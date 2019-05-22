using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgProc1
{
    public partial class FormBrCr : Form
    {
        public FormBrCr()
        {
            InitializeComponent();
        }
        
        private void hscBrightness_ValueChanged(object sender, EventArgs e)
        {
            txtBrightness.Text = hscBrightness.Value.ToString();
        }

        private void hscContrast_ValueChanged(object sender, EventArgs e)
        {
            txtContrast.Text = hscContrast.Value.ToString();
        }

        private void txtBrightness_TextChanged(object sender, EventArgs e)
        {
            if ((txtBrightness.Text == "") || (txtBrightness.Text == "-"))
            {
                hscBrightness.Value = 0;
                txtBrightness.Text = "0";
            }
            else if ((Convert.ToInt16(txtBrightness.Text) <= 127) &&
            (Convert.ToInt16(txtBrightness.Text) >= -127))
            {
                hscBrightness.Value = Convert.ToInt16(txtBrightness.Text);
            }
            else
            {
                MessageBox.Show("Input nilai Error");
                txtBrightness.Text = "0";
            }
        }

        private void txtContrast_TextChanged(object sender, EventArgs e)
        {
            if ((txtContrast.Text == "") || (txtContrast.Text == "-"))
            {
                hscContrast.Value = 0;
                txtContrast.Text = "0";
            }
            else if ((Convert.ToInt16(txtContrast.Text) <= 127) &&
            (Convert.ToInt16(txtContrast.Text) >= -127))
            {
                hscContrast.Value = Convert.ToInt16(txtContrast.Text);
            }
            else
            {
                MessageBox.Show("Input nilai Error");
                txtContrast.Text = "0";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBrCr_Load(object sender, EventArgs e)
        {
            txtBrightness.Text = hscBrightness.Value.ToString();
            txtContrast.Text = hscContrast.Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
