using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DangNhapBLL
    {
        public DataTable Load()
        {
            return DAL.DangNhapDAL.Instance.Load();
        }
        public bool Update(DTO.DangNhapDTO data)
        {
            return DAL.DangNhapDAL.Instance.Update(data);
        }
        public bool Insert(string userName,string passWord,bool quyenHan)
        {
            DTO.DangNhapDTO taiKhoan = new DTO.DangNhapDTO(userName, passWord, quyenHan);
            return DAL.DangNhapDAL.Instance.Insert(taiKhoan);
        }
        public bool Delete(string userName)
        {
            return DAL.DangNhapDAL.Instance.Delete(userName);
        }
        public bool Login(string userName,string passWord)
        {
            return DAL.DangNhapDAL.Instance.Login(userName,passWord);
        }
        public DTO.DangNhapDTO GetAccountByUserName(string userName)
        {
            return DAL.DangNhapDAL.Instance.GetAccountByUserName(userName);
        }
        public bool UpdateAccountUserNameAndPassWord(string userName,string passWord)
        {
            return DAL.DangNhapDAL.Instance.UpdateAccountUserNameAndPassWord(userName,passWord);
        }
    }
}
