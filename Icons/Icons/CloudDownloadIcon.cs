using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Icons
{
    public class CloudDownloadCircleIcon : UserControl
    {
        public CloudDownloadCircleIcon()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Black; // matches your image background
            Size = new Size(200, 200);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int size = (int)(Math.Min(Width, Height) * 0.75f);
            int cx = (Width - size) / 2;
            int cy = (Height - size) / 2;

            float stroke = size * 0.07f;
            Color iconColor = Color.FromArgb(60, 190, 255);

            using (Pen p = new Pen(iconColor, stroke))
            {
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                p.LineJoin = LineJoin.Round;

                // =========================
                // CLOUD OUTLINE (3 arcs)
                // =========================

                int cloudW = (int)(size * 0.9f);
                int cloudH = (int)(size * 0.45f);
                int cloudX = cx + (size - cloudW) / 2;
                int cloudY = cy + (int)(size * 0.15f);

                // Left bump
                g.DrawArc(p,
                    cloudX,
                    cloudY,
                    cloudW / 2,
                    cloudH,
                    180,
                    180);

                // Right bump
                g.DrawArc(p,
                    cloudX + cloudW / 2,
                    cloudY,
                    cloudW / 2,
                    cloudH,
                    180,
                    180);

                // Top bump
                g.DrawArc(p,
                    cloudX + cloudW / 4,
                    cloudY - cloudH / 2,
                    cloudW / 2,
                    cloudH,
                    180,
                    180);

                // =========================
                // CIRCLE FOR ARROW
                // =========================

                int circleSize = (int)(size * 0.45f);
                int circleX = cx + (size - circleSize) / 2;
                int circleY = cy + (int)(size * 0.45f);

                Rectangle arrowCircle = new Rectangle(
                    circleX,
                    circleY,
                    circleSize,
                    circleSize
                );

                g.DrawEllipse(p, arrowCircle);

                // =========================
                // DOWNLOAD ARROW
                // =========================

                float arrowX = arrowCircle.Left + arrowCircle.Width / 2f;
                float arrowTop = arrowCircle.Top + arrowCircle.Height * 0.25f;
                float arrowBottom = arrowCircle.Bottom - arrowCircle.Height * 0.25f;

                // Arrow shaft
                g.DrawLine(p, arrowX, arrowTop, arrowX, arrowBottom);

                // Arrow head
                float headSize = circleSize * 0.18f;
                g.DrawLine(p,
                    arrowX - headSize,
                    arrowBottom - headSize,
                    arrowX,
                    arrowBottom);

                g.DrawLine(p,
                    arrowX + headSize,
                    arrowBottom - headSize,
                    arrowX,
                    arrowBottom);
            }
        }
    }
}
