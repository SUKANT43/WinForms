using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropsManagement
{
    public partial class Form2 : Form
    {
        Label l1;
        Form f;
        public Form2(Form1 f1)
        {
            l1 = new Label() { AutoSize = true };
            Controls.Add(l1);

            f1.ClickEvent += LabelText;
            f = f1;

        }
        private void LabelText(object sender, DataEvent e)
        {
            l1.Text = e.Message;

            ShowDialog();
        }

    }
}
