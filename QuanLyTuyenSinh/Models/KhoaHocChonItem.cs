using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Models;

/// <summary>Một khóa học trong danh sách hộp kiểm của form Sửa đợt.</summary>
public class KhoaHocChonItem
{
    public int MaKhoaHoc { get; set; }
    public string TenKhoaHoc { get; set; } = "";
    public bool CoTrongDot { get; set; }   // khóa này đang thuộc đợt
    public bool CoDuLieu { get; set; }     // đã có hồ sơ hoặc phân công trong khóa-đợt này (không gỡ được)

    public override string ToString() =>
        TenKhoaHoc + (CoDuLieu ? "  -  đã có hồ sơ hoặc phân công" : "");
}