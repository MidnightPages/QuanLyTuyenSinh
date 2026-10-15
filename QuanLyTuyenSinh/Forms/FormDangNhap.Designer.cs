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
            // FormDangNhap
            // 
            AcceptButton = btnDangNhap;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;
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
    }
}