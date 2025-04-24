using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _Lab11.Properties
{
    public partial class DanhSachSinhVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudentData();
            }
            
        }
        protected void LoadStudentData()
        {
            string MaLop = Request.QueryString["MaLop"];
            string MaMon = Request.QueryString["MaMon"];

         
            txtDisplay.Text = $"Môn: {MaMon}, Lớp: {MaLop}";
            clsConnection.Connect();
            //ISNULL(dt.Diem, 0) => chọn cột điểm của điểm thi nhưng nếu null thì ghi 0
            string query = "SELECT SinhVien.MSSV, SinhVien.HoTen, ISNULL(DiemThi.Diem, 0) " +
                "AS Diem FROM SinhVien " +
                "LEFT JOIN DiemThi ON SinhVien.MSSV = DiemThi.MSSV " +
                "AND DiemThi.MaMon = @MaMon WHERE SinhVien.MaLop = @MaLop;";

            SqlDataAdapter da = new SqlDataAdapter(query, clsConnection._connection);
            da.SelectCommand.Parameters.AddWithValue("@MaMon", MaMon);
            da.SelectCommand.Parameters.AddWithValue("@MaLop", MaLop);
            DataTable dt = new DataTable();
            da.Fill(dt);

            StudentList.DataSource = dt;
            StudentList.DataBind();
        }
        protected void StudentList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void StudentList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //e.RowIndex: Chỉ số của dòng đang được chỉnh sửa.
            GridViewRow row = StudentList.Rows[e.RowIndex];
            //Lấy MSSV của sinh viên (lưu trong DataKeyNames)
            string MSSV = StudentList.DataKeys[e.RowIndex].Value.ToString();

            string MaMon = Request.QueryString["MaMon"];
            TextBox txtDiem = (TextBox)row.FindControl("txtDiem");

            if (txtDiem == null)
            {
                return; 
            }
            float Diem;
            if (!float.TryParse(txtDiem.Text, out Diem))
            {
                return; 
            }

            string query = @"
            IF EXISTS (SELECT 1 FROM DiemThi WHERE MSSV = @MSSV AND MaMon = @MaMon)
                UPDATE DiemThi SET Diem = @Diem WHERE MSSV = @MSSV AND MaMon = @MaMon
            ELSE
                INSERT INTO DiemThi (MSSV, MaMon, Diem) VALUES (@MSSV, @MaMon, @Diem)";
            clsConnection.Connect();
            SqlCommand sql = new SqlCommand(query, clsConnection._connection);
            sql.Parameters.AddWithValue("@MSSV", MSSV);
            sql.Parameters.AddWithValue("@MaMon", MaMon);
            sql.Parameters.AddWithValue("@Diem", Diem);
            
            sql.ExecuteNonQuery();
            clsConnection.CloseConnect();
            StudentList.EditIndex = -1;

            LoadStudentData();
        }

        protected void StudentList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            StudentList.EditIndex = e.NewEditIndex;
            LoadStudentData();
        }

        protected void StudentList_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            
        }

        protected void StudentList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            StudentList.EditIndex = -1;
            LoadStudentData();
        }
    }
}