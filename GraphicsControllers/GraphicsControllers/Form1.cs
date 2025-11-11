using System;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Collections.Generic;

using System.Windows.Forms;

namespace GraphicsControllers
{
    //public partial class Form1 : Form
    //{
    //    bool isLine = false;
    //    int clickCount = 0;
    //    int x1, y1, x2, y2;

    //    public Form1()
    //    {
    //        InitializeComponent();
    //        leftPanel.MouseDown += LeftPanelMouseDown;
    //        leftPanel.Paint += PaintLeftPanel;
    //    }

    //    private void PaintLeftPanel(object s, PaintEventArgs e)
    //    {
    //        if (clickCount == 2)
    //        {
    //            using (Pen p = new Pen(Color.Black, 4))
    //            {
    //                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    //                e.Graphics.DrawLine(p, x1, y1, x2, y2);
    //                clickCount = 0;
    //                x1=y1=x2=y2 = 0;
    //            }
    //        }
    //    }

    //    private void LineButtonClick(object s, EventArgs e)
    //    {
    //        isLine = true;
    //        clickCount = 0;
    //    }

    //    private void LeftPanelMouseDown(object s, MouseEventArgs e)
    //    {
    //        if (!isLine) return;

    //        clickCount++;
    //       // MessageBox.Show($"{e.X  }{e.Y}");
    //        if (clickCount == 1)
    //        {
    //            x1 = e.X;
    //            y1 = e.Y;
    //        }
    //        else if (clickCount == 2)
    //        {
    //            x2 = e.X;
    //            y2 = e.Y;
    //            leftPanel.Invalidate(); 
    //            isLine = false; 
    //        }
    //    }
    //}

