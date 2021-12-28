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
    public partial class frmTaoHoaDon : Form
    {

        public frmTaoHoaDon()
        {
            InitializeComponent();
        }

        #region Binding dữ liệu lên các control + datagridview
        private void BindGrid(List<HoaDon> listHoaDon)
        {
            dgvHoaDon.Rows.Clear();
            foreach (var item in listHoaDon)
            {
                int index = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[index].Cells[1].Value = item.MaNhanVien;
                dgvHoaDon.Rows[index].Cells[2].Value = item.SoHoaDon;

                if (item.Status == true)
                {
                    dgvHoaDon.Rows[index].Cells[7].Value = "Còn sử dụng";
                }
                else
                {
                    dgvHoaDon.Rows[index].Cells[7].Value = "Không sử dụng";
                    dgvHoaDon.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaoHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<HoaDon> listHoaDon = db.HoaDons.ToList();
                BindGrid(listHoaDon);
                radNam.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
