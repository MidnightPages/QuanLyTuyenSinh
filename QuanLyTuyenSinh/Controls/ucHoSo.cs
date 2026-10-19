using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Forms;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;
using System.Diagnostics;
using System.Globalization;
using ClosedXML.Excel;

namespace QuanLyTuyenSinh.Controls;


/// <summary>
/// Nhân viên: xem hồ sơ thuộc phạm vi phụ trách, duyệt hàng loạt rồi bấm Lưu, thêm/sửa/xóa hồ sơ.
/// Quản trị viên: chỉ xem toàn bộ hồ sơ theo đợt và khóa học.
/// </summary>
public partial class ucHoSo : UserControl
{
    private bool _sanSang;      // chỉ tải dữ liệu sau khi control đã sẵn sàng (tránh gọi CSDL lúc thiết kế)
    private bool _dangNap;      // đang nạp lại ComboBox, bỏ qua sự kiện đổi lựa chọn
    private List<HoSoItem> _ds = new();
    private readonly BindingSource _bs = new();
    private readonly bool _laNhanVien = PhienDangNhap.LaNhanVien;
    private readonly int? _maNhanVien = PhienDangNhap.LaNhanVien ? PhienDangNhap.HienTai?.MaNhanVien : null;

    public ucHoSo()
    {
        InitializeComponent();
        LuoiHelper.DanhSoThuTu(dgvHoSo, "colStt");
        LuoiHelper.CauHinhChung(dgvHoSo);

        cboTrangThai.Items.Add("Tất cả");
        cboTrangThai.Items.AddRange(DanhMuc.TrangThaiHoSo);
        cboTrangThai.SelectedIndex = 0;

        dgvHoSo.DataSource = _bs;
        new ToolTip().SetToolTip(btnXuatDanhSach,
        "Xuất danh sách học viên đã được duyệt theo đợt và khóa học đang chọn");
    }

    // Quản trị viên chỉ xem: ẩn cột Chọn, cột Sửa, Xóa và các nút xử lý
    private void ApDungCheDoQuyen()
    {
        if (_laNhanVien) return;

        foreach (string ten in new[] { "colChon", "colSua", "colXoa" })
        {
            var cot = dgvHoSo.Columns[ten];
            if (cot != null) cot.Visible = false;
        }

        foreach (Control c in new Control[] { btnChonTatCa, btnBoChon, btnDuyet, btnHuyHS, btnLuu, btnBoQua, btnThem })
            c.Visible = false;
    }

    private void ucHoSo_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;

        ApDungCheDoQuyen();

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

