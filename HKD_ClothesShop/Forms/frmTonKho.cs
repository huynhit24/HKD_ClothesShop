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
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        #region Binding dữ liệu lên các control + datagridview
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            try
            {
                tabCTSP.Parent = tabControlDacDiemChung;
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<DacDiem> listDacDiem = db.DacDiems.ToList();
                List<SanPham> listSanPham = db.SanPhams.ToList();
                List<DacDiem_SanPham> listDDSP = db.DacDiem_SanPham.Where(P => P.SanPham.TrangThai == true).ToList();

   
                BindGridCT(listDDSP);
                FillSanPhamCombobox(listSanPham);
                /*FillSizeCombobox(listDacDiem);
                FillColorCombobox(listDacDiem);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        //-------------------------------------Chi tiết đặc điểm-------------------------------------------

        //hàm xóa thông tin
        private void Xoatt()
        {
            txtSLSP.Text = "";

            cmbSize.Text = "Chọn size";
            cmbColor.Text = "Chọn màu";
        }

        private void FillSanPhamCombobox(List<SanPham> listSanPham)
        {
            this.cmbMaSP.DataSource = listSanPham;
            this.cmbMaSP.ValueMember = "MaSanPham";
            this.cmbMaSP.DisplayMember = "TenSanPham";
        }

        /*private void FillSizeCombobox(List<DacDiem> listDacDiem)
        {
            this.cmbSize.DataSource = listDacDiem;
            this.cmbSize.ValueMember = "Size";
            this.cmbSize.DisplayMember = "Size";

        }*/

        /*private void FillColorCombobox(List<DacDiem> listDacDiem)
        {
            this.cmbColor.DataSource = listDacDiem;
            this.cmbColor.ValueMember = "Color";
            this.cmbColor.DisplayMember = "Color";
        }*/

        private void BindGridCT(List<DacDiem_SanPham> listDDSP)
        {
            dgvCTDD.Rows.Clear();
            foreach (var item in listDDSP)
            {
                int index = dgvCTDD.Rows.Add();
                dgvCTDD.Rows[index].Cells[0].Value = item.MaSanPham;
                dgvCTDD.Rows[index].Cells[1].Value = item.Size;
                dgvCTDD.Rows[index].Cells[2].Value = item.Color;
                dgvCTDD.Rows[index].Cells[3].Value = item.SoLuong;
                dgvCTDD.Rows[index].Cells[4].Value = item.SanPham.TenSanPham;

                /*if (item.Status == true)
                {
                    dgvDDSP.Rows[index].Cells[2].Value = "Còn sử dụng";
                }
                else
                {
                    dgvDDSP.Rows[index].Cells[2].Value = "Không sử dụng";
                    dgvDDSP.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                }*/
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra dữ liệu nhập vào ở các Textbox
                bool isValidated = isValidateDataCT();
                if (isValidated)// dữ liệu được xác thực đúng thỏa database
                {
                    using (var db = new QLBanHangHKDEntities())
                    {
                        var dacdiem = db.DacDiem_SanPham.FirstOrDefault(p => p.MaSanPham == cmbMaSP.SelectedValue.ToString()  && p.Size == cmbSize.Text && p.Color == cmbColor.Text);
                        if (dacdiem == null) // chưa có đặc diểm có size + color này
                        {
                            var dd = new DacDiem_SanPham()
                            {
                                MaSanPham = cmbMaSP.SelectedValue.ToString(),
                                Size = cmbSize.Text,
                                Color = cmbColor.Text,
                                SoLuong = Convert.ToInt32(txtSLSP.Text)
                                //Status = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm CT đặc điểm sản phẩm {dd.MaSanPham}, {dd.Size}, {dd.Color} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.DacDiem_SanPham.Add(dd);
                                db.SaveChanges();
                                frmTonKho_Load(sender, e);
                                MessageBox.Show($"Thêm mới CT Đặc điểm sản phẩm {dd.MaSanPham}, {dd.Size}, {dd.Color} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            dacdiem.SoLuong = Convert.ToInt32(txtSLSP.Text);
                            db.SaveChanges();
                            frmTonKho_Load(sender, e);
                            MessageBox.Show($"Cập nhật số lượng sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Xoatt();
                        }
                    }
                }
                else
                {
                    ThongBaoLoiDataInputCT();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Thêm  (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTonKho_Load(sender, e);
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    var dacdiem = db.DacDiem_SanPham.FirstOrDefault(p => p.MaSanPham == cmbMaSP.SelectedValue.ToString() && p.Size == cmbSize.Text && p.Color == cmbColor.Text);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (dacdiem != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateDataCT();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //dacdiem.MaSanPham = cmbMaSP.Text;
                            dacdiem.Size = cmbSize.Text;
                            dacdiem.Color = cmbColor.Text;
                            dacdiem.SoLuong = Convert.ToInt32(txtSLSP.Text);
                            //dacdiem.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Đặc điểm sản phẩm {cmbSize.Text}, {cmbColor.Text} cho {cmbMaSP.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                db.SaveChanges();
                                frmTonKho_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Đặc điểm sản phẩm {cmbSize.Text}, {cmbColor.Text} cho {cmbMaSP.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
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
                frmTonKho_Load(sender, e);
            }
        }

        private bool isValidateDataCT()
        {
            return KiemTra_BlankEmptyCT() == true && KiemTra_Limited_SLM_CTHD() == true && KiemTra_SLM_HopLe_CTHD() == true;
        }

        private void ThongBaoLoiDataInputCT()
        {
            if (KiemTra_BlankEmptyCT() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Đặc điểm Sản phẩm!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_SLM_CTHD() == false)
            {
                MessageBox.Show("Số lượng tồn phải 0 <= x <= 100 (vì shop nhỏ) và là số nguyên!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_SLM_HopLe_CTHD() == false)
            {
                MessageBox.Show("Số lượng tồn không hợp lệ!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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

        private bool KiemTra_Limited_SLM_CTHD()
        {
            int temp = Convert.ToInt32(txtSLSP.Text);
            if (temp >= 0 && temp <= 100)
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
                    cmbMaSP.Text = row.Cells[4].Value.ToString();
                    cmbSize.Text = row.Cells[1].Value.ToString();
                    cmbColor.Text = row.Cells[2].Value.ToString();
                    txtSLSP.Text = row.Cells[3].Value.ToString();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            txtSLSP.Text = "";
            cmbSize.Text = "Chọn size";
            cmbColor.Text = "Chọn màu";
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
