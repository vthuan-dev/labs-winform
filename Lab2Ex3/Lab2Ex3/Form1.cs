using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Ex3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnVerify_Click_1(object sender, EventArgs e)
        {
            if (lstSource.Text == lstDes.Text)
            {
                MessageBox.Show("Source and Destination cannot be the same!");
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtTicket.Text = "";
            txtName.Text = "";
            txtPassport.Text = "";
            lstSource.ClearSelected();
            lstDes.ClearSelected();
            dateFlight.Value = DateTime.Now;
            cboClass.Text = "";
            lstServices.ClearSelected();
            for (int i = 0; i < lstServices.Items.Count; i++) {
                if (lstServices.GetItemChecked(i))
                    lstServices.SetItemChecked(i, false);
            }
        }
    }
}
