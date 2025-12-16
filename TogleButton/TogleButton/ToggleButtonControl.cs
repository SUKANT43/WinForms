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
namespace TogleButton
{
    public partial class ToggleButtonControl : UserControl
    {
        Rectangle toogleRect;
        bool isClick;
        Label textLabel=new Label();
        public ToggleButtonControl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            toogleRect = new Rectangle(50, 50, 100, 35);
            Paint += PaintScreen;
            MouseDown += MouseDownEvent;
            textLabel.Click += TextLabelClick;
        }
        private void PaintScreen(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRect(toogleRect, toogleRect.Height))
            {
                using (SolidBrush trackBrush = new SolidBrush(isClick ? Color.Blue : Color.Black))
                {
                    g.FillPath(trackBrush, path);
                }
            }

            int thumbSize = toogleRect.Height - 6;
            int thumbX = isClick
                ?toogleRect.Right-thumbSize-2
                :toogleRect.Left + 3;

            Rectangle thumbRect = new Rectangle(
                thumbX,
                toogleRect.Top + 3,
                thumbSize,
                thumbSize
                );

            if (isClick)
            {
                textLabel.Text = "Off";
                textLabel.AutoSize = true;
                textLabel.ForeColor = Color.White;
                textLabel.BackColor = Color.Blue;
                textLabel.Location = new Point(toogleRect.Left+10,toogleRect.Top+8);
                textLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                Controls.Add(textLabel);
            }
            else
            {
                textLabel.Text = "On";
                textLabel.AutoSize = true;
                textLabel.ForeColor = Color.White;
                textLabel.BackColor = Color.Black;
                textLabel.Location = new Point(toogleRect.Right - 35, toogleRect.Top + 8);
                textLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                Controls.Add(textLabel);

            }

            using (SolidBrush thumbBrush = new SolidBrush(Color.White))
            {
                g.FillEllipse(thumbBrush, thumbRect);
            }
        }

        private void MouseDownEvent(object s,MouseEventArgs e)
        {
            if (toogleRect.Contains(e.Location))
            {
                isClick = !isClick;
                Invalidate();
            }
        }

        private void TextLabelClick(object s,EventArgs e)
        {
            isClick = !isClick;
            Invalidate();
        }

        GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius;

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }

}

