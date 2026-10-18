using System.Diagnostics;
using ClosedXML.Excel;
using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Controls;

/// <summary>
/// Thống kê hồ sơ và mức đạt chỉ tiêu theo đợt, khóa học. Quản trị viên xem toàn bộ,
/// nhân viên chỉ xem các khóa học mình được phân công.
/// </summary>
public partial class ucThongKe : UserControl
{
    private bool _sanSang;   // chỉ tải dữ liệu sau khi control đã sẵn sàng (tránh gọi CSDL lúc thiết kế)
    private bool _dangNap;   // đang nạp lại ComboBox, bỏ qua sự kiện đổi lựa chọn
    private List<ThongKeItem> _ds = new();
    private readonly int? _maNhanVien = PhienDangNhap.LaNhanVien ? PhienDangNhap.HienTai?.MaNhanVien : null;

    public ucThongKe()
    {
        InitializeComponent();
        LuoiHelper.DanhSoThuTu(dgvThongKe, "colStt");
        LuoiHelper.CauHinhChung(dgvThongKe);
    }

    private void ucThongKe_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        try
        {
            var dots = new List<LuaChon> { new(null, "Tất cả các đợt") };
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
        var ds = new List<LuaChon> { new(null, "Tất cả các khóa") };
        ds.AddRange(HoSoRepo.LayKhoaHocTrongPhamVi(maDot, _maNhanVien));

        _dangNap = true;
        try { GanDanhSach(cboKhoaHoc, ds); }
        finally { _dangNap = false; }
    }

