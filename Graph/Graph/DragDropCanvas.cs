using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{

    public partial class DragDropCanvas : Form
    {
        private List<Point[]> listOfShapes=new List<Point[]>();
        private Point dragStart;
        private Point[] selectedShape = null;
        private bool isResizing = false;
        public DragDropCanvas()
        {
            InitializeComponent();

            //typeof(Panel).InvokeMember("DoubleBuffered",
            //System.Reflection.BindingFlags.SetProperty |
            //System.Reflection.BindingFlags.Instance |
            //System.Reflection.BindingFlags.NonPublic,
            //null, leftPanel, new object[] { true });


            leftPanel.Paint += paintTriangle;
            leftPanel.MouseDown += LeftPanelMouseDown;
            leftPanel.MouseMove += LeftPanelMouseMove;
            leftPanel.MouseUp += LeftPanelMouseUp;
        }

        private void triangleGeneratorButton(object sender, EventArgs e)
        {
            Point[] p = { new Point(100, 0), new Point(0, 300), new Point(200, 300) };
            listOfShapes.Add(p);
            leftPanel.Invalidate();
        }

        private void paintTriangle(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(var p in listOfShapes)
            {
                g.FillPolygon(Brushes.Black, p);
            }
        }

        private void LeftPanelMouseDown(object s,MouseEventArgs e) {
            if (e.Button == MouseButtons.Middle) {
                Cursor = Cursors.SizeAll;
                foreach (var tri in listOfShapes.Reverse<Point[]>())
                {
                    using (GraphicsPath gp = new GraphicsPath())
                    {
                        gp.AddPolygon(tri);
                        if (gp.IsVisible(e.Location))
                        {
                            selectedShape = tri;
                            dragStart = e.Location;
                            break;
                        }
                    }
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                foreach(var tri in listOfShapes.Reverse<Point[]>())
                {
                    using(GraphicsPath gp=new GraphicsPath())
                    {
                        gp.AddPolygon(tri);
                        if (gp.IsVisible(e.Location))
                        {
                            selectedShape = tri;
                            isResizing = true;
                            dragStart = e.Location;
                            Cursor = Cursors.SizeNWSE;
                            break;

                        }
                    }
                }
            }
        }
        private void LeftPanelMouseMove(object s, MouseEventArgs e) {

            if (e.Button == MouseButtons.Middle)
            {
                if (selectedShape == null)
                    return;

                int dx = e.X - dragStart.X;
                int dy = e.Y - dragStart.Y;
                for (int i = 0; i < selectedShape.Length; i++)
                {
                    selectedShape[i].Offset(dx, dy);
                }
                dragStart = e.Location;
                leftPanel.Invalidate();
            }
            if (e.Button == MouseButtons.Left)
            {
                if (selectedShape == null)
                    return;

                int dx = e.X - dragStart.X;
                int dy = e.Y - dragStart.Y;
                selectedShape[1].Offset(0, dy);   
                selectedShape[2].Offset(dx, dy);  
                selectedShape[0].Offset(dx / 2, -dy / 2); 
                dragStart = e.Location;
                leftPanel.Invalidate();
            }
        }

        private void LeftPanelMouseUp(object s, MouseEventArgs e)
        {
                Cursor = Cursors.Default;
                selectedShape = null;
        }

    }
}
