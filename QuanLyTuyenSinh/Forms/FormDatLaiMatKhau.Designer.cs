#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormDatLaiMatKhau
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
            lblNguoiDung = new Label();
            lblMatKhauMoi = new Label();
            txtMatKhauMoi = new TextBox();
            lblNhapLai = new Label();
            txtNhapLai = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // lblNguoiDung
            // 
            lblNguoiDung.Dock = DockStyle.Top;
            lblNguoiDung.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNguoiDung.Location = new Point(0, 0);
            lblNguoiDung.Margin = new Padding(6, 0, 6, 0);
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Size = new Size(896, 158);
            lblNguoiDung.TabIndex = 0;
            lblNguoiDung.Text = "Đặt Lại Mật Khẩu";
            lblNguoiDung.TextAlign = ContentAlignment.MiddleCenter;
            lblNguoiDung.Click += lblNguoiDung_Click;
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Font = new Font("Segoe UI Semibold", 12.125F, FontStyle.Bold | FontStyle.Italic);
            lblMatKhauMoi.Location = new Point(163, 168);
            lblMatKhauMoi.Margin = new Padding(6, 0, 6, 0);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(229, 45);
            lblMatKhauMoi.TabIndex = 1;
            lblMatKhauMoi.Text = "Mật khẩu mới";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(405, 168);
            txtMatKhauMoi.Margin = new Padding(6, 7, 6, 7);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(391, 42);
            txtMatKhauMoi.TabIndex = 0;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // lblNhapLai
            // 
            lblNhapLai.AutoSize = true;
            lblNhapLai.Font = new Font("Segoe UI Semibold", 12.125F, FontStyle.Bold | FontStyle.Italic);
            lblNhapLai.Location = new Point(92, 251);
            lblNhapLai.Margin = new Padding(6, 0, 6, 0);
            lblNhapLai.Name = "lblNhapLai";
            lblNhapLai.Size = new Size(303, 45);
            lblNhapLai.TabIndex = 3;
            lblNhapLai.Text = "Nhập lại mật khẩu";
            // 
            // txtNhapLai
            // 
            txtNhapLai.Location = new Point(405, 251);
            txtNhapLai.Margin = new Padding(6, 7, 6, 7);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(391, 42);
            txtNhapLai.TabIndex = 1;
            txtNhapLai.UseSystemPasswordChar = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(257, 363);
            btnLuu.Margin = new Padding(6, 7, 6, 7);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(190, 82);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(494, 363);
            btnHuy.Margin = new Padding(6, 7, 6, 7);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(190, 82);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // FormDatLaiMatKhau
            // 
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(896, 517);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtNhapLai);
            Controls.Add(lblNhapLai);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(lblNguoiDung);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDatLaiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đặt lại mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNguoiDung;
        private Label lblMatKhauMoi;
        private TextBox txtMatKhauMoi;
        private Label lblNhapLai;
        private TextBox txtNhapLai;
        private Button btnLuu;
        private Button btnHuy;
    }
}
