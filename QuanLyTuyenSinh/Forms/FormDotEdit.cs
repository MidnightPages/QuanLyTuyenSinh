using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Forms;

/// <summary>
/// Thêm mới (dot = null), sửa hoặc xem (chiXem = true) một đợt tuyển sinh.
/// Tab "Khóa Học Trong Đợt" là bảng tích chọn khóa học kèm chỉ tiêu; thông tin đợt, khóa học và
/// chỉ tiêu được lưu cùng lúc.
/// </summary>
public partial class FormDotEdit : Form
{
    private DotTuyenSinh? _dot;          // null khi đang thêm mới
    private readonly bool _chiXem;
    private List<KhoaHocChonItem> _dsKhoa = new();

    /// <summary>True nếu có thay đổi dữ liệu, để danh sách bên ngoài tải lại.</summary>
    public bool CoThayDoi { get; private set; }

    public FormDotEdit(DotTuyenSinh? dot = null, bool chiXem = false)
    {
        InitializeComponent();
        LuoiHelper.DanhSoThuTu(dgvKhoaHoc, "colStt");
        _dot = dot;
        _chiXem = chiXem;

        cboTrangThai.Items.AddRange(DanhMuc.TrangThaiDot);

        if (_dot == null)
        {
            Text = "Thêm đợt tuyển sinh";
            dtpBatDau.Value = DateTime.Today;
            dtpKetThuc.Value = DateTime.Today.AddMonths(2);
            cboTrangThai.SelectedIndex = 0;
        }
        else
        {
            Text = _chiXem ? "Xem đợt tuyển sinh" : "Sửa đợt tuyển sinh";
            txtTenDot.Text = _dot.TenDot;
            dtpBatDau.Value = _dot.NgayBatDau;
            dtpKetThuc.Value = _dot.NgayKetThuc;
            cboTrangThai.SelectedItem = _dot.TrangThai;
            txtMoTa.Text = _dot.MoTa ?? "";
        }

        if (_chiXem) KhoaChiXem();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode) return;
        NapKhoaHoc();
    }

    private void KhoaChiXem()
    {
        txtTenDot.ReadOnly = true;
        dtpBatDau.Enabled = false;
        dtpKetThuc.Enabled = false;
        cboTrangThai.Enabled = false;
        txtMoTa.ReadOnly = true;
        btnLuu.Visible = false;
        dgvKhoaHoc.ReadOnly = true;
        lblHuongDan.Text = "Các khóa học được mở trong đợt này và chỉ tiêu của từng khóa (chỉ xem).";
    }

    private void NapKhoaHoc()
    {
        try
        {
            _dsKhoa = DotRepo.LayKhoaHocChoDot(_dot?.MaDot);
            foreach (var khoa in _dsKhoa) khoa.Chon = khoa.CoTrongDot;
            dgvKhoaHoc.DataSource = _dsKhoa;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được danh sách khóa học: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Không cho bỏ tích khóa đã có hồ sơ hoặc phân công
    private void dgvKhoaHoc_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
    {
        if (dgvKhoaHoc.Columns[e.ColumnIndex].Name != "colChon") return;
        if (dgvKhoaHoc.Rows[e.RowIndex].DataBoundItem is KhoaHocChonItem khoa && khoa.CoDuLieu && khoa.Chon)
        {
            e.Cancel = true;
            MessageBox.Show($"Khóa học \"{khoa.TenKhoaHoc}\" đã có hồ sơ hoặc đã được phân công nhân viên nên không thể gỡ khỏi đợt.",
                "Không thể gỡ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Chỉ tiêu phải là số nguyên không âm
    private void dgvKhoaHoc_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
    {
        if (dgvKhoaHoc.Columns[e.ColumnIndex].Name != "colChiTieu") return;

        string chu = e.FormattedValue?.ToString()?.Trim() ?? "";
        if (!int.TryParse(chu, out int so) || so < 0 || so > 1_000_000)
        {
            MessageBox.Show("Chỉ tiêu phải là một số nguyên từ 0 trở lên.", "Chỉ tiêu không hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }
    }

    // Ghi nhận ngay khi tích ô (không chờ rời khỏi ô)
    private void dgvKhoaHoc_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        if (dgvKhoaHoc.IsCurrentCellDirty) dgvKhoaHoc.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgvKhoaHoc_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        e.ThrowException = false;   // tránh hộp thoại lỗi mặc định của DataGridView
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        // Chốt ô đang nhập dở (nếu nhập sai chỉ tiêu thì dừng lại)
        if (!dgvKhoaHoc.EndEdit()) return;

        string ten = txtTenDot.Text.Trim();
        if (ten == "")
        {
            MessageBox.Show("Vui lòng nhập tên đợt.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabMain.SelectedTab = tabThongTin;
            txtTenDot.Focus();
            return;
        }
        if (dtpKetThuc.Value.Date < dtpBatDau.Value.Date)
        {
            MessageBox.Show("Ngày kết thúc không được trước ngày bắt đầu.", "Dữ liệu chưa hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabMain.SelectedTab = tabThongTin;
            return;
        }
        if (cboTrangThai.SelectedItem == null)
        {
            MessageBox.Show("Vui lòng chọn trạng thái.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabMain.SelectedTab = tabThongTin;
            return;
        }

        string? moTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();
        var khoaHocDuocTich = _dsKhoa.Where(x => x.Chon)
            .Select(x => (MaKhoaHoc: x.MaKhoaHoc, ChiTieu: x.ChiTieu)).ToList();

        try
        {
            if (_dot == null)
            {
                // Thêm đợt mới, rồi gắn các khóa học đã tích kèm chỉ tiêu
                var moi = new DotTuyenSinh
                {
                    TenDot = ten,
                    NgayBatDau = dtpBatDau.Value.Date,
                    NgayKetThuc = dtpKetThuc.Value.Date,
                    TrangThai = cboTrangThai.SelectedItem.ToString()!,
                    MoTa = moTa
                };
                DotRepo.Them(moi);
                _dot = moi;
                CoThayDoi = true;

                string? loi = DotRepo.LuuKhoaHocTrongDot(moi.MaDot, khoaHocDuocTich);
                if (loi != null)
                {
                    MessageBox.Show("Đã tạo đợt nhưng chưa lưu được khóa học: " + loi, "Lưu chưa đầy đủ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                // Lưu khóa học và chỉ tiêu trước: nếu không hợp lệ thì chưa lưu gì cả
                string? loi = DotRepo.LuuKhoaHocTrongDot(_dot.MaDot, khoaHocDuocTich);
                if (loi != null)
                {
                    MessageBox.Show(loi, "Không lưu được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dot.TenDot = ten;
                _dot.NgayBatDau = dtpBatDau.Value.Date;
                _dot.NgayKetThuc = dtpKetThuc.Value.Date;
                _dot.TrangThai = cboTrangThai.SelectedItem.ToString()!;
                _dot.MoTa = moTa;
                DotRepo.Sua(_dot);
                CoThayDoi = true;
            }

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không lưu được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDong_Click(object? sender, EventArgs e) => Close();
}