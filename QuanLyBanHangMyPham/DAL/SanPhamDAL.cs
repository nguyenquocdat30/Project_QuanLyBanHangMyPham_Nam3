using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL
    {
        private static SanPhamDAL instance;

        public static SanPhamDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SanPhamDAL();
                }
                return SanPhamDAL.instance;
            }

            private set
            {
                instance = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private SanPhamDAL() { }
        public DataTable Load()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC LOAD_SANPHAM");
        }
        public bool Update(DTO.SanPhamDTO data)
        {
            string query = string.Format("EXEC dbo.UPDATE_SANPHAM '{0}', N'{1}', {2}, '{3}', '{4}', {5}, N'{6}', '{7}', '{8}'", data.MaSP, data.TenSP, data.SoLuongTonKho, data.NgaySanXuat, data.HanSuDung, data.DonGia, data.MoTa, data.MaCC, data.MaSX);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(DTO.SanPhamDTO data)
        {
            string query = string.Format("EXEC dbo.INSERT_SP '{0}', N'{1}', {2}, '{3}', '{4}', {5}, N'{6}', '{7}', '{8}'", data.MaSP, data.TenSP, data.SoLuongTonKho, data.NgaySanXuat, data.HanSuDung, data.DonGia, data.MoTa, data.MaCC, data.MaSX);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(string maSP)
        {
            string query = string.Format("DELETE_SANPHAM '{0}'",maSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable LoadCbbManager()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MASP,TENSP FROM SANPHAM");
        }
        public DataTable TimKiemSanPham(string data)
        {
            string query = string.Format("EXEC TIMKIEM_SANPHAM N'{0}'",data);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable TimKiemSanPhamTonKho(string data)
        {
            string query = string.Format("EXEC TIMKIEM_SANPHANTONKHO N'{0}'", data);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable LoadSanPhamTonKho()
        {
            string query = "LOAD_SANPHANTONKHO";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
