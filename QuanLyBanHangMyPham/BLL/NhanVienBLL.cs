using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        public DataTable Load()
        {
            return DAL.NhanVienDAL.Instance.Load();
        }
        public bool Update(string maNV, string hoNV, string tenNV, string ngaySinh, bool gioiTinh, string diaChi, string dienThoai, string cmnd, string queQuan, string ngayVaoLam)
        {
            DTO.NhanVienDTO nhanVien = new DTO.NhanVienDTO(maNV, hoNV, tenNV, ngaySinh, gioiTinh, diaChi, dienThoai, cmnd, queQuan, ngayVaoLam);
            return DAL.NhanVienDAL.Instance.Update(nhanVien);
        }
        public bool Insert(string maNV, string hoNV, string tenNV, string ngaySinh, bool gioiTinh, string diaChi, string dienThoai, string cmnd, string queQuan, string ngayVaoLam)
        {
            DTO.NhanVienDTO nhanVien = new DTO.NhanVienDTO(maNV, hoNV, tenNV, ngaySinh, gioiTinh, diaChi, dienThoai, cmnd, queQuan,ngayVaoLam);
            return DAL.NhanVienDAL.Instance.Insert(nhanVien);
        }
        public bool Delete(string maNV)
        {
            return DAL.NhanVienDAL.Instance.Delete(maNV);
        }
        public DTO.NhanVienDTO GetNhanVienByMaNV(string maNV)
        {
            return DAL.NhanVienDAL.Instance.GetNhanVienByMaNV(maNV);
        }
        public DataTable LoadCbbManager()
        {
            return DAL.NhanVienDAL.Instance.LoadCbbManager();
        }
    }
}
