using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietHoaDonDAL
    {
        private static ChiTietHoaDonDAL instance;

        public static ChiTietHoaDonDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ChiTietHoaDonDAL();
                }
                return ChiTietHoaDonDAL.instance;
            }

            private set
            {
                instance = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private ChiTietHoaDonDAL() { }
        public DataTable Load(DTO.ChiTietHoaDonDTO data)
        {
            string query = string.Format("");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool Update(DTO.ChiTietHoaDonDTO data)
        {
            string query = "";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(DTO.ChiTietHoaDonDTO data)
        {
            string query = string.Format("EXEC dbo.INSERT_CTHD '{0}', '{1}',{2},{3}",data.MaHD,data.MaSP,data.SoLuong,data.DonGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(DTO.ChiTietHoaDonDTO data)
        {
            string query = "";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
