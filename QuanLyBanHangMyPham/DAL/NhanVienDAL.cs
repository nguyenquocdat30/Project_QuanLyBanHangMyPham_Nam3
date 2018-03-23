using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        private static NhanVienDAL instance;

        public static NhanVienDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NhanVienDAL();
                }
                return NhanVienDAL.instance;
            }

            private set
            {
                instance = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private NhanVienDAL() { }
        public DataTable Load()
        {
            
            return DataProvider.Instance.ExecuteQuery("EXEC LOAD_NHANVIEN");
        }
        public bool Update(DTO.NhanVienDTO data)
        {
            string query = string.Format("EXEC UPDATE_NHANVIEN '{0}',N'{1}',N'{2}','{3}',{4},N'{5}','{6}','{7}',N'{8}','{9}'", data.MaNhanVien,data.HoNV,data.TenNV,data.NgaySinh,data.GioiTinh,data.DiaChi,data.DienThoai,data.Cmnd,data.QueQuan,data.NgayVaoLam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(DTO.NhanVienDTO data)
        {
            string query = string.Format("EXEC dbo.INSERT_NHANVIEN '{0}', N'{1}', N'{2}', '{3}',{4}, N'{5}', '{6}', '{7}', N'{8}', '{9}'",data.MaNhanVien,data.HoNV,data.TenNV,data.NgaySinh,data.GioiTinh,data.DiaChi,data.DienThoai,data.Cmnd,data.QueQuan,data.NgayVaoLam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(string data)
        {
            string query = string.Format("EXEC DELETE_NHANVIEN '{0}'",data);
            string query2 = string.Format("DELETE_DANGNHAP '{0}'", data);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            int result2 = DataProvider.Instance.ExecuteNonQuery(query2);
            if(result > 0 || result2 >0)
            {
                return true;
            }
            return false;
        }
        public DTO.NhanVienDTO GetNhanVienByMaNV(string data)
        {
            string query = string.Format("SELECT MANV,HONV,TENNV,CONVERT(VARCHAR(10),NGAYSINH)AS NGAYSINH,GIOITINH,DIACHI,DIENTHOAI,CMND,QUEQUAN,CONVERT(VARCHAR(10),NGAYVAOLAM) AS NGAYVAOLAM FROM dbo.NHANVIEN WHERE MANV = '{0}'", data);
            DataTable temp = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in temp.Rows)
            {
                return new DTO.NhanVienDTO(item);
            }
            return null;
        }
        public DataTable LoadCbbManager()
        {
            string query = "SELECT MANV,HONV +' '+ TENNV AS 'HOTENNV' FROM NHANVIEN";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
