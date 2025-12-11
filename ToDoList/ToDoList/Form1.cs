using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MinimumSize = new Size(600,700);
            Load += ResizeAndLoad;
            Resize += ResizeAndLoad;
        }

        public void ResizeAndLoad(object s,EventArgs e)
        {
            TitlePosition();
            AddTaskLabelPosition();
        }
         
        public void TitlePosition()
        {
            titleLabel.Location = new Point((Width / 2)- titleLabel.Width+80,20);
        }

        public void AddTaskLabelPosition()
        {
            addTaskLabel.Location = new Point(20,80);
        }


    }
}
