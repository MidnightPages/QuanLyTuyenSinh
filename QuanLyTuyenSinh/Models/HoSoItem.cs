using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Models;

public class HoSoItem
{
    public int MaHoSo { get; set; }
    public int MaDotKhoaHoc { get; set; }
    public int MaDot { get; set; }
    public string TenDot { get; set; } = "";
    public int MaKhoaHoc { get; set; }
    public string TenKhoaHoc { get; set; } = "";
    public string HoTen { get; set; } = "";
    public DateTime? NgaySinh { get; set; }
    public string SoDienThoai { get; set; } = "";
    public string Email { get; set; } = "";
    public string? DiaChi { get; set; }
    public DateTime NgayDangKy { get; set; }
    public string TrangThaiHoSo { get; set; } = "Chờ xử lý";
    public int? MaNhanVienXacNhan { get; set; }
    public string? TenNhanVienXacNhan { get; set; }
    public DateTime? NgayXacNhan { get; set; }
    public bool DaKetThuc { get; set; }   // đợt đã kết thúc

    // Chỉ dùng trên giao diện
    public string TrangThaiGoc { get; set; } = "Chờ xử lý";
    public bool Chon { get; set; }
    public bool DuocXuLy { get; set; }
    public string GhiChu { get; set; } = "";
    public bool DaThayDoi => TrangThaiHoSo != TrangThaiGoc;
}