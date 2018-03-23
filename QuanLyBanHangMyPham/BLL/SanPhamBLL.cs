using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBLL
    {
        public DataTable Load()
        {
            return DAL.SanPhamDAL.Instance.Load();
        }
        public bool Update(string maSp, string tenSP, int soLuong, string ngaySX, string hanSD, double donGia, string moTa, string maNCC, string maNSX)
        {
            DTO.SanPhamDTO sanPham = new DTO.SanPhamDTO(maSp,tenSP,soLuong,ngaySX,hanSD,donGia,moTa,maNCC,maNSX);
            return DAL.SanPhamDAL.Instance.Update(sanPham);
        }
        public bool Insert(string maSp,string tenSP,int soLuong,string ngaySX,string hanSD,double donGia,string moTa,string maNCC,string maNSX)
        {
            DTO.SanPhamDTO sanPham = new DTO.SanPhamDTO(maSp, tenSP, soLuong, ngaySX, hanSD, donGia, moTa, maNCC, maNSX);
            return DAL.SanPhamDAL.Instance.Insert(sanPham);
        }
        public bool Delete(string maSP)
        {
            return DAL.SanPhamDAL.Instance.Delete(maSP);
        }
        public DataTable LoadCbbManager()
        {
            return DAL.SanPhamDAL.Instance.LoadCbbManager();
        }
        public DataTable TimKiemSanPham(string data)
        {
            return DAL.SanPhamDAL.Instance.TimKiemSanPham(data);
        }
        public DataTable TimKiemSanPhamTonKho(string data)
        {
            return DAL.SanPhamDAL.Instance.TimKiemSanPhamTonKho(data);
        }
        public DataTable LoadSanPhamTonKho()
        {
            return DAL.SanPhamDAL.Instance.LoadSanPhamTonKho();
        }
    }
}
