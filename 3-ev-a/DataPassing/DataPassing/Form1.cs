using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPassing
{
    public partial class Form1 : Form
    {
        private TextBox txtForm;
        private UserControl1 us;
        private bool isUpdating = false;

        public Form1()
        {
            txtForm = new TextBox
            {
                Dock = DockStyle.Top
            };
            us = new UserControl1 {
                Dock=DockStyle.Top
            };
            Controls.Add(us);
            Controls.Add(txtForm);

            txtForm.TextChanged += (s, e) =>
            {
                if (isUpdating) return;
                isUpdating = true;
                us.TextValue = txtForm.Text;
                isUpdating = false;
            };

            us.TextValueChanged += (s, e) =>
            {
                if (isUpdating) return;

                isUpdating = true;
                txtForm.Text = us.TextValue;
                isUpdating = false;
            };


            InitializeComponent();
        }
    }
}
