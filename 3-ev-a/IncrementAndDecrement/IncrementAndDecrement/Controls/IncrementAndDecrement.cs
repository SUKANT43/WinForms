using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncrementAndDecrement.Controls
{
    public class IncrementAndDecrement : Control
    {
        private int _start;
        Rectangle incRect = new Rectangle(0, 0, 0, 0);
        Rectangle valueRect = new Rectangle();
        Rectangle decRect = new Rectangle();
        Point previousLocation;

        public int Start
        {
            get => _start;
            set
            {
                _start = value;
            }
        }

        private int _end;
        public int End
        {
            get => _end;
            set
            {
                _end = value;
            }
        }

        private int _currentValue;
        public int CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
            }
        }

        public IncrementAndDecrement()
        {
            DoubleBuffered = true;
            Paint += PagePaint;
            AlignRectangle();
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AlignRectangle();
            Invalidate();
        }

        private void AlignRectangle()
        {
            incRect.Location = new Point(5, 0);
            incRect.Size = new Size((Width / 3) - 10, Height - 2);

            valueRect.Location = new Point(incRect.Right + 10, 0);
            valueRect.Size = new Size((Width / 3) - 10, Height - 2);

            decRect.Location = new Point(valueRect.Right + 10, 0);
            decRect.Size = new Size((Width / 3) - 10, Height - 2);

        }

        private void PagePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawValue(g);
            DrawIncrement(g);
            DrawDecrement(g);
        }

        private void DrawIncrement(Graphics g)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            int diameter = radius * 2;
            path.AddArc(incRect.X, incRect.Y, diameter, diameter, 180, 90);
            path.AddArc(incRect.Right - diameter, incRect.Y, diameter, diameter, 270, 90);
            path.AddArc(incRect.Right - diameter, incRect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(incRect.X, incRect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            g.DrawPath(new Pen(Color.Black, 2), path);

            using (Font font = new Font("Arial", incRect.Width / 2))
            {
                SizeF textSize = g.MeasureString("+", font);


                float x = incRect.X + (incRect.Width - textSize.Width) / 2;
                float y = incRect.Y + (incRect.Height - textSize.Height) / 2;

                g.DrawString("+", font, Brushes.Black, x, y);
            }
        }


        private void DrawValue(Graphics g)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            int diameter = radius * 2;
            path.AddArc(valueRect.X, valueRect.Y, diameter, diameter, 180, 90);
            path.AddArc(valueRect.Right - diameter, valueRect.Y, diameter, diameter, 270, 90);
            path.AddArc(valueRect.Right - diameter, valueRect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(valueRect.X, valueRect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            g.DrawPath(new Pen(Color.Black, 2), path);
            float fontSize = valueRect.Width / 2f;
            string text = _currentValue.ToString();

            SizeF valueSize;
            Font font;

            do
            {
                font = new Font("Arial", fontSize, FontStyle.Bold);
                valueSize = g.MeasureString(text, font);

                if (valueSize.Width > valueRect.Width - 10)
                {
                    font.Dispose();
                    fontSize--;
                }
                else
                {
                    break;
                }

            } while (fontSize > 6);

            using (font)
            {
                float x = valueRect.X + (valueRect.Width - valueSize.Width) / 2;
                float y = valueRect.Y + (valueRect.Height - valueSize.Height) / 2;

                g.DrawString(text, font, Brushes.Black, x, y);
            }
        }

        private void DrawDecrement(Graphics g)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            int diameter = radius * 2;
            path.AddArc(decRect.X, decRect.Y, diameter, diameter, 180, 90);
            path.AddArc(decRect.Right - diameter, decRect.Y, diameter, diameter, 270, 90);
            path.AddArc(decRect.Right - diameter, decRect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(decRect.X, decRect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            g.DrawPath(new Pen(Color.Black, 2), path);

            using (Font font = new Font("Arial", Height / 2, FontStyle.Bold))
            {
                SizeF textSize = g.MeasureString("-", font);
                float x = decRect.X + (decRect.Width - textSize.Width) / 2;
                float y = decRect.Y + (decRect.Height - textSize.Height) / 2;
                g.DrawString("-", font, Brushes.Black, x, y);
            }


        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (incRect.Contains(e.Location))
            {
                _currentValue += 1;
                Invalidate();
            }
            if (decRect.Contains(e.Location))
            {
                _currentValue -= 1;
                Invalidate();
            }
        }

        bool isMove = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            isMove = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if ( e.X > previousLocation.X&&isMove)
            {
                previousLocation = e.Location;
                _currentValue++;
                Invalidate();
            }

          else if(isMove)
            {
                previousLocation = e.Location;
                _currentValue--;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            previousLocation = new Point();
            isMove = false;
        }

    }
}

