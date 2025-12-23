using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ButtonsController btn = new ButtonsController(50);
            Controls.Add(btn);
        }
    }
}
