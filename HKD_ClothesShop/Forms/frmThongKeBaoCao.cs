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
using System.Windows.Forms.DataVisualization.Charting;
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
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            ThongKeThangVaHomNay();
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("1", "20000000");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("2", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("3", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("4", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("5", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("6", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("7", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("8", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("9", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("10", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("11", "0");
            chartDoanhThu.Series["DoanhThu"].Points.AddXY("12", "0");

            chartSLBan.DataSource = db.SanPhams.ToList();

            chartSLBan.Series["SanPham"].XValueMember = "TenSanPham";
            chartSLBan.Series["SanPham"].XValueType = ChartValueType.String;
            chartSLBan.Series["SanPham"].YValueMembers = "DonGia";
            chartSLBan.Series["SanPham"].YValueType = ChartValueType.Double;




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
                List<DacDiem_SanPham> listDDSP = db.DacDiem_SanPham.ToList();


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

                //Tính doanh thu tháng, ngày
                decimal DTThang = 0;
                foreach (var item in listCTHoaDon)
                {
                    if (item.HoaDon.NgayLap.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy"))
                    {
                        DTThang += item.SoLuongMua * item.DonGiaBan;
                    }
                }
                labelDTThang.Text = Convert.ToString(DTThang.ToString("0.00"));
                decimal DTNow = 0;
                foreach (var item in listCTHoaDon)
                {
                    if (item.HoaDon.NgayLap.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                    {
                        DTNow += item.SoLuongMua * item.DonGiaBan;
                    }
                }
                labelDTNow.Text = Convert.ToString(DTNow.ToString("0.00"));

                // đếm tổng số lượng hàng trong kho
                int TSHKho = 0;
                foreach (var item in listDDSP)
                {
                    TSHKho += item.SoLuong;
                }
                labelTSHKho.Text = Convert.ToString(TSHKho);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi gì đó!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