    // Danh sách khóa học trong ComboBox phụ thuộc vào đợt đang chọn
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
        if (!_sanSang) return;
        try
        {
            int? maDot = cboDot.SelectedValue as int?;
            int? maKhoaHoc = cboKhoaHoc.SelectedValue as int?;
            string? trangThai = cboTrangThai.SelectedIndex > 0 ? cboTrangThai.SelectedItem!.ToString() : null;

            _ds = HoSoRepo.LayDanhSach(maDot, maKhoaHoc, trangThai, txtTimKiem.Text.Trim(), _maNhanVien);
            foreach (var h in _ds)
            {
                h.TrangThaiGoc = h.TrangThaiHoSo;
                DatQuyenXuLy(h);
            }
            _bs.DataSource = _ds;
            CapNhatNut();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách hồ sơ: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Hồ sơ nào nhân viên được xử lý (tích chọn, đổi trạng thái) và ghi chú lý do nếu không được
    private void DatQuyenXuLy(HoSoItem h)
    {
        if (!_laNhanVien)
        {
            h.DuocXuLy = false;
            h.GhiChu = h.DaKetThuc ? "Đợt đã kết thúc" : "";
            return;
        }

        bool doNguoiKhac = h.MaNhanVienXacNhan != null && h.MaNhanVienXacNhan != _maNhanVien;
        h.DuocXuLy = !h.DaKetThuc && !doNguoiKhac;
        h.GhiChu = h.DaKetThuc ? "Đợt đã kết thúc"
                 : doNguoiKhac ? $"Do {h.TenNhanVienXacNhan} xác nhận"
                 : "";
    }

    private bool CoThayDoiChuaLuu() => _ds.Any(x => x.DaThayDoi);

    // Có thay đổi chưa lưu thì khóa bộ lọc và nút thêm để khỏi làm mất thay đổi
    private void CapNhatNut()
    {
        int soThayDoi = _ds.Count(x => x.DaThayDoi);
        bool coThayDoi = soThayDoi > 0;

        btnLuu.Enabled = coThayDoi;
        btnBoQua.Enabled = coThayDoi;
        btnThem.Enabled = !coThayDoi;
        cboDot.Enabled = !coThayDoi;
        cboKhoaHoc.Enabled = !coThayDoi;
        cboTrangThai.Enabled = !coThayDoi;
        txtTimKiem.Enabled = !coThayDoi;

        lblTomTat.Text = $"  {_ds.Count} hồ sơ"
            + (coThayDoi ? $"  -  {soThayDoi} thay đổi chưa lưu (các dòng tô vàng), hãy bấm Lưu hoặc Bỏ thay đổi" : "");
    }

    private static void NhacLuuTruoc()
    {
        MessageBox.Show("Đang có thay đổi duyệt chưa lưu. Hãy bấm Lưu hoặc Bỏ thay đổi trước.",
            "Chưa lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ----- bộ lọc -----
    private void cboDot_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangNap || !_sanSang) return;
        try { NapKhoaHoc(); } catch { /* lỗi sẽ hiện ở TaiDuLieu */ }
        TaiDuLieu();
    }

    private void cboLoc_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangNap || !_sanSang) return;
        TaiDuLieu();
    }

    private void txtTimKiem_TextChanged(object? sender, EventArgs e)
    {
        if (!_sanSang) return;
        TaiDuLieu();
    }

    // ----- duyệt hàng loạt -----
    private void btnChonTatCa_Click(object? sender, EventArgs e)
    {
        foreach (var h in _ds) h.Chon = h.DuocXuLy;
        _bs.ResetBindings(false);
    }

    private void btnBoChon_Click(object? sender, EventArgs e)
    {
        foreach (var h in _ds) h.Chon = false;
        _bs.ResetBindings(false);
    }

    private void DatTrangThai(string trangThaiMoi)
    {
        var chon = _ds.Where(x => x.Chon && x.DuocXuLy).ToList();
        if (chon.Count == 0)
        {
            MessageBox.Show("Hãy tích chọn ít nhất một hồ sơ. Dòng chữ xám là hồ sơ bạn không xử lý được.",
                "Chưa chọn hồ sơ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        foreach (var h in chon)
        {
            h.TrangThaiHoSo = trangThaiMoi;
            h.Chon = false;
        }
        _bs.ResetBindings(false);
        CapNhatNut();
    }

    private void btnDuyet_Click(object? sender, EventArgs e) => DatTrangThai("Đã duyệt");

    private void btnHuyHS_Click(object? sender, EventArgs e) => DatTrangThai("Đã hủy");

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        if (_maNhanVien == null) return;
        var thayDoi = _ds.Where(x => x.DaThayDoi).ToList();
        if (thayDoi.Count == 0) return;

        int soDuyet = thayDoi.Count(x => x.TrangThaiHoSo == "Đã duyệt");
        int soHuy = thayDoi.Count(x => x.TrangThaiHoSo == "Đã hủy");
        var traLoi = MessageBox.Show(
            $"Lưu {thayDoi.Count} thay đổi ({soDuyet} Đã duyệt, {soHuy} Đã hủy)?",
            "Xác nhận lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (traLoi != DialogResult.Yes) return;

        try
        {
            var (thanhCong, loi) = HoSoRepo.LuuTrangThai(thayDoi, _maNhanVien.Value);
            string noiDung = $"Đã lưu {thanhCong}/{thayDoi.Count} hồ sơ.";
            if (loi.Count > 0)
                noiDung += "\n\nKhông lưu được:\n" + string.Join("\n", loi);

            MessageBox.Show(noiDung, "Kết quả",
                MessageBoxButtons.OK, loi.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            TaiDuLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lưu được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnBoQua_Click(object? sender, EventArgs e) => TaiDuLieu();

    // ----- thêm, sửa, xóa -----
    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!_laNhanVien) return;
        using var form = new FormHoSoThem();
        if (form.ShowDialog(FindForm()) == DialogResult.OK) TaiDuLieu();
    }

    // Bấm nút Sửa / Xóa ngay trên dòng
    private void dgvHoSo_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (!_laNhanVien || e.RowIndex < 0 || e.ColumnIndex < 0) return;
        if (dgvHoSo.Rows[e.RowIndex].DataBoundItem is not HoSoItem hoSo) return;

        switch (dgvHoSo.Columns[e.ColumnIndex].Name)
        {
            case "colSua": Sua(hoSo); break;
            case "colXoa": Xoa(hoSo); break;
        }
    }

    private void Sua(HoSoItem hoSo)
    {
        if (CoThayDoiChuaLuu()) { NhacLuuTruoc(); return; }
        if (hoSo.DaKetThuc)
        {
            MessageBox.Show("Đợt tuyển sinh đã kết thúc nên không sửa được hồ sơ.\nNhấn đúp vào dòng để xem.",
                "Không thể sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var form = new FormHoSoChiTiet(hoSo, chiXem: false);
        form.ShowDialog(FindForm());
        if (form.CoThayDoi) TaiDuLieu();
    }

    private void Xoa(HoSoItem hoSo)
    {
        if (_maNhanVien == null) return;
        if (CoThayDoiChuaLuu()) { NhacLuuTruoc(); return; }
        if (hoSo.DaKetThuc)
        {
            MessageBox.Show("Đợt tuyển sinh đã kết thúc nên không xóa được hồ sơ.", "Không thể xóa",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var traLoi = MessageBox.Show($"Xóa hồ sơ của \"{hoSo.HoTen}\"?", "Xác nhận xóa",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (traLoi != DialogResult.Yes) return;

        try
        {
            if (!HoSoRepo.Xoa(hoSo.MaHoSo, _maNhanVien.Value))
            {
                MessageBox.Show("Không xóa được: hồ sơ nằm ngoài phạm vi của bạn hoặc đợt đã kết thúc.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            TaiDuLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không xóa được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ----- xuất danh sách học viên đã được duyệt -----
    // Lấy "tên" (từ cuối của họ tên) để sắp xếp danh sách theo kiểu danh sách lớp
    private static string TenGoi(string hoTen) =>
        hoTen.Split(' ', StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? "";

    private void btnXuatDanhSach_Click(object? sender, EventArgs e)
    {
        if (CoThayDoiChuaLuu()) { NhacLuuTruoc(); return; }

        int? maDot = cboDot.SelectedValue as int?;
        int? maKhoaHoc = cboKhoaHoc.SelectedValue as int?;

        List<HoSoItem> dsDuyet;
        try
        {
            // Luôn lấy hồ sơ "Đã duyệt" theo đợt và khóa học đang chọn (bỏ qua ô trạng thái và ô tìm kiếm)
            dsDuyet = HoSoRepo.LayDanhSach(maDot, maKhoaHoc, "Đã duyệt", "", _maNhanVien);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lấy được danh sách: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (dsDuyet.Count == 0)
        {
            MessageBox.Show("Không có hồ sơ nào ở trạng thái Đã duyệt trong đợt và khóa học đang chọn.",
                "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Sắp xếp theo tên rồi họ tên, theo thứ tự chữ cái tiếng Việt
        var vi = StringComparer.Create(new CultureInfo("vi-VN"), true);
        dsDuyet = dsDuyet.OrderBy(h => TenGoi(h.HoTen), vi).ThenBy(h => h.HoTen, vi).ToList();

        using var hopThoai = new SaveFileDialog
        {
            Filter = "Tệp Excel (*.xlsx)|*.xlsx",
            FileName = $"danhsach_da_duyet_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
        };
        if (hopThoai.ShowDialog(FindForm()) != DialogResult.OK) return;

        try
        {
            const int soCot = 11;
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Danh sách đã duyệt");

            // Tiêu đề và thông tin chung
            ws.Cell(1, 1).Value = "DANH SÁCH HỌC VIÊN ĐÃ ĐƯỢC DUYỆT";
            var tieuDe = ws.Range(1, 1, 1, soCot);
            tieuDe.Merge();
            tieuDe.Style.Font.Bold = true;
            tieuDe.Style.Font.FontSize = 14;
            tieuDe.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell(2, 1).Value = $"Đợt tuyển sinh: {cboDot.Text}";
            ws.Cell(3, 1).Value = $"Khóa học: {cboKhoaHoc.Text}";
            ws.Cell(4, 1).Value = $"Tổng số học viên: {dsDuyet.Count}    |    Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";

            // Dòng tiêu đề của bảng
            string[] tenCot = { "STT", "Họ Tên", "Ngày Sinh", "Số Điện Thoại", "Email", "Địa Chỉ",
                                "Đợt Tuyển Sinh", "Khóa Học", "Ngày Đăng Ký", "Ngày Duyệt", "Người Duyệt" };
            for (int i = 0; i < tenCot.Length; i++)
                ws.Cell(6, i + 1).Value = tenCot[i];

            // Dữ liệu
            int dong = 7;
            int stt = 1;
            foreach (var h in dsDuyet)
            {
                ws.Cell(dong, 1).Value = stt++;
                ws.Cell(dong, 2).Value = h.HoTen;
                if (h.NgaySinh.HasValue) ws.Cell(dong, 3).Value = h.NgaySinh.Value;
                ws.Cell(dong, 4).Value = h.SoDienThoai;     // lưu dạng chữ để giữ số 0 ở đầu
                ws.Cell(dong, 5).Value = h.Email;
                ws.Cell(dong, 6).Value = h.DiaChi ?? "";
                ws.Cell(dong, 7).Value = h.TenDot;
                ws.Cell(dong, 8).Value = h.TenKhoaHoc;
                ws.Cell(dong, 9).Value = h.NgayDangKy;
                if (h.NgayXacNhan.HasValue) ws.Cell(dong, 10).Value = h.NgayXacNhan.Value;
                ws.Cell(dong, 11).Value = h.TenNhanVienXacNhan ?? "";
                dong++;
            }
            int dongCuoi = dong - 1;

            // Định dạng
            ws.Range(7, 3, dongCuoi, 3).Style.DateFormat.Format = "dd/MM/yyyy";
            ws.Range(7, 9, dongCuoi, 10).Style.DateFormat.Format = "dd/MM/yyyy HH:mm";

            var dongTieuDe = ws.Range(6, 1, 6, soCot);
            dongTieuDe.Style.Font.Bold = true;
            dongTieuDe.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            dongTieuDe.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var bang = ws.Range(6, 1, dongCuoi, soCot);
            bang.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            bang.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            ws.Range(7, 1, dongCuoi, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range(7, 3, dongCuoi, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Columns(1, soCot).AdjustToContents(6, dongCuoi);

            wb.SaveAs(hopThoai.FileName);

            var mo = MessageBox.Show($"Đã xuất {dsDuyet.Count} học viên. Bạn có muốn mở file không?", "Thành công",
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

    // ----- sự kiện của lưới -----
    private void dgvHoSo_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
    {
        // Chỉ cho tích chọn các hồ sơ xử lý được
        if (dgvHoSo.Columns[e.ColumnIndex].Name != "colChon") return;
        if (dgvHoSo.Rows[e.RowIndex].DataBoundItem is HoSoItem h && !h.DuocXuLy) e.Cancel = true;
    }

    private void dgvHoSo_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        // Ghi nhận ngay khi tích ô (không chờ rời khỏi ô)
        if (dgvHoSo.IsCurrentCellDirty) dgvHoSo.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgvHoSo_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (dgvHoSo.Rows[e.RowIndex].DataBoundItem is not HoSoItem h) return;

        if (h.DaThayDoi) e.CellStyle.BackColor = Color.LightYellow;
        else if (_laNhanVien && !h.DuocXuLy) e.CellStyle.ForeColor = Color.Gray;
    }

    // Nhấn đúp vào dòng: chỉ xem
    private void dgvHoSo_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        string cot = dgvHoSo.Columns[e.ColumnIndex].Name;
        if (cot == "colSua" || cot == "colXoa" || cot == "colChon") return;   // đã xử lý ở nút / ô tích
        if (dgvHoSo.Rows[e.RowIndex].DataBoundItem is not HoSoItem hoSo) return;

        using var form = new FormHoSoChiTiet(hoSo, chiXem: true);
        form.ShowDialog(FindForm());
    }
}