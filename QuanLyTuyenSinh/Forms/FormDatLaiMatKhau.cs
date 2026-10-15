using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Forms;

/// <summary>Quản trị viên đặt lại mật khẩu cho một tài khoản.</summary>
public partial class FormDatLaiMatKhau : Form
{
    private readonly NhanVienItem _nv;

    public FormDatLaiMatKhau(NhanVienItem nv)
    {
        InitializeComponent();
        _nv = nv;
        lblNguoiDung.Text = $"Đặt lại mật khẩu cho: {nv.HoTen} ({nv.TenDangNhap})";
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        if (txtMatKhauMoi.Text.Length < 6)
        {
            MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Sai thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMatKhauMoi.Focus();
            return;
        }
        if (txtMatKhauMoi.Text != txtNhapLai.Text)
        {
            MessageBox.Show("Mật khẩu nhập lại không khớp.", "Sai thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNhapLai.Focus();
            return;
        }

        try
        {
            NhanVienRepo.DatLaiMatKhau(_nv.MaTaiKhoan, txtMatKhauMoi.Text);
            MessageBox.Show("Đã đặt lại mật khẩu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không đặt lại được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
