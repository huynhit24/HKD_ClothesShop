
namespace HKD_ClothesShop.Forms
{
    partial class frmTonKho
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDacDiem = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHidden = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDacDiem = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCTSP = new System.Windows.Forms.TabPage();
            this.btnAn = new System.Windows.Forms.Button();
            this.dgvCTDD = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThemCT = new System.Windows.Forms.Button();
            this.cmbMaSP = new System.Windows.Forms.ComboBox();
            this.btnSuaCT = new System.Windows.Forms.Button();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.txtSLSP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabDacDiem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDacDiem)).BeginInit();
            this.tabCTSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDD)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::HKD_ClothesShop.Properties.Resources.closed_sign;
            this.btnClose.Location = new System.Drawing.Point(12, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 42);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDacDiem);
            this.tabControl1.Controls.Add(this.tabCTSP);
            this.tabControl1.Location = new System.Drawing.Point(2, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1209, 667);
            this.tabControl1.TabIndex = 34;
            // 
            // tabDacDiem
            // 
            this.tabDacDiem.Controls.Add(this.label7);
            this.tabDacDiem.Controls.Add(this.btnHidden);
            this.tabDacDiem.Controls.Add(this.groupBox1);
            this.tabDacDiem.Controls.Add(this.dgvDacDiem);
            this.tabDacDiem.Font = new System.Drawing.Font("Roboto Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDacDiem.Location = new System.Drawing.Point(4, 24);
            this.tabDacDiem.Name = "tabDacDiem";
            this.tabDacDiem.Padding = new System.Windows.Forms.Padding(3);
            this.tabDacDiem.Size = new System.Drawing.Size(1201, 639);
            this.tabDacDiem.TabIndex = 0;
            this.tabDacDiem.Text = "Đặc điểm chung";
            this.tabDacDiem.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(584, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 33);
            this.label7.TabIndex = 34;
            this.label7.Text = "DANH SÁCH ĐẶC ĐIỂM CHUNG";
            // 
            // btnHidden
            // 
            this.btnHidden.BackColor = System.Drawing.Color.GreenYellow;
            this.btnHidden.FlatAppearance.BorderSize = 0;
            this.btnHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidden.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHidden.ForeColor = System.Drawing.Color.Red;
            this.btnHidden.Location = new System.Drawing.Point(407, 46);
            this.btnHidden.Name = "btnHidden";
            this.btnHidden.Size = new System.Drawing.Size(83, 28);
            this.btnHidden.TabIndex = 33;
            this.btnHidden.Text = "Ẩn";
            this.btnHidden.UseVisualStyleBackColor = false;
            this.btnHidden.Click += new System.EventHandler(this.btnHidden_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.comboBoxColor);
            this.groupBox1.Controls.Add(this.comboBoxSize);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 334);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đặc điểm";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(196, 207);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(136, 23);
            this.cbStatus.TabIndex = 54;
            this.cbStatus.Text = "Không sử dụng";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnUpdate.FlatAppearance.BorderSize = 3;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::HKD_ClothesShop.Properties.Resources.update;
            this.btnUpdate.Location = new System.Drawing.Point(208, 236);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(124, 58);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnCreate.FlatAppearance.BorderSize = 3;
            this.btnCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Image = global::HKD_ClothesShop.Properties.Resources.create;
            this.btnCreate.Location = new System.Drawing.Point(69, 236);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(124, 58);
            this.btnCreate.TabIndex = 33;
            this.btnCreate.Text = "Thêm";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 51;
            this.label3.Text = "Màu sắc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 50;
            this.label1.Text = "Kích thước";
            // 
            // dgvDacDiem
            // 
            this.dgvDacDiem.AllowUserToAddRows = false;
            this.dgvDacDiem.AllowUserToDeleteRows = false;
            this.dgvDacDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDacDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvDacDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDacDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvDacDiem.Location = new System.Drawing.Point(407, 80);
            this.dgvDacDiem.Name = "dgvDacDiem";
            this.dgvDacDiem.Size = new System.Drawing.Size(753, 539);
            this.dgvDacDiem.TabIndex = 32;
            this.dgvDacDiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDacDiem_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Kích thước";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Màu sắc";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Trạng thái";
            this.Column3.Name = "Column3";
            // 
            // tabCTSP
            // 
            this.tabCTSP.Controls.Add(this.btnAn);
            this.tabCTSP.Controls.Add(this.dgvCTDD);
            this.tabCTSP.Controls.Add(this.groupBox2);
            this.tabCTSP.Location = new System.Drawing.Point(4, 24);
            this.tabCTSP.Name = "tabCTSP";
            this.tabCTSP.Padding = new System.Windows.Forms.Padding(3);
            this.tabCTSP.Size = new System.Drawing.Size(1201, 639);
            this.tabCTSP.TabIndex = 1;
            this.tabCTSP.Text = "Đặc điểm số lượng sản phẩm";
            this.tabCTSP.UseVisualStyleBackColor = true;
            // 
            // btnAn
            // 
            this.btnAn.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAn.FlatAppearance.BorderSize = 0;
            this.btnAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAn.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAn.ForeColor = System.Drawing.Color.Red;
            this.btnAn.Location = new System.Drawing.Point(207, 6);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(83, 28);
            this.btnAn.TabIndex = 35;
            this.btnAn.Text = "Ẩn";
            this.btnAn.UseVisualStyleBackColor = false;
            this.btnAn.Click += new System.EventHandler(this.btnAn_Click);
            // 
            // dgvCTDD
            // 
            this.dgvCTDD.AllowUserToAddRows = false;
            this.dgvCTDD.AllowUserToDeleteRows = false;
            this.dgvCTDD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCTDD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTDD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvCTDD.Location = new System.Drawing.Point(207, 44);
            this.dgvCTDD.Name = "dgvCTDD";
            this.dgvCTDD.Size = new System.Drawing.Size(994, 575);
            this.dgvCTDD.TabIndex = 34;
            this.dgvCTDD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTDD_CellClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Mã sản phẩm";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Kích thước";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Màu sắc";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Số lượng tồn";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Tên sản phẩm";
            this.Column8.Name = "Column8";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThemCT);
            this.groupBox2.Controls.Add(this.cmbMaSP);
            this.groupBox2.Controls.Add(this.btnSuaCT);
            this.groupBox2.Controls.Add(this.cmbColor);
            this.groupBox2.Controls.Add(this.txtSLSP);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmbSize);
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 562);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // btnThemCT
            // 
            this.btnThemCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCT.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCT.Location = new System.Drawing.Point(33, 251);
            this.btnThemCT.Name = "btnThemCT";
            this.btnThemCT.Size = new System.Drawing.Size(106, 48);
            this.btnThemCT.TabIndex = 52;
            this.btnThemCT.Text = "Thêm";
            this.btnThemCT.UseVisualStyleBackColor = true;
            this.btnThemCT.Click += new System.EventHandler(this.btnThemCT_Click);
            // 
            // cmbMaSP
            // 
            this.cmbMaSP.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaSP.FormattingEnabled = true;
            this.cmbMaSP.Location = new System.Drawing.Point(21, 25);
            this.cmbMaSP.Name = "cmbMaSP";
            this.cmbMaSP.Size = new System.Drawing.Size(129, 27);
            this.cmbMaSP.TabIndex = 51;
            // 
            // btnSuaCT
            // 
            this.btnSuaCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCT.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaCT.Location = new System.Drawing.Point(33, 322);
            this.btnSuaCT.Name = "btnSuaCT";
            this.btnSuaCT.Size = new System.Drawing.Size(106, 48);
            this.btnSuaCT.TabIndex = 34;
            this.btnSuaCT.Text = "Sửa";
            this.btnSuaCT.UseVisualStyleBackColor = true;
            this.btnSuaCT.Click += new System.EventHandler(this.btnSuaCT_Click);
            // 
            // cmbColor
            // 
            this.cmbColor.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Items.AddRange(new object[] {
            "White",
            "Blue",
            "Green",
            "Yellow",
            "Orange",
            "Pink",
            "Gray",
            "Red",
            "Black",
            "Brown",
            "Beige",
            "Violet",
            "Purple"});
            this.cmbColor.Location = new System.Drawing.Point(21, 130);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(129, 27);
            this.cmbColor.TabIndex = 50;
            this.cmbColor.Text = "Chọn màu";
            // 
            // txtSLSP
            // 
            this.txtSLSP.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLSP.Location = new System.Drawing.Point(85, 184);
            this.txtSLSP.Name = "txtSLSP";
            this.txtSLSP.Size = new System.Drawing.Size(67, 27);
            this.txtSLSP.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 19);
            this.label10.TabIndex = 48;
            this.label10.Text = "Số lượng";
            // 
            // cmbSize
            // 
            this.cmbSize.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Items.AddRange(new object[] {
            "XS",
            "S",
            "M",
            "L",
            "XL",
            "XXL"});
            this.cmbSize.Location = new System.Drawing.Point(21, 76);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(129, 27);
            this.cmbSize.TabIndex = 46;
            this.cmbSize.Text = "Chọn size";
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            "XS",
            "S",
            "M",
            "L",
            "XL",
            "XXL"});
            this.comboBoxSize.Location = new System.Drawing.Point(200, 40);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(121, 27);
            this.comboBoxSize.TabIndex = 55;
            this.comboBoxSize.Text = "Chọn size";
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            "White",
            "Blue",
            "Green",
            "Yellow",
            "Orange",
            "Pink",
            "Gray",
            "Red",
            "Black",
            "Brown",
            "Beige",
            "Violet",
            "Purple"});
            this.comboBoxColor.Location = new System.Drawing.Point(200, 91);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(121, 27);
            this.comboBoxColor.TabIndex = 56;
            this.comboBoxColor.Text = "Chọn màu";
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1209, 717);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTonKho";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDacDiem.ResumeLayout(false);
            this.tabDacDiem.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDacDiem)).EndInit();
            this.tabCTSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDD)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDacDiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDacDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TabPage tabCTSP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThemCT;
        private System.Windows.Forms.ComboBox cmbMaSP;
        private System.Windows.Forms.Button btnSuaCT;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.TextBox txtSLSP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.DataGridView dgvCTDD;
        private System.Windows.Forms.Button btnHidden;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.ComboBox comboBoxSize;
    }
}