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

namespace Lab6Ex2
{
    public partial class frmCanBo : Form
    {
        public frmCanBo()
        {
            InitializeComponent();
        }

        int staffId;
        int staffType;
        
        private void frmCanBo_Load(object sender, EventArgs e)
        {
            try
            {
                clsDatabase.OpenConnection();

                SqlCommand com = new SqlCommand("Select * from ChucVu", clsDatabase.con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                cboCV.DataSource = dt;               
                cboCV.ValueMember = "MaCV";           
                cboCV.DisplayMember = "TenCV";        

                clsDatabase.CloseConnection();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            clsDatabase.OpenConnection();
            SqlCommand com = new SqlCommand("Select Max(MaCB) from CanBo", clsDatabase.con);
            staffId = Convert.ToInt32(com.ExecuteScalar());
            clsDatabase.CloseConnection();
            }
            catch(Exception)
            {
                staffId = 0;
            }
            staffId++;
            ResetFields(true);
            txtID.Text = staffId.ToString();
        }   

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            string strInsert = "Insert into CanBo Values (@MaCB, @TenCb, @ChucVuCB, @SoGioGiang, @DonGia)";
            clsDatabase.OpenConnection();
            SqlCommand com = new SqlCommand(strInsert, clsDatabase.con);

            SqlParameter p1 = new SqlParameter("@MaCB", SqlDbType.Int);
            p1.Value = staffId;
            SqlParameter p2 = new SqlParameter("@TenCB", SqlDbType.NVarChar);
            p2.Value = txtName.Text;
            SqlParameter p3 = new SqlParameter("@ChucVuCB", SqlDbType.Int);
            p3.Value = staffType;
            SqlParameter p4 = new SqlParameter("@SoGioGiang", SqlDbType.Int);
            p4.Value = Convert.ToInt32(txtHour.Text);
            SqlParameter p5 = new SqlParameter("@DonGia", SqlDbType.Money);
            p5.Value = Convert.ToDecimal(txtSalary.Text);

            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            com.ExecuteNonQuery();

            MessageBox.Show("Added successfully!");
            clsDatabase.CloseConnection();
            ResetFields(false);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ResetFields(false);
            Application.Exit(); 
        }

        private void cboCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCV.SelectedIndex == -1) return;

            DataRowView selectedRow = (DataRowView)cboCV.SelectedItem;

            staffType = Convert.ToInt32(selectedRow["MaCV"]);
        }

        void ResetFields(bool status)
        {
            txtID.Clear();
            txtName.Clear();
            cboCV.SelectedIndex = -1;
            txtSalary.Clear();
            txtHour.Clear();
            btnAdd.Enabled = !status;
            btnSave.Enabled = status;
            btnClose.Enabled = status;
            txtName.Focus();
        }
    }
}
