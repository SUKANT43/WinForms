using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace expenseTracker
{
    public partial class ColorCategoryControl : UserControl
    {
        public ColorCategoryControl()
        {
            InitializeComponent();
            MinimumSize = new Size(125, 177);
            MaximumSize = new Size(125, 177);
        }
    }
}
