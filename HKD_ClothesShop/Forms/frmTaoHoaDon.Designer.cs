
namespace HKD_ClothesShop.Forms
{
    partial class frmTaoHoaDon
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
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSHD = new System.Windows.Forms.TextBox();
            this.tabChiTietHoaDon = new System.Windows.Forms.TabControl();
            this.tabHoaDon = new System.Windows.Forms.TabPage();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbMNV = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMKH = new System.Windows.Forms.ComboBox();
            this.cmbTinhTrang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHidden = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabChiTietHoaDon.SuspendLayout();
            this.tabHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::HKD_ClothesShop.Properties.Resources.closed_sign;
            this.btnClose.Location = new System.Drawing.Point(12, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbTinhTrang);
            this.groupBox1.Controls.Add(this.cmbMKH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbMNV);
            this.groupBox1.Controls.Add(this.dtpNgayLap);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSHD);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 525);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(154, 159);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(200, 27);
            this.dtpNgayLap.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 19);
            this.label6.TabIndex = 25;
            this.label6.Text = "Ngày lập hóa đơn";
            // 
            // btnSua
            // 
            this.btnSua.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSua.FlatAppearance.BorderSize = 3;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Image = global::HKD_ClothesShop.Properties.Resources.update;
            this.btnSua.Location = new System.Drawing.Point(255, 425);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(102, 48);
            this.btnSua.TabIndex = 21;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnThem.FlatAppearance.BorderSize = 3;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Image = global::HKD_ClothesShop.Properties.Resources.create;
            this.btnThem.Location = new System.Drawing.Point(111, 425);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 48);
            this.btnThem.TabIndex = 20;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(232, 381);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(136, 23);
            this.cbStatus.TabIndex = 16;
            this.cbStatus.Text = "Không sử dụng";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số hóa đơn";
            // 
            // txtSHD
            // 
            this.txtSHD.Location = new System.Drawing.Point(154, 31);
            this.txtSHD.Name = "txtSHD";
            this.txtSHD.Size = new System.Drawing.Size(203, 27);
            this.txtSHD.TabIndex = 0;
            // 
            // tabChiTietHoaDon
            // 
            this.tabChiTietHoaDon.Controls.Add(this.tabHoaDon);
            this.tabChiTietHoaDon.Controls.Add(this.tabPage2);
            this.tabChiTietHoaDon.Location = new System.Drawing.Point(4, 57);
            this.tabChiTietHoaDon.Name = "tabChiTietHoaDon";
            this.tabChiTietHoaDon.SelectedIndex = 0;
            this.tabChiTietHoaDon.Size = new System.Drawing.Size(1193, 575);
            this.tabChiTietHoaDon.TabIndex = 7;
            // 
            // tabHoaDon
            // 
            this.tabHoaDon.Controls.Add(this.btnHidden);
            this.tabHoaDon.Controls.Add(this.label7);
            this.tabHoaDon.Controls.Add(this.dgvHoaDon);
            this.tabHoaDon.Controls.Add(this.groupBox1);
            this.tabHoaDon.Location = new System.Drawing.Point(4, 22);
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabHoaDon.Size = new System.Drawing.Size(1185, 549);
            this.tabHoaDon.TabIndex = 0;
            this.tabHoaDon.Text = "Hóa đơn";
            this.tabHoaDon.UseVisualStyleBackColor = true;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvHoaDon.Location = new System.Drawing.Point(396, 53);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(783, 478);
            this.dgvHoaDon.TabIndex = 7;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1185, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chi tiết hóa đơn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbMNV
            // 
            this.cmbMNV.FormattingEnabled = true;
            this.cmbMNV.Location = new System.Drawing.Point(154, 70);
            this.cmbMNV.Name = "cmbMNV";
            this.cmbMNV.Size = new System.Drawing.Size(121, 27);
            this.cmbMNV.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mã khách hàng";
            // 
            // cmbMKH
            // 
            this.cmbMKH.FormattingEnabled = true;
            this.cmbMKH.Location = new System.Drawing.Point(154, 108);
            this.cmbMKH.Name = "cmbMKH";
            this.cmbMKH.Size = new System.Drawing.Size(121, 27);
            this.cmbMKH.TabIndex = 29;
            // 
            // cmbTinhTrang
            // 
            this.cmbTinhTrang.FormattingEnabled = true;
            this.cmbTinhTrang.Items.AddRange(new object[] {
            "Đã thanh toán",
            "Ghi nợ"});
            this.cmbTinhTrang.Location = new System.Drawing.Point(154, 212);
            this.cmbTinhTrang.Name = "cmbTinhTrang";
            this.cmbTinhTrang.Size = new System.Drawing.Size(150, 27);
            this.cmbTinhTrang.TabIndex = 30;
            this.cmbTinhTrang.Text = "Chưa thanh toán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 31;
            this.label4.Text = "Tính trạng";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Số hóa đơn";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã nhân viên";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mã khách hàng";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ngày lập hóa đơn";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tình trạng thanh toán";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Trạng thái";
            this.Column6.Name = "Column6";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(634, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 33);
            this.label7.TabIndex = 35;
            this.label7.Text = "DANH SÁCH ĐẶC ĐIỂM CHUNG";
            // 
            // btnHidden
            // 
            this.btnHidden.BackColor = System.Drawing.Color.GreenYellow;
            this.btnHidden.FlatAppearance.BorderSize = 0;
            this.btnHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidden.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHidden.ForeColor = System.Drawing.Color.Red;
            this.btnHidden.Location = new System.Drawing.Point(396, 22);
            this.btnHidden.Name = "btnHidden";
            this.btnHidden.Size = new System.Drawing.Size(83, 28);
            this.btnHidden.TabIndex = 36;
            this.btnHidden.Text = "Ẩn";
            this.btnHidden.UseVisualStyleBackColor = false;
            this.btnHidden.Click += new System.EventHandler(this.btnHidden_Click);
            // 
            // frmTaoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 634);
            this.Controls.Add(this.tabChiTietHoaDon);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTaoHoaDon";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmTaoHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabChiTietHoaDon.ResumeLayout(false);
            this.tabHoaDon.ResumeLayout(false);
            this.tabHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSHD;
        private System.Windows.Forms.TabControl tabChiTietHoaDon;
        private System.Windows.Forms.TabPage tabHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTinhTrang;
        private System.Windows.Forms.ComboBox cmbMKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHidden;
    }
}