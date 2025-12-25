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
        public Form1()//clock form
        {
            DoubleBuffered = true;
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

          // WriteTime(g, baseRectangle);
            MiantainClockNeedel(g);
            MiantainClockNeedel(g);
            MiantainClockNeedel(g);

        }

        public void MiantainClockNeedel(Graphics g)
        {
            DateTime dt = DateTime.Now;

            float cx = baseRectangle.X + baseRectangle.Width / 2f;
            float cy = baseRectangle.Y + baseRectangle.Height / 2f;
            float radius = Math.Min(baseRectangle.Width, baseRectangle.Height) / 2f;

            // ================= SECOND HAND =================
            float secAngle = (float)(Math.PI / 180 * (dt.Second * 6 - 90));
            float secX = cx + radius * 0.9f * (float)Math.Cos(secAngle);
            float secY = cy + radius * 0.9f * (float)Math.Sin(secAngle);

            using (Pen p = new Pen(Color.Red, 2f))
                g.DrawLine(p, cx, cy, secX, secY);

            // ================= MINUTE HAND =================
            float minAngle = (float)(Math.PI / 180 * ((dt.Minute * 6 + dt.Second * 0.1f) - 90));
            float minX = cx + radius * 0.75f * (float)Math.Cos(minAngle);
            float minY = cy + radius * 0.75f * (float)Math.Sin(minAngle);

            using (Pen p = new Pen(Color.Black, 3f))
                g.DrawLine(p, cx, cy, minX, minY);

            // ================= HOUR HAND =================
            float hourAngle = (float)(Math.PI / 180 *
                (((dt.Hour % 12) * 30 + dt.Minute * 0.5f) - 90));
            float hourX = cx + radius * 0.55f * (float)Math.Cos(hourAngle);
            float hourY = cy + radius * 0.55f * (float)Math.Sin(hourAngle);

            using (Pen p = new Pen(Color.Black, 4f))
                g.DrawLine(p, cx, cy, hourX, hourY);

            // ================= CENTER DOT =================
           // using (Brush b = Brushes.Black)
                //g.FillEllipse(b, cx - 4, cy - 4, 8, 8);
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
