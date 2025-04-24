using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _Lab11
{
    public class clsConnection
    {
        public static SqlConnection _connection;

        public static bool Connect()
        {
            try
            {
                string connectionString = "Server=DESKTOP-PK93L7G\\SQLEXPRESS;Database=SinhVien;Integrated Security=True;";

                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool CloseConnect() {
            try
            {
                _connection.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }
    }
}