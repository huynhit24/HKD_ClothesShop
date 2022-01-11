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
    public partial class frmLoaiSanPham : Form
    {
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }
        #region Binding dữ liệu lên các control + datagridview
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindGrid(List<LoaiSanPham> listLSP)
        {
            dgvLoaiSanPham.Rows.Clear();
            foreach (var item in listLSP)
            {
                int index = dgvLoaiSanPham.Rows.Add();
                dgvLoaiSanPham.Rows[index].Cells[0].Value = item.MaLoaiSP;
                dgvLoaiSanPham.Rows[index].Cells[1].Value = item.TenLoaiSP;
                if (item.Status == true)
                {
                    dgvLoaiSanPham.Rows[index].Cells[2].Value = "Còn sử dụng";
                }
                else
                {
                    dgvLoaiSanPham.Rows[index].Cells[2].Value = "Không sử dụng";
                    dgvLoaiSanPham.Rows[index].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                QLBanHangHKDEntities db = new QLBanHangHKDEntities();
                List<LoaiSanPham> listLSP = db.LoaiSanPhams.ToList();
                BindGrid(listLSP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Thêm, sửa loại sản phẩm
        private void Xoatt()
        {
            txtML.Text = "";
            txtTenLoai.Text = "";
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra dữ liệu nhập vào ở các Textbox
                bool isValidated = isValidateData();
                if (isValidated)// dữ liệu được xác thực đúng thỏa database
                {
                    using (var db = new QLBanHangHKDEntities())
                    {
                        if(dgvLoaiSanPham.Rows.Count != 0)
                        {
                            /*int index = dgvLoaiSanPham.CurrentCell.RowIndex;
                            DataGridViewRow row = dgvLoaiSanPham.Rows[index];
                            string temp = row.Cells[0].Value.ToString();*/
                            var loaisp = db.LoaiSanPhams.FirstOrDefault(p => p.MaLoaiSP == txtML.Text.ToUpper());
                            if (loaisp == null) // chưa có loại sp có mã này
                            {
                                var lsp = new LoaiSanPham()
                                {
                                    MaLoaiSP = txtML.Text.ToUpper(),
                                    TenLoaiSP = txtTenLoai.Text,
                                    Status = (cbStatus.Checked == true) ? false : true
                                };
                                if (MessageBox.Show($"Bạn có muốn lưu thêm loại sản phẩm này!", "Lưu/Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    db.LoaiSanPhams.Add(lsp);
                                    db.SaveChanges();
                                    frmLoaiSanPham_Load(sender, e);
                                    MessageBox.Show($"Thêm mới Loại sản phẩm {txtTenLoai.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Xoatt();
                                }
                                else
                                {
                                    Xoatt();
                                }

                            }
                            else
                            {
                                MessageBox.Show($"Mã loại SP {txtML.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu để chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(ex.Message, "Lỗi Thêm Loại SP (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmLoaiSanPham_Load(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLBanHangHKDEntities())
                {
                    /*int index = dgvLoaiSanPham.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvLoaiSanPham.Rows[index];
                    string temp = row.Cells[0].Value.ToString();*/
                    //var loaisp = db.LoaiSanPhams.FirstOrDefault(p => p.MaLoaiSP == temp);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    var loaisp = db.LoaiSanPhams.FirstOrDefault(p => p.MaLoaiSP == txtML.Text.ToUpper());

                    if (loaisp != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateData();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //loaisp.MaLoaiSP = txtML.Text;
                            loaisp.TenLoaiSP = txtTenLoai.Text;
                            loaisp.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có muốn lưu sửa loại sản phẩm này!", "Lưu/Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.SaveChanges();
                                frmLoaiSanPham_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Loại sản phẩm {txtML.Text}, {txtTenLoai.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Không tìm thấy Thông tin Loại SP cần sửa!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Sửa Loại SP (có thể do trùng mã khác trong CSDL)! - Mời bạn thử lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmLoaiSanPham_Load(sender, e);
            }
        }

        #endregion

        #region Kiểm tra lỗi nhập liệu

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_ML() == true && KiemTra_ID_HopLe() == true
                   && KiemTra_Limited_TenLoai() == true && KiemTra_TenLoai_HopLe() == true;
        }

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Loại sản phẩm!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_ML() == false)
            {
                MessageBox.Show("Loại sản phẩm phải đủ 4 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_ID_HopLe() == false)
            {
                MessageBox.Show("Mã không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_TenLoai() == false)
            {
                MessageBox.Show("Tên loại sản phẩm không quá 20 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_TenLoai_HopLe() == false)
            {
                MessageBox.Show("Tên loại sản phẩm không hợp lệ - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }

        }

        private bool KiemTra_BlankEmpty()
        {
            if (txtML.Text != "" && txtTenLoai.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_ML()
        {
            if (txtML.Text.Length == 4)
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
            Match mat = reg.Match(txtML.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_TenLoai()
        {
            if (txtTenLoai.Text.Length <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_TenLoai_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_HoTen);
            Match mat = reg.Match(txtTenLoai.Text);
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

        private void dgvLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLoaiSanPham.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvLoaiSanPham.Rows[dgvLoaiSanPham.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();

                    txtML.Text = row.Cells[0].Value.ToString();
                    txtTenLoai.Text = row.Cells[1].Value.ToString();
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
            List<LoaiSanPham> listLSP = db.LoaiSanPhams.ToList();
            if (btnHidden.Text == "Ẩn")
            {
                foreach (DataGridViewRow item in dgvLoaiSanPham.Rows)
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

                foreach (DataGridViewRow item in dgvLoaiSanPham.Rows)
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
    }
}
