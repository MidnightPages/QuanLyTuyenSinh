using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Forms;

/// <summary>Xem hoặc sửa thông tin người đăng ký của một hồ sơ (trạng thái chỉ đổi ở danh sách).</summary>
public partial class FormHoSoChiTiet : Form
{
    private readonly HoSoItem _hoSo;

    public bool CoThayDoi { get; private set; }

    public FormHoSoChiTiet(HoSoItem hoSo, bool chiXem)
    {
        InitializeComponent();
        _hoSo = hoSo;
        Text = chiXem ? "Chi tiết hồ sơ" : "Sửa hồ sơ";

        txtDot.Text = hoSo.TenDot;
        txtKhoaHoc.Text = hoSo.TenKhoaHoc;
        txtNgayDangKy.Text = hoSo.NgayDangKy.ToString("dd/MM/yyyy HH:mm");
        txtHoTen.Text = hoSo.HoTen;
        if (hoSo.NgaySinh.HasValue)
        {
            dtpNgaySinh.Value = hoSo.NgaySinh.Value;
            dtpNgaySinh.Checked = true;
        }
        txtSoDienThoai.Text = hoSo.SoDienThoai;
        txtEmail.Text = hoSo.Email;
        txtDiaChi.Text = hoSo.DiaChi ?? "";
        txtTrangThai.Text = hoSo.TrangThaiHoSo;
        txtXacNhan.Text = hoSo.MaNhanVienXacNhan == null
            ? "(chưa có)"
            : $"{hoSo.TenNhanVienXacNhan} - {hoSo.NgayXacNhan:dd/MM/yyyy HH:mm}";

        if (chiXem)
        {
            txtHoTen.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            btnLuu.Visible = false;
        }
    }

    private static void Canh(string noiDung)
    {
        MessageBox.Show(noiDung, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        if (txtHoTen.Text.Trim() == "") { Canh("Vui lòng nhập họ tên."); txtHoTen.Focus(); return; }
        if (txtSoDienThoai.Text.Trim() == "") { Canh("Vui lòng nhập số điện thoại."); txtSoDienThoai.Focus(); return; }
        if (txtEmail.Text.Trim() == "") { Canh("Vui lòng nhập email."); txtEmail.Focus(); return; }

        var capNhat = new HoSoItem
        {
            MaHoSo = _hoSo.MaHoSo,
            HoTen = txtHoTen.Text.Trim(),
            NgaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null,
            SoDienThoai = txtSoDienThoai.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim()
        };

        try
        {
            string? loi = HoSoRepo.SuaThongTin(capNhat, PhienDangNhap.HienTai!.MaNhanVien);
            if (loi != null)
            {
                MessageBox.Show(loi, "Không lưu được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CoThayDoi = true;
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lưu được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void txtEmail_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtXacNhan_TextChanged(object sender, EventArgs e)
    {

    }
}
