using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskUi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Loading...";

            for (int i = 1; i <= 5; i++)
            {
                await Task.Delay(1000);
                label1.Text = $"Stage {i}";
            }

            label1.Text = "Completed";
        }
    }
}
