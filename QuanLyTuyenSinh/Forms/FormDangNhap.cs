using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Forms;

public partial class FormDangNhap : Form
{
    public FormDangNhap()
    {
        InitializeComponent();
    }

    // Đặt thành false để ẩn 3 nút demo khi dùng thật (không muốn lộ tài khoản mẫu)
    private const bool HienNutDemo = true;

    // Điền tên đăng nhập, mật khẩu rồi bấm nút Đăng nhập như người dùng tự gõ
    private void DangNhapNhanh(string tenDangNhap, string matKhau)
    {
        txtTenDangNhap.Text = tenDangNhap;
        txtMatKhau.Text = matKhau;
        btnDangNhap.PerformClick();
    }

    private void btnDangNhap_Click(object sender, EventArgs e)
    {
        lblThongBao.Text = "";
        string tenDN = txtTenDangNhap.Text.Trim();

        if (tenDN == "" || txtMatKhau.Text == "")
        {
            lblThongBao.Text = "Vui lòng nhập tên đăng nhập và mật khẩu.";
            return;
        }

        try
        {
            var nguoiDung = AuthService.DangNhap(tenDN, txtMatKhau.Text, out string loi);
            if (nguoiDung == null)
            {
                lblThongBao.Text = loi;
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                return;
            }

            PhienDangNhap.DangNhap(nguoiDung);
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            lblThongBao.Text = "Lỗi: " + ex.Message;
        }
    }

    private void btnThoat_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void btnDemoAdmin_Click(object? sender, EventArgs e) =>
        DangNhapNhanh("admin", "111111");

    private void btnDemoLan_Click(object? sender, EventArgs e) =>
        DangNhapNhanh("nv.lan", "123456");

    private void btnDemoHung_Click(object? sender, EventArgs e) =>
        DangNhapNhanh("nv.hung", "NhanVien@123");
}
