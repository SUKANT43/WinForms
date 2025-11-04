using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            Load += LoadAndResize;
            Resize += (s, e) => LoadAndResize(s, e);

        }

        private void LoadAndResize(object s, EventArgs e)
        {
            mainPanel.Controls.Clear(); 
            x = 0;
            y = 0;
            max = 0;

            foreach (Label label in list)
            {
                int width = label.Width;
                int height = label.Height;

                if (x + width > mainPanel.Width)
                {
                    x = 0;
                    y += max;
                    max = 0;
                }

                label.Location = new Point(x, y);

                x += width;
                max = Math.Max(max, height);

                mainPanel.Controls.Add(label);
            }
        }


        private void generateBtn(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(widthTextBox.Text);
             int height = Convert.ToInt32(heightTextBox.Text);

            if (x + width > mainPanel.Width)
            {
                x = 0;
                y += max;
                max = 0;
            }

            Label label = new Label()
            {
                Text = $"num: {count++}, Width: {width}, Height: {height}",
                Size = new Size(width, height),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightBlue,
            };

            x += width;
            max = Math.Max(max, height); 

            list.Add(label);
            mainPanel.Controls.Add(label);
        }


        private void deleteBtn(object sender, EventArgs e)
        {

            int num = (int)removeBox.Value;
            var labelRemove = list.FirstOrDefault(l => l.Text.StartsWith($"num: {num},"));
            if (labelRemove != null)
            {
                mainPanel.Controls.Remove(labelRemove);
                list.Remove(labelRemove);
                for (int i = 0; i < list.Count; i++)
                {
                    Label l = list[i];
                    l.Text = $"num: {i}, Width: {Width}, Height: {Height}";
                }
                LoadAndResize(null, null); 
            }
            else
            {
                MessageBox.Show("Label not found!");
            }
        }
    }
}
