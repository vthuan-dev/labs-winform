using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Ex1
{
    public partial class frmBookSale : Form
    {
        private clsBookSale mBookSale;
        public frmBookSale()
        {
            InitializeComponent();
        }

        private void mnuCal_Click(object sender, EventArgs e)
        {
            try
            {
                mBookSale = new clsStudentBookSale(txtTitle.Text, Convert.ToInt32(txtQuan.Text), 
                    Convert.ToDecimal(txtPrice.Text), chkDis.Checked, chkDisStudent.Checked);
                mBookSale.Title = txtTitle.Text;
                mBookSale.Quantity = Convert.ToInt32(txtQuan.Text);
                mBookSale.Price = Convert.ToDecimal(txtPrice.Text);
                mBookSale.Discount = chkDis.Checked;

                txtPrice.Text = mBookSale.Price.ToString("C");
                txtEPrice.Text = mBookSale.ExtendedPrice().ToString("C");
                txtDis.Text = mBookSale.DiscountAmount().ToString("C");
                txtNetDue.Text = mBookSale.NetDue().ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Quantity or Price, " + ex.Message, "Data Entry Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtQuan.Text = "";
            txtPrice.Text = "";
        }

        private void mnuSum_Click(object sender, EventArgs e)
        {
            string strMessage = "Sales Total: " + clsBookSale.SalesTotal.ToString("C")
                 + "\nSales Count: " + clsBookSale.SalesCount.ToString();

            MessageBox.Show(strMessage, "Summary Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

 
    }
}
