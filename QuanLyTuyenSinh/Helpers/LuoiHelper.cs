using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Helpers;

public static class LuoiHelper
{
    /// <summary>
    /// Cột có tên tenCotStt sẽ hiển thị số thứ tự dòng (1, 2, 3...), tự đánh lại khi lọc hoặc tải lại.
    /// Cột này là cột trống, không gắn với dữ liệu nào.
    /// </summary>
    public static void DanhSoThuTu(DataGridView dgv, string tenCotStt)
    {
        dgv.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgv.Columns[e.ColumnIndex].Name != tenCotStt) return;
            e.Value = (e.RowIndex + 1).ToString();   // phải là chuỗi chữ, không phải số
            e.FormattingApplied = true;
        };
    }
}