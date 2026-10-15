# Hệ Thống Quản Lý Tuyển Sinh Trung Tâm

Hệ thống gồm **hai phần dùng chung một cơ sở dữ liệu PostgreSQL**:

|Phần|Công nghệ|Dành cho|
|-|-|-|
|Ứng dụng quản lý nội bộ (`QuanLyTuyenSinh/`)|C# WinForms (.NET 10), Npgsql, BCrypt.Net-Next, ClosedXML|Quản trị viên và nhân viên tuyển sinh|
|Website đăng ký (`web/`)|Python, HTML, CSS, JavaScript|Học viên đăng ký khóa học|

Học viên đăng ký trên website, hồ sơ được lưu vào CSDL với trạng thái **Chờ xử lý** và hiện ngay trong ứng dụng quản lý để nhân viên xử lý.

## Chức năng chính

**Quản trị viên**

* Quản lý khóa học, đợt tuyển sinh (thêm, sửa, ngừng, xóa).
* Quản lý nhân viên và tài khoản (thêm, sửa, khóa, đặt lại mật khẩu, xóa).
* Phân công nhân viên phụ trách từng khóa học trong từng đợt (một khóa có thể có nhiều nhân viên).
* Xem toàn bộ hồ sơ theo đợt và khóa học (chỉ xem, không xử lý).
* Thống kê hồ sơ, lọc theo đợt và khóa học, xuất file Excel.

**Nhân viên tuyển sinh**

* Xem hồ sơ thuộc các khóa học mình được phân công.
* Duyệt hàng loạt: tích chọn nhiều hồ sơ, đánh dấu Đã duyệt hoặc Đã hủy rồi bấm Lưu.
* Thêm hồ sơ thủ công, sửa, xóa hồ sơ.
* Sửa các đợt mình được phân công, xem thống kê trong phạm vi phụ trách.

**Quy tắc nghiệp vụ**

* Trạng thái hồ sơ: Chờ xử lý, Đã duyệt (thành công), Đã hủy (không thành công). 
* Mỗi hồ sơ chỉ do một nhân viên xác nhận (người lưu kết quả đầu tiên).
* Khi đợt tuyển sinh kết thúc, hồ sơ của đợt đó không đổi trạng thái, không sửa, không xóa được.
* Trong cùng một khóa học của một đợt, không đăng ký trùng số điện thoại hoặc email.

## Cấu trúc thư mục

```
.
├── QuanLyTuyenSinh/        # ứng dụng WinForms
│   ├── Data/               # Db.cs (kết nối CSDL) và các lớp truy vấn
│   ├── Models/

│   ├── Services/ 

│   ├── Controls/ 

│   ├── Forms/ 

│   ├── Helpers/
│   └── Program.cs
├── web/                    # website đăng ký
     ├── app.py
     └── database/
   	 ├── 01\_tao\_bang.pgsql             # tạo bảng
    	 └── 02\_du\_lieu\_mo\_phong.pgsql     # dữ liệu mẫu
```

## Yêu cầu cài đặt

* **PostgreSQL 14 trở lên** (cần quyền chạy `CREATE EXTENSION pgcrypto`, thường dùng tài khoản `postgres`).
* **.NET 10 SDK** trên **Windows** (WinForms chỉ chạy trên Windows).
* Trình soạn thảo một trong hai: **Visual Studio 2022/2026 Community** (workload *.NET desktop development*) hoặc **VS Code** + extension C# Dev Kit.
* **Python 3.10 trở lên** cho website.

## 1\. Tạo cơ sở dữ liệu

Tạo một CSDL tên `tuyensinh`, rồi chạy lần lượt hai file SQL (thứ tự quan trọng).

Dùng `psql`:

```
psql -U postgres -c "CREATE DATABASE tuyensinh;"
psql -U postgres -d tuyensinh -f database/01\_tao\_bang.sql
psql -U postgres -d tuyensinh -f database/02\_du\_lieu\_mo\_phong.sql
```

Hoặc dùng pgAdmin: tạo database `tuyensinh`, mở *Query Tool*, mở và chạy từng file theo thứ tự. Hãy chắc chắn file chạy đến hết (có lệnh `COMMIT` ở cuối file dữ liệu mẫu).

Nếu muốn dùng tên CSDL khác, nhớ sửa cho khớp ở bước 2.

## 2\. Đổi thông tin kết nối PostgreSQL (BẮT BUỘC)

Mật khẩu trong mã nguồn chỉ là **matkhaucuaban**. Bạn phải đổi thành thông tin PostgreSQL của máy mình ở **hai file** sau, nếu không chương trình sẽ báo "Lỗi kết nối".

### a) Ứng dụng quản lý: `QuanLyTuyenSinh/Data/Db.cs`

Sửa hằng `ConnectionString`:

```csharp
private const string ConnectionString =
    "Host=localhost;Port=5432;Database=tuyensinh;Username=postgres;Password=**matkhaucuaban**";
```

Đổi `Host`, `Port`, `Database`, `Username` và `Password` cho đúng với máy của bạn.

### b) Website: `web/app.py`

Trong hàm `ket\_noi()`, sửa các giá trị mặc định (host, port, dbname, user, password):

