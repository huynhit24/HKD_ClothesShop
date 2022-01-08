
namespace HKD_ClothesShop.Forms
{
    partial class frmThuongHieu
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
            this.groupBoxNV = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLuuS = new System.Windows.Forms.Button();
            this.buttonHuyS = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panelThem = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panelLuuHuy = new System.Windows.Forms.Panel();
            this.buttonLuuT = new System.Windows.Forms.Button();
            this.buttonHuyT = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnChonLogo = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.labelSDT = new System.Windows.Forms.Label();
            this.labelDiachi = new System.Windows.Forms.Label();
            this.labelTenTH = new System.Windows.Forms.Label();
            this.labelMTH = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenTH = new System.Windows.Forms.TextBox();
            this.txtMTH = new System.Windows.Forms.TextBox();
            this.dgvThuongHieu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHidden = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxNV.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelThem.SuspendLayout();
            this.panelLuuHuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuongHieu)).BeginInit();
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
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBoxNV
            // 
            this.groupBoxNV.Controls.Add(this.panel1);
            this.groupBoxNV.Controls.Add(this.panelThem);
            this.groupBoxNV.Controls.Add(this.btnChonLogo);
            this.groupBoxNV.Controls.Add(this.picLogo);
            this.groupBoxNV.Controls.Add(this.cbStatus);
            this.groupBoxNV.Controls.Add(this.labelSDT);
            this.groupBoxNV.Controls.Add(this.labelDiachi);
            this.groupBoxNV.Controls.Add(this.labelTenTH);
            this.groupBoxNV.Controls.Add(this.labelMTH);
            this.groupBoxNV.Controls.Add(this.txtSDT);
            this.groupBoxNV.Controls.Add(this.txtDiaChi);
            this.groupBoxNV.Controls.Add(this.txtTenTH);
            this.groupBoxNV.Controls.Add(this.txtMTH);
            this.groupBoxNV.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNV.Location = new System.Drawing.Point(12, 72);
            this.groupBoxNV.Name = "groupBoxNV";
            this.groupBoxNV.Size = new System.Drawing.Size(374, 676);
            this.groupBoxNV.TabIndex = 6;
            this.groupBoxNV.TabStop = false;
            this.groupBoxNV.Text = "Nhập thông tin nhân viên";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(232, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 222);
            this.panel1.TabIndex = 74;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnUpdate.FlatAppearance.BorderSize = 3;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::HKD_ClothesShop.Properties.Resources.update;
            this.btnUpdate.Location = new System.Drawing.Point(0, 102);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(134, 55);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonLuuS);
            this.panel2.Controls.Add(this.buttonHuyS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 102);
            this.panel2.TabIndex = 70;
            // 
            // buttonLuuS
            // 
            this.buttonLuuS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLuuS.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLuuS.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.buttonLuuS.FlatAppearance.BorderSize = 3;
            this.buttonLuuS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLuuS.Image = global::HKD_ClothesShop.Properties.Resources.save_file;
            this.buttonLuuS.Location = new System.Drawing.Point(0, 0);
            this.buttonLuuS.Name = "buttonLuuS";
            this.buttonLuuS.Size = new System.Drawing.Size(134, 48);
            this.buttonLuuS.TabIndex = 66;
            this.buttonLuuS.Text = "Lưu";
            this.buttonLuuS.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonLuuS.UseVisualStyleBackColor = true;
            this.buttonLuuS.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // buttonHuyS
            // 
            this.buttonHuyS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHuyS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonHuyS.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonHuyS.FlatAppearance.BorderSize = 3;
            this.buttonHuyS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHuyS.Image = global::HKD_ClothesShop.Properties.Resources.cancel;
            this.buttonHuyS.Location = new System.Drawing.Point(0, 54);
            this.buttonHuyS.Name = "buttonHuyS";
            this.buttonHuyS.Size = new System.Drawing.Size(134, 48);
            this.buttonHuyS.TabIndex = 65;
            this.buttonHuyS.Text = "Hủy";
            this.buttonHuyS.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonHuyS.UseVisualStyleBackColor = true;
            this.buttonHuyS.Click += new System.EventHandler(this.buttonHuyS_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnThoat.FlatAppearance.BorderSize = 3;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Image = global::HKD_ClothesShop.Properties.Resources.exit;
            this.btnThoat.Location = new System.Drawing.Point(0, 164);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(134, 58);
            this.btnThoat.TabIndex = 64;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panelThem
            // 
            this.panelThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelThem.Controls.Add(this.btnCreate);
            this.panelThem.Controls.Add(this.panelLuuHuy);
            this.panelThem.Controls.Add(this.btnReset);
            this.panelThem.Location = new System.Drawing.Point(77, 430);
            this.panelThem.Name = "panelThem";
            this.panelThem.Size = new System.Drawing.Size(136, 222);
            this.panelThem.TabIndex = 73;
            // 
            // btnCreate
            // 
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCreate.FlatAppearance.BorderSize = 3;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Image = global::HKD_ClothesShop.Properties.Resources.create;
            this.btnCreate.Location = new System.Drawing.Point(0, 102);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(136, 55);
            this.btnCreate.TabIndex = 20;
            this.btnCreate.Text = "Thêm";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panelLuuHuy
            // 
            this.panelLuuHuy.Controls.Add(this.buttonLuuT);
            this.panelLuuHuy.Controls.Add(this.buttonHuyT);
            this.panelLuuHuy.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLuuHuy.Location = new System.Drawing.Point(0, 0);
            this.panelLuuHuy.Name = "panelLuuHuy";
            this.panelLuuHuy.Size = new System.Drawing.Size(136, 102);
            this.panelLuuHuy.TabIndex = 69;
            // 
            // buttonLuuT
            // 
            this.buttonLuuT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLuuT.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLuuT.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.buttonLuuT.FlatAppearance.BorderSize = 3;
            this.buttonLuuT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLuuT.Image = global::HKD_ClothesShop.Properties.Resources.save_file;
            this.buttonLuuT.Location = new System.Drawing.Point(0, 0);
            this.buttonLuuT.Name = "buttonLuuT";
            this.buttonLuuT.Size = new System.Drawing.Size(136, 48);
            this.buttonLuuT.TabIndex = 66;
            this.buttonLuuT.Text = "Lưu";
            this.buttonLuuT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonLuuT.UseVisualStyleBackColor = true;
            this.buttonLuuT.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // buttonHuyT
            // 
            this.buttonHuyT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHuyT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonHuyT.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonHuyT.FlatAppearance.BorderSize = 3;
            this.buttonHuyT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHuyT.Image = global::HKD_ClothesShop.Properties.Resources.cancel;
            this.buttonHuyT.Location = new System.Drawing.Point(0, 54);
            this.buttonHuyT.Name = "buttonHuyT";
            this.buttonHuyT.Size = new System.Drawing.Size(136, 48);
            this.buttonHuyT.TabIndex = 65;
            this.buttonHuyT.Text = "Hủy";
            this.buttonHuyT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonHuyT.UseVisualStyleBackColor = true;
            this.buttonHuyT.Click += new System.EventHandler(this.buttonHuyT_Click);
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReset.FlatAppearance.BorderSize = 3;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::HKD_ClothesShop.Properties.Resources.monitor;
            this.btnReset.Location = new System.Drawing.Point(0, 164);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(136, 58);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "Reset";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnChonLogo
            // 
            this.btnChonLogo.BackColor = System.Drawing.Color.Lime;
            this.btnChonLogo.FlatAppearance.BorderSize = 0;
            this.btnChonLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonLogo.Location = new System.Drawing.Point(201, 282);
            this.btnChonLogo.Name = "btnChonLogo";
            this.btnChonLogo.Size = new System.Drawing.Size(91, 29);
            this.btnChonLogo.TabIndex = 28;
            this.btnChonLogo.Text = "Chọn logo";
            this.btnChonLogo.UseVisualStyleBackColor = false;
            this.btnChonLogo.Click += new System.EventHandler(this.btnChonLogo_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = global::HKD_ClothesShop.Properties.Resources.HKD_icon;
            this.picLogo.Location = new System.Drawing.Point(6, 207);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(180, 180);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 27;
            this.picLogo.TabStop = false;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(232, 388);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(136, 23);
            this.cbStatus.TabIndex = 16;
            this.cbStatus.Text = "Không sử dụng";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // labelSDT
            // 
            this.labelSDT.AutoSize = true;
            this.labelSDT.Location = new System.Drawing.Point(16, 156);
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
            // labelTenTH
            // 
            this.labelTenTH.AutoSize = true;
            this.labelTenTH.Location = new System.Drawing.Point(16, 70);
            this.labelTenTH.Name = "labelTenTH";
            this.labelTenTH.Size = new System.Drawing.Size(126, 19);
            this.labelTenTH.TabIndex = 8;
            this.labelTenTH.Text = "Tên thương hiệu";
            // 
            // labelMTH
            // 
            this.labelMTH.AutoSize = true;
            this.labelMTH.Location = new System.Drawing.Point(16, 31);
            this.labelMTH.Name = "labelMTH";
            this.labelMTH.Size = new System.Drawing.Size(122, 19);
            this.labelMTH.TabIndex = 7;
            this.labelMTH.Text = "Mã thương hiệu";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(154, 156);
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
            // txtTenTH
            // 
            this.txtTenTH.Location = new System.Drawing.Point(154, 70);
            this.txtTenTH.Name = "txtTenTH";
            this.txtTenTH.Size = new System.Drawing.Size(203, 27);
            this.txtTenTH.TabIndex = 1;
            // 
            // txtMTH
            // 
            this.txtMTH.Location = new System.Drawing.Point(154, 31);
            this.txtMTH.Name = "txtMTH";
            this.txtMTH.Size = new System.Drawing.Size(203, 27);
            this.txtMTH.TabIndex = 0;
            // 
            // dgvThuongHieu
            // 
            this.dgvThuongHieu.AllowUserToAddRows = false;
            this.dgvThuongHieu.AllowUserToDeleteRows = false;
            this.dgvThuongHieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThuongHieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuongHieu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvThuongHieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuongHieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuongHieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvThuongHieu.GridColor = System.Drawing.Color.Gold;
            this.dgvThuongHieu.Location = new System.Drawing.Point(403, 72);
            this.dgvThuongHieu.Name = "dgvThuongHieu";
            this.dgvThuongHieu.Size = new System.Drawing.Size(772, 778);
            this.dgvThuongHieu.TabIndex = 7;
            this.dgvThuongHieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThuongHieu_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Logo";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã thương hiệu";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên thương hiệu";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Địa chỉ";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "SĐT";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Trạng thái";
            this.Column6.Name = "Column6";
            // 
            // btnHidden
            // 
            this.btnHidden.BackColor = System.Drawing.Color.GreenYellow;
            this.btnHidden.FlatAppearance.BorderSize = 0;
            this.btnHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidden.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHidden.ForeColor = System.Drawing.Color.Red;
            this.btnHidden.Location = new System.Drawing.Point(403, 38);
            this.btnHidden.Name = "btnHidden";
            this.btnHidden.Size = new System.Drawing.Size(83, 28);
            this.btnHidden.TabIndex = 11;
            this.btnHidden.Text = "Ẩn";
            this.btnHidden.UseVisualStyleBackColor = false;
            this.btnHidden.Click += new System.EventHandler(this.btnHidden_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(646, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 33);
            this.label7.TabIndex = 12;
            this.label7.Text = "DANH SÁCH THƯƠNG HIỆU";
            // 
            // frmThuongHieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1209, 634);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnHidden);
            this.Controls.Add(this.dgvThuongHieu);
            this.Controls.Add(this.groupBoxNV);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThuongHieu";
            this.Text = "Form9";
            this.Load += new System.EventHandler(this.frmThuongHieu_Load);
            this.groupBoxNV.ResumeLayout(false);
            this.groupBoxNV.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelThem.ResumeLayout(false);
            this.panelLuuHuy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuongHieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxNV;
        private System.Windows.Forms.Button btnChonLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Label labelSDT;
        private System.Windows.Forms.Label labelDiachi;
        private System.Windows.Forms.Label labelTenTH;
        private System.Windows.Forms.Label labelMTH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenTH;
        private System.Windows.Forms.TextBox txtMTH;
        private System.Windows.Forms.DataGridView dgvThuongHieu;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnHidden;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonLuuS;
        private System.Windows.Forms.Button buttonHuyS;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panelThem;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panelLuuHuy;
        private System.Windows.Forms.Button buttonLuuT;
        private System.Windows.Forms.Button buttonHuyT;
        private System.Windows.Forms.Button btnReset;
    }
}