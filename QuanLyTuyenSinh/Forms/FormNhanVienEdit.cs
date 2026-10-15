using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Forms;

/// <summary>
/// Thêm mới (nv = null), sửa hoặc xem (chiXem = true) một nhân viên cùng tài khoản của họ.
/// Khi sửa có nút "Đặt lại mật khẩu".
/// </summary>
public partial class FormNhanVienEdit : Form
{
    private readonly NhanVienItem? _goc;

    public FormNhanVienEdit(NhanVienItem? nv = null, bool chiXem = false)
    {
        InitializeComponent();
        _goc = nv;

        cboGioiTinh.Items.AddRange(DanhMuc.GioiTinh);
        cboVaiTro.Items.AddRange(DanhMuc.DanhSachVaiTro);
        cboTrangThai.Items.AddRange(DanhMuc.TrangThaiTaiKhoan);

        if (_goc == null)
        {
            Text = "Thêm nhân viên";
            cboGioiTinh.SelectedIndex = 0;
            cboVaiTro.SelectedItem = VaiTro.NhanVien;
            cboTrangThai.SelectedItem = "Hoạt động";
        }
        else
        {
            Text = chiXem ? "Xem nhân viên" : "Sửa nhân viên";
            txtTenDangNhap.Text = _goc.TenDangNhap;
            txtTenDangNhap.ReadOnly = true;   // không đổi tên đăng nhập
            txtHoTen.Text = _goc.HoTen;
            if (_goc.NgaySinh.HasValue)
            {
                dtpNgaySinh.Value = _goc.NgaySinh.Value;
                dtpNgaySinh.Checked = true;
            }
            cboGioiTinh.SelectedItem = _goc.GioiTinh ?? "";
            txtSoDienThoai.Text = _goc.SoDienThoai ?? "";
            cboVaiTro.SelectedItem = _goc.VaiTro;
            cboTrangThai.SelectedItem = _goc.TrangThai;

            // Khi xem hoặc sửa: ẩn ô nhập mật khẩu. Khi sửa thì có nút "Đặt lại mật khẩu".
            lblMatKhau.Visible = txtMatKhau.Visible = false;
            lblNhapLai.Visible = txtNhapLai.Visible = false;
            btnDatLaiMatKhau.Visible = !chiXem;

            // Không cho tự đổi vai trò hoặc tự khóa tài khoản đang đăng nhập
            if (_goc.MaTaiKhoan == PhienDangNhap.HienTai?.MaTaiKhoan)
            {
                cboVaiTro.Enabled = false;
                cboTrangThai.Enabled = false;
            }
        }

        if (chiXem)
        {
            txtHoTen.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtSoDienThoai.ReadOnly = true;
            cboVaiTro.Enabled = false;
            cboTrangThai.Enabled = false;
            btnLuu.Visible = false;
            btnHuy.Text = "Đóng";
        }
    }

    private static void Canh(string noiDung)
    {
        MessageBox.Show(noiDung, "Thiếu hoặc sai thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void btnDatLaiMatKhau_Click(object? sender, EventArgs e)
    {
        if (_goc == null) return;
        using var form = new FormDatLaiMatKhau(_goc);
        form.ShowDialog(this);
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        string tenDN = txtTenDangNhap.Text.Trim();
        string hoTen = txtHoTen.Text.Trim();

        if (_goc == null)
        {
            if (tenDN.Length < 3 || tenDN.Contains(' '))
            {
                Canh("Tên đăng nhập phải từ 3 ký tự và không có khoảng trắng.");
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text.Length < 6)
            {
                Canh("Mật khẩu phải có ít nhất 6 ký tự.");
                txtMatKhau.Focus();
                return;
            }
            if (txtMatKhau.Text != txtNhapLai.Text)
            {
                Canh("Mật khẩu nhập lại không khớp.");
                txtNhapLai.Focus();
                return;
            }
        }
        if (hoTen == "")
        {
            Canh("Vui lòng nhập họ tên.");
            txtHoTen.Focus();
            return;
        }
        if (cboVaiTro.SelectedItem == null || cboTrangThai.SelectedItem == null)
        {
            Canh("Vui lòng chọn vai trò và trạng thái.");
            return;
        }

        var nv = new NhanVienItem
        {
            TenDangNhap = tenDN,
            HoTen = hoTen,
            NgaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null,
            GioiTinh = string.IsNullOrEmpty(cboGioiTinh.SelectedItem?.ToString()) ? null : cboGioiTinh.SelectedItem!.ToString(),
            SoDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text.Trim(),
            VaiTro = cboVaiTro.SelectedItem.ToString()!,
            TrangThai = cboTrangThai.SelectedItem.ToString()!
        };

        try
        {
            if (_goc == null)
            {
                NhanVienRepo.Them(nv, txtMatKhau.Text);
            }
            else
            {
                nv.MaNhanVien = _goc.MaNhanVien;
                nv.MaTaiKhoan = _goc.MaTaiKhoan;
                nv.TenDangNhap = _goc.TenDangNhap;
                NhanVienRepo.Sua(nv);
            }
            DialogResult = DialogResult.OK;
        }
        catch (InvalidOperationException ex)
        {
            Canh(ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lưu được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}