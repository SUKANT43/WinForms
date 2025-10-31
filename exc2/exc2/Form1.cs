using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exc2
{
    public partial class Form1 : Form
    {
        int x, y = 0;
        int count = 0;
        int max = 0;
        private List<Label> list = new List<Label>();
        public Form1()
        {
            InitializeComponent();
            Load += (s, e) => LoadAndResize(s, e);
            Resize += (s, e) => LoadAndResize(s, e);

        }

        private void LoadAndResize(object s, EventArgs e)
        {
            for(int i = 0; i < list.Count; i++)
            {
                mainPanel.Controls.Add(list[i]);
            }
        }

        private void generateBtn(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(widthBox.Value);
            int height = Convert.ToInt32(heightBox.Value);
            height = Math.Max(height, heightBox.Height);
            if (x+width>mainPanel.Width)
            {
                y = max;
                max = 0;
                x = 0;
            }
            Label label = new Label()
            {
                Text = $"{count++}",
                Size = new Size(width, height),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y),
                BorderStyle=BorderStyle.FixedSingle
            };
            x += width;
            list.Add(label);
            mainPanel.Controls.Add(label);
        }

        private void deleteBtn(object sender, EventArgs e)
        {

        }
    }
}
