using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Helpers;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Forms;

/// <summary>
/// Thêm mới (dot = null), sửa hoặc xem (chiXem = true) một đợt tuyển sinh.
/// Tab "Khóa Học Trong Đợt" liệt kê các khóa học kèm hộp kiểm; thông tin đợt và khóa học được lưu cùng lúc.
/// </summary>
public partial class FormDotEdit : Form
{
    private DotTuyenSinh? _dot;          // null khi đang thêm mới
    private readonly bool _chiXem;
    private bool _dangNap;               // đang nạp danh sách khóa học, bỏ qua sự kiện ItemCheck

    /// <summary>True nếu có thay đổi dữ liệu, để danh sách bên ngoài tải lại.</summary>
    public bool CoThayDoi { get; private set; }

    public FormDotEdit(DotTuyenSinh? dot = null, bool chiXem = false)
    {
        InitializeComponent();
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
        lblHuongDan.Text = "Các khóa học được mở trong đợt này (chỉ xem).";
    }

    private void NapKhoaHoc()
    {
        try
        {
            var ds = DotRepo.LayKhoaHocChoDot(_dot?.MaDot);

            _dangNap = true;
            clbKhoaHoc.Items.Clear();
            foreach (var khoa in ds)
                clbKhoaHoc.Items.Add(khoa, khoa.CoTrongDot);
            _dangNap = false;
        }
        catch (Exception ex)
        {
            _dangNap = false;
            MessageBox.Show("Không tải được danh sách khóa học: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void clbKhoaHoc_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        if (_dangNap) return;

        // Chế độ xem: không cho đổi
        if (_chiXem)
        {
            e.NewValue = e.CurrentValue;
            return;
        }

        // Không cho bỏ tích khóa đã có hồ sơ hoặc phân công
        if (e.NewValue == CheckState.Unchecked &&
            clbKhoaHoc.Items[e.Index] is KhoaHocChonItem khoa && khoa.CoDuLieu)
        {
            e.NewValue = CheckState.Checked;
            MessageBox.Show($"Khóa học \"{khoa.TenKhoaHoc}\" đã có hồ sơ hoặc đã được phân công nhân viên nên không thể gỡ khỏi đợt.",
                "Không thể gỡ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
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
        var khoaHocDuocTich = clbKhoaHoc.CheckedItems.Cast<KhoaHocChonItem>()
            .Select(x => x.MaKhoaHoc).ToList();

        try
        {
            if (_dot == null)
            {
                // Thêm đợt mới, rồi gắn các khóa học đã tích
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
                // Lưu khóa học trước: nếu không hợp lệ thì chưa lưu gì cả
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