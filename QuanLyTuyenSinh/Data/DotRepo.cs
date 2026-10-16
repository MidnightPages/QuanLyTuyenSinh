using Npgsql;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Data;

public static class DotRepo
{
    // ----------------------------------------------------------------
    // Đợt tuyển sinh
    // ----------------------------------------------------------------
    public static List<DotTuyenSinh> LayDanhSach(string tuKhoa, string? trangThai)
    {
        const string sql = @"
            SELECT d.MaDot, d.TenDot, d.NgayBatDau, d.NgayKetThuc, d.TrangThai, d.MoTa,
                   (SELECT COUNT(*) FROM DotKhoaHoc dk WHERE dk.MaDot = d.MaDot) AS SoKhoaHoc,
                   (SELECT COUNT(*) FROM HoSoDangKy h
                        JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = h.MaDotKhoaHoc
                        WHERE dk.MaDot = d.MaDot) AS SoHoSo
            FROM DotTuyenSinh d
            WHERE (@tk = '' OR d.TenDot ILIKE '%' || @tk || '%')
              AND (@tt IS NULL OR d.TrangThai = @tt)
            ORDER BY d.NgayBatDau DESC, d.MaDot DESC";

        var ds = new List<DotTuyenSinh>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("tk", tuKhoa);
        cmd.Parameters.Add(Sql.Chuoi("tt", trangThai));
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new DotTuyenSinh
            {
                MaDot = rd.GetInt32(0),
                TenDot = rd.GetString(1),
                NgayBatDau = rd.GetDateTime(2),
                NgayKetThuc = rd.GetDateTime(3),
                TrangThai = rd.GetString(4),
                MoTa = rd.IsDBNull(5) ? null : rd.GetString(5),
                SoKhoaHoc = (int)rd.GetInt64(6),
                SoHoSo = (int)rd.GetInt64(7)
            });
        }
        return ds;
    }

    public static void Them(DotTuyenSinh d)
    {
        const string sql = @"
            INSERT INTO DotTuyenSinh (TenDot, NgayBatDau, NgayKetThuc, TrangThai, MoTa)
            VALUES (@ten, @bd, @kt, @tt, @mt)
            RETURNING MaDot";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("ten", d.TenDot);
        cmd.Parameters.Add(Sql.Ngay("bd", d.NgayBatDau));
        cmd.Parameters.Add(Sql.Ngay("kt", d.NgayKetThuc));
        cmd.Parameters.AddWithValue("tt", d.TrangThai);
        cmd.Parameters.Add(Sql.Chuoi("mt", d.MoTa));
        d.MaDot = (int)cmd.ExecuteScalar()!;
    }

    public static void Sua(DotTuyenSinh d)
    {
        const string sql = @"
            UPDATE DotTuyenSinh
            SET TenDot = @ten, NgayBatDau = @bd, NgayKetThuc = @kt, TrangThai = @tt, MoTa = @mt
            WHERE MaDot = @ma";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("ten", d.TenDot);
        cmd.Parameters.Add(Sql.Ngay("bd", d.NgayBatDau));
        cmd.Parameters.Add(Sql.Ngay("kt", d.NgayKetThuc));
        cmd.Parameters.AddWithValue("tt", d.TrangThai);
        cmd.Parameters.Add(Sql.Chuoi("mt", d.MoTa));
        cmd.Parameters.AddWithValue("ma", d.MaDot);
        cmd.ExecuteNonQuery();
    }

    private static long Dem(NpgsqlConnection conn, NpgsqlTransaction tx, string sql, int id)
    {
        using var cmd = new NpgsqlCommand(sql, conn, tx);
        cmd.Parameters.AddWithValue("id", id);
        return (long)cmd.ExecuteScalar()!;
    }

    /// <summary>
    /// Đợt đã có hồ sơ hoặc đã có phân công thì chuyển sang "Đã ngừng", ngược lại xóa hẳn
    /// (kèm danh sách khóa học của đợt). Trả về true nếu đã xóa hẳn.
    /// </summary>
    public static bool XoaHoacNgung(int maDot)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var tx = conn.BeginTransaction();

        long soHoSo = Dem(conn, tx, @"
            SELECT COUNT(*) FROM HoSoDangKy h
            JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = h.MaDotKhoaHoc
            WHERE dk.MaDot = @id", maDot);
        long soPhanCong = Dem(conn, tx, @"
            SELECT COUNT(*) FROM PhanCongTuyenSinh pc
            JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = pc.MaDotKhoaHoc
            WHERE dk.MaDot = @id", maDot);

        if (soHoSo > 0 || soPhanCong > 0)
        {
            using var up = new NpgsqlCommand("UPDATE DotTuyenSinh SET TrangThai = 'Đã ngừng' WHERE MaDot = @id", conn, tx);
            up.Parameters.AddWithValue("id", maDot);
            up.ExecuteNonQuery();
            tx.Commit();
            return false;
        }

        using (var d1 = new NpgsqlCommand("DELETE FROM DotKhoaHoc WHERE MaDot = @id", conn, tx))
        {
            d1.Parameters.AddWithValue("id", maDot);
            d1.ExecuteNonQuery();
        }
        using (var d2 = new NpgsqlCommand("DELETE FROM DotTuyenSinh WHERE MaDot = @id", conn, tx))
        {
            d2.Parameters.AddWithValue("id", maDot);
            d2.ExecuteNonQuery();
        }
        tx.Commit();
        return true;
    }

    /// <summary>Nhân viên có được phân công ở ít nhất một khóa học trong đợt này không.</summary>
    public static bool NhanVienDuocPhanCong(int maDot, int maNhanVien)
    {
        const string sql = @"
            SELECT EXISTS (
                SELECT 1 FROM PhanCongTuyenSinh pc
                JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = pc.MaDotKhoaHoc
                WHERE dk.MaDot = @dot AND pc.MaNhanVien = @nv)";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("dot", maDot);
        cmd.Parameters.AddWithValue("nv", maNhanVien);
        return (bool)cmd.ExecuteScalar()!;
    }

    // ----------------------------------------------------------------
    // Khóa học trong đợt (bảng DotKhoaHoc)
    // ----------------------------------------------------------------
    public static List<DotKhoaHocItem> LayKhoaHocTrongDot(int maDot)
    {
        const string sql = @"
            SELECT dk.MaDotKhoaHoc, k.MaKhoaHoc, k.TenKhoaHoc, k.HocPhi, k.ThoiLuong, k.TrangThai,
                   (SELECT COUNT(*) FROM HoSoDangKy h WHERE h.MaDotKhoaHoc = dk.MaDotKhoaHoc) AS SoHoSo,
                   (SELECT COUNT(*) FROM PhanCongTuyenSinh pc WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc) AS SoNhanVien
            FROM DotKhoaHoc dk
            JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
            WHERE dk.MaDot = @dot
            ORDER BY k.TenKhoaHoc";

        var ds = new List<DotKhoaHocItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("dot", maDot);
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new DotKhoaHocItem
            {
                MaDotKhoaHoc = rd.GetInt32(0),
                MaKhoaHoc = rd.GetInt32(1),
                TenKhoaHoc = rd.GetString(2),
                HocPhi = rd.GetDecimal(3),
                ThoiLuong = rd.IsDBNull(4) ? null : rd.GetString(4),
                TrangThaiKhoaHoc = rd.GetString(5),
                SoHoSo = (int)rd.GetInt64(6),
                SoNhanVien = (int)rd.GetInt64(7)
            });
        }
        return ds;
    }

    /// <summary>Các khóa học đang mở nhưng chưa được thêm vào đợt này.</summary>
    public static List<KhoaHoc> LayKhoaHocChuaCoTrongDot(int maDot)
    {
        const string sql = @"
            SELECT k.MaKhoaHoc, k.TenKhoaHoc, k.HocPhi, k.ThoiLuong, k.TrangThai
            FROM KhoaHoc k
            WHERE k.TrangThai = 'Đang mở'
              AND NOT EXISTS (SELECT 1 FROM DotKhoaHoc dk WHERE dk.MaDot = @dot AND dk.MaKhoaHoc = k.MaKhoaHoc)
            ORDER BY k.TenKhoaHoc";

        var ds = new List<KhoaHoc>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("dot", maDot);
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new KhoaHoc
            {
                MaKhoaHoc = rd.GetInt32(0),
                TenKhoaHoc = rd.GetString(1),
                HocPhi = rd.GetDecimal(2),
                ThoiLuong = rd.IsDBNull(3) ? null : rd.GetString(3),
                TrangThai = rd.GetString(4)
            });
        }
        return ds;
    }

    public static void ThemKhoaHocVaoDot(int maDot, int maKhoaHoc)
    {
        const string sql = @"
            INSERT INTO DotKhoaHoc (MaDot, MaKhoaHoc) VALUES (@dot, @kh)
            ON CONFLICT (MaDot, MaKhoaHoc) DO NOTHING";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("dot", maDot);
        cmd.Parameters.AddWithValue("kh", maKhoaHoc);
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Gỡ khóa học khỏi đợt. Trả về null nếu thành công, hoặc thông báo lỗi nếu khóa học
    /// đã có hồ sơ đăng ký hoặc đã được phân công nhân viên.
    /// </summary>
    public static string? GoKhoaHocKhoiDot(int maDotKhoaHoc)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();

        const string kiemTra = @"
            SELECT (SELECT COUNT(*) FROM HoSoDangKy WHERE MaDotKhoaHoc = @id) +
                   (SELECT COUNT(*) FROM PhanCongTuyenSinh WHERE MaDotKhoaHoc = @id)";
        using (var kt = new NpgsqlCommand(kiemTra, conn))
        {
            kt.Parameters.AddWithValue("id", maDotKhoaHoc);
            long tong = (long)kt.ExecuteScalar()!;
            if (tong > 0)
                return "Không thể gỡ vì khóa học này đã có hồ sơ đăng ký hoặc đã được phân công nhân viên.";
        }

        using var del = new NpgsqlCommand("DELETE FROM DotKhoaHoc WHERE MaDotKhoaHoc = @id", conn);
        del.Parameters.AddWithValue("id", maDotKhoaHoc);
        del.ExecuteNonQuery();
        return null;
    }

    /// <summary>
    /// Danh sách khóa học để tích chọn cho một đợt: các khóa đang mở và cả những khóa
    /// đã thuộc đợt (kể cả khi khóa đó đã ngừng). maDot = null khi đang thêm đợt mới.
    /// </summary>
    public static List<KhoaHocChonItem> LayKhoaHocChoDot(int? maDot)
    {
        const string sql = @"
            SELECT x.MaKhoaHoc, x.TenKhoaHoc, x.CoTrongDot, x.CoDuLieu
            FROM (
                SELECT k.MaKhoaHoc, k.TenKhoaHoc, k.TrangThai,
                       EXISTS (SELECT 1 FROM DotKhoaHoc dk
                               WHERE dk.MaDot = @dot AND dk.MaKhoaHoc = k.MaKhoaHoc) AS CoTrongDot,
                       EXISTS (SELECT 1 FROM DotKhoaHoc dk
                               WHERE dk.MaDot = @dot AND dk.MaKhoaHoc = k.MaKhoaHoc
                                 AND (EXISTS (SELECT 1 FROM HoSoDangKy h WHERE h.MaDotKhoaHoc = dk.MaDotKhoaHoc)
                                   OR EXISTS (SELECT 1 FROM PhanCongTuyenSinh pc WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc))
                              ) AS CoDuLieu
                FROM KhoaHoc k
            ) x
            WHERE x.TrangThai = 'Đang mở' OR x.CoTrongDot
            ORDER BY x.TenKhoaHoc";

        var ds = new List<KhoaHocChonItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.Add(Sql.So("dot", maDot));
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new KhoaHocChonItem
            {
                MaKhoaHoc = rd.GetInt32(0),
                TenKhoaHoc = rd.GetString(1),
                CoTrongDot = rd.GetBoolean(2),
                CoDuLieu = rd.GetBoolean(3)
            });
        }
        return ds;
    }

    /// <summary>
    /// Đặt danh sách khóa học của đợt đúng bằng khoaHocCanCo: khóa mới được thêm, khóa không còn trong
    /// danh sách bị gỡ (trừ khóa đã có hồ sơ hoặc phân công). Trả về null nếu thành công, hoặc thông báo lỗi.
    /// </summary>
    public static string? LuuKhoaHocTrongDot(int maDot, IEnumerable<int> khoaHocCanCo)
    {
        var dich = new HashSet<int>(khoaHocCanCo);

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var tx = conn.BeginTransaction();

        var hienTai = new HashSet<int>();
        using (var cmd = new NpgsqlCommand("SELECT MaKhoaHoc FROM DotKhoaHoc WHERE MaDot = @dot", conn, tx))
        {
            cmd.Parameters.AddWithValue("dot", maDot);
            using var rd = cmd.ExecuteReader();
            while (rd.Read()) hienTai.Add(rd.GetInt32(0));
        }

        foreach (int kh in hienTai.Except(dich))
        {
            using var kt = new NpgsqlCommand(@"
                SELECT (SELECT COUNT(*) FROM HoSoDangKy h
                        JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = h.MaDotKhoaHoc
                        WHERE dk.MaDot = @dot AND dk.MaKhoaHoc = @kh)
                     + (SELECT COUNT(*) FROM PhanCongTuyenSinh pc
                        JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = pc.MaDotKhoaHoc
                        WHERE dk.MaDot = @dot AND dk.MaKhoaHoc = @kh)", conn, tx);
            kt.Parameters.AddWithValue("dot", maDot);
            kt.Parameters.AddWithValue("kh", kh);
            if ((long)kt.ExecuteScalar()! > 0)
                return "Không thể gỡ khóa học đã có hồ sơ đăng ký hoặc đã được phân công nhân viên.";   // giao dịch tự hủy

            using var del = new NpgsqlCommand(
                "DELETE FROM DotKhoaHoc WHERE MaDot = @dot AND MaKhoaHoc = @kh", conn, tx);
            del.Parameters.AddWithValue("dot", maDot);
            del.Parameters.AddWithValue("kh", kh);
            del.ExecuteNonQuery();
        }

        foreach (int kh in dich.Except(hienTai))
        {
            using var ins = new NpgsqlCommand(@"
                INSERT INTO DotKhoaHoc (MaDot, MaKhoaHoc) VALUES (@dot, @kh)
                ON CONFLICT (MaDot, MaKhoaHoc) DO NOTHING", conn, tx);
            ins.Parameters.AddWithValue("dot", maDot);
            ins.Parameters.AddWithValue("kh", kh);
            ins.ExecuteNonQuery();
        }

        tx.Commit();
        return null;
    }

    /// <summary>Đếm dữ liệu sẽ bị xóa cùng đợt này (để cảnh báo trước khi xóa).</summary>
    public static (int SoKhoaHoc, int SoHoSo, int SoPhanCong) DemDuLieuLienQuan(int maDot)
    {
        const string sql = @"
            SELECT (SELECT COUNT(*) FROM DotKhoaHoc WHERE MaDot = @id),
                   (SELECT COUNT(*) FROM HoSoDangKy h
                    JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = h.MaDotKhoaHoc
                    WHERE dk.MaDot = @id),
                   (SELECT COUNT(*) FROM PhanCongTuyenSinh pc
                    JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = pc.MaDotKhoaHoc
                    WHERE dk.MaDot = @id)";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id", maDot);
        using var rd = cmd.ExecuteReader();
        rd.Read();
        return ((int)rd.GetInt64(0), (int)rd.GetInt64(1), (int)rd.GetInt64(2));
    }

    /// <summary>Xóa vĩnh viễn đợt cùng toàn bộ hồ sơ, phân công và liên kết khóa-đợt của đợt đó.</summary>
    public static void XoaVinhVien(int maDot)
    {
        const string sql = @"
            DELETE FROM HoSoDangKy
            WHERE MaDotKhoaHoc IN (SELECT MaDotKhoaHoc FROM DotKhoaHoc WHERE MaDot = @id);
            DELETE FROM PhanCongTuyenSinh
            WHERE MaDotKhoaHoc IN (SELECT MaDotKhoaHoc FROM DotKhoaHoc WHERE MaDot = @id);
            DELETE FROM DotKhoaHoc WHERE MaDot = @id;
            DELETE FROM DotTuyenSinh WHERE MaDot = @id;";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var tx = conn.BeginTransaction();
        using var cmd = new NpgsqlCommand(sql, conn, tx);
        cmd.Parameters.AddWithValue("id", maDot);
        cmd.ExecuteNonQuery();
        tx.Commit();
    }
}
