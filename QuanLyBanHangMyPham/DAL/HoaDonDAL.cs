using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        private static HoaDonDAL instance;
        public static HoaDonDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new HoaDonDAL();
                }
                return HoaDonDAL.instance;
            }

            private set
            {
                instance = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private HoaDonDAL() { }
        public DataTable Load()
        {
            return DataProvider.Instance.ExecuteQuery("");
        }
        public DataTable LoadHoaDonManager()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC LOAD_HOADON");
        }
        public bool Update(DTO.HoaDonDTO data)
        {
            string query = "";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(DTO.HoaDonDTO data)
        {
            string query = string.Format("EXEC dbo.INSERT_HOADON_TUSINHMA '{0}', '{1}', '{2}'",data.NgayLapHD,data.MaKH,data.MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(DTO.HoaDonDTO data)
        {
            string query = "";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DTO.HoaDonDTO getBill()
        {
            string query = "SELECT TOP 1 MAHOADON,CONVERT(VARCHAR(10),NGAYLAPHOADON) AS NGAYLAPHOADON,MAKH,MANV FROM dbo.HOADON ORDER BY MAHOADON DESC";
            DataTable data = DAL.DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                return new DTO.HoaDonDTO(item);
            }
            return null;
        }
    }
}
