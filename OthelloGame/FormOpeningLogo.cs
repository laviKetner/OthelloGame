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
    public partial class FormOpeningLogo : Form
    {
        public FormOpeningLogo()
        {
            InitializeComponent();
            Show();
            System.Threading.Thread.Sleep(2000);
            Close();
        }
    }
}
