using Lab9;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Register
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void LoadData()
        {
            try
            {
                clsDatabase.OpenConnection();

                string str = "Select MaKH, TenDN, HoTen, NgaySinh, GioiTinh, Email From KhachHang";
                SqlDataAdapter da = new SqlDataAdapter(str, clsDatabase.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grvCustomerList.DataSource = dt;
                grvCustomerList.DataBind();

                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void grvCustomerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCustomerList.PageIndex = e.NewPageIndex;
            LoadData();
            grvCustomerList.SelectedIndex = -1;
        }
        

        protected void grvCustomerList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvCustomerList.EditIndex = e.NewEditIndex;
            LoadData();
            grvCustomerList.SelectedIndex = e.NewEditIndex;
        }

        protected void grvCustomerList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int maKH = Convert.ToInt32(grvCustomerList.DataKeys[e.RowIndex].Value.ToString());
            try
            {
                clsDatabase.OpenConnection();

                string update_str = "Update KhachHang Set HoTen = @HoTen, " +
                    "NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, Email = @Email Where MaKH = @MaKH";
                SqlCommand sqlCommand = new SqlCommand(update_str, clsDatabase.conn);
                List<SqlParameter> list_prm = new List<SqlParameter>()
                {
                    new SqlParameter("@HoTen", e.NewValues["HoTen"]),
                    new SqlParameter("@NgaySinh", e.NewValues["NgaySinh"]),
                    new SqlParameter("@GioiTinh", e.NewValues["GioiTinh"]),
                    new SqlParameter("@Email", e.NewValues["Email"]),
                    new SqlParameter("@MaKH", maKH),
                };
                sqlCommand.Parameters.AddRange(list_prm.ToArray());
                sqlCommand.ExecuteNonQuery();                

                grvCustomerList.EditIndex = -1;
                LoadData();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Cập nhật thành công!')", true);

                clsDatabase.CloseConnection();
            }
            catch (Exception ex) 
            { 
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void grvCustomerList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvCustomerList.EditIndex = -1;
            LoadData();
        }

        protected void grvCustomerList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int maKH = Convert.ToInt32(grvCustomerList.DataKeys[e.RowIndex].Value.ToString());
            try
            {
                clsDatabase.OpenConnection();

                string delete_str = "Delete From KhachHang Where MaKH = @MaKH";
                SqlCommand sqlCommand = new SqlCommand(delete_str, clsDatabase.conn);
                SqlParameter prm = new SqlParameter("@MaKH", maKH);                
                sqlCommand.Parameters.Add(prm);
                sqlCommand.ExecuteNonQuery();

                grvCustomerList.EditIndex = -1;
                LoadData();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Cập nhật thành công!')", true);

                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
    }
}