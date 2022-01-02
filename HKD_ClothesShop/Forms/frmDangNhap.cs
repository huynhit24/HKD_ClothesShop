using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HKD_ClothesShop.Modal;

namespace HKD_ClothesShop.Forms
{
    public partial class frmDangNhap : Form
    {
        // dùng để chứa username, password để xác minh quyền sử dụng
        string username;
        string password;
        string quyenhan;
        QLBanHangHKDEntities context = new QLBanHangHKDEntities();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát Form Đăng Nhập!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                Application.Exit();
            }
        }

        private void lbDoiPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmDoiMatKhau().Show();
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

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        public static string getStringSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", ""); // replace tránh SQL Injection
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text.Trim();
            password = txtPassword.Text.Trim();

            if (isValidateData() == true)
            {
                string sha265 = getStringSHA256Hash(txtPassword.Text).ToLower().Substring(0,15);

                if (KiemTraDangNhap(username, sha265) == true)
                {
                    switch (quyenhan)
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
                    }
                }
                else
                {
                    MessageBox.Show("Thông Tin Tài Khoản Đăng Nhập Không Đúng - Mời bạn thử lại!", "Lỗi Đăng Nhập", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                ThongBaoLoiDataInput();
            }
        }

        #region Kiểm tra lỗi nhập liệu

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_Username() == true && KiemTra_Username_HopLe() == true
                   && KiemTra_Limited_Pass() == true
                   && KiemTra_Pass_HopLe() == true;
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
        }

        private bool KiemTra_BlankEmpty()
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
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


        #endregion
    }
}
