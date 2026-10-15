#nullable disable
namespace QuanLyTuyenSinh.Controls
{
    partial class ucKhoaHoc
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
            DataGridViewCellStyle styleTien = new DataGridViewCellStyle();
            DataGridViewCellStyle styleGiua = new DataGridViewCellStyle();
            pnlLoc = new Panel();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            dgvKhoaHoc = new DataGridView();
            colStt = new DataGridViewTextBoxColumn();
            colTenKhoaHoc = new DataGridViewTextBoxColumn();
            colHocPhi = new DataGridViewTextBoxColumn();
            colThoiLuong = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colSua = new DataGridViewButtonColumn();
            colXoa = new DataGridViewButtonColumn();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoaHoc).BeginInit();
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
            txtTimKiem.PlaceholderText = "Tên khóa học...";
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
            // dgvKhoaHoc
            dgvKhoaHoc.AllowUserToAddRows = false;
            dgvKhoaHoc.AllowUserToDeleteRows = false;
            dgvKhoaHoc.AllowUserToResizeRows = false;
            dgvKhoaHoc.AutoGenerateColumns = false;
            dgvKhoaHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhoaHoc.BackgroundColor = Color.White;
            dgvKhoaHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoaHoc.Columns.AddRange(new DataGridViewColumn[] { colStt, colTenKhoaHoc, colHocPhi, colThoiLuong, colTrangThai, colSua, colXoa });
            dgvKhoaHoc.Dock = DockStyle.Fill;
            dgvKhoaHoc.Location = new Point(0, 60);
            dgvKhoaHoc.MultiSelect = false;
            dgvKhoaHoc.Name = "dgvKhoaHoc";
            dgvKhoaHoc.ReadOnly = true;
            dgvKhoaHoc.RowHeadersVisible = false;
            dgvKhoaHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoaHoc.Size = new Size(900, 540);
            dgvKhoaHoc.TabIndex = 1;
            dgvKhoaHoc.CellContentClick += dgvKhoaHoc_CellContentClick;
            dgvKhoaHoc.CellDoubleClick += dgvKhoaHoc_CellDoubleClick;
            // colStt
            styleGiua.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.DefaultCellStyle = styleGiua;
            colStt.FillWeight = 30F;
            colStt.HeaderText = "STT";
            colStt.Name = "colStt";
            colStt.ReadOnly = true;
            // colTenKhoaHoc
            colTenKhoaHoc.DataPropertyName = "TenKhoaHoc";
            colTenKhoaHoc.FillWeight = 160F;
            colTenKhoaHoc.HeaderText = "Tên Khóa Học";
            colTenKhoaHoc.Name = "colTenKhoaHoc";
            colTenKhoaHoc.ReadOnly = true;
            // colHocPhi
            styleTien.Alignment = DataGridViewContentAlignment.MiddleRight;
            styleTien.Format = "N0";
            colHocPhi.DataPropertyName = "HocPhi";
            colHocPhi.DefaultCellStyle = styleTien;
            colHocPhi.FillWeight = 80F;
            colHocPhi.HeaderText = "Học Phí (VNĐ)";
            colHocPhi.Name = "colHocPhi";
            colHocPhi.ReadOnly = true;
            // colThoiLuong
            colThoiLuong.DataPropertyName = "ThoiLuong";
            colThoiLuong.FillWeight = 90F;
            colThoiLuong.HeaderText = "Thời Lượng";
            colThoiLuong.Name = "colThoiLuong";
            colThoiLuong.ReadOnly = true;
            // colTrangThai
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.FillWeight = 70F;
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
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
            // ucKhoaHoc
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvKhoaHoc);
            Controls.Add(pnlLoc);
            Name = "ucKhoaHoc";
            Size = new Size(900, 600);
            Load += ucKhoaHoc_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoaHoc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLoc;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private DataGridView dgvKhoaHoc;
        private DataGridViewTextBoxColumn colStt;
        private DataGridViewTextBoxColumn colTenKhoaHoc;
        private DataGridViewTextBoxColumn colHocPhi;
        private DataGridViewTextBoxColumn colThoiLuong;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colSua;
        private DataGridViewButtonColumn colXoa;
    }
}