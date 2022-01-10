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

        private void FillNhanVienCombobox(List<NhanVienBanHang> listNhanVien)
        {
            this.cmbMNV.DataSource = listNhanVien;
            this.cmbMNV.ValueMember = "MaNhanVien";
            this.cmbMNV.DisplayMember = "MaNhanVien";
        }

        private void FillKhachHangCombobox(List<KhachHang> listKhachHang)
        {
            this.cmbMKH.DataSource = listKhachHang;
            this.cmbMKH.ValueMember = "MaKhachHang";
            this.cmbMKH.DisplayMember = "MaKhachHang";
        }

        private void FillLabelSHD()
        {
            labelSHD.Text = txtSHD.Text;
            
        }

        private void FillMSPCombobox(List<SanPham> listSanPham)
        {
            this.comboBoxMSP.DataSource = listSanPham;
            this.comboBoxMSP.ValueMember = "MaSanPham";
            this.comboBoxMSP.DisplayMember = "TenSanPham";
        }

        private void BindGrid(List<HoaDon> listHoaDon)
        {
            dgvHoaDon.Rows.Clear();
            foreach (var item in listHoaDon)
            {
                int index = dgvHoaDon.Rows.Add();
                
                dgvHoaDon.Rows[index].Cells[0].Value = item.SoHoaDon;
                dgvHoaDon.Rows[index].Cells[1].Value = item.MaNhanVien;
                dgvHoaDon.Rows[index].Cells[2].Value = item.MaKhachHang;
                dgvHoaDon.Rows[index].Cells[3].Value = item.NgayLap;
                if (item.TinhTrang == "T")
                {
                    dgvHoaDon.Rows[index].Cells[4].Value = "Đã thanh toán";
                }
                else
                {
                    if (item.TinhTrang == "C")
                    {
                        dgvHoaDon.Rows[index].Cells[4].Value = "Chưa thanh toán";
                    }
                    else
                    {
                        dgvHoaDon.Rows[index].Cells[4].Value = "Ghi nợ";
                    }
                    //dgvHoaDon.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                if (item.Status == true)
                {
                    dgvHoaDon.Rows[index].Cells[5].Value = "Còn sử dụng";
                }
                else
                {
                    dgvHoaDon.Rows[index].Cells[5].Value = "Không sử dụng";
                    dgvHoaDon.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                dgvHoaDon.Rows[index].Cells[6].Value = item.KhachHang.HoTen;
                dgvHoaDon.Rows[index].Cells[7].Value = item.NhanVienBanHang.HoTen;

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
                tabPageCTHD.Parent = null;
                tabHoaDon.Parent = tabChiTietHoaDon;
                tabPageAllCTHD.Parent = tabChiTietHoaDon;
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<HoaDon> listHoaDon = db.HoaDons.ToList();
                List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();

                List<NhanVienBanHang> listNhanVien = db.NhanVienBanHangs.ToList();
                List<KhachHang> listKhachHang = db.KhachHangs.ToList();
                List<SanPham> listSanPham = db.SanPhams.ToList();

                BindGrid(listHoaDon);
                FillNhanVienCombobox(listNhanVien);
                FillKhachHangCombobox(listKhachHang);
                BindGridAllCTHD(listCTHoaDon);


                /*BindGridCTHD(listCTHoaDon);
                FillSHDCombobox(listHoaDon);
                FillMSPCombobox(listSanPham);*/



                /*foreach (var item in comboBoxMSP.ValueMember)
                {
                    if (item.ToString() == comboBoxMSP.SelectedValue.ToString())
                    {
                        labelGiaGoc.Text = db.ChiTietHoaDons.FirstOrDefault(p => p.SoHoaDon == txtSHD.Text && p.MaSanPham == comboBoxMSP.SelectedValue.ToString()).ToString();
                        labelDGB.Text = labelGiaGoc.Text;
                        break;
                    }
                }*/

                /*foreach (var item in listSanPham)
                {
                    if (item.MaSanPham.ToString() == comboBoxMSP.Text.ToString())
                    {
                        labelGiaGoc.Text = item.DonGia.ToString("0.00");
                        labelDGB.Text = item.DonGia.ToString("0.00");
                        break;
                    }
                }*/
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

        private void Xoatt()
        {
            txtSHD.Text = "";
            txtSLMua.Text = "";
            txtKM.Text = "";
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
                        int index = dgvHoaDon.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvHoaDon.Rows[index];
                        string temp = row.Cells[1].Value.ToString();
                        var hoadon = db.HoaDons.FirstOrDefault(p => p.SoHoaDon == txtSHD.Text /*&& p.MaNhanVien == cmbMNV.Text && p.MaKhachHang == cmbMKH.Text*/);
                        if (hoadon == null) // chưa có đặc diểm có size + color này
                        {
                            var dd = new HoaDon()
                            {
                                SoHoaDon = txtSHD.Text,
                                MaNhanVien = cmbMNV.Text,
                                MaKhachHang = cmbMKH.Text,
                                NgayLap = dtpNgayLap.Value,
                                TinhTrang = (cmbTinhTrang.Text.ToString() == "Đã thanh toán") ? "T" : (cmbTinhTrang.Text.ToString() == "Chưa thanh toán") ? "C" : "N",
                                Status = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm Hóa đơn {dd.MaKhachHang}, {dd.SoHoaDon}, {dd.MaNhanVien} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.HoaDons.Add(dd);
                                db.SaveChanges();
                                frmTaoHoaDon_Load(sender, e);
                                MessageBox.Show($"Thêm mới Hóa đơn {dd.MaKhachHang}, {dd.SoHoaDon}, {dd.MaNhanVien} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show($"Số Hóa đơn {txtSHD.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
                MessageBox.Show(ex.Message, "Lỗi Thêm Hóa đơn (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTaoHoaDon_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    int index = dgvHoaDon.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvHoaDon.Rows[index];
                    string stemp = row.Cells[0].Value.ToString();
                    string temp = row.Cells[1].Value.ToString();
                    var dacdiem = db.HoaDons.FirstOrDefault(p => p.SoHoaDon == txtSHD.Text /*&& p.MaNhanVien == cmbMNV.Text && p.MaKhachHang == cmbMKH.Text*/);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (dacdiem != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateData();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            dacdiem.SoHoaDon = txtSHD.Text;
                            dacdiem.MaNhanVien = cmbMNV.Text;
                            dacdiem.MaKhachHang = cmbMKH.Text;
                            dacdiem.NgayLap = dtpNgayLap.Value;
                            dacdiem.TinhTrang = (cmbTinhTrang.Text.ToString() == "Đã thanh toán") ? "T" : (cmbTinhTrang.Text.ToString() == "Chưa thanh toán") ? "C" : "N";
                            dacdiem.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Hóa đơn {cmbMKH.Text}, {cmbMNV.Text} cho {txtSHD.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                db.SaveChanges();
                                frmTaoHoaDon_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Hóa đơn {cmbMKH.Text}, {cmbMNV.Text} cho {txtSHD.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Không tìm thấy Thông tin Hóa đơn cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa TT Hóa đơn (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTaoHoaDon_Load(sender, e);
            }
        }

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true && KiemTra_Limited_SHD() == true && KiemTra_SHD_HopLe() == true;
        }

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Hóa đơn!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        private bool KiemTra_BlankEmpty()
        {
            if (txtSHD.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool KiemTra_Limited_SHD()
        {
            if (txtSHD.Text.Length == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_SHD_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_ID);
            Match mat = reg.Match(txtSHD.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnHidden_Click(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<HoaDon> listDacDiem = db.HoaDons.ToList();
            if (btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
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

                foreach (DataGridViewRow item in dgvHoaDon.Rows)
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

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHoaDon.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvHoaDon.Rows[dgvHoaDon.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();

                    txtSHD.Text = row.Cells[0].Value.ToString();
                    cmbMNV.Text = row.Cells[1].Value.ToString();
                    cmbMKH.Text = row.Cells[2].Value.ToString();
                    QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                    foreach (var i in db.HoaDons)
                    {
                        if (row.Cells[3].Value.ToString() == i.NgayLap.ToString("dd/MM/yyyy"))
                        {
                            dtpNgayLap.Value = i.NgayLap;
                        }
                    }
                    cmbTinhTrang.Text = row.Cells[4].Value.ToString();

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

        //-----------------------------------------Chi tiết hóa đơn------------------------------------------------------

        private void BindGridCTHD(List<ChiTietHoaDon> listCTHoaDon)
        {
            try
            {
                dgvCTHD.Rows.Clear();
                foreach (var item in listCTHoaDon)
                {
                    int index = dgvCTHD.Rows.Add();
                    dgvCTHD.Rows[index].Cells[0].Value = item.SanPham.AnhBiaSP; //Ảnh sản phẩm mua
                    dgvCTHD.Rows[index].Cells[1].Value = item.SoHoaDon; // Số hóa đơn
                    dgvCTHD.Rows[index].Cells[2].Value = item.HoaDon.NhanVienBanHang.HoTen; // Tên nhân viên
                    dgvCTHD.Rows[index].Cells[3].Value = item.HoaDon.KhachHang.HoTen; // Tên khách hàng
                    dgvCTHD.Rows[index].Cells[4].Value = item.SanPham.TenSanPham; // Tên sản phẩm
                    dgvCTHD.Rows[index].Cells[5].Value = item.SoLuongMua; // Số lượng mua
                    dgvCTHD.Rows[index].Cells[6].Value = item.DonGiaBan; // Đơn giá bán
                    dgvCTHD.Rows[index].Cells[7].Value = item.SoLuongMua * item.DonGiaBan; // Thành tiền
                    dgvCTHD.Rows[index].Cells[8].Value = item.HoaDon.MaNhanVien; // Mã nhân viên
                    dgvCTHD.Rows[index].Cells[9].Value = item.HoaDon.MaKhachHang; // Mã khách hàng
                    dgvCTHD.Rows[index].Cells[10].Value = item.MaSanPham; // Mã sản phẩm
                    dgvCTHD.Rows[index].Cells[11].Value = item.SanPham.DonGia; // Đơn giá gốc
                    dgvCTHD.Rows[index].Cells[12].Value = item.SanPham.DonViTinh; // Đợn vị tính
                    dgvCTHD.Rows[index].Cells[13].Value = item.SanPham.ChatLieu; // Chất liệu
                    //dgvCTHD.Rows[index].Cells[14].Value = item.HoaDon.TinhTrang; // Tình trạng

                    if (item.HoaDon.TinhTrang == "T")
                    {
                        dgvCTHD.Rows[index].Cells[14].Value = "Đã thanh toán";
                    }
                    else
                    {
                        if (item.HoaDon.TinhTrang == "C")
                        {
                            dgvCTHD.Rows[index].Cells[14].Value = "Chưa thanh toán";
                        }
                        else
                        {
                            dgvCTHD.Rows[index].Cells[14].Value = "Ghi nợ";
                        }
                        //dgvHoaDon.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    /*if (item.Status == true)
                    {
                        dgvCTHD.Rows[index].Cells[5].Value = "Còn sử dụng";
                    }
                    else
                    {
                        dgvCTHD.Rows[index].Cells[5].Value = "Không sử dụng";
                        dgvCTHD.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    dgvCTHD.Rows[index].Cells[6].Value = item.KhachHang.HoTen;
                    dgvCTHD.Rows[index].Cells[7].Value = item.NhanVienBanHang.HoTen;*/

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void HideGridCTHD()
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    var search = (from ct in db.ChiTietHoaDons
                                  where ct.SoHoaDon.ToString().ToLower().Contains(txtSHD.Text.ToString().ToLower())
                                  select ct).ToList();
                    BindGridCTHD(search);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra dữ liệu nhập vào ở các Textbox
                bool isValidated = isValidateDataCTHD();
                if (isValidated)// dữ liệu được xác thực đúng thỏa database
                {
                    using (var db = new QLBanHangHKDEntities())
                    {
                        /*int index = dgvCTHD.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvCTHD.Rows[index];
                        string temp = row.Cells[1].Value.ToString();*/
                        var hoadon = db.ChiTietHoaDons.FirstOrDefault(p => (p.SoHoaDon == txtSHD.Text || p.SoHoaDon == labelSHD.Text) && p.MaSanPham == comboBoxMSP.SelectedValue.ToString());;
                        if (hoadon == null) // chưa có đặc diểm có size + color này
                        {
                            var dd = new ChiTietHoaDon()
                            {
                                SoHoaDon = labelSHD.Text,
                                MaSanPham = comboBoxMSP.SelectedValue.ToString(),
                                SoLuongMua = Convert.ToInt32(txtSLMua.Text),
                                DonGiaBan = Convert.ToDecimal(labelDGB.Text)
                                /*TinhTrang = (cmbTinhTrang.Text.ToString() == "Đã thanh toán") ? "T" : (cmbTinhTrang.Text.ToString() == "Chưa thanh toán") ? "C" : "N",
                                Status = (cbStatus.Checked == true) ? false : true*/
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm Chi tiết Hóa đơn {dd.SoHoaDon}, {dd.MaSanPham} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.ChiTietHoaDons.Add(dd);
                                db.SaveChanges();
                                frmTaoHoaDon_Load(sender, e);
                                MessageBox.Show($"Thêm mới Chi tiết Hóa đơn {dd.SoHoaDon}, {dd.MaSanPham} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Số Hóa đơn {txtSHD.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    ThongBaoLoiDataInputCTHD();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Thêm Chi tiết Hóa đơn (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTaoHoaDon_Load(sender, e);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    //List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();
                    /*int index = dgvHoaDon.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvCTHD.Rows[index];
                    string stemp = row.Cells[0].Value.ToString();
                    string temp = row.Cells[1].Value.ToString();*/
                    var dacdiem = db.ChiTietHoaDons.FirstOrDefault(p => (p.SoHoaDon == labelSHD.Text && p.MaSanPham == comboBoxMSP.SelectedValue.ToString()) || (p.SoHoaDon == labelSHD.Text && p.MaSanPham == comboBoxMSP.SelectedValue.ToString()));
                    if (dacdiem != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateDataCTHDUpdate();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //dacdiem.SoHoaDon = comboBoxSHD.Text;
                            //dacdiem.MaSanPham = comboBoxMSP.Text;
                            dacdiem.SoLuongMua = Convert.ToInt32(txtSLMua.Text);
                            
                            dacdiem.DonGiaBan = Convert.ToDecimal(labelDGB.Text);
                            /* dacdiem.TinhTrang = (cmbTinhTrang.Text.ToString() == "Đã thanh toán") ? "T" : (cmbTinhTrang.Text.ToString() == "Chưa thanh toán") ? "C" : "N";
                             dacdiem.Status = (cbStatus.Checked == true) ? false : true;*/
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Hóa đơn {dacdiem.SoHoaDon}, {dacdiem.MaSanPham} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                db.SaveChanges();
                                //frmTaoHoaDon_Load(sender, e);
                                HideGridCTHD();
                                MessageBox.Show($"Cập nhật thông tin Chi tiết Hóa đơn {dacdiem.SoHoaDon}, {dacdiem.MaSanPham} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            ThongBaoLoiDataInputCTHD();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Thông tin Chi tiết Hóa đơn cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa TT Chi tiết Hóa đơn (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTaoHoaDon_Load(sender, e);
            }
        }

        private bool isValidateDataCTHD()
        {
            return KiemTra_BlankEmpty_CTHD() == true && KiemTra_Limited_SLM_CTHD() == true && KiemTra_SLM_HopLe_CTHD() == true;
        }

        private bool isValidateDataCTHDUpdate()
        {
            return KiemTra_BlankEmpty_CTHD() == true;
        }

        private void ThongBaoLoiDataInputCTHD()
        {
            if (KiemTra_BlankEmpty_CTHD() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Chi tiết Hóa đơn!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        private bool KiemTra_BlankEmpty_CTHD()
        {
            if (txtSLMua.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool KiemTra_Limited_SLM_CTHD()
        {
            int temp = Convert.ToInt32(txtSLMua.Text);
            double per = Convert.ToDouble(txtKM.Text);
            if (temp >= 1 && per >= 0 && per <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_SLM_HopLe_CTHD()
        {
            Regex reg = new Regex(XacthucRegex.Regex_Number);
            Match mat = reg.Match(txtSLMua.Text);
            Match matKM = reg.Match(txtKM.Text);
            if (mat.Success && matKM.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void comboBoxMSP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<SanPham> listSanPham = db.SanPhams.ToList();
                foreach (var item in listSanPham)
                {
                    if (item.MaSanPham.ToString() == comboBoxMSP.SelectedValue.ToString())
                    {
                        labelGiaGoc.Text = item.DonGia.ToString("0.00");
                        labelDGB.Text = item.DonGia.ToString("0.00");
                        labelThanhtien.Text = "0.00";
                        txtSLMua.Text = "0";
                        txtKM.Text = "0";
                        try
                        {
                            int slmua = 0;
                            int km = 0;
                            /*
                            Regex reg = new Regex(XacthucRegex.Regex_Number);
                            Match mat = reg.Match(txtSLMua.Text);
                            Match matKM = reg.Match(txtKM.Text);
                            if (mat.Success && matKM.Success)
                            {
                                slmua = Convert.ToInt32(txtSLMua.Text);
                                km = Convert.ToInt32(txtKM.Text);
                            }
                            else
                            {
                                MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!","Cảnh báo ⚠",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                            }
                            */

                            if (txtSLMua.Text == "" && txtKM.Text != "")
                            {
                                slmua = 0;
                                Regex reg = new Regex(XacthucRegex.Regex_Number);
                                Match matKM = reg.Match(txtKM.Text);
                                if (matKM.Success)
                                {
                                    km = Convert.ToInt32(txtKM.Text);
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!", "Cảnh báo ⚠", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                }
                            }
                            if (txtKM.Text == "" && txtSLMua.Text != "")
                            {
                                Regex reg = new Regex(XacthucRegex.Regex_Number);
                                Match mat = reg.Match(txtSLMua.Text);
                                if (mat.Success)
                                {
                                    slmua = Convert.ToInt32(txtSLMua.Text);
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!", "Cảnh báo ⚠", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                }
                                km = 0;
                            }
                            if (txtKM.Text != "" && txtSLMua.Text != "")
                            {
                                Regex reg = new Regex(XacthucRegex.Regex_Number);
                                Match mat = reg.Match(txtSLMua.Text);
                                Match matKM = reg.Match(txtKM.Text);
                                if (mat.Success && matKM.Success)
                                {
                                    slmua = Convert.ToInt32(txtSLMua.Text);
                                    km = Convert.ToInt32(txtKM.Text);
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!", "Cảnh báo ⚠", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                }
                            }
                            if (txtKM.Text == "" && txtSLMua.Text == "")
                            {
                                slmua = 0;
                                km = 0;
                            }
                            if (km < 0 || km > 100 || slmua < 0)
                            {
                                MessageBox.Show("👉 0% <= Khuyến mãi <= 100%\n\n👉 Số lượng mua >= 0", "Cảnh cáo ❌❌❌!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                //QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                                //List<SanPham> listSanPham = db.SanPhams.ToList();
                                foreach (var i in listSanPham)
                                {
                                    if (i.MaSanPham.ToString() == comboBoxMSP.Text.ToString())
                                    {
                                        if (km == 0)
                                        {
                                            labelDGB.Text = Convert.ToString(i.DonGia);
                                            labelThanhtien.Text = Convert.ToString(i.DonGia * slmua);
                                        }
                                        else
                                        {
                                            decimal dgb = i.DonGia - (km * i.DonGia / 100);
                                            decimal thanhtien = dgb * slmua;
                                            labelDGB.Text = Convert.ToString(dgb);
                                            labelThanhtien.Text = Convert.ToString(thanhtien);
                                        }
                                        return;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Xảy ra lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void txtSLMua_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int slmua = 0;
                int km = 0;
                /*
                Regex reg = new Regex(XacthucRegex.Regex_Number);
                Match mat = reg.Match(txtSLMua.Text);
                Match matKM = reg.Match(txtKM.Text);
                if (mat.Success && matKM.Success)
                {
                    slmua = Convert.ToInt32(txtSLMua.Text);
                    km = Convert.ToInt32(txtKM.Text);
                }
                else
                {
                    MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!","Cảnh báo ⚠",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                }
                */
                
                if(txtSLMua.Text == "" && txtKM.Text != "")
                {
                    slmua = 0;
                    Regex reg = new Regex(XacthucRegex.Regex_Number);
                    Match matKM = reg.Match(txtKM.Text);
                    if (matKM.Success)
                    {
                        km = Convert.ToInt32(txtKM.Text);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!", "Cảnh báo ⚠", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
                if (txtKM.Text == "" && txtSLMua.Text != "")
                {
                    Regex reg = new Regex(XacthucRegex.Regex_Number);
                    Match mat = reg.Match(txtSLMua.Text);
                    if (mat.Success)
                    {
                        slmua = Convert.ToInt32(txtSLMua.Text);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!", "Cảnh báo ⚠", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                    km = 0;
                }
                if (txtKM.Text != "" && txtSLMua.Text != "")
                {
                    Regex reg = new Regex(XacthucRegex.Regex_Number);
                    Match mat = reg.Match(txtSLMua.Text);
                    Match matKM = reg.Match(txtKM.Text);
                    if (mat.Success && matKM.Success)
                    {
                        slmua = Convert.ToInt32(txtSLMua.Text);
                        km = Convert.ToInt32(txtKM.Text);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!", "Cảnh báo ⚠", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
                if (txtKM.Text == "" && txtSLMua.Text == "")
                {
                    slmua = 0;
                    km = 0;
                }
                if (km < 0 || km > 100 || slmua < 0)
                {
                    MessageBox.Show("👉 0% <= Khuyến mãi <= 100%\n\n👉 Số lượng mua >= 0", "Cảnh cáo ❌❌❌!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                    List<SanPham> listSanPham = db.SanPhams.ToList();
                    foreach (var item in listSanPham)
                    {
                        string temp;
                        if (comboBoxMSP.SelectedValue == null)
                        {
                            temp = "";
                        }
                        else
                        {
                            temp = comboBoxMSP.SelectedValue.ToString();
                        }
                        if (item.MaSanPham.ToString() == temp.ToString())
                        {
                            if (km == 0)
                            {
                                labelDGB.Text = Convert.ToString(item.DonGia);
                                labelThanhtien.Text = Convert.ToString(item.DonGia * slmua);
                            }
                            else
                            {
                                decimal dgb = item.DonGia - (km * item.DonGia / 100);
                                decimal thanhtien = dgb * slmua;
                                labelDGB.Text = Convert.ToString(dgb);
                                labelThanhtien.Text = Convert.ToString(thanhtien);
                            }
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHoaDon.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvCTHD.Rows[dgvCTHD.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();
                    Image logo = (Bitmap)((new ImageConverter()).ConvertFrom(row.Cells[0].Value));
                    picAnhSP.Image = logo;
                    labelSHD.Text = row.Cells[1].Value.ToString();
                    comboBoxMSP.Text = row.Cells[4].Value.ToString();
                    txtSLMua.Text = row.Cells[5].Value.ToString();
                    labelGiaGoc.Text = row.Cells[11].Value.ToString();
                    labelDGB.Text = row.Cells[6].Value.ToString();
                    labelThanhtien.Text = row.Cells[7].Value.ToString();
                    labelThanhToan.Text = row.Cells[14].Value.ToString();

                    
                    txtKM.Text = "";
                    /*cmbMKH.Text = row.Cells[2].Value.ToString();
                    QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                    foreach (var i in db.HoaDons)
                    {
                        if (row.Cells[3].Value.ToString() == i.NgayLap.ToString("dd/MM/yyyy"))
                        {
                            dtpNgayLap.Value = i.NgayLap;
                        }
                    }
                    cmbTinhTrang.Text = row.Cells[4].Value.ToString();

                    cbStatus.Checked = (row.Cells[5].Value.ToString() == "Còn sử dụng") ? false : true;*/
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

        private void buttonAn_Click(object sender, EventArgs e)
        {
            if (buttonAn.Text == "Ẩn")
            {

                buttonAn.Text = "Hiện";
                buttonAn.BackColor = Color.Blue;
                buttonAn.ForeColor = Color.Yellow;
                groupBoxCTHD.Visible = false;
                dgvCTHD.Dock = DockStyle.Fill;
            }
            else
            {
                buttonAn.Text = "Ẩn";
                buttonAn.BackColor = Color.GreenYellow;
                buttonAn.ForeColor = Color.Red;
                groupBoxCTHD.Visible = true;
                dgvCTHD.Dock = DockStyle.None;
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

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            ///this.Close();
            tabPageCTHD.Parent = null;
            tabHoaDon.Parent = tabChiTietHoaDon;
            tabPageAllCTHD.Parent = tabChiTietHoaDon;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Xoatt();
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
            lbSHD.Visible = false;
            lbMNV.Visible = false;
            lbMKH.Visible = false;
            lbNgayLHD.Visible = false;
            lbTinhtrang.Visible = false;
            txtSHD.Visible = false;
            cmbMNV.Visible = false;
            cmbMKH.Visible = false;
            dtpNgayLap.Visible = false;
            cmbTinhTrang.Visible = false;
            cbStatus.Visible = false;
            groupBoxTTHD.Text = "";
        }

        private void Mo()
        {
            lbSHD.Visible = true;
            lbMNV.Visible = true;
            lbMKH.Visible = true;
            lbNgayLHD.Visible = true;
            lbTinhtrang.Visible = true;
            txtSHD.Visible = true;
            cmbMNV.Visible = true;
            cmbMKH.Visible = true;
            dtpNgayLap.Visible = true;
            cmbTinhTrang.Visible = true;
            cbStatus.Visible = true;
            groupBoxTTHD.Text = "Thông tin hóa đơn ✍";

        }

        private void buttonThanhToanKhach_Click(object sender, EventArgs e)
        {
            //openChildForm(new frmThanhToan());
            new frmThanhToan().ShowDialog();
        }
        //---------------------------------------Hóa đơn---------------------------------------

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BindGridAllCTHD(List<ChiTietHoaDon> listCTHoaDon)
        {
            try
            {
                dgvAllCTHD.Rows.Clear();
                foreach (var item in listCTHoaDon)
                {
                    int index = dgvAllCTHD.Rows.Add();
                    dgvAllCTHD.Rows[index].Cells[0].Value = item.SanPham.AnhBiaSP; //Ảnh sản phẩm mua
                    dgvAllCTHD.Rows[index].Cells[1].Value = item.SoHoaDon; // Số hóa đơn
                    dgvAllCTHD.Rows[index].Cells[2].Value = item.HoaDon.NhanVienBanHang.HoTen; // Tên nhân viên
                    dgvAllCTHD.Rows[index].Cells[3].Value = item.HoaDon.KhachHang.HoTen; // Tên khách hàng
                    dgvAllCTHD.Rows[index].Cells[4].Value = item.SanPham.TenSanPham; // Tên sản phẩm
                    dgvAllCTHD.Rows[index].Cells[5].Value = item.SoLuongMua; // Số lượng mua
                    dgvAllCTHD.Rows[index].Cells[6].Value = item.DonGiaBan; // Đơn giá bán
                    dgvAllCTHD.Rows[index].Cells[7].Value = item.SoLuongMua * item.DonGiaBan; // Thành tiền
                    dgvAllCTHD.Rows[index].Cells[8].Value = item.HoaDon.MaNhanVien; // Mã nhân viên
                    dgvAllCTHD.Rows[index].Cells[9].Value = item.HoaDon.MaKhachHang; // Mã khách hàng
                    dgvAllCTHD.Rows[index].Cells[10].Value = item.MaSanPham; // Mã sản phẩm
                    dgvAllCTHD.Rows[index].Cells[11].Value = item.SanPham.DonGia; // Đơn giá gốc
                    dgvAllCTHD.Rows[index].Cells[12].Value = item.SanPham.DonViTinh; // Đợn vị tính
                    dgvAllCTHD.Rows[index].Cells[13].Value = item.SanPham.ChatLieu; // Chất liệu
                    //dgvCTHD.Rows[index].Cells[14].Value = item.HoaDon.TinhTrang; // Tình trạng

                    if (item.HoaDon.TinhTrang == "T")
                    {
                        dgvAllCTHD.Rows[index].Cells[14].Value = "Đã thanh toán";
                    }
                    else
                    {
                        if (item.HoaDon.TinhTrang == "C")
                        {
                            dgvAllCTHD.Rows[index].Cells[14].Value = "Chưa thanh toán";
                        }
                        else
                        {
                            dgvAllCTHD.Rows[index].Cells[14].Value = "Ghi nợ";
                        }
                        //dgvHoaDon.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    /*if (item.Status == true)
                    {
                        dgvCTHD.Rows[index].Cells[5].Value = "Còn sử dụng";
                    }
                    else
                    {
                        dgvCTHD.Rows[index].Cells[5].Value = "Không sử dụng";
                        dgvCTHD.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    dgvCTHD.Rows[index].Cells[6].Value = item.KhachHang.HoTen;
                    dgvCTHD.Rows[index].Cells[7].Value = item.NhanVienBanHang.HoTen;*/

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvHoaDon_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();
            //List<HoaDon> listHoaDon = db.HoaDons.ToList();
            List<SanPham> listSanPham = db.SanPhams.ToList();
            tabPageCTHD.Parent = tabChiTietHoaDon;
            tabHoaDon.Parent = null;
            tabPageAllCTHD.Parent = null;
            HideGridCTHD();
            //BindGridCTHD(listCTHoaDon);
            FillLabelSHD();
            FillMSPCombobox(listSanPham);


        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();
            /*List<HoaDon> listHoaDon = db.HoaDons.ToList();
            List<SanPham> listSanPham = db.SanPhams.ToList();*/
            /*tabPageCTHD.Parent = tabChiTietHoaDon;
            tabHoaDon.Parent = null;
            tabPageAllCTHD.Parent = null;*/
            SearchGridCTHD(listCTHoaDon);
            //BindGridCTHD(listCTHoaDon);
            /*FillSHDCombobox(listHoaDon);
            FillMSPCombobox(listSanPham);*/
        }

        private void SearchGridCTHD(List<ChiTietHoaDon> listCTHoaDon)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    if (textBoxSearch.Text != "")
                    {
                        var search = (from ct in db.ChiTietHoaDons
                                      where ct.SoHoaDon.ToString().ToLower().Contains(textBoxSearch.Text.ToString().ToLower())
                                      select ct).ToList();
                        BindGridCTHD(search);
                    }
                    else
                    {
                        BindGridCTHD(listCTHoaDon);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
