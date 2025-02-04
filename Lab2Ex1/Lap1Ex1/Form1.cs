using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap1Ex1
{
    public partial class StudentDetails : Form
    {
        public StudentDetails()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstClass.ClearSelected();
            cboDiv.Text = "";
            lstHob.ClearSelected();
            for(int i=0; i<=lstHob.Items.Count-1; i++)
            {
                if (lstHob.GetItemChecked(i)) { 
                    lstHob.SetItemChecked(i, false);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cnt = lstHob.CheckedItems.Count;
            string hobby = "";
            for (int i = 0; i <= cnt-1; i++) {
                hobby = hobby + lstHob.CheckedItems[i];
                if(i<cnt-1)
                    hobby = hobby + ", ";
            }
            MessageBox.Show(txtName.Text + " born in " + txtYear.Text + " from Class " +
                lstClass.Text + ", Division " + cboDiv.Text +
                " has following hobbies " + hobby);
        }
    }
}
