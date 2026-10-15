using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Forms;

/// <summary>Thêm mới (khoaHoc = null) hoặc sửa một khóa học.</summary>
public partial class FormKhoaHocEdit : Form
{
    private readonly KhoaHoc? _goc;

    public FormKhoaHocEdit(KhoaHoc? khoaHoc = null, bool chiXem = false)
    {
        InitializeComponent();
        _goc = khoaHoc;

        cboTrangThai.Items.AddRange(DanhMuc.TrangThaiKhoaHoc);

        if (_goc == null)
        {
            Text = "Thêm khóa học";
            cboTrangThai.SelectedIndex = 0;
        }
        else
        {
            Text = chiXem ? "Xem khóa học" : "Sửa khóa học";
            txtTenKhoaHoc.Text = _goc.TenKhoaHoc;
            nudHocPhi.Value = _goc.HocPhi;
            txtThoiLuong.Text = _goc.ThoiLuong ?? "";
            cboTrangThai.SelectedItem = _goc.TrangThai;
        }

        if (chiXem)
        {
            txtTenKhoaHoc.ReadOnly = true;
            txtThoiLuong.ReadOnly = true;
            nudHocPhi.Enabled = false;
            cboTrangThai.Enabled = false;
            btnLuu.Visible = false;
            btnHuy.Text = "Đóng";
        }
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        string ten = txtTenKhoaHoc.Text.Trim();
        if (ten == "")
        {
            MessageBox.Show("Vui lòng nhập tên khóa học.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenKhoaHoc.Focus();
            return;
        }
        if (cboTrangThai.SelectedItem == null)
        {
            MessageBox.Show("Vui lòng chọn trạng thái.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var khoaHoc = new KhoaHoc
        {
            TenKhoaHoc = ten,
            HocPhi = nudHocPhi.Value,
            ThoiLuong = string.IsNullOrWhiteSpace(txtThoiLuong.Text) ? null : txtThoiLuong.Text.Trim(),
            TrangThai = cboTrangThai.SelectedItem.ToString()!
        };

        try
        {
            if (_goc == null)
            {
                KhoaHocRepo.Them(khoaHoc);
            }
            else
            {
                khoaHoc.MaKhoaHoc = _goc.MaKhoaHoc;
                KhoaHocRepo.Sua(khoaHoc);
            }
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lưu được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
