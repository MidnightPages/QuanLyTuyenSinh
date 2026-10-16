#nullable disable
namespace QuanLyTuyenSinh.Controls
{
    partial class ucPhanCongCuaToi
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
            DataGridViewCellStyle styleWrap = new DataGridViewCellStyle();
            DataGridViewCellStyle styleGiua = new DataGridViewCellStyle();
            pnlLoc = new Panel();
            lblDot = new Label();
            cboDot = new ComboBox();
            lblKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
            lblTomTat = new Label();
            dgvPhanCong = new DataGridView();
            colStt = new DataGridViewTextBoxColumn();
            colDot = new DataGridViewTextBoxColumn();
            colKhoaHoc = new DataGridViewTextBoxColumn();
            colNhanVien = new DataGridViewTextBoxColumn();
            colSoHoSo = new DataGridViewTextBoxColumn();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).BeginInit();
            SuspendLayout();
            // pnlLoc
            pnlLoc.Controls.Add(lblDot);
            pnlLoc.Controls.Add(cboDot);
            pnlLoc.Controls.Add(lblKhoaHoc);
            pnlLoc.Controls.Add(cboKhoaHoc);
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
            cboDot.Size = new Size(230, 23);
            cboDot.TabIndex = 0;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            // lblKhoaHoc
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(300, 17);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(54, 15);
            lblKhoaHoc.Text = "Khóa học";
            // cboKhoaHoc
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(360, 13);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(230, 23);
            cboKhoaHoc.TabIndex = 1;
            cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;
            // lblTomTat
            lblTomTat.Dock = DockStyle.Bottom;
            lblTomTat.ForeColor = Color.DimGray;
            lblTomTat.Location = new Point(0, 572);
            lblTomTat.Name = "lblTomTat";
            lblTomTat.Size = new Size(1000, 28);
            lblTomTat.TextAlign = ContentAlignment.MiddleLeft;
            // dgvPhanCong
            dgvPhanCong.AllowUserToAddRows = false;
            dgvPhanCong.AllowUserToDeleteRows = false;
            dgvPhanCong.AllowUserToResizeRows = false;
            dgvPhanCong.AutoGenerateColumns = false;
            dgvPhanCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhanCong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPhanCong.BackgroundColor = Color.White;
            dgvPhanCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhanCong.Columns.AddRange(new DataGridViewColumn[] { colStt, colDot, colKhoaHoc, colNhanVien, colSoHoSo });
            dgvPhanCong.Dock = DockStyle.Fill;
            dgvPhanCong.Location = new Point(0, 50);
            dgvPhanCong.MultiSelect = false;
            dgvPhanCong.Name = "dgvPhanCong";
            dgvPhanCong.ReadOnly = true;
            dgvPhanCong.RowHeadersVisible = false;
            dgvPhanCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanCong.Size = new Size(1000, 522);
            dgvPhanCong.TabIndex = 2;
            // colStt
            styleGiua.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.DefaultCellStyle = styleGiua;
            colStt.FillWeight = 30F;
            colStt.HeaderText = "STT";
            colStt.Name = "colStt";
            colStt.ReadOnly = true;
            // colDot
            colDot.DataPropertyName = "TenDot";
            colDot.FillWeight = 120F;
            colDot.HeaderText = "Đợt Tuyển Sinh";
            colDot.Name = "colDot";
            colDot.ReadOnly = true;
            // colKhoaHoc
            colKhoaHoc.DataPropertyName = "TenKhoaHoc";
            colKhoaHoc.FillWeight = 120F;
            colKhoaHoc.HeaderText = "Khóa Học";
            colKhoaHoc.Name = "colKhoaHoc";
            colKhoaHoc.ReadOnly = true;
            // colNhanVien
            styleWrap.WrapMode = DataGridViewTriState.True;
            colNhanVien.DataPropertyName = "NhanVienPhuTrach";
            colNhanVien.DefaultCellStyle = styleWrap;
            colNhanVien.FillWeight = 230F;
            colNhanVien.HeaderText = "Nhân Viên Phụ Trách";
            colNhanVien.Name = "colNhanVien";
            colNhanVien.ReadOnly = true;
            // colSoHoSo
            colSoHoSo.DataPropertyName = "SoHoSo";
            colSoHoSo.DefaultCellStyle = styleGiua;
            colSoHoSo.FillWeight = 50F;
            colSoHoSo.HeaderText = "Số Hồ Sơ";
            colSoHoSo.Name = "colSoHoSo";
            colSoHoSo.ReadOnly = true;
            // ucPhanCongCuaToi
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvPhanCong);
            Controls.Add(lblTomTat);
            Controls.Add(pnlLoc);
            Name = "ucPhanCongCuaToi";
            Size = new Size(1000, 600);
            Load += ucPhanCongCuaToi_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLoc;
        private Label lblDot;
        private ComboBox cboDot;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
        private Label lblTomTat;
        private DataGridView dgvPhanCong;
        private DataGridViewTextBoxColumn colStt;
        private DataGridViewTextBoxColumn colDot;
        private DataGridViewTextBoxColumn colKhoaHoc;
        private DataGridViewTextBoxColumn colNhanVien;
        private DataGridViewTextBoxColumn colSoHoSo;
    }
}