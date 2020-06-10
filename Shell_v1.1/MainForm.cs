using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shell_v1._02
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void userControl_Load(object sender, EventArgs e)
        {
            userControl.SetPortText(29250);
            userControl.SetIPText("192.168.0.103");
        }
    }
}
