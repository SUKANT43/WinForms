using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace wf
{
    public partial class SizeForm : Form
    {
        private Button btn;
        private Label label1;
       
        public SizeForm()
        {
            btn = new Button
            {
                Text = "Select Font",
                Dock = DockStyle.Top
            };
            btn.Click += Btn_Click;

            // TextBox to show path
            label1 = new Label
            {
                Text="hi hello",
                Dock = DockStyle.Fill,
            };

            Controls.Add(label1);
            Controls.Add(btn);

            this.Text = "FolderBrowserDialog Example";
            this.Size = new System.Drawing.Size(400, 150);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the chosen font to a label
                    label1.Font = fontDialog.Font;
                }
            }
        }
    }
    }
