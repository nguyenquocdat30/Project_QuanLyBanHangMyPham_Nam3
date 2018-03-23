using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        private string maHD;

        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        private string ngayLapHD;

        public string NgayLapHD
        {
            get { return ngayLapHD; }
            set { ngayLapHD = value; }
        }
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string maNV;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        public HoaDonDTO(string maHD, string ngayLapHD, string maKH, string maNV) 
        {
            this.maHD = maHD;
            this.ngayLapHD = ngayLapHD;
            this.maKH = maKH;
            this.maNV = maNV;
        }
        public HoaDonDTO()
        {
            this.maHD = "";
            this.ngayLapHD = "";
            this.maKH = "";
            this.maNV = "";
        }
        public HoaDonDTO(DataRow row)
        {
            this.MaHD = (string)row["MAHOADON"];
            this.NgayLapHD = (string)row["NGAYLAPHOADON"];
            this.MaKH = (string)row["MAKH"];
            this.MaNV = (string)row["MANV"];
        }
    }
}
