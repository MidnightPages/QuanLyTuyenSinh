using Npgsql;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Data;

public static class KhoaHocRepo
{
    private static KhoaHoc DocDong(NpgsqlDataReader rd) => new()
    {
        MaKhoaHoc = rd.GetInt32(0),
        TenKhoaHoc = rd.GetString(1),
        HocPhi = rd.GetDecimal(2),
        ThoiLuong = rd.IsDBNull(3) ? null : rd.GetString(3),
        TrangThai = rd.GetString(4)
    };

    /// <summary>Lấy danh sách khóa học, lọc theo từ khóa (tên) và trạng thái (null = tất cả).</summary>
    public static List<KhoaHoc> LayDanhSach(string tuKhoa, string? trangThai)
    {
        const string sql = @"
            SELECT MaKhoaHoc, TenKhoaHoc, HocPhi, ThoiLuong, TrangThai
            FROM KhoaHoc
            WHERE (@tk = '' OR TenKhoaHoc ILIKE '%' || @tk || '%')
              AND (@tt IS NULL OR TrangThai = @tt)
            ORDER BY MaKhoaHoc";

        var ds = new List<KhoaHoc>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("tk", tuKhoa);
        cmd.Parameters.Add(Sql.Chuoi("tt", trangThai));
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) ds.Add(DocDong(rd));
        return ds;
    }

    public static void Them(KhoaHoc k)
    {
        const string sql = @"
            INSERT INTO KhoaHoc (TenKhoaHoc, HocPhi, ThoiLuong, TrangThai)
            VALUES (@ten, @hp, @tl, @tt)
            RETURNING MaKhoaHoc";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("ten", k.TenKhoaHoc);
        cmd.Parameters.AddWithValue("hp", k.HocPhi);
        cmd.Parameters.Add(Sql.Chuoi("tl", k.ThoiLuong));
        cmd.Parameters.AddWithValue("tt", k.TrangThai);
        k.MaKhoaHoc = (int)cmd.ExecuteScalar()!;
    }

    public static void Sua(KhoaHoc k)
    {
        const string sql = @"
            UPDATE KhoaHoc
            SET TenKhoaHoc = @ten, HocPhi = @hp, ThoiLuong = @tl, TrangThai = @tt
            WHERE MaKhoaHoc = @ma";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("ten", k.TenKhoaHoc);
        cmd.Parameters.AddWithValue("hp", k.HocPhi);
        cmd.Parameters.Add(Sql.Chuoi("tl", k.ThoiLuong));
        cmd.Parameters.AddWithValue("tt", k.TrangThai);
        cmd.Parameters.AddWithValue("ma", k.MaKhoaHoc);
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Khóa học đã thuộc một đợt nào đó thì chuyển sang "Đã ngừng", chưa thuộc đợt nào thì xóa hẳn.
    /// Trả về true nếu đã xóa hẳn, false nếu chỉ chuyển sang Đã ngừng.
    /// </summary>
    public static bool XoaHoacNgung(int maKhoaHoc)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();

        using (var kt = new NpgsqlCommand("SELECT EXISTS (SELECT 1 FROM DotKhoaHoc WHERE MaKhoaHoc = @ma)", conn))
        {
            kt.Parameters.AddWithValue("ma", maKhoaHoc);
            bool daThuocDot = (bool)kt.ExecuteScalar()!;

            if (daThuocDot)
            {
                using var up = new NpgsqlCommand("UPDATE KhoaHoc SET TrangThai = 'Đã ngừng' WHERE MaKhoaHoc = @ma", conn);
                up.Parameters.AddWithValue("ma", maKhoaHoc);
                up.ExecuteNonQuery();
                return false;
            }
        }

        using var del = new NpgsqlCommand("DELETE FROM KhoaHoc WHERE MaKhoaHoc = @ma", conn);
        del.Parameters.AddWithValue("ma", maKhoaHoc);
        del.ExecuteNonQuery();
        return true;
    }
    /// <summary>Đếm dữ liệu sẽ bị xóa cùng khóa học này (để cảnh báo trước khi xóa).</summary>
    public static (int SoDot, int SoHoSo, int SoPhanCong) DemDuLieuLienQuan(int maKhoaHoc)
    {
        const string sql = @"
            SELECT (SELECT COUNT(*) FROM DotKhoaHoc WHERE MaKhoaHoc = @id),
                   (SELECT COUNT(*) FROM HoSoDangKy h
                    JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = h.MaDotKhoaHoc
                    WHERE dk.MaKhoaHoc = @id),
                   (SELECT COUNT(*) FROM PhanCongTuyenSinh pc
                    JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = pc.MaDotKhoaHoc
                    WHERE dk.MaKhoaHoc = @id)";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id", maKhoaHoc);
        using var rd = cmd.ExecuteReader();
        rd.Read();
        return ((int)rd.GetInt64(0), (int)rd.GetInt64(1), (int)rd.GetInt64(2));
    }

    /// <summary>Xóa vĩnh viễn khóa học cùng toàn bộ hồ sơ, phân công và liên kết với các đợt.</summary>
    public static void XoaVinhVien(int maKhoaHoc)
    {
        const string sql = @"
            DELETE FROM HoSoDangKy
            WHERE MaDotKhoaHoc IN (SELECT MaDotKhoaHoc FROM DotKhoaHoc WHERE MaKhoaHoc = @id);
            DELETE FROM PhanCongTuyenSinh
            WHERE MaDotKhoaHoc IN (SELECT MaDotKhoaHoc FROM DotKhoaHoc WHERE MaKhoaHoc = @id);
            DELETE FROM DotKhoaHoc WHERE MaKhoaHoc = @id;
            DELETE FROM KhoaHoc WHERE MaKhoaHoc = @id;";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var tx = conn.BeginTransaction();
        using var cmd = new NpgsqlCommand(sql, conn, tx);
        cmd.Parameters.AddWithValue("id", maKhoaHoc);
        cmd.ExecuteNonQuery();
        tx.Commit();
    }
}
