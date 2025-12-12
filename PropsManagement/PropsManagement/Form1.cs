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
    public partial class Form1 : Form
    {
        TextBox tx;
        public Form1()
        {
             tx = new TextBox()
            {
                Height = 400,
                Width = 500,
            };
            Button btn = new Button()
            {
                Height = 100,
                Width = 100,
                Text = "Click"
            };
            btn.Click += ButtonClicked;
            Controls.Add(tx);
            Controls.Add(btn);

        }

        public event EventHandler<DataEvent> ClickEvent;

        public void ButtonClicked(object s, EventArgs e)
        {
            ClickEvent?.Invoke(this, new DataEvent(tx.Text));
        }

    }
}
