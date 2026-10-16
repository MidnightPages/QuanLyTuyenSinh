using Npgsql;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Helpers;

namespace QuanLyTuyenSinh.Data;

public static class PhanCongRepo
{
    /// <summary>Danh sách phân công, lọc theo đợt và nhân viên (null = tất cả).</summary>
    public static List<PhanCongItem> LayDanhSach(int? maDot, int? maNhanVien)
    {
        const string sql = @"
            SELECT pc.MaPhanCong, pc.MaNhanVien, nv.HoTen, d.MaDot, d.TenDot, d.TrangThai,
                   k.MaKhoaHoc, k.TenKhoaHoc,
                   (SELECT COUNT(*) FROM HoSoDangKy h WHERE h.MaDotKhoaHoc = pc.MaDotKhoaHoc) AS SoHoSo
            FROM PhanCongTuyenSinh pc
            JOIN NhanVien nv ON nv.MaNhanVien = pc.MaNhanVien
            JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = pc.MaDotKhoaHoc
            JOIN DotTuyenSinh d ON d.MaDot = dk.MaDot
            JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
            WHERE (@dot IS NULL OR d.MaDot = @dot)
              AND (@nv IS NULL OR pc.MaNhanVien = @nv)
            ORDER BY d.NgayBatDau DESC, d.MaDot DESC, k.TenKhoaHoc, nv.HoTen";

        var ds = new List<PhanCongItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.Add(Sql.So("dot", maDot));
        cmd.Parameters.Add(Sql.So("nv", maNhanVien));
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new PhanCongItem
            {
                MaPhanCong = rd.GetInt32(0),
                MaNhanVien = rd.GetInt32(1),
                TenNhanVien = rd.GetString(2),
                MaDot = rd.GetInt32(3),
                TenDot = rd.GetString(4),
                TrangThaiDot = rd.GetString(5),
                MaKhoaHoc = rd.GetInt32(6),
                TenKhoaHoc = rd.GetString(7),
                SoHoSo = (int)rd.GetInt64(8)
            });
        }
        return ds;
    }

    private static int? TimDotKhoaHoc(NpgsqlConnection conn, int maDot, int maKhoaHoc)
    {
        using var cmd = new NpgsqlCommand(
            "SELECT MaDotKhoaHoc FROM DotKhoaHoc WHERE MaDot = @dot AND MaKhoaHoc = @kh", conn);
        cmd.Parameters.AddWithValue("dot", maDot);
        cmd.Parameters.AddWithValue("kh", maKhoaHoc);
        var kq = cmd.ExecuteScalar();
        return kq == null ? null : (int)kq;
    }

    // Nhân viên đã xác nhận hồ sơ của khóa-đợt này thì không được gỡ hay đổi phân công
    // (trigger trong CSDL yêu cầu người xác nhận hồ sơ phải còn được phân công).
    private static bool DaXacNhanHoSo(NpgsqlConnection conn, int maNhanVien, int maDotKhoaHoc)
    {
        using var cmd = new NpgsqlCommand(@"
            SELECT EXISTS (SELECT 1 FROM HoSoDangKy
                           WHERE MaDotKhoaHoc = @dk AND MaNhanVienXacNhan = @nv)", conn);
        cmd.Parameters.AddWithValue("dk", maDotKhoaHoc);
        cmd.Parameters.AddWithValue("nv", maNhanVien);
        return (bool)cmd.ExecuteScalar()!;
    }

    private const string LoiDaXacNhan =
        "Nhân viên này đã xác nhận hồ sơ của khóa học này nên không thể đổi hoặc gỡ phân công.";
    private const string LoiTrung =
        "Nhân viên này đã được phân công khóa học này trong đợt đã chọn.";

    /// <summary>Thêm phân công. Trả về null nếu thành công, hoặc thông báo lỗi.</summary>
    public static string? Them(int maNhanVien, int maDot, int maKhoaHoc)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();

        int? maDotKhoaHoc = TimDotKhoaHoc(conn, maDot, maKhoaHoc);
        if (maDotKhoaHoc == null) return "Khóa học này chưa được thêm vào đợt đã chọn.";

        try
        {
            using var cmd = new NpgsqlCommand(
                "INSERT INTO PhanCongTuyenSinh (MaNhanVien, MaDotKhoaHoc) VALUES (@nv, @dk)", conn);
            cmd.Parameters.AddWithValue("nv", maNhanVien);
            cmd.Parameters.AddWithValue("dk", maDotKhoaHoc.Value);
            cmd.ExecuteNonQuery();
            return null;
        }
        catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            return LoiTrung;
        }
    }

    /// <summary>Sửa phân công. Trả về null nếu thành công, hoặc thông báo lỗi.</summary>
    public static string? Sua(int maPhanCong, int maNhanVien, int maDot, int maKhoaHoc)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();

        int? maDotKhoaHoc = TimDotKhoaHoc(conn, maDot, maKhoaHoc);
        if (maDotKhoaHoc == null) return "Khóa học này chưa được thêm vào đợt đã chọn.";

        int nvCu, dkCu;
        using (var cmd = new NpgsqlCommand(
            "SELECT MaNhanVien, MaDotKhoaHoc FROM PhanCongTuyenSinh WHERE MaPhanCong = @id", conn))
        {
            cmd.Parameters.AddWithValue("id", maPhanCong);
            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return "Không tìm thấy phân công (có thể đã bị xóa).";
            nvCu = rd.GetInt32(0);
            dkCu = rd.GetInt32(1);
        }

        bool coDoi = nvCu != maNhanVien || dkCu != maDotKhoaHoc.Value;
        if (coDoi && DaXacNhanHoSo(conn, nvCu, dkCu)) return LoiDaXacNhan;

        try
        {
            using var up = new NpgsqlCommand(
                "UPDATE PhanCongTuyenSinh SET MaNhanVien = @nv, MaDotKhoaHoc = @dk WHERE MaPhanCong = @id", conn);
            up.Parameters.AddWithValue("nv", maNhanVien);
            up.Parameters.AddWithValue("dk", maDotKhoaHoc.Value);
            up.Parameters.AddWithValue("id", maPhanCong);
            up.ExecuteNonQuery();
            return null;
        }
        catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            return LoiTrung;
        }
    }

    /// <summary>Xóa phân công. Trả về null nếu thành công, hoặc thông báo lỗi.</summary>
    public static string? Xoa(int maPhanCong)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();

        int nvCu, dkCu;
        using (var cmd = new NpgsqlCommand(
            "SELECT MaNhanVien, MaDotKhoaHoc FROM PhanCongTuyenSinh WHERE MaPhanCong = @id", conn))
        {
            cmd.Parameters.AddWithValue("id", maPhanCong);
            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return null; // đã bị xóa từ trước
            nvCu = rd.GetInt32(0);
            dkCu = rd.GetInt32(1);
        }

        if (DaXacNhanHoSo(conn, nvCu, dkCu)) return LoiDaXacNhan;

        using var del = new NpgsqlCommand("DELETE FROM PhanCongTuyenSinh WHERE MaPhanCong = @id", conn);
        del.Parameters.AddWithValue("id", maPhanCong);
        del.ExecuteNonQuery();
        return null;
    }

    /// <summary>
    /// Các khóa học của một đợt, mỗi khóa một dòng, kèm tên tất cả nhân viên phụ trách.
    /// maNhanVienPhamVi = null: tất cả khóa (quản trị viên); có giá trị: chỉ khóa nhân viên đó phụ trách.
    /// </summary>
    public static List<PhanCongKhoaItem> LayTheoDot(int maDot, int? maNhanVienPhamVi)
    {
        const string sql = @"
            SELECT dk.MaDotKhoaHoc, k.MaKhoaHoc, k.TenKhoaHoc,
                   COALESCE((SELECT string_agg(nv.HoTen, ', ' ORDER BY nv.HoTen)
                             FROM PhanCongTuyenSinh pc
                             JOIN NhanVien nv ON nv.MaNhanVien = pc.MaNhanVien
                             WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc), '') AS NhanVienPhuTrach,
                   (SELECT COUNT(*) FROM PhanCongTuyenSinh pc
                    WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc) AS SoNhanVien,
                   (SELECT COUNT(*) FROM HoSoDangKy h
                    WHERE h.MaDotKhoaHoc = dk.MaDotKhoaHoc) AS SoHoSo
            FROM DotKhoaHoc dk
            JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
            WHERE dk.MaDot = @dot
              AND (@nv IS NULL OR EXISTS (
                    SELECT 1 FROM PhanCongTuyenSinh pcx
                    WHERE pcx.MaDotKhoaHoc = dk.MaDotKhoaHoc AND pcx.MaNhanVien = @nv))
            ORDER BY k.TenKhoaHoc";

        var ds = new List<PhanCongKhoaItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("dot", maDot);
        cmd.Parameters.Add(Sql.So("nv", maNhanVienPhamVi));
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new PhanCongKhoaItem
            {
                MaDotKhoaHoc = rd.GetInt32(0),
                MaKhoaHoc = rd.GetInt32(1),
                TenKhoaHoc = rd.GetString(2),
                NhanVienPhuTrach = rd.GetString(3),
                SoNhanVien = (int)rd.GetInt64(4),
                SoHoSo = (int)rd.GetInt64(5)
            });
        }
        return ds;
    }

    /// <summary>
    /// Danh sách nhân viên để chọn phân công cho một khóa-đợt: các nhân viên đang hoạt động
    /// và cả những người đang phụ trách khóa này (kể cả khi tài khoản đã bị khóa).
    /// </summary>
    public static List<NhanVienPhanCongItem> LayNhanVienChoKhoa(int maDotKhoaHoc)
    {
        const string sql = @"
            SELECT x.MaNhanVien, x.HoTen, x.TenDangNhap, x.DuocPhanCong, x.DaXacNhan
            FROM (
                SELECT n.MaNhanVien, n.HoTen, t.TenDangNhap, t.TrangThai,
                       EXISTS (SELECT 1 FROM PhanCongTuyenSinh pc
                               WHERE pc.MaNhanVien = n.MaNhanVien AND pc.MaDotKhoaHoc = @dk) AS DuocPhanCong,
                       EXISTS (SELECT 1 FROM HoSoDangKy h
                               WHERE h.MaDotKhoaHoc = @dk AND h.MaNhanVienXacNhan = n.MaNhanVien) AS DaXacNhan
                FROM NhanVien n
                JOIN TaiKhoan t ON t.MaTaiKhoan = n.MaTaiKhoan
                WHERE t.VaiTro = @vt
            ) x
            WHERE x.TrangThai = 'Hoạt động' OR x.DuocPhanCong
            ORDER BY x.HoTen";

        var ds = new List<NhanVienPhanCongItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("dk", maDotKhoaHoc);
        cmd.Parameters.AddWithValue("vt", VaiTro.NhanVien);
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new NhanVienPhanCongItem
            {
                MaNhanVien = rd.GetInt32(0),
                HoTen = rd.GetString(1),
                TenDangNhap = rd.GetString(2),
                DuocPhanCong = rd.GetBoolean(3),
                DaXacNhan = rd.GetBoolean(4)
            });
        }
        return ds;
    }

    /// <summary>
    /// Đặt danh sách nhân viên phụ trách của một khóa-đợt đúng bằng nhanVienCanCo:
    /// người mới được thêm, người không còn trong danh sách bị gỡ. Trả về null nếu thành công, hoặc thông báo lỗi.
    /// </summary>
    public static string? LuuPhanCong(int maDotKhoaHoc, IEnumerable<int> nhanVienCanCo)
    {
        var dich = new HashSet<int>(nhanVienCanCo);

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var tx = conn.BeginTransaction();

        // Đợt đã ngừng thì không thay đổi phân công
        using (var ktDot = new NpgsqlCommand(@"
            SELECT d.TrangThai
            FROM DotKhoaHoc dk
            JOIN DotTuyenSinh d ON d.MaDot = dk.MaDot
            WHERE dk.MaDotKhoaHoc = @dk", conn, tx))
        {
            ktDot.Parameters.AddWithValue("dk", maDotKhoaHoc);
            string? trangThaiDot = ktDot.ExecuteScalar() as string;
            if (trangThaiDot == null) return "Không tìm thấy khóa học trong đợt (có thể đã bị xóa).";
            if (trangThaiDot == "Đã ngừng") return "Đợt tuyển sinh đã ngừng nên không thể thay đổi phân công.";
        }

        var hienTai = new HashSet<int>();
        using (var cmd = new NpgsqlCommand(
            "SELECT MaNhanVien FROM PhanCongTuyenSinh WHERE MaDotKhoaHoc = @dk", conn, tx))
        {
            cmd.Parameters.AddWithValue("dk", maDotKhoaHoc);
            using var rd = cmd.ExecuteReader();
            while (rd.Read()) hienTai.Add(rd.GetInt32(0));
        }

        // Gỡ những người không còn trong danh sách (trừ người đã xác nhận hồ sơ)
        foreach (int nv in hienTai.Except(dich))
        {
            using var kt = new NpgsqlCommand(@"
                SELECT EXISTS (SELECT 1 FROM HoSoDangKy
                               WHERE MaDotKhoaHoc = @dk AND MaNhanVienXacNhan = @nv)", conn, tx);
            kt.Parameters.AddWithValue("dk", maDotKhoaHoc);
            kt.Parameters.AddWithValue("nv", nv);
            if ((bool)kt.ExecuteScalar()!) return LoiDaXacNhan;   // thoát: giao dịch tự hủy

            using var del = new NpgsqlCommand(
                "DELETE FROM PhanCongTuyenSinh WHERE MaDotKhoaHoc = @dk AND MaNhanVien = @nv", conn, tx);
            del.Parameters.AddWithValue("dk", maDotKhoaHoc);
            del.Parameters.AddWithValue("nv", nv);
            del.ExecuteNonQuery();
        }

        // Thêm những người mới
        foreach (int nv in dich.Except(hienTai))
        {
            using var ins = new NpgsqlCommand(@"
                INSERT INTO PhanCongTuyenSinh (MaNhanVien, MaDotKhoaHoc) VALUES (@nv, @dk)
                ON CONFLICT (MaNhanVien, MaDotKhoaHoc) DO NOTHING", conn, tx);
            ins.Parameters.AddWithValue("nv", nv);
            ins.Parameters.AddWithValue("dk", maDotKhoaHoc);
            ins.ExecuteNonQuery();
        }

        tx.Commit();
        return null;
    }

    /// <summary>
    /// Các khóa học (ở mọi đợt) mà nhân viên đang phụ trách, kèm tên tất cả nhân viên của khóa đó.
    /// maDot, maKhoaHoc = null nghĩa là không lọc.
    /// </summary>
    public static List<PhanCongKhoaItem> LayPhanCongCuaToi(int maNhanVien, int? maDot, int? maKhoaHoc)
    {
        const string sql = @"
            SELECT dk.MaDotKhoaHoc, k.MaKhoaHoc, k.TenKhoaHoc, d.TenDot,
                   COALESCE((SELECT string_agg(nv.HoTen, ', ' ORDER BY nv.HoTen)
                             FROM PhanCongTuyenSinh pc
                             JOIN NhanVien nv ON nv.MaNhanVien = pc.MaNhanVien
                             WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc), '') AS NhanVienPhuTrach,
                   (SELECT COUNT(*) FROM PhanCongTuyenSinh pc
                    WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc) AS SoNhanVien,
                   (SELECT COUNT(*) FROM HoSoDangKy h
                    WHERE h.MaDotKhoaHoc = dk.MaDotKhoaHoc) AS SoHoSo
            FROM DotKhoaHoc dk
            JOIN DotTuyenSinh d ON d.MaDot = dk.MaDot
            JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
            WHERE EXISTS (SELECT 1 FROM PhanCongTuyenSinh pcx
                          WHERE pcx.MaDotKhoaHoc = dk.MaDotKhoaHoc AND pcx.MaNhanVien = @nv)
              AND (@dot IS NULL OR d.MaDot = @dot)
              AND (@kh IS NULL OR k.MaKhoaHoc = @kh)
            ORDER BY d.NgayBatDau DESC, d.MaDot DESC, k.TenKhoaHoc";

        var ds = new List<PhanCongKhoaItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("nv", maNhanVien);
        cmd.Parameters.Add(Sql.So("dot", maDot));
        cmd.Parameters.Add(Sql.So("kh", maKhoaHoc));
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new PhanCongKhoaItem
            {
                MaDotKhoaHoc = rd.GetInt32(0),
                MaKhoaHoc = rd.GetInt32(1),
                TenKhoaHoc = rd.GetString(2),
                TenDot = rd.GetString(3),
                NhanVienPhuTrach = rd.GetString(4),
                SoNhanVien = (int)rd.GetInt64(5),
                SoHoSo = (int)rd.GetInt64(6)
            });
        }
        return ds;
    }
}