    public partial class Form1 : Form
    {
        private bool isLine= false, isRectangle= false, isTriangle=false;
        private int checkPoint = 0;
        private int x1, y1, x2, y2,x3,y3,x4,y4;
        private bool isMoving = false;
        private Point mousePoint;
        private Point[] selectedShape=null;
        private List<Point[]> ls = new List<Point[]>();
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, leftPanel, new object[] { true });
            leftPanel.MouseDown += LeftPanelMouseDown;
            leftPanel.MouseMove += LeftPanelMouseMove;
            leftPanel.MouseUp += LeftPanelMouseUp;
            leftPanel.Paint += LeftPanelPaint;
            leftPanel.MouseDoubleClick += LeftPanelDoubleClick;
        }

        private void LeftPanelPaint(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (isLine || isRectangle || isTriangle)
            {
                if (x2 != 0 && y2 != 0)
                {
                    g.DrawLine(new Pen(Color.Black,3), new Point(x1, y1), new Point(x2, y2));
                }
                if (x2 != 0 && y2 != 0 && x3 != 0 && y3 != 0)
                {
                    g.DrawLine(new Pen(Color.Black, 3), new Point(x1, y1), new Point(x2, y2));
                    g.DrawLine(new Pen(Color.Black, 3), new Point(x2, y2), new Point(x3, y3));

                }

            }
            
                for (int i = ls.Count - 1; i >= 0; i--)
                {
                    Point[] p = ls[i];
                    if (p.Length == 2)
                    {
                        Pen pen = new Pen(Color.Black, 3);
                        g.DrawLine(pen, p[0], p[1]);
                    }
                    if (p.Length == 3)
                    {
                        Pen pen = new Pen(Color.Black, 3);
                        g.DrawPolygon(pen, p);
                        g.FillPolygon(Brushes.LightGreen, p);
                    }
                    if (p.Length == 4)
                    {
                        Pen pen = new Pen(Color.Black, 3);
                        g.DrawPolygon(pen, p);
                        g.FillPolygon(Brushes.Violet, p);
                    }
                }

        }
        
        private void LineButtonClick(object sender, EventArgs e)
        {
            isLine = true;
            isRectangle = false;
            isTriangle = false;
            checkPoint = 0;
            x1 = y1 = x2 = y2 = x3 = y3 = 0;
            leftPanel.Invalidate();
        }

        private void TriangleButtonClick(object sender, EventArgs e)
        {
            isLine = false;
            isRectangle = false;
            isTriangle = true;
            checkPoint = 0;
            x1 = y1 = x2 = y2 = x3 = y3 = 0;
            leftPanel.Invalidate();
        }

        private void RectangleButtonClick(object sender, EventArgs e)
        {
            isLine = false;
            isRectangle = true;
            isTriangle = false;
            checkPoint = 0;
            x1 = y1 = x2 = y2 = x3 = y3 = 0;
            leftPanel.Invalidate();
        }
        private void LeftPanelMouseDown(object s, MouseEventArgs e)
        {
            if (isLine)
            {
                checkPoint++;
                if (checkPoint == 1)
                {
                    x1 = e.X;
                    y1 = e.Y;
                }
                if (checkPoint == 2)
                {
                    x2 = e.X;
                    y2 = e.Y;
                    ls.Insert(0,new Point[]{new Point ( x1, y1),
                        new Point(x2,y2),
                });
                    checkPoint = 0;
                    isLine = false;
                    x1 = y1 = x2 = y2 = x3 = y3 = 0;
                    leftPanel.Invalidate();
                }
            }

            if (isTriangle)
            {
                checkPoint++;
                if (checkPoint == 1)
                {
                    x1 = e.X;
                    y1 = e.Y;
                }
                if (checkPoint == 2)
                {
                    x2 = e.X;
                    y2 = e.Y;
                    leftPanel.Invalidate();

                }
                if (checkPoint == 3)
                {
                    x3 = e.X;
                    y3 = e.Y;
                    ls.Insert(0,new Point[]{new Point ( x1, y1),
                        new Point(x2,y2),
                        new Point(x3,y3)
                });
                    checkPoint = 0;
                    isTriangle = false;
                    x1 = y1 = x2 = y2 = x3 = y3 = 0;
                    leftPanel.Invalidate();
                }
            }
            if (isRectangle)
            {
                checkPoint++;
                x4 = e.X;
                y4 = e.Y;
                if (checkPoint == 1)
                {
                    x1 = e.X;
                    y1 = e.Y;
                }
                if (checkPoint == 2)
                {
                    x2 = e.X;
                    y2 = e.Y;
                    leftPanel.Invalidate();

                }
                if (checkPoint == 3)
                {
                    x3 = e.X;
                    y3 = e.Y;
                    leftPanel.Invalidate();

                }
                if (checkPoint == 4)
                {
                    x4 = e.X;
                    y4 = e.Y;
                    Point[] ordered = OrderRectanglePoints(new Point[]{new Point ( x1, y1),
                        new Point(x2,y2),
                        new Point(x3,y3),
                        new Point(x4,y4)
                });
                    ls.Insert(0,ordered);
                    checkPoint = 0;
                    isRectangle = false;
                    x1 = y1 = x2 = y2 = x3 = y3 = 0;
                    leftPanel.Invalidate();
                }
                }

            if (e.Button == MouseButtons.Middle)
            {
                for (int i = ls.Count - 1; i >= 0; i--)
                {
                    Point[] p = ls[i];
                    using (GraphicsPath gp = new GraphicsPath())
                    {
                        if (p.Length > 2)
                        {
                            gp.AddPolygon(p);
                            if (gp.IsVisible(e.Location))
                            {
                                Cursor = Cursors.SizeAll;
                                isMoving = true;
                                mousePoint = e.Location;
                                selectedShape = ls[i];
                            }
                        }
                        if (p.Length == 2)
                        {
                            gp.AddLine(p[0], p[1]);
                            using (Pen pen = new Pen(Color.Black, 10))
                            {
                                if (gp.IsOutlineVisible(e.Location, pen))
                                {
                                    Cursor = Cursors.SizeAll;
                                    isMoving = true;
                                    mousePoint = e.Location;
                                    selectedShape = ls[i];

                                }
                            }
                        }
                    }
                }
            }
        }
        private Point[] OrderRectanglePoints(Point[] pts)
        {
            Array.Sort(pts, (a, b) => a.Y.CompareTo(b.Y));
            Point[] top = new Point[] { pts[0], pts[1] };
            Point[] bottom = new Point[] { pts[2], pts[3] };
            Array.Sort(top, (a, b) => a.X.CompareTo(b.X));
            Array.Sort(bottom, (a, b) => a.X.CompareTo(b.X));
            return new Point[] { top[0], top[1], bottom[1], bottom[0] };
        }
       

        private void LeftPanelMouseMove(object s,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && isMoving && selectedShape != null)
            {

                ls.Remove(selectedShape);

                int dx = e.X - mousePoint.X;
                int dy = e.Y - mousePoint.Y;
                bool withinBound = true;
                foreach (var pt in selectedShape)
                {
                    int newX = pt.X + dx;
                    int newY = pt.Y + dy;
                    if (newX < 0 || newY < 0 || newX > leftPanel.Width || newY > leftPanel.Height)
                    {
                        withinBound = false;
                        break;
                    }
                }

                if (withinBound)
                {
                    for (int i = 0; i < selectedShape.Length; i++)
                    {
                        selectedShape[i].Offset(dx, dy);
                    }
                }
                 ls.Insert(0,selectedShape);

                mousePoint = e.Location;
                leftPanel.Invalidate();
            }
        }

        private void LeftPanelMouseUp(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Cursor = Cursors.Default;
                selectedShape = null;
                isMoving = false;
            }
        }

        private void LeftPanelDoubleClick(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //MessageBox.Show("hi");
                if (ls == null)
                {
                    return;
                }
                foreach(var l in ls)
                {
                    GraphicsPath gp = new GraphicsPath();
                    if (l.Length > 2)
                    {
                        gp.AddPolygon(l);
                        if (gp.IsVisible(e.Location))
                        {
                            ls.Remove(l);
                            leftPanel.Invalidate();
                            return;
                        }
                    }
                    else if (l.Length == 2)
                    {
                        Pen p = new Pen(Color.Black,10);
                        gp.AddLine(l[0], l[1]);
                        if (gp.IsOutlineVisible(e.Location, p))
                        {
                            ls.Remove(l);
                            leftPanel.Invalidate();
                            return;
                        }
                    }
                }
            }
        }
    }
}
