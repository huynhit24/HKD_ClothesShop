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
    public partial class frmThuongHieu : Form
    {
        public frmThuongHieu()
        {
            InitializeComponent();
        }

        #region Binding dữ liệu lên các control + datagridview
        private void BindGrid(List<ThuongHieu> listThuongHieu)
        {
            dgvThuongHieu.Rows.Clear();
            foreach (var item in listThuongHieu)
            {
                int index = dgvThuongHieu.Rows.Add();
                dgvThuongHieu.Rows[index].Cells[0].Value = item.Logo;
                dgvThuongHieu.Rows[index].Cells[1].Value = item.MaThuongHieu;
                dgvThuongHieu.Rows[index].Cells[2].Value = item.TenThuongHieu;
                dgvThuongHieu.Rows[index].Cells[3].Value = item.DiaChi;
                dgvThuongHieu.Rows[index].Cells[4].Value = item.DienThoai;
                if (item.Status == true)
                {
                    dgvThuongHieu.Rows[index].Cells[5].Value = "Còn sử dụng";
                }
                else
                {
                    dgvThuongHieu.Rows[index].Cells[5].Value = "Không sử dụng";
                    dgvThuongHieu.Rows[index].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThuongHieu_Load(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<ThuongHieu> listThuongHieu = db.ThuongHieux.ToList();
                BindGrid(listThuongHieu);
                Tat();
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

        #region Thêm, sửa thương hiệu
        //hàm xóa thông tin
        private void Xoatt()
        {
            txtMTH.Text = "";
            txtTenTH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
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
                        int index = dgvThuongHieu.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvThuongHieu.Rows[index];
                        string temp = row.Cells[1].Value.ToString();
                        var thuonghieu = db.ThuongHieux.FirstOrDefault(p => p.MaThuongHieu == txtMTH.Text);
                        if (thuonghieu == null) // chưa có thương hiệu có mã này
                        {
                            var hinhanh = (byte[])new ImageConverter().ConvertTo(picLogo.Image, typeof(byte[]));
                            var th = new ThuongHieu()
                            {
                                MaThuongHieu = txtMTH.Text,
                                TenThuongHieu = txtTenTH.Text,
                                DiaChi = txtDiaChi.Text,
                                DienThoai = txtSDT.Text,
                                Logo = hinhanh,
                                Status = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm Thương hiệu {txtMTH.Text} có họ tên {txtTenTH.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.ThuongHieux.Add(th);
                                db.SaveChanges();
                                frmThuongHieu_Load(sender, e);
                                MessageBox.Show($"Thêm mới Thương hiệu {txtTenTH.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show($"Mã thương hiệu {txtMTH.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
                MessageBox.Show(ex.Message, "Lỗi Thêm Thương hiệu (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmThuongHieu_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    int index = dgvThuongHieu.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvThuongHieu.Rows[index];
                    string temp = row.Cells[0].Value.ToString();
                    var thuonghieu = db.ThuongHieux.FirstOrDefault(p => p.MaThuongHieu == txtMTH.Text);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (thuonghieu != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateDataUpdate();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //thuonghieu.MaThuongHieu = txtMTH.Text;
                            thuonghieu.TenThuongHieu = txtTenTH.Text;
                            thuonghieu.DienThoai = txtSDT.Text;
                            var hinhanh = (byte[])new ImageConverter().ConvertTo(picLogo.Image, typeof(byte[]));
                            thuonghieu.Logo = hinhanh;
                            thuonghieu.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Thương hiệu {txtMTH.Text} có họ tên {txtTenTH.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.SaveChanges();
                                frmThuongHieu_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Thương hiệu {txtTenTH.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Không tìm thấy Thông tin Thương hiệu cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa TT Thương hiệu (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmThuongHieu_Load(sender, e);
            }
        }
        #endregion

        #region Kiểm tra lỗi nhập liệu

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_MTH() == true && KiemTra_ID_HopLe() == true
                   && KiemTra_Limited_HoTen() == true && KiemTra_HoTen_HopLe() == true
                   && KiemTra_Limited_DiaChi() == true && KiemTra_DiaChi_HopLe() == true
                   && KiemTra_Limited_SDT() == true && KiemTra_SDT_HopLe() == true;
        }

        private bool isValidateDataUpdate()
        {
            return KiemTra_BlankEmpty() == true
                   //&& KiemTra_Limited_MTH() == true && KiemTra_ID_HopLe() == true
                   && KiemTra_Limited_HoTen() == true && KiemTra_HoTen_HopLe() == true
                   && KiemTra_Limited_DiaChi() == true && KiemTra_DiaChi_HopLe() == true
                   && KiemTra_Limited_SDT() == true && KiemTra_SDT_HopLe() == true;
        }

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Thương hiệu!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_MTH() == false)
            {
                MessageBox.Show("Mã thương hiệu phải đủ 3 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_ID_HopLe() == false)
            {
                MessageBox.Show("Mã không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_HoTen() == false)
            {
                MessageBox.Show("Tên thương hiệu nhân viên không quá 30 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_HoTen_HopLe() == false)
            {
                MessageBox.Show("Tên thương hiệu không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
                MessageBox.Show("Số ĐT nhân viên không quá 15 số - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_SDT_HopLe() == false)
            {
                MessageBox.Show("SĐT không hợp lệ!\n\nMời bạn tham khảo:\nViettel: 09xxx, 03xxx\nMobiFone: 09xxx, 07xxx\nVinaPhone: 09xxx, 08xxx\nVietnamobile và Gmobile: 09xxx, 05xxx\nSĐT cũ 11 chữ số: 01xxx", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        private bool KiemTra_BlankEmpty()
        {
            if (txtMTH.Text != "" && txtTenTH.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_MTH()
        {
            if (txtMTH.Text.Length == 3)
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
            Match mat = reg.Match(txtMTH.Text);
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
            if (txtTenTH.Text.Length <= 30)
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
            Match mat = reg.Match(txtTenTH.Text);
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


        #endregion

        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvThuongHieu.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvThuongHieu.Rows[dgvThuongHieu.CurrentCell.RowIndex];
                    QLBanHangHKDEntities db = new QLBanHangHKDEntities();

                    Image logo = (Bitmap)((new ImageConverter()).ConvertFrom(row.Cells[0].Value));
                    picLogo.Image = logo;
                    txtMTH.Text = row.Cells[1].Value.ToString();
                    txtTenTH.Text = row.Cells[2].Value.ToString();
                    txtDiaChi.Text = row.Cells[3].Value.ToString();
                    txtSDT.Text = row.Cells[4].Value.ToString();
                    cbStatus.Checked = (row.Cells[5].Value.ToString() == "Còn sử dụng") ? false : true;
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

        private void btnChonLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picLogo.ImageLocation = openFile.FileName;
            }
        }

        private void btnHidden_Click(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<ThuongHieu> listThuongHieu = db.ThuongHieux.ToList();
            if (btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvThuongHieu.Rows)
                {
                    if (item.DefaultCellStyle.BackColor == Color.Orange)
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

                foreach (DataGridViewRow item in dgvThuongHieu.Rows)
                {
                    if (item.DefaultCellStyle.BackColor == Color.Orange)
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
            labelMTH.Visible = false;
            labelTenTH.Visible = false;
            labelDiachi.Visible = false;
            labelSDT.Visible = false;
            txtMTH.Visible = false;
            txtTenTH.Visible = false;
            txtDiaChi.Visible = false;
            txtSDT.Visible = false;
            picLogo.Visible = false;
            btnChonLogo.Visible = false;
            cbStatus.Visible = false;
            groupBoxNV.Text = "";
        }

        private void Mo()
        {
            labelMTH.Visible = true;
            labelTenTH.Visible = true;
            labelDiachi.Visible = true;
            labelSDT.Visible = true;
            txtMTH.Visible = true;
            txtTenTH.Visible = true;
            txtDiaChi.Visible = true;
            txtSDT.Visible = true;
            picLogo.Visible = true;
            btnChonLogo.Visible = true;
            cbStatus.Visible = true;
            groupBoxNV.Text = "Nhập thông tin nhân viên";
        }
    }
}
