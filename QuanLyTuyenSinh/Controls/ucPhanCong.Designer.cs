#nullable disable
namespace QuanLyTuyenSinh.Controls
{
    partial class ucPhanCong
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
            lblGhiChu = new Label();
            dgvPhanCong = new DataGridView();
            colStt = new DataGridViewTextBoxColumn();
            colKhoaHoc = new DataGridViewTextBoxColumn();
            colNhanVien = new DataGridViewTextBoxColumn();
            colSoHoSo = new DataGridViewTextBoxColumn();
            colSua = new DataGridViewButtonColumn();
            colXoa = new DataGridViewButtonColumn();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).BeginInit();
            SuspendLayout();
            // pnlLoc
            pnlLoc.Controls.Add(lblDot);
            pnlLoc.Controls.Add(cboDot);
            pnlLoc.Controls.Add(lblGhiChu);
            pnlLoc.Dock = DockStyle.Top;
            pnlLoc.Location = new Point(0, 0);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1000, 50);
            pnlLoc.TabIndex = 0;
            // lblDot
            lblDot.AutoSize = true;
            lblDot.Location = new Point(15, 17);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(79, 15);
            lblDot.Text = "Đợt tuyển sinh";
            // cboDot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDot.FormattingEnabled = true;
            cboDot.Location = new Point(105, 13);
            cboDot.Name = "cboDot";
            cboDot.Size = new Size(280, 23);
            cboDot.TabIndex = 0;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            // lblGhiChu
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Location = new Point(405, 17);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(560, 20);
            // dgvPhanCong
            dgvPhanCong.AllowUserToAddRows = false;
            dgvPhanCong.AllowUserToDeleteRows = false;
            dgvPhanCong.AllowUserToResizeRows = false;
            dgvPhanCong.AutoGenerateColumns = false;
            dgvPhanCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhanCong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPhanCong.BackgroundColor = Color.White;
            dgvPhanCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhanCong.Columns.AddRange(new DataGridViewColumn[] { colStt, colKhoaHoc, colNhanVien, colSoHoSo, colSua, colXoa });
            dgvPhanCong.Dock = DockStyle.Fill;
            dgvPhanCong.Location = new Point(0, 50);
            dgvPhanCong.MultiSelect = false;
            dgvPhanCong.Name = "dgvPhanCong";
            dgvPhanCong.ReadOnly = true;
            dgvPhanCong.RowHeadersVisible = false;
            dgvPhanCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanCong.Size = new Size(1000, 550);
            dgvPhanCong.TabIndex = 1;
            dgvPhanCong.CellContentClick += dgvPhanCong_CellContentClick;
            // colStt
            styleGiua.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.DefaultCellStyle = styleGiua;
            colStt.FillWeight = 30F;
            colStt.HeaderText = "STT";
            colStt.Name = "colStt";
            colStt.ReadOnly = true;
            // colKhoaHoc
            colKhoaHoc.DataPropertyName = "TenKhoaHoc";
            colKhoaHoc.FillWeight = 110F;
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
            colSoHoSo.FillWeight = 45F;
            colSoHoSo.HeaderText = "Số Hồ Sơ";
            colSoHoSo.Name = "colSoHoSo";
            colSoHoSo.ReadOnly = true;
            // colSua
            colSua.FillWeight = 40F;
            colSua.HeaderText = "Thao Tác";
            colSua.Name = "colSua";
            colSua.Text = "Sửa";
            colSua.UseColumnTextForButtonValue = true;
            // colXoa
            colXoa.FillWeight = 48F;
            colXoa.HeaderText = "";
            colXoa.Name = "colXoa";
            colXoa.Text = "Xóa hết";
            colXoa.UseColumnTextForButtonValue = true;
            // ucPhanCong
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvPhanCong);
            Controls.Add(pnlLoc);
            Name = "ucPhanCong";
            Size = new Size(1000, 600);
            Load += ucPhanCong_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLoc;
        private Label lblDot;
        private ComboBox cboDot;
        private Label lblGhiChu;
        private DataGridView dgvPhanCong;
        private DataGridViewTextBoxColumn colStt;
        private DataGridViewTextBoxColumn colKhoaHoc;
        private DataGridViewTextBoxColumn colNhanVien;
        private DataGridViewTextBoxColumn colSoHoSo;
        private DataGridViewButtonColumn colSua;
        private DataGridViewButtonColumn colXoa;
    }
}