```python
host=os.getenv("PGHOST", "localhost"),
port=os.getenv("PGPORT", "5432"),
dbname=os.getenv("PGDATABASE", "tuyensinh"),
user=os.getenv("PGUSER", "postgres"),
password=os.getenv("PGPASSWORD", "**matkhaucuaban**"),
```

Hoặc đặt biến môi trường `PGHOST`, `PGPORT`, `PGDATABASE`, `PGUSER`, `PGPASSWORD` thay vì sửa file (ví dụ trong PowerShell: `$env:PGPASSWORD="mat\_khau\_cua\_ban"`).

> \*\*Lưu ý:\*\* không đưa mật khẩu thật của bạn lên GitHub. Khi cần đẩy mã lên, hãy trả các giá trị trên về chỗ trống mẫu.

## 3\. Chạy ứng dụng quản lý

**Cách 1: Visual Studio.** Mở file `.sln` (hoặc `QuanLyTuyenSinh/QuanLyTuyenSinh.csproj`) rồi bấm **F5**. Các thư viện NuGet (Npgsql, BCrypt.Net-Next, ClosedXML) được tự tải về.

**Cách 2: dòng lệnh / VS Code.**

```
cd QuanLyTuyenSinh
dotnet run
```

Lần đầu chương trình kiểm tra kết nối CSDL rồi mở màn hình đăng nhập.

## 4\. Chạy website đăng ký

```
cd web
python -m pip install -r requirements.txt
python app.py
```

Cài thêm các thư viện khác mà `app.py` dùng (xem các dòng `import` ở đầu file). Mở trình duyệt theo địa chỉ hiện trong cửa sổ lệnh.

## 5\. Tài khoản chạy thử

Dữ liệu mẫu có sẵn hai tài khoản để bạn thử ngay:

|Vai trò|Tên đăng nhập|Mật khẩu|Dùng để thử|
|-|-|-|-|
|Quản trị viên|`admin`|`111111`|Quản lý khóa học, đợt, nhân viên, phân công; xem hồ sơ (chỉ xem); thống kê và xuất Excel|
|Nhân viên tuyển sinh|`nv.lan`|`123456`|Duyệt hàng loạt, thêm, sửa, xóa hồ sơ trong các khóa mình phụ trách|

Dữ liệu mẫu còn có các nhân viên `nv.hung`, `nv.mai`, `nv.nam` (cùng mật khẩu `NhanVien@123`) để thử trường hợp nhiều nhân viên cùng một khóa, và `nv.thu` là tài khoản **đã bị khóa** (thử đăng nhập sẽ báo bị khóa). Đây chỉ là tài khoản mẫu, hãy đổi mật khẩu nếu dùng thật.

### Gợi ý kiểm thử nhanh

1. Đăng nhập `admin`, vào **Đợt tuyển sinh**, mở **Sửa** một đợt để xem các khóa học được tích; vào **Phân công** chọn đợt rồi bấm **Sửa** ở một khóa để thêm hoặc gỡ nhân viên.
2. Đăng nhập `nv.lan`, vào **Hồ sơ**, chọn "Đợt tuyển sinh 3", tích vài hồ sơ **Chờ xử lý**, bấm **Đánh dấu Đã duyệt** rồi **Lưu**.
3. Đăng nhập `nv.hung`: hồ sơ đã do Lan xác nhận hiện chữ xám và không đổi được (mỗi hồ sơ chỉ một người xác nhận).
4. Mở website, đăng ký một hồ sơ mới, rồi quay lại ứng dụng bằng `nv.lan` để thấy hồ sơ ở trạng thái **Chờ xử lý**.
5. Đăng nhập `admin`, vào **Thống kê**, bấm **Xuất Excel**.

> \*\*Lưu ý ngày tháng:\*\* dữ liệu mẫu tính theo ngày \*\*12/10/2026\*\*; "Đợt tuyển sinh 3" kéo dài đến \*\*15/12/2026\*\*. Nếu hôm nay đã quá ngày đó, đợt sẽ bị coi là đã kết thúc (hồ sơ bị khóa, website không nhận đăng ký). Khi đó hãy đăng nhập `admin`, vào \*\*Đợt tuyển sinh\*\* và sửa lại ngày kết thúc, trạng thái của đợt đó.

## Xử lý sự cố thường gặp

|Hiện tượng|Cách xử lý|
|-|-|
|Hộp thoại "Lỗi kết nối" khi mở ứng dụng|Kiểm tra dịch vụ PostgreSQL đang chạy, và `ConnectionString` trong `Db.cs` đã đúng chưa|
|Website báo lỗi kết nối|Kiểm tra giá trị trong `ket\_noi()` của `web/app.py` hoặc các biến môi trường `PG...`|
|Lỗi khi chạy file `02\_du\_lieu\_mo\_phong.sql` về `pgcrypto`|Chạy bằng tài khoản có quyền tạo extension (thường là `postgres`)|
|Đăng nhập báo sai mật khẩu|Dùng đúng tài khoản mẫu ở mục 5; kiểm tra đã chạy file dữ liệu mẫu chưa|



# QuanLyTuyenSinh
