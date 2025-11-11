using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class Form1 : Form
    {
        List<ShapeData> ls = new List<ShapeData>();
        string currentShape = null;
        bool isDrawing = false;
        bool isMoving = false;
        bool isResizing = false; 

        Point startPoint, endPoint;
        ShapeData selectedShape = null;
        Point mousePoint;

        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, leftPanel, new object[] { true });

            leftPanel.Paint += LeftPanelPaint;
            leftPanel.MouseDown += LeftPanelMouseDown;
            leftPanel.MouseMove += LeftPanelMouseMove;
            leftPanel.MouseUp += LeftPanelMouseUp;
            leftPanel.MouseDoubleClick += LeftPanelMouseDoubleClick;
        }

        private void LeftPanelPaint(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var sh in ls.AsEnumerable().Reverse())
                sh.Draw(g);

            if (isDrawing)
            {
                using (Pen previewPen = new Pen(Color.Gray, 2) { DashStyle = DashStyle.Dash })
                    DrawShape(g, previewPen, currentShape, startPoint, endPoint);
            }
        }

        private void DrawShape(Graphics g, Pen p, string shape, Point start, Point end)
        {
            Rectangle rect = GetRectangle(start, end);
            switch (shape)
            {
                case "Rectangle": g.DrawRectangle(p, rect); break;
                case "Ellipse": g.DrawEllipse(p, rect); break;
                case "Triangle":
                    Point p1 = new Point(rect.Left + rect.Width / 2, rect.Top);
                    Point p2 = new Point(rect.Left, rect.Bottom);
                    Point p3 = new Point(rect.Right, rect.Bottom);
                    g.DrawPolygon(p, new Point[] { p1, p2, p3 });
                    break;
            }
        }

        private Rectangle GetRectangle(Point start, Point end)
        {
            return new Rectangle(
                Math.Min(start.X, end.X),
                Math.Min(start.Y, end.Y),
                Math.Abs(end.X - start.X),
                Math.Abs(end.Y - start.Y)
            );
        }

        private void TriangleButtonClick(object sender, EventArgs e) => currentShape = "Triangle";
        private void RectangleButtonClick(object sender, EventArgs e) => currentShape = "Rectangle";
        private void EllipseButtonClick(object sender, EventArgs e) => currentShape = "Ellipse";

        private void LeftPanelMouseDown(object s, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.Button == MouseButtons.Left)
            {
                foreach (var sh in ls)
                {
                    if (sh.Contains(e.Location))
                    {
                        selectedShape = sh;
                        isResizing = true;
                        mousePoint = e.Location;
                        Cursor = Cursors.SizeNWSE;
                        ls.Remove(selectedShape);
                        ls.Insert(0, selectedShape);
                        break;
                    }
                }
                return;
            }

            if (e.Button == MouseButtons.Left && !Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (string.IsNullOrEmpty(currentShape)) return;
                isDrawing = true;
                startPoint = e.Location;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                foreach (var sh in ls)
                {
                    if (sh.Contains(e.Location))
                    {
                        selectedShape = sh;
                        isMoving = true;
                        mousePoint = e.Location;
                        Cursor = Cursors.SizeAll;
                        ls.Remove(selectedShape);
                        ls.Insert(0, selectedShape);
                        break;
                    }
                }
            }
        }

        private void LeftPanelMouseMove(object s, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;
                leftPanel.Invalidate();
            }

            if (isMoving && selectedShape != null && e.Button == MouseButtons.Middle)
            {
                int dx = e.X - mousePoint.X;
                int dy = e.Y - mousePoint.Y;
                selectedShape.Move(dx, dy, leftPanel.Width, leftPanel.Height, e.X, e.Y);
                mousePoint = e.Location;
                leftPanel.Invalidate();
            }

            if (isResizing && selectedShape != null && e.Button == MouseButtons.Left)
            {
                int dx = e.X - mousePoint.X;
                int dy = e.Y - mousePoint.Y;
                selectedShape.Resize(dx, dy, leftPanel.Width, leftPanel.Height);
                mousePoint = e.Location;
                leftPanel.Invalidate();
            }
        }

        private void LeftPanelMouseUp(object s, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                endPoint = e.Location;
                ls.Insert(0, new ShapeData(currentShape, startPoint, endPoint));
                currentShape = null;
                leftPanel.Invalidate();
            }
            else if (isMoving && e.Button == MouseButtons.Middle)
            {
                isMoving = false;
                selectedShape = null;
                Cursor = Cursors.Default;
            }
            else if (isResizing && e.Button == MouseButtons.Left)
            {
                isResizing = false;
                selectedShape = null;
                Cursor = Cursors.Default;
            }
        }

        private void LeftPanelMouseDoubleClick(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (var sh in ls.AsEnumerable().Reverse())
                {
                    if (sh.Contains(e.Location))
                    {
                        ls.Remove(sh);
                        leftPanel.Invalidate();
                        break;
                    }
                }
            }
        }
    }

    public class ShapeData
    {
        public string ShapeName { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }

        public ShapeData(string name, Point start, Point end)
        {
            ShapeName = name;
            Start = start;
            End = end;
        }

        public void Draw(Graphics g)
        {
            Rectangle rect = new Rectangle(
                Math.Min(Start.X, End.X),
                Math.Min(Start.Y, End.Y),
                Math.Abs(End.X - Start.X),
                Math.Abs(End.Y - Start.Y)
            );

            using (Pen borderPen = new Pen(Color.Black, 2))
            {
                switch (ShapeName)
                {
                    case "Rectangle":
                        g.FillRectangle(Brushes.LightGreen, rect);
                        g.DrawRectangle(borderPen, rect);
                        break;
                    case "Ellipse":
                        g.FillEllipse(Brushes.LightSteelBlue, rect);
                        g.DrawEllipse(borderPen, rect);
                        break;
                    case "Triangle":
                        Point p1 = new Point(rect.Left + rect.Width / 2, rect.Top);
                        Point p2 = new Point(rect.Left, rect.Bottom);
                        Point p3 = new Point(rect.Right, rect.Bottom);
                        g.FillPolygon(Brushes.MediumPurple, new[] { p1, p2, p3 });
                        g.DrawPolygon(borderPen, new[] { p1, p2, p3 });
                        break;
                }
            }
        }

        public bool Contains(Point p)
        {
            Rectangle rect = new Rectangle(
                Math.Min(Start.X, End.X),
                Math.Min(Start.Y, End.Y),
                Math.Abs(End.X - Start.X),
                Math.Abs(End.Y - Start.Y)
            );

            switch (ShapeName)
            {
                case "Rectangle": return rect.Contains(p);
                case "Ellipse":
                    double rx = rect.Width / 2.0;
                    double ry = rect.Height / 2.0;
                    double cx = rect.Left + rx;
                    double cy = rect.Top + ry;
                    return ((p.X - cx) * (p.X - cx)) / (rx * rx) + ((p.Y - cy) * (p.Y - cy)) / (ry * ry) <= 1;
                case "Triangle":
                    Point p1 = new Point(rect.Left + rect.Width / 2, rect.Top);
                    Point p2 = new Point(rect.Left, rect.Bottom);
                    Point p3 = new Point(rect.Right, rect.Bottom);
                    using (GraphicsPath gp = new GraphicsPath())
                    {
                        gp.AddPolygon(new[] { p1, p2, p3 });
                        return gp.IsVisible(p);
                    }
                default: return false;
            }
        }

        public void Move(int dx, int dy, int panelWidth, int panelHeight, int eX, int eY)
        {
            Rectangle rect = new Rectangle(
                Math.Min(Start.X, End.X) + dx,
                Math.Min(Start.Y, End.Y) + dy,
                Math.Abs(End.X - Start.X),
                Math.Abs(End.Y - Start.Y)
            );

            if (rect.Left < 0 || rect.Top < 0 || rect.Right > panelWidth - 150 || rect.Bottom > panelHeight)
                return;

            Start = new Point(Start.X + dx, Start.Y + dy);
            End = new Point(End.X + dx, End.Y + dy);
        }

        public void Resize(int dx, int dy, int panelWidth, int panelHeight)
        {
            End = new Point(End.X + dx, End.Y + dy);

            Rectangle rect = new Rectangle(
                Math.Min(Start.X, End.X),
                Math.Min(Start.Y, End.Y),
                Math.Abs(End.X - Start.X),
                Math.Abs(End.Y - Start.Y)
            );

            if (rect.Right > panelWidth)
                End = new Point(panelWidth - 1, End.Y);
            if (rect.Bottom > panelHeight)
                End = new Point(End.X, panelHeight - 1);
        }
    }
}
