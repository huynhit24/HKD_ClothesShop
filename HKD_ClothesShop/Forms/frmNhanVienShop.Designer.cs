
namespace HKD_ClothesShop.Forms
{
    partial class frmNhanVienShop
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
            this.groupBoxNVShop = new System.Windows.Forms.GroupBox();
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
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.picAnhNV = new System.Windows.Forms.PictureBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.labelNgaysinh = new System.Windows.Forms.Label();
            this.radKhac = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelSDT = new System.Windows.Forms.Label();
            this.labelHoten = new System.Windows.Forms.Label();
            this.labelMNV = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMNV = new System.Windows.Forms.TextBox();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHidden = new System.Windows.Forms.Button();
            this.groupBoxNVShop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelThem.SuspendLayout();
            this.panelLuuHuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
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
            // groupBoxNVShop
            // 
            this.groupBoxNVShop.Controls.Add(this.panel1);
            this.groupBoxNVShop.Controls.Add(this.panelThem);
            this.groupBoxNVShop.Controls.Add(this.btnChonAnh);
            this.groupBoxNVShop.Controls.Add(this.picAnhNV);
            this.groupBoxNVShop.Controls.Add(this.dtpNgaySinh);
            this.groupBoxNVShop.Controls.Add(this.labelNgaysinh);
            this.groupBoxNVShop.Controls.Add(this.radKhac);
            this.groupBoxNVShop.Controls.Add(this.radNu);
            this.groupBoxNVShop.Controls.Add(this.radNam);
            this.groupBoxNVShop.Controls.Add(this.cbStatus);
            this.groupBoxNVShop.Controls.Add(this.labelEmail);
            this.groupBoxNVShop.Controls.Add(this.labelSDT);
            this.groupBoxNVShop.Controls.Add(this.labelHoten);
            this.groupBoxNVShop.Controls.Add(this.labelMNV);
            this.groupBoxNVShop.Controls.Add(this.txtEmail);
            this.groupBoxNVShop.Controls.Add(this.txtSDT);
            this.groupBoxNVShop.Controls.Add(this.txtHoTen);
            this.groupBoxNVShop.Controls.Add(this.txtMNV);
            this.groupBoxNVShop.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNVShop.Location = new System.Drawing.Point(26, 55);
            this.groupBoxNVShop.Name = "groupBoxNVShop";
            this.groupBoxNVShop.Size = new System.Drawing.Size(374, 762);
            this.groupBoxNVShop.TabIndex = 5;
            this.groupBoxNVShop.TabStop = false;
            this.groupBoxNVShop.Text = "Nhập thông tin nhân viên";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(231, 516);
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
            this.panelThem.Controls.Add(this.btnCreate);
            this.panelThem.Controls.Add(this.panelLuuHuy);
            this.panelThem.Controls.Add(this.btnReset);
            this.panelThem.Location = new System.Drawing.Point(89, 516);
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
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.Lime;
            this.btnChonAnh.FlatAppearance.BorderSize = 0;
            this.btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonAnh.Location = new System.Drawing.Point(232, 386);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(91, 29);
            this.btnChonAnh.TabIndex = 28;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // picAnhNV
            // 
            this.picAnhNV.Image = global::HKD_ClothesShop.Properties.Resources.HKD_icon;
            this.picAnhNV.Location = new System.Drawing.Point(27, 313);
            this.picAnhNV.Name = "picAnhNV";
            this.picAnhNV.Size = new System.Drawing.Size(180, 180);
            this.picAnhNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnhNV.TabIndex = 27;
            this.picAnhNV.TabStop = false;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(157, 165);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 27);
            this.dtpNgaySinh.TabIndex = 26;
            // 
            // labelNgaysinh
            // 
            this.labelNgaysinh.AutoSize = true;
            this.labelNgaysinh.Location = new System.Drawing.Point(23, 165);
            this.labelNgaysinh.Name = "labelNgaysinh";
            this.labelNgaysinh.Size = new System.Drawing.Size(80, 19);
            this.labelNgaysinh.TabIndex = 25;
            this.labelNgaysinh.Text = "Ngày sinh";
            // 
            // radKhac
            // 
            this.radKhac.AutoSize = true;
            this.radKhac.Location = new System.Drawing.Point(232, 124);
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
            this.radNu.Location = new System.Drawing.Point(141, 124);
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
            this.radNam.Location = new System.Drawing.Point(42, 124);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(61, 23);
            this.radNam.TabIndex = 22;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(232, 478);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(136, 23);
            this.cbStatus.TabIndex = 16;
            this.cbStatus.Text = "Không sử dụng";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(23, 264);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(49, 19);
            this.labelEmail.TabIndex = 11;
            this.labelEmail.Text = "Email";
            // 
            // labelSDT
            // 
            this.labelSDT.AutoSize = true;
            this.labelSDT.Location = new System.Drawing.Point(23, 211);
            this.labelSDT.Name = "labelSDT";
            this.labelSDT.Size = new System.Drawing.Size(39, 19);
            this.labelSDT.TabIndex = 10;
            this.labelSDT.Text = "SĐT";
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
            // labelMNV
            // 
            this.labelMNV.AutoSize = true;
            this.labelMNV.Location = new System.Drawing.Point(16, 31);
            this.labelMNV.Name = "labelMNV";
            this.labelMNV.Size = new System.Drawing.Size(106, 19);
            this.labelMNV.TabIndex = 7;
            this.labelMNV.Text = "Mã nhân viên";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(154, 264);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(203, 27);
            this.txtEmail.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(154, 211);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(203, 27);
            this.txtSDT.TabIndex = 3;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(154, 70);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(203, 27);
            this.txtHoTen.TabIndex = 1;
            // 
            // txtMNV
            // 
            this.txtMNV.Location = new System.Drawing.Point(154, 31);
            this.txtMNV.Name = "txtMNV";
            this.txtMNV.Size = new System.Drawing.Size(203, 27);
            this.txtMNV.TabIndex = 0;
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9});
            this.dgvNhanVien.GridColor = System.Drawing.Color.GreenYellow;
            this.dgvNhanVien.Location = new System.Drawing.Point(406, 101);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.Size = new System.Drawing.Size(723, 1436);
            this.dgvNhanVien.TabIndex = 6;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column8.HeaderText = "Ảnh";
            this.Column8.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column8.MinimumWidth = 92;
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column8.Width = 92;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Mã nhân viên";
            this.Column1.Name = "Column1";
            this.Column1.Width = 83;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "Họ tên";
            this.Column2.Name = "Column2";
            this.Column2.Width = 92;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "Giới tính";
            this.Column4.Name = "Column4";
            this.Column4.Width = 91;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.HeaderText = "Ngày sinh";
            this.Column5.Name = "Column5";
            this.Column5.Width = 91;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = "SĐT";
            this.Column6.Name = "Column6";
            this.Column6.Width = 91;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.HeaderText = "Email";
            this.Column7.Name = "Column7";
            this.Column7.Width = 92;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column9.HeaderText = "Trạng thái";
            this.Column9.Name = "Column9";
            this.Column9.Width = 108;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(667, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(317, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "DANH SÁCH NHÂN VIÊN";
            // 
            // btnHidden
            // 
            this.btnHidden.BackColor = System.Drawing.Color.GreenYellow;
            this.btnHidden.FlatAppearance.BorderSize = 0;
            this.btnHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidden.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHidden.ForeColor = System.Drawing.Color.Red;
            this.btnHidden.Location = new System.Drawing.Point(406, 67);
            this.btnHidden.Name = "btnHidden";
            this.btnHidden.Size = new System.Drawing.Size(83, 28);
            this.btnHidden.TabIndex = 10;
            this.btnHidden.Text = "Ẩn";
            this.btnHidden.UseVisualStyleBackColor = false;
            this.btnHidden.Click += new System.EventHandler(this.btnHidden_Click);
            // 
            // frmNhanVienShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1243, 634);
            this.Controls.Add(this.btnHidden);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.groupBoxNVShop);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNhanVienShop";
            this.Text = "Form13";
            this.Load += new System.EventHandler(this.frmNhanVienShop_Load);
            this.groupBoxNVShop.ResumeLayout(false);
            this.groupBoxNVShop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelThem.ResumeLayout(false);
            this.panelLuuHuy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxNVShop;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label labelNgaysinh;
        private System.Windows.Forms.RadioButton radKhac;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelSDT;
        private System.Windows.Forms.Label labelHoten;
        private System.Windows.Forms.Label labelMNV;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMNV;
        private System.Windows.Forms.PictureBox picAnhNV;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHidden;
        private System.Windows.Forms.DataGridViewImageColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
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