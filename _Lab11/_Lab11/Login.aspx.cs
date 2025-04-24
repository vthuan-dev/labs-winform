using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _Lab11
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                clsConnection.Connect();
                string MCB = txtMCB.Text;
                string Password = txtPass.Text;
                string query = "SELECT TenCanBo from CanBo where MaCB = @MaCB and MatKhau = @MatKhau";

                SqlCommand sql = new SqlCommand(query, clsConnection._connection);

                sql.Parameters.AddWithValue("@MaCB", MCB);
                sql.Parameters.AddWithValue("@MatKhau", Password);

                object result = sql.ExecuteScalar();

                if (result != null)
                {

                    Session["MaCB"] = MCB;
                    Session["TenCB"] = result.ToString();
                    clsConnection.CloseConnect();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    txtMessage.Text = "Mã cán bộ hoặc mật khẩu sai!! ";
                    clsConnection.CloseConnect();
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}