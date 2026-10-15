#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormChonNhanVien
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
            lblThongTin = new Label();
            clbNhanVien = new CheckedListBox();
            lblGhiChu = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // lblThongTin
            lblThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblThongTin.Location = new Point(15, 12);
            lblThongTin.Name = "lblThongTin";
            lblThongTin.Size = new Size(390, 45);
            lblThongTin.Text = "Khóa học";
            // clbNhanVien
            clbNhanVien.CheckOnClick = true;
            clbNhanVien.FormattingEnabled = true;
            clbNhanVien.Location = new Point(15, 65);
            clbNhanVien.Name = "clbNhanVien";
            clbNhanVien.Size = new Size(390, 256);
            clbNhanVien.TabIndex = 0;
            clbNhanVien.ItemCheck += clbNhanVien_ItemCheck;
            // lblGhiChu
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Location = new Point(15, 328);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(390, 36);
            // btnLuu
            btnLuu.Location = new Point(210, 375);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(95, 34);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // btnHuy
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(310, 375);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(95, 34);
            btnHuy.TabIndex = 2;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // FormChonNhanVien
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(420, 425);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(lblGhiChu);
            Controls.Add(clbNhanVien);
            Controls.Add(lblThongTin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormChonNhanVien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhân viên phụ trách";
            ResumeLayout(false);
        }

        #endregion

        private Label lblThongTin;
        private CheckedListBox clbNhanVien;
        private Label lblGhiChu;
        private Button btnLuu;
        private Button btnHuy;
    }
}