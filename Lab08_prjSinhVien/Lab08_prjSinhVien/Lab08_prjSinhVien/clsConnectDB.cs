using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab08_prjSinhVien
{
    internal class clsConnectDB
    {
        public static SqlConnection con;
        private static string connectionString = "Server=HXPDONG; Database=SinhVien;uid=mylogin;pwd=mylogin;Integrated Security=True;";

        public static bool OpenConnection()
        {
            try
            {
                if (con == null)
                {
                    con = new SqlConnection(connectionString);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Database Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool CloseConnection()
        {
            try
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đóng kết nối: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
