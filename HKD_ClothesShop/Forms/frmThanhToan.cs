using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HKD_ClothesShop.Modal;

namespace HKD_ClothesShop.Forms
{
    public partial class frmThanhToan : Form
    {
        //public bool flag = false;
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();
            MoButton();
            buttonClear.Enabled = true;
            buttonClear.Visible = true;
            btnTinhTienthoi.Enabled = true;
            btnTinhTienthoi.Visible = true;
            labelThanhtoan.Text = ThanhToan.TienThanhToan;
            labelKhachdua.Text = "0";
            labelTienthoi.Text = "0";
            money = 0;
        }

        private void XoaTT()
        {
            labelKhachdua.Text = "0";
            //buttonTraDu.Enabled = true;
        }

        //tắt các button chọn tiền
        private void TatButton()
        {
            button1ngan.Enabled = false;
            button5ngan.Enabled = false;
            button10ngan.Enabled = false;
            button20ngan.Enabled = false;
            button50ngan.Enabled = false;
            button100ngan.Enabled = false;
            button200ngan.Enabled = false;
            button500ngan.Enabled = false;
            button1ngan.Visible = false;
            button5ngan.Visible = false;
            button10ngan.Visible = false;
            button20ngan.Visible = false;
            button50ngan.Visible = false;
            button100ngan.Visible = false;
            button200ngan.Visible = false;
            button500ngan.Visible = false;
        }

        //mở các button chọn tiền
        private void MoButton()
        {
            button1ngan.Enabled = true;
            button5ngan.Enabled = true;
            button10ngan.Enabled = true;
            button20ngan.Enabled = true;
            button50ngan.Enabled = true;
            button100ngan.Enabled = true;
            button200ngan.Enabled = true;
            button500ngan.Enabled = true;
            button1ngan.Visible = true;
            button5ngan.Visible = true;
            button10ngan.Visible = true;
            button20ngan.Visible = true;
            button50ngan.Visible = true;
            button100ngan.Visible = true;
            button200ngan.Visible = true;
            button500ngan.Visible = true;
        }
        private void buttonTraDu_Click(object sender, EventArgs e)
        {
            TatButton();
            buttonClear.Enabled = false;
            buttonClear.Visible = false;
            btnTinhTienthoi.Enabled = false;
            btnTinhTienthoi.Visible = false;
            //flag = true;
            labelKhachdua.Text = labelThanhtoan.Text;
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            XoaTT();
            money = 0;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            frmThanhToan_Load(sender, e);
        }

        private void buttonDongy_Click(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<HoaDon> listHoaDon = db.HoaDons.ToList();
            long tientt = Convert.ToInt64(labelThanhtoan.Text);
            long tienkd = Convert.ToInt64(labelKhachdua.Text);
            if (tienkd >= tientt)
            {
                foreach (var item in listHoaDon)
                {
                    if (item.SoHoaDon == ThanhToan.SoHoaDon)
                    {
                        item.TinhTrang = "T";
                        MessageBox.Show("Quý khách đã thanh toán đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.SaveChanges();
                        break;
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Khách hàng cần phải đưa đủ tiền thanh toán!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            }
        }

        public static long money;
        public static long tiendu;

        private void button1ngan_Click(object sender, EventArgs e)
        {
            money += 1000;
            labelKhachdua.Text = money.ToString();
        }

        private void button5ngan_Click(object sender, EventArgs e)
        {
            money += 5000;
            labelKhachdua.Text = money.ToString();

        }

        private void button10ngan_Click(object sender, EventArgs e)
        {
            money += 10000;
            labelKhachdua.Text = money.ToString();

        }

        private void button20ngan_Click(object sender, EventArgs e)
        {
            money += 20000;
            labelKhachdua.Text = money.ToString();

        }

        private void button50ngan_Click(object sender, EventArgs e)
        {
            money += 50000;
            labelKhachdua.Text = money.ToString();

        }

        private void button100ngan_Click(object sender, EventArgs e)
        {
            money += 100000;
            labelKhachdua.Text = money.ToString();

        }

        private void button200ngan_Click(object sender, EventArgs e)
        {
            money += 200000;
            labelKhachdua.Text = money.ToString();

        }

        private void button500ngan_Click(object sender, EventArgs e)
        {
            money += 500000;
            labelKhachdua.Text = money.ToString();

        }

        private void btnTinhTienthoi_Click(object sender, EventArgs e)
        {
            tiendu = money - Convert.ToInt64(labelThanhtoan.Text);
            labelTienthoi.Text = tiendu.ToString();
        }
    }
}
