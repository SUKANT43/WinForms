using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomEvent
{
    public partial class Form2 : Form
    {
        public event EventHandler<CustomEventClass> CustomEvent;

        public Form2()
        {
            InitializeComponent();
        }

        protected virtual void OnCustomEvent(CustomEventClass e)
        {
            CustomEvent?.Invoke(this, e);
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            OnCustomEvent(new CustomEventClass("Data from Form2"));
            this.Close();
        }
    }

}
