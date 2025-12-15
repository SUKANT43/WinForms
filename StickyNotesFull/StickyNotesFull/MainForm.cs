using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StickyNotesFull
{
    public partial class MainForm : Form
    {
        private List<DataEventArgs> dataList;
        private int x, y;
        private SubForm subForm;

        private bool isEditMode = false;
        private string editingFileName;

        private bool isSelectAllChecked = false;
        private List<CheckBox> checkBoxList = new List<CheckBox>();
        private Button deleteButton;
        private CheckBox selectAllCheckBox;
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

            subForm.DataEvents += CreateUser;

            selectAllCheckBox = new CheckBox
            {
                Name = "selectAllCheckBox",
                Text = "Select ",
                ForeColor = Color.White,
                Location = new Point(10, 45),
                Font = new Font("Montserrat", 10, FontStyle.Bold),
            AutoSize = true
            };
            selectAllCheckBox.CheckedChanged += SelectAllCheckBoxClicked;
            topPanel.Controls.Add(selectAllCheckBox);
        }

        public void PageLoadAndResize(object sender, EventArgs e)
        {
            bottomPanel.Controls.Clear();
            checkBoxList.Clear();

            x = 0;
            y = isSelectAllChecked ? 60 : 10;

            ManageDesign();
            ShowData();

            if (isSelectAllChecked)
                AddDeleteButton();
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
                Size = new Size(panelWidth, 120),
                Name = data.FileName
            };

            x = (bottomPanel.ClientSize.Width - dataPanel.Width) / 2;
            dataPanel.Location = new Point(x, y);

            Panel colorPanel = new Panel
            {
                Size = new Size(dataPanel.Width, 10),
                Location = new Point(0, 0),
                BackColor =
                    data.SelectedColor == "green" ? Color.Green :
                    data.SelectedColor == "purple" ? Color.BlueViolet :
                    Color.FromArgb(255, 128, 128)
            };

            Label headerLabel = new Label
            {
                Text = data.Header,
                Font = new Font("Montserrat", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 30),
                Size = new Size(dataPanel.Width - 60, 30)
            };

            Label timeLabel = new Label
            {
                Text = data.CreatedAt,
                ForeColor = Color.Gray,
                Location = new Point(dataPanel.Width - 160, dataPanel.Height - 20)
            };

            if (isSelectAllChecked)
            {
                CheckBox cb = new CheckBox
                {
                    Name = data.FileName,
                    Location = new Point(10, dataPanel.Height - 30),
                    Checked = true
                };
                checkBoxList.Add(cb);
                dataPanel.Controls.Add(cb);
            }

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete")
            {
                ForeColor = Color.Red
            };

            editItem.Click += (s, e) =>
            {
                if (isSelectAllChecked) return;

                isEditMode = true;
                editingFileName = data.FileName;
                subForm.EditData(data);
                subForm.ShowDialog();
                isEditMode = false;
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

            Label optionLabel = new Label
            {
                Text = "...",
                Font = new Font("Montserrat", 15, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(dataPanel.Width - 40, 0),
                Cursor = Cursors.Hand
            };

            optionLabel.Click += (s, e) =>
            {
                if (!isSelectAllChecked)
                    menu.Show(optionLabel, new Point(0, optionLabel.Height));
            };

            dataPanel.DoubleClick += (s, e) =>
            {
                if (isSelectAllChecked) return;

                isEditMode = true;
                editingFileName = data.FileName;
                subForm.EditData(data);
                subForm.ShowDialog();
                isEditMode = false;
            };

            dataPanel.Controls.Add(colorPanel);
            dataPanel.Controls.Add(optionLabel);
            dataPanel.Controls.Add(headerLabel);
            dataPanel.Controls.Add(timeLabel);

            bottomPanel.Controls.Add(dataPanel);
            y += dataPanel.Height + 12;
        }

        private void SelectAllCheckBoxClicked(object sender, EventArgs e)
        {
            isSelectAllChecked = ((CheckBox)sender).Checked;
            PageLoadAndResize(this, EventArgs.Empty);
        }

        private void AddDeleteButton()
        {
            deleteButton = new Button
            {
                Text = "Delete",
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(90, 40),
                Location = new Point(10, 10)
            };
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Click += DeleteSelectedNotes;
                bottomPanel.Controls.Add(deleteButton);
        }

        private void DeleteSelectedNotes(object sender, EventArgs e)
        {
            var selected = checkBoxList.Where(c => c.Checked).ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("No items selected");
                return;
            }

            if (MessageBox.Show("Delete selected notes?", "Confirm",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }


            foreach (var cb in selected)
            {
                DataController.DeleteData(cb.Name);
            }

            isSelectAllChecked = false;
            selectAllCheckBox.Checked = false;
            PageLoadAndResize(this, EventArgs.Empty);
        }

        private void CreateUser(object sender, DataEventArgs e)
        {
            if (isEditMode)
                DataController.UpdateData(editingFileName, e);
            else
                DataController.AddData(e);

            PageLoadAndResize(this, EventArgs.Empty);
        }

        private void AddLabelClick(object sender, EventArgs e)
        {
            isEditMode = false;
            subForm.ShowDialog();
        }
    }
}
