namespace QuanLyTuyenSinh.Models;

/// <summary>Một khóa học được mở trong một đợt (dòng của bảng DotKhoaHoc kèm thông tin khóa học).</summary>
public class DotKhoaHocItem
{
    public int MaDotKhoaHoc { get; set; }
    public int MaKhoaHoc { get; set; }
    public string TenKhoaHoc { get; set; } = "";
    public decimal HocPhi { get; set; }
    public string? ThoiLuong { get; set; }
    public string TrangThaiKhoaHoc { get; set; } = "";
    public int SoHoSo { get; set; }
    public int SoNhanVien { get; set; }
}
