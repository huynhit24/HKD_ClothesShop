using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using HKD_ClothesShop.Modal;

namespace HKD_ClothesShop.Forms
{
    public partial class frmDoiMatKhau : Form
    {

        // dùng để chứa username, password để xác minh quyền sử dụng
        string username;
        string password;
        string passwordnew;
        string quyenhan;
        QLBanHangHKDEntities context = new QLBanHangHKDEntities();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmDangNhap().Show();
        }

        public bool KiemTraDangNhap(string TenDangNhap, string MatKhau)
        {
            var ktDangNhap = context.ThongTinTaiKhoans.SingleOrDefault(p => p.TenDangNhap == TenDangNhap
                             && p.MatKhau == MatKhau);
            if (ktDangNhap != null)
            {
                quyenhan = ktDangNhap.VaiTroID;
                return true;
            }
            return false;
        }

        public static string getStringSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", ""); // replace tránh SQL Injection
            }
        }

        #region Kiểm tra lỗi nhập liệu

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_Username() == true && KiemTra_Username_HopLe() == true
                   && KiemTra_Limited_Pass() == true
                   && KiemTra_Pass_HopLe() == true
                   && KiemTra_Limited_NewPass() == true && KiemTra_NewPass_HopLe() == true;
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
            if (KiemTra_Limited_NewPass() == false)
            {
                MessageBox.Show("Password mới phải đủ 8 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_NewPass_HopLe() == false)
            {
                MessageBox.Show("Password mới phải có ít nhất 1 ký tự viết Hoa tiếng Anh, 1 chữ số, 1 ký tự đặc biệt: !@#...!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        private bool KiemTra_BlankEmpty()
        {
            if (txtUsername.Text != "" && txtPassword.Text != "" && txtNewpass.Text != "")
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

        private bool KiemTra_Limited_NewPass()
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

        private bool KiemTra_NewPass_HopLe()
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



        #endregion

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text.Trim();
            password = txtPassword.Text.Trim();
            passwordnew = txtNewpass.Text.Trim();

            if (isValidateData() == true)
            {
                string sha265 = getStringSHA256Hash(txtPassword.Text).ToLower().Substring(0, 15);
                string shanewpass = getStringSHA256Hash(txtNewpass.Text).ToLower().Substring(0, 15);
                if (KiemTraDangNhap(username, sha265) == true)
                {
                    try
                    {
                        var ktDoiPass = context.ThongTinTaiKhoans.SingleOrDefault(p => p.TenDangNhap == username
                             && p.MatKhau == sha265);
                        ktDoiPass.MatKhau = shanewpass;
                        var ktPass = context.ThongTinTaiKhoans.SingleOrDefault(p => p.TenDangNhap == username
                             && p.MatKhau == shanewpass);
                        if(ktPass != null)
                        {
                            MessageBox.Show("Đổi pass thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            MessageBox.Show("Đổi pass không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Xảy ra lỗi gì đó!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    

                    /*switch (quyenhan)
                    {
                        case "ad":
                            MessageBox.Show("Đăng Nhập Tài Khoản Admin Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            ThongTinDangNhap.Username = username;
                            ThongTinDangNhap.Password = password;
                            ThongTinDangNhap.Quyenhan = quyenhan;
                            new frmMain().Show();
                            break;
                        case "bh":
                            MessageBox.Show("Đăng Nhập Tài Khoản QL Bán hàng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            ThongTinDangNhap.Username = username;
                            ThongTinDangNhap.Password = password;
                            ThongTinDangNhap.Quyenhan = quyenhan;
                            new frmMain().Show();
                            break;
                    }*/
                }
                else
                {
                    MessageBox.Show("Không tồn tại tài khoản trong hệ thống cần đổi pass  - Mời bạn thử lại!", "Lỗi Đăng Nhập", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                ThongBaoLoiDataInput();
            }
        }
    }
}
