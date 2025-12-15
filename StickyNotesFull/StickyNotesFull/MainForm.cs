using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StickyNotesFull
{
    public partial class MainForm : Form
    {
        private List<DataEventArgs> dataList;
        private int x, y;
        private SubForm subForm;

        public MainForm(SubForm sf)
        {
            InitializeComponent();

            subForm = sf;
            dataList = new List<DataEventArgs>();

            BackColor = Color.FromArgb(32, 32, 32);
            ForeColor = Color.White;

            MaximumSize = new Size(650, 1500);
            MinimumSize = new Size(350, 450);

            bottomPanel.AutoScroll = true;

            Load += PageLoadAndResize;
            Resize += PageLoadAndResize;

            sf.DataEvents += CreateUser;
        }

        public void PageLoadAndResize(object sender, EventArgs e)
        {
            bottomPanel.Controls.Clear();
            x = 0;
            y = 10;
            ManageDesign();
            ShowData();
        }

        private void ManageDesign()
        {
            stickyNotesLabel.Font = new Font("Montserrat", 15, FontStyle.Bold);
            addLabel.Font = new Font("Montserrat", 20, FontStyle.Bold);

            stickyNotesLabel.Location = new Point(10, 10);
            addLabel.Location = new Point(topPanel.Width - 35, 10);
        }

        private void ShowData()
        {
            dataList = DataController.GetData();

            foreach (var data in dataList)
            {
                CreateNotePanel(data);
            }
        }

        private void CreateNotePanel(DataEventArgs data)
        {
            int panelWidth = bottomPanel.DisplayRectangle.Width - 20;

            Panel dataPanel = new Panel
            {
                BackColor = Color.FromArgb(41, 41, 41),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(panelWidth, 120)
            };

            x = (bottomPanel.ClientSize.Width - dataPanel.Width) / 2;
            dataPanel.Location = new Point( x, y);

            Panel colorPanel = new Panel
            {
                Size = new Size(dataPanel.Width, 10),
                Location = new Point(0, 0),
                BackColor = data.SelectedColor == "green"
                    ? Color.Green
                    : data.SelectedColor == "purple"
                        ? Color.BlueViolet
                        : Color.FromArgb(255, 128, 128)
            };

            Label optionLabel = new Label
            {
                Text = "...",
                Font = new Font("Montserrat", 15, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(dataPanel.Width - 40, 0),
                Cursor = Cursors.Hand
            };

            Label headerLabel = new Label
            {
                Text = data.Header,
                Font = new Font("Montserrat", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 30),
                Size = new Size(dataPanel.Width - 20, 30)
            };

            Label timeLabel = new Label
            {
                Text = data.CreatedAt,
                ForeColor = Color.Gray,
                Location = new Point(dataPanel.Width - 160, dataPanel.Height - 20)
            };

            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete")
            {
                ForeColor = Color.Red
            };

            editItem.Click += (s, e) =>
            {
                subForm.EditData(data);
                subForm.DataEvents += (ss, ee) =>
                {
                    DataController.UpdateData(data.FileName, ee);
                    PageLoadAndResize(this, EventArgs.Empty);
                };
                subForm.ShowDialog();
            };

            deleteItem.Click += (s, e) =>
            {
                if (MessageBox.Show("Delete this note?", "Confirm",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataController.DeleteData(data.FileName);
                    PageLoadAndResize(this, EventArgs.Empty);
                }
            };

            menu.Items.Add(editItem);
            menu.Items.Add(deleteItem);

            optionLabel.Click += (s, e) =>
            {
                menu.Show(optionLabel, new Point(0, optionLabel.Height));
            };

            dataPanel.Controls.Add(colorPanel);
            dataPanel.Controls.Add(optionLabel);
            dataPanel.Controls.Add(headerLabel);
            dataPanel.Controls.Add(timeLabel);

            bottomPanel.Controls.Add(dataPanel);

            y += dataPanel.Height + 12;
        }

        private void CreateUser(object sender, DataEventArgs e)
        {
            DataController.AddData(e);
            PageLoadAndResize(this, EventArgs.Empty);
        }

        private void AddLabelClick(object sender, EventArgs e)
        {
            subForm.ShowDialog();
        }
    }
}
