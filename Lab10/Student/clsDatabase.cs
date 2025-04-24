using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Student
{
    public class clsDatabase
    {
        public static SqlConnection conn;

        public static bool OpenConnection()
        {
            try
            {
                string connString = "Server=localhost;Database=QLSV;uid=mylogin;pwd=mylogin;TrustServerCertificate=True";
                conn = new SqlConnection(connString);
                conn.Open();
            }
            catch (Exception) {
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