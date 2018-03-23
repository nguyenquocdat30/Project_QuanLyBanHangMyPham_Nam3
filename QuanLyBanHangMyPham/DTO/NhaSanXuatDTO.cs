using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaSanXuatDTO
    {
        private string maSX;
        public string MaSX
        {
            get { return maSX; }
            set { maSX = value; }
        }

        private string tenSX;
        public string TenSX
        {
            get { return tenSX; }
            set { tenSX = value; }
        }

        private string quocGia;
        public string QuocGia
        {
            get { return quocGia; }
            set { quocGia = value; }
        }

        public NhaSanXuatDTO()
        {
            this.maSX = "";
            this.tenSX = "";
            this.quocGia = "";
        }

        public NhaSanXuatDTO(string maSX, string tenSX, string quocGia)
        {
            this.maSX = maSX;
            this.tenSX = tenSX;
            this.quocGia = quocGia;
        }
        public NhaSanXuatDTO(DataRow row)
        {
            this.MaSX = (string)row["MASX"];
            this.TenSX = (string)row["TENNSX"];
            this.QuocGia = (string)row["QUOCGIA"];
        }
    }
}
