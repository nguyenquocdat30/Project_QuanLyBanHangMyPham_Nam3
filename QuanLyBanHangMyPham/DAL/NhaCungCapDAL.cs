using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL
    {
        private static NhaCungCapDAL instance;

        public static NhaCungCapDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NhaCungCapDAL();
                }
                return NhaCungCapDAL.instance;
            }

            private set
            {
                instance = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private NhaCungCapDAL() { }
        public DataTable Load()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC SELECT_NCC");
        }
        public bool Update(DTO.NhaCungCapDTO data)
        {
            string query = string.Format("EXEC UPDATE_NHACUNGCAP '{0}',N'{1}',N'{2}','{3}','{4}'",data.MaCC,data.TenCC,data.DiaChi,data.DienThoai,data.EMail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(DTO.NhaCungCapDTO data)
        {
            string query = string.Format("EXEC INSERT_NCC '{0}',N'{1}',N'{2}','{3}','{4}'",data.MaCC,data.TenCC,data.DiaChi,data.DienThoai,data.EMail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(string maNCC)
        {
            string query = string.Format("EXEC DELETE_NHACUNGCAP '{0}'",maNCC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable LoadCbbManager()
        {
            string query = "SELECT MANCC,TENNCC FROM NHACUNGCAP";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
