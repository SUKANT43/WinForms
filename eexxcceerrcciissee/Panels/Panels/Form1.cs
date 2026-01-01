using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panels
{
    public partial class Form1 : Form
    {
        private List<Label> list = new List<Label>();
        int row;
        int col;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Resize += PageResize;
        }


        private  void PageResize(object s,EventArgs e)
        {
            LoadPanel();
        }

        private void LoadPanel()
        {
            panel1.Controls.Clear();
            int height = panel1.Height;
            int width = panel1.Width;
            int panelHeight = 1;
            int panelWidth=1;
            if (row > 0)
            {
                 panelHeight = height / row;
                 panelWidth = width / col;

            }
            int x = 0;
            int y = 0;
            int count = 0;
            for(int i = 1; i <= row; i++)
            {
                for(int j = 1; j <= col; j++)
                {
                    Label l = list[count++];
                    l.Text = $"Count:{count}\n Width:{panelWidth} \n Height:{panelHeight}";
                    l.Width = panelWidth;
                    l.Height = panelHeight;
                    l.Location = new Point(x, y);
                    l.BorderStyle = BorderStyle.FixedSingle;
                    l.BackColor = Color.LightBlue;
                    x += panelWidth;
                    panel1.Controls.Add(l);
                }
                x = 0;
                y += panelHeight;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            row = (int)numericUpDown1.Value;
            col = (int)numericUpDown2.Value;
            for (int i = 1; i <= row * col; i++)
            {
                list.Add(new Label());
            }
            LoadPanel();
        }
    }
}
