using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Models;

/// <summary>Một khóa học trong một đợt, kèm tên tất cả nhân viên phụ trách (gộp trong một chuỗi).</summary>
public class PhanCongKhoaItem
{
    public int MaDotKhoaHoc { get; set; }
    public int MaKhoaHoc { get; set; }
    public string TenKhoaHoc { get; set; } = "";
    public string NhanVienPhuTrach { get; set; } = "";
    public int SoNhanVien { get; set; }
    public int SoHoSo { get; set; }
}

/// <summary>Một nhân viên trong danh sách chọn phân công của một khóa học.</summary>
public class NhanVienPhanCongItem
{
    public int MaNhanVien { get; set; }
    public string HoTen { get; set; } = "";
    public string TenDangNhap { get; set; } = "";
    public bool DuocPhanCong { get; set; }   // đang phụ trách khóa này
    public bool DaXacNhan { get; set; }      // đã xác nhận hồ sơ của khóa này (không được gỡ)

    public override string ToString() =>
        $"{HoTen} ({TenDangNhap})" + (DaXacNhan ? "  -  đã xác nhận hồ sơ" : "");
}