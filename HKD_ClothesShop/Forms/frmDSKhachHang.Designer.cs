
namespace HKD_ClothesShop.Forms
{
    partial class frmDSKhachHang
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
            this.groupBoxDSKH = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.radKhac = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelSDT = new System.Windows.Forms.Label();
            this.labelDiachi = new System.Windows.Forms.Label();
            this.labelHoten = new System.Windows.Forms.Label();
            this.labelMKH = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMKH = new System.Windows.Forms.TextBox();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnHidden = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBoxDSKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDSKH
            // 
            this.groupBoxDSKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxDSKH.BackColor = System.Drawing.Color.White;
            this.groupBoxDSKH.Controls.Add(this.btnThoat);
            this.groupBoxDSKH.Controls.Add(this.btnReset);
            this.groupBoxDSKH.Controls.Add(this.radKhac);
            this.groupBoxDSKH.Controls.Add(this.btnCreate);
            this.groupBoxDSKH.Controls.Add(this.btnUpdate);
            this.groupBoxDSKH.Controls.Add(this.radNu);
            this.groupBoxDSKH.Controls.Add(this.radNam);
            this.groupBoxDSKH.Controls.Add(this.cbStatus);
            this.groupBoxDSKH.Controls.Add(this.labelEmail);
            this.groupBoxDSKH.Controls.Add(this.labelSDT);
            this.groupBoxDSKH.Controls.Add(this.labelDiachi);
            this.groupBoxDSKH.Controls.Add(this.labelHoten);
            this.groupBoxDSKH.Controls.Add(this.labelMKH);
            this.groupBoxDSKH.Controls.Add(this.txtEmail);
            this.groupBoxDSKH.Controls.Add(this.txtSDT);
            this.groupBoxDSKH.Controls.Add(this.txtDiaChi);
            this.groupBoxDSKH.Controls.Add(this.txtHoTen);
            this.groupBoxDSKH.Controls.Add(this.txtMKH);
            this.groupBoxDSKH.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDSKH.Location = new System.Drawing.Point(12, 136);
            this.groupBoxDSKH.Name = "groupBoxDSKH";
            this.groupBoxDSKH.Size = new System.Drawing.Size(374, 480);
            this.groupBoxDSKH.TabIndex = 4;
            this.groupBoxDSKH.TabStop = false;
            this.groupBoxDSKH.Text = "Nhập thông tin khách hàng";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnThoat.FlatAppearance.BorderSize = 3;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Image = global::HKD_ClothesShop.Properties.Resources.cancel;
            this.btnThoat.Location = new System.Drawing.Point(244, 404);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(124, 58);
            this.btnThoat.TabIndex = 64;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReset.FlatAppearance.BorderSize = 3;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::HKD_ClothesShop.Properties.Resources.monitor;
            this.btnReset.Location = new System.Drawing.Point(106, 404);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 58);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "Reset";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // radKhac
            // 
            this.radKhac.AutoSize = true;
            this.radKhac.Location = new System.Drawing.Point(237, 156);
            this.radKhac.Name = "radKhac";
            this.radKhac.Size = new System.Drawing.Size(63, 23);
            this.radKhac.TabIndex = 24;
            this.radKhac.TabStop = true;
            this.radKhac.Text = "Khác";
            this.radKhac.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(140, 156);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(48, 23);
            this.radNu.TabIndex = 23;
            this.radNu.TabStop = true;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Location = new System.Drawing.Point(53, 156);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(61, 23);
            this.radNam.TabIndex = 22;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnUpdate.FlatAppearance.BorderSize = 3;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::HKD_ClothesShop.Properties.Resources.update;
            this.btnUpdate.Location = new System.Drawing.Point(244, 341);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 48);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.MouseLeave += new System.EventHandler(this.btnUpdate_MouseLeave);
            this.btnUpdate.MouseHover += new System.EventHandler(this.btnUpdate_MouseHover);
            // 
            // btnCreate
            // 
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCreate.FlatAppearance.BorderSize = 3;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Image = global::HKD_ClothesShop.Properties.Resources.create;
            this.btnCreate.Location = new System.Drawing.Point(106, 341);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(125, 48);
            this.btnCreate.TabIndex = 20;
            this.btnCreate.Text = "Thêm";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.btnCreate.MouseLeave += new System.EventHandler(this.btnCreate_MouseLeave);
            this.btnCreate.MouseHover += new System.EventHandler(this.btnCreate_MouseHover);
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(209, 293);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(136, 23);
            this.cbStatus.TabIndex = 16;
            this.cbStatus.Text = "Không sử dụng";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(16, 239);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(49, 19);
            this.labelEmail.TabIndex = 11;
            this.labelEmail.Text = "Email";
            // 
            // labelSDT
            // 
            this.labelSDT.AutoSize = true;
            this.labelSDT.Location = new System.Drawing.Point(16, 197);
            this.labelSDT.Name = "labelSDT";
            this.labelSDT.Size = new System.Drawing.Size(39, 19);
            this.labelSDT.TabIndex = 10;
            this.labelSDT.Text = "SĐT";
            // 
            // labelDiachi
            // 
            this.labelDiachi.AutoSize = true;
            this.labelDiachi.Location = new System.Drawing.Point(16, 109);
            this.labelDiachi.Name = "labelDiachi";
            this.labelDiachi.Size = new System.Drawing.Size(58, 19);
            this.labelDiachi.TabIndex = 9;
            this.labelDiachi.Text = "Địa chỉ";
            // 
            // labelHoten
            // 
            this.labelHoten.AutoSize = true;
            this.labelHoten.Location = new System.Drawing.Point(16, 70);
            this.labelHoten.Name = "labelHoten";
            this.labelHoten.Size = new System.Drawing.Size(56, 19);
            this.labelHoten.TabIndex = 8;
            this.labelHoten.Text = "Họ tên";
            // 
            // labelMKH
            // 
            this.labelMKH.AutoSize = true;
            this.labelMKH.Location = new System.Drawing.Point(16, 31);
            this.labelMKH.Name = "labelMKH";
            this.labelMKH.Size = new System.Drawing.Size(120, 19);
            this.labelMKH.TabIndex = 7;
            this.labelMKH.Text = "Mã khách hàng";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(154, 239);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(203, 27);
            this.txtEmail.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(154, 197);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(203, 27);
            this.txtSDT.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(154, 109);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(203, 27);
            this.txtDiaChi.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(154, 70);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(203, 27);
            this.txtHoTen.TabIndex = 1;
            // 
            // txtMKH
            // 
            this.txtMKH.Location = new System.Drawing.Point(154, 31);
            this.txtMKH.Name = "txtMKH";
            this.txtMKH.Size = new System.Drawing.Size(203, 27);
            this.txtMKH.TabIndex = 0;
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKhachHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvKhachHang.GridColor = System.Drawing.Color.DodgerBlue;
            this.dgvKhachHang.Location = new System.Drawing.Point(403, 145);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.Size = new System.Drawing.Size(803, 471);
            this.dgvKhachHang.TabIndex = 5;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label6.Location = new System.Drawing.Point(442, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(347, 33);
            this.label6.TabIndex = 6;
            this.label6.Text = "DANH SÁCH KHÁCH HÀNG";
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
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(904, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(987, 105);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(219, 27);
            this.txtSearch.TabIndex = 8;
            // 
            // btnHidden
            // 
            this.btnHidden.BackColor = System.Drawing.Color.GreenYellow;
            this.btnHidden.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHidden.ForeColor = System.Drawing.Color.Red;
            this.btnHidden.Location = new System.Drawing.Point(403, 104);
            this.btnHidden.Name = "btnHidden";
            this.btnHidden.Size = new System.Drawing.Size(83, 28);
            this.btnHidden.TabIndex = 9;
            this.btnHidden.Text = "Ẩn";
            this.btnHidden.UseVisualStyleBackColor = false;
            this.btnHidden.Click += new System.EventHandler(this.btnHidden_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã khách hàng";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Họ tên";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Giới tính";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Địa chỉ";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "SĐT";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Email";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Trạng thái";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Sửa thông tin";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column8.Text = "Sửa";
            this.Column8.UseColumnTextForButtonValue = true;
            // 
            // frmDSKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1228, 638);
            this.Controls.Add(this.btnHidden);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.groupBoxDSKH);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDSKhachHang";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.frmDSKhachHang_Load);
            this.groupBoxDSKH.ResumeLayout(false);
            this.groupBoxDSKH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxDSKH;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelSDT;
        private System.Windows.Forms.Label labelDiachi;
        private System.Windows.Forms.Label labelHoten;
        private System.Windows.Forms.Label labelMKH;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMKH;
        private System.Windows.Forms.RadioButton radKhac;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnHidden;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
    }
}