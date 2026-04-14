using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp.Components
{
    public partial class FormBorderComponent : UserControl
    {
        Timer minimizeTimer;
        int targetHeight;
        int targetWidth;
        Color normalGray = Color.FromArgb(220, 220, 220);
        Color clickedGray = Color.FromArgb(200, 200, 200);
        public FormBorderComponent()
        {
            InitializeComponent();
            minimizeTimer = new Timer();
            minimizeTimer.Interval = 10;
            minimizeTimer.Tick += MinimizeTimerTick;
        }

        private void MinimizeTimerTick(object sender, EventArgs e)
        {
            Form form = FindForm();
            if (form == null) return;

            if (form.Height > 80 && form.Width > 150)
            {
                form.Height = Math.Max(80, form.Height - 30);
                form.Width = Math.Max(150, form.Width - 30);
                form.Opacity = Math.Max(0.2, form.Opacity - 0.05);
            }
            else
            {
                minimizeTimer.Stop();

                form.Opacity = 1;
                form.Height = targetHeight;
                form.Width = targetWidth;

                form.WindowState = FormWindowState.Minimized;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ManageLocationAndSize();
        }

        private void ManageLocationAndSize()
        {
            closeButton.Location = new Point(Width - closeButton.Width, 0);
            minimizeButton.Location = new Point(closeButton.Location.X - minimizeButton.Width, 0);
            closeButton.Height = Height;
            minimizeButton.Height = Height;
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            var form = FindForm();
            if (form != null)
                form.Close();
        }

        private void MinimizeButtonClick(object sender, EventArgs e)
        {
            Form form = FindForm();
            if (form == null) return;

            targetHeight = form.Height;
            targetWidth = form.Width;

            minimizeTimer.Start();
        }

        bool isMouseDown;
        Point lastPoint;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.X < closeButton.Location.X)
            {
                isMouseDown = true;
                lastPoint = e.Location;
                BackColor = clickedGray;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!isMouseDown) return;

            Form form = FindForm();
            if (form == null) return;

            form.Left += e.X - lastPoint.X;
            form.Top += e.Y - lastPoint.Y;

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isMouseDown = false;
            BackColor = normalGray;
        }

    }
}
