using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using HKD_ClothesShop.Modal;

namespace HKD_ClothesShop.Forms
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        #region Binding dữ liệu lên các control + datagridview

        private void FillVaiTroCombobox(List<PhanQuyen> listQuyen)
        {
            this.cmbVaiTro.DataSource = listQuyen;
            this.cmbVaiTro.DisplayMember = "TenVaiTro";
            this.cmbVaiTro.ValueMember = "VaiTroID";
        }
        private void BindGrid(List<ThongTinTaiKhoan> listAcc)
        {
            dgvTaiKhoan.Rows.Clear();
            foreach (var item in listAcc)
            {
                int index = dgvTaiKhoan.Rows.Add();
                dgvTaiKhoan.Rows[index].Cells[1].Value = item.TenDangNhap;
                dgvTaiKhoan.Rows[index].Cells[0].Value = item.HoTen;
                
                dgvTaiKhoan.Rows[index].Cells[2].Value = item.MatKhau;
                dgvTaiKhoan.Rows[index].Cells[3].Value = item.SDT;
                dgvTaiKhoan.Rows[index].Cells[4].Value = item.Email;
                if (item.VaiTroID == "ad")
                {
                    dgvTaiKhoan.Rows[index].Cells[5].Value = "Admin";
                }
                else
                {
                    dgvTaiKhoan.Rows[index].Cells[5].Value = "Bán hàng";
                    //dgvTaiKhoan.Rows[index].DefaultCellStyle.BackColor = Color.Black;
                }
                /*if (item.Status == true)
                {
                    dgvTaiKhoan.Rows[index].Cells[6].Value = "Còn sử dụng";
                }
                else
                {
                    dgvTaiKhoan.Rows[index].Cells[6].Value = "Không sử dụng";
                    dgvTaiKhoan.Rows[index].DefaultCellStyle.BackColor = Color.Black;
                }*/
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<ThongTinTaiKhoan> listAcc = db.ThongTinTaiKhoans.ToList();
                List<PhanQuyen> listQuyen = db.PhanQuyens.ToList();
                BindGrid(listAcc);
                FillVaiTroCombobox(listQuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        //hàm băm dùng để băm mật khẩu
        public static string getStringSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", ""); // replace tránh SQL Injection
            }
        }

        // xóa thông tin Reset
        private void Xoatt()
        {
            txtUsername.Text = "";
            txtHoTen.Text = "";
            txtPassword.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        // hàm thêm 1 tài khoản đăng nhập mới
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
                        /*int index = dgvTaiKhoan.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvTaiKhoan.Rows[index];
                        string temp = row.Cells[0].Value.ToString();*/
                        string sha265 = getStringSHA256Hash(txtPassword.Text).ToLower();
                        var khachhang = db.ThongTinTaiKhoans.FirstOrDefault(p => p.TenDangNhap == txtUsername.Text.Trim() && p.MatKhau == sha265.Substring(0,15));
                        if (khachhang == null) // chưa có khách hàng có mã này
                        {
                            
                            var kh = new ThongTinTaiKhoan()
                            {
                                TenDangNhap = txtUsername.Text,
                                HoTen = txtHoTen.Text,
                                MatKhau = sha265.Substring(0,15),
                                SDT = txtSDT.Text,
                                Email = txtEmail.Text,
                                VaiTroID = (cmbVaiTro.Text  == "Admin") ? "ad" : "bh"
                                //Status = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm Tài khoản có họ tên {txtHoTen.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.ThongTinTaiKhoans.Add(kh);
                                db.SaveChanges();
                                frmTaiKhoan_Load(sender, e);
                                MessageBox.Show($"Thêm mới Tài khoản {txtHoTen.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }

                        }
                        else
                        {
                            MessageBox.Show($"Tài khoản này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    ThongBaoLoiDataInput();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Thêm Tài khoản đăng nhập (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTaiKhoan_Load(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    /*int index = dgvTaiKhoan.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvTaiKhoan.Rows[index];
                    string temp = row.Cells[0].Value.ToString();
                    string tempu = row.Cells[1].Value.ToString();
                    string tempp = row.Cells[2].Value.ToString();*/
                    var khachhang = db.ThongTinTaiKhoans.FirstOrDefault(p => p.TenDangNhap == txtUsername.Text && p.MatKhau == txtPassword.Text);
                    //var khachhang = db.ThongTinTaiKhoans.FirstOrDefault(p => p.TenDangNhap == tempu && p.MatKhau == tempp);

                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (khachhang != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateDataUpdate();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //khachhang.TenDangNhap = txtUsername.Text;
                            khachhang.HoTen = txtHoTen.Text;
                            /*khachhang.GioiTinh = (radNam.Checked == true *//*&& radNu.Checked == false && radKhac.Checked == false*//*) ? "M"
                                                : (*//*radNam.Checked == false &&*//* radNu.Checked == true *//*&& radKhac.Checked == false*//*) ? "F"
                                                : "O";*/
                            //khachhang.MatKhau = txtPassword.Text;
                            khachhang.SDT = txtSDT.Text;
                            khachhang.Email = txtEmail.Text;
                            khachhang.VaiTroID = (cmbVaiTro.Text == "Admin") ? "ad" : "bh";
                            //khachhang.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật tài khoản có họ tên {txtHoTen.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.SaveChanges();
                                frmTaiKhoan_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Tài khoản {txtHoTen.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Không tìm thấy Thông tin Tài khoản cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa TT Tài khoản (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTaiKhoan_Load(sender, e);
            }
        }

        #region Kiểm tra lỗi nhập liệu

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_Username() == true && KiemTra_Username_HopLe() == true
                   && KiemTra_Limited_HoTen() == true && KiemTra_HoTen_HopLe() == true
                   && KiemTra_Limited_Pass() == true
                   && KiemTra_Pass_HopLe() == true && KiemTra_Limited_SDT() == true
                   && KiemTra_SDT_HopLe() == true && KiemTra_Limited_Email() == true
                   && KiemTra_Email_HopLe() == true;
        }

        private bool isValidateDataUpdate()
        {
            return KiemTra_BlankEmpty() == true
                   //&& KiemTra_Limited_Username() == true && KiemTra_Username_HopLe() == true
                   && KiemTra_Limited_HoTen() == true && KiemTra_HoTen_HopLe() == true
                   //&& KiemTra_Limited_Pass() == true && KiemTra_Pass_HopLe() == true 
                   && KiemTra_Limited_SDT() == true
                   && KiemTra_SDT_HopLe() == true && KiemTra_Limited_Email() == true
                   && KiemTra_Email_HopLe() == true;
        }

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Tài khoản!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_Username() == false)
            {
                MessageBox.Show("Username có số ký tự trong khoảng từ 8 - 30 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Username_HopLe() == false)
            {
                MessageBox.Show("Username không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
            if (KiemTra_Limited_Pass() == false)
            {
                MessageBox.Show("Password phải đủ 8 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Pass_HopLe() == false)
            {
                MessageBox.Show("Password phải có ít nhất 1 ký tự viết Hoa tiếng Anh, 1 chữ số, 1 ký tự đặc biệt: !@#...!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
            if (txtUsername.Text != "" && txtHoTen.Text != "" && txtPassword.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_Username()
        {
            if (txtUsername.Text.Length <= 30 && txtUsername.Text.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Username_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_ID);
            Match mat = reg.Match(txtUsername.Text);
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

        private bool KiemTra_Limited_Pass()
        {
            if (txtPassword.Text.Length == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Pass_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_Password);
            Match mat = reg.Match(txtPassword.Text);
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

        private void btnHidden_Click(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<ThongTinTaiKhoan> listAcc = db.ThongTinTaiKhoans.ToList();
            if (btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvTaiKhoan.Rows)
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

                foreach (DataGridViewRow item in dgvTaiKhoan.Rows)
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

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTaiKhoan.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvTaiKhoan.Rows[dgvTaiKhoan.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();

                    txtHoTen.Text = row.Cells[0].Value.ToString();
                    txtUsername.Text = row.Cells[1].Value.ToString();
                    txtPassword.Text = row.Cells[2].Value.ToString();
                    txtSDT.Text = row.Cells[3].Value.ToString();
                    txtEmail.Text = row.Cells[4].Value.ToString();
                    cmbVaiTro.Text = (row.Cells[5].Value.ToString() == "Admin") ? "Admin" : "Bán hàng";
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
