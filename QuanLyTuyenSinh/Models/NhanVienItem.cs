namespace QuanLyTuyenSinh.Models;

/// <summary>Thông tin một người dùng nội bộ (bảng NhanVien kèm tài khoản tương ứng).</summary>
public class NhanVienItem
{
    public int MaNhanVien { get; set; }
    public int MaTaiKhoan { get; set; }
    public string TenDangNhap { get; set; } = "";
    public string HoTen { get; set; } = "";
    public DateTime? NgaySinh { get; set; }
    public string? GioiTinh { get; set; }
    public string? SoDienThoai { get; set; }
    public string VaiTro { get; set; } = "";
    public string TrangThai { get; set; } = "Hoạt động";

    public string TenHienThi => $"{HoTen} ({TenDangNhap})";
}
