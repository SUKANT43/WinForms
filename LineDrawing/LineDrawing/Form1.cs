using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace LineDrawing
{
    public partial class Form1 : Form
    {
        List<Point> ls = new List<Point>();
        bool makePoint = false;
        bool drawLine = false;
        Point currentPoint;
        Timer tm=new Timer();
        int timerCondition;
        public Form1()
        {
            InitializeComponent();
            Paint += FormPaint;
            MouseDoubleClick += FormDoubleClick;
            MouseDown += FormClick;
            tm.Interval = 1;
            tm.Tick += OnTimerEvent;
            //MouseUp += FormMouseUp;
        }
        public void FormPaint(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (makePoint)
            {
                for(int i = 0;i<ls.Count; i++)
                {
                    g.FillEllipse(Brushes.Black, ls[i].X-2, ls[i].Y-2, 5, 5);
                }
            }
            Pen p1 = new Pen(Color.Black,2);
            Pen p2 = new Pen(Color.Orange, 2);
            Pen p3 = new Pen(Color.Black, 200);

            GraphicsPath gp = new GraphicsPath();
            if (drawLine)
            {
                for (int i = 1; i <= timerCondition && i < ls.Count; i++)
                {
                    gp.AddLine(ls[i - 1], ls[i]);
                    if (gp.IsOutlineVisible(ls[i],p3))
                    {
                        g.DrawLine(p2, ls[i - 1], ls[i]);
                    }
                    else {
                        g.DrawLine(p1, ls[i - 1], ls[i]);
                    }
                }
            }
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            //MessageBox.Show("hi");
            if ( timerCondition < ls.Count-1)
            {
                timerCondition++;
                Invalidate();
            }
            else
            {
                tm.Stop();
            }
        }


        public void FormDoubleClick(object s,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                makePoint = true;
                drawLine = true;
                Invalidate();
                if (ls.Count > 1)
                {
                    tm.Start();
                }
            }
        }

        public void FormClick(object s,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timerCondition = 0;
                makePoint = true;
                drawLine = false;
                currentPoint = e.Location;
                ls.Add(e.Location);
                this.Invalidate();
            }
        }

        public void FormMouseUp(object s,MouseEventArgs e)
        {
            makePoint = false;
            drawLine = false;
        }
    }
}
