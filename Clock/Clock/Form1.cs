using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClockControl cc = new ClockControl();
            cc.AutoSize = true;
            cc.Size = new Size(400, 400);
            cc.Location = new Point(100, 75);
            Controls.Add(cc);
        }
    }
}
