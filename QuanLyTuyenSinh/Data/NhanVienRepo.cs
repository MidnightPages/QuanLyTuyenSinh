using Npgsql;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Data;

public static class NhanVienRepo
{
    private const string CotChon = @"
        SELECT n.MaNhanVien, n.MaTaiKhoan, t.TenDangNhap, n.HoTen, n.NgaySinh,
               n.GioiTinh, n.SoDienThoai, t.VaiTro, t.TrangThai
        FROM NhanVien n
        JOIN TaiKhoan t ON t.MaTaiKhoan = n.MaTaiKhoan";

    private static NhanVienItem DocDong(NpgsqlDataReader rd) => new()
    {
        MaNhanVien = rd.GetInt32(0),
        MaTaiKhoan = rd.GetInt32(1),
        TenDangNhap = rd.GetString(2),
        HoTen = rd.GetString(3),
        NgaySinh = rd.IsDBNull(4) ? null : rd.GetDateTime(4),
        GioiTinh = rd.IsDBNull(5) ? null : rd.GetString(5),
        SoDienThoai = rd.IsDBNull(6) ? null : rd.GetString(6),
        VaiTro = rd.GetString(7),
        TrangThai = rd.GetString(8)
    };

    /// <summary>Danh sách người dùng nội bộ, lọc theo từ khóa (họ tên, tên đăng nhập) và trạng thái tài khoản.</summary>
    public static List<NhanVienItem> LayDanhSach(string tuKhoa, string? trangThai)
    {
        string sql = CotChon + @"
            WHERE (@tk = '' OR n.HoTen ILIKE '%' || @tk || '%' OR t.TenDangNhap ILIKE '%' || @tk || '%')
              AND (@tt IS NULL OR t.TrangThai = @tt)
            ORDER BY n.MaNhanVien";

        var ds = new List<NhanVienItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("tk", tuKhoa);
        cmd.Parameters.Add(Sql.Chuoi("tt", trangThai));
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) ds.Add(DocDong(rd));
        return ds;
    }

    /// <summary>Nhân viên tuyển sinh đang hoạt động, dùng để chọn khi phân công.</summary>
    public static List<NhanVienItem> LayNhanVienPhanCong()
    {
        string sql = CotChon + @"
            WHERE t.VaiTro = @vt AND t.TrangThai = 'Hoạt động'
            ORDER BY n.HoTen";

        var ds = new List<NhanVienItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("vt", VaiTro.NhanVien);
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) ds.Add(DocDong(rd));
        return ds;
    }

    /// <summary>Tạo tài khoản và thông tin nhân viên trong cùng một giao dịch.</summary>
    public static void Them(NhanVienItem nv, string matKhau)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(matKhau);

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var tx = conn.BeginTransaction();
        try
        {
            int maTaiKhoan;
            using (var c1 = new NpgsqlCommand(@"
                INSERT INTO TaiKhoan (TenDangNhap, MatKhauHash, VaiTro, TrangThai)
                VALUES (@u, @h, @vt, @tt) RETURNING MaTaiKhoan", conn, tx))
            {
                c1.Parameters.AddWithValue("u", nv.TenDangNhap);
                c1.Parameters.AddWithValue("h", hash);
                c1.Parameters.AddWithValue("vt", nv.VaiTro);
                c1.Parameters.AddWithValue("tt", nv.TrangThai);
                maTaiKhoan = (int)c1.ExecuteScalar()!;
            }

            using (var c2 = new NpgsqlCommand(@"
                INSERT INTO NhanVien (MaTaiKhoan, HoTen, NgaySinh, GioiTinh, SoDienThoai)
                VALUES (@tk, @ten, @ns, @gt, @sdt) RETURNING MaNhanVien", conn, tx))
            {
                c2.Parameters.AddWithValue("tk", maTaiKhoan);
                c2.Parameters.AddWithValue("ten", nv.HoTen);
                c2.Parameters.Add(Sql.NgayNull("ns", nv.NgaySinh));
                c2.Parameters.Add(Sql.Chuoi("gt", nv.GioiTinh));
                c2.Parameters.Add(Sql.Chuoi("sdt", nv.SoDienThoai));
                nv.MaNhanVien = (int)c2.ExecuteScalar()!;
            }

            tx.Commit();
            nv.MaTaiKhoan = maTaiKhoan;
        }
        catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            throw new InvalidOperationException("Tên đăng nhập đã tồn tại. Hãy chọn tên khác.");
        }
    }

    /// <summary>Sửa thông tin cá nhân, vai trò và trạng thái tài khoản (không đổi tên đăng nhập, mật khẩu).</summary>
    public static void Sua(NhanVienItem nv)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var tx = conn.BeginTransaction();

        using (var c1 = new NpgsqlCommand(
            "UPDATE TaiKhoan SET VaiTro = @vt, TrangThai = @tt WHERE MaTaiKhoan = @tk", conn, tx))
        {
            c1.Parameters.AddWithValue("vt", nv.VaiTro);
            c1.Parameters.AddWithValue("tt", nv.TrangThai);
            c1.Parameters.AddWithValue("tk", nv.MaTaiKhoan);
            c1.ExecuteNonQuery();
        }

        using (var c2 = new NpgsqlCommand(@"
            UPDATE NhanVien
            SET HoTen = @ten, NgaySinh = @ns, GioiTinh = @gt, SoDienThoai = @sdt
            WHERE MaNhanVien = @nv", conn, tx))
        {
            c2.Parameters.AddWithValue("ten", nv.HoTen);
            c2.Parameters.Add(Sql.NgayNull("ns", nv.NgaySinh));
            c2.Parameters.Add(Sql.Chuoi("gt", nv.GioiTinh));
            c2.Parameters.Add(Sql.Chuoi("sdt", nv.SoDienThoai));
            c2.Parameters.AddWithValue("nv", nv.MaNhanVien);
            c2.ExecuteNonQuery();
        }

        tx.Commit();
    }

    public static void DatLaiMatKhau(int maTaiKhoan, string matKhauMoi)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(matKhauMoi);
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand("UPDATE TaiKhoan SET MatKhauHash = @h WHERE MaTaiKhoan = @tk", conn);
        cmd.Parameters.AddWithValue("h", hash);
        cmd.Parameters.AddWithValue("tk", maTaiKhoan);
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Đã có phân công hoặc đã xác nhận hồ sơ thì chuyển tài khoản sang "Đã khóa", ngược lại xóa hẳn
    /// (thông tin nhân viên xóa kèm). Trả về true nếu đã xóa hẳn.
    /// </summary>
    public static bool XoaHoacKhoa(NhanVienItem nv)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();

        const string kiemTra = @"
            SELECT EXISTS (SELECT 1 FROM PhanCongTuyenSinh WHERE MaNhanVien = @id)
                OR EXISTS (SELECT 1 FROM HoSoDangKy WHERE MaNhanVienXacNhan = @id)";
        bool coDuLieu;
        using (var kt = new NpgsqlCommand(kiemTra, conn))
        {
            kt.Parameters.AddWithValue("id", nv.MaNhanVien);
            coDuLieu = (bool)kt.ExecuteScalar()!;
        }

        if (coDuLieu)
        {
            using var up = new NpgsqlCommand("UPDATE TaiKhoan SET TrangThai = 'Đã khóa' WHERE MaTaiKhoan = @tk", conn);
            up.Parameters.AddWithValue("tk", nv.MaTaiKhoan);
            up.ExecuteNonQuery();
            return false;
        }

        using var del = new NpgsqlCommand("DELETE FROM TaiKhoan WHERE MaTaiKhoan = @tk", conn);
        del.Parameters.AddWithValue("tk", nv.MaTaiKhoan);
        del.ExecuteNonQuery();
        return true;
    }
}
