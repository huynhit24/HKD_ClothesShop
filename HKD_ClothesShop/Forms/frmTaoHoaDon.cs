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
        #region khởi tạo
        public frmTaoHoaDon()
        {
            InitializeComponent();
        }

        private void frmTaoHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                tabPageCTHD.Parent = null;
                tabHoaDon.Parent = tabChiTietHoaDon;
                tabPageAllCTHD.Parent = tabChiTietHoaDon;
                tabPageSLSizeColor.Parent = null;
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<HoaDon> listHoaDon = db.HoaDons.ToList();
                List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();
                List<DacDiem_SanPham> listCTDacDiem = db.DacDiem_SanPham.ToList();

                List<NhanVienBanHang> listNhanVien = db.NhanVienBanHangs.Where(P => P.Status == true).ToList();
                List<KhachHang> listKhachHang = db.KhachHangs.Where(P => P.Status == true).ToList();
                List<SanPham> listSanPham = db.SanPhams.Where(P => P.TrangThai == true).ToList();

                BindGrid(listHoaDon);
                FillNhanVienCombobox(listNhanVien);
                FillKhachHangCombobox(listKhachHang);
                //FillMSPCombobox(listSanPham);
                //HideGridCTHD();
                BindGridCTHD(listCTHoaDon);
                BindGridAllCTHD(listCTHoaDon);

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

        #region Lập hóa đơn

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

        #endregion

        #region Hóa đơn
        private void Xoatt()
        {
            txtSHD.Text = "";
            labelSLMua.Text = "0";
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
                        /*int index = dgvHoaDon.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvHoaDon.Rows[index];
                        string temp = row.Cells[1].Value.ToString();*/
                        var hoadon = db.HoaDons.FirstOrDefault(p => p.SoHoaDon == txtSHD.Text /*&& p.MaNhanVien == cmbMNV.Text && p.MaKhachHang == cmbMKH.Text*/);
                        if (hoadon == null) // chưa có đặc diểm có size + color này
                        {
                            
                            var dd = new HoaDon()
                            {
                                SoHoaDon = txtSHD.Text,
                                MaNhanVien = cmbMNV.Text,
                                MaKhachHang = cmbMKH.Text,
                                NgayLap = dtpNgayLap.Value,
                                TinhTrang = (labelTinhTrang.Text.ToString() == "Đã thanh toán") ? "T" : (labelTinhTrang.Text.ToString() == "Chưa thanh toán") ? "C" : "N",
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
                    /*int index = dgvHoaDon.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvHoaDon.Rows[index];
                    string stemp = row.Cells[0].Value.ToString();
                    string temp = row.Cells[1].Value.ToString();*/
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
                            dacdiem.TinhTrang = (labelTinhTrang.Text.ToString() == "Đã thanh toán") ? "T" : (labelTinhTrang.Text.ToString() == "Chưa thanh toán") ? "C" : "N";
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
                    labelTinhTrang.Text = row.Cells[4].Value.ToString();

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

        #endregion

        #endregion

        #region Chi tiết hóa đơn
        private void FillMSPCombobox(List<SanPham> listSanPham)
        {
            this.comboBoxMSP.DataSource = listSanPham;
            this.comboBoxMSP.ValueMember = "MaSanPham";
            this.comboBoxMSP.DisplayMember = "TenSanPham";
        }

        public static string size = "M";
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
                    dgvCTHD.Rows[index].Cells[6].Value = (ulong) item.DonGiaBan; // Đơn giá bán
                    dgvCTHD.Rows[index].Cells[7].Value = (ulong) (item.SoLuongMua * item.DonGiaBan); // Thành tiền
                    dgvCTHD.Rows[index].Cells[8].Value = item.HoaDon.MaNhanVien; // Mã nhân viên
                    dgvCTHD.Rows[index].Cells[9].Value = item.HoaDon.MaKhachHang; // Mã khách hàng
                    dgvCTHD.Rows[index].Cells[10].Value = item.MaSanPham; // Mã sản phẩm
                    dgvCTHD.Rows[index].Cells[11].Value = (ulong) item.SanPham.DonGia; // Đơn giá gốc
                    dgvCTHD.Rows[index].Cells[12].Value = item.SanPham.DonViTinh; // Đợn vị tính
                    dgvCTHD.Rows[index].Cells[13].Value = item.SanPham.ChatLieu; // Chất liệu
                    //dgvCTHD.Rows[index].Cells[14].Value = item.HoaDon.TinhTrang; // Tình trạng
                    dgvCTHD.Rows[index].Cells[15].Value = size.ToString(); // Chất liệu


                    if (item.HoaDon.TinhTrang == "T")
                    {
                        dgvCTHD.Rows[index].Cells[14].Value = "Đã thanh toán";
                        labelThanhToan.Text = "Đã thanh toán";
                    }
                    else
                    {
                        if (item.HoaDon.TinhTrang == "C")
                        {
                            dgvCTHD.Rows[index].Cells[14].Value = "Chưa thanh toán";
                            labelThanhToan.Text = "Chưa thanh toán";
                        }
                        else
                        {
                            dgvCTHD.Rows[index].Cells[14].Value = "Ghi nợ";
                            labelThanhToan.Text = "Ghi nợ";
                        }
                        //dgvHoaDon.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }

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
                if (labelThanhToan.Text == "Đã thanh toán")
                {
                    MessageBox.Show($"👉 Không được phép chỉnh sửa Hóa đơn khi đã thanh toán!", "Cảnh báo ⚠❌💀", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // kiểm tra dữ liệu nhập vào ở các Textbox
                bool isValidated = isValidateDataCTHD();
                if (isValidated)// dữ liệu được xác thực đúng thỏa database
                {
                    using (var db = new QLBanHangHKDEntities())
                    {
                        /*int index = dgvCTHD.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvCTHD.Rows[index];
                        string temp = row.Cells[1].Value.ToString();*/
                        var hoadon = db.ChiTietHoaDons.FirstOrDefault(p => (p.SoHoaDon == txtSHD.Text && p.MaSanPham == comboBoxMSP.SelectedValue.ToString() || (p.SoHoaDon == labelSHD.Text && p.MaSanPham == comboBoxMSP.SelectedValue.ToString())));
                        if (hoadon == null) // chưa có đặc diểm có size + color này
                        {
                            var dd = new ChiTietHoaDon()
                            {
                                SoHoaDon = txtSHD.Text,
                                MaSanPham = comboBoxMSP.SelectedValue.ToString(),
                                SoLuongMua = Convert.ToInt32(labelSLMua.Text),
                                DonGiaBan = Convert.ToDecimal(labelGiaGoc.Text)
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
                            MessageBox.Show($"Mặt hàng này đã có trong hóa đơn rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelThanhToan.Text == "Đã thanh toán")
                {
                    MessageBox.Show($"👉 Không được phép chỉnh sửa Hóa đơn khi đã thanh toán!", "Cảnh báo ⚠❌💀", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var db = new QLBanHangHKDEntities())
                {
                    var dacdiem = db.ChiTietHoaDons.FirstOrDefault(p => (p.SoHoaDon == labelSHD.Text && p.MaSanPham == comboBoxMSP.SelectedValue.ToString()) || (p.SoHoaDon == labelSHD.Text && p.MaSanPham == comboBoxMSP.SelectedValue.ToString()));
                    if (dacdiem != null)
                    {
                        if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm này khỏi hóa đơn mua hàng!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.ChiTietHoaDons.Remove(dacdiem);
                            db.SaveChanges();
                            //frmTaoHoaDon_Load(sender, e);
                            HideGridCTHD();
                            MessageBox.Show($"Xóa mặt hàng này khỏi hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Xoatt();
                        }
                        else
                        {
                            Xoatt();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Thông tin Chi tiết Hóa đơn cần xóa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Xóa TT Chi tiết Hóa đơn (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (labelSLMua.Text != "")
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
            int temp = Convert.ToInt32(labelSLMua.Text);
            if (temp >= 0)
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
            Match mat = reg.Match(labelSLMua.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void comboBoxMSP_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int slmua = 0;


                if (labelSLMua.Text == "")
                {
                    slmua = 0;

                }
                if (labelSLMua.Text != "")
                {
                    Regex reg = new Regex(XacthucRegex.Regex_Number);
                    Match mat = reg.Match(labelSLMua.Text);
                    if (mat.Success)
                    {
                        slmua = Convert.ToInt32(labelSLMua.Text);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng mua phải là số nguyên không âm!", "Cảnh báo ⚠", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
                if (labelSLMua.Text != "")
                {
                    Regex reg = new Regex(XacthucRegex.Regex_Number);
                    Match mat = reg.Match(labelSLMua.Text);

                    if (mat.Success)
                    {
                        slmua = Convert.ToInt32(labelSLMua.Text);

                    }
                    else
                    {
                        MessageBox.Show("Số lượng mua + Khuyến mãi khuyến mãi phải là số nguyên không âm!", "Cảnh báo ⚠", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
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
                        decimal dgb = item.DonGia;
                        decimal thanhtien = dgb * slmua;
                        labelDGB.Text = Convert.ToString((ulong)dgb);
                        labelThanhtien.Text = Convert.ToString((ulong)thanhtien);
                        return;
                    }
                }
            }
            catch (Exception ex)
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
                    labelSLMua.Text = row.Cells[5].Value.ToString();
                    labelGiaGoc.Text = row.Cells[11].Value.ToString();
                    labelDGB.Text = row.Cells[6].Value.ToString();
                    labelThanhtien.Text = row.Cells[7].Value.ToString();
                    msptemp = comboBoxMSP.SelectedValue.ToString();
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
            labelTinhTrang.Visible = false;
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
            labelTinhTrang.Visible = true;
            cbStatus.Visible = true;
            groupBoxTTHD.Text = "Thông tin hóa đơn ✍";

        }

        public ulong tien = 0;
        private void buttonThanhToanKhach_Click(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<HoaDon> listHoaDon = db.HoaDons.ToList();
            List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();
            int demtongsl = 0;
            foreach (var item in listHoaDon)
            {
                if (item.SoHoaDon == labelSHD.Text)
                {
                    ThanhToan.SoHoaDon = item.SoHoaDon;
                    var listHD = listCTHoaDon.Where(p => p.SoHoaDon == item.SoHoaDon).ToList();
                    foreach (var i in listHD)
                    {
                        demtongsl += i.SoLuongMua;
                    }
                    break;
                }
            }
            if (dgvCTHD.Rows.Count == 0)
            {
                MessageBox.Show("Thêm mặt hàng vào hóa đơn để thanh toán!", "Thông báo ⚠⚠⚠", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (demtongsl == 0)
            {
                MessageBox.Show("Số lượng mua ở giỏ phải lớn hơn 0 !", "Thông báo ⚠⚠⚠", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (labelThanhToan.Text == "Đã thanh toán")
            {
                MessageBox.Show("Quý khách đã thanh toán hóa đơn rôì!", "Thông báo ⚠⚠⚠", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //openChildForm(new frmThanhToan());
            
            long tien = 0;
            foreach (var item in listHoaDon)
            {
                if(item.SoHoaDon == labelSHD.Text)
                {
                    ThanhToan.SoHoaDon = item.SoHoaDon;
                    var listHD = listCTHoaDon.Where(p => p.SoHoaDon == item.SoHoaDon).ToList();
                    foreach(var i in listHD)
                    {
                        tien += (long) i.DonGiaBan * i.SoLuongMua;
                    }
                    break;
                }
            }
            ThanhToan.TienThanhToan = tien.ToString();
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
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();
                //List<HoaDon> listHoaDon = db.HoaDons.ToList();
                List<SanPham> listSanPham = db.SanPhams.Where(P => P.TrangThai == true).ToList();
                

                bool trangthai = false;
                DataGridViewRow row = dgvHoaDon.Rows[dgvHoaDon.CurrentCell.RowIndex];
                if (row.Cells[4].Value.ToString().Trim() == "Đã thanh toán")
                {
                    trangthai = true;
                }
                
                if (trangthai == true)
                {
                    MessageBox.Show("Hóa đơn này đã thanh toán không thể thay đổi!", "Good job!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    trangthai = false;
                    return;
                }
                tabPageCTHD.Parent = tabChiTietHoaDon;
                tabHoaDon.Parent = null;
                tabPageAllCTHD.Parent = null;
                HideGridCTHD();
                //BindGridCTHD(listCTHoaDon);
                FillLabelSHD();
                FillMSPCombobox(listSanPham);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            frmTaoHoaDon_Load(sender, e);
        }

        #endregion

        #region Danh sách chi tiết hóa đơn
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

        #endregion

        #region Chi tiết số lượng mua

        
        //hàm xóa thông tin
        private void Clear()
        {
            txtSLSP.Text = "";

            SizeHang.Text = "Kích thước - Size";
            ColorHang.Text = "Màu sắc - Color";
           
        }

        
        // Truyên data lên datagridview
        private void BindGridCT(List<DacDiem_SanPham> listDDSP)
        {
            dgvCTDD.Rows.Clear();
            foreach (var item in listDDSP)
            {
                int index = dgvCTDD.Rows.Add();
                dgvCTDD.Rows[index].Cells[0].Value = item.MaSanPham;
                dgvCTDD.Rows[index].Cells[1].Value = item.SanPham.TenSanPham;
                dgvCTDD.Rows[index].Cells[2].Value = item.Size;
                dgvCTDD.Rows[index].Cells[3].Value = item.Color;
                dgvCTDD.Rows[index].Cells[4].Value = Convert.ToInt32(soluongmua);
                dgvCTDD.Rows[index].Cells[5].Value = item.SoLuong;


                //tính giá bán theo kích cỡ
                if(dgvCTDD.Rows[index].Cells[2].Value.ToString().Trim() == "S")
                    dgvCTDD.Rows[index].Cells[6].Value = (ulong) item.SanPham.DonGia * 0.8;

                if (dgvCTDD.Rows[index].Cells[2].Value.ToString().Trim() == "M")
                    dgvCTDD.Rows[index].Cells[6].Value = (ulong) item.SanPham.DonGia;

                if (dgvCTDD.Rows[index].Cells[2].Value.ToString().Trim() == "L")
                    dgvCTDD.Rows[index].Cells[6].Value = (ulong) item.SanPham.DonGia * 1.2;

                if (dgvCTDD.Rows[index].Cells[2].Value.ToString().Trim() == "XL")
                    dgvCTDD.Rows[index].Cells[6].Value = (ulong) item.SanPham.DonGia * 1.4;

                if (dgvCTDD.Rows[index].Cells[2].Value.ToString().Trim() == "XXL")
                    dgvCTDD.Rows[index].Cells[6].Value = (ulong) item.SanPham.DonGia * 1.8;
                        
                


            }
        }

        public static string msptemp;
        public static string tensptemp;

        private void dgvCTHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                using (var db = new QLBanHangHKDEntities())
                {
                    
                    List<SanPham> listSP = db.SanPhams.ToList();
                    List<DacDiem_SanPham> listDDSP = db.DacDiem_SanPham.ToList();
                    List<DacDiem_SanPham> listDDSPtemp = new List<DacDiem_SanPham>();

                    labelMSP.Text = msptemp;

                    foreach (var item in listDDSP)
                    {
                        if (item.MaSanPham == msptemp)
                        {
                            labelTenSP.Text = item.SanPham.TenSanPham;
                            break;
                        }
                    }
                    
                    foreach (var item in listDDSP)
                    {
                        if (item.MaSanPham == msptemp)
                        {
                            listDDSPtemp.Add(item);
                        }
                    }

                    int sum = 0;
                    DataGridViewRow row = dgvCTHD.Rows[dgvCTHD.CurrentCell.RowIndex];
                    sum = Convert.ToInt32(row.Cells[5].Value.ToString());
                    
                    if (sum != 0)
                    {
                        MessageBox.Show("Mặt hàng này đã xác nhận mua rồi không thể thay đổi!", "Good job!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sum = 0;
                        return;
                    }
                    tabPageCTHD.Parent = null;
                    tabPageSLSizeColor.Parent = tabChiTietHoaDon;
                    BindGridCT(listDDSPtemp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //List<DacDiem_SanPham> listspmua = new List<DacDiem_SanPham>();
        
        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    var dacdiem = db.DacDiem_SanPham.FirstOrDefault(p => p.MaSanPham == labelMSP.Text && p.Size == SizeHang.Text && p.Color == ColorHang.Text);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (dacdiem != null)
                    {
                        if(dacdiem.SoLuong == 0)
                        {
                            MessageBox.Show($"Hết hàng size này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateDataCT();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            
                            
                            //dacdiem.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn KHÁCH muốn mua hàng với số lượng này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                soluongmua = Convert.ToInt32(txtSLSP.Text);
                                dacdiem.SoLuong = dacdiem.SoLuong - Convert.ToInt32(txtSLSP.Text);
                                slcongdon += soluongmua;
                                foreach (DataGridViewRow row in dgvCTDD.Rows)
                                {
                                    bool check = row.Cells[0].Value.ToString() == labelMSP.Text
                                              && row.Cells[2].Value.ToString() == SizeHang.Text
                                              && row.Cells[3].Value.ToString() == ColorHang.Text;
                                    if (check == true)
                                    {
                                        row.Cells[4].Value = soluongmua;
                                    }
                                }
                                var hoadon = db.ChiTietHoaDons.FirstOrDefault(p => (p.SoHoaDon == txtSHD.Text && p.MaSanPham == labelMSP.Text.ToString()));
                                if (hoadon != null) // chưa có đặc diểm có size + color này
                                {
                                    labelSLMua.Text = DemSLMua().ToString();
                                    hoadon.SoLuongMua = slcongdon;
                                    hoadon.DonGiaBan = hoadon.SanPham.DonGia;
                                    ThanhTien = TinhThanhTien();
                                    labelThanhtien.Text = ThanhTien.ToString();
                                    db.SaveChanges();
                                    List<ChiTietHoaDon> list = db.ChiTietHoaDons.ToList();
                                    BindGridCTHD(list);
                                }
                                db.SaveChanges();
                                //BindGridCT(db.DacDiem_SanPham.ToList());
                                MessageBox.Show($"Cập nhật số lượng mặt hàng khách mua thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                                soluongmua = 0;
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            ThongBaoLoiDataInputCT();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Thông tin Đặc điểm cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa TT Đặc điểm (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            }
        }

        private bool isValidateDataCT()
        {
            return KiemTra_BlankEmptyCT();
        }

        private void ThongBaoLoiDataInputCT()
        {
            if (KiemTra_BlankEmptyCT() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Đặc điểm Sản phẩm!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_SLM_CTDD() == false)
            {
                MessageBox.Show("Số lượng hàng khách mua phải từ 1 <= mua < soluongton", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_SLM_HopLe_CTDD() == false)
            {
                MessageBox.Show("Kiểu dữ liệu số lượng mua không hợp lệ", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        private bool KiemTra_BlankEmptyCT()
        {
            if (txtSLSP.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int soluongmua = 0;
        public int soluongton;
        public int slcongdon = 0;
        private bool KiemTra_Limited_SLM_CTDD()
        {
            int temp = Convert.ToInt32(txtSLSP.Text);
            if (temp >= 1 && temp < soluongton)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_SLM_HopLe_CTDD()
        {
            Regex reg = new Regex(XacthucRegex.Regex_Number);
            Match mat = reg.Match(txtSLSP.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dgvCTDD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCTDD.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvCTDD.Rows[dgvCTDD.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();
                    labelMSP.Text = row.Cells[0].Value.ToString();
                    SizeHang.Text = row.Cells[2].Value.ToString();
                    ColorHang.Text = row.Cells[3].Value.ToString();
                    txtSLSP.Text = row.Cells[4].Value.ToString();
                    soluongton = Convert.ToInt32(row.Cells[5].Value.ToString());
                    //cbStatus.Checked = (row.Cells[3].Value.ToString() == "Còn sử dụng") ? false : true;
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

        private void btnAn_Click(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<DacDiem_SanPham> listDacDiem = db.DacDiem_SanPham.ToList();
            if (btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvCTDD.Rows)
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

                foreach (DataGridViewRow item in dgvCTDD.Rows)
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

        private void buttonClearCT_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonThoatCT_Click(object sender, EventArgs e)
        {
            /*try
            {*/
            using (var db = new QLBanHangHKDEntities())
            {
                
                var hoadon = db.ChiTietHoaDons.FirstOrDefault(p => (p.SoHoaDon == txtSHD.Text && p.MaSanPham == labelMSP.Text.ToString()));
                if (hoadon != null) // chưa có đặc diểm có size + color này
                {
                    labelSLMua.Text = DemSLMua().ToString();
                    hoadon.SoLuongMua = slcongdon;
                    hoadon.DonGiaBan = hoadon.SanPham.DonGia;
                    ThanhTien = TinhThanhTien();
                    labelThanhtien.Text = ThanhTien.ToString();
                    db.SaveChanges();
                    List<ChiTietHoaDon> list = db.ChiTietHoaDons.ToList();
                    BindGridCTHD(list);
                }
            }
            //labelSLMua.Text = DemSLMua().ToString();
            //buttonThem_Click(sender, e);
            tabPageSLSizeColor.Parent = null;
            tabPageCTHD.Parent = tabChiTietHoaDon;
            tabHoaDon.Parent = null;
            tabPageAllCTHD.Parent = null;
            /*}
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        
        public static long ThanhTien = 0;

        private int DemSLMua()
        {
            int dem = 0;
            foreach(DataGridViewRow row in dgvCTDD.Rows)
            {
                dem += Convert.ToInt32(row.Cells[4].Value);
            }
            return dem;
        }

        private long TinhThanhTien()
        {
            long sum = 0;
            foreach (DataGridViewRow row in dgvCTDD.Rows)
            {
                int sl = Convert.ToInt32(row.Cells[4].Value.ToString());
                long gia = Convert.ToInt32(row.Cells[4].Value.ToString());

                sum += sl * gia;
            }
            return sum;
        }
        #endregion
    }
}
