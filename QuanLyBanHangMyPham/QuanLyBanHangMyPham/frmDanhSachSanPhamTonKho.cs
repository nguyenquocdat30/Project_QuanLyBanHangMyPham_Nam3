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
    public partial class frmDanhSachSanPhamTonKho : Form
    {
        public frmDanhSachSanPhamTonKho()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtTimKiem.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDanhSachSanPhamTonKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Thực Sự Muốn Thoát ??", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            dgvDanhSachSanPhamTonKho.DataSource = sanPham.TimKiemSanPhamTonKho(txtTimKiem.Text);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            dgvDanhSachSanPhamTonKho.DataSource = sanPham.LoadSanPhamTonKho();
        }

        private void frmDanhSachSanPhamTonKho_Load(object sender, EventArgs e)
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            dgvDanhSachSanPhamTonKho.DataSource = sanPham.LoadSanPhamTonKho();
        }
    }
}
