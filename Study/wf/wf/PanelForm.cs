using System;
using System.Drawing;
using System.Windows.Forms;

namespace wf
{
    public partial class PanelForm : Form
    {
        Panel p, e1, e2;

        public PanelForm()
        {
            MinimumSize = new Size(400, 300);

            // Parent panel
            p = new Panel
            {
                BackColor = Color.Blue,
                Anchor = AnchorStyles.None
            };

            // Child panels
            e1 = new Panel { BackColor = Color.Red };
            e2 = new Panel { BackColor = Color.Red };

            // Positioning + resizing logic
            void ResizeAndCenterPanels()
            {
                // Scale parent panel to ~80% of form
                int pw = (int)(ClientSize.Width * 0.8);
                int ph = (int)(ClientSize.Height * 0.8);
                p.Size = new Size(pw, ph);

                // Center parent in form
                p.Location = new Point(
                    (ClientSize.Width - p.Width) / 2,
                    (ClientSize.Height - p.Height) / 2
                );

                // Make child panels half the width and 40% height of parent
                int childW = (int)(p.Width * 0.5);
                int childH = (int)(p.Height * 0.4);

                e1.Size = new Size(childW, childH);
                e2.Size = new Size(childW, childH);

                // e1 at top center
                e1.Location = new Point(
                    (p.Width - e1.Width) / 2,
                    (p.Height - (2 * childH + 50)) / 2 // leave space for both in middle
                );

                // e2 below e1 with spacing
                e2.Location = new Point(
                    (p.Width - e2.Width) / 2,
                    e1.Bottom + 50
                );
            }

            Load += (s, e) => ResizeAndCenterPanels();
            Resize += (s, e) => ResizeAndCenterPanels();

            // Add controls
            p.Controls.Add(e1);
            p.Controls.Add(e2);
            Controls.Add(p);
        }
    }
}
