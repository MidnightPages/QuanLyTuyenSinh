# Cai dat: pip install "psycopg[binary]"
# Cau hinh ket noi PostgreSQL bang cac bien moi truong:
# PGHOST, PGPORT, PGDATABASE, PGUSER, PGPASSWORD
# Chay: python app.py

import json
import logging
import os
from datetime import date
from http.server import SimpleHTTPRequestHandler, ThreadingHTTPServer

import psycopg
from psycopg.errors import UniqueViolation
from psycopg.rows import dict_row

logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s")

MAX_BODY = 100_000  # so byte toi da cho moi yeu cau

# Chi nhan dang ky khi dot dang "Dang tuyen sinh" va khoa hoc dang "Dang mo".
# Kiem tra ngay trong cau INSERT nen khong the lach bang cach gui thang yeu cau len may chu.
SQL_DANG_KY = """
    INSERT INTO HoSoDangKy
        (MaDotKhoaHoc, HoTen, NgaySinh, SoDienThoai, Email, DiaChi)
    SELECT dk.MaDotKhoaHoc, %s::varchar, %s::date, %s::varchar, %s::varchar, %s::varchar
    FROM DotKhoaHoc dk
    JOIN DotTuyenSinh t ON t.MaDot = dk.MaDot
    JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
    WHERE dk.MaDotKhoaHoc = %s
      AND t.TrangThai = 'Đang tuyển sinh'
      AND k.TrangThai = 'Đang mở'
    RETURNING MaHoSo AS "maHoSo"
"""


def ket_noi():
    """Ket noi den PostgreSQL theo cau hinh bien moi truong."""
    return psycopg.connect(
        host=os.getenv("PGHOST", "localhost"),
        port=os.getenv("PGPORT", "5432"),
        dbname=os.getenv("PGDATABASE", "tuyensinh"),
        user=os.getenv("PGUSER", "postgres"),
        password=os.getenv("PGPASSWORD", "thuynga"),
        row_factory=dict_row,
    )


def lam_sach(gia_tri):
    """Chi nhan chuoi, cat khoang trang hai dau; khong phai chuoi thi coi nhu rong."""
    return gia_tri.strip() if isinstance(gia_tri, str) else ""


def kiem_tra(b):
    """Kiem tra du lieu dang ky. Tra ve (du_lieu, thong_bao_loi)."""
    if not isinstance(b, dict):
        return None, "Dữ liệu gửi lên không hợp lệ."

    try:
        ma_dot_khoa_hoc = int(b.get("maDotKhoaHoc"))
    except (TypeError, ValueError):
        return None, "Vui lòng chọn khóa học."

    ho_ten = lam_sach(b.get("hoTen"))
    so_dien_thoai = lam_sach(b.get("soDienThoai"))
    email = lam_sach(b.get("email"))
    dia_chi = lam_sach(b.get("diaChi")) or None

    if not ho_ten:
        return None, "Vui lòng nhập họ tên."
    if not so_dien_thoai:
        return None, "Vui lòng nhập số điện thoại."
    if not email:
        return None, "Vui lòng nhập email."

    # Do dai toi da theo cot trong CSDL
    if len(ho_ten) > 100:
        return None, "Họ tên quá dài (tối đa 100 ký tự)."
    if len(so_dien_thoai) > 15:
        return None, "Số điện thoại quá dài (tối đa 15 ký tự)."
    if len(email) > 100:
        return None, "Email quá dài (tối đa 100 ký tự)."
    if dia_chi and len(dia_chi) > 255:
        return None, "Địa chỉ quá dài (tối đa 255 ký tự)."

    ngay_sinh = None
    ngay_sinh_tho = lam_sach(b.get("ngaySinh"))
    if ngay_sinh_tho:
        try:
            ngay_sinh = date.fromisoformat(ngay_sinh_tho)
        except ValueError:
            return None, "Ngày sinh không hợp lệ."
        if ngay_sinh > date.today():
            return None, "Ngày sinh không được ở tương lai."

    return {
        "ma_dot_khoa_hoc": ma_dot_khoa_hoc,
        "ho_ten": ho_ten,
        "ngay_sinh": ngay_sinh,
        "so_dien_thoai": so_dien_thoai,
        "email": email,
        "dia_chi": dia_chi,
    }, None


