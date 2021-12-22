using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HKD_ClothesShop.Modal;

namespace HKD_ClothesShop.Forms
{
    public partial class frmDSKhachHang : Form
    {
        public frmDSKhachHang()
        {
            InitializeComponent();
        }

        private void BindGrid(List<KhachHang> listKhachHang)
        {
            dgvKhachHang.Rows.Clear();
            foreach (var item in listKhachHang)
            {
                int index = dgvKhachHang.Rows.Add();
                dgvKhachHang.Rows[index].Cells[0].Value = item.MaKhachHang;
                dgvKhachHang.Rows[index].Cells[1].Value = item.HoTen;
                if(item.GioiTinh == "M")
                    dgvKhachHang.Rows[index].Cells[2].Value = "Nam";
                else
                    if (item.GioiTinh == "F")
                        dgvKhachHang.Rows[index].Cells[2].Value = "Nữ";
                    else
                        dgvKhachHang.Rows[index].Cells[2].Value = "Khác";
                dgvKhachHang.Rows[index].Cells[3].Value = item.DiaChi;
                dgvKhachHang.Rows[index].Cells[4].Value = item.SDT;
                dgvKhachHang.Rows[index].Cells[5].Value = item.Email;
                if(item.Status == true)
                    dgvKhachHang.Rows[index].Cells[6].Value = "Còn sử dụng";
            }
        }

        private void frmDSKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<KhachHang> listKhachHang = db.KhachHangs.ToList();
                BindGrid(listKhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Hiệu ứng hover màu mè
        private void btnCreate_MouseHover(object sender, EventArgs e)
        {
            btnCreate.BackColor = Color.Coral;
            btnCreate.ForeColor = Color.White;
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Firebrick;
            btnUpdate.ForeColor = Color.White;
        }

        private void btnCreate_MouseLeave(object sender, EventArgs e)
        {
            btnCreate.BackColor = Color.White;
            btnCreate.ForeColor = Color.Black;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.White;
            btnUpdate.ForeColor = Color.Black;
        }
        #endregion
    }
}
