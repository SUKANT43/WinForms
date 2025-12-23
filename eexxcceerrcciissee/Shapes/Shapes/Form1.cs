using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Shapes
{
    public partial class Form1 : Form
    {
        List<Shapes> ls = new List<Shapes>();
        Shapes selectedShape = null;
        Point lastMouse;
        bool isDragging = false;
        bool isResize = false;
        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty|BindingFlags.Instance|BindingFlags.NonPublic,
                null,
                leftPanel,
                new object[] {true}
                );

            MinimumSize = new Size(1500, 1000);
            MaximumSize = new Size(1500, 1000);


            leftPanel.Paint += FormPaint;
            leftPanel.MouseDown += OnMouseDown;
            leftPanel.MouseMove += OnMouseMove;
            leftPanel.MouseUp += OnMouseUp;
            leftPanel.MouseDoubleClick += OnMouseDoubleClick;
            leftPanel.Resize += (s, e) => { leftPanel.Invalidate();};
        }

        private void OnMouseDoubleClick(object a, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = ls.Count - 1; i >= 0; i--)
                {
                    if (ls[i].Contains(e.Location))
                    {
                        selectedShape = ls[i];
                        ls.Remove(ls[i]);
                        leftPanel.Invalidate();
                        break;
                    }
                }
            }
        }


        private void OnMouseDown(object a,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                selectedShape = null;
                for (int i = ls.Count - 1; i >= 0; i--)
                {
                    if (ls[i].Contains(e.Location))
                    {
                        selectedShape = ls[i];
                        lastMouse = e.Location;
                        isDragging = true;
                        leftPanel.Cursor = Cursors.SizeAll;
                        ls.Remove(selectedShape);
                        ls.Add(selectedShape);
                        selectedShape.IsSelected = true;
                        break;
                    }
                }
                leftPanel.Invalidate();
            }

            if (e.Button == MouseButtons.Left)
            {
                for(int i = ls.Count - 1; i >= 0; i--)
                {
                    if (ls[i].Contains(e.Location))
                    {
                        selectedShape = ls[i];
                        lastMouse = e.Location;
                        isResize = true;
                        leftPanel.Cursor = Cursors.PanNW;
                        ls.Remove(selectedShape);
                        ls.Add(selectedShape);
                        selectedShape.IsSelected = true;
                        break;
                    }
                }
                leftPanel.Invalidate();
            }
        }

        private void OnMouseMove(object a,MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Middle)
            {
                if (isDragging && selectedShape != null)
                {
                    int dx = e.X - lastMouse.X;
                    int dy = e.Y - lastMouse.Y;
                    Size s = new Size(Width-160 , Height-40);
                    selectedShape.Move(dx, dy,s);
                    lastMouse = e.Location;
                    leftPanel.Invalidate();
                }
            }

            if (e.Button == MouseButtons.Left )
            {
                int dx = e.X - lastMouse.X;
                int dy = e.Y - lastMouse.Y;

                if (selectedShape != null && isResize)
                {
                    Size s = new Size(Width - 160, Height-40);

                    selectedShape.Resize(dx, dy,s);
                }
                lastMouse = e.Location;
                leftPanel.Invalidate();
            }
        }

        private void OnMouseUp(object a,MouseEventArgs e)
        {
            isDragging = false;
            isResize = false;
            leftPanel.Cursor = Cursors.Arrow;
            if (selectedShape != null)
            {
                selectedShape.IsSelected = false;
            }
            leftPanel.Invalidate();
        }

        private void FormPaint(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Shapes ss in ls)
            {
                ss.Draw(g);   
            }
        }

        private void TriangleButtonClick(object sender, EventArgs e)
        {
            ls.Insert(0, new Triangle(
                new Point(100, 40),  
                new Point(40, 140),  
                new Point(160, 140)   
            ));
            leftPanel.Invalidate();
        }

        private void RectangleButtonClick(object sender, EventArgs e)
        {
            ls.Insert(0, new Rectangle(
                new Point(100, 100),  
                new Point(170, 100),  
                new Point(170, 170), 
                new Point(100, 170)  
            ));
            leftPanel.Invalidate();
        }

        private void CircleButtonClick(object sender, EventArgs e)
        {
            ls.Insert(0, new Circle(400,300,100,100));
            leftPanel.Invalidate();
        }
    }
}