class Handler(SimpleHTTPRequestHandler):
    def __init__(self, *a, **k):
        super().__init__(*a, directory="public", **k)

    def tra_json(self, ma, data):
        body = json.dumps(data, ensure_ascii=False, default=str).encode("utf-8")
        self.send_response(ma)
        self.send_header("Content-Type", "application/json; charset=utf-8")
        self.send_header("Content-Length", str(len(body)))
        self.end_headers()
        self.wfile.write(body)

    # Lay danh sach khoa hoc cho o chon (chi dot "Dang tuyen sinh", khoa "Dang mo")
    def do_GET(self):
        if self.path == "/api/khoa-hoc":
            try:
                with ket_noi() as db:
                    rows = db.execute("""
                        SELECT dk.MaDotKhoaHoc AS ma,
                               k.TenKhoaHoc AS khoa,
                               t.TenDot AS dot
                        FROM DotKhoaHoc dk
                        JOIN DotTuyenSinh t ON t.MaDot = dk.MaDot
                        JOIN KhoaHoc k ON k.MaKhoaHoc = dk.MaKhoaHoc
                        WHERE t.TrangThai = 'Đang tuyển sinh'
                          AND k.TrangThai = 'Đang mở'
                        ORDER BY k.TenKhoaHoc
                    """).fetchall()
                return self.tra_json(200, rows)
            except psycopg.Error:
                logging.exception("Loi khi tai danh sach khoa hoc")
                return self.tra_json(500, {
                    "ok": False,
                    "message": "Không thể tải danh sách khóa học. Vui lòng thử lại sau."
                })

        super().do_GET()

    # Luu ho so dang ky vao PostgreSQL
    def do_POST(self):
        if self.path != "/api/dang-ky":
            return self.tra_json(404, {
                "ok": False,
                "message": "Không tìm thấy."
            })

        try:
            do_dai = int(self.headers.get("Content-Length", "0"))
        except ValueError:
            do_dai = 0
        if do_dai > MAX_BODY:
            return self.tra_json(413, {
                "ok": False,
                "message": "Dữ liệu gửi lên quá lớn."
            })

        try:
            b = json.loads(self.rfile.read(do_dai) or b"{}")
        except ValueError:
            return self.tra_json(400, {
                "ok": False,
                "message": "Dữ liệu gửi lên không phải JSON hợp lệ."
            })

        du_lieu, loi = kiem_tra(b)
        if loi:
            return self.tra_json(400, {"ok": False, "message": loi})

        try:
            with ket_noi() as db:
                row = db.execute(SQL_DANG_KY, (
                    du_lieu["ho_ten"],
                    du_lieu["ngay_sinh"],
                    du_lieu["so_dien_thoai"],
                    du_lieu["email"],
                    du_lieu["dia_chi"],
                    du_lieu["ma_dot_khoa_hoc"],
                )).fetchone()
        except UniqueViolation:
            return self.tra_json(409, {
                "ok": False,
                "message": "Số điện thoại hoặc email đã đăng ký khóa học này."
            })
        except psycopg.Error:
            logging.exception("Loi khi luu ho so dang ky")
            return self.tra_json(500, {
                "ok": False,
                "message": "Hệ thống đang gặp sự cố. Vui lòng thử lại sau."
            })

        if row is None:
            # Khong co dong nao duoc them: dot da ngung / khong con dang tuyen sinh, hoac khoa hoc khong mo
            return self.tra_json(400, {
                "ok": False,
                "message": "Khóa học hoặc đợt tuyển sinh này hiện không mở đăng ký."
            })

        return self.tra_json(201, {
            "ok": True,
            "maHoSo": row["maHoSo"],
            "message": "Đăng ký thành công."
        })


if __name__ == "__main__":
    print("Mở http://localhost:3000")
    print(
        "PostgreSQL: "
        f"{os.getenv('PGHOST', 'localhost')}:"
        f"{os.getenv('PGPORT', '5432')}/"
        f"{os.getenv('PGDATABASE', 'tuyensinh')}"
    )
    ThreadingHTTPServer(("", 3000), Handler).serve_forever()