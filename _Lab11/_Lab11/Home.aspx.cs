using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _Lab11
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaCB"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            clsConnection.Connect();
            string maCB = Session["MaCB"].ToString();
            txtName.Text = Session["TenCB"].ToString();

            string query = "SELECT DISTINCT GiangDay.MaMon, MonHoc.TenMon, GiangDay.MaLop, Lop.TenLop " +
                       "FROM GiangDay " +
                       "JOIN MonHoc ON GiangDay.MaMon = MonHoc.MaMon " +
                       "JOIN Lop ON GiangDay.MaLop = Lop.MaLop " +
                       "WHERE GiangDay.MaCB = @MaCB";

            SqlDataAdapter da = new SqlDataAdapter(query, clsConnection._connection);
            da.SelectCommand.Parameters.AddWithValue("@MaCB", maCB);
            DataTable dt = new DataTable();
            da.Fill(dt);
            

            tableCourse.DataSource = dt;
            tableCourse.DataBind();
            clsConnection.CloseConnect();
        }

        protected void tableCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}