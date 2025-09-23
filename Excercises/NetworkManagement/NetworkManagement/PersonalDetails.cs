using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkManagement
{
    public partial class PersonalDetails : UserControl
    {
        public PersonalDetails()
        {
            InitializeComponent();
        }

        private void IndiaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (IndiaRadioButton.Checked)
            {
                PersonalDetailsPanel.Controls.Add(this.IsIndiaPanel);
                IsIndiaPanel.Visible = true;
            }
            else
            {
                IsIndiaPanel.Visible = false;
            }
        }

        private void NriRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NriRadioButton.Checked)
            {
                PersonalDetailsPanel.Controls.Add(this.IsNriPanel);
                IsNriPanel.Visible = true;
            }
            else
            {
                IsNriPanel.Visible = false;
            }
        }

        private void OtherRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (OtherRadioButton.Checked)
            {
                PersonalDetailsPanel.Controls.Add(this.IsOtherPanel);
                PersonalDetailsPanel.Visible = true;
            }
            else
            {
                PersonalDetailsPanel.Visible = false;
            }
        }
    }
}
