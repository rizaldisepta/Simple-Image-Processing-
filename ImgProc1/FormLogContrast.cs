﻿using System;
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
    public partial class FormLogContrast : Form
    {
        public FormLogContrast()
        {
            InitializeComponent();
        }

        private void FormLogContrast_Load(object sender, EventArgs e)
        {

        }

        private void hS_LogContrast_ValueChanged(object sender, EventArgs e)
        {
            tB_LogContrast.Text = hS_LogContrast.Value.ToString();
        }
    }
}
