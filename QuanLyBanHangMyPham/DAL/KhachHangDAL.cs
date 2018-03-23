using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        private static KhachHangDAL instance;

        public static KhachHangDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new KhachHangDAL();
                }
                return KhachHangDAL.instance;
            }

            private set
            {
                instance = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private KhachHangDAL() { }
        public DataTable Load()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC LOAD_KHACHANG");
        }
        public bool Update(DTO.KhachHangDTO data)
        {
            string query = string.Format("EXEC UPDATE_KHACHHANG '{0}',N'{1}',N'{2}','{3}','{4}',N'{5}','{6}','{7}'",data.MaKH, data.HoKH, data.TenKH, data.NgaySinh, data.GioiTinh, data.DiaChi, data.DienThoai, data.Email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(DTO.KhachHangDTO data)
        {
            string query = string.Format("EXEC dbo.INSERT_KHACHHANG_TUSINHMA N'{0}',N'{1}','{2}',{3},N'{4}','{5}','{6}'",data.HoKH,data.TenKH,data.NgaySinh,data.GioiTinh,data.DiaChi,data.DienThoai,data.Email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(string data)
        {
            string query = string.Format("EXEC DELETE_KHACHHANG '{0}'",data);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DTO.KhachHangDTO getLastCustomer()
        {
            string query = "SELECT TOP 1 MAKH,HOKH,TENKH,CONVERT(VARCHAR(10),NGAYSINH) AS NGAYSINH,GIOITINH,DIACHI,DIENTHOAI,EMAIL FROM dbo.KHACHHANG ORDER BY MAKH DESC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new DTO.KhachHangDTO(item);
            }
            return null;
        }
        public DataTable TimKiemKhachHang(string data)
        {
            string query = string.Format("EXEC TIMKIEM_KHACHHANG N'{0}'", data);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable LoadCbbManager()
        {
            string query = "SELECT MAKH FROM KHACHHANG";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
