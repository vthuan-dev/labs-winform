using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab08_prjSinhVien
{
    public partial class frmDangNhap : Form
    {
        public static clsCanBo mCanBoOrigin;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            mCanBoOrigin = null;
            if (!clsConnectDB.OpenConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlCommand com = new SqlCommand("select distinct * from CanBo where MaCB=@mscb and MatkhauCB=@mkcb", clsConnectDB.con);
                
                SqlParameter p1 = new SqlParameter("@mscb", SqlDbType.NVarChar);
                p1.Value = txtUsername.Text;
                SqlParameter p2 = new SqlParameter("@mkcb", SqlDbType.NVarChar);
                p2.Value = txtPasswd.Text;
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string mscb = reader.GetString(0);
                            string hotencb = reader.GetString(1); 
                            string mkcb = reader.GetString(2);
                            mCanBoOrigin = new clsCanBo(mscb, hotencb, mkcb);
                        }
                    }
                }
                if (mCanBoOrigin != null)
                {
                    this.Hide();
                    frmTrangCanBo newfr = new frmTrangCanBo();
                    newfr.ShowDialog();
                    this.Show();
                    txtUsername.Clear();
                    txtPasswd.Clear();
                    txtUsername.Focus();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không đúng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clsConnectDB.CloseConnection();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
