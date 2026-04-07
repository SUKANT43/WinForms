using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartView
{
    class ChartDataViewer : Control
    {
        private List<ChartData> dataList = new List<ChartData>();


        public ChartDataViewer()
        {
            DoubleBuffered = true;
            Paint += PaintData;
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


        private void PaintData(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int padding = 10;
                int rowHeight = Height / dataList.Count;
                int fontSize = Math.Min(rowHeight / 3, Width - 10);

                using (Font font = new Font("Segoe UI", fontSize, FontStyle.Bold))
                {
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        int y = i * rowHeight + padding;

                        DrawColor(g, dataList[i], y, rowHeight);
                        DrawString(g, dataList[i], y, font);
                    }
                }
            }
            catch (Exception exception) { }

        }

        private void DrawColor(Graphics g, ChartData item, int y, int rowHeight)
        {
            int size = rowHeight / 2;

            using (Brush brush = new SolidBrush(item.Color))
            {
                g.FillEllipse(brush, 10, y, size, size);
            }
        }

        private void DrawString(Graphics g, ChartData item, int y, Font font)
        {
            g.DrawString(
                $"{item.Name} - {item.Value}",
                font,
                Brushes.Black,
                40,
                y
            );
        }

    }
}
