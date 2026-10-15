#nullable disable
namespace QuanLyTuyenSinh.Controls
{
    partial class ucNhanVien
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
            DataGridViewCellStyle styleGiua = new DataGridViewCellStyle();
            pnlLoc = new Panel();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            dgvNhanVien = new DataGridView();
            colStt = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colTenDangNhap = new DataGridViewTextBoxColumn();
            colVaiTro = new DataGridViewTextBoxColumn();
            colSoDienThoai = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colSua = new DataGridViewButtonColumn();
            colXoa = new DataGridViewButtonColumn();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
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
            pnlLoc.Size = new Size(1000, 60);
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
            txtTimKiem.PlaceholderText = "Họ tên hoặc tên đăng nhập...";
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
            cboTrangThai.Size = new Size(130, 23);
            cboTrangThai.TabIndex = 3;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            // btnThem
            btnThem.Location = new Point(525, 14);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // dgvNhanVien
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.AllowUserToResizeRows = false;
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] { colStt, colHoTen, colTenDangNhap, colVaiTro, colSoDienThoai, colTrangThai, colSua, colXoa });
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(0, 60);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(1000, 540);
            dgvNhanVien.TabIndex = 1;
            dgvNhanVien.CellContentClick += dgvNhanVien_CellContentClick;
            dgvNhanVien.CellDoubleClick += dgvNhanVien_CellDoubleClick;
            // colStt
            styleGiua.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.DefaultCellStyle = styleGiua;
            colStt.FillWeight = 30F;
            colStt.HeaderText = "STT";
            colStt.Name = "colStt";
            colStt.ReadOnly = true;
            // colHoTen
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 130F;
            colHoTen.HeaderText = "Họ Tên";
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            // colTenDangNhap
            colTenDangNhap.DataPropertyName = "TenDangNhap";
            colTenDangNhap.FillWeight = 90F;
            colTenDangNhap.HeaderText = "Tên Đăng Nhập";
            colTenDangNhap.Name = "colTenDangNhap";
            colTenDangNhap.ReadOnly = true;
            // colVaiTro
            colVaiTro.DataPropertyName = "VaiTro";
            colVaiTro.FillWeight = 90F;
            colVaiTro.HeaderText = "Vai Trò";
            colVaiTro.Name = "colVaiTro";
            colVaiTro.ReadOnly = true;
            // colSoDienThoai
            colSoDienThoai.DataPropertyName = "SoDienThoai";
            colSoDienThoai.FillWeight = 80F;
            colSoDienThoai.HeaderText = "Số Điện Thoại";
            colSoDienThoai.Name = "colSoDienThoai";
            colSoDienThoai.ReadOnly = true;
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
            // ucNhanVien
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvNhanVien);
            Controls.Add(pnlLoc);
            Name = "ucNhanVien";
            Size = new Size(1000, 600);
            Load += ucNhanVien_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLoc;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private DataGridView dgvNhanVien;
        private DataGridViewTextBoxColumn colStt;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colTenDangNhap;
        private DataGridViewTextBoxColumn colVaiTro;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colSua;
        private DataGridViewButtonColumn colXoa;
    }
}