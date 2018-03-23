using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DangNhapDTO
    {
        private string userName;
        private string passWord;
        private bool quyenHan;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public bool QuyenHan
        {
            get
            {
                return quyenHan;
            }

            set
            {
                quyenHan = value;
            }
        }
        public DangNhapDTO()
        {
            this.userName = "";
            this.passWord = "";
            this.quyenHan = false;
        }
        public DangNhapDTO(string userName,string passWord,bool quyenHan)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.quyenHan = quyenHan;
        }
        public DangNhapDTO(DataRow row)
        {
            this.userName = (string)row["USERNAME"];
            this.passWord = (string)row["PASSWORD"];
            this.quyenHan = (bool)row["QUYENHAN"];
        }
    }
}
