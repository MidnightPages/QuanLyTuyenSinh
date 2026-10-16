namespace QuanLyTuyenSinh.Forms
{
    partial class FormDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            tieude = new Label();
            tendn = new Label();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            mkdn = new Label();
            btnDangNhap = new Button();
            btnThoat = new Button();
            lblThongBao = new Label();
            groupBox1 = new GroupBox();
            btnDemoHung = new Button();
            btnDemoLan = new Button();
            btnDemoAdmin = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tieude
            // 
            resources.ApplyResources(tieude, "tieude");
            tieude.Name = "tieude";
            // 
            // tendn
            // 
            resources.ApplyResources(tendn, "tendn");
            tendn.Name = "tendn";
            // 
            // txtTenDangNhap
            // 
            resources.ApplyResources(txtTenDangNhap, "txtTenDangNhap");
            txtTenDangNhap.Name = "txtTenDangNhap";
            // 
            // txtMatKhau
            // 
            resources.ApplyResources(txtMatKhau, "txtMatKhau");
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // mkdn
            // 
            resources.ApplyResources(mkdn, "mkdn");
            mkdn.Name = "mkdn";
            // 
            // btnDangNhap
            // 
            resources.ApplyResources(btnDangNhap, "btnDangNhap");
            btnDangNhap.BackColor = SystemColors.ActiveCaption;
            btnDangNhap.ForeColor = SystemColors.ActiveCaptionText;
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnThoat
            // 
            resources.ApplyResources(btnThoat, "btnThoat");
            btnThoat.BackColor = SystemColors.ActiveCaption;
            btnThoat.ForeColor = SystemColors.ActiveCaptionText;
            btnThoat.Name = "btnThoat";
            btnThoat.TabStop = false;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // lblThongBao
            // 
            resources.ApplyResources(lblThongBao, "lblThongBao");
            lblThongBao.ForeColor = Color.Firebrick;
            lblThongBao.Name = "lblThongBao";
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = Color.WhiteSmoke;
            groupBox1.Controls.Add(btnDemoHung);
            groupBox1.Controls.Add(btnDemoLan);
            groupBox1.Controls.Add(btnDemoAdmin);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // btnDemoHung
            // 
            resources.ApplyResources(btnDemoHung, "btnDemoHung");
            btnDemoHung.Name = "btnDemoHung";
            btnDemoHung.UseVisualStyleBackColor = true;
            btnDemoHung.Click += btnDemoHung_Click;
            // 
            // btnDemoLan
            // 
            resources.ApplyResources(btnDemoLan, "btnDemoLan");
            btnDemoLan.Name = "btnDemoLan";
            btnDemoLan.UseVisualStyleBackColor = true;
            btnDemoLan.Click += btnDemoLan_Click;
            // 
            // btnDemoAdmin
            // 
            resources.ApplyResources(btnDemoAdmin, "btnDemoAdmin");
            btnDemoAdmin.Name = "btnDemoAdmin";
            btnDemoAdmin.UseVisualStyleBackColor = true;
            btnDemoAdmin.Click += btnDemoAdmin_Click;
            // 
            // FormDangNhap
            // 
            AcceptButton = btnDangNhap;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;
            Controls.Add(groupBox1);
            Controls.Add(lblThongBao);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(mkdn);
            Controls.Add(txtTenDangNhap);
            Controls.Add(tendn);
            Controls.Add(tieude);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormDangNhap";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tieude;
        private Label tendn;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private Label mkdn;
        private Button btnDangNhap;
        private Button btnThoat;
        private Label lblThongBao;
        private GroupBox groupBox1;
        private Button btnDemoAdmin;
        private Button btnDemoHung;
        private Button btnDemoLan;
    }
}