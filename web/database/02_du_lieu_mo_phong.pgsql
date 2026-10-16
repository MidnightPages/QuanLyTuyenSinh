-- =====================================================================
-- HỆ THỐNG QUẢN LÝ TUYỂN SINH TRUNG TÂM - PostgreSQL
-- File 2/2: Dữ liệu mô phỏng (chạy SAU 01_tao_bang.sql)
-- Giả định thời điểm hiện tại: 12/10/2026
-- Tài khoản mẫu:  admin / Admin@123   |   nv.lan, nv.hung, nv.mai, nv.nam / NhanVien@123
--                 nv.thu là tài khoản Đã khóa
-- Mật khẩu được băm bằng bcrypt qua extension pgcrypto.
-- =====================================================================
CREATE EXTENSION IF NOT EXISTS pgcrypto;

BEGIN;

-- Bảng 1. TaiKhoan
INSERT INTO TaiKhoan (MaTaiKhoan, TenDangNhap, MatKhauHash, VaiTro, TrangThai) VALUES
  (1, 'admin', crypt('Admin@123', gen_salt('bf')), 'Quản trị viên', 'Hoạt động'),
  (2, 'nv.lan', crypt('NhanVien@123', gen_salt('bf')), 'Nhân viên', 'Hoạt động'),
  (3, 'nv.hung', crypt('NhanVien@123', gen_salt('bf')), 'Nhân viên', 'Hoạt động'),
  (4, 'nv.mai', crypt('NhanVien@123', gen_salt('bf')), 'Nhân viên', 'Hoạt động'),
  (5, 'nv.nam', crypt('NhanVien@123', gen_salt('bf')), 'Nhân viên', 'Hoạt động'),
  (6, 'nv.thu', crypt('NhanVien@123', gen_salt('bf')), 'Nhân viên', 'Đã khóa');

-- Bảng 2. NhanVien
INSERT INTO NhanVien (MaNhanVien, MaTaiKhoan, HoTen, NgaySinh, GioiTinh, SoDienThoai) VALUES
  (1, 1, 'Trần Quốc Bảo', '1982-03-14', 'Nam', '0912000001'),
  (2, 2, 'Lê Thị Lan', '1990-07-21', 'Nữ', '0912000002'),
  (3, 3, 'Phạm Văn Hùng', '1988-11-05', 'Nam', '0912000003'),
  (4, 4, 'Nguyễn Thị Mai', '1993-02-18', 'Nữ', '0912000004'),
  (5, 5, 'Đặng Hoàng Nam', '1995-09-30', 'Nam', '0912000005'),
  (6, 6, 'Vũ Thị Thu', '1991-05-09', 'Nữ', '0912000006');

-- Bảng 3. DotTuyenSinh
INSERT INTO DotTuyenSinh (MaDot, TenDot, NgayBatDau, NgayKetThuc, TrangThai, MoTa) VALUES
  (1, 'Đợt tuyển sinh 1', '2026-04-01', '2026-06-30', 'Đã kết thúc', 'Đợt tuyển sinh đầu năm 2026'),
  (2, 'Đợt tuyển sinh 2', '2026-06-01', '2026-08-15', 'Đã kết thúc', 'Các khóa học hè cho học sinh, sinh viên'),
  (3, 'Đợt tuyển sinh 3', '2026-10-01', '2026-12-15', 'Đang tuyển sinh', 'Đợt tuyển sinh cuối năm 2026'),
  (4, 'Đợt tuyển sinh 4', '2027-01-05', '2027-03-20', 'Sắp diễn ra', 'Đợt tuyển sinh đầu năm 2027'),
  (5, 'Đợt tuyển sinh 5', '2026-01-05', '2026-01-31', 'Đã ngừng', 'Đợt thử nghiệm, đã ngừng và chưa có hồ sơ');

