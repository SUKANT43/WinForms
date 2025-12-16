using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Clock
{
    public partial class ClockControl : UserControl
    {
        private Timer timer;
        public ClockControl()
        {
            DoubleBuffered = true;
            Size = new Size(300, 300);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => Invalidate();
            timer.Start();
        }
    }
}
