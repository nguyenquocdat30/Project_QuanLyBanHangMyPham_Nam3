using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangBLL
    {
        public DataTable Load()
        {
            return DAL.KhachHangDAL.Instance.Load();
        }
        public bool Update(DTO.KhachHangDTO data)
        {
            return DAL.KhachHangDAL.Instance.Update(data);
        }
        public bool Insert(DTO.KhachHangDTO data)
        {
            return DAL.KhachHangDAL.Instance.Insert(data);
        }
        public bool Delete(string maKH)
        {
            return DAL.KhachHangDAL.Instance.Delete(maKH);
        }
        // lấy khách hàng cuối cùng - đồng nghĩa với việc khách hàng vừa thêm để lập hóa đơn
        public DTO.KhachHangDTO getLastCustomer()
        {
            return DAL.KhachHangDAL.Instance.getLastCustomer();
        }
        public DataTable TimKiemKhachHang(string data)
        {
            return DAL.KhachHangDAL.Instance.TimKiemKhachHang(data);
        }
        public DataTable LoadCbbManager()
        {
            return DAL.KhachHangDAL.Instance.LoadCbbManager();
        }
    }
}
