using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangMyPham
{
    public partial class frmThongTinTaiKhoan : Form
    {
        private string maNV = "";
        private DTO.NhanVienDTO nhanVien = null;
        public frmThongTinTaiKhoan(string maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Thực Sự Muốn Thoát ??", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void frmThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadThongTinNhanVien();
        }
        private void LoadThongTinNhanVien()
        {
            BLL.NhanVienBLL nv = new BLL.NhanVienBLL();
            nhanVien = nv.GetNhanVienByMaNV(this.maNV);
            txtCMNDNhanVien.Text = nhanVien.Cmnd;
            txtDiaChiNhanVien.Text = nhanVien.DiaChi;
            txtDienThoaiNhanVien.Text = nhanVien.DienThoai;
            txtHoNhanVien.Text = nhanVien.HoNV;
            txtTenNhanVien.Text = nhanVien.TenNV;
            txtQueQuanNhanVien.Text = nhanVien.QueQuan;
            txtMaNV.Text = this.maNV;
            dtpNgayVaoLamNhanVien.Text = nhanVien.NgayVaoLam;
            dtpNgaySinhNhanVien.Text = nhanVien.NgaySinh;
            txtTenTaiKhoan.Text = nhanVien.MaNhanVien;
            if (nhanVien.GioiTinh == true)
            {
                rbNamNhanVien.Checked = true;
            }
            else
            {
                rbNuNhanVien.Checked = true;
            }
        }
        private bool CheckPassWord()
        {
            BLL.DangNhapBLL dangNhap = new BLL.DangNhapBLL();
            return dangNhap.Login(txtTenTaiKhoan.Text, txtMatKhau.Text);
        }

        private void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            if(txtMatKhauMoi1.Text!= ""&& txtMatKhauMoi2.Text !="" &&txtMatKhau.Text!= "")
            {
                if (CheckPassWord() == true)
                {
                    BLL.DangNhapBLL changePassword = new BLL.DangNhapBLL();
                    if(changePassword.UpdateAccountUserNameAndPassWord(txtTenTaiKhoan.Text,txtMatKhauMoi1.Text)==true)
                    {
                        MessageBox.Show("Thay đỗi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMatKhauMoi1.Text = "";
                        txtMatKhau.Text = "";
                        txtMatKhauMoi2.Text = "";
                        txtMatKhau.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình thực hiện !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu bạn nhập vào không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
