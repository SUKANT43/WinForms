using System;
using System.Drawing;
using System.Windows.Forms;

namespace StickyNotesFull
{
    public partial class SubForm : Form
    {
        public event EventHandler<DataEventArgs> DataEvents;

        string colorName;
        string editFileName;
        bool isEdit;

        public SubForm()
        {
            InitializeComponent();
            InitUI();
        }

        public void EditData(DataEventArgs data)
        {
            Controls.Clear();
            InitializeComponent();
            InitUI();

            isEdit = true;
            editFileName = data.FileName;

            headerRichTextBox.Text = data.Header;
            contentRichTextBox.Text = data.Content;
            colorName = data.SelectedColor;
            colorPanel.BackColor = data.SelectedColor == "green"
                    ? Color.Green
                    : data.SelectedColor == "purple"
                        ? Color.BlueViolet
                        : Color.FromArgb(255, 128, 128);

        }

        private void InitUI()
        {
            BackColor = Color.FromArgb(32, 32, 32);
            headerRichTextBox.BackColor = Color.FromArgb(41, 41, 41);
            headerRichTextBox.ForeColor = Color.White;
            contentRichTextBox.BackColor = Color.FromArgb(41, 41, 41);
            contentRichTextBox.ForeColor = Color.White;
            ForeColor = Color.White;
            Font = new Font("Montserrat", 10);
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(headerRichTextBox.Text) ||
                string.IsNullOrEmpty(contentRichTextBox.Text) ||
                string.IsNullOrEmpty(colorName))
                return;

            DataEvents?.Invoke(
                this, new DataEventArgs(
                    editFileName,
                    headerRichTextBox.Text,
                    contentRichTextBox.Text,
                    "",
                    colorName,
                    editFileName
                )
            );

            headerRichTextBox.Text = "";
            contentRichTextBox.Text = "";
            colorName = "";
            colorPanel.BackColor = Color.Transparent;
            Close();
        }

        private void redLabelClick(object sender, EventArgs e)
        {
            colorName = "red";
            colorPanel.BackColor = redLabel.BackColor;
        }

        private void purpleLabelClick(object sender, EventArgs e)
        {
            colorName = "purple";
            colorPanel.BackColor = purpleLabel.BackColor;
        }

        private void greenLabelClick(object sender, EventArgs e)
        {
            colorName = "green";
            colorPanel.BackColor = greenLabel.BackColor;
        }
    }
}
