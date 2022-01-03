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
        private void BindGrid(List<DacDiem> listNhanVien)
        {
            dgvDacDiem.Rows.Clear();
            foreach (var item in listNhanVien)
            {
                int index = dgvDacDiem.Rows.Add();
                dgvDacDiem.Rows[index].Cells[0].Value = item.Size;
                dgvDacDiem.Rows[index].Cells[1].Value = item.Color;

                if (item.Status == true)
                {
                    dgvDacDiem.Rows[index].Cells[2].Value = "Còn sử dụng";
                }
                else
                {
                    dgvDacDiem.Rows[index].Cells[2].Value = "Không sử dụng";
                    dgvDacDiem.Rows[index].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<DacDiem> listDacDiem = db.DacDiems.ToList();
                List<SanPham> listSanPham = db.SanPhams.ToList();
                List<DacDiem_SanPham> listDDSP = db.DacDiem_SanPham.ToList();

                BindGrid(listDacDiem);
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

        #region Thêm, sửa đặc điểm
        //hàm xóa thông tin
        private void Xoatt()
        {
            txtSLSP.Text = "";
            
            cmbSize.Text = "Chọn size";
            cmbColor.Text = "Chọn màu";
            comboBoxSize.Text = "Chọn size";
            comboBoxColor.Text = "Chọn màu";
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra dữ liệu nhập vào ở các Textbox
                
                    using (var db = new QLBanHangHKDEntities())
                    {
                        int index = dgvDacDiem.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvDacDiem.Rows[index];
                        string temp = row.Cells[1].Value.ToString();
                        var dacdiem = db.DacDiems.FirstOrDefault(p => p.Size == comboBoxSize.Text && p.Color == comboBoxColor.Text);
                        if (dacdiem == null) // chưa có đặc diểm có size + color này
                        {
                            var dd = new DacDiem()
                            {
                                Size = comboBoxSize.Text,
                                Color = comboBoxColor.Text,
                                Status = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm đặc điểm {comboBoxSize.Text}, {comboBoxColor.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.DacDiems.Add(dd);
                                db.SaveChanges();
                                frmTonKho_Load(sender, e);
                                MessageBox.Show($"Thêm mới Đặc điểm {comboBoxSize.Text}, {comboBoxColor.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Đặc điểm {comboBoxSize.Text}, {comboBoxColor.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        }
                    }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Thêm Đặc điểm (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTonKho_Load(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    int index = dgvDacDiem.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvDacDiem.Rows[index];
                    string stemp = row.Cells[0].Value.ToString();
                    string temp = row.Cells[1].Value.ToString();
                    var dacdiem = db.DacDiems.FirstOrDefault(p => p.Size == comboBoxSize.Text && p.Color == comboBoxColor.Text);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (dacdiem != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        
                            //dacdiem.Size = txtSize.Text;
                            //dacdiem.Color = txtColor.Text;
                            dacdiem.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Đặc điểm {comboBoxSize.Text}, {comboBoxColor.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                
                                db.SaveChanges();
                                frmTonKho_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Đặc điểm {comboBoxSize.Text}, {comboBoxColor.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
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

        #endregion

        #region Kiểm tra lỗi nhập liệu


        #endregion

        private void dgvDacDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDacDiem.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvDacDiem.Rows[dgvDacDiem.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();

                    comboBoxSize.Text = row.Cells[0].Value.ToString();
                    comboBoxColor.Text = row.Cells[1].Value.ToString();
                    cbStatus.Checked = (row.Cells[2].Value.ToString() == "Còn sử dụng") ? false : true;
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
            List<DacDiem> listDacDiem = db.DacDiems.ToList();
            if (btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvDacDiem.Rows)
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

                foreach (DataGridViewRow item in dgvDacDiem.Rows)
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

        //-------------------------------------Chi tiết đặc điểm-------------------------------------------

        private void FillSanPhamCombobox(List<SanPham> listSanPham)
        {
            this.cmbMaSP.DataSource = listSanPham;
            this.cmbMaSP.ValueMember = "MaSanPham";
            this.cmbMaSP.DisplayMember = "MaSanPham";
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
                        int index = dgvCTDD.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvCTDD.Rows[index];
                        string temp = row.Cells[1].Value.ToString();
                        var dacdiem = db.DacDiem_SanPham.FirstOrDefault(p => p.MaSanPham == cmbMaSP.Text  && p.Size == cmbSize.Text && p.Color == cmbColor.Text);
                        if (dacdiem == null) // chưa có đặc diểm có size + color này
                        {
                            var dd = new DacDiem_SanPham()
                            {
                                MaSanPham = cmbMaSP.Text,
                                Size = cmbSize.Text,
                                Color = cmbColor.Text,
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
                            MessageBox.Show($"Chi tiết Đặc điểm sản phẩm {cmbMaSP.Text}, {cmbSize.Text}, {cmbColor.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
                    int index = dgvCTDD.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvCTDD.Rows[index];
                    string stemp = row.Cells[0].Value.ToString();
                    string temp = row.Cells[1].Value.ToString();
                    var dacdiem = db.DacDiem_SanPham.FirstOrDefault(p => p.MaSanPham == cmbMaSP.Text && p.Size == cmbSize.Text && p.Color == cmbColor.Text);
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
            return KiemTra_BlankEmptyCT();
        }

        private void ThongBaoLoiDataInputCT()
        {
            if (KiemTra_BlankEmptyCT() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Đặc điểm Sản phẩm!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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

        private void dgvCTDD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCTDD.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvCTDD.Rows[dgvCTDD.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();
                    cmbMaSP.Text = row.Cells[0].Value.ToString();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            comboBoxSize.Text = "Chọn size";
            comboBoxColor.Text = "Chọn màu";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxSize.Text = "Chọn size";
            comboBoxColor.Text = "Chọn màu";
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
