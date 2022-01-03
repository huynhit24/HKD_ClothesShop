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
                {
                    dgvKhachHang.Rows[index].Cells[6].Value = "Còn sử dụng";
                }
                else
                {
                    dgvKhachHang.Rows[index].Cells[6].Value = "Không sử dụng";
                    dgvKhachHang.Rows[index].DefaultCellStyle.BackColor = Color.Black;
                }
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
        //hàm xóa thông tin
        private void Xoatt()
        {
            txtMKH.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            radNam.Checked = true;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra dữ liệu nhập vào ở các Textbox
                bool isValidated = isValidateData();
                if (isValidated)// dữ liệu được xác thực đúng thỏa database
                {
                    using (var db = new QLBanHangHKDEntities())
                    {
                        int index = dgvKhachHang.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvKhachHang.Rows[index];
                        string temp = row.Cells[0].Value.ToString();
                        var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                        if(khachhang == null) // chưa có khách hàng có mã này
                        {
                            var kh = new KhachHang()
                            {
                                MaKhachHang = txtMKH.Text,
                                HoTen = txtHoTen.Text,
                                GioiTinh = (radNam.Checked == true && radNu.Checked == false && radKhac.Checked == false) ? "M"
                                        : (radNam.Checked == false && radNu.Checked == true && radKhac.Checked == false) ? "F"
                                        : "O",
                                DiaChi = txtDiaChi.Text,
                                SDT = txtSDT.Text,
                                Email = txtEmail.Text,
                                Status = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm khách hàng {txtMKH.Text} có họ tên {txtHoTen.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.KhachHangs.Add(kh);
                                db.SaveChanges();
                                frmDSKhachHang_Load(sender, e);
                                MessageBox.Show($"Thêm mới Khách hàng {txtHoTen.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }
                                
                        }
                        else
                        {
                            MessageBox.Show($"Mã khách hàng {txtMKH.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        }
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
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    int index = dgvKhachHang.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvKhachHang.Rows[index];
                    string temp = row.Cells[0].Value.ToString();
                    var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == temp);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if(khachhang != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateDataUpdate();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //khachhang.MaKhachHang = txtMKH.Text;
                            khachhang.HoTen = txtHoTen.Text;
                            khachhang.GioiTinh = (radNam.Checked == true /*&& radNu.Checked == false && radKhac.Checked == false*/) ? "M"
                                                : (/*radNam.Checked == false &&*/ radNu.Checked == true /*&& radKhac.Checked == false*/) ? "F"
                                                : "O";
                            khachhang.DiaChi = txtDiaChi.Text;
                            khachhang.SDT = txtSDT.Text;
                            khachhang.Email = txtEmail.Text;
                            khachhang.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật khách hàng {txtMKH.Text} có họ tên {txtHoTen.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.SaveChanges();
                                frmDSKhachHang_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Khách hàng {txtHoTen.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            ThongBaoLoiDataInput();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Thông tin Khách hàng cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa Khách (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmDSKhachHang_Load(sender, e);
            }
        }
        #endregion

        #region Kiểm tra lỗi nhập liệu

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_MKH() == true && KiemTra_ID_HopLe() == true
                   && KiemTra_Limited_HoTen() == true && KiemTra_HoTen_HopLe() == true
                   && KiemTra_Limited_DiaChi() == true
                   && KiemTra_DiaChi_HopLe() == true && KiemTra_Limited_SDT() == true
                   && KiemTra_SDT_HopLe() == true && KiemTra_Limited_Email() == true
                   && KiemTra_Email_HopLe() == true;
        }

        private bool isValidateDataUpdate()
        {
            return KiemTra_BlankEmpty() == true
                   //&& KiemTra_Limited_MKH() == true && KiemTra_ID_HopLe() == true
                   && KiemTra_Limited_HoTen() == true && KiemTra_HoTen_HopLe() == true
                   && KiemTra_Limited_DiaChi() == true
                   && KiemTra_DiaChi_HopLe() == true && KiemTra_Limited_SDT() == true
                   && KiemTra_SDT_HopLe() == true && KiemTra_Limited_Email() == true
                   && KiemTra_Email_HopLe() == true;
        }

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
            if (KiemTra_ID_HopLe() == false)
            {
                MessageBox.Show("Mã không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_HoTen() == false)
            {
                MessageBox.Show("Họ tên khách hàng không quá 40 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_HoTen_HopLe() == false)
            {
                MessageBox.Show("Họ tên không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_DiaChi() == false)
            {
                MessageBox.Show("Địa chỉ khách hàng không quá 200 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_DiaChi_HopLe() == false)
            {
                MessageBox.Show("Địa chỉ không hợp lệ - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_SDT() == false)
            {
                MessageBox.Show("Số ĐT khách hàng không quá 15 số - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_SDT_HopLe() == false)
            {
                MessageBox.Show("SĐT không hợp lệ!\n\nMời bạn tham khảo:\nViettel: 09xxx, 03xxx\nMobiFone: 09xxx, 07xxx\nVinaPhone: 09xxx, 08xxx\nVietnamobile và Gmobile: 09xxx, 05xxx\nSĐT cũ 11 chữ số: 01xxx", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
            if (txtMKH.Text != "" && txtHoTen.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
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

        private bool KiemTra_ID_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_ID);
            Match mat = reg.Match(txtMKH.Text);
            if (mat.Success)
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

        private bool KiemTra_HoTen_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_HoTen);
            Match mat = reg.Match(txtHoTen.Text);
            if (mat.Success)
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

        private bool KiemTra_DiaChi_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_DiaChi);
            Match mat = reg.Match(txtDiaChi.Text);
            if (mat.Success)
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

        private bool KiemTra_SDT_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_SDT);
            Match mat = reg.Match(txtSDT.Text);
            if (mat.Success)
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

        #endregion
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachHang.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvKhachHang.Rows[dgvKhachHang.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();

                    txtMKH.Text = row.Cells[0].Value.ToString();
                    txtHoTen.Text = row.Cells[1].Value.ToString();
                    if (row.Cells[2].Value.ToString().Trim() == "Nam")
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        if (row.Cells[2].Value.ToString().Trim() == "Nữ")
                        {
                            radNu.Checked = true;
                        }
                        else
                        {
                            radKhac.Checked = true;
                        }
                    }
                    txtDiaChi.Text = row.Cells[3].Value.ToString();
                    txtSDT.Text = row.Cells[4].Value.ToString();
                    txtEmail.Text = row.Cells[5].Value.ToString();
                    cbStatus.Checked = (row.Cells[6].Value.ToString() == "Còn sử dụng") ? false : true;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHidden_Click(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<KhachHang> listKhachHang = db.KhachHangs.ToList();
            if(btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvKhachHang.Rows)
                {
                    if (item.DefaultCellStyle.BackColor == Color.Black)
                    {
                        item.Visible = false;
                    }
                }
                btnHidden.Text = "Hiện";
                btnHidden.BackColor = Color.Blue;
                btnHidden.ForeColor = Color.Yellow;
            }
            else
            {

                foreach (DataGridViewRow item in dgvKhachHang.Rows)
                {
                    if (item.DefaultCellStyle.BackColor == Color.Black)
                    {
                        item.Visible = true;
                    }
                }
                btnHidden.Text = "Ẩn";
                btnHidden.BackColor = Color.GreenYellow;
                btnHidden.ForeColor = Color.Red;
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Xoatt();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