    private void TaiDuLieu()
    {
        if (!_sanSang) return;
        try
        {
            int? maDot = cboDot.SelectedValue as int?;
            int? maKhoaHoc = cboKhoaHoc.SelectedValue as int?;
            _ds = ThongKeRepo.LayThongKe(maDot, maKhoaHoc, _maNhanVien);
            dgvThongKe.DataSource = _ds;

            lblTong.Text = $"Tổng hồ sơ\n{_ds.Sum(x => x.Tong)}";
            lblChoXuLy.Text = $"Chờ xử lý\n{_ds.Sum(x => x.ChoXuLy)}";
            lblDaDuyet.Text = $"Đã duyệt\n{_ds.Sum(x => x.DaDuyet)}";
            lblDaHuy.Text = $"Đã hủy\n{_ds.Sum(x => x.DaHuy)}";

            // Mức đạt chỉ tiêu chung: chỉ tính các khóa đã đặt chỉ tiêu
            int tongChiTieu = _ds.Sum(x => x.ChiTieu);
            int duyetCoChiTieu = _ds.Where(x => x.ChiTieu > 0).Sum(x => x.DaDuyet);
            lblChiTieu.Text = tongChiTieu > 0
                ? $"Đạt chỉ tiêu\n{duyetCoChiTieu * 100.0 / tongChiTieu:0.#}% ({duyetCoChiTieu}/{tongChiTieu})"
                : "Đạt chỉ tiêu\nChưa đặt chỉ tiêu";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được số liệu thống kê: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Khóa đạt hoặc vượt chỉ tiêu thì phần trăm hiện màu xanh
    private void dgvThongKe_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        if (dgvThongKe.Columns[e.ColumnIndex].Name != "colTyLeChiTieu") return;
        if (dgvThongKe.Rows[e.RowIndex].DataBoundItem is ThongKeItem x && x.ChiTieu > 0 && x.DaDuyet >= x.ChiTieu)
            e.CellStyle.ForeColor = Color.Green;
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

    private void btnLamMoi_Click(object? sender, EventArgs e) => TaiDuLieu();

    private void btnXuatCsv_Click(object? sender, EventArgs e)
    {
        if (_ds.Count == 0)
        {
            MessageBox.Show("Chưa có số liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var hopThoai = new SaveFileDialog
        {
            Filter = "Tệp Excel (*.xlsx)|*.xlsx",
            FileName = $"thongke_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
        };
        if (hopThoai.ShowDialog(FindForm()) != DialogResult.OK) return;

        try
        {
            const int soCot = 10;
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Thống kê");

            // Tiêu đề và thông tin chung
            ws.Cell(1, 1).Value = "THỐNG KÊ HỒ SƠ ĐĂNG KÝ VÀ CHỈ TIÊU";
            var tieuDe = ws.Range(1, 1, 1, soCot);
            tieuDe.Merge();
            tieuDe.Style.Font.Bold = true;
            tieuDe.Style.Font.FontSize = 14;
            tieuDe.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell(2, 1).Value = $"Phạm vi: {cboDot.Text}  |  {cboKhoaHoc.Text}";
            ws.Cell(3, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";

            // Dòng tiêu đề của bảng
            string[] tenCot = { "STT", "Đợt Tuyển Sinh", "Khóa Học", "Chỉ Tiêu", "Tổng Hồ Sơ", "Chờ Xử Lý",
                                "Đã Duyệt", "Đã Hủy", "Tỷ Lệ Duyệt", "Đạt Chỉ Tiêu" };
            for (int i = 0; i < tenCot.Length; i++)
                ws.Cell(5, i + 1).Value = tenCot[i];

            // Dữ liệu
            int dong = 6;
            int stt = 1;
            foreach (var x in _ds)
            {
                ws.Cell(dong, 1).Value = stt++;
                ws.Cell(dong, 2).Value = x.TenDot;
                ws.Cell(dong, 3).Value = x.TenKhoaHoc;
                ws.Cell(dong, 4).Value = x.ChiTieu;
                ws.Cell(dong, 5).Value = x.Tong;
                ws.Cell(dong, 6).Value = x.ChoXuLy;
                ws.Cell(dong, 7).Value = x.DaDuyet;
                ws.Cell(dong, 8).Value = x.DaHuy;
                if (x.Tong > 0) ws.Cell(dong, 9).Value = (double)x.DaDuyet / x.Tong;
                if (x.DatChiTieu.HasValue) ws.Cell(dong, 10).Value = x.DatChiTieu.Value;
                dong++;
            }

            // Dòng tổng cộng
            int tong = _ds.Sum(x => x.Tong);
            int duyet = _ds.Sum(x => x.DaDuyet);
            int tongChiTieu = _ds.Sum(x => x.ChiTieu);
            int duyetCoChiTieu = _ds.Where(x => x.ChiTieu > 0).Sum(x => x.DaDuyet);
            ws.Cell(dong, 2).Value = "Tổng Cộng";
            ws.Cell(dong, 4).Value = tongChiTieu;
            ws.Cell(dong, 5).Value = tong;
            ws.Cell(dong, 6).Value = _ds.Sum(x => x.ChoXuLy);
            ws.Cell(dong, 7).Value = duyet;
            ws.Cell(dong, 8).Value = _ds.Sum(x => x.DaHuy);
            if (tong > 0) ws.Cell(dong, 9).Value = (double)duyet / tong;
            if (tongChiTieu > 0) ws.Cell(dong, 10).Value = (double)duyetCoChiTieu / tongChiTieu;

            // Định dạng
            ws.Range(dong, 1, dong, soCot).Style.Font.Bold = true;
            ws.Range(6, 9, dong, 10).Style.NumberFormat.Format = "0.0%";

            var dongTieuDe = ws.Range(5, 1, 5, soCot);
            dongTieuDe.Style.Font.Bold = true;
            dongTieuDe.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            dongTieuDe.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var bang = ws.Range(5, 1, dong, soCot);
            bang.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            bang.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            ws.Range(6, 1, dong, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range(6, 4, dong, soCot).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Columns(1, soCot).AdjustToContents(5, dong);

            wb.SaveAs(hopThoai.FileName);

            var mo = MessageBox.Show("Đã xuất file thành công. Bạn có muốn mở file không?", "Thành công",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (mo == DialogResult.Yes)
                Process.Start(new ProcessStartInfo(hopThoai.FileName) { UseShellExecute = true });
        }
        catch (IOException)
        {
            MessageBox.Show("Không ghi được file. Nếu file đang mở trong Excel, hãy đóng lại rồi thử lần nữa.",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không xuất được file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}