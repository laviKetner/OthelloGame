using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex02_Othelo
{
    public partial class FormPlayOnline : Form
    {
        public FormPlayOnline()
        {
            InitializeComponent();
            FormClosing += FormPlayOnline_FormClosing;
        }

        //need to remember to do:  FormClosing -= FormPlayOnline_FormClosing after play//
        private void FormPlayOnline_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
