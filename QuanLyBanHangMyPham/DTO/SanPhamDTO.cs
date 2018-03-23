using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        private string maSP;
        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        private string tenSP;
        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }

        private int soLuongTonKho;
        public int SoLuongTonKho
        {
            get { return soLuongTonKho; }
            set { soLuongTonKho = value; }
        }
        private string ngaySanXuat;
        public string NgaySanXuat
        {
            get { return ngaySanXuat; }
            set { ngaySanXuat = value; }
        }

        private string hanSuDung;
        public string HanSuDung
        {
            get { return hanSuDung; }
            set { hanSuDung = value; }
        }

        private double donGia;
        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private string moTa;
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        private string maCC;
        public string MaCC
        {
            get { return maCC; }
            set { maCC = value; }
        }

        private string maSX;
        public string MaSX
        {
            get { return maSX; }
            set { maSX = value; }
        }

        public SanPhamDTO()
        {
            this.maSP = "";
            this.tenSP = "";
            this.soLuongTonKho = 0;
            this.ngaySanXuat = "";
            this.HanSuDung = "";
            this.donGia = 0;
            this.moTa = "";
            this.maCC = "";
            this.maSX = "";
        }

        public SanPhamDTO(string maSP,string tenSP,int soLuongTonKho, string ngaySanXuat, string hanSuDung, double donGia,string moTa,string maCC,string maSX)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.soLuongTonKho = soLuongTonKho;
            this.ngaySanXuat = ngaySanXuat;
            this.hanSuDung = hanSuDung;
            this.donGia = donGia;
            this.moTa = moTa;
            this.maCC = maCC;
            this.maSX = maSX;
        }
        public SanPhamDTO(DataRow row)
        {
            this.MaSP = (string)row["MASP"];
            this.TenSP = (string)row["TENSP"];
            this.SoLuongTonKho = (int)row["SOLUONGTONKHO"];
            this.NgaySanXuat = (string)row["NGAYSX"];
            this.HanSuDung = (string)row["HANSUDUNG"];
            this.DonGia = (double)row["DONGIA"];
            this.MoTa = (string)row["MOTA"];
            this.MaCC = (string)row["MANCC"];
            this.MaSX = (string)row["MASX"];
        }
    }
}