-- Bảng 4. KhoaHoc
INSERT INTO KhoaHoc (MaKhoaHoc, TenKhoaHoc, HocPhi, ThoiLuong, TrangThai) VALUES
  (1, 'Khóa học A', 3500000, '3 tháng (36 buổi)', 'Đang mở'),
  (2, 'Khóa học B', 9800000, '4 tháng (48 buổi)', 'Đang mở'),
  (3, 'Khóa học C', 4200000, '2 tháng (24 buổi)', 'Đang mở'),
  (4, 'Khóa học D', 3900000, '2 tháng (24 buổi)', 'Đang mở'),
  (5, 'Khóa học E', 2800000, '1,5 tháng (18 buổi)', 'Đang mở'),
  (6, 'Khóa học F', 3600000, '3 tháng (30 buổi)', 'Đang mở'),
  (7, 'Khóa học G', 5200000, '3 tháng (36 buổi)', 'Đang mở'),
  (8, 'Khóa học H', 4500000, '4 tháng (40 buổi)', 'Đã ngừng');

-- Bảng 5. DotKhoaHoc (khóa học được mở trong từng đợt)
INSERT INTO DotKhoaHoc (MaDotKhoaHoc, MaDot, MaKhoaHoc, ChiTieu) VALUES
  (1,  1, 1, 30),
  (2,  1, 2, 25),
  (3,  1, 3, 40),
  (4,  1, 5, 20),
  (5,  1, 8, 15),
  (6,  2, 1, 25),
  (7,  2, 3, 35),
  (8,  2, 4, 20),
  (9,  2, 7, 30),
  (10, 3, 1, 30),
  (11, 3, 2, 25),
  (12, 3, 3, 40),
  (13, 3, 4, 20),
  (14, 3, 5, 25),
  (15, 3, 6, 15),
  (16, 4, 2, 20),
  (17, 4, 3, 30),
  (18, 4, 4, 25),
  (19, 4, 5, 20),
  (20, 4, 6, 15);

-- Bảng 6. PhanCongTuyenSinh (một khóa trong một đợt có thể có nhiều nhân viên)
INSERT INTO PhanCongTuyenSinh (MaPhanCong, MaNhanVien, MaDotKhoaHoc) VALUES
  (1, 2, 1),
  (2, 3, 2),
  (3, 4, 3),
  (4, 2, 4),
  (5, 5, 4),
  (6, 3, 5),
  (7, 2, 6),
  (8, 4, 6),
  (9, 4, 7),
  (10, 5, 8),
  (11, 3, 9),
  (12, 2, 10),
  (13, 4, 10),
  (14, 3, 11),
  (15, 2, 11),
  (16, 4, 12),
  (17, 5, 12),
  (18, 5, 13),
  (19, 2, 14),
  (20, 3, 15),
  (21, 3, 16),
  (22, 5, 16),
  (23, 2, 17),
  (24, 3, 18),
  (25, 4, 19),
  (26, 5, 20);

