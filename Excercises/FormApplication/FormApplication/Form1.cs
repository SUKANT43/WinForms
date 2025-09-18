using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NameInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DesignationTextInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void FeedbackTextInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Your feedback submited successfully:\n Name: {NameInputBox.Text} \n Designation: {DesignationTextInput.Text} \n Feedback: {FeedbackTextInput.Text}");
            NameInputBox.Text = "";
            DesignationTextInput.Text = "";
            FeedbackTextInput.Text = "";
        }
    }
}
