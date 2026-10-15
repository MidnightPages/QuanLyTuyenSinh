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
            DataGridViewCellStyle styleNgay = new DataGridViewCellStyle();
            DataGridViewCellStyle styleGiua = new DataGridViewCellStyle();
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
            // pnlLoc
            pnlLoc.Controls.Add(lblDot);
            pnlLoc.Controls.Add(cboDot);
            pnlLoc.Controls.Add(lblKhoaHoc);
            pnlLoc.Controls.Add(cboKhoaHoc);
            pnlLoc.Controls.Add(lblTrangThai);
            pnlLoc.Controls.Add(cboTrangThai);
            pnlLoc.Controls.Add(txtTimKiem);
            pnlLoc.Dock = DockStyle.Top;
            pnlLoc.Location = new Point(0, 0);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1100, 50);
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
            cboDot.Size = new Size(170, 23);
            cboDot.TabIndex = 0;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            // lblKhoaHoc
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(240, 17);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(54, 15);
            lblKhoaHoc.Text = "Khóa học";
            // cboKhoaHoc
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(300, 13);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(190, 23);
            cboKhoaHoc.TabIndex = 1;
            cboKhoaHoc.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(510, 17);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(57, 15);
            lblTrangThai.Text = "Trạng thái";
            // cboTrangThai
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(575, 13);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(120, 23);
            cboTrangThai.TabIndex = 2;
            cboTrangThai.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
            // txtTimKiem
            txtTimKiem.Location = new Point(715, 13);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tên, SĐT hoặc email...";
            txtTimKiem.Size = new Size(210, 23);
            txtTimKiem.TabIndex = 3;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // pnlThaoTac
            pnlThaoTac.Controls.Add(btnChonTatCa);
            pnlThaoTac.Controls.Add(btnBoChon);
            pnlThaoTac.Controls.Add(btnDuyet);
            pnlThaoTac.Controls.Add(btnHuyHS);
            pnlThaoTac.Controls.Add(btnLuu);
            pnlThaoTac.Controls.Add(btnBoQua);
            pnlThaoTac.Controls.Add(btnThem);
            pnlThaoTac.Dock = DockStyle.Top;
            pnlThaoTac.Location = new Point(0, 50);
            pnlThaoTac.Name = "pnlThaoTac";
            pnlThaoTac.Size = new Size(1100, 50);
            pnlThaoTac.TabIndex = 1;
            // btnChonTatCa
            btnChonTatCa.Location = new Point(10, 8);
            btnChonTatCa.Name = "btnChonTatCa";
            btnChonTatCa.Size = new Size(105, 32);
            btnChonTatCa.TabIndex = 0;
            btnChonTatCa.Text = "Chọn tất cả";
            btnChonTatCa.UseVisualStyleBackColor = true;
            btnChonTatCa.Click += btnChonTatCa_Click;
            // btnBoChon
            btnBoChon.Location = new Point(120, 8);
            btnBoChon.Name = "btnBoChon";
            btnBoChon.Size = new Size(85, 32);
            btnBoChon.TabIndex = 1;
            btnBoChon.Text = "Bỏ chọn";
            btnBoChon.UseVisualStyleBackColor = true;
            btnBoChon.Click += btnBoChon_Click;
            // btnDuyet
            btnDuyet.Location = new Point(215, 8);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(150, 32);
            btnDuyet.TabIndex = 2;
            btnDuyet.Text = "Đánh dấu Đã duyệt";
            btnDuyet.UseVisualStyleBackColor = true;
            btnDuyet.Click += btnDuyet_Click;
            // btnHuyHS
            btnHuyHS.Location = new Point(370, 8);
            btnHuyHS.Name = "btnHuyHS";
            btnHuyHS.Size = new Size(140, 32);
            btnHuyHS.TabIndex = 3;
            btnHuyHS.Text = "Đánh dấu Đã hủy";
            btnHuyHS.UseVisualStyleBackColor = true;
            btnHuyHS.Click += btnHuyHS_Click;
            // btnLuu
            btnLuu.Location = new Point(530, 8);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 32);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // btnBoQua
            btnBoQua.Location = new Point(615, 8);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.Size = new Size(90, 32);
            btnBoQua.TabIndex = 5;
            btnBoQua.Text = "Bỏ thay đổi";
            btnBoQua.UseVisualStyleBackColor = true;
            btnBoQua.Click += btnBoQua_Click;
            // btnThem
            btnThem.Location = new Point(780, 8);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 32);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm hồ sơ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // lblTomTat
            lblTomTat.Dock = DockStyle.Bottom;
            lblTomTat.Location = new Point(0, 572);
            lblTomTat.Name = "lblTomTat";
            lblTomTat.Size = new Size(1100, 28);
            lblTomTat.TextAlign = ContentAlignment.MiddleLeft;
            // dgvHoSo
            dgvHoSo.AllowUserToAddRows = false;
            dgvHoSo.AllowUserToDeleteRows = false;
            dgvHoSo.AllowUserToResizeRows = false;
            dgvHoSo.AutoGenerateColumns = false;
            dgvHoSo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoSo.BackgroundColor = Color.White;
            dgvHoSo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoSo.Columns.AddRange(new DataGridViewColumn[] { colStt, colChon, colHoTen, colSoDienThoai, colEmail, colDot, colKhoaHoc, colNgayDangKy, colTrangThai, colNguoiXacNhan, colGhiChu, colSua, colXoa });
            dgvHoSo.Dock = DockStyle.Fill;
            dgvHoSo.Location = new Point(0, 100);
            dgvHoSo.MultiSelect = false;
            dgvHoSo.Name = "dgvHoSo";
            dgvHoSo.RowHeadersVisible = false;
            dgvHoSo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoSo.Size = new Size(1100, 472);
            dgvHoSo.TabIndex = 2;
            dgvHoSo.CellBeginEdit += dgvHoSo_CellBeginEdit;
            dgvHoSo.CellContentClick += dgvHoSo_CellContentClick;
            dgvHoSo.CellDoubleClick += dgvHoSo_CellDoubleClick;
            dgvHoSo.CellFormatting += dgvHoSo_CellFormatting;
            dgvHoSo.CurrentCellDirtyStateChanged += dgvHoSo_CurrentCellDirtyStateChanged;
            // colStt
            styleGiua.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.DefaultCellStyle = styleGiua;
            colStt.FillWeight = 30F;
            colStt.HeaderText = "STT";
            colStt.Name = "colStt";
            colStt.ReadOnly = true;
            // colChon
            colChon.DataPropertyName = "Chon";
            colChon.FillWeight = 30F;
            colChon.HeaderText = "Chọn";
            colChon.Name = "colChon";
            // colHoTen
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 100F;
            colHoTen.HeaderText = "Họ Tên";
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            // colSoDienThoai
            colSoDienThoai.DataPropertyName = "SoDienThoai";
            colSoDienThoai.FillWeight = 75F;
            colSoDienThoai.HeaderText = "Số Điện Thoại";
            colSoDienThoai.Name = "colSoDienThoai";
            colSoDienThoai.ReadOnly = true;
            // colEmail
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 115F;
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // colDot
            colDot.DataPropertyName = "TenDot";
            colDot.FillWeight = 80F;
            colDot.HeaderText = "Đợt";
            colDot.Name = "colDot";
            colDot.ReadOnly = true;
            // colKhoaHoc
            colKhoaHoc.DataPropertyName = "TenKhoaHoc";
            colKhoaHoc.FillWeight = 80F;
            colKhoaHoc.HeaderText = "Khóa Học";
            colKhoaHoc.Name = "colKhoaHoc";
            colKhoaHoc.ReadOnly = true;
            // colNgayDangKy
            styleNgay.Format = "dd/MM/yyyy HH:mm";
            colNgayDangKy.DataPropertyName = "NgayDangKy";
            colNgayDangKy.DefaultCellStyle = styleNgay;
            colNgayDangKy.FillWeight = 90F;
            colNgayDangKy.HeaderText = "Ngày Đăng Ký";
            colNgayDangKy.Name = "colNgayDangKy";
            colNgayDangKy.ReadOnly = true;
            // colTrangThai
            colTrangThai.DataPropertyName = "TrangThaiHoSo";
            colTrangThai.FillWeight = 70F;
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // colNguoiXacNhan
            colNguoiXacNhan.DataPropertyName = "TenNhanVienXacNhan";
            colNguoiXacNhan.FillWeight = 90F;
            colNguoiXacNhan.HeaderText = "Người Xác Nhận";
            colNguoiXacNhan.Name = "colNguoiXacNhan";
            colNguoiXacNhan.ReadOnly = true;
            // colGhiChu
            colGhiChu.DataPropertyName = "GhiChu";
            colGhiChu.FillWeight = 100F;
            colGhiChu.HeaderText = "Ghi Chú";
            colGhiChu.Name = "colGhiChu";
            colGhiChu.ReadOnly = true;
            // colSua
            colSua.FillWeight = 38F;
            colSua.HeaderText = "Thao Tác";
            colSua.Name = "colSua";
            colSua.Text = "Sửa";
            colSua.UseColumnTextForButtonValue = true;
            // colXoa
            colXoa.FillWeight = 38F;
            colXoa.HeaderText = "";
            colXoa.Name = "colXoa";
            colXoa.Text = "Xóa";
            colXoa.UseColumnTextForButtonValue = true;
            // ucHoSo
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvHoSo);
            Controls.Add(lblTomTat);
            Controls.Add(pnlThaoTac);
            Controls.Add(pnlLoc);
            Name = "ucHoSo";
            Size = new Size(1100, 600);
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