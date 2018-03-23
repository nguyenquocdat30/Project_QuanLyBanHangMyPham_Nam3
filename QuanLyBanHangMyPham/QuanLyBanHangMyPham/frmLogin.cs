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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Thự Sự Muốn Thoát ?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!= DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            if(Login(userName,passWord))
            {
                BLL.DangNhapBLL acc = new BLL.DangNhapBLL();
                DTO.DangNhapDTO account = acc.GetAccountByUserName(userName);
                frmManager f = new frmManager(account);
                this.Hide();
                f.ShowDialog();
                txtPassWord.Text = "";
                txtPassWord.Focus();
                this.Show();
            }
            else
            {
                if(txtPassWord.Text.Length == 0 || txtUserName.Text.Length ==0)
                {
                    MessageBox.Show("Bạn Chưa Nhập Tài Khoản Hoặc Mật Khẩu !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassWord.Text = "";
                    txtUserName.Text = "";
                    txtUserName.Focus();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Nhập Sai Tài Khoản Hoặc Mật Khẩu !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassWord.Text = "";
                    txtPassWord.Focus();
                }
            }
        }
        private bool Login(string userName,string passWord)
        {
            BLL.DangNhapBLL checkLogin = new BLL.DangNhapBLL();
            return checkLogin.Login(userName, passWord);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
