using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
namespace SnakeGame
{
    public partial class Form1 : Form
    {
        Point linePoint;
        Point ballPoint;
        Timer t;
        int ballDX = 30;  
        int ballDY = 30;   

        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember(
            "DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            panel1,
            new object[] { true }
            );


            MaximumSize = new Size(900, 800);
            MinimumSize = new Size(900, 800);
            t = new Timer();
            t.Interval += 10;
            t.Tick += (s, e) => { panel1.Invalidate(); };
            t.Start();
            linePoint = new Point(0,700);
            ballPoint = new Point();
            panel1.Paint += PagePaint;
            KeyDown+= LineMove;
        }
        public void LineMove(object s, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                if (linePoint.X + 170 >= panel1.Width)
                    return;

                linePoint.X += 100;
                panel1.Invalidate();
            }

            if (e.KeyData == Keys.Left)
            {
                if (linePoint.X - 100 < 0)
                    return;

                linePoint.X -= 100;
                panel1.Invalidate();
            }
        }

        public void PagePaint(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawLine(g);
            DrawBall(g);
        }

        public void DrawLine(Graphics g)
        {
            using(Pen p=new Pen(Color.LightGray,4))
            {
                g.DrawLine(p,linePoint.X,linePoint.Y,linePoint.X+100,linePoint.Y);
            }
        }

        public void DrawBall(Graphics g)
        {
            ControlBallPoint();
            using (SolidBrush b = new SolidBrush(Color.Red))
            {
                g.FillEllipse(b,ballPoint.X,ballPoint.Y,50,50);
            }
        }

        public void ControlBallPoint()
        {
            ballPoint.X += ballDX;
            ballPoint.Y += ballDY;

            if (ballPoint.X <= 0 || ballPoint.X + 50 >= panel1.Width)
            {
                ballDX = -ballDX;
            }

            if (ballPoint.Y <= 0)
            {
                ballDY = -ballDY;
            }

            Rectangle ballRect = new Rectangle(ballPoint.X, ballPoint.Y, 50, 50);
            Rectangle lineRect = new Rectangle(linePoint.X, linePoint.Y - 5, 100, 10);

            if (ballRect.IntersectsWith(lineRect))
            {
                ballDY = -ballDY;
                ballPoint.Y = linePoint.Y - 50;
            }

            if (ballRect.Location.Y > Height)
            {
                ballPoint = new Point();
                ballDX = 30;
                ballDY = 30;
            }
        }

    }
}
