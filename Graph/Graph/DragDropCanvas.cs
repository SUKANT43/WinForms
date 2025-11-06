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

    public partial class DragDropCanvas : Form
    {
        public DragDropCanvas()
        {
            InitializeComponent();
        }

        private void triangleGeneratorButton(object sender, EventArgs e)
        {
          leftPanel.Paint += TrianglePaint;
          leftPanel.Invalidate();
        }

        private void TrianglePaint(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] p1 = { new Point(100,100),new Point(0,200),new Point(200,200)};
            g.FillPolygon(Brushes.Black,p1);

        }

    }
}