-- Bảng 7. HoSoDangKy
INSERT INTO HoSoDangKy (MaHoSo, MaDotKhoaHoc, HoTen, NgaySinh, SoDienThoai, Email, DiaChi, NgayDangKy, TrangThaiHoSo, MaNhanVienXacNhan, NgayXacNhan) VALUES
  (1, 1, 'Trần Thanh Tâm', '1988-04-20', '0968695681', 'tran.thanh.tam83@example.com', '45 Lê Lợi, Vĩnh Yên, Vĩnh Phúc', '2026-06-11 14:50:36', 'Đã duyệt', 2, '2026-06-16 18:05:36'),
  (2, 1, 'Trần Anh An', '2006-06-07', '0991963043', 'tran.anh.an63@example.com', '67 Hùng Vương, Việt Trì, Phú Thọ', '2026-05-21 12:22:59', 'Đã duyệt', 2, '2026-05-25 17:54:59'),
  (3, 2, 'Hoàng Ngọc Quân', '2007-12-19', '0918909714', 'hoang.ngoc.quan83@example.com', '33 Quang Trung, Hà Đông, Hà Nội', '2026-05-10 08:54:45', 'Đã duyệt', 3, '2026-05-13 12:21:45'),
  (4, 2, 'Đặng Thu Sơn', '1993-07-19', '0953438575', 'dang.thu.son68@example.com', '12 Nguyễn Trãi, Thanh Xuân, Hà Nội', '2026-06-01 16:33:51', 'Đã duyệt', 3, '2026-06-06 18:22:51'),
  (5, 3, 'Vũ Minh Sơn', '2005-12-15', '0930726097', 'vu.minh.son16@example.com', '14 Lê Duẩn, Hải Châu, Đà Nẵng', '2026-05-31 19:59:34', 'Đã hủy', 4, '2026-06-05 23:41:34'),
  (6, 3, 'Phạm Ngọc Khoa', '1989-11-20', '0901245123', 'pham.ngoc.khoa5@example.com', '90 Đường 2/9, Quận 1, TP. Hồ Chí Minh', '2026-05-29 20:33:59', 'Đã duyệt', 4, '2026-06-01 21:49:59'),
  (7, 4, 'Đỗ Văn Linh', '1988-08-23', '0942500997', 'do.van.linh59@example.com', '23 Nguyễn Huệ, Phúc Yên, Vĩnh Phúc', '2026-06-05 12:28:59', 'Chờ xử lý', NULL, NULL),
  (8, 4, 'Huỳnh Thị Hiếu', '1999-01-03', '0955205206', 'huynh.thi.hieu19@example.com', '12 Nguyễn Trãi, Thanh Xuân, Hà Nội', '2026-04-01 15:37:34', 'Đã duyệt', 2, '2026-04-06 16:52:34'),
  (9, 5, 'Lê Văn Long', '2003-08-23', '0989198595', 'le.van.long75@example.com', '5 Kim Mã, Ba Đình, Hà Nội', '2026-04-18 16:14:30', 'Đã duyệt', 3, '2026-04-23 21:46:30'),
  (10, 5, 'Dương Thu Linh', '1997-03-17', '0968142594', 'duong.thu.linh53@example.com', '67 Hùng Vương, Việt Trì, Phú Thọ', '2026-04-26 14:00:06', 'Đã duyệt', 3, '2026-04-27 14:53:06'),
  (11, 6, 'Vũ Thanh Đạt', '1995-02-16', '0940758128', 'vu.thanh.dat58@example.com', '33 Quang Trung, Hà Đông, Hà Nội', '2026-07-31 15:36:39', 'Đã duyệt', 2, '2026-08-02 20:09:39'),
  (12, 6, 'Phạm Đức Hạnh', '1997-01-07', '0909329269', 'pham.duc.hanh71@example.com', '12 Nguyễn Trãi, Thanh Xuân, Hà Nội', '2026-07-12 10:02:41', 'Đã duyệt', 2, '2026-07-16 15:14:41'),
  (13, 7, 'Dương Gia Giang', '1990-07-09', '0921527272', 'duong.gia.giang85@example.com', '23 Nguyễn Huệ, Phúc Yên, Vĩnh Phúc', '2026-06-28 16:26:55', 'Đã duyệt', 4, '2026-07-02 18:37:55'),
  (14, 7, 'Lý Hữu Linh', '1995-09-16', '0962773682', 'ly.huu.linh23@example.com', '45 Lê Lợi, Vĩnh Yên, Vĩnh Phúc', '2026-06-29 09:33:50', 'Đã duyệt', 4, '2026-06-30 10:47:50'),
  (15, 8, 'Đặng Đức Hà', '1990-06-18', '0903648678', 'dang.duc.ha46@example.com', '33 Quang Trung, Hà Đông, Hà Nội', '2026-07-14 17:50:34', 'Đã duyệt', 5, '2026-07-15 22:35:34'),
  (16, 8, 'Bùi Ngọc Đạt', '1988-05-04', '0974589376', 'bui.ngoc.dat17@example.com', '45 Lê Lợi, Vĩnh Yên, Vĩnh Phúc', '2026-06-28 10:06:43', 'Đã duyệt', 5, '2026-07-01 15:57:43'),
  (17, 9, 'Lý Thị Linh', '1993-05-03', '0942225137', 'ly.thi.linh21@example.com', '12 Nguyễn Trãi, Thanh Xuân, Hà Nội', '2026-06-01 14:55:57', 'Đã duyệt', 3, '2026-06-05 14:58:57'),
  (18, 9, 'Đỗ Gia Tuấn', '1999-10-21', '0947017385', 'do.gia.tuan41@example.com', '5 Kim Mã, Ba Đình, Hà Nội', '2026-07-12 19:39:02', 'Đã duyệt', 3, '2026-07-15 23:52:02'),
  (19, 10, 'Đặng Đức Khoa', '1996-01-24', '0952217045', 'dang.duc.khoa38@example.com', '45 Lê Lợi, Vĩnh Yên, Vĩnh Phúc', '2026-10-12 00:00:00', 'Chờ xử lý', NULL, NULL),
  (20, 10, 'Dương Hữu Long', '2002-06-07', '0978598717', 'duong.huu.long3@example.com', '14 Lê Duẩn, Hải Châu, Đà Nẵng', '2026-10-09 08:46:07', 'Chờ xử lý', NULL, NULL),
  (21, 10, 'Bùi Đức Yến', '1998-10-05', '0940566123', 'bui.duc.yen4@example.com', '8 Trần Phú, Việt Trì, Phú Thọ', '2026-10-06 14:24:24', 'Đã hủy', 2, '2026-10-10 19:38:24'),
  (22, 10, 'Đỗ Khánh Trang', '1997-05-26', '0991771658', 'do.khanh.trang72@example.com', '67 Hùng Vương, Việt Trì, Phú Thọ', '2026-10-03 11:01:01', 'Đã duyệt', 4, '2026-10-08 14:27:01'),
  (23, 11, 'Đỗ Thu Châu', '1986-11-28', '0924065539', 'do.thu.chau71@example.com', '101 Hai Bà Trưng, Hoàn Kiếm, Hà Nội', '2026-10-09 21:16:21', 'Đã duyệt', 2, '2026-10-11 03:09:21'),
  (24, 11, 'Nguyễn Quốc Đạt', '2008-07-23', '0968265854', 'nguyen.quoc.dat20@example.com', '90 Đường 2/9, Quận 1, TP. Hồ Chí Minh', '2026-10-06 20:14:35', 'Đã duyệt', 2, '2026-10-09 21:37:35'),
  (25, 11, 'Dương Đức Tuấn', '1990-11-14', '0941901923', 'duong.duc.tuan25@example.com', '8 Trần Phú, Việt Trì, Phú Thọ', '2026-10-03 15:57:00', 'Đã hủy', 2, '2026-10-08 21:23:00'),
  (26, 11, 'Hoàng Thanh Trang', '1989-12-24', '0998114271', 'hoang.thanh.trang34@example.com', '14 Lê Duẩn, Hải Châu, Đà Nẵng', '2026-10-02 08:34:13', 'Đã duyệt', 2, '2026-10-07 08:59:13'),
  (27, 12, 'Đặng Thị Châu', '1997-06-18', '0919044466', 'dang.thi.chau94@example.com', '67 Hùng Vương, Việt Trì, Phú Thọ', '2026-10-05 12:02:47', 'Đã duyệt', 4, '2026-10-07 14:20:47'),
  (28, 12, 'Phan Quốc Kiên', '2004-11-16', '0984532675', 'phan.quoc.kien2@example.com', '14 Lê Duẩn, Hải Châu, Đà Nẵng', '2026-10-07 13:51:49', 'Chờ xử lý', NULL, NULL),
  (29, 12, 'Lê Văn Dũng', '2007-11-25', '0969121083', 'le.van.dung86@example.com', '33 Quang Trung, Hà Đông, Hà Nội', '2026-10-01 21:23:04', 'Đã duyệt', 5, '2026-10-04 22:57:04'),
  (30, 13, 'Lê Thị Long', '2008-02-13', '0965037186', 'le.thi.long14@example.com', '14 Lê Duẩn, Hải Châu, Đà Nẵng', '2026-10-05 17:19:41', 'Đã duyệt', 5, '2026-10-08 21:17:41'),
  (31, 13, 'Lý Thanh Đạt', '1996-02-03', '0961194403', 'ly.thanh.dat75@example.com', '5 Kim Mã, Ba Đình, Hà Nội', '2026-10-02 20:31:49', 'Đã duyệt', 5, '2026-10-06 01:45:49'),
  (32, 13, 'Huỳnh Khánh Đạt', '1995-03-07', '0966195414', 'huynh.khanh.dat52@example.com', '5 Kim Mã, Ba Đình, Hà Nội', '2026-10-08 11:55:44', 'Đã hủy', 5, '2026-10-11 15:48:44'),
  (33, 14, 'Lê Anh Kiên', '2008-03-14', '0976043714', 'le.anh.kien85@example.com', '23 Nguyễn Huệ, Phúc Yên, Vĩnh Phúc', '2026-10-05 13:53:07', 'Đã duyệt', 2, '2026-10-08 17:09:07'),
  (34, 14, 'Huỳnh Minh Trang', '1994-10-15', '0916540483', 'huynh.minh.trang35@example.com', '90 Đường 2/9, Quận 1, TP. Hồ Chí Minh', '2026-10-11 14:25:01', 'Chờ xử lý', NULL, NULL),
  (35, 14, 'Phan Thanh Yến', '1997-12-06', '0944351640', 'phan.thanh.yen8@example.com', '5 Kim Mã, Ba Đình, Hà Nội', '2026-10-01 12:35:44', 'Đã duyệt', 2, '2026-10-03 15:12:44'),
  (36, 15, 'Lý Anh Long', '1992-11-04', '0901577597', 'ly.anh.long5@example.com', '67 Hùng Vương, Việt Trì, Phú Thọ', '2026-10-11 21:17:20', 'Chờ xử lý', NULL, NULL),
  (37, 15, 'Đặng Khánh Hiếu', '1985-02-05', '0972338150', 'dang.khanh.hieu99@example.com', '14 Lê Duẩn, Hải Châu, Đà Nẵng', '2026-10-06 11:29:13', 'Chờ xử lý', NULL, NULL),
  (38, 15, 'Trần Văn Khoa', '1990-09-24', '0956309126', 'tran.van.khoa6@example.com', '23 Nguyễn Huệ, Phúc Yên, Vĩnh Phúc', '2026-10-09 11:58:30', 'Chờ xử lý', NULL, NULL),
  (39, 16, 'Huỳnh Ngọc Bình', '1989-01-16', '0986382176', 'huynh.ngoc.binh63@example.com', '5 Kim Mã, Ba Đình, Hà Nội', '2026-10-06 12:53:48', 'Đã duyệt', 5, '2026-10-08 15:10:48'),
  (40, 16, 'Phạm Thu Bình', '2008-12-21', '0955144515', 'pham.thu.binh9@example.com', '14 Lê Duẩn, Hải Châu, Đà Nẵng', '2026-10-11 16:43:34', 'Chờ xử lý', NULL, NULL),
  (41, 16, 'Huỳnh Thanh Hà', '1990-05-28', '0910478103', 'huynh.thanh.ha72@example.com', '101 Hai Bà Trưng, Hoàn Kiếm, Hà Nội', '2026-10-09 16:55:24', 'Chờ xử lý', NULL, NULL);

