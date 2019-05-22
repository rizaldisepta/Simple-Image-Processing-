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
    public partial class GammaCorrection : Form
    {
        public GammaCorrection()
        {
            InitializeComponent();
        }

        private void hSB_GammaCorection_ValueChanged(object sender, EventArgs e)
        {
            tB_Gamma.Text = hSB_GammaCorection.Value.ToString();
        }
    }
}
