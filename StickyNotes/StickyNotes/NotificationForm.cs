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

            Controls.Add(new Label
            {
                Text = msg,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });

            Timer t = new Timer { Interval = 10000 };
            t.Tick += (s, e) => Close();
            t.Start();
        }
    }
}
