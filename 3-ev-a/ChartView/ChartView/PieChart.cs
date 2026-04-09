using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartView
{
    public class PieChart:Control
    {
        private List<ChartData> dataList = new List<ChartData>();
        public PieChart()
        {
            dataList.Add(new ChartData("Jan", 10, Color.FromArgb(255, 99, 132)));   // vibrant pink-red
            dataList.Add(new ChartData("Feb", 70, Color.FromArgb(54, 162, 235)));   // bright blue
            dataList.Add(new ChartData("Mar", 55, Color.FromArgb(75, 192, 192)));   // teal
            dataList.Add(new ChartData("Apr", 90, Color.FromArgb(255, 159, 64)));   // orange
            dataList.Add(new ChartData("May", 65, Color.FromArgb(153, 102, 255)));  // purple
            dataList.Add(new ChartData("Jun", 65, Color.FromArgb(255, 205, 86)));   // yellow
            dataList.Add(new ChartData("Jul", 65, Color.FromArgb(255, 99, 255)));   // magenta
            dataList.Add(new ChartData("Aug", 65, Color.FromArgb(0, 200, 83)));     // green
            dataList.Add(new ChartData("Sep", 65, Color.FromArgb(0, 188, 212)));    // cyan
            Paint += PaintPieChart;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        private void PaintPieChart(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawPie(g);
        }

        private void DrawPie(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            float start = 0;
            float total = dataList.Sum(e => e.Value);
            foreach(var ls in dataList)
            {
                float angle = 360f * ls.Value / total;
                using(Brush brush=new SolidBrush(ls.Color))
                {
                    g.FillPie(brush, rect, start, angle);
                    start += angle;
                }
            }
        }
    }
}
