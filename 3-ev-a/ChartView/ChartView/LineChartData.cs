using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartView
{
    public class LineSeries
    {
        public string SeriesName { get; set; }
        public Color LineColor { get; set; }
        public List<ChartPoint> Points { get; set; }
    }

    public class ChartPoint
    {
        public Month Month { get; }
        public double Value { get; }

        public ChartPoint(Month month, double value)
        {
            Month = month;
            Value = value;
        }
    }
}
