using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Models
{
    public class NguoiDung
    {
        public int MaTaiKhoan { get; set; }
        public int MaNhanVien { get; set; }
        public string TenDangNhap { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string VaiTro { get; set; } = "";
    }
}
