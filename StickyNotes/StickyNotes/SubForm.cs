using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNotes
{
    public partial class SubForm : Form
    {
        bool isEditing = false,isSave=false;
        string id;
        public SubForm()
        {
            InitializeComponent();
            MaximumSize = new Size(300,400);
            MinimumSize = new Size(300, 400);
            Load += LoadPage;
        }

        public void LoadPage(object e,EventArgs s)
        {
            if (isEditing)
            {
                addButton.Visible = false;
                okButton.Visible = true;
                saveButton.Visible = true;
            }
            else
            {
                addButton.Visible = true;
                okButton.Visible = false;
                saveButton.Visible = false;
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            string header = headerRichTextBox.Text;
            string content = contentRichTextBox.Text;
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Content must have a value.");
                return;
            }
            if (!isEditing)
            {
                MainForm mf = new MainForm(header, content);
                Close();
            }
            
        }


        public SubForm(string id, string header, string content)
        {
            InitializeComponent();
            this.id = id;
            isEditing = true;
            headerRichTextBox.Text = header;
            contentRichTextBox.Text = content;
            Load += LoadPage;

        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            MainForm mf = new MainForm(id, headerRichTextBox.Text, contentRichTextBox.Text);
            Close();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (isEditing)
            {
                MainForm mf = new MainForm(id, headerRichTextBox.Text, contentRichTextBox.Text);
            }
        }
    }


}
