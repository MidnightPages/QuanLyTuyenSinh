using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Forms;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Controls;

public partial class ucKhoaHoc : UserControl
{
    // Chỉ tải dữ liệu sau khi control đã sẵn sàng (tránh gọi CSDL lúc đang thiết kế trong Designer)
    private bool _sanSang;

    public ucKhoaHoc()
    {
        InitializeComponent();
        LuoiHelper.DanhSoThuTu(dgvKhoaHoc, "colStt");
        LuoiHelper.CauHinhChung(dgvKhoaHoc);

        cboTrangThai.Items.Add("Tất cả");
        cboTrangThai.Items.AddRange(DanhMuc.TrangThaiKhoaHoc);
        cboTrangThai.SelectedIndex = 0;
    }

    private void ucKhoaHoc_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;

        // Quản trị viên: thêm, sửa, xóa. Nhân viên: chỉ xem (nhấn đúp vào dòng).
        bool duocSua = PhanQuyen.CoTheSuaKhoaHoc;
        btnThem.Visible = duocSua;
        foreach (string ten in new[] { "colSua", "colXoa" })
        {
            var cot = dgvKhoaHoc.Columns[ten];
            if (cot != null) cot.Visible = duocSua;
        }

        _sanSang = true;
        TaiDuLieu();
    }

    private void TaiDuLieu()
    {
        if (!_sanSang) return;
        try
        {
            string? trangThai = cboTrangThai.SelectedIndex > 0 ? cboTrangThai.SelectedItem!.ToString() : null;
            dgvKhoaHoc.DataSource = KhoaHocRepo.LayDanhSach(txtTimKiem.Text.Trim(), trangThai);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách khóa học: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void txtTimKiem_TextChanged(object? sender, EventArgs e) => TaiDuLieu();

    private void cboTrangThai_SelectedIndexChanged(object? sender, EventArgs e) => TaiDuLieu();

    private void btnThem_Click(object? sender, EventArgs e)
    {
        using var form = new FormKhoaHocEdit();
        if (form.ShowDialog(FindForm()) == DialogResult.OK) TaiDuLieu();
    }

    // Bấm nút Sửa / Xóa ngay trên dòng
    private void dgvKhoaHoc_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0 || !PhanQuyen.CoTheSuaKhoaHoc) return;
        if (dgvKhoaHoc.Rows[e.RowIndex].DataBoundItem is not KhoaHoc khoaHoc) return;

        switch (dgvKhoaHoc.Columns[e.ColumnIndex].Name)
        {
            case "colSua": Sua(khoaHoc); break;
            case "colXoa": Xoa(khoaHoc); break;
        }
    }

    private void Sua(KhoaHoc khoaHoc)
    {
        using var form = new FormKhoaHocEdit(khoaHoc);
        if (form.ShowDialog(FindForm()) == DialogResult.OK) TaiDuLieu();
    }

    private void Xoa(KhoaHoc khoaHoc)
    {
        try
        {
            var (soDot, soHoSo, soPhanCong) = KhoaHocRepo.DemDuLieuLienQuan(khoaHoc.MaKhoaHoc);

            string canhBao =
                $"Bạn có chắc muốn xóa khóa học \"{khoaHoc.TenKhoaHoc}\" không?\n\n" +
                "Vì việc xóa sẽ xóa vĩnh viễn toàn bộ dữ liệu liên quan đến khóa học này:\n" +
                $"   •  {soHoSo} hồ sơ đăng ký\n" +
                $"   •  {soPhanCong} lượt phân công nhân viên\n" +
                $"   •  khóa học bị gỡ khỏi {soDot} đợt tuyển sinh\n\n" +
                "Dữ liệu đã xóa KHÔNG thể khôi phục.";

            var traLoi = MessageBox.Show(canhBao, "Cảnh báo xóa khóa học",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (traLoi != DialogResult.Yes) return;

            KhoaHocRepo.XoaVinhVien(khoaHoc.MaKhoaHoc);
            MessageBox.Show($"Đã xóa khóa học \"{khoaHoc.TenKhoaHoc}\" và toàn bộ dữ liệu liên quan.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDuLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không xóa được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Nhấn đúp vào dòng: chỉ xem
    private void dgvKhoaHoc_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        string cot = dgvKhoaHoc.Columns[e.ColumnIndex].Name;
        if (cot == "colSua" || cot == "colXoa") return;   // đã xử lý ở nút
        if (dgvKhoaHoc.Rows[e.RowIndex].DataBoundItem is not KhoaHoc khoaHoc) return;

        using var form = new FormKhoaHocEdit(khoaHoc, chiXem: true);
        form.ShowDialog(FindForm());
    }
}