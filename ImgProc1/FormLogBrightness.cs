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
    public partial class FormLogBrightness : Form
    {
        public FormLogBrightness()
        {
            InitializeComponent();
        }

        private void FormLogBrightness_Load(object sender, EventArgs e)
        {

        }
        private void hSB_LogBrightness_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void hSB_LogBrightness_ValueChanged(object sender, EventArgs e)
        {
            tB_LogBrightness.Text = hSB_LogBrightness.Value.ToString();
        }
    }
}
