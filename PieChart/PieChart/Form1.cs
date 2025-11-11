using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace PieChart
{
    public partial class Form1 : Form
    {
        float a=62, b=8, c=13, d=17;
        public Form1()
        {
            InitializeComponent();
            Paint += FormPaint;
        }
        public void FormPaint(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(100, 100, 300, 300);
            float aAngle = 360f * a / 100f;
            float bAngle = 360f * b / 100f;
            float cAngle = 360f * c / 100f;
            float dAngle = 360f * d / 100f;
            float start = 0;
            g.FillPie(Brushes.LightBlue, rect, start, aAngle);
            start += aAngle;
            g.FillPie(Brushes.LightGreen, rect, start, bAngle);
            start += bAngle;
            g.FillPie(Brushes.LightPink, rect, start, cAngle);
            start += cAngle;
            g.FillPie(Brushes.LightGoldenrodYellow, rect, start, dAngle);
        }
    }
}
