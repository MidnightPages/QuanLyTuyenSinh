# Cai dat: pip install "psycopg[binary]"
# Cau hinh ket noi PostgreSQL bang cac bien moi truong:
# PGHOST, PGPORT, PGDATABASE, PGUSER, PGPASSWORD
# Chay: python app.py

import json
import os
from http.server import SimpleHTTPRequestHandler, ThreadingHTTPServer

import psycopg
from psycopg.rows import dict_row


def ket_noi():
    """Ket noi den PostgreSQL theo cau hinh bien moi truong."""
    return psycopg.connect(
        host=os.getenv("PGHOST", "localhost"),
        port=os.getenv("PGPORT", "5432"),
        dbname=os.getenv("PGDATABASE", "tuyensinh"),
        user=os.getenv("PGUSER", "postgres"),
        password=os.getenv("PGPASSWORD", "matkhaucuaban"),
        row_factory=dict_row,
    )


class Handler(SimpleHTTPRequestHandler):
    def __init__(self, *a, **k):
        super().__init__(*a, directory="public", **k)

    def tra_json(self, ma, data):
        body = json.dumps(data, ensure_ascii=False).encode("utf-8")
        self.send_response(ma)
        self.send_header("Content-Type", "application/json; charset=utf-8")
        self.send_header("Content-Length", str(len(body)))
        self.end_headers()
        self.wfile.write(body)

    # Lay danh sach khoa hoc cho o chon
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
            except psycopg.Error as e:
                return self.tra_json(500, {
                    "ok": False,
                    "message": "Không thể tải danh sách khóa học: " + str(e)
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
            b = json.loads(
                self.rfile.read(int(self.headers.get("Content-Length", "0"))) or b"{}"
            )
        except (ValueError, json.JSONDecodeError):
            return self.tra_json(400, {
                "ok": False,
                "message": "Dữ liệu gửi lên không phải JSON hợp lệ."
            })

        try:
            with ket_noi() as db:
                row = db.execute("""
                    INSERT INTO HoSoDangKy
                        (MaDotKhoaHoc, HoTen, NgaySinh, SoDienThoai,
                         Email, DiaChi, NgayDangKy)
                    VALUES (%s, %s, %s, %s, %s, %s, CURRENT_TIMESTAMP)
                    RETURNING MaHoSo AS "maHoSo"
                """, (
                    b.get("maDotKhoaHoc"),
                    b.get("hoTen"),
                    b.get("ngaySinh"),
                    b.get("soDienThoai"),
                    b.get("email"),
                    b.get("diaChi"),
                )).fetchone()

            return self.tra_json(201, {
                "ok": True,
                "maHoSo": row["maHoSo"],
                "message": "Đăng ký thành công."
            })

        except psycopg.IntegrityError as e:
            # SQLSTATE 23505 = unique_violation
            trung = e.sqlstate == "23505"
            return self.tra_json(409 if trung else 400, {
                "ok": False,
                "message": (
                    "Số điện thoại hoặc email đã đăng ký khóa học này."
                    if trung else "Dữ liệu không hợp lệ: " + str(e)
                )
            })
        except psycopg.Error as e:
            return self.tra_json(500, {
                "ok": False,
                "message": "Lỗi cơ sở dữ liệu: " + str(e)
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
