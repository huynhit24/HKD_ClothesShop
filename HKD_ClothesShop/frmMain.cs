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
            /*btnCoupon.Enabled = false;
            btnCoupon.Visible = false;
            btnMoney.Enabled = false;
            btnMoney.Visible = false;
            btnTracking.Enabled = false;
            btnTracking.Visible = false;
            btnFeedback.Enabled = false;
            btnFeedback.Visible = false;
            btnNhomKH.Enabled = false;
            btnNhomKH.Visible = false;*/

            #endregion
        }

        #region Menu, Submenu sự kiện click
        //cho các menu con ẩn đi
        private void customizeDesing()
        {
            panelHoaDonSubmenu.Visible = false;
            panelKhoSubmenu.Visible = false;
            panelKhachSubmenu.Visible = false;
            panelSpSubmenu.Visible = false;
        }
        // nếu menu con đang mở thì tắt đi
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

        //khi nhấn vào 1 button ở sidebar thì có hiệu ứng cùng hiện menu con
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

        //tắt button đi khổi phục trạng thái ban đầu
        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //show menu con
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

        // 1 nùi sự kiện mở tắt các chức năng bên sidebar
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
            openChildForm(new frmNhapHang());
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
            openChildForm(new frmThuongHieu());
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

        // chình màu sác Theme
        private void btnSettings_Click(object sender, EventArgs e)
        {
            /*hideSubmenu();
            openChildForm(new frmCaiDat());*/
            if (btnSettings.BackColor == Color.Honeydew)
            {
                this.BackColor = Color.FromArgb(13, 19, 41);
                pictureBox1.Visible = false;
                btnSettings.Image = Image.FromFile(@"C:\HKD_ClothesShop\HKD_ClothesShop\Assets\moon.png");
                btnSettings.TextImageRelation = TextImageRelation.TextBeforeImage;

                btnSettings.BackColor = Color.DeepSkyBlue;
                btnSettings.ForeColor = Color.White;
                panelMenuNgang.BackColor = Color.Black;
                panelShopImage.BackColor = Color.Black;

                btnHoaDon.ForeColor = Color.White;
                btnTaoHoaDon.ForeColor = Color.Blue;
                btnGhiNo.ForeColor = Color.Blue;
                btnKho.ForeColor = Color.White;
                btnNhapKho.ForeColor = Color.Blue;
                btnTonKho.ForeColor = Color.Blue;
                btnKhach.ForeColor = Color.White;
                btnDSKH.ForeColor = Color.Blue;
                btnNhomKH.ForeColor = Color.Blue;
                btnThuongHieu.ForeColor = Color.White;
                btnSanPham.ForeColor = Color.White;
                btnDSSP.ForeColor = Color.Blue;
                btnLoaiSP.ForeColor = Color.Blue;
                btnReport.ForeColor = Color.White;
                btnNhanVien.ForeColor = Color.White;

            }
            else
            {
                this.BackColor = Color.White;
                pictureBox1.Visible = true;
                btnSettings.Image = Image.FromFile(@"C:\HKD_ClothesShop\HKD_ClothesShop\Assets\sun.png");
                btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;


                btnSettings.BackColor = Color.Honeydew;
                btnSettings.ForeColor = Color.Black;
                panelMenuNgang.BackColor = Color.White;
                panelShopImage.BackColor = Color.White;

                btnHoaDon.ForeColor = Color.Black;
                btnTaoHoaDon.ForeColor = Color.Indigo;
                btnGhiNo.ForeColor = Color.Indigo;
                btnKho.ForeColor = Color.Black;
                btnNhapKho.ForeColor = Color.Indigo;
                btnTonKho.ForeColor = Color.Indigo;
                btnKhach.ForeColor = Color.Black;
                btnDSKH.ForeColor = Color.Indigo;
                btnNhomKH.ForeColor = Color.Indigo;
                btnThuongHieu.ForeColor = Color.Black;
                btnSanPham.ForeColor = Color.Black;
                btnDSSP.ForeColor = Color.Indigo;
                btnLoaiSP.ForeColor = Color.Indigo;
                btnReport.ForeColor = Color.Black;
                btnNhanVien.ForeColor = Color.Black;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            this.Close();
            new frmDangNhap().Show();
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

        // sự kiện khi nhấn nút HOME thì reset đóng thất cả các Form hoạt động
        private void Reset()
        {
            DisableButton();
            hideSubmenu();
            leftBorderBtn.Visible = false;
            activeForm.Close();
        }
        #endregion


        // hàm này dùng để mở 1 form con trong form Main
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

        private void btnNhomKH_Click(object sender, EventArgs e)
        {

        }

        // khi load form main nếu tài khoản admin thì mở thêm chức năng quản lý tài khoản
        private void frmMain_Load(object sender, EventArgs e)
        {
            switch (ThongTinDangNhap.Quyenhan)
            {
                case "ad":
                    //ThongTinDangNhap.flag = false;
                    labelName.Text = ThongTinDangNhap.Username;
                    break;
                case "bh":
                    //ThongTinDangNhap.flag = false;
                    labelName.Text = ThongTinDangNhap.Username;
                    btnTaiKhoan.Enabled = false;
                    break;
            }
        }

        private void taoHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaoHoaDon());
            hideSubmenu();
        }

        private void themKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDSKhachHang());
            hideSubmenu();
        }

        private void themThuongHieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThuongHieu());
            hideSubmenu();
        }

        private void themSanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapHang());
            hideSubmenu();
        }

        private void xemThongKeBaoCaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKeBaoCao());
            hideSubmenu();
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            this.Close();
            new frmDangNhap().Show();
        }
    }
}
