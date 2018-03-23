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
    public partial class frmTraHoaDon : Form
    {
        public frmTraHoaDon()
        {
            InitializeComponent();
        }

        private void frmTraHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Thực Sự Muốn Thoát ??", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            dtpTimKiem.ResetText();
            dtpNgayBatDau.ResetText();
            dtpNgayKetThuc.ResetText();
            txtTimKiem.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
