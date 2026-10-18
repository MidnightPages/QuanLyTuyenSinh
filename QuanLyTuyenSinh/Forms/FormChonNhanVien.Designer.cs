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
            // 
            // lblThongTin
            // 
            lblThongTin.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblThongTin.Location = new Point(30, 29);
            lblThongTin.Margin = new Padding(6, 0, 6, 0);
            lblThongTin.Name = "lblThongTin";
            lblThongTin.Size = new Size(780, 108);
            lblThongTin.TabIndex = 4;
            lblThongTin.Text = "Khóa học";
            // 
            // clbNhanVien
            // 
            clbNhanVien.CheckOnClick = true;
            clbNhanVien.FormattingEnabled = true;
            clbNhanVien.Location = new Point(30, 156);
            clbNhanVien.Margin = new Padding(6, 7, 6, 7);
            clbNhanVien.Name = "clbNhanVien";
            clbNhanVien.Size = new Size(776, 589);
            clbNhanVien.TabIndex = 0;
            clbNhanVien.ItemCheck += clbNhanVien_ItemCheck;
            // 
            // lblGhiChu
            // 
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Location = new Point(30, 787);
            lblGhiChu.Margin = new Padding(6, 0, 6, 0);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(780, 86);
            lblGhiChu.TabIndex = 3;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(420, 900);
            btnLuu.Margin = new Padding(6, 7, 6, 7);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(190, 82);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(620, 900);
            btnHuy.Margin = new Padding(6, 7, 6, 7);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(190, 82);
            btnHuy.TabIndex = 2;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // FormChonNhanVien
            // 
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(840, 1020);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(lblGhiChu);
            Controls.Add(clbNhanVien);
            Controls.Add(lblThongTin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 7, 6, 7);
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