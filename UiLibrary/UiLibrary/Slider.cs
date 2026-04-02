using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace UiLibrary
{
    public class Slider : Control
    {
        Rectangle mainRectangle;
        Rectangle topRectangle;
        Rectangle valueRectangle;
        Rectangle bottomRectangle;
        Rectangle levelRectangle;

        private int _currentValue;
        public int CurrentValue
        {
            get => _currentValue;
        }

        bool isMouseMove = false;
        Point currentLocation;
        Color primaryColor = Color.FromArgb(0, 122, 204);
        public Slider()
        {
            DoubleBuffered = true;
            Size = new Size(200, 50);
            UpdateRectangles();
            Paint += PagePaint;
        }

        private void UpdateRectangles()
        {
            mainRectangle = new Rectangle(
                5,
                5,
                Width - 10,
                Height - 10
            );

            topRectangle = new Rectangle(
                mainRectangle.X, mainRectangle.Y, mainRectangle.Width, 20
                );
            valueRectangle = new Rectangle(
                mainRectangle.X, mainRectangle.Bottom - 20, mainRectangle.Width, 25
                );

            bottomRectangle = new Rectangle(
                mainRectangle.X, valueRectangle.Top - 20, mainRectangle.Width, 20
                );

            levelRectangle = new Rectangle();

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRectangles();
            Invalidate();
        }

        private void PagePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawBorder(g);
            DrawTopRectangle(g);
            DrawBottomRectangle(g);
            DrawLevelRectangle(g);
            DrawValueRectangle(g);
        }

        private void DrawLevelRectangle(Graphics g)
        {
            int totalHeight = bottomRectangle.Top - topRectangle.Bottom;

            if (isMouseMove)
            {
                using (Brush brush = new SolidBrush(primaryColor))
                {
                    levelRectangle.X = mainRectangle.X;
                    levelRectangle.Y = currentLocation.Y;
                    levelRectangle.Width = mainRectangle.Width;
                    levelRectangle.Height = bottomRectangle.Top - levelRectangle.Y;

                    g.FillRectangle(brush, levelRectangle);
                    int currentHeight = bottomRectangle.Top - currentLocation.Y;
                    _currentValue = (currentHeight * 100) / totalHeight;
                }
            }
            else
            {

                int currentHeight = (totalHeight * _currentValue) / 100;
                // MessageBox.Show(currentHeight.ToString());
                levelRectangle.X = mainRectangle.X;
                levelRectangle.Y = bottomRectangle.Top - currentHeight;
                levelRectangle.Width = mainRectangle.Width;
                levelRectangle.Height = bottomRectangle.Top - levelRectangle.Y;
                //MessageBox.Show(levelRectangle.Y.ToString());
                using (Brush brush = new SolidBrush(primaryColor))
                {
                    g.FillRectangle(brush, levelRectangle);
                }
            }
        }

        private void DrawBottomRectangle(Graphics g)
        {
            using (Brush brush = new SolidBrush(primaryColor))
            {
                g.FillRectangle(brush, bottomRectangle);
            }

            using (Brush brush = new SolidBrush(Color.White))
            {

                PointF[] point = new PointF[]
                {
                    new PointF(bottomRectangle.X+((bottomRectangle.Width/2)-15),bottomRectangle.Y+5),
                    new PointF(bottomRectangle.X+((bottomRectangle.Width/2)+15),bottomRectangle.Y+5),
                    new PointF(bottomRectangle.Width/2+3,bottomRectangle.Bottom-2)
                };

                g.FillPolygon(brush, point);
            }

        }

        private void DrawValueRectangle(Graphics g)
        {

            using (Brush brush = new SolidBrush(primaryColor))
            {
                int size = 11;
                int height = 0;
                if (_currentValue > 9)
                {
                    size = 11;
                    height = 4;
                }

                if (_currentValue == 100)
                {
                    size = 11;
                    height = 8;
                }

                Font font = new Font("Arial", size, FontStyle.Bold);
                SizeF fontSize = g.MeasureString(_currentValue.ToString(), font);
                g.DrawString(_currentValue.ToString(), font, brush, new PointF(
                    valueRectangle.X + ((valueRectangle.Width - fontSize.Width) / 2),
                    valueRectangle.Y + ((valueRectangle.Height - fontSize.Width) / 2)+height-3
                    ));
                font.Dispose();
            }

        }

        private void DrawTopRectangle(Graphics g)
        {
            using (Brush brush = new SolidBrush(primaryColor))
            {
                g.FillRectangle(brush, topRectangle);
            }

            PointF[] trianglePoint = new PointF[]
            {
                new PointF(topRectangle.Width/2,5),
                new PointF((topRectangle.Width/2)+15,topRectangle.Bottom-4),
                new PointF((topRectangle.Width/2)-15,topRectangle.Bottom-4)
            };

            using (Brush brush = new SolidBrush(Color.White))
            {
                g.FillPolygon(brush, trianglePoint);
            }

        }

        private void DrawBorder(Graphics g)
        {
            using (Pen pen = new Pen(primaryColor, 2))
            {
                g.DrawRectangle(pen, mainRectangle);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (bottomRectangle.Contains(e.Location))
            {
                if (--_currentValue < 0)
                {
                    _currentValue = 0;
                    return;
                }
                Invalidate();
            }

            if (topRectangle.Contains(e.Location))
            {
                if (++_currentValue > 100)
                {
                    _currentValue = 100;
                    return;
                }
                Invalidate();
            }

            if (e.Location.Y < bottomRectangle.Top && e.Location.Y > topRectangle.Bottom)
            {
                isMouseMove = true;
                currentLocation = e.Location;
                Invalidate();
            }

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isMouseMove && e.Location.Y < bottomRectangle.Top && e.Location.Y > topRectangle.Bottom)
            {
                currentLocation = e.Location;
                currentLocation.Y = currentLocation.Y;
                Invalidate();
            }
            
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isMouseMove = false;
        }

    }
}
