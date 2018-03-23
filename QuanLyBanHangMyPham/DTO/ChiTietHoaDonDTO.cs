using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        private string maHD;

        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        private string maSP;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private double donGia;

        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }


        public ChiTietHoaDonDTO(string maHD, string maSP, int soLuong, double donGia)
        {
            this.maHD = maHD;
            this.maSP = maSP;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }
        public ChiTietHoaDonDTO()
        {
            this.maHD = "";
            this.maSP = "";
            this.soLuong = 0;
            this.donGia = 0;
        }
        public ChiTietHoaDonDTO(DataRow row)
        {
            this.MaHD = (string)row["MAHOADON"];
            this.MaSP = (string)row["MASP"];
            this.SoLuong = (int)row["SOLUONGSP"];
            this.DonGia = (double)row["DONGIA"];
        }
    }
}
