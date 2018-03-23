using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        /// <summary>
        /// Singleton để tạo duy nhất 1 thể hiện của lớp 
        /// </summary>
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataProvider();
                }
                return DataProvider.instance;
            }

            private set
            {
                DataProvider.instance = value;
            }
        }
        private string connectionSTR = @"Data Source=.\;Initial Catalog=QUANLYBANHANGMYPHAM;Integrated Security=True";
        /// <summary>
        /// Constructor
        /// </summary>
        private DataProvider() { }
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            try
            {
                SqlConnection connection = new SqlConnection(connectionSTR);
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                sqlAdapter.Fill(data);
                connection.Close();
            }
            catch {}
            return data;
        }
        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            try
            {
                SqlConnection connection = new SqlConnection(connectionSTR);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                data = cmd.ExecuteNonQuery();
                connection.Close();
                
            }
            catch
            {}
            return data;
        }
    }
}
