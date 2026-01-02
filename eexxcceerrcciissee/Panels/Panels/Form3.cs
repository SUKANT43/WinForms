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
    public partial class Form3 : Form
    {
        private int [] row;
        private int[] col;
        private List<Panel>list;
        int x, y;
        public Form3()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (row == null || col == null) return;

            int totalRowRatio = row.Sum();
            int totalColRatio = col.Sum();

            int y = 0;

            for (int r = 0; r < row.Length; r++)
            {
                int rowHeight = panel2.Height * row[r] / totalRowRatio;
                int x = 0;

                for (int c = 0; c < col.Length; c++)
                {
                    int colWidth = panel2.Width * col[c] / totalColRatio;

                    Panel p = new Panel
                    {
                        Location = new Point(x, y),
                        Size = new Size(colWidth, rowHeight),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.LightBlue
                    };

                    x += colWidth;
                }
                y += rowHeight;
            }
        }

        private int GetRowHeight(int index)
        {
            if (row.Length == 1)
                return panel2.Height;   // 100%

            int total = row.Sum();
            return panel2.Height * row[index] / total;
        }

        private int GetColWidth(int index)
        {
            if (col.Length == 1)
                return panel2.Width;    // 100%

            int total = col.Sum();
            return panel2.Width * col[index] / total;
        }

        private void LoadPanel()
        {
            if (row == null || col == null) return;


            int y = 0;

            for (int r = 0; r < row.Length; r++)
            {
                int rowHeight = GetRowHeight(r);
                int x = 0;

                for (int c = 0; c < col.Length; c++)
                {
                    int colWidth = GetColWidth(c);

                    Panel p = new Panel
                    {
                        Location = new Point(x, y),
                        Size = new Size(colWidth, rowHeight),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.LightBlue
                    };

                    panel2.Controls.Add(p);
                    x += colWidth;
                }

                y += rowHeight;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            row = textBox1.Text
                    .Split(':')
                    .Select(int.Parse)
                    .ToArray();

            col = textBox2.Text
                .Split(':')
                .Select(int.Parse)
                .ToArray();
            panel2.Controls.Clear();
            LoadPanel();
        }
    }
}
