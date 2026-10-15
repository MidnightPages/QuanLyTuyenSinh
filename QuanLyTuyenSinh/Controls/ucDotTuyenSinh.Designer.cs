#nullable disable
namespace QuanLyTuyenSinh.Controls
{
    partial class ucDotTuyenSinh
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
            DataGridViewCellStyle styleNgay = new DataGridViewCellStyle();
            DataGridViewCellStyle styleGiua = new DataGridViewCellStyle();
            pnlLoc = new Panel();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            dgvDot = new DataGridView();
            colStt = new DataGridViewTextBoxColumn();
            colTenDot = new DataGridViewTextBoxColumn();
            colNgayBatDau = new DataGridViewTextBoxColumn();
            colNgayKetThuc = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colSoKhoaHoc = new DataGridViewTextBoxColumn();
            colSoHoSo = new DataGridViewTextBoxColumn();
            colSua = new DataGridViewButtonColumn();
            colXoa = new DataGridViewButtonColumn();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDot).BeginInit();
            SuspendLayout();
            // pnlLoc
            pnlLoc.Controls.Add(lblTimKiem);
            pnlLoc.Controls.Add(txtTimKiem);
            pnlLoc.Controls.Add(lblTrangThai);
            pnlLoc.Controls.Add(cboTrangThai);
            pnlLoc.Controls.Add(btnThem);
            pnlLoc.Dock = DockStyle.Top;
            pnlLoc.Location = new Point(0, 0);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(900, 60);
            pnlLoc.TabIndex = 0;
            // lblTimKiem
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(15, 22);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(58, 15);
            lblTimKiem.Text = "Tìm kiếm";
            // txtTimKiem
            txtTimKiem.Location = new Point(85, 18);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tên đợt tuyển sinh...";
            txtTimKiem.Size = new Size(200, 23);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(305, 22);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(57, 15);
            lblTrangThai.Text = "Trạng thái";
            // cboTrangThai
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(375, 18);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(140, 23);
            cboTrangThai.TabIndex = 3;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            // btnThem
            btnThem.Location = new Point(545, 14);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // dgvDot
            dgvDot.AllowUserToAddRows = false;
            dgvDot.AllowUserToDeleteRows = false;
            dgvDot.AllowUserToResizeRows = false;
            dgvDot.AutoGenerateColumns = false;
            dgvDot.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDot.BackgroundColor = Color.White;
            dgvDot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDot.Columns.AddRange(new DataGridViewColumn[] { colStt, colTenDot, colNgayBatDau, colNgayKetThuc, colTrangThai, colSoKhoaHoc, colSoHoSo, colSua, colXoa });
            dgvDot.Dock = DockStyle.Fill;
            dgvDot.Location = new Point(0, 60);
            dgvDot.MultiSelect = false;
            dgvDot.Name = "dgvDot";
            dgvDot.ReadOnly = true;
            dgvDot.RowHeadersVisible = false;
            dgvDot.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDot.Size = new Size(900, 540);
            dgvDot.TabIndex = 1;
            dgvDot.CellContentClick += dgvDot_CellContentClick;
            dgvDot.CellDoubleClick += dgvDot_CellDoubleClick;
            // colStt
            styleGiua.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.DefaultCellStyle = styleGiua;
            colStt.FillWeight = 30F;
            colStt.HeaderText = "STT";
            colStt.Name = "colStt";
            colStt.ReadOnly = true;
            // colTenDot
            colTenDot.DataPropertyName = "TenDot";
            colTenDot.FillWeight = 150F;
            colTenDot.HeaderText = "Tên Đợt";
            colTenDot.Name = "colTenDot";
            colTenDot.ReadOnly = true;
            // colNgayBatDau
            styleNgay.Format = "dd/MM/yyyy";
            colNgayBatDau.DataPropertyName = "NgayBatDau";
            colNgayBatDau.DefaultCellStyle = styleNgay;
            colNgayBatDau.FillWeight = 80F;
            colNgayBatDau.HeaderText = "Ngày Bắt Đầu";
            colNgayBatDau.Name = "colNgayBatDau";
            colNgayBatDau.ReadOnly = true;
            // colNgayKetThuc
            colNgayKetThuc.DataPropertyName = "NgayKetThuc";
            colNgayKetThuc.DefaultCellStyle = styleNgay;
            colNgayKetThuc.FillWeight = 80F;
            colNgayKetThuc.HeaderText = "Ngày Kết Thúc";
            colNgayKetThuc.Name = "colNgayKetThuc";
            colNgayKetThuc.ReadOnly = true;
            // colTrangThai
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.FillWeight = 85F;
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // colSoKhoaHoc
            colSoKhoaHoc.DataPropertyName = "SoKhoaHoc";
            colSoKhoaHoc.DefaultCellStyle = styleGiua;
            colSoKhoaHoc.FillWeight = 60F;
            colSoKhoaHoc.HeaderText = "Số Khóa Học";
            colSoKhoaHoc.Name = "colSoKhoaHoc";
            colSoKhoaHoc.ReadOnly = true;
            // colSoHoSo
            colSoHoSo.DataPropertyName = "SoHoSo";
            colSoHoSo.DefaultCellStyle = styleGiua;
            colSoHoSo.FillWeight = 55F;
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
            colXoa.FillWeight = 40F;
            colXoa.HeaderText = "";
            colXoa.Name = "colXoa";
            colXoa.Text = "Xóa";
            colXoa.UseColumnTextForButtonValue = true;
            // ucDotTuyenSinh
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvDot);
            Controls.Add(pnlLoc);
            Name = "ucDotTuyenSinh";
            Size = new Size(900, 600);
            Load += ucDotTuyenSinh_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDot).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLoc;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private DataGridView dgvDot;
        private DataGridViewTextBoxColumn colStt;
        private DataGridViewTextBoxColumn colTenDot;
        private DataGridViewTextBoxColumn colNgayBatDau;
        private DataGridViewTextBoxColumn colNgayKetThuc;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewTextBoxColumn colSoKhoaHoc;
        private DataGridViewTextBoxColumn colSoHoSo;
        private DataGridViewButtonColumn colSua;
        private DataGridViewButtonColumn colXoa;
    }
}