using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student
{
    public partial class wfrStudent : System.Web.UI.Page
    {
        private DataTable dt = new DataTable();

        protected void LoadData()
        {
            try
            {
                clsDatabase.OpenConnection();

                string str = "Select MaSV, TenSV, Phai, Lop From SinhVien";
                SqlDataAdapter da = new SqlDataAdapter(str, clsDatabase.conn);
                da.Fill(dt);
                grvStudent.DataSource = dt;
                grvStudent.DataBind();

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

        protected void grvStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {            
            grvStudent.PageIndex = e.NewPageIndex;            
            LoadData();

            // Reset index
            grvStudent.SelectedIndex = -1;            
            
        }

        protected void grvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvStudent.EditIndex = e.NewEditIndex;
            LoadData();

            //Change selected index
            grvStudent.SelectedIndex = e.NewEditIndex;           
            

        }

        protected void grvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string MaSV = grvStudent.DataKeys[e.RowIndex].Value.ToString();           
            try
            {
                clsDatabase.OpenConnection();

                string update_str = "Update SinhVien Set TenSV = @TenSV, Phai = @Phai, Lop = @Lop Where MaSV = @MaSV";
                SqlCommand com = new SqlCommand(update_str, clsDatabase.conn);
                List<SqlParameter> list_prm = new List<SqlParameter>()
                {
                    new SqlParameter("@TenSV", e.NewValues["TenSV"]),
                    new SqlParameter("@Phai", e.NewValues["Phai"]),
                    new SqlParameter("@Lop", e.NewValues["Lop"]),
                    new SqlParameter("@MaSV", MaSV)
                };                
                com.Parameters.AddRange(list_prm.ToArray());
                com.ExecuteNonQuery();

                clsDatabase.CloseConnection();

                grvStudent.EditIndex = -1;
                LoadData();
            }
            catch (Exception ex) {
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void grvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvStudent.EditIndex = -1;
            LoadData();
        }

        protected void grvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string MaSV = grvStudent.DataKeys[e.RowIndex].Value.ToString();
            try
            {
                clsDatabase.OpenConnection();

                string update_str = "Delete from SinhVien Where MaSV = @MaSV";
                SqlCommand com = new SqlCommand(update_str, clsDatabase.conn);
                SqlParameter p = new SqlParameter("@MaSV", MaSV);
                com.Parameters.Add(p);
                com.ExecuteNonQuery();

                clsDatabase.CloseConnection();

                LoadData();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void grvStudent_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grvStudent.SelectedIndex = e.NewSelectedIndex;            
        }        
    }
}