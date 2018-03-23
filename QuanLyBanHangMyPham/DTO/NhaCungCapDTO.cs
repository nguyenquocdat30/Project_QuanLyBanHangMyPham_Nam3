using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        private string maCC;

        public string MaCC
        {
            get { return maCC; }
            set { maCC = value; }
        }

        private string tenCC;

        public string TenCC
        {
            get { return tenCC; }
            set { tenCC = value; }
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

        private string eMail;

        public string EMail
        {
            get { return eMail; }
            set { eMail = value; }
        }

        public NhaCungCapDTO()
        {
            this.maCC = "";
            this.tenCC = "";
            this.diaChi = "";
            this.dienThoai = "";
            this.eMail = "";
        }

        public NhaCungCapDTO(string maCC,string tenCC,string dienThoai,string diaChi,string eMail)
        {
            this.maCC = maCC;
            this.tenCC = tenCC;
            this.dienThoai = dienThoai;
            this.diaChi = diaChi;
            this.eMail = eMail;
        }
        public NhaCungCapDTO(DataRow row)
        {
            this.MaCC = (string)row["MANCC"];
            this.TenCC = (string)row["TENNCC"];
            this.DiaChi = (string)row["DIACHI"];
            this.DienThoai = (string)row["DIENTHOAI"];
            this.EMail = (string)row["EMAIL"];
        }
    }
}
