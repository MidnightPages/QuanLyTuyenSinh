using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Models;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh.Forms;

/// <summary>
/// Nhân viên thêm hồ sơ thủ công (khi học viên không thể đăng ký trên website).
/// Chỉ thêm được vào khóa học mình phụ trách, trong đợt chưa kết thúc.
/// </summary>
public partial class FormHoSoThem : Form
{
    private bool _sanSang;   // tránh nạp lại khóa học khi đang gán dữ liệu cho các ComboBox

    public FormHoSoThem()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode) return;

        try
        {
            int maNhanVien = PhienDangNhap.HienTai!.MaNhanVien;
            var dots = HoSoRepo.LayDotChoThemHoSo(maNhanVien);
            if (dots.Count == 0)
            {
                MessageBox.Show(
                    "Hiện chưa có đợt nào bạn có thể thêm hồ sơ (cần được phân công khóa học và đợt chưa kết thúc).",
                    "Không có đợt phù hợp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                return;
            }

            cboDot.DisplayMember = nameof(LuaChon.Ten);
            cboDot.ValueMember = nameof(LuaChon.Ma);
            cboDot.DataSource = dots;

            cboKhoaHoc.DisplayMember = nameof(LuaChon.Ten);
            cboKhoaHoc.ValueMember = nameof(LuaChon.Ma);

            _sanSang = true;
            NapKhoaHoc();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Chỉ liệt kê khóa học trong đợt đang chọn mà nhân viên được phân công
    private void NapKhoaHoc()
    {
        if (!_sanSang) return;
        if (cboDot.SelectedValue is int maDot)
            cboKhoaHoc.DataSource = HoSoRepo.LayKhoaHocTrongPhamVi(maDot, PhienDangNhap.HienTai!.MaNhanVien);
        else
            cboKhoaHoc.DataSource = null;
    }

    private void cboDot_SelectedIndexChanged(object? sender, EventArgs e) => NapKhoaHoc();

    private static void Canh(string noiDung)
    {
        MessageBox.Show(noiDung, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        if (cboDot.SelectedValue is not int maDot || cboKhoaHoc.SelectedValue is not int maKhoaHoc)
        {
            Canh("Vui lòng chọn đợt tuyển sinh và khóa học.");
            return;
        }
        if (txtHoTen.Text.Trim() == "") { Canh("Vui lòng nhập họ tên."); txtHoTen.Focus(); return; }
        if (txtSoDienThoai.Text.Trim() == "") { Canh("Vui lòng nhập số điện thoại."); txtSoDienThoai.Focus(); return; }
        if (txtEmail.Text.Trim() == "") { Canh("Vui lòng nhập email."); txtEmail.Focus(); return; }

        var hoSo = new HoSoItem
        {
            HoTen = txtHoTen.Text.Trim(),
            NgaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null,
            SoDienThoai = txtSoDienThoai.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim()
        };

        try
        {
            string? loi = HoSoRepo.ThemThuCong(PhienDangNhap.HienTai!.MaNhanVien, maDot, maKhoaHoc, hoSo);
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