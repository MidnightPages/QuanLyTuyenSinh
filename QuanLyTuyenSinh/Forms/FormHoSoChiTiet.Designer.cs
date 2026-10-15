#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormHoSoChiTiet
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
            lblDot = new Label();
            txtDot = new TextBox();
            lblKhoaHoc = new Label();
            txtKhoaHoc = new TextBox();
            lblNgayDangKy = new Label();
            txtNgayDangKy = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblTrangThai = new Label();
            txtTrangThai = new TextBox();
            lblXacNhan = new Label();
            txtXacNhan = new TextBox();
            btnLuu = new Button();
            btnDong = new Button();
            SuspendLayout();
            // 
            // lblDot
            // 
            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblDot.Location = new Point(40, 54);
            lblDot.Margin = new Padding(6, 0, 6, 0);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(196, 37);
            lblDot.TabIndex = 21;
            lblDot.Text = "Đợt tuyển sinh";
            // 
            // txtDot
            // 
            txtDot.Location = new Point(300, 48);
            txtDot.Margin = new Padding(6, 7, 6, 7);
            txtDot.Name = "txtDot";
            txtDot.ReadOnly = true;
            txtDot.Size = new Size(596, 42);
            txtDot.TabIndex = 20;
            txtDot.TabStop = false;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblKhoaHoc.Location = new Point(40, 151);
            lblKhoaHoc.Margin = new Padding(6, 0, 6, 0);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(130, 37);
            lblKhoaHoc.TabIndex = 19;
            lblKhoaHoc.Text = "Khóa học";
            // 
            // txtKhoaHoc
            // 
            txtKhoaHoc.Location = new Point(300, 144);
            txtKhoaHoc.Margin = new Padding(6, 7, 6, 7);
            txtKhoaHoc.Name = "txtKhoaHoc";
            txtKhoaHoc.ReadOnly = true;
            txtKhoaHoc.Size = new Size(596, 42);
            txtKhoaHoc.TabIndex = 18;
            txtKhoaHoc.TabStop = false;
            // 
            // lblNgayDangKy
            // 
            lblNgayDangKy.AutoSize = true;
            lblNgayDangKy.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblNgayDangKy.Location = new Point(40, 247);
            lblNgayDangKy.Margin = new Padding(6, 0, 6, 0);
            lblNgayDangKy.Name = "lblNgayDangKy";
            lblNgayDangKy.Size = new Size(185, 37);
            lblNgayDangKy.TabIndex = 17;
            lblNgayDangKy.Text = "Ngày đăng ký";
            // 
            // txtNgayDangKy
            // 
            txtNgayDangKy.Location = new Point(300, 243);
            txtNgayDangKy.Margin = new Padding(6, 7, 6, 7);
            txtNgayDangKy.Name = "txtNgayDangKy";
            txtNgayDangKy.ReadOnly = true;
            txtNgayDangKy.Size = new Size(316, 42);
            txtNgayDangKy.TabIndex = 16;
            txtNgayDangKy.TabStop = false;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblHoTen.Location = new Point(40, 343);
            lblHoTen.Margin = new Padding(6, 0, 6, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(98, 37);
            lblHoTen.TabIndex = 15;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(300, 336);
            txtHoTen.Margin = new Padding(6, 7, 6, 7);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(596, 42);
            txtHoTen.TabIndex = 0;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblNgaySinh.Location = new Point(40, 439);
            lblNgaySinh.Margin = new Padding(6, 0, 6, 0);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(140, 37);
            lblNgaySinh.TabIndex = 14;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Checked = false;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(300, 432);
            dtpNgaySinh.Margin = new Padding(6, 7, 6, 7);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(316, 42);
            dtpNgaySinh.TabIndex = 1;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblSoDienThoai.Location = new Point(40, 535);
            lblSoDienThoai.Margin = new Padding(6, 0, 6, 0);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(176, 37);
            lblSoDienThoai.TabIndex = 13;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(300, 537);
            txtSoDienThoai.Margin = new Padding(6, 7, 6, 7);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(316, 42);
            txtSoDienThoai.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblEmail.Location = new Point(40, 631);
            lblEmail.Margin = new Padding(6, 0, 6, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(86, 37);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(300, 629);
            txtEmail.Margin = new Padding(6, 7, 6, 7);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(596, 42);
            txtEmail.TabIndex = 3;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblDiaChi.Location = new Point(40, 727);
            lblDiaChi.Margin = new Padding(6, 0, 6, 0);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(103, 37);
            lblDiaChi.TabIndex = 11;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(300, 725);
            txtDiaChi.Margin = new Padding(6, 7, 6, 7);
            txtDiaChi.MaxLength = 255;
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ScrollBars = ScrollBars.Vertical;
            txtDiaChi.Size = new Size(596, 138);
            txtDiaChi.TabIndex = 4;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblTrangThai.Location = new Point(40, 919);
            lblTrangThai.Margin = new Padding(6, 0, 6, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(143, 37);
            lblTrangThai.TabIndex = 10;
            lblTrangThai.Text = "Trạng thái";
            // 
            // txtTrangThai
            // 
            txtTrangThai.Location = new Point(300, 917);
            txtTrangThai.Margin = new Padding(6, 7, 6, 7);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.ReadOnly = true;
            txtTrangThai.Size = new Size(316, 42);
            txtTrangThai.TabIndex = 9;
            txtTrangThai.TabStop = false;
            // 
            // lblXacNhan
            // 
            lblXacNhan.AutoSize = true;
            lblXacNhan.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblXacNhan.Location = new Point(40, 1015);
            lblXacNhan.Margin = new Padding(6, 0, 6, 0);
            lblXacNhan.Name = "lblXacNhan";
            lblXacNhan.Size = new Size(211, 37);
            lblXacNhan.TabIndex = 8;
            lblXacNhan.Text = "Người xác nhận";
            // 
            // txtXacNhan
            // 
            txtXacNhan.Location = new Point(300, 1013);
            txtXacNhan.Margin = new Padding(6, 7, 6, 7);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.ReadOnly = true;
            txtXacNhan.Size = new Size(596, 42);
            txtXacNhan.TabIndex = 7;
            txtXacNhan.TabStop = false;
            txtXacNhan.TextChanged += txtXacNhan_TextChanged;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(500, 1128);
            btnLuu.Margin = new Padding(6, 7, 6, 7);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(190, 82);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnDong
            // 
            btnDong.DialogResult = DialogResult.Cancel;
            btnDong.Location = new Point(710, 1128);
            btnDong.Margin = new Padding(6, 7, 6, 7);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(190, 82);
            btnDong.TabIndex = 6;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            // 
            // FormHoSoChiTiet
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDong;
            ClientSize = new Size(960, 1260);
            Controls.Add(btnDong);
            Controls.Add(btnLuu);
            Controls.Add(txtXacNhan);
            Controls.Add(lblXacNhan);
            Controls.Add(txtTrangThai);
            Controls.Add(lblTrangThai);
            Controls.Add(txtDiaChi);
            Controls.Add(lblDiaChi);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblSoDienThoai);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(txtNgayDangKy);
            Controls.Add(lblNgayDangKy);
            Controls.Add(txtKhoaHoc);
            Controls.Add(lblKhoaHoc);
            Controls.Add(txtDot);
            Controls.Add(lblDot);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormHoSoChiTiet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết hồ sơ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDot;
        private TextBox txtDot;
        private Label lblKhoaHoc;
        private TextBox txtKhoaHoc;
        private Label lblNgayDangKy;
        private TextBox txtNgayDangKy;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblTrangThai;
        private TextBox txtTrangThai;
        private Label lblXacNhan;
        private TextBox txtXacNhan;
        private Button btnLuu;
        private Button btnDong;
    }
}