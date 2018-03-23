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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadComboboxMaKhachHang();
            LoadComboboxTenNhanVien();
            LoadComboboxNhaCungCap();
            LoadComboboxNhaSanXuat();
            LoadNSX();
            LoadDataNCC();
            LoadNhanVien();
            LoadKH();
            LoadTK();
            LoadSP();
        }
        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Thực Sự Muốn Thoát ??","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!= DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLamMoiHD_Click(object sender, EventArgs e)
        {
            LamMoiHoaDon();
        }

        
        #region Các hàm sử dụng lại và load combobox 
        private void LamMoiNhaCungCap()
        {
            txtMaNhaCungCapNCC.Text = "";
            txtTenNhaCungCapNCC.Text = "";
            txtDiaChiNCC.Text = "";
            txtDienThoaiNCC.Text = "";
            txtEmailNCC.Text = "";
            txtMaNhaCungCapNCC.Focus();
        }
        private void LamMoiNhaSanXuat()
        {
            txtMaNhaSanXuatNSX.Text = "";
            txtTenNhaSanXuatNSX.Text = "";
            cbbQuocGiaNSX.ResetText();
            txtMaNhaSanXuatNSX.Focus();
        }
        private void LamMoiNhanVien()
        {
            txtMaNhanVienNV.Text = "";
            txtHoNhanVienNV.Text = "";
            txtTenNhanVienNV.Text = "";
            txtDiaChiNV.Text = "";
            txtDienThoaiNV.Text = "";
            txtQueQuanNV.Text = "";
            txtCMNDNV.Text = "";
            rbNamNV.Checked = false;
            rbNuNV.Checked = false;
            dtpNgayVaoLamNV.ResetText();
            dtpNgaySinhNV.ResetText();
            txtHoNhanVienNV.Focus();
        }
        private void LamMoiKhachHang()
        {
            cbbMaKhachHangKH.Text = "";
            txtHoKhachHangKH.Text = "";
            txtTenKhachHangKH.Text = "";
            txtDiaChiKH.Text = "";
            txtDienThoaiKH.Text = "";
            txtEmailKH.Text = "";
            rbNamKH.Checked = false;
            rbNuKH.Checked = false;
            dtpNgaySinhKH.ResetText();
            txtHoKhachHangKH.Focus();
        }
        private void LamMoiSanPham()
        {
            txtMaSanPhamSP.Text = "";
            txtTenSanPhamSP.Text = "";
            txtMoTaSP.Text = "";
            txtDonGiaSP.Text = "";
            dtpNgaySanXuatSP.ResetText();
            dtpHanSuDungSP.ResetText();
            cbbMaNhaCungCapSP.ResetText();
            cbbMaNhaSanXuatSP.ResetText();
            cbbSoLuongTonKhoSP.ResetText();
            txtMaSanPhamSP.Focus();
        }
        private void LamMoiHoaDon()
        {
            txtMaHoaDonHD.Text = "";
            cbbMaNhanVienHD.ResetText();
            cbbMaKhachHangHD.ResetText();
            dtpNgayLapHoaDonHD.ResetText();
            listViewHoaDonHD.Clear();
        }
        private void LamMoiTaiKhoan()
        {
            txtUsernameTK.Text = "";
            txtPasswordTK.Text = "";
            cbbQuyenHanTK.ResetText();
            cbbTenNhanVienTK.ResetText();
        }
        private void LoadComboboxMaKhachHang()
        {
            BLL.KhachHangBLL khachHang = new BLL.KhachHangBLL();
            cbbMaKhachHangKH.DataSource = khachHang.LoadCbbManager();
            cbbMaKhachHangKH.ValueMember = "MAKH";
            cbbMaKhachHangKH.DisplayMember = "MAKH";
        }
        private void LoadComboboxTenNhanVien()
        {
            BLL.NhanVienBLL nhanVien = new BLL.NhanVienBLL();
            cbbTenNhanVienTK.DataSource = nhanVien.LoadCbbManager();
            cbbTenNhanVienTK.ValueMember = "MANV";
            cbbTenNhanVienTK.DisplayMember = "HOTENNV";
        }
        private void LoadComboboxNhaCungCap()
        {
            BLL.NhaCungCapBLL ncc = new BLL.NhaCungCapBLL();
            cbbMaNhaCungCapSP.DataSource = ncc.LoadCbbManager();
            cbbMaNhaCungCapSP.ValueMember = "MANCC";
            cbbMaNhaCungCapSP.DisplayMember = "TENNCC";
        }
        private void LoadComboboxNhaSanXuat()
        {
            BLL.NhaSanXuatBLL nsx = new BLL.NhaSanXuatBLL();
            cbbMaNhaSanXuatSP.DataSource = nsx.LoadCbbManager();
            cbbMaNhaSanXuatSP.ValueMember = "MASX";
            cbbMaNhaSanXuatSP.DisplayMember = "TENNSX";
        }

        #endregion
        #region Nhà cung cấp
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNhaCungCapNCC.Text;
            string tenNCC = txtTenNhaCungCapNCC.Text;
            string diaChiNCC = txtDiaChiNCC.Text;
            string dienThoaiNCC = txtDienThoaiNCC.Text;
            string emailNCC = txtEmailNCC.Text;
            if (maNCC != "" && diaChiNCC != "" && tenNCC != "")
            {
                BLL.NhaCungCapBLL ncc = new BLL.NhaCungCapBLL();
                if (ncc.Insert(maNCC, tenNCC, diaChiNCC, dienThoaiNCC, emailNCC) == true)
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNhaCungCap();
                    LoadComboboxNhaCungCap();
                    LoadDataNCC();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNhaCungCapNCC.Focus();
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin Nhà cung cấp trước khi thêm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCapNhatNCC_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNhaCungCapNCC.Text;
            string tenNCC = txtTenNhaCungCapNCC.Text;
            string diaChiNCC = txtDiaChiNCC.Text;
            string dienThoaiNCC = txtDienThoaiNCC.Text;
            string emailNCC = txtEmailNCC.Text;
            if (maNCC != "" && diaChiNCC != "" && tenNCC != "")
            {
                BLL.NhaCungCapBLL ncc = new BLL.NhaCungCapBLL();
                if (ncc.Update(maNCC, tenNCC, diaChiNCC, dienThoaiNCC, emailNCC) == true)
                {
                    MessageBox.Show("Cập nhật thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNhaCungCap();
                    LoadDataNCC();
                    LoadComboboxNhaCungCap();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNhaCungCapNCC.Focus();
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin Nhà cung cấp trước khi Cập nhật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNhaCungCapNCC.Text;
            if(maNCC != "")
            {
                BLL.NhaCungCapBLL ncc = new BLL.NhaCungCapBLL();
                if(ncc.Delete(maNCC) == true)
                {
                    MessageBox.Show("Xóa thành công NCC "+maNCC, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNhaCungCap();
                    LoadDataNCC();
                    LoadComboboxNhaCungCap();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin mã nhà cung cấp chưa được nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLamMoiNCC_Click(object sender, EventArgs e)
        {
            LamMoiNhaCungCap();
            LoadDataNCC();
        }

        private void LoadDataNCC()
        {
            BLL.NhaCungCapBLL ncc1 = new BLL.NhaCungCapBLL();
            dgvNCC.DataSource = ncc1.Load();
        }
        #endregion

        #region Nhà sản xuất


        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            if(txtMaNhaSanXuatNSX.Text != "" && txtTenNhaSanXuatNSX.Text !=""&& cbbQuocGiaNSX.Text != "")
            {
                BLL.NhaSanXuatBLL nhaSanXuat = new BLL.NhaSanXuatBLL();
                if(nhaSanXuat.Insert(txtMaNhaSanXuatNSX.Text,txtTenNhaSanXuatNSX.Text,cbbQuocGiaNSX.Text)==true)
                {
                    MessageBox.Show("Thêm nhà sản xuất thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNhaSanXuat();
                    LoadNSX();
                    LoadComboboxNhaSanXuat();
                }
                else
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin nhà sản xuất trước khi thêm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhatNSX_Click(object sender, EventArgs e)
        {
            BLL.NhaSanXuatBLL nhaSanXuat = new BLL.NhaSanXuatBLL();
            if(txtMaNhaSanXuatNSX.Text!=""&&txtTenNhaSanXuatNSX.Text!="" && cbbQuocGiaNSX.Text !="")
            {
                if(nhaSanXuat.Update(txtMaNhaSanXuatNSX.Text, txtTenNhaSanXuatNSX.Text, cbbQuocGiaNSX.Text) == true)
                {
                    MessageBox.Show("Cập nhật thành công ");
                    LamMoiNhaSanXuat();
                    LoadNSX();
                    LoadComboboxNhaSanXuat();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện");
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin trước khi cập nhật");
            }
        }

        private void btnXoaNSX_Click(object sender, EventArgs e)
        {
            if (txtMaNhaSanXuatNSX.Text != "")
            {
                BLL.NhaSanXuatBLL nhaSanXuat = new BLL.NhaSanXuatBLL();
                if (nhaSanXuat.Delete(txtMaNhaSanXuatNSX.Text) == true)
                {
                    MessageBox.Show("Xóa thành công nhà sản xuất "+ txtMaNhaSanXuatNSX.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNhaSanXuat();
                    LoadNSX();
                    LoadComboboxNhaSanXuat();
                }
                else
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin mã nhà sản xuất chưa được nhập!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLamMoiNSX_Click(object sender, EventArgs e)
        {
            LamMoiNhaSanXuat();
            LoadNSX();
        }
        private void LoadNSX()
        {
            BLL.NhaSanXuatBLL nsx = new BLL.NhaSanXuatBLL();
            dgvNSX.DataSource = nsx.Load();
        }
        #endregion
        #region Nhân viên
        private void btnLamMoiNV_Click(object sender, EventArgs e)
        {
            LamMoiNhanVien();
        }


        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (rbNamNV.Checked == true || rbNuNV.Checked == true)
            {
                if (txtMaNhanVienNV.Text != "" && txtHoNhanVienNV.Text != "" && txtTenNhanVienNV.Text != "" && txtDiaChiNV.Text != "" && txtDienThoaiNV.Text != "" && dtpNgaySinhNV.Text != "" && dtpNgayVaoLamNV.Text != "")
                {
                    BLL.NhanVienBLL nhanVien = new BLL.NhanVienBLL();
                    if (rbNamNV.Checked == true)
                    {
                        if (nhanVien.Insert(txtMaNhanVienNV.Text, txtHoNhanVienNV.Text, txtTenNhanVienNV.Text, dtpNgaySinhNV.Text, true, txtDiaChiNV.Text, txtDienThoaiNV.Text, txtCMNDNV.Text, txtQueQuanNV.Text, dtpNgayVaoLamNV.Text) == true)
                        {
                            MessageBox.Show("Thêm nhân viên thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LamMoiNhanVien();
                            LoadNhanVien();
                            LoadComboboxTenNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (nhanVien.Insert(txtMaNhanVienNV.Text, txtHoNhanVienNV.Text, txtTenNhanVienNV.Text, dtpNgaySinhNV.Text, false, txtDiaChiNV.Text, txtDienThoaiNV.Text, txtCMNDNV.Text, txtQueQuanNV.Text, dtpNgayVaoLamNV.Text) == true)
                        {
                            MessageBox.Show("Thêm nhân viên thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LamMoiNhanVien();
                            LoadNhanVien();
                            LoadComboboxTenNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nhập đầy đủ thông tin nhân viên trước khi thêm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCapNhatNV_Click(object sender, EventArgs e)
        {
            if (rbNamNV.Checked == true || rbNuNV.Checked == true)
            {
                if (txtMaNhanVienNV.Text != "" && txtHoNhanVienNV.Text != "" && txtTenNhanVienNV.Text != "" && txtDiaChiNV.Text != "" && txtDienThoaiNV.Text != "" && dtpNgaySinhNV.Text != "" && dtpNgayVaoLamNV.Text != "")
                {
                    BLL.NhanVienBLL nhanVien = new BLL.NhanVienBLL();
                    if (rbNamNV.Checked == true)
                    {
                        if (nhanVien.Update(txtMaNhanVienNV.Text, txtHoNhanVienNV.Text, txtTenNhanVienNV.Text, dtpNgaySinhNV.Text, true, txtDiaChiNV.Text, txtDienThoaiNV.Text, txtCMNDNV.Text, txtQueQuanNV.Text, dtpNgayVaoLamNV.Text) == true)
                        {
                            MessageBox.Show("Cập nhật thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LamMoiNhanVien();
                            LoadNhanVien();
                            LoadComboboxTenNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (nhanVien.Update(txtMaNhanVienNV.Text, txtHoNhanVienNV.Text, txtTenNhanVienNV.Text, dtpNgaySinhNV.Text, false, txtDiaChiNV.Text, txtDienThoaiNV.Text, txtCMNDNV.Text, txtQueQuanNV.Text, dtpNgayVaoLamNV.Text) == true)
                        {
                            MessageBox.Show("Cập nhật thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LamMoiNhanVien();
                            LoadNhanVien();
                            LoadComboboxTenNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nhập đầy đủ thông tin nhân viên trước khi thêm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVienNV.Text != "")
            {
                BLL.NhanVienBLL nhanVien = new BLL.NhanVienBLL();
                if (nhanVien.Delete(txtMaNhanVienNV.Text) == true)
                {
                    MessageBox.Show("Xóa thành công nhân viên và tài khoản cấp phát cho nhân viên MNV : " + txtMaNhanVienNV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNhanVien();
                    LoadNhanVien();
                    LoadComboboxTenNhanVien();
                }
                else
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin mã nhân viên chưa được nhập!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadNhanVien()
        {
            BLL.NhanVienBLL nv = new BLL.NhanVienBLL();
            dgvNV.DataSource = nv.Load();
        }
        #endregion

        #region Khách Hàng
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if(txtHoKhachHangKH.Text !="" &&dtpNgaySinhKH.Text!=""&& txtTenKhachHangKH.Text != ""&& txtDienThoaiKH.Text != "" && txtDiaChiKH.Text!= "" &&(rbNamKH.Checked==true || rbNuKH.Checked == true))
            {
                DTO.KhachHangDTO kh = null;
                if (rbNamKH.Checked == true)
                {
                    // sử dụng procdure trong sql tự động sinh mã nên không cần truyền mã khách hàng xuống
                    kh = new DTO.KhachHangDTO("", txtHoKhachHangKH.Text, txtTenKhachHangKH.Text, dtpNgaySinhKH.Text, true, txtDiaChiKH.Text, txtDienThoaiKH.Text, txtEmailKH.Text);
                }
                else
                {
                    kh = new DTO.KhachHangDTO("", txtHoKhachHangKH.Text, txtTenKhachHangKH.Text, dtpNgaySinhKH.Text, false, txtDiaChiKH.Text, txtDienThoaiKH.Text, txtEmailKH.Text);
                }
                BLL.KhachHangBLL khachHang = new BLL.KhachHangBLL();
                if(khachHang.Insert(kh) == true)
                {
                    MessageBox.Show("Thêm khách hàng thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiKhachHang();
                    LoadComboboxMaKhachHang();
                    LoadKH();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHoKhachHangKH.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập đầy đủ thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoKhachHangKH.Focus();
            }
        }

        private void btnCapNhatKH_Click(object sender, EventArgs e)
        {
            if (cbbMaKhachHangKH.SelectedValue.ToString() !=""&&txtHoKhachHangKH.Text != "" && dtpNgaySinhKH.Text != "" && txtTenKhachHangKH.Text != "" && txtDienThoaiKH.Text != "" && txtDiaChiKH.Text != "" && (rbNamKH.Checked == true || rbNuKH.Checked == true))
            {
                DTO.KhachHangDTO kh = null;
                if (rbNamKH.Checked == true)
                {
                    // sử dụng procdure trong sql tự động sinh mã nên không cần truyền mã khách hàng xuống
                    kh = new DTO.KhachHangDTO(cbbMaKhachHangKH.SelectedValue.ToString(), txtHoKhachHangKH.Text, txtTenKhachHangKH.Text, dtpNgaySinhKH.Text, true, txtDiaChiKH.Text, txtDienThoaiKH.Text, txtEmailKH.Text);
                }
                else
                {
                    kh = new DTO.KhachHangDTO(cbbMaKhachHangKH.SelectedValue.ToString(), txtHoKhachHangKH.Text, txtTenKhachHangKH.Text, dtpNgaySinhKH.Text, false, txtDiaChiKH.Text, txtDienThoaiKH.Text, txtEmailKH.Text);
                }
                BLL.KhachHangBLL khachHang = new BLL.KhachHangBLL();
                if (khachHang.Update(kh) == true)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiKhachHang();
                    LoadKH();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHoKhachHangKH.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập đầy đủ thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoKhachHangKH.Focus();
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (cbbMaKhachHangKH.Text != "")
            {
                BLL.KhachHangBLL khachHang = new BLL.KhachHangBLL();
                if (khachHang.Delete(cbbMaKhachHangKH.Text) == true)
                {
                    MessageBox.Show("Xóa thành công khách hàng " + cbbMaKhachHangKH.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiNhanVien();
                    LoadComboboxMaKhachHang();
                    LoadKH();
                }
                else
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin mã khách hàng chưa được nhập!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLamMoiKH_Click(object sender, EventArgs e)
        {
            LamMoiKhachHang();
        }
        private void LoadKH()
        {
            BLL.KhachHangBLL khachHang = new BLL.KhachHangBLL();
            dgvKH.DataSource = khachHang.Load();
        }

        #endregion

        #region Tài Khoản

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            txtUsernameTK.Text = cbbTenNhanVienTK.SelectedValue.ToString();
            if (txtPasswordTK.Text != "" && cbbQuyenHanTK.Text != "")
            {
                BLL.DangNhapBLL taiKhoan = new BLL.DangNhapBLL();
                if (cbbQuyenHanTK.Text == "Admin")
                {
                    if (taiKhoan.Insert(txtUsernameTK.Text, txtPasswordTK.Text, true) == true)
                    {
                        MessageBox.Show("Thêm Tài khoản thành công");
                        LoadTK();
                        LamMoiTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện");
                    }
                }
                else if (cbbQuyenHanTK.Text == "User")
                {
                    if (taiKhoan.Insert(txtUsernameTK.Text, txtPasswordTK.Text, false) == true)
                    {
                        MessageBox.Show("Thêm Tài khoản thành công");
                        LoadTK();
                        LamMoiTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện");
                    }
                }
            }
        }

        private void btnCapNhatTK_Click(object sender, EventArgs e)
        {
            txtUsernameTK.Text = cbbTenNhanVienTK.SelectedValue.ToString();
            DTO.DangNhapDTO dangNhap= null;
            if (cbbQuyenHanTK.Text == "Admin")
            {
                dangNhap = new DTO.DangNhapDTO(txtUsernameTK.Text, txtPasswordTK.Text, true);
            }
            else if(cbbQuyenHanTK.Text == "User")
            {
                dangNhap = new DTO.DangNhapDTO(txtUsernameTK.Text, txtPasswordTK.Text, false);
            }
            if (txtPasswordTK.Text != "" && cbbQuyenHanTK.Text != "")
            {
                BLL.DangNhapBLL taiKhoan = new BLL.DangNhapBLL();
                if (taiKhoan.Update(dangNhap) == true)
                {
                    MessageBox.Show("Cập nhật Tài khoản thành công");
                    LoadTK();
                    LamMoiTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện");
                }
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            txtUsernameTK.Text = cbbTenNhanVienTK.SelectedValue.ToString();
            if (txtUsernameTK.Text != "")
            {
                BLL.DangNhapBLL taiKhoan = new BLL.DangNhapBLL();
                if (taiKhoan.Delete(txtUsernameTK.Text) == true)
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                    LoadTK();
                }
                else
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình thực hiện");
                }
            }
        }
        private void btnLamMoiTK_Click(object sender, EventArgs e)
        {
            LamMoiTaiKhoan();
            LoadTK();
            LoadComboboxTenNhanVien();
        }
        private void LoadTK()
        {
            BLL.DangNhapBLL taiKhoan = new BLL.DangNhapBLL();
            dgvTK.DataSource = taiKhoan.Load();
        }
        #endregion

        #region Sản phẩm
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(txtMaSanPhamSP.Text !="" && txtTenSanPhamSP.Text !="" && txtDonGiaSP.Text !="" && txtMoTaSP.Text !=""  && dtpNgaySanXuatSP.Text !="" && dtpHanSuDungSP.Text !="" &&cbbSoLuongTonKhoSP.Text !="" &&cbbMaNhaCungCapSP.Text!="" &&cbbMaNhaSanXuatSP.Text!="")
            {
                BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
                int soLuong = Int32.Parse(cbbSoLuongTonKhoSP.Text);
                double donGia = Double.Parse(txtDonGiaSP.Text);
                if(sanPham.Insert(txtMaSanPhamSP.Text,txtTenSanPhamSP.Text, soLuong,dtpNgaySanXuatSP.Text,dtpHanSuDungSP.Text, donGia,txtMoTaSP.Text,cbbMaNhaCungCapSP.SelectedValue.ToString(),cbbMaNhaSanXuatSP.SelectedValue.ToString()))
                {
                    MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSP();
                    LamMoiSanPham();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập đầy đủ thông tin sản phẩm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatSP_Click(object sender, EventArgs e)
        {
            if (txtMaSanPhamSP.Text != "" && txtTenSanPhamSP.Text != "" && txtDonGiaSP.Text != "" && txtMoTaSP.Text != "" && dtpNgaySanXuatSP.Text != "" && dtpHanSuDungSP.Text != "" && cbbSoLuongTonKhoSP.Text != "" && cbbMaNhaCungCapSP.Text != "" && cbbMaNhaSanXuatSP.Text != "")
            {
                BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
                int soLuong = Int32.Parse(cbbSoLuongTonKhoSP.Text);
                double donGia = Double.Parse(txtDonGiaSP.Text);
                if (sanPham.Update(txtMaSanPhamSP.Text, txtTenSanPhamSP.Text, soLuong, dtpNgaySanXuatSP.Text, dtpHanSuDungSP.Text, donGia, txtMoTaSP.Text, cbbMaNhaCungCapSP.SelectedValue.ToString(), cbbMaNhaSanXuatSP.SelectedValue.ToString()))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSP();
                    LamMoiSanPham();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập đầy đủ thông tin sản phẩm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if(txtMaSanPhamSP.Text !="")
            {
                BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
                if(sanPham.Delete(txtMaSanPhamSP.Text)==true)
                {
                    MessageBox.Show("Xóa Sản Phẩm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSP();
                    LamMoiSanPham();
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập mã sản phẩm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLamMoiSP_Click(object sender, EventArgs e)
        {
            LamMoiSanPham();
        }
        private void LoadSP()
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            dgvSP.DataSource = sanPham.Load();
            for(int i =0;i<50;i++)
            {
                cbbSoLuongTonKhoSP.Items.Add(i);
            }
        }
        #endregion
    }
}
