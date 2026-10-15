using System;
using System.Collections.Generic;
using System.Text;

using Npgsql;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Data;

public static class HoSoRepo
{
    // Đợt của hồ sơ h đã kết thúc (theo trạng thái hoặc đã qua ngày kết thúc)
    private const string DotDaKetThuc = @"EXISTS (
        SELECT 1 FROM DotKhoaHoc dkx
        JOIN DotTuyenSinh dx ON dx.MaDot = dkx.MaDot
        WHERE dkx.MaDotKhoaHoc = h.MaDotKhoaHoc
          AND (dx.TrangThai IN ('Đã kết thúc', 'Đã ngừng') OR dx.NgayKetThuc < CURRENT_DATE))";

    // Nhân viên @nv được phân công khóa-đợt của hồ sơ h
    private const string DuocPhanCong = @"EXISTS (
        SELECT 1 FROM PhanCongTuyenSinh pcx
        WHERE pcx.MaNhanVien = @nv AND pcx.MaDotKhoaHoc = h.MaDotKhoaHoc)";

    /// <summary>maNhanVienPhamVi = null: xem tất cả (quản trị viên); có giá trị: chỉ hồ sơ nhân viên đó phụ trách.</summary>
    public static List<HoSoItem> LayDanhSach(int? maDot, int? maKhoaHoc, string? trangThai,
                                             string tuKhoa, int? maNhanVienPhamVi)
    {
        string sql = @"
            SELECT h.MaHoSo, h.MaDotKhoaHoc, d.MaDot, d.TenDot, k.MaKhoaHoc, k.TenKhoaHoc,
                   h.HoTen, h.NgaySinh, h.SoDienThoai, h.Email, h.DiaChi, h.NgayDangKy,
                   h.TrangThaiHoSo, h.MaNhanVienXacNhan, nv.HoTen, h.NgayXacNhan,
                   (d.TrangThai IN ('Đã kết thúc', 'Đã ngừng') OR d.NgayKetThuc < CURRENT_DATE) AS DaKetThuc
            FROM HoSoDangKy h
            JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = h.MaDotKhoaHoc
            JOIN DotTuyenSinh d ON d.MaDot = dk.MaDot
            JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
            LEFT JOIN NhanVien nv ON nv.MaNhanVien = h.MaNhanVienXacNhan
            WHERE (@dot IS NULL OR d.MaDot = @dot)
              AND (@kh IS NULL OR k.MaKhoaHoc = @kh)
              AND (@tt IS NULL OR h.TrangThaiHoSo = @tt)
              AND (@tk = '' OR h.HoTen ILIKE '%' || @tk || '%'
                            OR h.SoDienThoai ILIKE '%' || @tk || '%'
                            OR h.Email ILIKE '%' || @tk || '%')
              AND (@nv IS NULL OR " + DuocPhanCong + @")
            ORDER BY h.NgayDangKy DESC, h.MaHoSo DESC";

        var ds = new List<HoSoItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.Add(Sql.So("dot", maDot));
        cmd.Parameters.Add(Sql.So("kh", maKhoaHoc));
        cmd.Parameters.Add(Sql.Chuoi("tt", trangThai));
        cmd.Parameters.AddWithValue("tk", tuKhoa);
        cmd.Parameters.Add(Sql.So("nv", maNhanVienPhamVi));
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new HoSoItem
            {
                MaHoSo = rd.GetInt32(0),
                MaDotKhoaHoc = rd.GetInt32(1),
                MaDot = rd.GetInt32(2),
                TenDot = rd.GetString(3),
                MaKhoaHoc = rd.GetInt32(4),
                TenKhoaHoc = rd.GetString(5),
                HoTen = rd.GetString(6),
                NgaySinh = rd.IsDBNull(7) ? null : rd.GetDateTime(7),
                SoDienThoai = rd.GetString(8),
                Email = rd.GetString(9),
                DiaChi = rd.IsDBNull(10) ? null : rd.GetString(10),
                NgayDangKy = rd.GetDateTime(11),
                TrangThaiHoSo = rd.GetString(12),
                MaNhanVienXacNhan = rd.IsDBNull(13) ? null : rd.GetInt32(13),
                TenNhanVienXacNhan = rd.IsDBNull(14) ? null : rd.GetString(14),
                NgayXacNhan = rd.IsDBNull(15) ? null : rd.GetDateTime(15),
                DaKetThuc = rd.GetBoolean(16)
            });
        }
        return ds;
    }

    /// <summary>Các đợt có khóa học thuộc phạm vi (maNhanVien = null: tất cả đợt có khóa học).</summary>
    public static List<LuaChon> LayDotTrongPhamVi(int? maNhanVien)
    {
        const string sql = @"
            SELECT d.MaDot, d.TenDot
            FROM DotTuyenSinh d
            WHERE EXISTS (
                SELECT 1 FROM DotKhoaHoc dk
                WHERE dk.MaDot = d.MaDot
                  AND (@nv IS NULL OR EXISTS (
                        SELECT 1 FROM PhanCongTuyenSinh pc
                        WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc AND pc.MaNhanVien = @nv)))
            ORDER BY d.NgayBatDau DESC, d.MaDot DESC";

        var ds = new List<LuaChon>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.Add(Sql.So("nv", maNhanVien));
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) ds.Add(new LuaChon(rd.GetInt32(0), rd.GetString(1)));
        return ds;
    }

    /// <summary>Các khóa học thuộc phạm vi, có thể lọc theo đợt (maDot = null: mọi đợt).</summary>
    public static List<LuaChon> LayKhoaHocTrongPhamVi(int? maDot, int? maNhanVien)
    {
        const string sql = @"
            SELECT DISTINCT k.MaKhoaHoc, k.TenKhoaHoc
            FROM DotKhoaHoc dk
            JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
            WHERE (@dot IS NULL OR dk.MaDot = @dot)
              AND (@nv IS NULL OR EXISTS (
                    SELECT 1 FROM PhanCongTuyenSinh pc
                    WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc AND pc.MaNhanVien = @nv))
            ORDER BY k.TenKhoaHoc";

        var ds = new List<LuaChon>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.Add(Sql.So("dot", maDot));
        cmd.Parameters.Add(Sql.So("nv", maNhanVien));
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) ds.Add(new LuaChon(rd.GetInt32(0), rd.GetString(1)));
        return ds;
    }

    /// <summary>
    /// Lưu trạng thái các hồ sơ đã đổi. Mỗi hồ sơ được cập nhật riêng: hồ sơ nào không hợp lệ
    /// (đợt đã kết thúc, đã do nhân viên khác xác nhận...) sẽ được báo lại, các hồ sơ còn lại vẫn lưu.
    /// </summary>
    public static (int ThanhCong, List<string> Loi) LuuTrangThai(IEnumerable<HoSoItem> thayDoi, int maNhanVien)
    {
        string sql = @"
            UPDATE HoSoDangKy AS h
            SET TrangThaiHoSo = @tt,
                MaNhanVienXacNhan = COALESCE(h.MaNhanVienXacNhan, @nv),
                NgayXacNhan = CURRENT_TIMESTAMP
            WHERE h.MaHoSo = @id
              AND (h.MaNhanVienXacNhan IS NULL OR h.MaNhanVienXacNhan = @nv)
              AND " + DuocPhanCong + @"
              AND NOT " + DotDaKetThuc;

        int thanhCong = 0;
        var loi = new List<string>();
        using var conn = Db.TaoKetNoi();
        conn.Open();

        foreach (var h in thayDoi)
        {
            try
            {
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("tt", h.TrangThaiHoSo);
                cmd.Parameters.AddWithValue("nv", maNhanVien);
                cmd.Parameters.AddWithValue("id", h.MaHoSo);
                if (cmd.ExecuteNonQuery() > 0)
                    thanhCong++;
                else
                    loi.Add($"- {h.HoTen}: đợt đã kết thúc hoặc hồ sơ đã do nhân viên khác xác nhận.");
            }
            catch (PostgresException ex)
            {
                loi.Add($"- {h.HoTen}: {ex.MessageText}");
            }
        }
        return (thanhCong, loi);
    }

    /// <summary>Sửa thông tin người đăng ký. Trả về null nếu thành công, hoặc thông báo lỗi.</summary>
    public static string? SuaThongTin(HoSoItem hoSo, int maNhanVien)
    {
        string sql = @"
            UPDATE HoSoDangKy AS h
            SET HoTen = @ten, NgaySinh = @ns, SoDienThoai = @sdt, Email = @em, DiaChi = @dc
            WHERE h.MaHoSo = @id
              AND " + DuocPhanCong + @"
              AND NOT " + DotDaKetThuc;

        try
        {
            using var conn = Db.TaoKetNoi();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("ten", hoSo.HoTen);
            cmd.Parameters.Add(Sql.NgayNull("ns", hoSo.NgaySinh));
            cmd.Parameters.AddWithValue("sdt", hoSo.SoDienThoai);
            cmd.Parameters.AddWithValue("em", hoSo.Email);
            cmd.Parameters.Add(Sql.Chuoi("dc", hoSo.DiaChi));
            cmd.Parameters.AddWithValue("id", hoSo.MaHoSo);
            cmd.Parameters.AddWithValue("nv", maNhanVien);
            return cmd.ExecuteNonQuery() > 0
                ? null
                : "Không thể sửa: đợt đã kết thúc hoặc hồ sơ nằm ngoài phạm vi phụ trách của bạn.";
        }
        catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            return "Số điện thoại hoặc email này đã được dùng để đăng ký khóa học này.";
        }
        catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.RaiseException)
        {
            return ex.MessageText;
        }
    }

    /// <summary>Xóa hồ sơ (cần được phân công và đợt chưa kết thúc). Trả về true nếu đã xóa.</summary>
    public static bool Xoa(int maHoSo, int maNhanVien)
    {
        string sql = @"
            DELETE FROM HoSoDangKy AS h
            WHERE h.MaHoSo = @id
              AND " + DuocPhanCong + @"
              AND NOT " + DotDaKetThuc;

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id", maHoSo);
        cmd.Parameters.AddWithValue("nv", maNhanVien);
        return cmd.ExecuteNonQuery() > 0;
    }

    /// <summary>
    /// Các đợt nhân viên có thể thêm hồ sơ thủ công: đợt chưa kết thúc và có khóa học nhân viên đó phụ trách.
    /// </summary>
    public static List<LuaChon> LayDotChoThemHoSo(int maNhanVien)
    {
        const string sql = @"
            SELECT d.MaDot, d.TenDot
            FROM DotTuyenSinh d
            WHERE d.TrangThai NOT IN ('Đã kết thúc', 'Đã ngừng')
              AND d.NgayKetThuc >= CURRENT_DATE
              AND EXISTS (
                    SELECT 1 FROM DotKhoaHoc dk
                    JOIN PhanCongTuyenSinh pc ON pc.MaDotKhoaHoc = dk.MaDotKhoaHoc
                    WHERE dk.MaDot = d.MaDot AND pc.MaNhanVien = @nv)
            ORDER BY d.NgayBatDau DESC, d.MaDot DESC";

        var ds = new List<LuaChon>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("nv", maNhanVien);
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) ds.Add(new LuaChon(rd.GetInt32(0), rd.GetString(1)));
        return ds;
    }

    /// <summary>
    /// Nhân viên thêm hồ sơ thủ công (khi học viên không đăng ký được trên web). Hồ sơ mới có trạng thái
    /// Chờ xử lý. Trả về null nếu thành công, hoặc thông báo lỗi.
    /// </summary>
    public static string? ThemThuCong(int maNhanVien, int maDot, int maKhoaHoc, HoSoItem hoSo)
    {
        // Tìm khóa-đợt, đồng thời kiểm tra: đúng phạm vi phụ trách và đợt chưa kết thúc
        const string timSql = @"
            SELECT dk.MaDotKhoaHoc
            FROM DotKhoaHoc dk
            JOIN DotTuyenSinh d ON d.MaDot = dk.MaDot
            WHERE dk.MaDot = @dot AND dk.MaKhoaHoc = @kh
              AND d.TrangThai NOT IN ('Đã kết thúc', 'Đã ngừng')
              AND d.NgayKetThuc >= CURRENT_DATE
              AND EXISTS (SELECT 1 FROM PhanCongTuyenSinh pc
                          WHERE pc.MaDotKhoaHoc = dk.MaDotKhoaHoc AND pc.MaNhanVien = @nv)";

        const string themSql = @"
            INSERT INTO HoSoDangKy (MaDotKhoaHoc, HoTen, NgaySinh, SoDienThoai, Email, DiaChi)
            VALUES (@dk, @ten, @ns, @sdt, @em, @dc)";

        try
        {
            using var conn = Db.TaoKetNoi();
            conn.Open();

            object? maDotKhoaHoc;
            using (var tim = new NpgsqlCommand(timSql, conn))
            {
                tim.Parameters.AddWithValue("dot", maDot);
                tim.Parameters.AddWithValue("kh", maKhoaHoc);
                tim.Parameters.AddWithValue("nv", maNhanVien);
                maDotKhoaHoc = tim.ExecuteScalar();
            }
            if (maDotKhoaHoc == null)
                return "Không thể thêm: khóa học không thuộc phạm vi phụ trách của bạn hoặc đợt đã kết thúc.";

            using var them = new NpgsqlCommand(themSql, conn);
            them.Parameters.AddWithValue("dk", (int)maDotKhoaHoc);
            them.Parameters.AddWithValue("ten", hoSo.HoTen);
            them.Parameters.Add(Sql.NgayNull("ns", hoSo.NgaySinh));
            them.Parameters.AddWithValue("sdt", hoSo.SoDienThoai);
            them.Parameters.AddWithValue("em", hoSo.Email);
            them.Parameters.Add(Sql.Chuoi("dc", hoSo.DiaChi));
            them.ExecuteNonQuery();
            return null;
        }
        catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            return "Số điện thoại hoặc email này đã được dùng để đăng ký khóa học này.";
        }
    }
}
