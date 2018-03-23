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
    public partial class frmDanhSachSanPham : Form
    {
        public frmDanhSachSanPham()
        {
            InitializeComponent();
        }

        private void frmDanhSachSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Thực Sự Muốn Thoát ??", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtTimKiem.Focus();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            dgvDanhSachSP.DataSource = sanPham.TimKiemSanPham(txtTimKiem.Text);
        }

        private void frmDanhSachSanPham_Load(object sender, EventArgs e)
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            dgvDanhSachSP.DataSource = sanPham.Load();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            dgvDanhSachSP.DataSource = sanPham.Load();
        }
    }
}
