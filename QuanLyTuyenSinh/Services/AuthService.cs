using System;
using System.Collections.Generic;
using System.Text;

using Npgsql;
using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Services;

public static class AuthService
{
    public static NguoiDung? DangNhap(string tenDangNhap, string matKhau, out string loi)
    {
        loi = "";
        const string sql = @"
            SELECT t.MaTaiKhoan, t.TenDangNhap, t.MatKhauHash, t.VaiTro, t.TrangThai,
                   n.MaNhanVien, n.HoTen
            FROM TaiKhoan t
            JOIN NhanVien n ON n.MaTaiKhoan = t.MaTaiKhoan
            WHERE t.TenDangNhap = @u";

        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("u", tenDangNhap);
        using var rd = cmd.ExecuteReader();

        if (!rd.Read())
        {
            loi = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return null;
        }

        string hash = rd.GetString(2);
        if (!BCrypt.Net.BCrypt.Verify(matKhau, hash))
        {
            loi = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return null;
        }

        if (rd.GetString(4) == "Đã khóa")
        {
            loi = "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên.";
            return null;
        }

        return new NguoiDung
        {
            MaTaiKhoan = rd.GetInt32(0),
            TenDangNhap = rd.GetString(1),
            VaiTro = rd.GetString(3),
            MaNhanVien = rd.GetInt32(5),
            HoTen = rd.GetString(6)
        };
    }
}