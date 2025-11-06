using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form3 : Form
    {
        int x, y, w, h;
        public Form3()
        {
            InitializeComponent();
            mainPanel.Paint += DrawImage;
            mainPanel.MouseClick += OnClickAndOnResize;
        }

        private void DrawImage(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.SkyBlue,x,y,200,200);
        }

        private void OnClickAndOnResize(object s, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            DrawImage(null,null);
        }

    }
}
