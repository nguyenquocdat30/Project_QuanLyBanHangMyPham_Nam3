using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QuanLyBanHangMyPham
{
    public partial class frmManager : Form
    {
        private DTO.DangNhapDTO loginAccount;
        private DTO.KhachHangDTO kh = null;
        private DTO.HoaDonDTO hd = null;
        private DTO.ChiTietHoaDonDTO cthd = null;
        private double tongTienHoaDon;
        private bool checkThemKhachHang;
        private bool checkThemHoaDon;
        public DangNhapDTO LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
                QuyenTruyCap(loginAccount.QuyenHan);
            }
        }

        public frmManager(DangNhapDTO account)
        {
            InitializeComponent();
            this.LoginAccount = account;
            this.checkThemKhachHang = false;
            this.checkThemHoaDon = false;
        }
        private void QuyenTruyCap(bool type)
        {
            dangNhapQuanTriToolStripMenuItem.Enabled = type == true;
        }
        private bool SetQuyenTruyCap(DangNhapDTO login)
        {
            if (login.QuyenHan == true) return true;
            else return false;
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            LoadDataToComboBox();
            LoadInputDataToListView();
            LoadGvHoaDon();
        }
        private void LoadGvHoaDon()
        {
            BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
            dgvHoaDon.DataSource = hoaDon.LoadHoaDonManager();
        }
        private void frmManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Thực Sự Muốn Thoát ??","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!=DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void traHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraHoaDon f = new frmTraHoaDon();
            f.ShowDialog();
        }

        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.ShowDialog();
        }

        private void danhSachSanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachSanPham f = new frmDanhSachSanPham();
            f.ShowDialog();
        }

        private void danhSachTonKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachSanPhamTonKho f = new frmDanhSachSanPhamTonKho();
            f.ShowDialog();
        }

        private void dangNhapQuanTriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void thongTinTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinTaiKhoan f = new frmThongTinTaiKhoan(LoginAccount.UserName);
            f.ShowDialog();
        }

        private void thongTinPhanMemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem f = new frmThongTinPhanMem();
            f.ShowDialog();
        }

        private void troGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mọi thông tin liên hệ Team DCH : 0164.312.7775 ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            if(checkThemKhachHang == false)
            {
                checkThemKhachHang = ThemKhachHang();
                if(checkThemKhachHang == true)
                {
                    if (checkThemHoaDon == false)
                    {
                        checkThemHoaDon = ThemHoaDon();
                    }
                }
            }
            
            if(checkThemHoaDon == true && checkThemKhachHang == true&& listViewGioHang.Items.Count>0)
            {
                ThemChiTietHoaDon();
                ClearInput();
                listViewGioHang.Items.Clear();
                checkThemKhachHang = false;
                checkThemHoaDon = false;
                LoadGvHoaDon();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình thực hiện - Vui lòng xem lại dữ liệu vào ..", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadDataToComboBox();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            //int a = Int32.Parse(cbbSoLuong.Text);
            //string b = cbbSanPham.SelectedValue.ToString();
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            ThemGioHang();
            setTongTien();
        }

        private void btnXoaGioHang_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa sản phẩm ra khỏi giỏ hàng ??", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                for (int i = 0; i < listViewGioHang.Items.Count; i++)
                {
                    if(listViewGioHang.Items[i].Checked|| listViewGioHang.Items[i].Selected)
                    {
                        listViewGioHang.Items[i].Remove();
                    }
                }
            }
            setTongTien();
        }
        #region function 
        // fuction Clear Input
        private void ClearInput()
        {
            txtTenKhachHang.Text = "";
            txtHoKhachHang.Text = "";
            txtDiaChiKhachHang.Text = "";
            txtDienThoaiKhachHang.Text = "";
            txtDonGia.Text = "";
            txtEmailKhachHang.Text = "";
            rbNamKhachHang.Checked = false;
            rbNuKhachHang.Checked = false;
            dtpNgaySinhKhachHang.ResetText();
            cbbSanPham.ResetText();
            cbbSoLuong.ResetText();
            txtHoKhachHang.Focus();
        }
        // function Load Data vào Combobox và số lượng
        public void LoadDataToComboBox()
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            cbbSanPham.DataSource = sanPham.LoadCbbManager();
            cbbSanPham.DisplayMember = "TENSP";
            cbbSanPham.ValueMember = "MASP";
            for(int i=1;i<50;i++)
            {
                cbbSoLuong.Items.Add(i);
            }
        }
        public void LoadInputDataToListView()
        {
            listViewGioHang.CheckBoxes = true;
            listViewGioHang.Columns.Add("Tên sản phẩm",95);
            listViewGioHang.Columns.Add("SL",30);
            listViewGioHang.Columns.Add("Đơn giá",90);
            listViewGioHang.Columns.Add("Tổng",90);
            listViewGioHang.View = View.Details;
        }
        public void ThemGioHang()
        {
            double tongTien = 0;
            if (cbbSanPham.Text !="" && cbbSoLuong.Text != "" && txtDonGia.Text != "")
            {
                if(listViewGioHang.Items.Count>0)
                {
                    for (int i = 0; i < listViewGioHang.Items.Count; i++)
                    {
                        if (cbbSanPham.Text == listViewGioHang.Items[i].SubItems[0].Text)
                        {
                            txtDonGia.Value = Int32.Parse(xoaChuoiTongTienVND(listViewGioHang.Items[i].SubItems[2].Text));
                            int soLuong = Int32.Parse(listViewGioHang.Items[i].SubItems[1].Text) + Int32.Parse(cbbSoLuong.Text);
                            listViewGioHang.Items[i].SubItems[1].Text = soLuong.ToString();
                            tongTien = (double)soLuong * Double.Parse(xoaChuoiTongTienVND(listViewGioHang.Items[i].SubItems[2].Text));
                            listViewGioHang.Items[i].SubItems[3].Text = tongTien.ToString() + "vnđ";
                            return;
                        }
                    }
                }
                tongTien = Double.Parse(txtDonGia.Text) * Double.Parse(cbbSoLuong.Text);
                ListViewItem item = new ListViewItem();
                item.Text = cbbSanPham.Text;
                item.SubItems.Add(cbbSoLuong.Text);
                item.SubItems.Add(txtDonGia.Text + "vnđ");
                item.SubItems.Add(tongTien.ToString() + "vnđ");
                listViewGioHang.Items.Add(item);
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập đầy đủ thông tin giỏ hàng trước khi thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDonGia.Focus();
            }
        }
        public void setTongTien()
        {
            double tong = 0;
            if(listViewGioHang.Items.Count<=0)
            {
                tong = 0;
            }
            else
            {
                for(int i=0;i<listViewGioHang.Items.Count;i++)
                {
                    tong += Double.Parse(xoaChuoiTongTienVND(listViewGioHang.Items[i].SubItems[3].Text));
                }
            }
            tongTienHoaDon = tong;
            lblTongTien.Text = tongTienHoaDon.ToString() + "vnđ";
        }
        public string xoaChuoiTongTienVND(string str)
        {
            int temp = str.IndexOf("v");
            str = str.Remove(temp);
            return str;
        }
        #endregion
        public bool ThemKhachHang()
        {
            string hoKh = txtHoKhachHang.Text;
            string tenKh = txtTenKhachHang.Text;
            string ngaySinh = dtpNgaySinhKhachHang.Text;
            string dienThoai = txtDienThoaiKhachHang.Text;
            string eMail = txtEmailKhachHang.Text;
            string diaChi = txtDiaChiKhachHang.Text;
            BLL.KhachHangBLL khachHang = new BLL.KhachHangBLL();
            
            if (txtHoKhachHang.Text != "" && txtTenKhachHang.Text != "" && dtpNgaySinhKhachHang.Text != "" && txtDiaChiKhachHang.Text != "" && (rbNamKhachHang.Checked == true || rbNuKhachHang.Checked == true))
            {
                if (rbNamKhachHang.Checked == true)
                {
                    // sử dụng procdure trong sql tự động sinh mã nên không cần truyền mã khách hàng xuống
                    kh = new KhachHangDTO("", hoKh, tenKh, ngaySinh, true, diaChi, dienThoai, eMail);
                }
                else
                {
                    kh = new KhachHangDTO("", hoKh, tenKh, ngaySinh, false, diaChi, dienThoai, eMail);
                }
                return khachHang.Insert(kh);
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập đầy đủ thông tin trong phần khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoKhachHang.Focus();
            }
            return false;
        }
        public bool ThemHoaDon()
        {
            BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
            BLL.KhachHangBLL khachHang = new BLL.KhachHangBLL();
            kh = khachHang.getLastCustomer();
            hd = new DTO.HoaDonDTO("", DateTime.Now.ToString("yyyy-MM-dd"), kh.MaKH, LoginAccount.UserName);
            return hoaDon.Insert(hd);
        }
        public void ThemChiTietHoaDon()
        {
            BLL.ChiTietHoaDonBLL chiTietHoaDon = new BLL.ChiTietHoaDonBLL();
            BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
            hd = hoaDon.getBill();
            hd = hoaDon.getBill();
            if (listViewGioHang.Items.Count <= 0)
            {
                MessageBox.Show("Hãy thêm vào giỏ hàng trước khi lập hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < listViewGioHang.Items.Count; i++)
                {
                    string maSP = "";
                    int soLuong = Int32.Parse(listViewGioHang.Items[i].SubItems[1].Text);
                    double donGia = Double.Parse(xoaChuoiTongTienVND(listViewGioHang.Items[i].SubItems[2].Text));
                    foreach (var temp in cbbSanPham.Items)
                    {
                        DataRowView ma = (DataRowView)temp;
                        if (ma.Row.ItemArray[1].ToString() == listViewGioHang.Items[i].SubItems[0].Text)
                        {
                            maSP = ma.Row.ItemArray[0].ToString();
                            break;
                        }
                    }
                    cthd = new ChiTietHoaDonDTO(hd.MaHD, maSP, soLuong, donGia);
                    chiTietHoaDon.Insert(cthd);
                }
                MessageBox.Show("Thêm thành công ");
            }
        }
    }
}
