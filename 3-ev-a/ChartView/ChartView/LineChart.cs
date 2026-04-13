using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        bool isMouseMoving;
        Point currentPoint;
        double max;
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
                        new ChartPoint(Month.Feb, 300),
                        new ChartPoint(Month.Mar, 100),
                        new ChartPoint(Month.Apr, 110),
                        new ChartPoint(Month.May, 105),
                        new ChartPoint(Month.Jun, 130),
                        new ChartPoint(Month.Jul, 150),
                        new ChartPoint(Month.Aug, 145),
                        new ChartPoint(Month.Sep, 140),
                        new ChartPoint(Month.Oct, 155),
                        new ChartPoint(Month.Nov, 170),
                        new ChartPoint(Month.Dec, 190),
                        //new ChartPoint(Month.Jan, 300),

                    }
                },
                new LineSeries
                {
                    SeriesName = "Savings",
                    LineColor = Color.Green,
                    Points = new List<ChartPoint>
                    {
                        new ChartPoint(Month.Jan, 180),
                        new ChartPoint(Month.Feb, 90),
                        new ChartPoint(Month.Mar, 100),
                        new ChartPoint(Month.Apr, 110),
                        new ChartPoint(Month.May, 130),
                        new ChartPoint(Month.Jun, 125),
                        new ChartPoint(Month.Jul, 150),
                        new ChartPoint(Month.Aug, 145),
                        new ChartPoint(Month.Sep, 180),
                        new ChartPoint(Month.Oct, 175),
                        new ChartPoint(Month.Nov, 200),
                        new ChartPoint(Month.Dec,300 )
                    }
                }

            };
            max = list.SelectMany(series => series.Points).Max(point => point.Value);

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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawLine(g);
            DrawMonth(g);
            DrawGraph(g);
            DrawGraphShower(g);
            DrawValue(g);
        }

        private void DrawValue(Graphics g)
        {
            if (isMouseMoving)
            {
                GetHoveredMonth();

                if (selectedMonth == Month.None)
                {
                    return;
                }


                foreach (var ls in list)
                {
                    for (int i = 0; i < ls.Points.Count; i++)
                    {
                        if (selectedMonth == ls.Points[i].Month)
                        {
                            using (Font font = new Font("Arial", 9, FontStyle.Bold))
                            using (Brush brush = new SolidBrush(ls.LineColor))
                            {
                                SizeF stringSize = g.MeasureString(ls.Points[i].Value.ToString(), font);

                                if ((float)GetY(ls.Points[i].Value) > currentPoint.Y - 5)
                                {
                                    g.DrawString(ls.Points[i].Value.ToString(), font, brush, new PointF(monthPoint[selectedMonth], (float)GetY(ls.Points[i].Value)));
                                }
                            }
                        }
                    }
                }

            }

        }
        Month selectedMonth;
        private void GetHoveredMonth()
        {
            const int tolerance = 5;

            foreach (var item in monthPoint)
            {
                if (Math.Abs(item.Value - currentPoint.X + 10) <= tolerance)
                {
                    selectedMonth = item.Key;
                    return;
                }
            }

            selectedMonth = Month.None;
        }

        private void DrawGraphShower(Graphics g)
        {
            if (isMouseMoving)
            {
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                    g.DrawLine(pen, new Point(currentPoint.X, Height - 30), new Point(currentPoint.X, currentPoint.Y));
                    g.DrawLine(pen, new Point(10, currentPoint.Y), new Point(currentPoint.X, currentPoint.Y));
                }
            }
        }

        private void DrawGraph(Graphics g)
        {
            foreach (var ls in list)
            {
                for (int i = 1; i < ls.Points.Count; i++)
                {
                    using (Pen pen = new Pen(ls.LineColor, 2))
                    {
                        g.DrawLine(pen, monthPoint[ls.Points[i - 1].Month] + 10, (float)GetY(ls.Points[i - 1].Value), monthPoint[ls.Points[i].Month] + 10, (float)GetY(ls.Points[i].Value));
                    }
                }
            }

        }

       
        private double GetY(double p)
        {
            double y = (Height - 30) - ((p / max) * (Height - 30));
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
                g.DrawLine(pen, new Point(10, Height - 30), new Point(10, 0));
                g.DrawLine(pen, new Point(10, Height - 30), new Point(Width - 10, Height - 30));
            }
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            try
            {
                if (e.X > monthPoint[Month.Jan] && e.X < monthPoint[Month.Dec] + 10 && e.Y < Height - 30 && e.Y >= 0)
                {
                    isMouseMoving = true;
                    currentPoint = e.Location;
                    Invalidate();
                }

                else
                {
                    isMouseMoving = false;
                    Invalidate();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            isMouseMoving = false;
            Invalidate();
        }

    }
}
