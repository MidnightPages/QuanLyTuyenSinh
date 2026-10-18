#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormHoSoThem
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
            cboDot = new ComboBox();
            lblKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
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
            lblGhiChu = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // lblDot
            // 
            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblDot.Location = new Point(40, 55);
            lblDot.Margin = new Padding(6, 0, 6, 0);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(196, 37);
            lblDot.TabIndex = 16;
            lblDot.Text = "Đợt tuyển sinh";
            // 
            // cboDot
            // 
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDot.FormattingEnabled = true;
            cboDot.Location = new Point(295, 53);
            cboDot.Margin = new Padding(6, 7, 6, 7);
            cboDot.Name = "cboDot";
            cboDot.Size = new Size(596, 44);
            cboDot.TabIndex = 0;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblKhoaHoc.Location = new Point(40, 151);
            lblKhoaHoc.Margin = new Padding(6, 0, 6, 0);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(130, 37);
            lblKhoaHoc.TabIndex = 15;
            lblKhoaHoc.Text = "Khóa học";
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(295, 149);
            cboKhoaHoc.Margin = new Padding(6, 7, 6, 7);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(596, 44);
            cboKhoaHoc.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblHoTen.Location = new Point(40, 247);
            lblHoTen.Margin = new Padding(6, 0, 6, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(98, 37);
            lblHoTen.TabIndex = 14;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(295, 245);
            txtHoTen.Margin = new Padding(6, 7, 6, 7);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(596, 42);
            txtHoTen.TabIndex = 2;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblNgaySinh.Location = new Point(40, 343);
            lblNgaySinh.Margin = new Padding(6, 0, 6, 0);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(140, 37);
            lblNgaySinh.TabIndex = 13;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Checked = false;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(295, 341);
            dtpNgaySinh.Margin = new Padding(6, 7, 6, 7);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(316, 42);
            dtpNgaySinh.TabIndex = 3;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblSoDienThoai.Location = new Point(40, 439);
            lblSoDienThoai.Margin = new Padding(6, 0, 6, 0);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(176, 37);
            lblSoDienThoai.TabIndex = 12;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(295, 437);
            txtSoDienThoai.Margin = new Padding(6, 7, 6, 7);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(316, 42);
            txtSoDienThoai.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblEmail.Location = new Point(40, 535);
            lblEmail.Margin = new Padding(6, 0, 6, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(86, 37);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(295, 533);
            txtEmail.Margin = new Padding(6, 7, 6, 7);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(596, 42);
            txtEmail.TabIndex = 5;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblDiaChi.Location = new Point(40, 631);
            lblDiaChi.Margin = new Padding(6, 0, 6, 0);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(103, 37);
            lblDiaChi.TabIndex = 10;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(295, 629);
            txtDiaChi.Margin = new Padding(6, 7, 6, 7);
            txtDiaChi.MaxLength = 255;
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ScrollBars = ScrollBars.Vertical;
            txtDiaChi.Size = new Size(596, 138);
            txtDiaChi.TabIndex = 6;
            // 
            // lblGhiChu
            // 
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Location = new Point(40, 804);
            lblGhiChu.Margin = new Padding(6, 0, 6, 0);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(860, 48);
            lblGhiChu.TabIndex = 9;
            lblGhiChu.Text = "Hồ sơ mới có trạng thái Chờ xử lý.";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(500, 876);
            btnLuu.Margin = new Padding(6, 7, 6, 7);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(190, 82);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(710, 876);
            btnHuy.Margin = new Padding(6, 7, 6, 7);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(190, 82);
            btnHuy.TabIndex = 8;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // FormHoSoThem
            // 
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(960, 1008);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(lblGhiChu);
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
            Controls.Add(cboKhoaHoc);
            Controls.Add(lblKhoaHoc);
            Controls.Add(cboDot);
            Controls.Add(lblDot);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormHoSoThem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm hồ sơ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDot;
        private ComboBox cboDot;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
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
        private Label lblGhiChu;
        private Button btnLuu;
        private Button btnHuy;
    }
}