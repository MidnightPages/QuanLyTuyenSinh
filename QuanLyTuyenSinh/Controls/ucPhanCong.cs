using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Forms;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Controls;

/// <summary>
/// Quản trị viên: chọn đợt, mỗi khóa học một dòng, sửa (tích hộp kiểm chọn nhân viên) hoặc xóa hết nhân viên phụ trách.
/// Nhân viên: chỉ xem các khóa mình phụ trách ("Phân công của tôi").
/// </summary>
public partial class ucPhanCong : UserControl
{
    private bool _sanSang;   // chỉ tải dữ liệu sau khi control đã sẵn sàng (tránh gọi CSDL lúc thiết kế)
    private List<PhanCongKhoaItem> _ds = new();
    private readonly bool _laQuanTri = PhienDangNhap.LaQuanTri;
    private readonly int? _maNhanVien = PhienDangNhap.LaNhanVien ? PhienDangNhap.HienTai?.MaNhanVien : null;

    public ucPhanCong()
    {
        InitializeComponent();
        LuoiHelper.DanhSoThuTu(dgvPhanCong, "colStt");
    }

    private void ucPhanCong_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;

        // Nhân viên chỉ xem: ẩn các cột nút
        if (!_laQuanTri)
        {
            foreach (string ten in new[] { "colSua", "colXoa" })
            {
                var cot = dgvPhanCong.Columns[ten];
                if (cot != null) cot.Visible = false;
            }
        }

        try
        {
            List<LuaChon> dots;
            int viTriMacDinh = 0;
            if (_laQuanTri)
            {
                var tatCa = DotRepo.LayDanhSach("", null);
                dots = tatCa.Select(d => new LuaChon(d.MaDot, d.TenDot)).ToList();
                // Mặc định chọn đợt đang tuyển sinh (nếu có)
                int viTri = tatCa.FindIndex(d => d.TrangThai == "Đang tuyển sinh");
                if (viTri >= 0) viTriMacDinh = viTri;
            }
            else
            {
                dots = HoSoRepo.LayDotTrongPhamVi(_maNhanVien);
            }

            cboDot.DisplayMember = nameof(LuaChon.Ten);
            cboDot.ValueMember = nameof(LuaChon.Ma);
            cboDot.DataSource = dots;
            if (dots.Count > 0) cboDot.SelectedIndex = viTriMacDinh;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách đợt: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        _sanSang = true;
        TaiDuLieu();
    }

    private void TaiDuLieu()
    {
        if (!_sanSang) return;

        if (cboDot.SelectedValue is not int maDot)
        {
            dgvPhanCong.DataSource = null;
            lblGhiChu.Text = "Chưa có đợt tuyển sinh nào.";
            return;
        }

        try
        {
            _ds = PhanCongRepo.LayTheoDot(maDot, _maNhanVien);
            dgvPhanCong.DataSource = _ds;
            lblGhiChu.Text = _ds.Count == 0
                ? "Đợt này chưa có khóa học. Hãy thêm khóa học vào đợt ở mục \"Đợt tuyển sinh\"."
                : $"{_ds.Count} khóa học";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách phân công: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cboDot_SelectedIndexChanged(object? sender, EventArgs e) => TaiDuLieu();

    // Bấm nút Sửa / Xóa hết ngay trên dòng của khóa học
    private void dgvPhanCong_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (!_laQuanTri || e.RowIndex < 0 || e.ColumnIndex < 0) return;
        if (dgvPhanCong.Rows[e.RowIndex].DataBoundItem is not PhanCongKhoaItem khoa) return;

        switch (dgvPhanCong.Columns[e.ColumnIndex].Name)
        {
            case "colSua": Sua(khoa); break;
            case "colXoa": XoaHet(khoa); break;
        }
    }

    // Hộp thoại có đủ nhân viên kèm hộp kiểm: tích để thêm, bỏ tích để gỡ
    private void Sua(PhanCongKhoaItem khoa)
    {
        using var form = new FormChonNhanVien(khoa, cboDot.Text, chiThem: false);
        if (form.ShowDialog(FindForm()) == DialogResult.OK) TaiDuLieu();
    }

    private void XoaHet(PhanCongKhoaItem khoa)
    {
        if (khoa.SoNhanVien == 0)
        {
            MessageBox.Show("Khóa học này chưa có nhân viên phụ trách.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var traLoi = MessageBox.Show(
            $"Gỡ toàn bộ nhân viên phụ trách khóa \"{khoa.TenKhoaHoc}\"?",
            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (traLoi != DialogResult.Yes) return;

        try
        {
            string? loi = PhanCongRepo.LuuPhanCong(khoa.MaDotKhoaHoc, Array.Empty<int>());
            if (loi != null)
            {
                MessageBox.Show(loi, "Không thể gỡ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TaiDuLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không gỡ được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}