using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DangNhapDAL
    {
        private static DangNhapDAL instance;

        public static DangNhapDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DangNhapDAL();
                }
                return DangNhapDAL.instance;
            }

            private set
            {
                instance = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private DangNhapDAL() { }
        public DataTable Load()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC LOAD_TAIKHOAN");
        }
        public bool Update(DTO.DangNhapDTO account)
        {
            string query = string.Format("EXEC UPDATE_TAIKHOAN '{0}', '{1}', {2}",account.UserName,account.PassWord,account.QuyenHan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccountUserNameAndPassWord(string userName, string passWord)
        {
            string query = string.Format("EXEC UPDATE_TAIKHOAN_KHONGSUAQUYENHAN '{0}','{1}'", userName, passWord);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(DTO.DangNhapDTO account)
        {
            string query = string.Format("EXEC INSERT_TAIKHOAN '{0}','{1}','{2}'",account.UserName,account.PassWord,account.QuyenHan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(string userName)
        {
            string query = string.Format("EXEC DELETE_TAIKHOAN '{0}'",userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        /// <summary>
        /// hàm kiểm tra đăng nhập
        /// thực hiện một truy vấn với dữ liệu vào từ người dùng
        /// trả về số dòng kết quả sau khi thực hiện truy vấn 
        /// (nếu >0 => có dữ liệu => tài khoản mật khẩu đúng )
        /// </summary>
        /// <returns></returns>
        public bool Login(string userName,string passWord)
        {
            string query = string.Format("EXEC DUYET_TAIKHOAN '{0}','{1}'", userName, passWord);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        public DTO.DangNhapDTO GetAccountByUserName(string userName)
        {
            string query = string.Format("SELECT dbo.DANGNHAP.* FROM dbo.DANGNHAP WHERE USERNAME = '{0}'", userName);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                return new DTO.DangNhapDTO(item);
            }
            return null;
        }
    }
}
