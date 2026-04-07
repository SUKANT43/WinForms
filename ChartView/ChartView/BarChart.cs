using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartView
{

    class BarChart : Control
    {

        private List<ChartData> dataList = new List<ChartData>();



        public BarChart()
        {
            Paint += PaintChart;
            DoubleBuffered = true;
            dataList.Add(new ChartData("Jan", 10, Color.FromArgb(255, 99, 132)));   // vibrant pink-red
            dataList.Add(new ChartData("Feb", 70, Color.FromArgb(54, 162, 235)));   // bright blue
            dataList.Add(new ChartData("Mar", 55, Color.FromArgb(75, 192, 192)));   // teal
            dataList.Add(new ChartData("Apr", 90, Color.FromArgb(255, 159, 64)));   // orange
            dataList.Add(new ChartData("May", 65, Color.FromArgb(153, 102, 255)));  // purple
            dataList.Add(new ChartData("Jun", 65, Color.FromArgb(255, 205, 86)));   // yellow
            dataList.Add(new ChartData("Jul", 65, Color.FromArgb(255, 99, 255)));   // magenta
            dataList.Add(new ChartData("Aug", 65, Color.FromArgb(0, 200, 83)));     // green
            dataList.Add(new ChartData("Sep", 65, Color.FromArgb(0, 188, 212)));    // cyan

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        private void PaintChart(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawLine(g);
            DrawGraph(g);
        }

        private void DrawGraph(Graphics g)
        {
            DrawBar(g);
        }

        private void DrawBar(Graphics g)
        {
            try
            {
                            int gap = 10;
            int padding = 10;

            int barWidth = ((Width - (padding * 2)) - (gap * (dataList.Count - 1))) / dataList.Count;
            int currentX = gap+(barWidth/2) ;

            int maxHeight = Height - 20;
            double maxValue = dataList.Max(x => x.Value);

            foreach (var ls in dataList)
            {
                int barHeight = (int)((ls.Value / maxValue) * maxHeight);

                using (Pen p = new Pen(ls.Color, barWidth))
                {
                    g.DrawLine(
                        p,
                        new Point(currentX, Height - 10),
                        new Point(currentX, Height - 10 - barHeight)
                    );
                }

                DrawValue(g, currentX, Height - 10 - barHeight, ls.Value,barWidth);

                currentX += barWidth + gap;
            }

            }
            catch(Exception e)
            {

            }
        }

        private void DrawValue(Graphics g, int currentX, int currentY,double value,int barWidth)
        {
            Font font = new Font("Ariel",barWidth/4, FontStyle.Bold);
            using(Brush brush=new SolidBrush(Color.Black))
            {
                SizeF fontSize = g.MeasureString(value.ToString(), font);
                g.DrawString(value.ToString(), font, brush, new PointF(currentX - (fontSize.Width / 2), (Height - 20)-(((Height-20)-currentY)/2)));
            }
        }

        private void DrawLine(Graphics g)
        {
            using (Pen p = new Pen(Brushes.Black, 2))
            {
                g.DrawLine(p, new Point(10, Height - 10), new Point(10, 10));
                g.DrawLine(p, new Point(10, Height - 10), new Point(Width - 10, Height - 10));
            }
        }
    }
}
