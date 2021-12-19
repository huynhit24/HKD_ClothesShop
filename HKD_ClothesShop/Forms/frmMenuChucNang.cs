using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKD_ClothesShop.Forms
{
    public partial class frmMenuChucNang : Form
    {
        public frmMenuChucNang()
        {
            InitializeComponent();

            #region Tắt các chức năng chưa hoàn thiện
            groupQLTC.Enabled = false;
            groupQLTC.Visible = false;
            panelLapDonMuaHang.Enabled = false;
            panelLapDonMuaHang.Visible = false;
            panelUpdateGiaMua.Enabled = false;
            panelUpdateGiaMua.Visible = false;
            panelLapPhieuYC.Enabled = false;
            panelLapPhieuYC.Visible = false;
            panelLapPhieuXuatHang.Enabled = false;
            panelLapPhieuXuatHang.Visible = false;

            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        
        private void panelXemDSKhachHang_Click(object sender, EventArgs e)
        {
            //this.Close();
            openChildForm(new frmDSKhachHang());
        }

        private void panelXemDSSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDSSanPham());
        }

        private void panelThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaiKhoan());
        }

        private void panelTaoMoi_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaiKhoan());
        }

        private void panelThayDoiQuyen_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaiKhoan());
        }

        private void panelDangXuatTK_Click(object sender, EventArgs e)
        {
            this.Close();
            openChildForm(new frmDangNhap());
        }

        private void panelLapHDBanHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaoHoaDon());
        }

        private void panelLapDonMuaHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaoHoaDon());
        }

        private void panelUpdateGiaBan_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaoHoaDon());
        }

        private void panelUpdateGiaMua_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaoHoaDon());
        }

        private void panelLapPhieuXuatKho_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapKho());
        }

        private void panelLapPhieuNhapKho_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapKho());
        }

        private void panelLapPhieuYC_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTonKho());
        }

        private void panelTinhLuongNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void panelThuChi_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaiChinh());
        }
    }
}
