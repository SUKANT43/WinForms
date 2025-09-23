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
    public partial class ServiceRequirementForm : UserControl
    {
        public ServiceRequirementForm()
        {
            InitializeComponent();
        }

        private void NewConnectionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NewConnectionRadioButton.Checked)
            {
                ServiceRequirementFormPanel.Controls.Add(IsNew);
                IsNew.Visible = true;
                OldAddressLabel.Visible = false;
                OldAddressRichTextBox.Visible = false;
            }
            else
            {
                IsNew.Visible = false;
            }
        }

        private void RelocationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RelocationRadioButton.Checked)
            {
                ServiceRequirementFormPanel.Controls.Add(IsNew);
                IsNew.Visible = true;
                OldAddressLabel.Visible = true;
                OldAddressRichTextBox.Visible = true;
            }
            else
            {
                IsNew.Visible = false;
            }
        }
    }
}
