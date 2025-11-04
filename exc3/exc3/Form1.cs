using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exc3
{
    public partial class Form1 : Form
    {
        private bool isDragging=false;
        private Point dragStartPoint;

        public Form1()
        {
            InitializeComponent();
            MouseClick += ButtonClick;
            dragPanel.MouseClick += ButtonClick;

            dragPanel.MouseDown += MouseDownDrag;
            dragPanel.MouseUp += MouseUpDrag;
            dragPanel.MouseMove +=MouseMoveDrag;
        }
        private void ButtonClick(object s, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                int x = e.X - (dragPanel.Width / 2);
                int y = e.Y - (dragPanel.Height / 2);
                x = Math.Max(0, Math.Min(x, ClientSize.Width - dragPanel.Width));
                y = Math.Max(0, Math.Min(y, ClientSize.Height - dragPanel.Height));

                dragPanel.Location = new Point(x, y);
            }

            if (e.Button == MouseButtons.Right)
            {
                dragPanel.Size = new Size(100, 100);
                dragPanel.Location = new Point(0, 0);
            }
        }

        public void MouseDownDrag(object s,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isDragging = true;
                dragStartPoint = e.Location;
                dragPanel.Cursor = Cursors.SizeAll;
            }
        }

        public void MouseMoveDrag(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                int dx = e.X - dragStartPoint.X;
                int dy = e.Y - dragStartPoint.Y;

                int newX = dragPanel.Left + dx;
                int newY = dragPanel.Top + dy;

                newX = Math.Max(0, Math.Min(newX, ClientSize.Width - dragPanel.Width));
                newY = Math.Max(0, Math.Min(newY, ClientSize.Height - dragPanel.Height));

                dragPanel.Location = new Point(newX, newY);
            }
        }

                private void MouseUpDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isDragging = false;
                dragPanel.Cursor = Cursors.Default;
            }
        }

    }
}
