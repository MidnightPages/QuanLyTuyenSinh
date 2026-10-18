using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Forms;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Controls;

/// <summary>Trang quản lý nhân viên và tài khoản (chỉ dành cho quản trị viên).</summary>
public partial class ucNhanVien : UserControl
{
    // Chỉ tải dữ liệu sau khi control đã sẵn sàng (tránh gọi CSDL lúc đang thiết kế trong Designer)
    private bool _sanSang;

    public ucNhanVien()
    {
        InitializeComponent();
        LuoiHelper.DanhSoThuTu(dgvNhanVien, "colStt");
        LuoiHelper.CauHinhChung(dgvNhanVien);

        cboTrangThai.Items.Add("Tất cả");
        cboTrangThai.Items.AddRange(DanhMuc.TrangThaiTaiKhoan);
        cboTrangThai.SelectedIndex = 0;
    }

    private void ucNhanVien_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        _sanSang = true;
        TaiDuLieu();
    }

    private void TaiDuLieu()
    {
        if (!_sanSang) return;
        try
        {
            string? trangThai = cboTrangThai.SelectedIndex > 0 ? cboTrangThai.SelectedItem!.ToString() : null;
            dgvNhanVien.DataSource = NhanVienRepo.LayDanhSach(txtTimKiem.Text.Trim(), trangThai);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách nhân viên: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static bool LaChinhMinh(NhanVienItem nv) =>
        nv.MaTaiKhoan == PhienDangNhap.HienTai?.MaTaiKhoan;

    private void txtTimKiem_TextChanged(object? sender, EventArgs e) => TaiDuLieu();

    private void cboTrangThai_SelectedIndexChanged(object? sender, EventArgs e) => TaiDuLieu();

    private void btnThem_Click(object? sender, EventArgs e)
    {
        using var form = new FormNhanVienEdit();
        if (form.ShowDialog(FindForm()) == DialogResult.OK) TaiDuLieu();
    }

    // Bấm nút Sửa / Xóa ngay trên dòng
    private void dgvNhanVien_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        if (dgvNhanVien.Rows[e.RowIndex].DataBoundItem is not NhanVienItem nv) return;

        switch (dgvNhanVien.Columns[e.ColumnIndex].Name)
        {
            case "colSua": Sua(nv); break;
            case "colXoa": Xoa(nv); break;
        }
    }

    private void Sua(NhanVienItem nv)
    {
        using var form = new FormNhanVienEdit(nv);
        if (form.ShowDialog(FindForm()) == DialogResult.OK) TaiDuLieu();
    }

    private void Xoa(NhanVienItem nv)
    {
        if (LaChinhMinh(nv))
        {
            MessageBox.Show("Bạn không thể xóa tài khoản đang đăng nhập.", "Không thể xóa",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var traLoi = MessageBox.Show($"Bạn có chắc muốn xóa tài khoản của \"{nv.HoTen}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (traLoi != DialogResult.Yes) return;

        try
        {
            bool daXoaHan = NhanVienRepo.XoaHoacKhoa(nv);
            MessageBox.Show(
                daXoaHan
                    ? "Đã xóa tài khoản."
                    : "Nhân viên này đã có phân công hoặc đã xác nhận hồ sơ nên không xóa hẳn mà tài khoản được chuyển sang trạng thái Đã khóa.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDuLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không xóa được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Nhấn đúp vào dòng: chỉ xem
    private void dgvNhanVien_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        string cot = dgvNhanVien.Columns[e.ColumnIndex].Name;
        if (cot == "colSua" || cot == "colXoa") return;   // đã xử lý ở nút
        if (dgvNhanVien.Rows[e.RowIndex].DataBoundItem is not NhanVienItem nv) return;

        using var form = new FormNhanVienEdit(nv, chiXem: true);
        form.ShowDialog(FindForm());
    }
}