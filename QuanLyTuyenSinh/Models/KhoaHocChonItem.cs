using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Models;

/// <summary>Một khóa học trong bảng tích chọn của form Sửa đợt (kèm chỉ tiêu).</summary>
public class KhoaHocChonItem
{
    public int MaKhoaHoc { get; set; }
    public string TenKhoaHoc { get; set; } = "";
    public bool CoTrongDot { get; set; }   // trạng thái ban đầu: khóa đang thuộc đợt
    public bool CoDuLieu { get; set; }     // đã có hồ sơ hoặc phân công trong khóa-đợt này (không gỡ được)
    public bool Chon { get; set; }         // đang được tích trên giao diện
    public int ChiTieu { get; set; }       // 0 = chưa đặt chỉ tiêu

    public string GhiChu => CoDuLieu ? "Đã có hồ sơ hoặc phân công" : "";
}