#nullable disable
namespace QuanLyTuyenSinh.Controls
{
    partial class ucHoSo
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlLoc = new Panel();
            lblDot = new Label();
            cboDot = new ComboBox();
            lblKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            txtTimKiem = new TextBox();
            pnlThaoTac = new Panel();
            btnChonTatCa = new Button();
            btnBoChon = new Button();
            btnDuyet = new Button();
            btnHuyHS = new Button();
            btnLuu = new Button();
            btnBoQua = new Button();
            btnThem = new Button();
            btnXuatDanhSach = new Button();
            lblTomTat = new Label();
            dgvHoSo = new DataGridView();
            colStt = new DataGridViewTextBoxColumn();
            colChon = new DataGridViewCheckBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colSoDienThoai = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDot = new DataGridViewTextBoxColumn();
            colKhoaHoc = new DataGridViewTextBoxColumn();
            colNgayDangKy = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colNguoiXacNhan = new DataGridViewTextBoxColumn();
            colGhiChu = new DataGridViewTextBoxColumn();
            colSua = new DataGridViewButtonColumn();
            colXoa = new DataGridViewButtonColumn();
            pnlLoc.SuspendLayout();
            pnlThaoTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoSo).BeginInit();
            SuspendLayout();
            // 
            // pnlLoc
            // 
            pnlLoc.Controls.Add(lblDot);
            pnlLoc.Controls.Add(cboDot);
            pnlLoc.Controls.Add(lblKhoaHoc);
            pnlLoc.Controls.Add(cboKhoaHoc);
            pnlLoc.Controls.Add(lblTrangThai);
            pnlLoc.Controls.Add(cboTrangThai);
            pnlLoc.Controls.Add(txtTimKiem);
            pnlLoc.Dock = DockStyle.Top;
            pnlLoc.Location = new Point(0, 0);
            pnlLoc.Margin = new Padding(6, 7, 6, 7);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(2200, 120);
            pnlLoc.TabIndex = 0;
            // 
            // lblDot
            // 
            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            lblDot.Location = new Point(40, 41);
            lblDot.Margin = new Padding(6, 0, 6, 0);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(198, 37);
            lblDot.TabIndex = 0;
            lblDot.Text = "Đợt tuyển sinh";
            // 
            // cboDot
            // 
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDot.FormattingEnabled = true;
            cboDot.Location = new Point(240, 38);
            cboDot.Margin = new Padding(6, 7, 6, 7);
            cboDot.Name = "cboDot";
            cboDot.Size = new Size(336, 44);
            cboDot.TabIndex = 0;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            lblKhoaHoc.Location = new Point(605, 41);
            lblKhoaHoc.Margin = new Padding(6, 0, 6, 0);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(132, 37);
            lblKhoaHoc.TabIndex = 1;
            lblKhoaHoc.Text = "Khóa học";
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(740, 38);
            cboKhoaHoc.Margin = new Padding(6, 7, 6, 7);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(376, 44);
            cboKhoaHoc.TabIndex = 1;
            cboKhoaHoc.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            lblTrangThai.Location = new Point(1146, 41);
            lblTrangThai.Margin = new Padding(6, 0, 6, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(140, 37);
            lblTrangThai.TabIndex = 2;
            lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(1290, 38);
            cboTrangThai.Margin = new Padding(6, 7, 6, 7);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(236, 44);
            cboTrangThai.TabIndex = 2;
            cboTrangThai.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(1724, 38);
            txtTimKiem.Margin = new Padding(6, 7, 6, 7);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tên, SĐT hoặc email...";
            txtTimKiem.Size = new Size(416, 42);
            txtTimKiem.TabIndex = 3;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // pnlThaoTac
            // 
            pnlThaoTac.Controls.Add(btnChonTatCa);
            pnlThaoTac.Controls.Add(btnBoChon);
            pnlThaoTac.Controls.Add(btnDuyet);
            pnlThaoTac.Controls.Add(btnHuyHS);
            pnlThaoTac.Controls.Add(btnLuu);
            pnlThaoTac.Controls.Add(btnBoQua);
            pnlThaoTac.Controls.Add(btnThem);
            pnlThaoTac.Controls.Add(btnXuatDanhSach);
            pnlThaoTac.Dock = DockStyle.Top;
            pnlThaoTac.Location = new Point(0, 120);
            pnlThaoTac.Margin = new Padding(6, 7, 6, 7);
            pnlThaoTac.Name = "pnlThaoTac";
            pnlThaoTac.Size = new Size(2200, 120);
            pnlThaoTac.TabIndex = 1;
            // 
            // btnChonTatCa
            // 
            btnChonTatCa.Location = new Point(60, 19);
            btnChonTatCa.Margin = new Padding(6, 7, 6, 7);
            btnChonTatCa.Name = "btnChonTatCa";
            btnChonTatCa.Size = new Size(210, 77);
            btnChonTatCa.TabIndex = 0;
            btnChonTatCa.Text = "Chọn tất cả";
            btnChonTatCa.UseVisualStyleBackColor = true;
            btnChonTatCa.Click += btnChonTatCa_Click;
            // 
            // btnBoChon
            // 
            btnBoChon.Location = new Point(280, 19);
            btnBoChon.Margin = new Padding(6, 7, 6, 7);
            btnBoChon.Name = "btnBoChon";
            btnBoChon.Size = new Size(170, 77);
            btnBoChon.TabIndex = 1;
            btnBoChon.Text = "Bỏ chọn";
            btnBoChon.UseVisualStyleBackColor = true;
            btnBoChon.Click += btnBoChon_Click;
            // 
            // btnDuyet
            // 
            btnDuyet.Location = new Point(730, 30);
            btnDuyet.Margin = new Padding(6, 7, 6, 7);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(200, 60);
            btnDuyet.BackColor = ColorTranslator.FromHtml("#E5F0FE");
            btnDuyet.ForeColor = Color.Black;
            btnDuyet.FlatStyle = FlatStyle.Flat;  
            btnDuyet.TabIndex = 2;
            btnDuyet.Text = "Duyệt hồ sơ";
            btnDuyet.UseVisualStyleBackColor = true;

            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnHuyHS
            // 
            btnHuyHS.Location = new Point(950, 30);
            btnHuyHS.Margin = new Padding(6, 7, 6, 7);
            btnHuyHS.Name = "btnHuyHS";
            btnHuyHS.Size = new Size(200, 60);
            btnHuyHS.BackColor = ColorTranslator.FromHtml("#E5F0FE");
            btnHuyHS.ForeColor = Color.Black;
            btnHuyHS.FlatStyle = FlatStyle.Flat;
            btnHuyHS.TabIndex = 3;
            btnHuyHS.Text = "Hủy hồ sơ";
            btnHuyHS.UseVisualStyleBackColor = true;
            btnHuyHS.Click += btnHuyHS_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(1190, 19);
            btnLuu.Margin = new Padding(6, 7, 6, 7);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(160, 77);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnBoQua
            // 
            btnBoQua.Location = new Point(1360, 19);
            btnBoQua.Margin = new Padding(6, 7, 6, 7);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.Size = new Size(180, 77);
            btnBoQua.TabIndex = 5;
            btnBoQua.Text = "Bỏ thay đổi";
            btnBoQua.UseVisualStyleBackColor = true;
            btnBoQua.Click += btnBoQua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(1900, 19);
            btnThem.Margin = new Padding(6, 7, 6, 7);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(240, 77);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm hồ sơ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXuatDanhSach
            // 
            btnXuatDanhSach.Location = new Point(1650, 19);
            btnXuatDanhSach.Margin = new Padding(6, 7, 6, 7);
            btnXuatDanhSach.Name = "btnXuatDanhSach";
            btnXuatDanhSach.Size = new Size(230, 77);
            btnXuatDanhSach.TabIndex = 7;
            btnXuatDanhSach.Text = "Xuất danh sách";
            btnXuatDanhSach.UseVisualStyleBackColor = true;
            btnXuatDanhSach.Click += btnXuatDanhSach_Click;
            // 
            // lblTomTat
            // 
            lblTomTat.Dock = DockStyle.Bottom;
            lblTomTat.Location = new Point(0, 1373);
            lblTomTat.Margin = new Padding(6, 0, 6, 0);
            lblTomTat.Name = "lblTomTat";
            lblTomTat.Size = new Size(2200, 67);
            lblTomTat.TabIndex = 3;
            lblTomTat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvHoSo
            // 
            dgvHoSo.AllowUserToAddRows = false;
            dgvHoSo.AllowUserToDeleteRows = false;
            dgvHoSo.AllowUserToResizeRows = false;
            dgvHoSo.AutoGenerateColumns = false;
            dgvHoSo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoSo.BackgroundColor = Color.White;
            dgvHoSo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoSo.Columns.AddRange(new DataGridViewColumn[] { colStt, colChon, colHoTen, colSoDienThoai, colEmail, colDot, colKhoaHoc, colNgayDangKy, colTrangThai, colNguoiXacNhan, colGhiChu, colSua, colXoa });
            dgvHoSo.Dock = DockStyle.Fill;
            dgvHoSo.Location = new Point(0, 240);
            dgvHoSo.Margin = new Padding(6, 7, 6, 7);
            dgvHoSo.MultiSelect = false;
            dgvHoSo.Name = "dgvHoSo";
            dgvHoSo.RowHeadersVisible = false;
            dgvHoSo.RowHeadersWidth = 82;
            dgvHoSo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoSo.Size = new Size(2200, 1133);
            dgvHoSo.TabIndex = 2;
            dgvHoSo.CellBeginEdit += dgvHoSo_CellBeginEdit;
            dgvHoSo.CellContentClick += dgvHoSo_CellContentClick;
            dgvHoSo.CellDoubleClick += dgvHoSo_CellDoubleClick;
            dgvHoSo.CellFormatting += dgvHoSo_CellFormatting;
            dgvHoSo.CurrentCellDirtyStateChanged += dgvHoSo_CurrentCellDirtyStateChanged;
            // 
            // colStt
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.DefaultCellStyle = dataGridViewCellStyle1;
            colStt.FillWeight = 30F;
            colStt.HeaderText = "STT";
            colStt.MinimumWidth = 10;
            colStt.Name = "colStt";
            colStt.ReadOnly = true;
            // 
            // colChon
            // 
            colChon.DataPropertyName = "Chon";
            colChon.FillWeight = 30F;
            colChon.HeaderText = "Chọn";
            colChon.MinimumWidth = 10;
            colChon.Name = "colChon";
            // 
            // colHoTen
            // 
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 100F;
            colHoTen.HeaderText = "Họ Tên";
            colHoTen.MinimumWidth = 10;
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            // 
            // colSoDienThoai
            // 
            colSoDienThoai.DataPropertyName = "SoDienThoai";
            colSoDienThoai.FillWeight = 75F;
            colSoDienThoai.HeaderText = "Số Điện Thoại";
            colSoDienThoai.MinimumWidth = 10;
            colSoDienThoai.Name = "colSoDienThoai";
            colSoDienThoai.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 115F;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 10;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colDot
            // 
            colDot.DataPropertyName = "TenDot";
            colDot.FillWeight = 80F;
            colDot.HeaderText = "Đợt";
            colDot.MinimumWidth = 10;
            colDot.Name = "colDot";
            colDot.ReadOnly = true;
            // 
            // colKhoaHoc
            // 
            colKhoaHoc.DataPropertyName = "TenKhoaHoc";
            colKhoaHoc.FillWeight = 80F;
            colKhoaHoc.HeaderText = "Khóa Học";
            colKhoaHoc.MinimumWidth = 10;
            colKhoaHoc.Name = "colKhoaHoc";
            colKhoaHoc.ReadOnly = true;
            // 
            // colNgayDangKy
            // 
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm";
            colNgayDangKy.DataPropertyName = "NgayDangKy";
            colNgayDangKy.DefaultCellStyle = dataGridViewCellStyle2;
            colNgayDangKy.FillWeight = 90F;
            colNgayDangKy.HeaderText = "Ngày Đăng Ký";
            colNgayDangKy.MinimumWidth = 10;
            colNgayDangKy.Name = "colNgayDangKy";
            colNgayDangKy.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThaiHoSo";
            colTrangThai.FillWeight = 70F;
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.MinimumWidth = 10;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // 
            // colNguoiXacNhan
            // 
            colNguoiXacNhan.DataPropertyName = "TenNhanVienXacNhan";
            colNguoiXacNhan.FillWeight = 90F;
            colNguoiXacNhan.HeaderText = "Người Xác Nhận";
            colNguoiXacNhan.MinimumWidth = 10;
            colNguoiXacNhan.Name = "colNguoiXacNhan";
            colNguoiXacNhan.ReadOnly = true;
            // 
            // colGhiChu
            // 
            colGhiChu.DataPropertyName = "GhiChu";
            colGhiChu.FillWeight = 100F;
            colGhiChu.HeaderText = "Ghi Chú";
            colGhiChu.MinimumWidth = 10;
            colGhiChu.Name = "colGhiChu";
            colGhiChu.ReadOnly = true;
            // 
            // colSua
            // 
            colSua.FillWeight = 38F;
            colSua.HeaderText = "Thao Tác";
            colSua.MinimumWidth = 10;
            colSua.Name = "colSua";
            colSua.Text = "Sửa";
            colSua.UseColumnTextForButtonValue = true;
            // 
            // colXoa
            // 
            colXoa.FillWeight = 38F;
            colXoa.HeaderText = "";
            colXoa.MinimumWidth = 10;
            colXoa.Name = "colXoa";
            colXoa.Text = "Xóa";
            colXoa.UseColumnTextForButtonValue = true;
            // 
            // ucHoSo
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvHoSo);
            Controls.Add(lblTomTat);
            Controls.Add(pnlThaoTac);
            Controls.Add(pnlLoc);
            Margin = new Padding(6, 7, 6, 7);
            Name = "ucHoSo";
            Size = new Size(2200, 1440);
            Load += ucHoSo_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            pnlThaoTac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoSo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLoc;
        private Label lblDot;
        private ComboBox cboDot;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private TextBox txtTimKiem;
        private Panel pnlThaoTac;
        private Button btnChonTatCa;
        private Button btnBoChon;
        private Button btnDuyet;
        private Button btnHuyHS;
        private Button btnLuu;
        private Button btnBoQua;
        private Button btnThem;
        private Button btnXuatDanhSach;
        private Label lblTomTat;
        private DataGridView dgvHoSo;
        private DataGridViewTextBoxColumn colStt;
        private DataGridViewCheckBoxColumn colChon;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDot;
        private DataGridViewTextBoxColumn colKhoaHoc;
        private DataGridViewTextBoxColumn colNgayDangKy;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewTextBoxColumn colNguoiXacNhan;
        private DataGridViewTextBoxColumn colGhiChu;
        private DataGridViewButtonColumn colSua;
        private DataGridViewButtonColumn colXoa;
    }
}