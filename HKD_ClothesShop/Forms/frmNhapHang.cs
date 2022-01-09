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

        private void FillLoaiCombobox(List<LoaiSanPham> listLoai)
        {
            this.cmbLSP.DataSource = listLoai;
            this.cmbLSP.DisplayMember = "TenLoaiSP";
            this.cmbLSP.ValueMember = "MaLoaiSP";
        }

        private void FillThuongHieuCombobox(List<ThuongHieu> listThuongHieu)
        {
            this.cmbMTH.DataSource = listThuongHieu;
            this.cmbMTH.DisplayMember = "TenThuongHieu";
            this.cmbMTH.ValueMember = "MaThuongHieu";
        }

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
                    dgvSanPham.Rows[index].Cells[10].Value = "Còn sử dụng";
                }
                else
                {
                    dgvSanPham.Rows[index].Cells[10].Value = "Không sử dụng";
                    dgvSanPham.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                dgvSanPham.Rows[index].Cells[11].Value = item.LoaiSanPham.TenLoaiSP;
                dgvSanPham.Rows[index].Cells[12].Value = item.ThuongHieu.TenThuongHieu;

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
                List<LoaiSanPham> listLoaiSP = db.LoaiSanPhams.ToList();
                List<ThuongHieu> listThuongHieu = db.ThuongHieux.ToList();
                FillLoaiCombobox(listLoaiSP);
                FillThuongHieuCombobox(listThuongHieu);
                BindGrid(listSanPham);
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
            /*try
            {*/
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

                            Image pictemp = picAnhSP.Image;
                            var hinhanh = (byte[])new ImageConverter().ConvertTo(pictemp, typeof(byte[]));
                            var sp = new SanPham()
                            {
                                MaSanPham = txtMSP.Text,
                                MaLoaiSP = cmbLSP.Text.ToString(),
                                MaThuongHieu = cmbMTH.Text.ToString(),
                                TenSanPham = txtTenSP.Text,
                                DonGia = Convert.ToDecimal(txtDonGia.Text),
                                DonViTinh = cmbDVT.Text,
                                NgayCapNhat = dtpDayUpdate.Value,
                                ChatLieu = txtChatLieu.Text,
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
                            MessageBox.Show($"Mã sản phẩm {txtMSP.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    ThongBaoLoiDataInput();
                }

            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Thêm Sản phẩm (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmNhapHang_Load(sender, e);
            }*/
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
                        bool isValidated = isValidateDataUpdate();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //sanpham.MaSanPham = txtMSP.Text;
                            sanpham.TenSanPham = txtTenSP.Text;
                            sanpham.MaLoaiSP = cmbLSP.SelectedValue.ToString();
                            sanpham.MaThuongHieu = cmbMTH.SelectedValue.ToString();
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
                                Xoatt();
                                btnCreate.Enabled = true;
                                btnUpdate.Enabled = true;
                                btnUpdate.FlatAppearance.BorderColor = Color.Crimson;
                                btnCreate.FlatAppearance.BorderColor = Color.Blue;
                            }
                            else
                            {
                                Xoatt();
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

        private bool isValidateDataUpdate()
        {
            return KiemTra_BlankEmpty() == true
                   //&& KiemTra_Limited_MSP() == true && KiemTra_MSP_HopLe() == true
                   && KiemTra_Limited_TenSP() == true && KiemTra_TenSP_HopLe() == true
                   && KiemTra_Limited_DonGia() == true
                   && KiemTra_DonGia_HopLe() == true && KiemTra_Limited_ChatLieu() == true
                   && KiemTra_ChatLieu_HopLe() == true;
        }

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Sản phẩm!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_MSP() == false)
            {
                MessageBox.Show("Mã sản phẩm phải đủ 6 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_MSP_HopLe() == false)
            {
                MessageBox.Show("Mã không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_TenSP() == false)
            {
                MessageBox.Show("Tên sản phẩm không quá 25 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_TenSP_HopLe() == false)
            {
                MessageBox.Show("Tên sản phẩm không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_DonGia() == false)
            {
                MessageBox.Show("Đơn giá không quá 15 số - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_DonGia_HopLe() == false)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_ChatLieu() == false)
            {
                MessageBox.Show("Chất liệu không quá 15 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_ChatLieu_HopLe() == false)
            {
                MessageBox.Show("Chất liệu không hợp lệ!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
            if (txtTenSP.Text.Length <= 25)
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
            Regex reg = new Regex(XacthucRegex.Regex_Decimal);
            Regex regNum = new Regex(XacthucRegex.Regex_Number);
            Match mat = reg.Match(txtDonGia.Text);
            Match matNum = regNum.Match(txtDonGia.Text);
            if (mat.Success || matNum.Success)
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
            if (txtChatLieu.Text.Length <= 15)
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
            Regex reg = new Regex(XacthucRegex.Regex_HoTen);
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
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<SanPham> listSanPham = db.SanPhams.ToList();
            if (btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvSanPham.Rows)
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

                foreach (DataGridViewRow item in dgvSanPham.Rows)
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

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSanPham.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvSanPham.Rows[dgvSanPham.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();
                    Image logo = (Bitmap)((new ImageConverter()).ConvertFrom(row.Cells[0].Value));
                    picAnhSP.Image = logo;
                    txtMSP.Text = row.Cells[1].Value.ToString();
                    txtTenSP.Text = row.Cells[2].Value.ToString();
                    cmbDVT.SelectedItem = row.Cells[3].Value.ToString();
                    txtDonGia.Text = row.Cells[4].Value.ToString();
                    txtChatLieu.Text = row.Cells[5].Value.ToString();
                    /*cmbLSP.SelectedItem = row.Cells[6].Value.ToString();
                    foreach (var i in context.SanPhams)
                    {
                        if (row.Cells[11].Value.ToString() == cmbLSP.SelectedItem.ToString())
                        {
                            lbLSP.Text = cmbLSP.SelectedItem.ToString();
                            break;
                        }
                    }*/
                    cmbLSP.Text = row.Cells[11].Value.ToString();
                    cmbMTH.Text = row.Cells[12].Value.ToString();
                    //lbLSP.Text = cmbLSP.Text.ToString();
                    /*cmbMTH.SelectedItem = row.Cells[7].Value.ToString();
                    //lbMTH.Text = cmbMTH.Se.ToString();
                    foreach (var i in context.SanPhams)
                    {
                        if (row.Cells[12].Value.ToString() == cmbMTH.SelectedItem.ToString())
                        {
                            lbMTH.Text = cmbMTH.SelectedItem.ToString();
                            break;
                        }
                    }*/
                    QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                    foreach (var i in db.SanPhams)
                    {
                        if (row.Cells[8].Value.ToString() == i.NgayCapNhat.ToString("dd/MM/yyyy"))
                        {
                            dtpDayUpdate.Value = i.NgayCapNhat;
                        }
                    }
                    txtMoTa.Text = row.Cells[9].Value.ToString();
                    cbStatus.Checked = (row.Cells[10].Value.ToString() == "Còn sử dụng") ? false : true;
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

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picAnhSP.ImageLocation = openFile.FileName;
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
            labelMSP.Visible = false;
            labelTSP.Visible = false;
            labelDVT.Visible = false;
            labelDongia.Visible = false;
            labelChatlieu.Visible = false;
            labelMaLoaiSP.Visible = false;
            labelMaTH.Visible = false;
            labelNgayupdate.Visible = false;
            labelMotaSP.Visible = false;
            txtMSP.Visible = false;
            txtTenSP.Visible = false;
            cmbDVT.Visible = false;
            txtDonGia.Visible = false;
            txtChatLieu.Visible = false;
            cmbLSP.Visible = false;
            cmbMTH.Visible = false;
            dtpDayUpdate.Visible = false;
            txtMoTa.Visible = false;
            picAnhSP.Visible = false;
            btnChonAnh.Visible = false;
            cbStatus.Visible = false;
            groupBoxSP.Text = "";
        }

        private void Mo()
        {
            labelMSP.Visible = true;
            labelTSP.Visible = true;
            labelDVT.Visible = true;
            labelDongia.Visible = true;
            labelChatlieu.Visible = true;
            labelMaLoaiSP.Visible = true;
            labelMaTH.Visible = true;
            labelNgayupdate.Visible = true;
            labelMotaSP.Visible = true;
            txtMSP.Visible = true;
            txtTenSP.Visible = true;
            cmbDVT.Visible = true;
            txtDonGia.Visible = true;
            txtChatLieu.Visible = true;
            cmbLSP.Visible = true;
            cmbMTH.Visible = true;
            dtpDayUpdate.Visible = true;
            txtMoTa.Visible = true;
            picAnhSP.Visible = true;
            btnChonAnh.Visible = true;
            cbStatus.Visible = true;
            groupBoxSP.Text = "Nhập thông tin sản phẩm";
        }
    }
}