-- Đồng bộ lại bộ đếm tự tăng sau khi chèn mã thủ công
SELECT setval(pg_get_serial_sequence('TaiKhoan', 'mataikhoan'), (SELECT MAX(mataikhoan) FROM TaiKhoan));
SELECT setval(pg_get_serial_sequence('NhanVien', 'manhanvien'), (SELECT MAX(manhanvien) FROM NhanVien));
SELECT setval(pg_get_serial_sequence('DotTuyenSinh', 'madot'), (SELECT MAX(madot) FROM DotTuyenSinh));
SELECT setval(pg_get_serial_sequence('KhoaHoc', 'makhoahoc'), (SELECT MAX(makhoahoc) FROM KhoaHoc));
SELECT setval(pg_get_serial_sequence('DotKhoaHoc', 'madotkhoahoc'), (SELECT MAX(madotkhoahoc) FROM DotKhoaHoc));
SELECT setval(pg_get_serial_sequence('PhanCongTuyenSinh', 'maphancong'), (SELECT MAX(maphancong) FROM PhanCongTuyenSinh));
SELECT setval(pg_get_serial_sequence('HoSoDangKy', 'mahoso'), (SELECT MAX(mahoso) FROM HoSoDangKy));

COMMIT;

-- Truy vấn kiểm tra nhanh (bỏ comment để chạy):
-- SELECT d.TenDot, k.TenKhoaHoc, h.TrangThaiHoSo, COUNT(*) AS SoHoSo
-- FROM HoSoDangKy h
-- JOIN DotKhoaHoc dk ON dk.MaDotKhoaHoc = h.MaDotKhoaHoc
-- JOIN DotTuyenSinh d ON d.MaDot = dk.MaDot
-- JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
-- GROUP BY d.TenDot, k.TenKhoaHoc, h.TrangThaiHoSo
-- ORDER BY d.TenDot, k.TenKhoaHoc;