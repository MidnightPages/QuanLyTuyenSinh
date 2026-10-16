#nullable disable
namespace QuanLyTuyenSinh.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            pnlTop = new Panel();
            tenht = new Label();
            lblNguoiDung = new Label();
            btnDangXuat = new Button();
            flpMenu = new FlowLayoutPanel();
            pnlNoiDung = new Panel();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.WhiteSmoke;
            pnlTop.Controls.Add(tenht);
            pnlTop.Controls.Add(lblNguoiDung);
            pnlTop.Controls.Add(btnDangXuat);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(6, 7, 6, 7);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(2200, 120);
            pnlTop.TabIndex = 0;
            pnlTop.Paint += pnlTop_Paint;
            // 
            // tenht
            // 
            tenht.AutoSize = true;
            tenht.Font = new Font("Lexend", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tenht.ForeColor = Color.MidnightBlue;
            tenht.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            tenht.Location = new Point(40, 26);
            tenht.Margin = new Padding(0);
            tenht.Name = "tenht";
            tenht.Size = new Size(692, 69);
            tenht.TabIndex = 0;
            tenht.Text = "Hệ Thống Quản Lý Tuyển Sinh";
            tenht.TextAlign = ContentAlignment.BottomLeft;
            tenht.Click += tenht_Click;
            // 
            // lblNguoiDung
            // 
            lblNguoiDung.Cursor = Cursors.Hand;
            lblNguoiDung.Dock = DockStyle.Right;
            lblNguoiDung.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNguoiDung.ImageAlign = ContentAlignment.MiddleRight;
            lblNguoiDung.Location = new Point(1530, 0);
            lblNguoiDung.Margin = new Padding(6, 0, 6, 0);
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Padding = new Padding(0, 0, 30, 0);
            lblNguoiDung.Size = new Size(462, 120);
            lblNguoiDung.TabIndex = 0;
            lblNguoiDung.TextAlign = ContentAlignment.MiddleRight;
            lblNguoiDung.Click += lblNguoiDung_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.Gainsboro;
            btnDangXuat.Dock = DockStyle.Right;
            btnDangXuat.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnDangXuat.ForeColor = SystemColors.ControlDarkDark;
            btnDangXuat.Location = new Point(1992, 0);
            btnDangXuat.Margin = new Padding(6, 7, 6, 7);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(208, 120);
            btnDangXuat.TabIndex = 1;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // flpMenu
            // 
            flpMenu.BackColor = SystemColors.ActiveCaption;
            flpMenu.Dock = DockStyle.Left;
            flpMenu.FlowDirection = FlowDirection.TopDown;
            flpMenu.Location = new Point(0, 120);
            flpMenu.Margin = new Padding(6, 7, 6, 7);
            flpMenu.Name = "flpMenu";
            flpMenu.Padding = new Padding(10, 12, 10, 12);
            flpMenu.Size = new Size(400, 1440);
            flpMenu.TabIndex = 1;
            flpMenu.WrapContents = false;
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.BackColor = Color.FromArgb(206, 219, 234);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(400, 120);
            pnlNoiDung.Margin = new Padding(6, 7, 6, 7);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Size = new Size(1800, 1440);
            pnlNoiDung.TabIndex = 2;
            pnlNoiDung.Paint += pnlNoiDung_Paint;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2200, 1560);
            Controls.Add(pnlNoiDung);
            Controls.Add(flpMenu);
            Controls.Add(pnlTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6, 7, 6, 7);
            MinimumSize = new Size(1774, 1221);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý tuyển sinh";
            WindowState = FormWindowState.Maximized;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblNguoiDung;
        private Button btnDangXuat;
        private FlowLayoutPanel flpMenu;
        private Panel pnlNoiDung;
        private Label tenht;
    }
}
