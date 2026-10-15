#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormKhoaHocEdit
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
            lblTen = new Label();
            txtTenKhoaHoc = new TextBox();
            lblHocPhi = new Label();
            nudHocPhi = new NumericUpDown();
            lblThoiLuong = new Label();
            txtThoiLuong = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnLuu = new Button();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)nudHocPhi).BeginInit();
            SuspendLayout();
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblTen.Location = new Point(40, 60);
            lblTen.Margin = new Padding(6, 0, 6, 0);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(179, 37);
            lblTen.TabIndex = 0;
            lblTen.Text = "Tên khóa học";
            // 
            // txtTenKhoaHoc
            // 
            txtTenKhoaHoc.Location = new Point(260, 57);
            txtTenKhoaHoc.Margin = new Padding(6, 7, 6, 7);
            txtTenKhoaHoc.MaxLength = 150;
            txtTenKhoaHoc.Name = "txtTenKhoaHoc";
            txtTenKhoaHoc.Size = new Size(516, 42);
            txtTenKhoaHoc.TabIndex = 1;
            // 
            // lblHocPhi
            // 
            lblHocPhi.AutoSize = true;
            lblHocPhi.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblHocPhi.Location = new Point(40, 168);
            lblHocPhi.Margin = new Padding(6, 0, 6, 0);
            lblHocPhi.Name = "lblHocPhi";
            lblHocPhi.Size = new Size(193, 37);
            lblHocPhi.TabIndex = 2;
            lblHocPhi.Text = "Học phí (VNĐ)";
            // 
            // nudHocPhi
            // 
            nudHocPhi.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            nudHocPhi.Location = new Point(256, 166);
            nudHocPhi.Margin = new Padding(6, 7, 6, 7);
            nudHocPhi.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudHocPhi.Name = "nudHocPhi";
            nudHocPhi.Size = new Size(520, 42);
            nudHocPhi.TabIndex = 3;
            nudHocPhi.TextAlign = HorizontalAlignment.Right;
            nudHocPhi.ThousandsSeparator = true;
            // 
            // lblThoiLuong
            // 
            lblThoiLuong.AutoSize = true;
            lblThoiLuong.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblThoiLuong.Location = new Point(40, 276);
            lblThoiLuong.Margin = new Padding(6, 0, 6, 0);
            lblThoiLuong.Name = "lblThoiLuong";
            lblThoiLuong.Size = new Size(150, 37);
            lblThoiLuong.TabIndex = 4;
            lblThoiLuong.Text = "Thời lượng";
            // 
            // txtThoiLuong
            // 
            txtThoiLuong.Location = new Point(260, 269);
            txtThoiLuong.Margin = new Padding(6, 7, 6, 7);
            txtThoiLuong.MaxLength = 50;
            txtThoiLuong.Name = "txtThoiLuong";
            txtThoiLuong.PlaceholderText = "Ví dụ: 3 tháng (36 buổi)";
            txtThoiLuong.Size = new Size(516, 42);
            txtThoiLuong.TabIndex = 5;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic);
            lblTrangThai.Location = new Point(40, 384);
            lblTrangThai.Margin = new Padding(6, 0, 6, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(143, 37);
            lblTrangThai.TabIndex = 6;
            lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(260, 381);
            cboTrangThai.Margin = new Padding(6, 7, 6, 7);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(316, 44);
            cboTrangThai.TabIndex = 7;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(380, 516);
            btnLuu.Margin = new Padding(6, 7, 6, 7);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(190, 82);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(590, 516);
            btnHuy.Margin = new Padding(6, 7, 6, 7);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(190, 82);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // FormKhoaHocEdit
            // 
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(840, 648);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(cboTrangThai);
            Controls.Add(lblTrangThai);
            Controls.Add(txtThoiLuong);
            Controls.Add(lblThoiLuong);
            Controls.Add(nudHocPhi);
            Controls.Add(lblHocPhi);
            Controls.Add(txtTenKhoaHoc);
            Controls.Add(lblTen);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormKhoaHocEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Khóa học";
            ((System.ComponentModel.ISupportInitialize)nudHocPhi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTen;
        private TextBox txtTenKhoaHoc;
        private Label lblHocPhi;
        private NumericUpDown nudHocPhi;
        private Label lblThoiLuong;
        private TextBox txtThoiLuong;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnLuu;
        private Button btnHuy;
    }
}
