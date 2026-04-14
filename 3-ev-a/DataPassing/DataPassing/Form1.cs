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
        Form2 f2;
        public Form1(Form2 form2)
        {
            f2 = form2;
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

        private void Button1Click(object sender, EventArgs e)
        {
            f2.ShowDialog();
        }
    }
}
