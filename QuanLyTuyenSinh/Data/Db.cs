using Npgsql;

namespace QuanLyTuyenSinh.Data;

public static class Db
{
    private const string ConnectionString =
        "Host=localhost;Port=5432;Database=tuyensinh;Username=postgres;Password=thuynga;";

    public static NpgsqlConnection TaoKetNoi() => new NpgsqlConnection(ConnectionString);

    public static bool KiemTraKetNoi(out string thongBao)
    {
        try
        {
            using var conn = TaoKetNoi();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM HoSoDangKy", conn);
            var soHoSo = (long)cmd.ExecuteScalar()!;
            thongBao = $"Kết nối thành công. CSDL có {soHoSo} hồ sơ.";
            return true;
        }
        catch (Exception ex)
        {
            thongBao = "Không kết nối được CSDL: " + ex.Message;
            return false;
        }
    }
}