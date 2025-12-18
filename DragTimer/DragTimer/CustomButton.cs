using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragTimer
{
    public partial class CustomButton : UserControl
    {
        private string text="button";
        private int width=160;
        private int height=50;
        private Color backgroundColor=Color.SkyBlue;
        private Color textColor=Color.Black;
        private float textSize = 10f;
        public string Text
        {
            set =>text=value;
            get => text;
        }

        public int Width
        {
            set => width = value;
            get => width;
        }

        public int Height
        {
            set => height = value;
            get =>height;
        }

        public Color BackgroundColor
        {
            set => backgroundColor = value;
            get => backgroundColor;
        }

        public Color TextColor
        {
            set => textColor = value;
            get => textColor;
        }

        public float TextSize
        {
            set => textSize = value;
            get => textSize;
        }

        private Rectangle customRectangle;
        private Font textFont;
        public CustomButton()
        {
            InitializeComponent();
            customRectangle = new Rectangle();
            Size = new Size(width, height);
            textFont = new Font("Segoe UI", textSize, FontStyle.Bold);
            Paint += PaintButton;
        }

        private void PaintButton(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            customRectangle.Size = new Size(width, height);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = CreateCurve(customRectangle,customRectangle.Height))
            {
                using (Brush b = new SolidBrush(backgroundColor))
                {
                    g.FillPath(b, path);
                    WriteText(g);
                }
            }
        }

        private void WriteText(Graphics g)
        {
            SizeF textSize = g.MeasureString(text, textFont);
            float x =(float)((customRectangle.X+ customRectangle.Width)-textSize.Width)/2;
            float y = (float)((customRectangle.Y + customRectangle.Height)-textSize.Height)/2;
            using(Brush b=new SolidBrush(Color.Black))
            {
                g.DrawString(text, textFont,b, x, y);
            }
        }

        private GraphicsPath CreateCurve(Rectangle r, int radius)
        {
            GraphicsPath path= new GraphicsPath();
            int d = radius;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
