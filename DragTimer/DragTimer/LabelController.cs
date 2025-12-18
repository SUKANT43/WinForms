using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DragTimer
{
    public partial class LabelController : UserControl
    {
        private string displayText = "0";

        public string DisplayText
        {
            get => displayText;
            set
            {
                displayText = value;
                Invalidate();
            }
        }

        public Font DisplayFont { get; set; } = new Font("Segoe UI", 12, FontStyle.Bold);

        public Color TextColor { get; set; } = Color.Black;

        public LabelController()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Size = new Size(150, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (SolidBrush brush = new SolidBrush(TextColor))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                g.DrawString(
                    displayText,
                    DisplayFont,
                    brush,
                    ClientRectangle,
                    sf
                );
            }
        }
    }
}
