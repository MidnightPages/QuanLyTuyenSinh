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

namespace QuanLyTuyenSinh.Controls;

/// <summary>
/// Trang "Phân công của tôi" của nhân viên: các khóa học mình phụ trách ở mọi đợt,
/// lọc theo đợt và khóa học. Chỉ xem.
/// </summary>
public partial class ucPhanCongCuaToi : UserControl
{
    private bool _sanSang;   // chỉ tải dữ liệu sau khi control đã sẵn sàng (tránh gọi CSDL lúc thiết kế)
    private bool _dangNap;   // đang nạp lại ComboBox, bỏ qua sự kiện đổi lựa chọn
    private List<PhanCongKhoaItem> _ds = new();
    private readonly int? _maNhanVien = PhienDangNhap.HienTai?.MaNhanVien;

    public ucPhanCongCuaToi()
    {
        InitializeComponent();
        LuoiHelper.DanhSoThuTu(dgvPhanCong, "colStt");
    }

    private void ucPhanCongCuaToi_Load(object? sender, EventArgs e)
    {
        if (DesignMode || _maNhanVien == null) return;

        try
        {
            var dots = new List<LuaChon> { new(null, "Tất cả") };
            dots.AddRange(HoSoRepo.LayDotTrongPhamVi(_maNhanVien));
            GanDanhSach(cboDot, dots);
            NapKhoaHoc();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách lọc: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        _sanSang = true;
        TaiDuLieu();
    }

    private static void GanDanhSach(ComboBox cbo, List<LuaChon> ds)
    {
        cbo.DisplayMember = nameof(LuaChon.Ten);
        cbo.ValueMember = nameof(LuaChon.Ma);
        cbo.DataSource = ds;
        cbo.SelectedIndex = 0;
    }

    // Danh sách khóa học trong ô lọc phụ thuộc vào đợt đang chọn
    private void NapKhoaHoc()
    {
        int? maDot = cboDot.SelectedValue as int?;
        var ds = new List<LuaChon> { new(null, "Tất cả") };
        ds.AddRange(HoSoRepo.LayKhoaHocTrongPhamVi(maDot, _maNhanVien));

        _dangNap = true;
        try { GanDanhSach(cboKhoaHoc, ds); }
        finally { _dangNap = false; }
    }

    private void TaiDuLieu()
    {
        if (!_sanSang || _maNhanVien == null) return;
        try
        {
            int? maDot = cboDot.SelectedValue as int?;
            int? maKhoaHoc = cboKhoaHoc.SelectedValue as int?;
            _ds = PhanCongRepo.LayPhanCongCuaToi(_maNhanVien.Value, maDot, maKhoaHoc);
            dgvPhanCong.DataSource = _ds;
            lblTomTat.Text = $"  {_ds.Count} khóa học bạn đang phụ trách";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách phân công: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cboDot_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangNap || !_sanSang) return;
        try { NapKhoaHoc(); } catch { /* lỗi sẽ hiện ở TaiDuLieu */ }
        TaiDuLieu();
    }

    private void cboKhoaHoc_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangNap || !_sanSang) return;
        TaiDuLieu();
    }
}