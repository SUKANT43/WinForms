using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

        }

        private void Button1Click(object sender, EventArgs e)
        {
            dragTimerController1.Min = (int)minNumeric.Value;
            dragTimerController1.Max = (int)maxNumeric.Value;
            dragTimerController1.Step = (int)stepNumeric.Value;
            dragTimerController1.Speed = (int)speedNumeric.Value;
        }
    }
}
