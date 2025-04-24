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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPwd.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var admin = "Admin";
            if(txtName.Text != admin || txtPwd.Text != admin)
            {
                MessageBox.Show("Wrong user name or password!");
            }
            else
            {
                this.Hide();
                var frm2 = new Form2();
                frm2.Show();
            }
        }
    }
}
