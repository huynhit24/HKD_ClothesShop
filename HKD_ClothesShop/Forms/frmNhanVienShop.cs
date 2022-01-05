using System;
using System.IO;
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
    public partial class frmNhanVienShop : Form
    {
        public frmNhanVienShop()
        {
            InitializeComponent();
        }

        #region Binding dữ liệu lên các control + datagridview
        private void BindGrid(List<NhanVienBanHang> listNhanVien)
        {
            dgvNhanVien.Rows.Clear();
            foreach (var item in listNhanVien)
            {
                int index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[1].Value = item.MaNhanVien;
                dgvNhanVien.Rows[index].Cells[2].Value = item.HoTen;
                if (item.GioiTinh == "M")
                    dgvNhanVien.Rows[index].Cells[3].Value = "Nam";
                else
                    if (item.GioiTinh == "F")
                    dgvNhanVien.Rows[index].Cells[3].Value = "Nữ";
                else
                    dgvNhanVien.Rows[index].Cells[3].Value = "Khác";
                dgvNhanVien.Rows[index].Cells[4].Value = item.NgaySinh.ToString("dd/MM/yyyy");
                dgvNhanVien.Rows[index].Cells[5].Value = item.SDT;
                dgvNhanVien.Rows[index].Cells[6].Value = item.Email;

                dgvNhanVien.Rows[index].Cells[0].Value = item.AnhThe;

                if (item.Status == true)
                {
                    dgvNhanVien.Rows[index].Cells[7].Value = "Còn sử dụng";
                }
                else
                {
                    dgvNhanVien.Rows[index].Cells[7].Value = "Không sử dụng";
                    dgvNhanVien.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVienShop_Load(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<NhanVienBanHang> listNhanVien = db.NhanVienBanHangs.ToList();
                BindGrid(listNhanVien);
                Tat();
                radNam.Checked = true;
                buttonLuuT.Visible = false;
                buttonHuyT.Visible = false;
                buttonLuuS.Visible = false;
                buttonHuyS.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Thêm, sửa khách hàng
        //hàm xóa thông tin
        private void Xoatt()
        {
            txtMNV.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            radNam.Checked = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra dữ liệu nhập vào ở các Textbox
                bool isValidated = isValidateData();
                if (isValidated)// dữ liệu được xác thực đúng thỏa database
                {
                    using (var db = new QLBanHangHKDEntities())
                    {
                        int index = dgvNhanVien.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvNhanVien.Rows[index];
                        string temp = row.Cells[1].Value.ToString();
                        var nhanvien = db.NhanVienBanHangs.FirstOrDefault(p => p.MaNhanVien == txtMNV.Text);
                        if (nhanvien == null) // chưa có nhân viên có mã này
                        {
                            var hinhanh = (byte[])new ImageConverter().ConvertTo(picAnhNV.Image, typeof(byte[]));
                            var nv = new NhanVienBanHang()
                            {
                                MaNhanVien = txtMNV.Text,
                                HoTen = txtHoTen.Text,
                                GioiTinh = (radNam.Checked == true && radNu.Checked == false && radKhac.Checked == false) ? "M"
                                        : (radNam.Checked == false && radNu.Checked == true && radKhac.Checked == false) ? "F"
                                        : "O",
                                NgaySinh = dtpNgaySinh.Value,
                                SDT = txtSDT.Text,
                                Email = txtEmail.Text,
                                AnhThe = hinhanh,
                                Status = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm Nhân viên {txtMNV.Text} có họ tên {txtHoTen.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.NhanVienBanHangs.Add(nv);
                                db.SaveChanges();
                                frmNhanVienShop_Load(sender, e);
                                MessageBox.Show($"Thêm mới Nhân viên {txtHoTen.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                                btnCreate.Enabled = true;
                                btnUpdate.Enabled = true;
                                btnUpdate.FlatAppearance.BorderColor = Color.Crimson;
                                btnCreate.FlatAppearance.BorderColor = Color.Blue;
                            }
                            else
                            {
                                Xoatt();
                                btnCreate.Enabled = true;
                                btnUpdate.Enabled = true;
                                btnUpdate.FlatAppearance.BorderColor = Color.Crimson;
                                btnCreate.FlatAppearance.BorderColor = Color.Blue;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Mã nhân viên {txtMNV.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
                MessageBox.Show(ex.Message, "Lỗi Thêm Khách (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmNhanVienShop_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    int index = dgvNhanVien.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvNhanVien.Rows[index];
                    string temp = row.Cells[1].Value.ToString();
                    var nhanvien = db.NhanVienBanHangs.FirstOrDefault(p => p.MaNhanVien == txtMNV.Text);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (nhanvien != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateDataUpdate();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //nhanvien.MaNhanVien = txtMNV.Text;
                            nhanvien.HoTen = txtHoTen.Text;
                            nhanvien.GioiTinh = (radNam.Checked == true /*&& radNu.Checked == false && radKhac.Checked == false*/) ? "M"
                                                : (/*radNam.Checked == false &&*/ radNu.Checked == true /*&& radKhac.Checked == false*/) ? "F"
                                                : "O";
                            nhanvien.NgaySinh = dtpNgaySinh.Value;
                            nhanvien.SDT = txtSDT.Text;
                            nhanvien.Email = txtEmail.Text;
                            var hinhanh = (byte[])new ImageConverter().ConvertTo(picAnhNV.Image, typeof(byte[]));
                            nhanvien.AnhThe = hinhanh;
                            nhanvien.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Nhân viên {txtMNV.Text} có họ tên {txtHoTen.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.SaveChanges();
                                frmNhanVienShop_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Nhân viên {txtHoTen.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                                btnCreate.Enabled = true;
                                btnUpdate.Enabled = true;
                                btnUpdate.FlatAppearance.BorderColor = Color.Crimson;
                                btnCreate.FlatAppearance.BorderColor = Color.Blue;
                            }
                            else
                            {
                                Xoatt();
                                btnCreate.Enabled = true;
                                btnUpdate.Enabled = true;
                                btnUpdate.FlatAppearance.BorderColor = Color.Crimson;
                                btnCreate.FlatAppearance.BorderColor = Color.Blue;
                            }
                        }
                        else
                        {
                            ThongBaoLoiDataInput();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Thông tin Nhân viên cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa TT Nhân viên (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmNhanVienShop_Load(sender, e);
            }
        }
        #endregion

        #region Kiểm tra lỗi nhập liệu

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_MKH() == true && KiemTra_ID_HopLe() == true
                   && KiemTra_Limited_HoTen() == true && KiemTra_HoTen_HopLe() == true
                   && KiemTra_Limited_SDT() == true
                   && KiemTra_SDT_HopLe() == true && KiemTra_Limited_Email() == true
                   && KiemTra_Email_HopLe() == true;
        }

        private bool isValidateDataUpdate()
        {
            return KiemTra_BlankEmpty() == true
                   //&& KiemTra_Limited_MKH() == true && KiemTra_ID_HopLe() == true
                   && KiemTra_Limited_HoTen() == true && KiemTra_HoTen_HopLe() == true
                   && KiemTra_Limited_SDT() == true
                   && KiemTra_SDT_HopLe() == true && KiemTra_Limited_Email() == true
                   && KiemTra_Email_HopLe() == true;
        }

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Nhân viên!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_MKH() == false)
            {
                MessageBox.Show("Mã nhân viên phải đủ 4 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_ID_HopLe() == false)
            {
                MessageBox.Show("Mã không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_HoTen() == false)
            {
                MessageBox.Show("Họ tên nhân viên không quá 40 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_HoTen_HopLe() == false)
            {
                MessageBox.Show("Họ tên không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_SDT() == false)
            {
                MessageBox.Show("Số ĐT nhân viên không quá 15 số - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_SDT_HopLe() == false)
            {
                MessageBox.Show("SĐT không hợp lệ!\n\nMời bạn tham khảo:\nViettel: 09xxx, 03xxx\nMobiFone: 09xxx, 07xxx\nVinaPhone: 09xxx, 08xxx\nVietnamobile và Gmobile: 09xxx, 05xxx\nSĐT cũ 11 chữ số: 01xxx", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_Email() == false)
            {
                MessageBox.Show("Email nhân viên không quá 254 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
            if (txtMNV.Text != "" && txtHoTen.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
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
            if (txtMNV.Text.Length == 4)
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
            Match mat = reg.Match(txtMNV.Text);
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNhanVien.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvNhanVien.Rows[dgvNhanVien.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();

                    txtMNV.Text = row.Cells[1].Value.ToString();
                    txtHoTen.Text = row.Cells[2].Value.ToString();
                    if (row.Cells[3].Value.ToString().Trim() == "Nam")
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        if (row.Cells[3].Value.ToString().Trim() == "Nữ")
                        {
                            radNu.Checked = true;
                        }
                        else
                        {
                            radKhac.Checked = true;
                        }
                    }
                    QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                    foreach (var i in db.NhanVienBanHangs)
                    {
                        if (row.Cells[4].Value.ToString() == i.NgaySinh.ToString("dd/MM/yyyy"))
                        {
                            dtpNgaySinh.Value = i.NgaySinh;
                        }
                    }
                    txtSDT.Text = row.Cells[5].Value.ToString();
                    txtEmail.Text = row.Cells[6].Value.ToString();
                    Image logo = (Bitmap)((new ImageConverter()).ConvertFrom(row.Cells[0].Value));
                    picAnhNV.Image = logo;
                    cbStatus.Checked = (row.Cells[7].Value.ToString() == "Còn sử dụng") ? false : true;
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
            List<NhanVienBanHang> listNhanVien = db.NhanVienBanHangs.ToList();
            if (btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvNhanVien.Rows)
                {
                    if (item.DefaultCellStyle.BackColor == Color.GreenYellow)
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

                foreach (DataGridViewRow item in dgvNhanVien.Rows)
                {
                    if (item.DefaultCellStyle.BackColor == Color.GreenYellow)
                    {
                        item.Visible = true;
                    }
                }
                btnHidden.Text = "Ẩn";
                btnHidden.BackColor = Color.GreenYellow;
                btnHidden.ForeColor = Color.Red;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picAnhNV.ImageLocation = openFile.FileName;
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Mo();
            btnCreate.FlatAppearance.BorderColor = Color.DarkGray;
            btnUpdate.FlatAppearance.BorderColor = Color.DarkGray;
            buttonLuuT.Visible = true;
            buttonHuyT.Visible = true;
            btnUpdate.Enabled = false;
            btnCreate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Bạn phải chọn 1 dòng trong bảng rồi nhấn nút sửa!", "Cảnh báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                return;
            }
            Mo();
            btnUpdate.FlatAppearance.BorderColor = Color.DarkGray;
            btnCreate.FlatAppearance.BorderColor = Color.DarkGray;
            buttonLuuS.Visible = true;
            buttonHuyS.Visible = true;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void buttonHuyT_Click(object sender, EventArgs e)
        {
            Tat();
            buttonLuuT.Visible = false;
            buttonHuyT.Visible = false;
            buttonLuuS.Visible = false;
            buttonHuyS.Visible = false;
            btnUpdate.FlatAppearance.BorderColor = Color.Crimson;
            btnCreate.FlatAppearance.BorderColor = Color.Blue;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void buttonHuyS_Click(object sender, EventArgs e)
        {
            Tat();
            buttonLuuT.Visible = false;
            buttonHuyT.Visible = false;
            buttonLuuS.Visible = false;
            buttonHuyS.Visible = false;
            btnUpdate.FlatAppearance.BorderColor = Color.Crimson;
            btnCreate.FlatAppearance.BorderColor = Color.Blue;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void Tat()
        {
            labelMNV.Visible = false;
            labelHoten.Visible = false;
            labelNgaysinh.Visible = false;
            labelSDT.Visible = false;
            labelEmail.Visible = false;
            txtMNV.Visible = false;
            txtHoTen.Visible = false;
            txtSDT.Visible = false;
            txtEmail.Visible = false;
            dtpNgaySinh.Visible = false;
            picAnhNV.Visible = false;
            btnChonAnh.Visible = false;
            radNam.Visible = false;
            radNu.Visible = false;
            radKhac.Visible = false;
            cbStatus.Visible = false;
            groupBoxNVShop.Text = "";
        }

        private void Mo()
        {
            labelMNV.Visible = true;
            labelHoten.Visible = true;
            labelNgaysinh.Visible = true;
            labelSDT.Visible = true;
            labelEmail.Visible = true;
            txtMNV.Visible = true;
            txtHoTen.Visible = true;
            txtSDT.Visible = true;
            txtEmail.Visible = true;
            dtpNgaySinh.Visible = true;
            picAnhNV.Visible = true;
            btnChonAnh.Visible = true;
            radNam.Visible = true;
            radNu.Visible = true;
            radKhac.Visible = true;
            cbStatus.Visible = true;
            groupBoxNVShop.Text = "Nhập thông tin sản phẩm";
        }
    }
}
