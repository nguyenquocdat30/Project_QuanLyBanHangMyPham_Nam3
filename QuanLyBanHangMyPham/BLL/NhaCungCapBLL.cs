using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaCungCapBLL
    {
        public DataTable Load()
        {
            return DAL.NhaCungCapDAL.Instance.Load();
        }
        public bool Update(string maNCC, string tenNCC, string diaChiNCC, string dienThoaiNCC, string emailNCC)
        {
            DTO.NhaCungCapDTO ncc = new DTO.NhaCungCapDTO(maNCC, tenNCC, dienThoaiNCC, diaChiNCC, emailNCC);
            return DAL.NhaCungCapDAL.Instance.Update(ncc);
        }
        public bool Insert(string maNCC, string tenNCC,string diaChiNCC,string dienThoaiNCC,string emailNCC)
        {
            DTO.NhaCungCapDTO ncc = new DTO.NhaCungCapDTO(maNCC, tenNCC, dienThoaiNCC, diaChiNCC, emailNCC);
            return DAL.NhaCungCapDAL.Instance.Insert(ncc);
        }
        public bool Delete(string maNCC)
        {
            return DAL.NhaCungCapDAL.Instance.Delete(maNCC);
        }
        public DataTable LoadCbbManager()
        {
            return DAL.NhaCungCapDAL.Instance.LoadCbbManager();
        }
    }
}
