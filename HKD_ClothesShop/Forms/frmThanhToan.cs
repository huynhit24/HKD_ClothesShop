using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HKD_ClothesShop.Modal;

namespace HKD_ClothesShop.Forms
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            QLBanHangHKDEntities db = new QLBanHangHKDEntities();
            List<ChiTietHoaDon> listCTHoaDon = db.ChiTietHoaDons.ToList();
            BindGridCTHD(listCTHoaDon);
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
