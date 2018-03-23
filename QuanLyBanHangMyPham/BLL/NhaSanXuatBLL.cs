using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaSanXuatBLL
    {
        public DataTable Load()
        {
            return DAL.NhaSanXuatDAL.Instance.Load();
        }
        public bool Update(string maNSX, string tenNSX,string quocGia)
        {
            DTO.NhaSanXuatDTO nsx = new DTO.NhaSanXuatDTO(maNSX, tenNSX, quocGia);
            return DAL.NhaSanXuatDAL.Instance.Update(nsx);
        }
        public bool Insert(string maNSX,string tenNSX,string quocGia)
        {
            DTO.NhaSanXuatDTO nhaSX = new DTO.NhaSanXuatDTO(maNSX,tenNSX,quocGia);
            return DAL.NhaSanXuatDAL.Instance.Insert(nhaSX);
        }
        public bool Delete(string maNSX)
        {
            return DAL.NhaSanXuatDAL.Instance.Delete(maNSX);
        }
        public DataTable LoadCbbManager()
        {
            return DAL.NhaSanXuatDAL.Instance.LoadCbbManager();
        }
    }
}
