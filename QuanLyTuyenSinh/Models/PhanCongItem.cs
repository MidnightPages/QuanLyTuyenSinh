namespace QuanLyTuyenSinh.Models;

public class PhanCongItem
{
    public int MaPhanCong { get; set; }
    public int MaNhanVien { get; set; }
    public string TenNhanVien { get; set; } = "";
    public int MaDot { get; set; }
    public string TenDot { get; set; } = "";
    public string TrangThaiDot { get; set; } = "";
    public int MaKhoaHoc { get; set; }
    public string TenKhoaHoc { get; set; } = "";
    public int SoHoSo { get; set; }
}
