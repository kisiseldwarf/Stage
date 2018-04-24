using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class aboutMenu : Form
    {
        public aboutMenu(Main parent)
        {
            parent.Enabled = false;
        }
        public aboutMenu()
        {
            InitializeComponent();
        }

        private void aboutMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
    }
}
