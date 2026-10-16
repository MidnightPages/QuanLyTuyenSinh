#nullable disable
namespace QuanLyTuyenSinh.Controls
{
    partial class ucThongKe
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle styleSo = new DataGridViewCellStyle();
            pnlLoc = new Panel();
            lblDot = new Label();
            cboDot = new ComboBox();
            lblKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
            btnLamMoi = new Button();
            btnXuatCsv = new Button();
            pnlTong = new Panel();
            lblTong = new Label();
            lblChoXuLy = new Label();
            lblDaDuyet = new Label();
            lblDaHuy = new Label();
            lblChiTieu = new Label();
            dgvThongKe = new DataGridView();
            colStt = new DataGridViewTextBoxColumn();
            colDot = new DataGridViewTextBoxColumn();
            colKhoaHoc = new DataGridViewTextBoxColumn();
            colChiTieu = new DataGridViewTextBoxColumn();
            colTong = new DataGridViewTextBoxColumn();
            colChoXuLy = new DataGridViewTextBoxColumn();
            colDaDuyet = new DataGridViewTextBoxColumn();
            colDaHuy = new DataGridViewTextBoxColumn();
            colTyLe = new DataGridViewTextBoxColumn();
            colTyLeChiTieu = new DataGridViewTextBoxColumn();
            pnlLoc.SuspendLayout();
            pnlTong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).BeginInit();
            SuspendLayout();
            // pnlLoc
            pnlLoc.Controls.Add(lblDot);
            pnlLoc.Controls.Add(cboDot);
            pnlLoc.Controls.Add(lblKhoaHoc);
            pnlLoc.Controls.Add(cboKhoaHoc);
            pnlLoc.Controls.Add(btnLamMoi);
            pnlLoc.Controls.Add(btnXuatCsv);
            pnlLoc.Dock = DockStyle.Top;
            pnlLoc.Location = new Point(0, 0);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1000, 50);
            pnlLoc.TabIndex = 0;
            // lblDot
            lblDot.AutoSize = true;
            lblDot.Location = new Point(15, 17);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(26, 15);
            lblDot.Text = "Đợt";
            // cboDot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDot.FormattingEnabled = true;
            cboDot.Location = new Point(50, 13);
            cboDot.Name = "cboDot";
            cboDot.Size = new Size(210, 23);
            cboDot.TabIndex = 0;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            // lblKhoaHoc
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(280, 17);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(54, 15);
            lblKhoaHoc.Text = "Khóa học";
            // cboKhoaHoc
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(340, 13);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(200, 23);
            cboKhoaHoc.TabIndex = 1;
            cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;
            // btnLamMoi
            btnLamMoi.Location = new Point(560, 9);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // btnXuatCsv
            btnXuatCsv.Location = new Point(670, 9);
            btnXuatCsv.Name = "btnXuatCsv";
            btnXuatCsv.Size = new Size(120, 32);
            btnXuatCsv.TabIndex = 3;
            btnXuatCsv.Text = "Xuất Excel";
            btnXuatCsv.UseVisualStyleBackColor = true;
            btnXuatCsv.Click += btnXuatCsv_Click;
            // pnlTong
            pnlTong.Controls.Add(lblTong);
            pnlTong.Controls.Add(lblChoXuLy);
            pnlTong.Controls.Add(lblDaDuyet);
            pnlTong.Controls.Add(lblDaHuy);
            pnlTong.Controls.Add(lblChiTieu);
            pnlTong.Dock = DockStyle.Top;
            pnlTong.Location = new Point(0, 50);
            pnlTong.Name = "pnlTong";
            pnlTong.Size = new Size(1000, 85);
            pnlTong.TabIndex = 1;
            // lblTong
            lblTong.BackColor = Color.AliceBlue;
            lblTong.BorderStyle = BorderStyle.FixedSingle;
            lblTong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTong.Location = new Point(15, 8);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(180, 65);
            lblTong.Text = "Tổng hồ sơ";
            lblTong.TextAlign = ContentAlignment.MiddleCenter;
            // lblChoXuLy
            lblChoXuLy.BackColor = Color.LemonChiffon;
            lblChoXuLy.BorderStyle = BorderStyle.FixedSingle;
            lblChoXuLy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChoXuLy.Location = new Point(205, 8);
            lblChoXuLy.Name = "lblChoXuLy";
            lblChoXuLy.Size = new Size(180, 65);
            lblChoXuLy.Text = "Chờ xử lý";
            lblChoXuLy.TextAlign = ContentAlignment.MiddleCenter;
            // lblDaDuyet
            lblDaDuyet.BackColor = Color.Honeydew;
            lblDaDuyet.BorderStyle = BorderStyle.FixedSingle;
            lblDaDuyet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDaDuyet.Location = new Point(395, 8);
            lblDaDuyet.Name = "lblDaDuyet";
            lblDaDuyet.Size = new Size(180, 65);
            lblDaDuyet.Text = "Đã duyệt";
            lblDaDuyet.TextAlign = ContentAlignment.MiddleCenter;
            // lblDaHuy
            lblDaHuy.BackColor = Color.MistyRose;
            lblDaHuy.BorderStyle = BorderStyle.FixedSingle;
            lblDaHuy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDaHuy.Location = new Point(585, 8);
            lblDaHuy.Name = "lblDaHuy";
            lblDaHuy.Size = new Size(180, 65);
            lblDaHuy.Text = "Đã hủy";
            lblDaHuy.TextAlign = ContentAlignment.MiddleCenter;
            // lblChiTieu
            lblChiTieu.BackColor = Color.Lavender;
            lblChiTieu.BorderStyle = BorderStyle.FixedSingle;
            lblChiTieu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChiTieu.Location = new Point(775, 8);
            lblChiTieu.Name = "lblChiTieu";
            lblChiTieu.Size = new Size(180, 65);
            lblChiTieu.Text = "Đạt chỉ tiêu";
            lblChiTieu.TextAlign = ContentAlignment.MiddleCenter;
            // dgvThongKe
            dgvThongKe.AllowUserToAddRows = false;
            dgvThongKe.AllowUserToDeleteRows = false;
            dgvThongKe.AllowUserToResizeRows = false;
            dgvThongKe.AutoGenerateColumns = false;
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.BackgroundColor = Color.White;
            dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongKe.Columns.AddRange(new DataGridViewColumn[] { colStt, colDot, colKhoaHoc, colChiTieu, colTong, colChoXuLy, colDaDuyet, colDaHuy, colTyLe, colTyLeChiTieu });
            dgvThongKe.Dock = DockStyle.Fill;
            dgvThongKe.Location = new Point(0, 135);
            dgvThongKe.MultiSelect = false;
            dgvThongKe.Name = "dgvThongKe";
            dgvThongKe.ReadOnly = true;
            dgvThongKe.RowHeadersVisible = false;
            dgvThongKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKe.Size = new Size(1000, 465);
            dgvThongKe.TabIndex = 2;
            dgvThongKe.CellFormatting += dgvThongKe_CellFormatting;
            // colStt
            styleSo.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.DefaultCellStyle = styleSo;
            colStt.FillWeight = 28F;
            colStt.HeaderText = "STT";
            colStt.Name = "colStt";
            colStt.ReadOnly = true;
            // colDot
            colDot.DataPropertyName = "TenDot";
            colDot.FillWeight = 110F;
            colDot.HeaderText = "Đợt Tuyển Sinh";
            colDot.Name = "colDot";
            colDot.ReadOnly = true;
            // colKhoaHoc
            colKhoaHoc.DataPropertyName = "TenKhoaHoc";
            colKhoaHoc.FillWeight = 110F;
            colKhoaHoc.HeaderText = "Khóa Học";
            colKhoaHoc.Name = "colKhoaHoc";
            colKhoaHoc.ReadOnly = true;
            // colChiTieu
            colChiTieu.DataPropertyName = "ChiTieu";
            colChiTieu.DefaultCellStyle = styleSo;
            colChiTieu.FillWeight = 55F;
            colChiTieu.HeaderText = "Chỉ Tiêu";
            colChiTieu.Name = "colChiTieu";
            colChiTieu.ReadOnly = true;
            // colTong
            colTong.DataPropertyName = "Tong";
            colTong.DefaultCellStyle = styleSo;
            colTong.FillWeight = 55F;
            colTong.HeaderText = "Tổng Hồ Sơ";
            colTong.Name = "colTong";
            colTong.ReadOnly = true;
            // colChoXuLy
            colChoXuLy.DataPropertyName = "ChoXuLy";
            colChoXuLy.DefaultCellStyle = styleSo;
            colChoXuLy.FillWeight = 55F;
            colChoXuLy.HeaderText = "Chờ Xử Lý";
            colChoXuLy.Name = "colChoXuLy";
            colChoXuLy.ReadOnly = true;
            // colDaDuyet
            colDaDuyet.DataPropertyName = "DaDuyet";
            colDaDuyet.DefaultCellStyle = styleSo;
            colDaDuyet.FillWeight = 55F;
            colDaDuyet.HeaderText = "Đã Duyệt";
            colDaDuyet.Name = "colDaDuyet";
            colDaDuyet.ReadOnly = true;
            // colDaHuy
            colDaHuy.DataPropertyName = "DaHuy";
            colDaHuy.DefaultCellStyle = styleSo;
            colDaHuy.FillWeight = 50F;
            colDaHuy.HeaderText = "Đã Hủy";
            colDaHuy.Name = "colDaHuy";
            colDaHuy.ReadOnly = true;
            // colTyLe
            colTyLe.DataPropertyName = "TyLeDuyet";
            colTyLe.DefaultCellStyle = styleSo;
            colTyLe.FillWeight = 60F;
            colTyLe.HeaderText = "Tỷ Lệ Duyệt";
            colTyLe.Name = "colTyLe";
            colTyLe.ReadOnly = true;
            // colTyLeChiTieu
            colTyLeChiTieu.DataPropertyName = "TyLeDatChiTieu";
            colTyLeChiTieu.DefaultCellStyle = styleSo;
            colTyLeChiTieu.FillWeight = 70F;
            colTyLeChiTieu.HeaderText = "Đạt Chỉ Tiêu";
            colTyLeChiTieu.Name = "colTyLeChiTieu";
            colTyLeChiTieu.ReadOnly = true;
            // ucThongKe
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvThongKe);
            Controls.Add(pnlTong);
            Controls.Add(pnlLoc);
            Name = "ucThongKe";
            Size = new Size(1000, 600);
            Load += ucThongKe_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            pnlTong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLoc;
        private Label lblDot;
        private ComboBox cboDot;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
        private Button btnLamMoi;
        private Button btnXuatCsv;
        private Panel pnlTong;
        private Label lblTong;
        private Label lblChoXuLy;
        private Label lblDaDuyet;
        private Label lblDaHuy;
        private Label lblChiTieu;
        private DataGridView dgvThongKe;
        private DataGridViewTextBoxColumn colStt;
        private DataGridViewTextBoxColumn colDot;
        private DataGridViewTextBoxColumn colKhoaHoc;
        private DataGridViewTextBoxColumn colChiTieu;
        private DataGridViewTextBoxColumn colTong;
        private DataGridViewTextBoxColumn colChoXuLy;
        private DataGridViewTextBoxColumn colDaDuyet;
        private DataGridViewTextBoxColumn colDaHuy;
        private DataGridViewTextBoxColumn colTyLe;
        private DataGridViewTextBoxColumn colTyLeChiTieu;
    }
}