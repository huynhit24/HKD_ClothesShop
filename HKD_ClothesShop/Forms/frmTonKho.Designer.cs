
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
            this.tabControlDacDiemChung = new System.Windows.Forms.TabControl();
            this.tabCTSP = new System.Windows.Forms.TabPage();
            this.dgvCTDD = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.btnThemCT = new System.Windows.Forms.Button();
            this.cmbMaSP = new System.Windows.Forms.ComboBox();
            this.btnSuaCT = new System.Windows.Forms.Button();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.txtSLSP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.tabControlDacDiemChung.SuspendLayout();
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
            // tabControlDacDiemChung
            // 
            this.tabControlDacDiemChung.Controls.Add(this.tabCTSP);
            this.tabControlDacDiemChung.Location = new System.Drawing.Point(2, 62);
            this.tabControlDacDiemChung.Name = "tabControlDacDiemChung";
            this.tabControlDacDiemChung.SelectedIndex = 0;
            this.tabControlDacDiemChung.Size = new System.Drawing.Size(1209, 667);
            this.tabControlDacDiemChung.TabIndex = 34;
            // 
            // tabCTSP
            // 
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
            this.groupBox2.Controls.Add(this.buttonThoat);
            this.groupBox2.Controls.Add(this.buttonReset);
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
            // buttonThoat
            // 
            this.buttonThoat.BackColor = System.Drawing.Color.Red;
            this.buttonThoat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonThoat.FlatAppearance.BorderSize = 3;
            this.buttonThoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThoat.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.ForeColor = System.Drawing.Color.White;
            this.buttonThoat.Image = global::HKD_ClothesShop.Properties.Resources.cancel;
            this.buttonThoat.Location = new System.Drawing.Point(21, 476);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(124, 58);
            this.buttonThoat.TabIndex = 60;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonThoat.UseVisualStyleBackColor = false;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonReset.FlatAppearance.BorderSize = 3;
            this.buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Image = global::HKD_ClothesShop.Properties.Resources.monitor;
            this.buttonReset.Location = new System.Drawing.Point(21, 403);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(124, 58);
            this.buttonReset.TabIndex = 59;
            this.buttonReset.Text = "Clear";
            this.buttonReset.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // btnThemCT
            // 
            this.btnThemCT.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnThemCT.FlatAppearance.BorderSize = 3;
            this.btnThemCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCT.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCT.Image = global::HKD_ClothesShop.Properties.Resources.create;
            this.btnThemCT.Location = new System.Drawing.Point(21, 269);
            this.btnThemCT.Name = "btnThemCT";
            this.btnThemCT.Size = new System.Drawing.Size(124, 48);
            this.btnThemCT.TabIndex = 52;
            this.btnThemCT.Text = "Thêm";
            this.btnThemCT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
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
            this.btnSuaCT.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnSuaCT.FlatAppearance.BorderSize = 3;
            this.btnSuaCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCT.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaCT.Image = global::HKD_ClothesShop.Properties.Resources.update;
            this.btnSuaCT.Location = new System.Drawing.Point(21, 335);
            this.btnSuaCT.Name = "btnSuaCT";
            this.btnSuaCT.Size = new System.Drawing.Size(124, 48);
            this.btnSuaCT.TabIndex = 34;
            this.btnSuaCT.Text = "Sửa";
            this.btnSuaCT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
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
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1209, 717);
            this.Controls.Add(this.tabControlDacDiemChung);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTonKho";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            this.tabControlDacDiemChung.ResumeLayout(false);
            this.tabCTSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDD)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControlDacDiemChung;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.Button buttonReset;
    }
}