using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaSanXuatDAL
    {
        private static NhaSanXuatDAL instance;

        public static NhaSanXuatDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NhaSanXuatDAL();
                }
                return NhaSanXuatDAL.instance;
            }

            private set
            {
                instance = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private NhaSanXuatDAL() { }
        public DataTable Load()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC LOAD_NSX");
        }
        public bool Update(DTO.NhaSanXuatDTO data)
        {
            string query = string.Format("UPDATE_NSX '{0}',N'{1}',N'{2}'",data.MaSX,data.TenSX,data.QuocGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(DTO.NhaSanXuatDTO data)
        {
            string query = string.Format("INSERT_NSX '{0}',N'{1}',N'{2}'",data.MaSX,data.TenSX,data.QuocGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(string maNSX)
        {
            string query = string.Format("EXEC DELETE_NSX '{0}' ",maNSX);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable LoadCbbManager()
        {
            string query = "SELECT MASX,TENNSX FROM NHASANXUAT";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
