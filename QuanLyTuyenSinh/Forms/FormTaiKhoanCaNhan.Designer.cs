#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormTaiKhoanCaNhan
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
            Label lblMkCu;
            Label lblMkMoi;
            Label lblNhapLai;
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblVaiTro = new Label();
            txtVaiTro = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            cboGioiTinh = new ComboBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            btnLuuThongTin = new Button();
            grpMatKhau = new GroupBox();
            txtMkCu = new TextBox();
            txtMkMoi = new TextBox();
            txtNhapLai = new TextBox();
            btnDoiMatKhau = new Button();
            btnDong = new Button();
            lblMkCu = new Label();
            lblMkMoi = new Label();
            lblNhapLai = new Label();
            grpMatKhau.SuspendLayout();
            SuspendLayout();
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblTenDangNhap.Location = new Point(40, 55);
            lblTenDangNhap.Margin = new Padding(6, 0, 6, 0);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(199, 37);
            lblTenDangNhap.TabIndex = 14;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(300, 52);
            txtTenDangNhap.Margin = new Padding(6, 7, 6, 7);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.ReadOnly = true;
            txtTenDangNhap.Size = new Size(576, 42);
            txtTenDangNhap.TabIndex = 13;
            txtTenDangNhap.TabStop = false;
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblVaiTro.Location = new Point(40, 151);
            lblVaiTro.Margin = new Padding(6, 0, 6, 0);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(98, 37);
            lblVaiTro.TabIndex = 12;
            lblVaiTro.Text = "Vai trò";
            // 
            // txtVaiTro
            // 
            txtVaiTro.Location = new Point(300, 148);
            txtVaiTro.Margin = new Padding(6, 7, 6, 7);
            txtVaiTro.Name = "txtVaiTro";
            txtVaiTro.ReadOnly = true;
            txtVaiTro.Size = new Size(576, 42);
            txtVaiTro.TabIndex = 11;
            txtVaiTro.TabStop = false;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblHoTen.Location = new Point(40, 247);
            lblHoTen.Margin = new Padding(6, 0, 6, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(98, 37);
            lblHoTen.TabIndex = 10;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(300, 244);
            txtHoTen.Margin = new Padding(6, 7, 6, 7);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(576, 42);
            txtHoTen.TabIndex = 0;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblNgaySinh.Location = new Point(40, 343);
            lblNgaySinh.Margin = new Padding(6, 0, 6, 0);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(140, 37);
            lblNgaySinh.TabIndex = 9;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Checked = false;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(300, 338);
            dtpNgaySinh.Margin = new Padding(6, 7, 6, 7);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(316, 42);
            dtpNgaySinh.TabIndex = 1;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblGioiTinh.Location = new Point(40, 439);
            lblGioiTinh.Margin = new Padding(6, 0, 6, 0);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(124, 37);
            lblGioiTinh.TabIndex = 8;
            lblGioiTinh.Text = "Giới tính";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(300, 436);
            cboGioiTinh.Margin = new Padding(6, 7, 6, 7);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(236, 44);
            cboGioiTinh.TabIndex = 2;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblSoDienThoai.Location = new Point(40, 535);
            lblSoDienThoai.Margin = new Padding(6, 0, 6, 0);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(176, 37);
            lblSoDienThoai.TabIndex = 7;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(300, 532);
            txtSoDienThoai.Margin = new Padding(6, 7, 6, 7);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(316, 42);
            txtSoDienThoai.TabIndex = 3;
            // 
            // btnLuuThongTin
            // 
            btnLuuThongTin.Location = new Point(580, 624);
            btnLuuThongTin.Margin = new Padding(6, 7, 6, 7);
            btnLuuThongTin.Name = "btnLuuThongTin";
            btnLuuThongTin.Size = new Size(300, 82);
            btnLuuThongTin.TabIndex = 4;
            btnLuuThongTin.Text = "Lưu thông tin";
            btnLuuThongTin.UseVisualStyleBackColor = true;
            btnLuuThongTin.Click += btnLuuThongTin_Click;
            // 
            // grpMatKhau
            // 
            grpMatKhau.Controls.Add(lblMkCu);
            grpMatKhau.Controls.Add(txtMkCu);
            grpMatKhau.Controls.Add(lblMkMoi);
            grpMatKhau.Controls.Add(txtMkMoi);
            grpMatKhau.Controls.Add(lblNhapLai);
            grpMatKhau.Controls.Add(txtNhapLai);
            grpMatKhau.Controls.Add(btnDoiMatKhau);
            grpMatKhau.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpMatKhau.Location = new Point(40, 744);
            grpMatKhau.Margin = new Padding(6, 7, 6, 7);
            grpMatKhau.Name = "grpMatKhau";
            grpMatKhau.Padding = new Padding(6, 7, 6, 7);
            grpMatKhau.Size = new Size(840, 480);
            grpMatKhau.TabIndex = 5;
            grpMatKhau.TabStop = false;
            grpMatKhau.Text = "Đổi mật khẩu";
            // 
            // lblMkCu
            // 
            lblMkCu.AutoSize = true;
            lblMkCu.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblMkCu.Location = new Point(30, 79);
            lblMkCu.Margin = new Padding(6, 0, 6, 0);
            lblMkCu.Name = "lblMkCu";
            lblMkCu.Size = new Size(232, 37);
            lblMkCu.TabIndex = 0;
            lblMkCu.Text = "Mật khẩu hiện tại";
            // 
            // txtMkCu
            // 
            txtMkCu.Location = new Point(300, 72);
            txtMkCu.Margin = new Padding(6, 7, 6, 7);
            txtMkCu.Name = "txtMkCu";
            txtMkCu.Size = new Size(496, 43);
            txtMkCu.TabIndex = 0;
            txtMkCu.UseSystemPasswordChar = true;
            // 
            // lblMkMoi
            // 
            lblMkMoi.AutoSize = true;
            lblMkMoi.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblMkMoi.Location = new Point(30, 175);
            lblMkMoi.Margin = new Padding(6, 0, 6, 0);
            lblMkMoi.Name = "lblMkMoi";
            lblMkMoi.Size = new Size(187, 37);
            lblMkMoi.TabIndex = 1;
            lblMkMoi.Text = "Mật khẩu mới";
            // 
            // txtMkMoi
            // 
            txtMkMoi.Location = new Point(300, 168);
            txtMkMoi.Margin = new Padding(6, 7, 6, 7);
            txtMkMoi.Name = "txtMkMoi";
            txtMkMoi.Size = new Size(496, 43);
            txtMkMoi.TabIndex = 1;
            txtMkMoi.UseSystemPasswordChar = true;
            // 
            // lblNhapLai
            // 
            lblNhapLai.AutoSize = true;
            lblNhapLai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblNhapLai.Location = new Point(30, 271);
            lblNhapLai.Margin = new Padding(6, 0, 6, 0);
            lblNhapLai.Name = "lblNhapLai";
            lblNhapLai.Size = new Size(245, 37);
            lblNhapLai.TabIndex = 2;
            lblNhapLai.Text = "Nhập lại mật khẩu";
            // 
            // txtNhapLai
            // 
            txtNhapLai.Location = new Point(300, 264);
            txtNhapLai.Margin = new Padding(6, 7, 6, 7);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(496, 43);
            txtNhapLai.TabIndex = 2;
            txtNhapLai.UseSystemPasswordChar = true;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Font = new Font("Segoe UI", 10.125F);
            btnDoiMatKhau.Location = new Point(500, 360);
            btnDoiMatKhau.Margin = new Padding(6, 7, 6, 7);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(300, 82);
            btnDoiMatKhau.TabIndex = 3;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(690, 1260);
            btnDong.Margin = new Padding(6, 7, 6, 7);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(190, 82);
            btnDong.TabIndex = 6;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // FormTaiKhoanCaNhan
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 1380);
            Controls.Add(btnDong);
            Controls.Add(grpMatKhau);
            Controls.Add(btnLuuThongTin);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblSoDienThoai);
            Controls.Add(cboGioiTinh);
            Controls.Add(lblGioiTinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(txtVaiTro);
            Controls.Add(lblVaiTro);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblTenDangNhap);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTaiKhoanCaNhan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tài khoản cá nhân";
            grpMatKhau.ResumeLayout(false);
            grpMatKhau.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblVaiTro;
        private TextBox txtVaiTro;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private ComboBox cboGioiTinh;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Button btnLuuThongTin;
        private GroupBox grpMatKhau;
        private Label lblMkCu;
        private TextBox txtMkCu;
        private Label lblMkMoi;
        private TextBox txtMkMoi;
        private Label lblNhapLai;
        private TextBox txtNhapLai;
        private Button btnDoiMatKhau;
        private Button btnDong;
    }
}