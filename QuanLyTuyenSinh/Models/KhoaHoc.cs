namespace QuanLyTuyenSinh.Models;

public class KhoaHoc
{
    public int MaKhoaHoc { get; set; }
    public string TenKhoaHoc { get; set; } = "";
    public decimal HocPhi { get; set; }
    public string? ThoiLuong { get; set; }
    public string TrangThai { get; set; } = "Đang mở";
}
