using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string hoKH;

        public string HoKH
        {
            get { return hoKH; }
            set { hoKH = value; }
        }
        private string tenKH;

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }
        private string ngaySinh;

        public string NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        private bool gioiTinh;

        public bool GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string dienThoai;

        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public KhachHangDTO(string maKH, string hoKH, string tenKH, string ngaySinh, bool gioiTinh, string diaChi, string dienThoai, string email) 
        {
            this.maKH = maKH;
            this.hoKH = hoKH;
            this.tenKH = tenKH;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.email = email;
        }
        public KhachHangDTO()
        {
            this.maKH = "";
            this.hoKH = "";
            this.tenKH = "";
            this.ngaySinh = "";
            this.gioiTinh = true;
            this.diaChi = "";
            this.dienThoai = "";
            this.email = "";
        }
        public KhachHangDTO(DataRow row)
        {
            this.MaKH = (string)row["MAKH"];
            this.HoKH = (string)row["HOKH"];
            this.TenKH = (string)row["TENKH"];
            this.NgaySinh = (string)row["NGAYSINH"];
            this.GioiTinh = (bool)row["GIOITINH"];
            this.DiaChi = (string)row["DIACHI"];
            this.DienThoai = (string)row["DIENTHOAI"];
            this.Email = (string)row["DIENTHOAI"];
        }
    }
}
