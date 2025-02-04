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

namespace Lab6Ex1
{
    public partial class frmDVDCatalog : Form
    {
        public frmDVDCatalog()
        {
            InitializeComponent();
        }
        int CodeNo;
        decimal price;
        string language;
        int subTitle;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                clsDatabase.OpenConnection();
                SqlCommand com = new SqlCommand("Select Max(DVDCodeNo) From Library", clsDatabase.con);
                CodeNo = Convert.ToInt32(com.ExecuteScalar());
                clsDatabase.CloseConnection();
            }
            catch (Exception) {
                CodeNo = 0;
            }
            CodeNo++;
            ResetFields(true);
            txtNo.Text = CodeNo.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strInsert = "Insert into DVDLibrary Values (@DVDNo, @DVDTitle, @DVDLang, @SubTitle, @Price)";
                clsDatabase.OpenConnection();
                SqlCommand com = new SqlCommand(strInsert, clsDatabase.con);

                SqlParameter p1 = new SqlParameter("@DVDNo", SqlDbType.Int);
                p1.Value = CodeNo;
                SqlParameter p2 = new SqlParameter("@DVDTitle", SqlDbType.NVarChar);
                p2.Value = txtTitle.Text;
                SqlParameter p3 = new SqlParameter("@DVDLang", SqlDbType.NVarChar);
                p3.Value = language;
                SqlParameter p4 = new SqlParameter("@SubTitle", SqlDbType.Bit);
                p4.Value = radYes.Checked;
                SqlParameter p5 = new SqlParameter("@Price", SqlDbType.Money);
                p5.Value = price;

                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.Parameters.Add(p4);
                com.Parameters.Add(p5);
                com.ExecuteNonQuery();

                MessageBox.Show("Insert successfully!!");
                clsDatabase.CloseConnection();
                ResetFields(false);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updPrice_ValueChanged(object sender, EventArgs e)
        {
            price = updPrice.Value;
        }

        private void cboLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLang.SelectedIndex == -1) return;
            language = cboLang.Text;
        }

        private void radYes_CheckedChanged(object sender, EventArgs e)
        {
            subTitle = 1;
        }

        private void radNo_CheckedChanged(object sender, EventArgs e)
        {
            subTitle = 0;
        }

        void ResetFields(bool status)
        {
            txtNo.Clear();
            txtTitle.Clear();
            cboLang.SelectedIndex = -1;
            updPrice.Value = updPrice.Minimum;
            radYes.Checked = true;
            radNo.Checked = false;
            btnSave.Enabled = status;
            btnCancel.Enabled = status;
            btnAdd.Enabled = !status;
            txtTitle.Focus();
        }
    }
}
