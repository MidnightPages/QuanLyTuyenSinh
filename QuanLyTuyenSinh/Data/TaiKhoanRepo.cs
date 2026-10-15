using System;
using System.Collections.Generic;
using System.Text;

using Npgsql;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Data;

/// <summary>Các thao tác của người dùng với tài khoản của chính mình.</summary>
public static class TaiKhoanRepo
{
    public static NhanVienItem? LayThongTin(int maNhanVien)
    {
        const string sql = @"
            SELECT n.MaNhanVien, n.MaTaiKhoan, t.TenDangNhap, n.HoTen, n.NgaySinh,
                   n.GioiTinh, n.SoDienThoai, t.VaiTro, t.TrangThai
            FROM NhanVien n
            JOIN TaiKhoan t ON t.MaTaiKhoan = n.MaTaiKhoan
            WHERE n.MaNhanVien = @id";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id", maNhanVien);
        using var rd = cmd.ExecuteReader();
        if (!rd.Read()) return null;
        return new NhanVienItem
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
    }

    /// <summary>Chỉ sửa thông tin cá nhân (không đổi được vai trò, trạng thái, tên đăng nhập).</summary>
    public static void SuaThongTin(NhanVienItem nv)
    {
        const string sql = @"
            UPDATE NhanVien
            SET HoTen = @ten, NgaySinh = @ns, GioiTinh = @gt, SoDienThoai = @sdt
            WHERE MaNhanVien = @id";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("ten", nv.HoTen);
        cmd.Parameters.Add(Sql.NgayNull("ns", nv.NgaySinh));
        cmd.Parameters.Add(Sql.Chuoi("gt", nv.GioiTinh));
        cmd.Parameters.Add(Sql.Chuoi("sdt", nv.SoDienThoai));
        cmd.Parameters.AddWithValue("id", nv.MaNhanVien);
        cmd.ExecuteNonQuery();
    }

    /// <summary>Đổi mật khẩu. Trả về null nếu thành công, hoặc thông báo lỗi.</summary>
    public static string? DoiMatKhau(int maTaiKhoan, string matKhauCu, string matKhauMoi)
    {
        using var conn = Db.TaoKetNoi();
        conn.Open();

        string? hashCu;
        using (var cmd = new NpgsqlCommand("SELECT MatKhauHash FROM TaiKhoan WHERE MaTaiKhoan = @id", conn))
        {
            cmd.Parameters.AddWithValue("id", maTaiKhoan);
            hashCu = cmd.ExecuteScalar() as string;
        }

        if (hashCu == null) return "Không tìm thấy tài khoản.";
        if (!BCrypt.Net.BCrypt.Verify(matKhauCu, hashCu)) return "Mật khẩu hiện tại không đúng.";

        using var up = new NpgsqlCommand("UPDATE TaiKhoan SET MatKhauHash = @h WHERE MaTaiKhoan = @id", conn);
        up.Parameters.AddWithValue("h", BCrypt.Net.BCrypt.HashPassword(matKhauMoi));
        up.Parameters.AddWithValue("id", maTaiKhoan);
        up.ExecuteNonQuery();
        return null;
    }
}