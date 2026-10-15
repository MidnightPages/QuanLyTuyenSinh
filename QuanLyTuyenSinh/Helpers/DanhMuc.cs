namespace QuanLyTuyenSinh.Helpers;

/// <summary>Các danh sách giá trị cố định dùng chung (khớp với ràng buộc CHECK trong CSDL).</summary>
public static class DanhMuc
{
    public static readonly string[] TrangThaiDot =
        { "Sắp diễn ra", "Đang tuyển sinh", "Đã kết thúc", "Đã ngừng" };

    public static readonly string[] TrangThaiKhoaHoc =
        { "Đang mở", "Đã ngừng" };

    public static readonly string[] TrangThaiTaiKhoan =
        { "Hoạt động", "Đã khóa" };

    public static readonly string[] DanhSachVaiTro =
        { VaiTro.QuanTri, VaiTro.NhanVien };

    public static readonly string[] GioiTinh =
        { "", "Nam", "Nữ", "Khác" };

    public static readonly string[] TrangThaiHoSo =
    { "Chờ xử lý", "Đã duyệt", "Đã hủy" };
}
