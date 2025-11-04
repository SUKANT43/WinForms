using System;
using System.Drawing;
using System.Windows.Forms;
//ModifierKeys.HasFlag
namespace exc3
{
    public partial class Form1 : Form
    {
        private Point dragStartPoint;
        private bool isResizing = false;
        private string resizeDir = "";

        public Form1()
        {
            InitializeComponent();

            MouseDoubleClick += ButtonClick;
            dragPanel.MouseDoubleClick += DragButtonClick;
            dragPanel.MouseDown += MouseDownDrag;
            dragPanel.MouseUp += MouseUpDrag;
            dragPanel.MouseMove += MouseMoveDrag;
        }

        private void ButtonClick(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X - (dragPanel.Width / 2);
                int y = e.Y - (dragPanel.Height / 2);
                x = Math.Max(0, Math.Min(x, ClientSize.Width - dragPanel.Width));
                y = Math.Max(0, Math.Min(y, ClientSize.Height - dragPanel.Height));
                dragPanel.Location = new Point(x, y);
            }

            if (e.Button == MouseButtons.Right)
            {
                dragPanel.Size = new Size(100, 100);
                dragPanel.Location = new Point(0, 0);
            }
        }

        private void DragButtonClick(object s, MouseEventArgs e)
        {
            Point np = dragPanel.Location;

            if (e.Button == MouseButtons.Left && !ModifierKeys.HasFlag(Keys.Control))
            {
                int x = (np.X + e.X) - (dragPanel.Width / 2);
                int y = (np.Y + e.Y) - (dragPanel.Height / 2);
                x = Math.Max(0, Math.Min(x, ClientSize.Width - dragPanel.Width));
                y = Math.Max(0, Math.Min(y, ClientSize.Height - dragPanel.Height));
                dragPanel.Location = new Point(x, y);
            }

            if (e.Button == MouseButtons.Right)
            {
                dragPanel.Size = new Size(100, 100);
                dragPanel.Location = new Point(0, 0);
            }
        }

        private void MouseDownDrag(object s, MouseEventArgs e)
        {
            int edge = 20;

            if (e.Button == MouseButtons.Middle)
            {
                dragStartPoint = e.Location;
                dragPanel.Cursor = Cursors.SizeAll;
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                dragStartPoint = e.Location;
                isResizing = true;

                bool onLeft = e.X <= edge;
                bool onRight = e.X >= dragPanel.Width - edge;
                bool onTop = e.Y <= edge;
                bool onBottom = e.Y >= dragPanel.Height - edge;

                if (onTop && onLeft)
                {
                    resizeDir = "TL";
                    dragPanel.Cursor = Cursors.SizeNWSE;
                }
                else if (onTop && onRight)
                {
                    resizeDir = "TR";
                    dragPanel.Cursor = Cursors.SizeNESW;
                }
                else if (onBottom && onLeft)
                {
                    resizeDir = "BL";
                    dragPanel.Cursor = Cursors.SizeNESW;
                }
                else if (onBottom && onRight)
                {
                    resizeDir = "BR";
                    dragPanel.Cursor = Cursors.SizeNWSE;
                }
                else if (onTop)
                {
                    resizeDir = "T";
                    dragPanel.Cursor = Cursors.SizeNS;
                }
                else if (onBottom)
                {
                    resizeDir = "B";
                    dragPanel.Cursor = Cursors.SizeNS;
                }
                else if (onLeft)
                {
                    resizeDir = "L";
                    dragPanel.Cursor = Cursors.SizeWE;
                }
                else if (onRight)
                {
                    resizeDir = "R";
                    dragPanel.Cursor = Cursors.SizeWE;
                }
                else
                {
                    resizeDir = "";
                    dragPanel.Cursor = Cursors.Default;
                }
            }
        }

        private void MouseMoveDrag(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                int dx = e.X - dragStartPoint.X;
                int dy = e.Y - dragStartPoint.Y;
                int newX = dragPanel.Left + dx;
                int newY = dragPanel.Top + dy;
                newX = Math.Max(0, Math.Min(newX, ClientSize.Width - dragPanel.Width));
                newY = Math.Max(0, Math.Min(newY, ClientSize.Height - dragPanel.Height));
                dragPanel.Location = new Point(newX, newY);
            }

            if (isResizing && e.Button == MouseButtons.Left)
            {
                int dx = e.X - dragStartPoint.X;
                int dy = e.Y - dragStartPoint.Y;
                Rectangle rect = dragPanel.Bounds;

                switch (resizeDir)
                {
                    case "T":
                        if (dragPanel.Top < 0)
                        {
                            return;
                        }
                        rect.Y += dy;
                        rect.Height -= dy;
                        break;
                    case "B":
                        if (dragPanel.Bottom > ClientSize.Height)
                        {
                            return;
                        }
                        rect.Height += dy;
                        break;
                    case "L":
                        if (dragPanel.Left < 0)
                        {
                            return;
                        }
                        rect.X += dx;
                        rect.Width -= dx;
                        break;
                    case "R":
                        if (dragPanel.Right > ClientSize.Width)
                        {
                            return;
                        }
                        rect.Width += dx;
                        break;
                    case "TL":
                        if(dragPanel.Top < 0|| dragPanel.Left < 0)
                        {
                            return;
                        }
                        rect.X += dx;
                        rect.Y += dy;
                        rect.Width -= dx;
                        rect.Height -= dy;
                        break;
                    case "TR":
                        if (dragPanel.Top < 0|| dragPanel.Right > ClientSize.Width)
                        {
                            return;
                        }
                        rect.Y += dy;
                        rect.Height -= dy;
                        rect.Width += dx;
                        break;
                    case "BL":
                        if(dragPanel.Bottom > ClientSize.Height|| dragPanel.Left < 0)
                        {
                            return;
                        }
                        rect.X += dx;
                        rect.Width -= dx;
                        rect.Height += dy;
                        break;
                    case "BR":
                        if(dragPanel.Bottom > ClientSize.Height|| dragPanel.Right > ClientSize.Width)
                        {
                            return;
                        }
                        rect.Width += dx;
                        rect.Height += dy;
                        break;
                }

                if (rect.Width < 20) rect.Width = 20;
                if (rect.Height < 20) rect.Height = 20;
                if (rect.X < 0)
                {
                    rect.Width += rect.X;
                    rect.X = 0;
                }
                if (rect.Y < 0)
                {
                    rect.Height += rect.Y;
                    rect.Y = 0;
                }

                dragPanel.Bounds = rect;
                dragStartPoint = e.Location;
            }
        }

        private void MouseUpDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                dragPanel.Cursor = Cursors.Default;

            if (isResizing)
            {
                isResizing = false;
                resizeDir = "";
                dragPanel.Cursor = Cursors.Default;
            }
        }
    }
}
