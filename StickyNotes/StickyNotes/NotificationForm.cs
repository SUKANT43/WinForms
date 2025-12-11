using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNotes
{
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();
        }
        public NotificationForm(string msg)
        {
            Width = 250;
            Height = 60;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            ProgressBar pb= new ProgressBar()
            {
                Dock=DockStyle.Bottom,
                Minimum = 0,
                Maximum = 3000,
                Value = 0,
            };
            Controls.Add(new Label
            {
                Text = msg,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });

            Controls.Add(pb);
            MainForm mf = new MainForm();

            Timer t = new Timer { Interval = 10 };
            t.Tick += (s, e) => {
                try
                { 
                    pb.Value += 10;
                    if (pb.Value >= pb.Maximum)
                    {
                        mf.ShowNote();
                        Close();
                    }
                }
                catch(Exception ee) { }
                
                };
            t.Start();
        }
    }
}
