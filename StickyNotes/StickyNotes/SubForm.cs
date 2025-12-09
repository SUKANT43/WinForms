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
        bool isEditing = false;
        string id;
        public SubForm()
        {
            InitializeComponent();
            MaximumSize = new Size(300,400);
            MinimumSize = new Size(300, 400);
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
            if (isEditing)
            {
                MainForm mf = new MainForm(id, header, content);
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
        }
    }


}
