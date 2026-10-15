using System;
using System.Collections.Generic;
using System.Text;

using Npgsql;
using QuanLyTuyenSinh.Models;

namespace QuanLyTuyenSinh.Data;

public static class ThongKeRepo
{
    /// <summary>
    /// Thống kê hồ sơ theo từng khóa học trong từng đợt (kể cả khóa chưa có hồ sơ nào).
    /// maNhanVienPhamVi = null: tất cả (quản trị viên); có giá trị: chỉ các khóa nhân viên đó phụ trách.
    /// </summary>
    public static List<ThongKeItem> LayThongKe(int? maDot, int? maKhoaHoc, int? maNhanVienPhamVi)
    {
        const string sql = @"
            SELECT dk.MaDotKhoaHoc, d.TenDot, k.TenKhoaHoc,
                   COUNT(h.MaHoSo) AS Tong,
                   COUNT(h.MaHoSo) FILTER (WHERE h.TrangThaiHoSo = 'Chờ xử lý') AS ChoXuLy,
                   COUNT(h.MaHoSo) FILTER (WHERE h.TrangThaiHoSo = 'Đã duyệt') AS DaDuyet,
                   COUNT(h.MaHoSo) FILTER (WHERE h.TrangThaiHoSo = 'Đã hủy') AS DaHuy
            FROM DotKhoaHoc dk
            JOIN DotTuyenSinh d ON d.MaDot = dk.MaDot
            JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
            LEFT JOIN HoSoDangKy h ON h.MaDotKhoaHoc = dk.MaDotKhoaHoc
            WHERE (@dot IS NULL OR d.MaDot = @dot)
              AND (@kh IS NULL OR k.MaKhoaHoc = @kh)
              AND (@nv IS NULL OR EXISTS (
                    SELECT 1 FROM PhanCongTuyenSinh pc
                    WHERE pc.MaNhanVien = @nv AND pc.MaDotKhoaHoc = dk.MaDotKhoaHoc))
            GROUP BY dk.MaDotKhoaHoc, d.MaDot, d.TenDot, d.NgayBatDau, k.TenKhoaHoc
            ORDER BY d.NgayBatDau DESC, d.MaDot DESC, k.TenKhoaHoc";

        var ds = new List<ThongKeItem>();
        using var conn = Db.TaoKetNoi();
        conn.Open();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.Add(Sql.So("dot", maDot));
        cmd.Parameters.Add(Sql.So("kh", maKhoaHoc));
        cmd.Parameters.Add(Sql.So("nv", maNhanVienPhamVi));
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            ds.Add(new ThongKeItem
            {
                MaDotKhoaHoc = rd.GetInt32(0),
                TenDot = rd.GetString(1),
                TenKhoaHoc = rd.GetString(2),
                Tong = (int)rd.GetInt64(3),
                ChoXuLy = (int)rd.GetInt64(4),
                DaDuyet = (int)rd.GetInt64(5),
                DaHuy = (int)rd.GetInt64(6)
            });
        }
        return ds;
    }
}