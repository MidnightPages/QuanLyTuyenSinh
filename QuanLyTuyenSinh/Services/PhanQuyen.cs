using QuanLyTuyenSinh.Data;

namespace QuanLyTuyenSinh.Services;

/// <summary>Kiểm tra quyền của người dùng đang đăng nhập.</summary>
public static class PhanQuyen
{
    // Quản trị viên: thêm, sửa, xóa khóa học. Nhân viên: chỉ xem.
    public static bool CoTheSuaKhoaHoc => PhienDangNhap.LaQuanTri;

    // Chỉ quản trị viên được thêm và xóa đợt tuyển sinh.
    public static bool CoTheThemXoaDot => PhienDangNhap.LaQuanTri;

    // Quản trị viên sửa mọi đợt; nhân viên chỉ sửa đợt mà mình được phân công.
    public static bool CoTheSuaDot(int maDot)
    {
        if (PhienDangNhap.LaQuanTri) return true;
        var nguoiDung = PhienDangNhap.HienTai;
        if (nguoiDung == null || !PhienDangNhap.LaNhanVien) return false;
        return DotRepo.NhanVienDuocPhanCong(maDot, nguoiDung.MaNhanVien);
    }
}
