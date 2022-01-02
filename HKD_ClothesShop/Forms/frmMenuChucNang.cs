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
        public static bool flag = false; // cờ đăng xuất
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
            //this.Close();
            //flag = true;
            this.ParentForm.Close();
            new frmDangNhap().Show();
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
            openChildForm(new frmNhapHang());
        }

        private void panelLapPhieuNhapKho_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapHang());
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

        private void panelUpdateTTSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapHang());
        }

        private void panelDoanhThu_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKeBaoCao());
        }

        private void panelTimSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapHang());
        }

        private void panelTimNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVienShop());
        }

        private void panelTimKiemKH_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDSKhachHang());
        }

        private void panelIntroduce_Click(object sender, EventArgs e)
        {

        }

        private void panelGuide_Click(object sender, EventArgs e)
        {

        }

        private void frmMenuChucNang_Load(object sender, EventArgs e)
        {
            switch (ThongTinDangNhap.Quyenhan)
            {
                case "ad":
                    //ThongTinDangNhap.flag = false;
                    break;
                case "bh":
                    //ThongTinDangNhap.flag = false;
                    panelThayDoiMatKhau.Enabled = false;
                    panelTaoMoi.Enabled = false;
                    panelThayDoiQuyen.Enabled = false;
                    panelThayDoiMatKhau.BackColor = Color.DarkGray;
                    panelTaoMoi.BackColor = Color.DarkGray;
                    panelThayDoiQuyen.BackColor = Color.DarkGray;
                    break;
            }
        }
    }
}
