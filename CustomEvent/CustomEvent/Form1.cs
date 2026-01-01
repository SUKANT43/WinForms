using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomEvent
{
    public partial class Form1 : Form
    {
        Form2 f;

        public Form1(Form2 f2)
        {
            InitializeComponent();
            f = f2;

            f.CustomEvent += F_CustomEvent;
            panel1.Paint += PanelPaint;
        }

        private void F_CustomEvent(object sender, CustomEventClass e)
        {
            MessageBox.Show("Received: " + e.Message);
        }

        private void PanelPaint(object s,PaintEventArgs e)
        {
            Panel pnl = s as Panel;

            Color lightOrange = Color.Orange;
            Color darkOrange = Color.DarkOrange;

            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    pnl.ClientRectangle,
                    lightOrange,
                    darkOrange,
                    LinearGradientMode.Vertical))   // Vertical gradient
            {
                e.Graphics.FillRectangle(brush, pnl.ClientRectangle);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            f.ShowDialog();
        }
    }

}
