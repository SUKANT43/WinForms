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
    public partial class PaymentForm : UserControl
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void UpiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (UpiRadioButton.Checked)
            {
                PaymentPanel.Controls.Add(UpiPanel);
                UpiPanel.Visible = true;
            }
            else
            {
                UpiPanel.Visible = false;
            }
        }

        private void NetBankingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NetBankingRadioButton.Checked)
            {
                PaymentPanel.Controls.Add(NetBankingPanel);
                NetBankingPanel.Visible = true;
            }
            else
            {
                NetBankingPanel.Visible = false;
            }
        }

        private void NameOnCardLabel_Click(object sender, EventArgs e)
        {

        }

        private void CardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CardRadioButton.Checked)
            {
                PaymentPanel.Controls.Add(CardPanel);
                CardPanel.Visible = true;
            }
            else
            {
                CardPanel.Visible = false;
            }
        }
    }
}
