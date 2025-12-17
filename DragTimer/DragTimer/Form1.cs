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
            DragTimerController dtc = new DragTimerController();
            dtc.Max = 30;
            dtc.Min = 0;
            dtc.Step = 10;
            dtc.Speed = 10;
            Controls.Add(dtc);
        }
    }
}
