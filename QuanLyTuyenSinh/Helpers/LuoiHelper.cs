using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyTuyenSinh.Helpers;

public static class LuoiHelper
{
    /// <summary>
    /// Đặt lại các thiết lập mà trình kéo thả hay làm mất. Gọi ngay sau InitializeComponent()
    /// nên dù Designer có ghi đè, bảng vẫn đúng. Hình thức (màu, cỡ chữ, độ rộng cột) vẫn chỉnh bằng kéo thả.
    /// </summary>
    public static void CauHinhChung(DataGridView dgv)
    {
        dgv.AutoGenerateColumns = false;   // chỉ dùng các cột đã thiết kế, không tự sinh cột
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AllowUserToResizeRows = false;
        dgv.RowHeadersVisible = false;
        dgv.MultiSelect = false;
    
    }

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