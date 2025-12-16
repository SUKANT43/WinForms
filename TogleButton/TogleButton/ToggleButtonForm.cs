using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace TogleButton
{
    public partial class ToggleButtonForm : Form
    {
        Rectangle toogleRect;
        public ToggleButtonForm()
        {
            InitializeComponent();
            ToggleButtonControl btn = new ToggleButtonControl();
            btn.Size = new Size(btn.Width + 100, btn.Height + 100);
            Controls.Add(btn);
        }
    }
}

