using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Lab6Ex2
{
    class clsDatabase{
        public static SqlConnection con;

        public static bool OpenConnection()
        {
            try
            {
                con = new SqlConnection("Server=DESKTOP-3C4VGSH; Database=QLCB; Integrated Security=True;");
                con.Open();
            }
            catch(Exception)
            {
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
            catch (Exception) {
                return false;
            }
            return true;
        }
    }

}
