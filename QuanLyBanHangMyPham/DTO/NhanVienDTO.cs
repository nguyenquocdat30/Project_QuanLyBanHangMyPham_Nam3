using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        private string hoNV;
        public string HoNV
        {
            get { return hoNV; }
            set { hoNV = value; }
        }

        private string tenNV;
        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
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
        public string  DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }

        private string cmnd;
        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        private string queQuan;
        public string QueQuan
        {
            get { return queQuan; }
            set { queQuan = value; }
        }

        private string ngayVaoLam;
        public string NgayVaoLam
        {
            get { return ngayVaoLam; }
            set { ngayVaoLam = value; }
        }

        public NhanVienDTO()
        { 
            this.maNhanVien = "";
            this.hoNV = "";
            this.tenNV = "";
            this.ngaySinh ="";
            this.gioiTinh = true;
            this.diaChi = "";
            this.dienThoai = "";
            this.cmnd = "";
            this.queQuan = "";
            this.ngayVaoLam = "";

        }
        public NhanVienDTO(string maNV,string hoNV,string tenNV, string ngaySinh,bool gioiTinh,string diaChi,string sdt,string cmnd,string queQuan, string ngayVaoLam)
        {
            this.maNhanVien = maNV;
            this.hoNV = hoNV;
            this.tenNV = tenNV;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.dienThoai = sdt;
            this.cmnd = cmnd;
            this.queQuan = queQuan;
            this.ngayVaoLam = ngayVaoLam;
        }
        public NhanVienDTO(DataRow row)
        {
            this.MaNhanVien = (string)row["MANV"];
            this.HoNV = (string)row["HONV"];
            this.TenNV = (string)row["TENNV"];
            this.NgaySinh = (string)row["NGAYSINH"];
            this.GioiTinh = (bool)row["GIOITINH"];
            this.DiaChi = (string)row["DIACHI"];
            this.DienThoai = (string)row["DIENTHOAI"];
            this.Cmnd = (string)row["CMND"];
            this.QueQuan = (string)row["QUEQUAN"];
            this.NgayVaoLam = (string)row["NGAYVAOLAM"];
        }
    }
}
