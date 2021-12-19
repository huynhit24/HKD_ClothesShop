using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HKD_ClothesShop.Forms;

namespace HKD_ClothesShop
{
    public partial class frmMain : Form
    {
        // chỉnh màu border trái
        private Button currentBtn;
        private Panel leftBorderBtn;

        public frmMain()
        {
            InitializeComponent();
            customizeDesing();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panelShopImage.Controls.Add(leftBorderBtn);

            #region Tắt các chức năng chưa hoàn thiện
            btnCoupon.Enabled = false;
            btnCoupon.Visible = false;
            btnMoney.Enabled = false;
            btnMoney.Visible = false;
            btnTracking.Enabled = false;
            btnTracking.Visible = false;
            btnFeedback.Enabled = false;
            btnFeedback.Visible = false;

            #endregion
        }

        #region Menu, Submenu sự kiện click
        private void customizeDesing()
        {
            panelHoaDonSubmenu.Visible = false;
            panelKhoSubmenu.Visible = false;
            panelKhachSubmenu.Visible = false;
            panelSpSubmenu.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panelHoaDonSubmenu.Visible == true)
                panelHoaDonSubmenu.Visible = false;
            if (panelKhoSubmenu.Visible == true)
                panelKhoSubmenu.Visible = false;
            if (panelKhachSubmenu.Visible == true)
                panelKhachSubmenu.Visible = false;
            if (panelSpSubmenu.Visible == true)
                panelSpSubmenu.Visible = false;
        }
        // danh sách màu dùng để border trái, sử RGB
        private struct RGBColors
        {
            public static Color mau1 = Color.FromArgb(172, 126, 241);
            public static Color mau2 = Color.FromArgb(249, 118, 176);
            public static Color mau3 = Color.FromArgb(253, 138, 114);
            public static Color mau4 = Color.FromArgb(95, 77, 221);
            public static Color mau5 = Color.FromArgb(249, 88, 155);
            public static Color mau6 = Color.FromArgb(24, 161, 251);
            public static Color mau7 = Color.FromArgb(200, 100, 50);
            public static Color mau8 = Color.FromArgb(210, 155, 100);
            public static Color mau9 = Color.FromArgb(100, 200, 99);
            public static Color mau10 = Color.FromArgb(253, 138, 114);
            public static Color mau11 = Color.FromArgb(167, 128, 99);
        }


        private void ActivateButton(Object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (Button)senderBtn;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void showSubmenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau1);
            showSubmenu(panelHoaDonSubmenu);
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau2);
            showSubmenu(panelKhoSubmenu);
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau3);
            showSubmenu(panelKhachSubmenu);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau4);
            showSubmenu(panelSpSubmenu);
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            //Your code
            openChildForm(new frmTaoHoaDon());
            hideSubmenu();
        }

        private void btnTraHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmKhachTraHang());
            hideSubmenu();
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapKho());
            hideSubmenu();
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTonKho());
            hideSubmenu();
        }

        private void btnDSKH_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDSKhachHang());
            hideSubmenu();
        }

        private void btnNhomKH_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhomKhachHang());
            hideSubmenu();
        }

        private void btnDSSP_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDSSanPham());
            hideSubmenu();
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            openChildForm(new frmLoaiSanPham());
            hideSubmenu();
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau5);
            openChildForm(new frmNhaCungCap());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau6);
            openChildForm(new frmThongKeBaoCao());
        }

        private void btnCoupon_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau7);
            openChildForm(new frmKhuyenMaiGiamGia());
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau8);
            openChildForm(new frmTaiChinh());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau9);
            openChildForm(new frmNhanVienShop());
        }

        private void btnTracking_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau10);
            openChildForm(new frmVanChuyen());
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            ActivateButton(sender, RGBColors.mau11);
            openChildForm(new frmPhanHoi());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new frmTaiKhoan());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new frmCaiDat());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            //code đăng xuất
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new frmMenuChucNang());
        }

        private void Reset()
        {
            DisableButton();
            hideSubmenu();
            leftBorderBtn.Visible = false;
            activeForm.Close();
        }
        #endregion

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        
    }
}
