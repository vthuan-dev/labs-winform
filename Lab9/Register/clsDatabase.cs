using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class clsDatabase
    {
        public static SqlConnection conn;

        public static bool OpenConnection()
        {
            try
            {
                string str = "Server=localhost;Database=QLKhachHang;uid=mylogin;pwd=mylogin;TrustServerCertificate=True";
                conn = new SqlConnection(str);
                conn.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool CloseConnection()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
