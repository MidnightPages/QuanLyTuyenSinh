using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Forms;

/// <summary>
/// Chọn nhân viên phụ trách một khóa học trong một đợt.
/// chiThem = true: chỉ liệt kê nhân viên chưa phụ trách, tích để thêm.
/// chiThem = false: liệt kê tất cả, người đang phụ trách được tích sẵn, bỏ tích để gỡ.
/// </summary>
public partial class FormChonNhanVien : Form
{
    private readonly PhanCongKhoaItem _khoa;
    private readonly bool _chiThem;
    private List<NhanVienPhanCongItem> _tatCa = new();
    private bool _dangNap;   // đang nạp danh sách, bỏ qua sự kiện ItemCheck

    public FormChonNhanVien(PhanCongKhoaItem khoa, string tenDot, bool chiThem)
    {
        InitializeComponent();
        _khoa = khoa;
        _chiThem = chiThem;

        Text = chiThem ? "Thêm nhân viên phụ trách" : "Sửa nhân viên phụ trách";
        lblThongTin.Text = $"Khóa học: {khoa.TenKhoaHoc}\nĐợt: {tenDot}";
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode) return;

        try
        {
            _tatCa = PhanCongRepo.LayNhanVienChoKhoa(_khoa.MaDotKhoaHoc);
            var hienThi = _chiThem ? _tatCa.Where(x => !x.DuocPhanCong).ToList() : _tatCa;

            _dangNap = true;
            foreach (var nv in hienThi)
                clbNhanVien.Items.Add(nv, !_chiThem && nv.DuocPhanCong);
            _dangNap = false;

            if (hienThi.Count == 0)
            {
                lblGhiChu.Text = _chiThem
                    ? "Tất cả nhân viên đang hoạt động đã phụ trách khóa này."
                    : "Chưa có nhân viên nào để chọn.";
            }
            else if (!_chiThem)
            {
                lblGhiChu.Text = "Tích để thêm, bỏ tích để gỡ. Người đã xác nhận hồ sơ không gỡ được.";
            }
            else
            {
                lblGhiChu.Text = "Tích chọn một hoặc nhiều nhân viên rồi bấm Lưu.";
            }
        }
        catch (Exception ex)
        {
            _dangNap = false;
            MessageBox.Show("Không tải được danh sách nhân viên: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Không cho bỏ tích người đã xác nhận hồ sơ của khóa này
    private void clbNhanVien_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        if (_dangNap) return;
        if (e.NewValue == CheckState.Unchecked &&
            clbNhanVien.Items[e.Index] is NhanVienPhanCongItem nv && nv.DaXacNhan)
        {
            e.NewValue = CheckState.Checked;
            MessageBox.Show($"{nv.HoTen} đã xác nhận hồ sơ của khóa học này nên không thể gỡ phân công.",
                "Không thể gỡ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        var duocTich = clbNhanVien.CheckedItems.Cast<NhanVienPhanCongItem>()
            .Select(x => x.MaNhanVien).ToHashSet();

        HashSet<int> danhSachMoi;
        if (_chiThem)
        {
            if (duocTich.Count == 0)
            {
                MessageBox.Show("Hãy tích chọn ít nhất một nhân viên.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Giữ nguyên những người đang phụ trách và thêm những người vừa tích
            danhSachMoi = _tatCa.Where(x => x.DuocPhanCong).Select(x => x.MaNhanVien).ToHashSet();
            danhSachMoi.UnionWith(duocTich);
        }
        else
        {
            danhSachMoi = duocTich;
        }

        try
        {
            string? loi = PhanCongRepo.LuuPhanCong(_khoa.MaDotKhoaHoc, danhSachMoi);
            if (loi != null)
            {
                MessageBox.Show(loi, "Không lưu được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lưu được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}