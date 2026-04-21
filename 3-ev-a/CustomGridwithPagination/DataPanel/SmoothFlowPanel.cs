using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPanel
{
    public class SmoothFlowPanel : FlowLayoutPanel
    {
        public SmoothFlowPanel()
        {
            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;
            this.WrapContents = true;
            this.AutoScroll = true;
            this.Dock = DockStyle.Fill;
        }
    }
}
