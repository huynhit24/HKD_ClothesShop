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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }
        #region Binding dữ liệu lên các control + datagridview
        private void BindGrid(List<SanPham> listSanPham)
        {
            dgvSanPham.Rows.Clear();
            foreach (var item in listSanPham)
            {
                int index = dgvSanPham.Rows.Add();
                dgvSanPham.Rows[index].Cells[0].Value = item.AnhBiaSP;
                dgvSanPham.Rows[index].Cells[1].Value = item.MaSanPham;
                dgvSanPham.Rows[index].Cells[2].Value = item.TenSanPham;
                dgvSanPham.Rows[index].Cells[3].Value = item.DonViTinh;
                dgvSanPham.Rows[index].Cells[4].Value = item.DonGia;
                dgvSanPham.Rows[index].Cells[5].Value = item.ChatLieu;
                dgvSanPham.Rows[index].Cells[6].Value = item.MaLoaiSP;
                dgvSanPham.Rows[index].Cells[7].Value = item.MaThuongHieu;
                dgvSanPham.Rows[index].Cells[8].Value = item.NgayCapNhat.ToString("dd/MM/yyyy");
                dgvSanPham.Rows[index].Cells[9].Value = item.MoTa;

                if (item.TrangThai == true)
                {
                    dgvSanPham.Rows[index].Cells[7].Value = "Còn sử dụng";
                }
                else
                {
                    dgvSanPham.Rows[index].Cells[7].Value = "Không sử dụng";
                    dgvSanPham.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<SanPham> listSanPham = db.SanPhams.ToList();
                BindGrid(listSanPham);
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
            txtMSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            txtChatLieu.Text = "";
            txtMoTa.Text = "";
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
                        int index = dgvSanPham.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvSanPham.Rows[index];
                        string temp = row.Cells[1].Value.ToString();
                        var sanpham = db.SanPhams.FirstOrDefault(p => p.MaSanPham == txtMSP.Text);
                        if (sanpham == null) // chưa có sản phẩm có mã này
                        {
                            var hinhanh = (byte[])new ImageConverter().ConvertTo(picAnhSP.Image, typeof(byte[]));
                            var sp = new SanPham()
                            {
                                MaSanPham = txtMSP.Text,
                                MaLoaiSP = cmbLSP.SelectedItem.ToString(),
                                MaThuongHieu = cmbMTH.SelectedItem.ToString(),
                                TenSanPham = txtTenSP.Text,
                                DonViTinh = cmbDVT.SelectedItem.ToString(),
                                NgayCapNhat = dtpDayUpdate.Value,
                                MoTa = txtMoTa.Text ?? null,
                                AnhBiaSP = hinhanh,
                                TrangThai = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm Sản phẩm {txtMSP.Text} có tên {txtTenSP.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.SanPhams.Add(sp);
                                db.SaveChanges();
                                frmNhapHang_Load(sender, e);
                                MessageBox.Show($"Thêm mới sản phẩm {txtTenSP.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Mã sản phẩm {txtMSP.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
                MessageBox.Show(ex.Message, "Lỗi Thêm Sản phẩm (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmNhapHang_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    int index = dgvSanPham.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvSanPham.Rows[index];
                    string temp = row.Cells[1].Value.ToString();
                    var sanpham = db.SanPhams.FirstOrDefault(p => p.MaSanPham == txtMSP.Text);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (sanpham != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateData();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            sanpham.MaSanPham = txtMSP.Text;
                            sanpham.TenSanPham = txtTenSP.Text;
                            sanpham.MaLoaiSP = cmbLSP.SelectedItem.ToString();
                            sanpham.MaThuongHieu = cmbMTH.SelectedItem.ToString();
                            sanpham.NgayCapNhat = dtpDayUpdate.Value;
                            sanpham.DonViTinh = cmbDVT.SelectedItem.ToString();
                            sanpham.DonGia = Convert.ToDecimal(txtDonGia.Text);
                            sanpham.ChatLieu = txtChatLieu.Text;
                            var hinhanh = (byte[])new ImageConverter().ConvertTo(picAnhSP.Image, typeof(byte[]));
                            sanpham.AnhBiaSP = hinhanh;
                            sanpham.TrangThai = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Sản phẩm {txtMSP.Text} có tên {txtTenSP.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.SaveChanges();
                                frmNhapHang_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Sản phẩm {txtTenSP.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Không tìm thấy Thông tin Sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa TT Sản phẩm (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmNhapHang_Load(sender, e);
            }
        }
        #endregion

        #region Kiểm tra lỗi nhập liệu

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_MSP() == true && KiemTra_MSP_HopLe() == true
                   && KiemTra_Limited_TenSP() == true && KiemTra_TenSP_HopLe() == true
                   && KiemTra_Limited_DonGia() == true
                   && KiemTra_DonGia_HopLe() == true && KiemTra_Limited_ChatLieu() == true
                   && KiemTra_ChatLieu_HopLe() == true;
        }

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Nhân viên!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_MSP() == false)
            {
                MessageBox.Show("Mã nhân viên phải đủ 4 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_MSP_HopLe() == false)
            {
                MessageBox.Show("Mã không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_TenSP() == false)
            {
                MessageBox.Show("Họ tên nhân viên không quá 40 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_TenSP_HopLe() == false)
            {
                MessageBox.Show("Họ tên không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_DonGia() == false)
            {
                MessageBox.Show("Số ĐT nhân viên không quá 15 số - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_DonGia_HopLe() == false)
            {
                MessageBox.Show("SĐT không hợp lệ!\n\nMời bạn tham khảo:\nViettel: 09xxx, 03xxx\nMobiFone: 09xxx, 07xxx\nVinaPhone: 09xxx, 08xxx\nVietnamobile và Gmobile: 09xxx, 05xxx\nSĐT cũ 11 chữ số: 01xxx", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_ChatLieu() == false)
            {
                MessageBox.Show("Email nhân viên không quá 254 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_ChatLieu_HopLe() == false)
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }

        }

        private bool KiemTra_BlankEmpty()
        {
            if (txtMSP.Text != "" && txtTenSP.Text != "" && txtDonGia.Text != "" && txtChatLieu.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_MSP()
        {
            if (txtMSP.Text.Length == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_MSP_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_ID);
            Match mat = reg.Match(txtMSP.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_TenSP()
        {
            if (txtTenSP.Text.Length <= 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_TenSP_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_HoTen);
            Match mat = reg.Match(txtTenSP.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_DonGia()
        {
            if (txtDonGia.Text.Length <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_DonGia_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_SDT);
            Match mat = reg.Match(txtDonGia.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool KiemTra_Limited_ChatLieu()
        {
            if (txtChatLieu.Text.Length <= 254)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_ChatLieu_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_Email);
            Match mat = reg.Match(txtChatLieu.Text);
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

        }
    }
}
