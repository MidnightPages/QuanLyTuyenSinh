using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Models;

/// <summary>Số liệu hồ sơ của một khóa học trong một đợt.</summary>
public class ThongKeItem
{
    public int MaDotKhoaHoc { get; set; }
    public string TenDot { get; set; } = "";
    public string TenKhoaHoc { get; set; } = "";
    public int Tong { get; set; }
    public int ChoXuLy { get; set; }
    public int DaDuyet { get; set; }
    public int DaHuy { get; set; }

    public string TyLeDuyet => Tong == 0 ? "-" : $"{DaDuyet * 100.0 / Tong:0.#}%";
}