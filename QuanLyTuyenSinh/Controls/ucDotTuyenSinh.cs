using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Forms;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;
using System.Diagnostics;

namespace QuanLyTuyenSinh.Controls;

public partial class ucDotTuyenSinh : UserControl
{
    // Chỉ tải dữ liệu sau khi control đã sẵn sàng (tránh gọi CSDL lúc đang thiết kế trong Designer)
    private bool _sanSang;

    public ucDotTuyenSinh()
    {
        InitializeComponent();
        LuoiHelper.DanhSoThuTu(dgvDot, "colStt");
        LuoiHelper.CauHinhChung(dgvDot);

        cboTrangThai.Items.Add("Tất cả");
        cboTrangThai.Items.AddRange(DanhMuc.TrangThaiDot);
        cboTrangThai.SelectedIndex = 0;
    }

    private void ucDotTuyenSinh_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;

        // Chỉ quản trị viên được thêm và xóa đợt. Nhân viên chỉ sửa đợt mình được phân công.
        bool duocThemXoa = PhanQuyen.CoTheThemXoaDot;
        btnThem.Visible = duocThemXoa;
        var cotXoa = dgvDot.Columns["colXoa"];
        if (cotXoa != null) cotXoa.Visible = duocThemXoa;

        _sanSang = true;
        TaiDuLieu();
    }

    private void TaiDuLieu()
    {
        if (!_sanSang) return;
        try
        {
            string? trangThai = cboTrangThai.SelectedIndex > 0 ? cboTrangThai.SelectedItem!.ToString() : null;
            dgvDot.DataSource = DotRepo.LayDanhSach(txtTimKiem.Text.Trim(), trangThai);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách đợt tuyển sinh: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void txtTimKiem_TextChanged(object? sender, EventArgs e) => TaiDuLieu();

    private void cboTrangThai_SelectedIndexChanged(object? sender, EventArgs e) => TaiDuLieu();

    private void btnThem_Click(object? sender, EventArgs e)
    {
        using var form = new FormDotEdit();
        form.ShowDialog(FindForm());
        if (form.CoThayDoi) TaiDuLieu();
    }

    // Link trang đăng ký hồ sơ trực tuyến (tạm thời). Khi website có link thật thì chỉ cần sửa dòng này.
    private const string LinkDangKy = "http://localhost:3000";

    private void btnTaoLink_Click(object? sender, EventArgs e)
    {
        // Sao chép link vào bộ nhớ tạm để dán gửi cho học viên
        bool daSaoChep = true;
        try { Clipboard.SetText(LinkDangKy); }
        catch { daSaoChep = false; }   // bộ nhớ tạm đang bị chương trình khác giữ

        string noiDung = "Link đăng ký hồ sơ trực tuyến:\n\n" + LinkDangKy + "\n\n"
            + (daSaoChep ? "Link đã được sao chép, bạn chỉ cần dán để gửi cho học viên.\n"
                         : "Chưa sao chép được tự động, hãy chép link ở trên.\n");

        // Website chỉ nhận đăng ký ở đợt có trạng thái "Đang tuyển sinh"
        if (dgvDot.CurrentRow?.DataBoundItem is DotTuyenSinh dot)
        {
            noiDung += $"\nĐợt đang chọn: {dot.TenDot} ({dot.TrangThai}).";
            if (dot.TrangThai != "Đang tuyển sinh")
                noiDung += "\nLưu ý: đợt này chưa ở trạng thái Đang tuyển sinh nên website chưa nhận đăng ký cho đợt này.";
            noiDung += "\n";
        }

        noiDung += "\nBạn có muốn mở trang đăng ký này không?";

        var traLoi = MessageBox.Show(noiDung, "Link đăng ký trực tuyến",
            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (traLoi != DialogResult.Yes) return;

        try
        {
            Process.Start(new ProcessStartInfo(LinkDangKy) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không mở được trình duyệt: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Bấm nút Sửa / Xóa ngay trên dòng
    private void dgvDot_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        if (dgvDot.Rows[e.RowIndex].DataBoundItem is not DotTuyenSinh dot) return;

        switch (dgvDot.Columns[e.ColumnIndex].Name)
        {
            case "colSua": Sua(dot); break;
            case "colXoa": Xoa(dot); break;
        }
    }

    private void Sua(DotTuyenSinh dot)
    {
        try
        {
            if (!PhanQuyen.CoTheSuaDot(dot.MaDot))
            {
                MessageBox.Show("Bạn chỉ sửa được các đợt tuyển sinh mà mình được phân công.\nNhấn đúp vào dòng để xem đợt này.",
                    "Không có quyền sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var form = new FormDotEdit(dot, chiXem: false);
            form.ShowDialog(FindForm());
            if (form.CoThayDoi) TaiDuLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không mở được đợt tuyển sinh: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Xoa(DotTuyenSinh dot)
    {
        if (!PhanQuyen.CoTheThemXoaDot) return;

        try
        {
            var (soKhoaHoc, soHoSo, soPhanCong) = DotRepo.DemDuLieuLienQuan(dot.MaDot);

            string canhBao =
                $"Bạn có chắc muốn xóa đợt \"{dot.TenDot}\" không?\n\n" +
                "Vì việc xóa sẽ xóa vĩnh viễn toàn bộ dữ liệu liên quan đến đợt này:\n" +
                $"   •  {soHoSo} hồ sơ đăng ký\n" +
                $"   •  {soPhanCong} lượt phân công nhân viên\n" +
                $"   •  {soKhoaHoc} khóa học trong đợt (chỉ gỡ khỏi đợt, khóa học vẫn còn ở mục Khóa học)\n\n" +
                "Dữ liệu đã xóa KHÔNG thể khôi phục.";

            var traLoi = MessageBox.Show(canhBao, "Cảnh báo xóa đợt tuyển sinh",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (traLoi != DialogResult.Yes) return;

            DotRepo.XoaVinhVien(dot.MaDot);
            MessageBox.Show($"Đã xóa đợt \"{dot.TenDot}\" và toàn bộ dữ liệu liên quan.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDuLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không xóa được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Nhấn đúp vào dòng: chỉ xem
    private void dgvDot_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        string cot = dgvDot.Columns[e.ColumnIndex].Name;
        if (cot == "colSua" || cot == "colXoa") return;   // đã xử lý ở nút
        if (dgvDot.Rows[e.RowIndex].DataBoundItem is not DotTuyenSinh dot) return;

        using var form = new FormDotEdit(dot, chiXem: true);
        form.ShowDialog(FindForm());
    }
}