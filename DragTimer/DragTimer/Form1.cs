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
            dtc.Max = 140;
            dtc.Min = -100;
            dtc.Step = 10;
            dtc.Speed = 5;
            Controls.Add(dtc);

            //CustomButton cb = new CustomButton();
            //cb.Location = new Point(300, 200);
            //cb.BackgroundColor = Color.Red;
            //cb.Text = "ok";
            //cb.Height = 10;
            //cb.Width = 20;
            //Controls.Add(cb);
        }

        
    }
}
