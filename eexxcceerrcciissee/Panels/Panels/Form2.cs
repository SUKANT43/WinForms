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
    public partial class Form2 : Form
    {
        int x = 0;
        int y = 0;
        int maxHeight = 0;
        private List<Label> list = new List<Label>();
        public Form2()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 400;
            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = 400;

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            x = 0;
            y = 0;
            maxHeight = 0;
            foreach (var ls in list)
            {
                int w = ls.Width;
                int h = ls.Height;
                maxHeight = maxHeight > h ? maxHeight : h;
                if (x + w > panel2.Width)
                {
                    x = 0;
                    y += maxHeight;
                    maxHeight = 0;
                }

                ls.Size = new Size(w, h);
                ls.Location = new Point(x, y);
                ls.BackColor = Color.LightBlue;
                ls.BorderStyle = BorderStyle.FixedSingle;
                

              
                x += w;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int w = (int)numericUpDown1.Value;
            int h = (int)numericUpDown2.Value;
            maxHeight = maxHeight > h ? maxHeight : h;
            if (x + w > panel2.Width)
            {
                x = 0;
                y+= maxHeight;
                maxHeight = 0;
            }

            Label l=new Label()
            {
                Size = new Size(w, h),
                Location=new Point(x,y),
                BackColor=Color.LightBlue,
                BorderStyle=BorderStyle.FixedSingle
            };

            list.Add(l);
            panel2.Controls.Add(l);
             x += w;
        }
    }
}
