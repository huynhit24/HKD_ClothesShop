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
                BindGrid(listDacDiem);
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
            txtSize.Text = "";
            txtColor.Text = "";
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
                        int index = dgvDacDiem.CurrentCell.RowIndex;
                        DataGridViewRow row = dgvDacDiem.Rows[index];
                        string temp = row.Cells[1].Value.ToString();
                        var dacdiem = db.DacDiems.FirstOrDefault(p => p.Size == txtSize.Text && p.Color == txtColor.Text);
                        if (dacdiem == null) // chưa có đặc diểm có size + color này
                        {
                            var dd = new DacDiem()
                            {
                                Size = txtSize.Text,
                                Color = txtColor.Text,
                                Status = (cbStatus.Checked == true) ? false : true
                            };
                            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm đặc điểm {txtSize.Text}, {txtColor.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.DacDiems.Add(dd);
                                db.SaveChanges();
                                frmTonKho_Load(sender, e);
                                MessageBox.Show($"Thêm mới Đặc điểm {txtSize.Text}, {txtColor.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Xoatt();
                            }
                            else
                            {
                                Xoatt();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Đặc điểm {txtSize.Text}, {txtColor.Text} này đã tồn tại rồi!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
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
                    var dacdiem = db.DacDiems.FirstOrDefault(p => p.Size == txtSize.Text && p.Color == txtColor.Text);
                    //var khachhang = db.KhachHangs.FirstOrDefault(p => p.MaKhachHang == txtMKH.Text);
                    if (dacdiem != null)
                    {
                        // kiểm tra dữ liệu lưu vào ở các Textbox
                        bool isValidated = isValidateData();
                        if (isValidated)// dữ liệu được xác thực đúng thỏa database
                        {
                            //dacdiem.Size = txtSize.Text;
                            //dacdiem.Color = txtColor.Text;
                            dacdiem.Status = (cbStatus.Checked == true) ? false : true;
                            if (MessageBox.Show($"Bạn có chắc chắn muốn lưu cập nhật Đặc điểm {txtSize.Text}, {txtColor.Text} này!", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                
                                db.SaveChanges();
                                frmTonKho_Load(sender, e);
                                MessageBox.Show($"Cập nhật thông tin Đặc điểm {txtSize.Text}, {txtColor.Text} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool isValidateData()
        {
            return KiemTra_BlankEmpty() == true
                   && KiemTra_Limited_Size() == true && KiemTra_ID_HopLe() == true
                   && KiemTra_Limited_Color() == true && KiemTra_Color_HopLe() == true;
        }

        private void ThongBaoLoiDataInput()
        {
            if (KiemTra_BlankEmpty() == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Đặc điểm!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_Size() == false)
            {
                MessageBox.Show("Size phải đủ 5 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_ID_HopLe() == false)
            {
                MessageBox.Show("Size không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Limited_Color() == false)
            {
                MessageBox.Show("Họ tên nhân viên không quá 10 kí tự - Mời nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTra_Color_HopLe() == false)
            {
                MessageBox.Show("Họ tên không hợp lệ - Mời nhập lại!\n\n(Không được chứa !@#$%^&*()_+-={}[]|...)", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }

        }

        private bool KiemTra_BlankEmpty()
        {
            if (txtSize.Text != "" && txtColor.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_Size()
        {
            if (txtSize.Text.Length == 5)
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
            Regex reg = new Regex(XacthucRegex.Regex_Size);
            Match mat = reg.Match(txtSize.Text);
            if (mat.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Limited_Color()
        {
            if (txtColor.Text.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool KiemTra_Color_HopLe()
        {
            Regex reg = new Regex(XacthucRegex.Regex_Color);
            Match mat = reg.Match(txtColor.Text);
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

        private void dgvDacDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDacDiem.Rows.Count != 0)
                {
                    DataGridViewRow row = dgvDacDiem.Rows[dgvDacDiem.CurrentCell.RowIndex];
                    QLBanHangHKDEntities context = new QLBanHangHKDEntities();

                    txtSize.Text = row.Cells[0].Value.ToString();
                    txtColor.Text = row.Cells[1].Value.ToString();
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


    }
}
