const form = document.getElementById("profileForm");
const status = document.getElementById("status");
const selectKhoa = document.getElementById("khoahoc");
const nutGui = form.querySelector(".submit");
 
// ---------- Kiểm tra dữ liệu phía trình duyệt ----------
const rules = {
  fullname: (v) => (v.length >= 2 ? "" : "Vui lòng nhập họ và tên."),
  dob: (v) => {
    const m = v.match(/^(\d{1,2})\/(\d{1,2})\/(\d{4})$/);
    if (!m) return "Nhập theo dạng ngày/tháng/năm, ví dụ 25/12/2004.";
    const [, d, mo, y] = m.map(Number);
    const date = new Date(y, mo - 1, d);
    const ok = date.getFullYear() === y && date.getMonth() === mo - 1 && date.getDate() === d;
    return ok && date < new Date() ? "" : "Ngày sinh không hợp lệ.";
  },
  phone: (v) => (/^(0|\+84)\d{9}$/.test(v.replace(/\s/g, "")) ? "" : "Số điện thoại phải gồm 10 chữ số, bắt đầu bằng 0."),
  email: (v) => (/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(v) ? "" : "Email chưa đúng định dạng."),
  address: (v) => (v.length >= 5 ? "" : "Vui lòng nhập địa chỉ."),
  maDotKhoaHoc: (v) => (v ? "" : "Vui lòng chọn khóa học."),
};
 
function hienLoi(input, message) {
  const field = input.closest(".field");
  field.classList.toggle("invalid", Boolean(message));
  field.querySelector(".error").textContent = message;
}
 
function validateField(input) {
  const message = rules[input.name === "fullname" ? "fullname" : input.name](input.value.trim());
  hienLoi(input, message);
  return !message;
}
 
const controls = [...form.querySelectorAll("input, select")];
controls.forEach((el) => {
  el.addEventListener("blur", () => validateField(el));
  el.addEventListener("input", () => {
    if (el.closest(".field").classList.contains("invalid")) validateField(el);
  });
});
 
// ---------- Tải danh sách khóa học ----------
async function taiKhoaHoc() {
  try {
    const res = await fetch("/api/khoa-hoc");
    const ds = await res.json();
    if (!res.ok) throw new Error();
    if (!ds.length) {
      selectKhoa.innerHTML = '<option value="">Hiện chưa có khóa học nhận đăng ký</option>';
      return;
    }
    selectKhoa.innerHTML =
      '<option value="">Chọn khóa học</option>' +
      ds.map((k) => `<option value="${k.ma}">${k.khoa} (${k.dot})</option>`).join("");
  } catch {
    selectKhoa.innerHTML = '<option value="">Không tải được khóa học</option>';
  }
}
taiKhoaHoc();
 
// "25/12/2004" -> "2004-12-25"
function doiNgay(v) {
  const [d, m, y] = v.split("/");
  return `${y}-${m.padStart(2, "0")}-${d.padStart(2, "0")}`;
}
 
// ---------- Gửi đăng ký ----------
form.addEventListener("submit", async (e) => {
  e.preventDefault();
  status.textContent = "";
 
  const allValid = controls.map(validateField).every(Boolean);
  if (!allValid) {
    status.style.color = "var(--error)";
    status.textContent = "Vui lòng kiểm tra lại các ô bị lỗi.";
    controls.find((el) => el.closest(".field").classList.contains("invalid")).focus();
    return;
  }
 
  const body = {
    hoTen: form.elements.fullname.value.trim(),
    ngaySinh: doiNgay(form.elements.dob.value.trim()),
    soDienThoai: form.elements.phone.value.trim(),
    email: form.elements.email.value.trim(),
    diaChi: form.elements.address.value.trim(),
    maDotKhoaHoc: Number(selectKhoa.value),
  };
 
  nutGui.disabled = true;
  try {
    const res = await fetch("/api/dang-ky", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(body),
    });
    const data = await res.json();
 
    if (!res.ok) {
      // Lỗi theo từng ô (dữ liệu sai, đăng ký trùng...)
      if (data.loi) {
        const anhXa = { hoTen: "fullname", ngaySinh: "dob", soDienThoai: "phone", email: "email", diaChi: "address", maDotKhoaHoc: "maDotKhoaHoc" };
        Object.entries(data.loi).forEach(([k, msg]) => hienLoi(form.elements[anhXa[k]], msg));
      }
      status.style.color = "var(--error)";
      status.textContent = data.message || "Đăng ký chưa thành công. Vui lòng kiểm tra lại.";
      return;
    }
 
    status.style.color = "var(--ok)";
    status.textContent = `${data.message} Mã hồ sơ: ${data.maHoSo}.`;
    form.reset();
  } catch {
    status.style.color = "var(--error)";
    status.textContent = "Không kết nối được máy chủ. Vui lòng thử lại.";
  } finally {
    nutGui.disabled = false;
  }
});