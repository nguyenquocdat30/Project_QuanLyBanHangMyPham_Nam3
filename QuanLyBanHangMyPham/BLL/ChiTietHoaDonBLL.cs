using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietHoaDonBLL
    {
        public DataTable Load(DTO.ChiTietHoaDonDTO data)
        {
            return DAL.ChiTietHoaDonDAL.Instance.Load(data);
        }
        public bool Update(DTO.ChiTietHoaDonDTO data)
        {
            return DAL.ChiTietHoaDonDAL.Instance.Update(data);
        }
        public bool Insert(DTO.ChiTietHoaDonDTO data)
        {
            return DAL.ChiTietHoaDonDAL.Instance.Insert(data);
        }
        public bool Delete(DTO.ChiTietHoaDonDTO data)
        {
            return DAL.ChiTietHoaDonDAL.Instance.Delete(data);
        }
    }
}
