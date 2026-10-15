using System;
using System.Collections.Generic;
using System.Text;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Services;

public static class PhienDangNhap
{
    public static NguoiDung? HienTai { get; private set; }

    public static bool LaQuanTri => HienTai?.VaiTro == VaiTro.QuanTri;
    public static bool LaNhanVien => HienTai?.VaiTro == VaiTro.NhanVien;

    public static void DangNhap(NguoiDung nguoiDung) => HienTai = nguoiDung;
    public static void DangXuat() => HienTai = null;
}