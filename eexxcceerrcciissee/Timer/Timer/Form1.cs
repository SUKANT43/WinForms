using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatchC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StopWatchControl swc = new StopWatchControl();
            Controls.Add(swc);
        }
    }
}
