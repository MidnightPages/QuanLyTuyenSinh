using QuanLyTuyenSinh.Services;
using QuanLyTuyenSinh.Controls;

namespace QuanLyTuyenSinh.Forms;

public partial class FormMain : Form
{
    public bool DangXuat { get; private set; }
    private readonly List<Button> _nutMenu = new();

    public FormMain()
    {
        InitializeComponent();

        var nguoiDung = PhienDangNhap.HienTai!;
        lblNguoiDung.Text = $"  {nguoiDung.HoTen} ({nguoiDung.VaiTro})";
        new ToolTip().SetToolTip(lblNguoiDung, "Bấm để xem và sửa thông tin tài khoản");
        TaoMenu();
        if (_nutMenu.Count > 0) _nutMenu[0].PerformClick();
    }

    private void TaoMenu()
    {
        string[] cacMuc = PhienDangNhap.LaQuanTri
            ? new[] { "Hồ sơ", "Đợt tuyển sinh", "Khóa học", "Phân công", "Nhân viên", "Thống kê" }
            : new[] { "Hồ sơ", "Đợt tuyển sinh", "Khóa học", "Phân công của tôi", "Thống kê" };

        foreach (string ten in cacMuc)
        {
            var nut = new Button
            {
                Text = ten,
                Width = flpMenu.Width - 10,
                Height = 44,
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat
            };
            nut.Click += (s, e) => MoTrang(nut, ten);
            flpMenu.Controls.Add(nut);
            _nutMenu.Add(nut);
        }
    }

    private void MoTrang(Button nutDangChon, string tenTrang)
    {
        foreach (var n in _nutMenu) n.BackColor = SystemColors.Control;
        nutDangChon.BackColor = Color.LightSteelBlue;

        foreach (Control c in pnlNoiDung.Controls.Cast<Control>().ToList())
        {
            pnlNoiDung.Controls.Remove(c);
            c.Dispose();
        }

        Control trang = tenTrang switch
        {
            "Khóa học" => new ucKhoaHoc(),
            "Đợt tuyển sinh" => new ucDotTuyenSinh(),
            "Nhân viên" => new ucNhanVien(),
            "Phân công" => new ucPhanCong(),
            "Phân công của tôi" => new ucPhanCongCuaToi(),
            "Hồ sơ" or "Hồ sơ (chỉ xem)" => new ucHoSo(),
            "Thống kê" => new ucThongKe(),
            _ => new Label
            {
                Text = $"Trang \"{tenTrang}\" đang xây dựng",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14)
            }
        };
        trang.Dock = DockStyle.Fill;
        pnlNoiDung.Controls.Add(trang);
    }

    private void btnDangXuat_Click(object? sender, EventArgs e)
    {
        DangXuat = true;
        Close();
    }

    private void pnlTop_Paint(object sender, PaintEventArgs e)
    {

    }

    private void lblNguoiDung_Click(object? sender, EventArgs e)
    {
        using var form = new FormTaiKhoanCaNhan();
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            var nguoiDung = PhienDangNhap.HienTai!;
            lblNguoiDung.Text = $"  {nguoiDung.HoTen} ({nguoiDung.VaiTro})";
        }
    }

    private void tenht_Click(object sender, EventArgs e)
    {

    }

    private void pnlNoiDung_Paint(object sender, PaintEventArgs e)
    {

    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }
}

