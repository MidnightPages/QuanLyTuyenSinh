namespace QuanLyTuyenSinh.Models;

public class DotTuyenSinh
{
    public int MaDot { get; set; }
    public string TenDot { get; set; } = "";
    public DateTime NgayBatDau { get; set; } = DateTime.Today;
    public DateTime NgayKetThuc { get; set; } = DateTime.Today.AddMonths(2);
    public string TrangThai { get; set; } = "Sắp diễn ra";
    public string? MoTa { get; set; }

    // Chỉ để hiển thị trên danh sách (không lưu vào bảng)
    public int SoKhoaHoc { get; set; }
    public int SoHoSo { get; set; }
}
