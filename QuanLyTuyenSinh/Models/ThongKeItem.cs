using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Models;

/// <summary>Số liệu hồ sơ và chỉ tiêu của một khóa học trong một đợt.</summary>
public class ThongKeItem
{
    public int MaDotKhoaHoc { get; set; }
    public string TenDot { get; set; } = "";
    public string TenKhoaHoc { get; set; } = "";
    public int ChiTieu { get; set; }      // 0 = chưa đặt chỉ tiêu
    public int Tong { get; set; }
    public int ChoXuLy { get; set; }
    public int DaDuyet { get; set; }
    public int DaHuy { get; set; }

    public string TyLeDuyet => Tong == 0 ? "-" : $"{DaDuyet * 100.0 / Tong:0.#}%";

    // Mức đạt chỉ tiêu = số hồ sơ Đã duyệt / chỉ tiêu (có thể vượt 100%)
    public double? DatChiTieu => ChiTieu > 0 ? (double)DaDuyet / ChiTieu : null;
    public string TyLeDatChiTieu => DatChiTieu is double v ? $"{v * 100:0.#}%" : "-";
}