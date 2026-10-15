using QuanLyTuyenSinh.Data;
using QuanLyTuyenSinh.Forms;
using QuanLyTuyenSinh.Services;

namespace QuanLyTuyenSinh;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        if (!Db.KiemTraKetNoi(out string thongBao))
        {
            MessageBox.Show(thongBao, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        while (true)
        {
            using (var dangNhap = new FormDangNhap())
            {
                if (dangNhap.ShowDialog() != DialogResult.OK) break;
            }

            var main = new FormMain();
            Application.Run(main);

            if (!main.DangXuat) break;
            PhienDangNhap.DangXuat();
        }
    }
}