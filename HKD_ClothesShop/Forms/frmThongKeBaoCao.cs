using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HKD_ClothesShop.Modal;

namespace HKD_ClothesShop.Forms
{
    public partial class frmThongKeBaoCao : Form
    {
        public frmThongKeBaoCao()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongKeBaoCao_Load(object sender, EventArgs e)
        {
            ThongKeThangVaHomNay();
        }

        private void ThongKeThangVaHomNay()
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<HoaDon> listHoaDon = db.HoaDons.ToList();
            List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();

            List<NhanVienBanHang> listNhanVien = db.NhanVienBanHangs.ToList();
            List<KhachHang> listKhachHang = db.KhachHangs.ToList();
            List<SanPham> listSanPham = db.SanPhams.ToList();

            int SLHDTNow = 0;
            int SLHDThang = 0;
            foreach (var item in listCTHoaDon)
            {
                if (item.HoaDon.NgayLap.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    SLHDThang++;
                }
            }
            labelSLHDNow.Text = Convert.ToString(SLHDTNow);
        }
    }
}
