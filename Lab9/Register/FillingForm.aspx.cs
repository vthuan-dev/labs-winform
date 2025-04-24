using Lab9;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Register
{
    public partial class FillingForm : System.Web.UI.Page
    {
        private int GetID()
        {
            int id;
            try
            {
                clsDatabase.OpenConnection();

                string str = "Select Max(MaKH) From KhachHang";
                SqlCommand com = new SqlCommand(str, clsDatabase.conn);
                id = Convert.ToInt32(com.ExecuteScalar());
                clsDatabase.CloseConnection();
            }
            catch (Exception)
            {
                id = 0;
            }
            id++;

            return id;
        }

        private void InsertKhachHang()
        {
            try
            {
                clsDatabase.OpenConnection();
                string insert_str = "Insert Into KhachHang Values (@MaKH, @TenDN, @MatKhau, @HoTen, " +
                            "@NgaySinh, @GioiTinh, @Email, @ThuNhap)";
                SqlCommand com = new SqlCommand(insert_str, clsDatabase.conn);

                List<SqlParameter> sqlParameters = new List<SqlParameter>()
                    {
                        new SqlParameter("@MaKH", GetID()),
                        new SqlParameter("@TenDN", txtTenDN.Text),
                        new SqlParameter("@MatKhau", txtMK.Text),
                        new SqlParameter("@HoTen", txtKH.Text),
                        new SqlParameter("@NgaySinh", txtNgaySinh.Text),
                        new SqlParameter("@GioiTinh", radNam.Checked),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@ThuNhap", txtThuNhap.Text),
                    };
                com.Parameters.AddRange(sqlParameters.ToArray());
                com.ExecuteNonQuery();
                clsDatabase.CloseConnection();
            } catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;
            }
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {            
            if (Page.IsValid)
            {
                try
                {
                    InsertKhachHang();
                    lblThongBao.Text = "Đăng ký thành công";
                }
                catch (Exception ex)
                {
                    lblThongBao.Text = ex.Message;
                }

            }
        }
    }
}