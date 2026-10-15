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
}
