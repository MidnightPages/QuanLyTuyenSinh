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
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblTenDangNhap.Location = new Point(40, 60);
            lblTenDangNhap.Margin = new Padding(6, 0, 6, 0);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(199, 37);
            lblTenDangNhap.TabIndex = 23;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(300, 58);
            txtTenDangNhap.Margin = new Padding(6, 7, 6, 7);
            txtTenDangNhap.MaxLength = 50;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(516, 42);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblMatKhau.Location = new Point(40, 168);
            lblMatKhau.Margin = new Padding(6, 0, 6, 0);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(132, 37);
            lblMatKhau.TabIndex = 22;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(300, 166);
            txtMatKhau.Margin = new Padding(6, 7, 6, 7);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(516, 42);
            txtMatKhau.TabIndex = 2;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblNhapLai
            // 
            lblNhapLai.AutoSize = true;
            lblNhapLai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblNhapLai.Location = new Point(40, 276);
            lblNhapLai.Margin = new Padding(6, 0, 6, 0);
            lblNhapLai.Name = "lblNhapLai";
            lblNhapLai.Size = new Size(245, 37);
            lblNhapLai.TabIndex = 21;
            lblNhapLai.Text = "Nhập lại mật khẩu";
            // 
            // txtNhapLai
            // 
            txtNhapLai.Location = new Point(300, 274);
            txtNhapLai.Margin = new Padding(6, 7, 6, 7);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(516, 42);
            txtNhapLai.TabIndex = 3;
            txtNhapLai.UseSystemPasswordChar = true;
            // 
            // btnDatLaiMatKhau
            // 
            btnDatLaiMatKhau.Location = new Point(300, 204);
            btnDatLaiMatKhau.Margin = new Padding(6, 7, 6, 7);
            btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            btnDatLaiMatKhau.Size = new Size(320, 82);
            btnDatLaiMatKhau.TabIndex = 20;
            btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            btnDatLaiMatKhau.UseVisualStyleBackColor = true;
            btnDatLaiMatKhau.Visible = false;
            btnDatLaiMatKhau.Click += btnDatLaiMatKhau_Click;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblHoTen.Location = new Point(40, 384);
            lblHoTen.Margin = new Padding(6, 0, 6, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(98, 37);
            lblHoTen.TabIndex = 17;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(300, 382);
            txtHoTen.Margin = new Padding(6, 7, 6, 7);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(516, 42);
            txtHoTen.TabIndex = 4;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblNgaySinh.Location = new Point(40, 492);
            lblNgaySinh.Margin = new Padding(6, 0, 6, 0);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(140, 37);
            lblNgaySinh.TabIndex = 16;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Checked = false;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(300, 490);
            dtpNgaySinh.Margin = new Padding(6, 7, 6, 7);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(316, 42);
            dtpNgaySinh.TabIndex = 5;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblGioiTinh.Location = new Point(40, 600);
            lblGioiTinh.Margin = new Padding(6, 0, 6, 0);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(124, 37);
            lblGioiTinh.TabIndex = 15;
            lblGioiTinh.Text = "Giới tính";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(300, 598);
            cboGioiTinh.Margin = new Padding(6, 7, 6, 7);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(236, 44);
            cboGioiTinh.TabIndex = 6;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblSoDienThoai.Location = new Point(40, 708);
            lblSoDienThoai.Margin = new Padding(6, 0, 6, 0);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(176, 37);
            lblSoDienThoai.TabIndex = 14;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(300, 706);
            txtSoDienThoai.Margin = new Padding(6, 7, 6, 7);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(316, 42);
            txtSoDienThoai.TabIndex = 7;
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblVaiTro.Location = new Point(40, 816);
            lblVaiTro.Margin = new Padding(6, 0, 6, 0);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(98, 37);
            lblVaiTro.TabIndex = 13;
            lblVaiTro.Text = "Vai trò";
            // 
            // cboVaiTro
            // 
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(300, 814);
            cboVaiTro.Margin = new Padding(6, 7, 6, 7);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(396, 44);
            cboVaiTro.TabIndex = 8;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblTrangThai.Location = new Point(40, 924);
            lblTrangThai.Margin = new Padding(6, 0, 6, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(143, 37);
            lblTrangThai.TabIndex = 12;
            lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(300, 922);
            cboTrangThai.Margin = new Padding(6, 7, 6, 7);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(396, 44);
            cboTrangThai.TabIndex = 9;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(430, 1056);
            btnLuu.Margin = new Padding(6, 7, 6, 7);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(190, 82);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(630, 1056);
            btnHuy.Margin = new Padding(6, 7, 6, 7);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(190, 82);
            btnHuy.TabIndex = 11;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // FormNhanVienEdit
            // 
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(880, 1188);
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
            Margin = new Padding(6, 7, 6, 7);
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