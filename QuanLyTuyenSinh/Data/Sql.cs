using Npgsql;
using NpgsqlTypes;

namespace QuanLyTuyenSinh.Data;

/// <summary>Hàm hỗ trợ tạo tham số cho câu lệnh SQL.</summary>
public static class Sql
{
    public static NpgsqlParameter Ngay(string ten, DateTime giaTri) =>
        new(ten, NpgsqlDbType.Date) { Value = giaTri.Date };

    public static NpgsqlParameter NgayNull(string ten, DateTime? giaTri) =>
        new(ten, NpgsqlDbType.Date) { Value = giaTri.HasValue ? giaTri.Value.Date : DBNull.Value };

    public static NpgsqlParameter Chuoi(string ten, string? giaTri) =>
        new(ten, NpgsqlDbType.Varchar) { Value = (object?)giaTri ?? DBNull.Value };

    public static NpgsqlParameter So(string ten, int? giaTri) =>
        new(ten, NpgsqlDbType.Integer) { Value = giaTri.HasValue ? giaTri.Value : DBNull.Value };
}
