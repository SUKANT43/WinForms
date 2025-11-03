using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace exc_1
{
    public partial class Form1 : Form
    {
        private List<Label> labelList = new List<Label>();
        int rowCount = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void generateBtn(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(rowNum.Value);
            int col = Convert.ToInt32(colNum.Value);
            int total = row * col;

            // ✅ Adjust label count without clearing every time
            if (labelList.Count > total)
            {
                // Remove extra labels
                for (int i = labelList.Count - 1; i >= total; i--)
                {
                    mainPanel.Controls.Remove(labelList[i]);
                    labelList[i].Dispose();
                    labelList.RemoveAt(i);
                }
            }
            else if (labelList.Count < total)
            {
                // Add missing labels only
                for (int i = labelList.Count; i < total; i++)
                {
                    Label label = new Label
                    {
                        BackColor = Color.SkyBlue,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    labelList.Add(label);
                    mainPanel.Controls.Add(label);
                }
            }

            // Refresh layout
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
                        //rowCount++;
                        x = 0 + cg;
                        y += h + rg;
                    }
                }
            }
           // MessageBox.Show($"{rowCount}");
            //if (rowCount > 0)
            //{
            //    int calcHeight = mainPanel.Height / rowCount;
            //    calcHeight -= rg;
            //    for (int i = 0; i < labelList.Count; i++)
            //    {
            //        Label label = labelList[i];
            //        label.Size =new Size( label.Width,calcHeight);
            //    }
            //}
        }
    }
}