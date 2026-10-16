using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Forms;

/// <summary>
/// Xem và sửa thông tin cá nhân của người đang đăng nhập.
/// Chỉ nhân viên mới có phần đổi mật khẩu (quản trị viên không dùng chức năng này).
/// </summary>
public partial class FormTaiKhoanCaNhan : Form
{
    private NhanVienItem? _nv;
    private bool _daLuu;

    public FormTaiKhoanCaNhan()
    {
        InitializeComponent();
        cboGioiTinh.Items.AddRange(DanhMuc.GioiTinh);

        if (!PhienDangNhap.LaNhanVien)
        {
            // Quản trị viên: ẩn phần đổi mật khẩu, đưa nút Đóng lên đúng chỗ nhóm đó đang đứng
            // rồi thu gọn form vừa khít với nút Đóng. Dùng vị trí tương đối nên đúng với mọi bố cục.
            grpMatKhau.Visible = false;
            btnDong.Top = grpMatKhau.Top;
            ClientSize = new Size(ClientSize.Width, btnDong.Bottom + 20);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode) return;

        try
        {
            _nv = TaiKhoanRepo.LayThongTin(PhienDangNhap.HienTai!.MaNhanVien);
            if (_nv == null)
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }

            txtTenDangNhap.Text = _nv.TenDangNhap;
            txtVaiTro.Text = _nv.VaiTro;
            txtHoTen.Text = _nv.HoTen;
            if (_nv.NgaySinh.HasValue)
            {
                dtpNgaySinh.Value = _nv.NgaySinh.Value;
                dtpNgaySinh.Checked = true;
            }
            cboGioiTinh.SelectedItem = _nv.GioiTinh ?? "";
            txtSoDienThoai.Text = _nv.SoDienThoai ?? "";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLuuThongTin_Click(object? sender, EventArgs e)
    {
        if (_nv == null) return;

        string hoTen = txtHoTen.Text.Trim();
        if (hoTen == "")
        {
            MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return;
        }

        _nv.HoTen = hoTen;
        _nv.NgaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null;
        _nv.GioiTinh = string.IsNullOrEmpty(cboGioiTinh.SelectedItem?.ToString()) ? null : cboGioiTinh.SelectedItem!.ToString();
        _nv.SoDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text.Trim();

        try
        {
            TaiKhoanRepo.SuaThongTin(_nv);
            PhienDangNhap.HienTai!.HoTen = hoTen;   // cập nhật tên hiển thị trong phiên đăng nhập
            _daLuu = true;
            MessageBox.Show("Đã lưu thông tin cá nhân.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lưu được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDoiMatKhau_Click(object? sender, EventArgs e)
    {
        if (txtMkCu.Text == "")
        {
            MessageBox.Show("Vui lòng nhập mật khẩu hiện tại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMkCu.Focus();
            return;
        }
        if (txtMkMoi.Text.Length < 6)
        {
            MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Sai thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMkMoi.Focus();
            return;
        }
        if (txtMkMoi.Text != txtNhapLai.Text)
        {
            MessageBox.Show("Mật khẩu nhập lại không khớp.", "Sai thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNhapLai.Focus();
            return;
        }

        try
        {
            string? loi = TaiKhoanRepo.DoiMatKhau(PhienDangNhap.HienTai!.MaTaiKhoan, txtMkCu.Text, txtMkMoi.Text);
            if (loi != null)
            {
                MessageBox.Show(loi, "Không đổi được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMkCu.Focus();
                return;
            }

            txtMkCu.Clear();
            txtMkMoi.Clear();
            txtNhapLai.Clear();
            MessageBox.Show("Đã đổi mật khẩu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không đổi được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDong_Click(object? sender, EventArgs e)
    {
        DialogResult = _daLuu ? DialogResult.OK : DialogResult.Cancel;
    }
}