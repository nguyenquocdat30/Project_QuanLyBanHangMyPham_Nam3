using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        public DataTable Load()
        {
            return DAL.HoaDonDAL.Instance.Load();
        }
        public DataTable LoadHoaDonManager()
        {
            return DAL.HoaDonDAL.Instance.LoadHoaDonManager();
        }
        public bool Update(DTO.HoaDonDTO data)
        {
            return DAL.HoaDonDAL.Instance.Update(data);
        }
        public bool Insert(DTO.HoaDonDTO data)
        {
            return DAL.HoaDonDAL.Instance.Insert(data);
        }
        public bool Delete(DTO.HoaDonDTO data)
        {
            return DAL.HoaDonDAL.Instance.Delete(data);
        }
        public DTO.HoaDonDTO getBill()
        {
            return DAL.HoaDonDAL.Instance.getBill();
        }
    }
}
