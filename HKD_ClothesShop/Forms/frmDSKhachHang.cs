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
    public partial class frmDSKhachHang : Form
    {
        public frmDSKhachHang()
        {
            InitializeComponent();
        }

        #region Binding dữ liệu lên các control + datagridview
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
                radNam.Checked = true;
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
        #endregion

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

        #region Thêm, sửa khách hàng
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra dữ liệu nhập vào ở các Textbox
                bool isValidated = KiemTra_BlankEmpty() == true && KiemTra_Limited_MKH() == true 
                                    && KiemTra_Limited_HoTen() == true && KiemTra_Limited_DiaChi() == true 
                                    && KiemTra_Limited_SDT() == true && KiemTra_Limited_Email() == true
                                    && KiemTra_Email_HopLe() == true;
                if (isValidated)// dữ liệu được xác thực đúng thỏa database
                {
                    using (var db = new QLBanHangHKDEntities())
                    {
                        var khachhang = new KhachHang()
                        {
                            MaKhachHang = txtMKH.Text,
                            HoTen = txtHoTen.Text,
                            GioiTinh = (radNam.Checked == true && radNu.Checked == false && radKhac.Checked == false) ? "M" 
                                        : (radNam.Checked == false && radNu.Checked == true && radKhac.Checked == false) ? "F" 
                                        : "O",
                            DiaChi = txtDiaChi.Text,
                            SDT = txtSDT.Text,
                            Email = txtEmail.Text,
                            Status = (cbStatus.Checked == false) ? true : false
                        };
                        db.KhachHangs.Add(khachhang);
                        db.SaveChanges();
                        frmDSKhachHang_Load(sender, e);
                        MessageBox.Show($"Thêm mới Khách hàng {txtHoTen.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ThongBaoLoiDataInput();
                }
                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Thêm Khách (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmDSKhachHang_Load(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Khách hàng!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_MKH() == false)
            {
                MessageBox.Show("Mã khách hàng phải đủ 5 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_HoTen() == false)
            {
                MessageBox.Show("Họ tên khách hàng không quá 40 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_DiaChi() == false)
            {
                MessageBox.Show("Địa chỉ khách hàng không quá 200 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_SDT() == false)
            {
                MessageBox.Show("Số ĐT khách hàng không quá 15 số - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_Email() == false)
            {
                MessageBox.Show("Email khách hàng không quá 254 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Email_HopLe() == false)
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        private bool KiemTra_BlankEmpty()
        {
            if (txtMKH.Text != "" || txtHoTen.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_MKH()
        {
           if(txtMKH.Text.Length == 5)
           {
                return true;
           }
           else
           {
                return false;
           }
        }

        private bool KiemTra_Limited_HoTen()
        {
            if (txtHoTen.Text.Length <= 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_DiaChi()
        {
            if (txtDiaChi.Text.Length <= 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_SDT()
        {
            if (txtSDT.Text.Length <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_Email()
        {
            if (txtEmail.Text.Length <= 254)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Email_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_Email);
            Match mat = reg.Match(txtEmail.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_SDT_HopLe()
        {
            return true;
        }
    }
}
