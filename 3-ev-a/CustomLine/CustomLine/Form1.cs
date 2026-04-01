using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomLine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lineControl1.Dock = DockStyle.Fill;
            lineControl1.HorizontalLine = 3;
            lineControl1.VerticalLine = 3;
        }
    }
}
