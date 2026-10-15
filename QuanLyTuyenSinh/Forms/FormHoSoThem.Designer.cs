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
            // lblDot
            lblDot.AutoSize = true;
            lblDot.Location = new Point(20, 23);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(79, 15);
            lblDot.Text = "Đợt tuyển sinh";
            // cboDot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDot.FormattingEnabled = true;
            cboDot.Location = new Point(150, 20);
            cboDot.Name = "cboDot";
            cboDot.Size = new Size(300, 23);
            cboDot.TabIndex = 0;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            // lblKhoaHoc
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(20, 63);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(54, 15);
            lblKhoaHoc.Text = "Khóa học";
            // cboKhoaHoc
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(150, 60);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(300, 23);
            cboKhoaHoc.TabIndex = 1;
            // lblHoTen
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 103);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(41, 15);
            lblHoTen.Text = "Họ tên";
            // txtHoTen
            txtHoTen.Location = new Point(150, 100);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 23);
            txtHoTen.TabIndex = 2;
            // lblNgaySinh
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 143);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(58, 15);
            lblNgaySinh.Text = "Ngày sinh";
            // dtpNgaySinh
            dtpNgaySinh.Checked = false;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(150, 140);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(160, 23);
            dtpNgaySinh.TabIndex = 3;
            // lblSoDienThoai
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(20, 183);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(77, 15);
            lblSoDienThoai.Text = "Số điện thoại";
            // txtSoDienThoai
            txtSoDienThoai.Location = new Point(150, 180);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(160, 23);
            txtSoDienThoai.TabIndex = 4;
            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 223);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.Text = "Email";
            // txtEmail
            txtEmail.Location = new Point(150, 220);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 23);
            txtEmail.TabIndex = 5;
            // lblDiaChi
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(20, 263);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(41, 15);
            lblDiaChi.Text = "Địa chỉ";
            // txtDiaChi
            txtDiaChi.Location = new Point(150, 260);
            txtDiaChi.MaxLength = 255;
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ScrollBars = ScrollBars.Vertical;
            txtDiaChi.Size = new Size(300, 60);
            txtDiaChi.TabIndex = 6;
            // lblGhiChu
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Location = new Point(20, 335);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(430, 20);
            lblGhiChu.Text = "Hồ sơ mới có trạng thái Chờ xử lý.";
            // btnLuu
            btnLuu.Location = new Point(250, 365);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(95, 34);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // btnHuy
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(355, 365);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(95, 34);
            btnHuy.TabIndex = 8;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // FormHoSoThem
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(480, 420);
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