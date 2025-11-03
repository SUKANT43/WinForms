using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace exc_1
{
    public partial class Form1 : Form
    {
        private List<Label> labelList = new List<Label>();

        public Form1()
        {
            InitializeComponent();

        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            labelList.Clear();
            int row = Convert.ToInt32(rowNum.Value);
            int col = Convert.ToInt32(colNum.Value);
            for (int i = 1; i <= row * col; i++)
            {
                Label label = new Label
                {
                    BackColor = Color.SkyBlue,
                    BorderStyle = BorderStyle.FixedSingle
                };
                labelList.Add(label);
                mainPanel.Controls.Add(label);

            }
            OnResize();
        }

        protected override void OnResize(EventArgs e)
        {
            OnResize();
            base.OnResize(e);
        }


        private void OnResize()
        {
            int count = 1;
            int rg = Convert.ToInt32(rowGap.Value);
            int cg = Convert.ToInt32(colGap.Value);
            int row = Convert.ToInt32(rowNum.Value);
            int col = Convert.ToInt32(colNum.Value);

            int w = Convert.ToInt32((mainPanel.Width - rg) / col);
            int h = Convert.ToInt32((mainPanel.Height - cg) / row);

            int duplicateW = w;
            int duplicateH = h;

            int x = cg;
            int y = rg;
            for (int i = 0; i < labelList.Count; i++)
            {
                Label label = labelList[i];
                label.Size = new Size(duplicateW, duplicateH);
                label.Location = new Point(x, y);
                label.Text = $"num: {count++} width: {label.Width} height: {label.Height}";
                x += w + cg;
                duplicateH = h;
                duplicateW = w;
                if (mainPanel.Width - x < w)
                {
                    double percentage = ((double)(mainPanel.Width - x) / w) * 100;
                    //MessageBox.Show($"{percentage}");
                    if (percentage > 90)
                    {
                        duplicateW = mainPanel.Width - x;
                        duplicateH = h;
                    }
                    else
                    {
                        x = 0 + cg;
                        y += h + rg;
                    }
                }
            }
        }
    }
}