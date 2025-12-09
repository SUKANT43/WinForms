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
    public partial class SubForm : Form
    {

        public SubForm(string a)
        {
            InitializeComponent();
            label1.Text = a;
        }


    }


}
