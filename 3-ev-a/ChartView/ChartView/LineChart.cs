using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartView
{
    public class LineChart : Control
    {
        List<LineSeries> list;
        Dictionary<Month, float> monthPoint;
        public LineChart()
        {
            DoubleBuffered = true;
            monthPoint = new Dictionary<Month, float>();
            list = new List<LineSeries>
            {
                new LineSeries
                {
                    SeriesName = "Sales",
                    LineColor = Color.DodgerBlue,
                    Points = new List<ChartPoint>
                    {
                        new ChartPoint(Month.Jan, 120),
                        new ChartPoint(Month.Feb, 145),
                        new ChartPoint(Month.Mar, 160),
                        new ChartPoint(Month.Apr, 180),
                        new ChartPoint(Month.May, 170),
                        new ChartPoint(Month.Jun, 210),
                        new ChartPoint(Month.Jul, 250),
                        new ChartPoint(Month.Aug, 240),
                        new ChartPoint(Month.Sep, 220),
                        new ChartPoint(Month.Oct, 260),
                        new ChartPoint(Month.Nov, 290),
                        new ChartPoint(Month.Dec, 320)
                    }
                },

                new LineSeries
                {
                    SeriesName = "Expenses",
                    LineColor = Color.OrangeRed,
                    Points = new List<ChartPoint>
                    {
                        new ChartPoint(Month.Jan, 80),
                        new ChartPoint(Month.Feb, 90),
                        new ChartPoint(Month.Mar, 100),
                        new ChartPoint(Month.Apr, 110),
                        new ChartPoint(Month.May, 105),
                        new ChartPoint(Month.Jun, 130),
                        new ChartPoint(Month.Jul, 150),
                        new ChartPoint(Month.Aug, 145),
                        new ChartPoint(Month.Sep, 140),
                        new ChartPoint(Month.Oct, 155),
                        new ChartPoint(Month.Nov, 170),
                        new ChartPoint(Month.Dec, 190)
                    }
                }
            };
            Paint += LinePaint;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        private void LinePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawLine(g);
            DrawMonth(g);
            DrawGraph(g);
        }

        private void DrawGraph(Graphics g)
        {

            foreach(var ls in list)
            {
                for(int i=1;i<ls.Points.Count;i++)
                {
                    using (Pen pen = new Pen(ls.LineColor,2))
                    {
                        g.DrawLine(pen, monthPoint[ls.Points[i - 1].Month], (float)GetY(ls.Points[i - 1].Value),monthPoint[ls.Points[i].Month],(float)GetY(ls.Points[i].Value));
                    }
                }
            }

        }

        private double GetY(double p)
        {
             double max = list.SelectMany(series => series.Points).Max(point => point.Value);
            double y = ((p / max) * (Height - 30));
            return y;

        }

        private void DrawMonth(Graphics g)
        {
            monthPoint.Clear();
            int leftPadding = 20;
            int bottomY = Height - 30;
            int sectionWidth = (Width - 20) / 12;

            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                for (int i = 1; i <= 12; i++)
                {
                    string monthText = ((Month)i).ToString();

                    SizeF size = g.MeasureString(monthText, font);

                    float x = leftPadding + ((i - 1) * sectionWidth) + ((sectionWidth - size.Width) / 2);

                    monthPoint.Add((Month)i, x);

                    g.DrawString(monthText, font, brush, x, bottomY);
                }
            }
        }
        private void DrawLine(Graphics g)
        {
            using (Pen pen = new Pen(Brushes.Black, 2))
            {
                g.DrawLine(pen, new Point(10, Height - 30), new Point(10, 10));
                g.DrawLine(pen, new Point(10, Height - 30), new Point(Width - 10, Height - 30));
            }
        }
    }
}
