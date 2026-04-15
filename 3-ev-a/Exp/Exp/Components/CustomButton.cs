using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp.Components
{
    class CustomButton : Control
    {
        private int _cornerRadius = 10;
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(0, value);
            }
        }

        private Color _buttonColor;
        public Color ButtonColor
        {
            get => _buttonColor;
            set => _buttonColor = value;
        }

        Rectangle buttonRectangle;
        public CustomButton()
        {
            DoubleBuffered = true;
            Paint += PaintButton;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }


        private void PaintButton(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            MakeCornerRadius(g);
            WriteText(g);
        }

        private void WriteText(Graphics g)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Text = "Button";
            }
            SizeF measureString = g.MeasureString(Text, Font);
            g.DrawString(Text, Font, new SolidBrush(ForeColor), (Width / 2) - (measureString.Width / 2), (Height / 2) - (measureString.Height / 2));
           
        }


        private void MakeCornerRadius(Graphics g)
        {
            buttonRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            int diameter = _cornerRadius * 2;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(buttonRectangle.X, buttonRectangle.Y, diameter, diameter, 180, 90);
                path.AddArc(buttonRectangle.Right - diameter, buttonRectangle.Y, diameter, diameter, 270, 90);
                path.AddArc(buttonRectangle.Right - diameter, buttonRectangle.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(buttonRectangle.X, buttonRectangle.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                using (Brush brush = new SolidBrush(_buttonColor))
                {
                    g.FillPath(brush, path);
                }
            }
        }
    }
}
