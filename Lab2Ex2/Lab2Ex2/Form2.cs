using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Ex2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee " + txtName.Text + " is living at " + txtAddress.Text +
                " joining in " + dateJoin.Value.ToString("dd/MM/yyyy") + " under department " + cboDep.Text + " is " + lstEdu.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            dateJoin.Value = DateTime.Now;
            lstEdu.Text = "";
            cboDep.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
