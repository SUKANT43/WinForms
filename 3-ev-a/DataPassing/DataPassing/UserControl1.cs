using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPassing
{
    public partial class UserControl1 : UserControl
    {
        private TextBox txtController;

        public event EventHandler TextValueChanged;

        public string TextValue
        {
            get => txtController.Text;
            set => txtController.Text = value;
        }



        public UserControl1()
        {
            txtController = new TextBox();
            txtController.Dock = DockStyle.Top;
            Controls.Add(txtController);
            txtController.TextChanged += (s, e) =>
            {
                TextValueChanged?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
