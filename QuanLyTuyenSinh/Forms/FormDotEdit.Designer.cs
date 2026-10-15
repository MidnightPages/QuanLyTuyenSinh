#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormDotEdit
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
            tabMain = new TabControl();
            tabThongTin = new TabPage();
            lblTenDot = new Label();
            txtTenDot = new TextBox();
            lblBatDau = new Label();
            dtpBatDau = new DateTimePicker();
            lblKetThuc = new Label();
            dtpKetThuc = new DateTimePicker();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            tabKhoaHoc = new TabPage();
            clbKhoaHoc = new CheckedListBox();
            lblHuongDan = new Label();
            pnlDuoi = new Panel();
            btnLuu = new Button();
            btnDong = new Button();
            tabMain.SuspendLayout();
            tabThongTin.SuspendLayout();
            tabKhoaHoc.SuspendLayout();
            pnlDuoi.SuspendLayout();
            SuspendLayout();
            // tabMain
            tabMain.Controls.Add(tabThongTin);
            tabMain.Controls.Add(tabKhoaHoc);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(0, 0);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(760, 465);
            tabMain.TabIndex = 0;
            // tabThongTin
            tabThongTin.Controls.Add(lblTenDot);
            tabThongTin.Controls.Add(txtTenDot);
            tabThongTin.Controls.Add(lblBatDau);
            tabThongTin.Controls.Add(dtpBatDau);
            tabThongTin.Controls.Add(lblKetThuc);
            tabThongTin.Controls.Add(dtpKetThuc);
            tabThongTin.Controls.Add(lblTrangThai);
            tabThongTin.Controls.Add(cboTrangThai);
            tabThongTin.Controls.Add(lblMoTa);
            tabThongTin.Controls.Add(txtMoTa);
            tabThongTin.Location = new Point(4, 24);
            tabThongTin.Name = "tabThongTin";
            tabThongTin.Padding = new Padding(3);
            tabThongTin.Size = new Size(752, 437);
            tabThongTin.TabIndex = 0;
            tabThongTin.Text = "Thông Tin Đợt";
            tabThongTin.UseVisualStyleBackColor = true;
            // lblTenDot
            lblTenDot.AutoSize = true;
            lblTenDot.Location = new Point(20, 28);
            lblTenDot.Name = "lblTenDot";
            lblTenDot.Size = new Size(45, 15);
            lblTenDot.Text = "Tên đợt";
            // txtTenDot
            txtTenDot.Location = new Point(130, 25);
            txtTenDot.MaxLength = 150;
            txtTenDot.Name = "txtTenDot";
            txtTenDot.Size = new Size(580, 23);
            txtTenDot.TabIndex = 1;
            // lblBatDau
            lblBatDau.AutoSize = true;
            lblBatDau.Location = new Point(20, 73);
            lblBatDau.Name = "lblBatDau";
            lblBatDau.Size = new Size(77, 15);
            lblBatDau.Text = "Ngày bắt đầu";
            // dtpBatDau
            dtpBatDau.CustomFormat = "dd/MM/yyyy";
            dtpBatDau.Format = DateTimePickerFormat.Custom;
            dtpBatDau.Location = new Point(130, 69);
            dtpBatDau.Name = "dtpBatDau";
            dtpBatDau.Size = new Size(150, 23);
            dtpBatDau.TabIndex = 3;
            // lblKetThuc
            lblKetThuc.AutoSize = true;
            lblKetThuc.Location = new Point(330, 73);
            lblKetThuc.Name = "lblKetThuc";
            lblKetThuc.Size = new Size(79, 15);
            lblKetThuc.Text = "Ngày kết thúc";
            // dtpKetThuc
            dtpKetThuc.CustomFormat = "dd/MM/yyyy";
            dtpKetThuc.Format = DateTimePickerFormat.Custom;
            dtpKetThuc.Location = new Point(420, 69);
            dtpKetThuc.Name = "dtpKetThuc";
            dtpKetThuc.Size = new Size(150, 23);
            dtpKetThuc.TabIndex = 5;
            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(20, 118);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(57, 15);
            lblTrangThai.Text = "Trạng thái";
            // cboTrangThai
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(130, 114);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(200, 23);
            cboTrangThai.TabIndex = 7;
            // lblMoTa
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(20, 163);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(36, 15);
            lblMoTa.Text = "Mô tả";
            // txtMoTa
            txtMoTa.Location = new Point(130, 160);
            txtMoTa.MaxLength = 500;
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(580, 120);
            txtMoTa.TabIndex = 9;
            // tabKhoaHoc
            tabKhoaHoc.Controls.Add(clbKhoaHoc);
            tabKhoaHoc.Controls.Add(lblHuongDan);
            tabKhoaHoc.Location = new Point(4, 24);
            tabKhoaHoc.Name = "tabKhoaHoc";
            tabKhoaHoc.Padding = new Padding(3);
            tabKhoaHoc.Size = new Size(752, 437);
            tabKhoaHoc.TabIndex = 1;
            tabKhoaHoc.Text = "Khóa Học Trong Đợt";
            tabKhoaHoc.UseVisualStyleBackColor = true;
            // lblHuongDan
            lblHuongDan.Dock = DockStyle.Top;
            lblHuongDan.ForeColor = Color.DimGray;
            lblHuongDan.Location = new Point(3, 3);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Padding = new Padding(5, 5, 0, 0);
            lblHuongDan.Size = new Size(746, 45);
            lblHuongDan.Text = "Tích chọn các khóa học được mở trong đợt này. Khóa học đã có hồ sơ hoặc đã được phân công nhân viên thì không bỏ tích được.";
            // clbKhoaHoc
            clbKhoaHoc.CheckOnClick = true;
            clbKhoaHoc.Dock = DockStyle.Fill;
            clbKhoaHoc.FormattingEnabled = true;
            clbKhoaHoc.IntegralHeight = false;
            clbKhoaHoc.Location = new Point(3, 48);
            clbKhoaHoc.Name = "clbKhoaHoc";
            clbKhoaHoc.Size = new Size(746, 386);
            clbKhoaHoc.TabIndex = 0;
            clbKhoaHoc.ItemCheck += clbKhoaHoc_ItemCheck;
            // pnlDuoi
            pnlDuoi.Controls.Add(btnLuu);
            pnlDuoi.Controls.Add(btnDong);
            pnlDuoi.Dock = DockStyle.Bottom;
            pnlDuoi.Location = new Point(0, 465);
            pnlDuoi.Name = "pnlDuoi";
            pnlDuoi.Size = new Size(760, 55);
            pnlDuoi.TabIndex = 1;
            // btnLuu
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.Location = new Point(550, 10);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 34);
            btnLuu.TabIndex = 0;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // btnDong
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDong.Location = new Point(660, 10);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(90, 34);
            btnDong.TabIndex = 1;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // FormDotEdit
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDong;
            ClientSize = new Size(760, 520);
            Controls.Add(tabMain);
            Controls.Add(pnlDuoi);
            MinimizeBox = false;
            MinimumSize = new Size(700, 480);
            Name = "FormDotEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đợt tuyển sinh";
            tabMain.ResumeLayout(false);
            tabThongTin.ResumeLayout(false);
            tabThongTin.PerformLayout();
            tabKhoaHoc.ResumeLayout(false);
            pnlDuoi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabThongTin;
        private Label lblTenDot;
        private TextBox txtTenDot;
        private Label lblBatDau;
        private DateTimePicker dtpBatDau;
        private Label lblKetThuc;
        private DateTimePicker dtpKetThuc;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private TabPage tabKhoaHoc;
        private CheckedListBox clbKhoaHoc;
        private Label lblHuongDan;
        private Panel pnlDuoi;
        private Button btnLuu;
        private Button btnDong;
    }
}