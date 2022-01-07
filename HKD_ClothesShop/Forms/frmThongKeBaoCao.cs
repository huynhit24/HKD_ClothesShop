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
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<HoaDon> listHoaDon = db.HoaDons.ToList();
                List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();

                List<NhanVienBanHang> listNhanVien = db.NhanVienBanHangs.ToList();
                List<KhachHang> listKhachHang = db.KhachHangs.ToList();
                List<SanPham> listSanPham = db.SanPhams.ToList();
                List<LoaiSanPham> listLoaiSanPham = db.LoaiSanPhams.ToList();

                // thống kê số lượng hóa đơn theo tháng, ngày hiện tại dùng foreach về sau LINQ hết
                int SLHDThang = 0;
                foreach (var item in listHoaDon)
                {
                    if (item.NgayLap.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy"))
                    {
                        SLHDThang++;
                    }
                }
                labelSLHDThang.Text = Convert.ToString(SLHDThang);
                int SLHDNow = 0;
                foreach (var item in listHoaDon)
                {
                    if (item.NgayLap.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                    {
                        SLHDNow++;
                    }
                }

                // thống kê số lượng khách hàng theo tháng, ngày hiện tại
                labelSLHDNow.Text = Convert.ToString(SLHDNow);
                int SLKHThang = 0;
                foreach (var item in db.KhachHangs)
                {
                    int temp = item.HoaDons.Count(p => p.NgayLap.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy"));
                    if(temp != 0)
                    {
                        SLKHThang++;
                    }
                }
                labelSLKHThang.Text = Convert.ToString(SLKHThang);
                int SLKHNow = 0;
                foreach (var item in db.KhachHangs)
                {
                    int temp = item.HoaDons.Count(p => p.NgayLap.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"));
                    if (temp != 0)
                    {
                        SLKHNow++;
                    }
                }
                labelSLKHNow.Text = Convert.ToString(SLKHNow);

                // đếm số loại sản phẩm
                int SLLSP = 0;
                SLLSP = listLoaiSanPham.Count();
                labelLSP.Text = Convert.ToString(SLLSP);

                // đếm tổng số lượng hàng đã bán tháng, ngày hiện tại
                int TSLMHBanThang = 0;
                foreach (var item in listCTHoaDon)
                {
                    if (item.HoaDon.NgayLap.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy"))
                    {
                       TSLMHBanThang += item.SoLuongMua;
                    }
                }
                labelTSLMHBanThang.Text = Convert.ToString(TSLMHBanThang);
                int TSLMHBanNow = 0;
                foreach (var item in listCTHoaDon)
                {
                    if (item.HoaDon.NgayLap.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                    {
                        TSLMHBanNow += item.SoLuongMua;
                    }
                }
                labelTSLMHBanNow.Text = Convert.ToString(TSLMHBanNow);

                // đếm số lượng mặt hàng được bán theo tháng, ngày hiện tại
                int SLMHBanThang = 0;
                List<ChiTietHoaDon> listCTHoaDontempmonth = new List<ChiTietHoaDon>();
                foreach (var item in listCTHoaDon)
                {
                    if (item.HoaDon.NgayLap.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy"))
                    {
                        listCTHoaDontempmonth.Add(item);
                    }
                }
                SLMHBanThang = db.ChiTietHoaDons.GroupBy(x => x.MaSanPham).Select(x => x.FirstOrDefault()).Count();
                labelSLMHThang.Text = Convert.ToString(SLMHBanThang);

                int SLMHBanNow = 0;
                List<ChiTietHoaDon> listCTHoaDontempday = new List<ChiTietHoaDon>();
                foreach (var item in listCTHoaDon)
                {
                    if(item.HoaDon.NgayLap.ToString("ddMM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                    {
                        listCTHoaDontempday.Add(item);
                    }
                }
                SLMHBanNow = db.ChiTietHoaDons.GroupBy(x => x.MaSanPham).Select(x => x.FirstOrDefault()).Count();

                labelSLMHNow.Text = Convert.ToString(SLMHBanNow);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi gì đó!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
