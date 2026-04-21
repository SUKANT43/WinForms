using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPanel
{
    class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            this.SetStyle(ControlStyles.Opaque, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Parent != null)
            {
                Graphics g = e.Graphics;
                Rectangle rect = this.Bounds;

                Control parent = Parent;
                using (Bitmap bmp = new Bitmap(parent.Width, parent.Height))
                {
                    parent.DrawToBitmap(bmp, parent.ClientRectangle);
                    g.DrawImage(bmp, -Left, -Top);
                }
            }
        }
    }
}
