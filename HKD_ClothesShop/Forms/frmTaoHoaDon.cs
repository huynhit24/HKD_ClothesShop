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
                    dgvHoaDon.Rows[index].Cells[4].Value = "Ghi nợ";
                    dgvHoaDon.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
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
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<HoaDon> listHoaDon = db.HoaDons.ToList();
                List<NhanVienBanHang> listNhanVien = db.NhanVienBanHangs.ToList();
                List<KhachHang> listKhachHang = db.KhachHangs.ToList();
                BindGrid(listHoaDon);
                FillNhanVienCombobox(listNhanVien);
                FillKhachHangCombobox(listKhachHang);

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
                        var hoadon = db.HoaDons.FirstOrDefault(p => p.SoHoaDon == txtSHD.Text && p.MaNhanVien == cmbMNV.Text && p.MaKhachHang == cmbMKH.Text );
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
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Chi tiết Đặc điểm sản phẩm {txtSHD.Text}, {cmbMKH.Text}, {cmbMNV.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
                    var dacdiem = db.HoaDons.FirstOrDefault(p => p.SoHoaDon == txtSHD.Text && p.MaNhanVien == cmbMNV.Text && p.MaKhachHang == cmbMKH.Text);
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
                            dacdiem.TinhTrang = cmbTinhTrang.Text;
                            dacdiem.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Hóa đơn {cmbMKH.Text}, {cmbMNV.Text} cho {txtSHD.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                db.SaveChanges();
                                frmTaoHoaDon_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Hóa đơn {cmbMKH.Text}, {cmbMNV.Text} cho {txtSHD.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return KiemTra_BlankEmpty();
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

        private bool KiemTra_ID_HopLe()
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
    }
}
