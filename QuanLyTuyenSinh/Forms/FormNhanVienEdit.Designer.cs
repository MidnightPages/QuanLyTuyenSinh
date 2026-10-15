#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormNhanVienEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblNhapLai = new Label();
            txtNhapLai = new TextBox();
            btnDatLaiMatKhau = new Button();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            cboGioiTinh = new ComboBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblVaiTro = new Label();
            cboVaiTro = new ComboBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // lblTenDangNhap
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(20, 25);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(83, 15);
            lblTenDangNhap.Text = "Tên đăng nhập";
            // txtTenDangNhap
            txtTenDangNhap.Location = new Point(150, 22);
            txtTenDangNhap.MaxLength = 50;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(260, 23);
            txtTenDangNhap.TabIndex = 1;
            // lblMatKhau
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(20, 70);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(55, 15);
            lblMatKhau.Text = "Mật khẩu";
            // txtMatKhau
            txtMatKhau.Location = new Point(150, 67);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(260, 23);
            txtMatKhau.TabIndex = 2;
            txtMatKhau.UseSystemPasswordChar = true;
            // lblNhapLai
            lblNhapLai.AutoSize = true;
            lblNhapLai.Location = new Point(20, 115);
            lblNhapLai.Name = "lblNhapLai";
            lblNhapLai.Size = new Size(98, 15);
            lblNhapLai.Text = "Nhập lại mật khẩu";
            // txtNhapLai
            txtNhapLai.Location = new Point(150, 112);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(260, 23);
            txtNhapLai.TabIndex = 3;
            txtNhapLai.UseSystemPasswordChar = true;
            // btnDatLaiMatKhau (chỉ hiện khi sửa nhân viên)
            btnDatLaiMatKhau.Location = new Point(150, 85);
            btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            btnDatLaiMatKhau.Size = new Size(160, 34);
            btnDatLaiMatKhau.TabIndex = 20;
            btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            btnDatLaiMatKhau.UseVisualStyleBackColor = true;
            btnDatLaiMatKhau.Visible = false;
            btnDatLaiMatKhau.Click += btnDatLaiMatKhau_Click;
            // lblHoTen
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 160);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(41, 15);
            lblHoTen.Text = "Họ tên";
            // txtHoTen
            txtHoTen.Location = new Point(150, 157);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(260, 23);
            txtHoTen.TabIndex = 4;
            // lblNgaySinh
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 205);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(58, 15);
            lblNgaySinh.Text = "Ngày sinh";
            // dtpNgaySinh
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(150, 202);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(160, 23);
            dtpNgaySinh.TabIndex = 5;
            dtpNgaySinh.Checked = false;
            // lblGioiTinh
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(20, 250);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(52, 15);
            lblGioiTinh.Text = "Giới tính";
            // cboGioiTinh
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(150, 247);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(120, 23);
            cboGioiTinh.TabIndex = 6;
            // lblSoDienThoai
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(20, 295);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(77, 15);
            lblSoDienThoai.Text = "Số điện thoại";
            // txtSoDienThoai
            txtSoDienThoai.Location = new Point(150, 292);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(160, 23);
            txtSoDienThoai.TabIndex = 7;
            // lblVaiTro
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(20, 340);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(39, 15);
            lblVaiTro.Text = "Vai trò";
            // cboVaiTro
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(150, 337);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(200, 23);
            cboVaiTro.TabIndex = 8;
            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(20, 385);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(57, 15);
            lblTrangThai.Text = "Trạng thái";
            // cboTrangThai
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(150, 382);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(200, 23);
            cboTrangThai.TabIndex = 9;
            // btnLuu
            btnLuu.Location = new Point(215, 440);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(95, 34);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // btnHuy
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(315, 440);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(95, 34);
            btnHuy.TabIndex = 11;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // FormNhanVienEdit
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(440, 495);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(cboTrangThai);
            Controls.Add(lblTrangThai);
            Controls.Add(cboVaiTro);
            Controls.Add(lblVaiTro);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblSoDienThoai);
            Controls.Add(cboGioiTinh);
            Controls.Add(lblGioiTinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(btnDatLaiMatKhau);
            Controls.Add(txtNhapLai);
            Controls.Add(lblNhapLai);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblTenDangNhap);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNhanVienEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhân viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblNhapLai;
        private TextBox txtNhapLai;
        private Button btnDatLaiMatKhau;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private ComboBox cboGioiTinh;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblVaiTro;
        private ComboBox cboVaiTro;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnLuu;
        private Button btnHuy;
    }
}