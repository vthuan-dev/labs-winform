using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6Ex1
{
    class clsDatabase
    {
        public static SqlConnection con;
        public static bool OpenConnection()
        {
            try
            {
                con = new SqlConnection("Server=DESKTOP-03C08VS; Database=DVDLibrary; Integrated Security=True;");
                con.Open();
                MessageBox.Show("Kết nối thành công");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối đến CSDL rùi bạn ui : " + ex.Message);
                return false;
            }
            return true;
        }

        public static bool CloseConnection()
        {
            try
            {
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
