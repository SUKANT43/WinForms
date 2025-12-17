using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Logos
{
    public partial class Form1 : Form
    {
        Rectangle baseRectangle;
        Font textFont;
        PointF[] hexagon;
        Timer t;
        public Form1()
        {
            Paint += PaintLogo;
            baseRectangle = new Rectangle(200, 200, 200, 150);
            textFont = new Font("Segoe UI", 10f, FontStyle.Bold);
             t = new Timer()
            {
                Interval=1000
            };
            t.Tick += TimerTick;
            t.Start();
            
        }
        private void TimerTick(object sender, EventArgs e)
        {
            Invalidate(); 
        }
        public void PaintLogo(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
             hexagon = CreateHexagon(baseRectangle);

            using (Brush b = new SolidBrush(Color.DeepSkyBlue))
                g.FillPolygon(b, hexagon);
            using (Pen p = new Pen(Color.Black))
                g.DrawLines(p, hexagon);

           WriteTime(g, baseRectangle);
            MiantainClockNeedel(g);
        }

        public void MiantainClockNeedel(Graphics g)
        {
            DateTime dt = DateTime.Now;
            int second = dt.Second;

            float cx = baseRectangle.X + baseRectangle.Width / 2f;
            float cy = baseRectangle.Y + baseRectangle.Height / 2f;
            float angle = (float)(Math.PI / 180 * (second * 6 - 90));
            float radius = Math.Min(baseRectangle.Width, baseRectangle.Height) / 2f;

            float x = cx + radius  * (float)Math.Cos(angle);
            float y = cy + radius  * (float)Math.Sin(angle);
            using (Pen p = new Pen(Color.Black))

                g.DrawLine(p, cx, cy, x, y);

        }

        public void WriteTime(Graphics g, Rectangle rect)
        {
            float cx = rect.X + rect.Width / 2f;
            float cy = rect.Y + rect.Height / 2f;
            float radius = Math.Min(rect.Width, rect.Height) / 2f;

            int time = 1;

            for (int i = 0; i < 59; i++)
            {
                if (i % 5 == 0)
                {
                    float angle = (float)(Math.PI / 180 * (6 * i - 90));

                    float x = cx + radius * (float)Math.Cos(angle);
                    float y = cy + radius * (float)Math.Sin(angle);

                    string text = time.ToString();
                    SizeF size = g.MeasureString(text, textFont);

                    g.DrawString(
                        text,
                        textFont,
                        Brushes.Black,
                      hexagon[i+1].X,
                        hexagon[i+1].Y
                    );

                    time++;
                }
            }
        }


        public PointF[] CreateHexagon(Rectangle rect)
        {
            float cx = rect.X + rect.Width / 2f;
            float cy = rect.Y + rect.Height / 2f;
            float radius = Math.Min(rect.Width, rect.Height);
           
            PointF[] pts = new PointF[60];
            for(int i = 0; i < 60; i++)
            {
                float angle = (float)(Math.PI / 180 * (6 * i - 90));
                pts[i] = new PointF(
                    cx+radius*(float)Math.Cos(angle),
                    cy+radius*(float)Math.Sin(angle)
                    );
                //MessageBox.Show($"cx:{cx} cy:{cy} s[i]X:{pts[i].X} s[i]Y:{pts[i].Y}");
            }
            return pts;
        }
    }
}
