using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
    public partial class Form1 : Form
    {
        int x, y, h, w;
        Panel mainPanel = new Panel();
        public Form1()
        {
            InitializeComponent();
            //MinimumSize = new Size(700, 500);
            //MaximumSize = new Size(700, 500);

            h = Height;
            w = Width;

            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Paint += PanelDrawing;
            //Controls.Add(mainPanel);
            mainPanel.SendToBack();
            //mainPanel.SendToBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            w = w / 2;
            mainPanel.Invalidate();
        }

        private void PanelDrawing(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black,0,0,w,h);
        }
    }
}
