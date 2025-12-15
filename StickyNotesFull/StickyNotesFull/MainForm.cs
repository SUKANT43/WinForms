using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StickyNotesFull
{
    public partial class MainForm : Form
    {
        private List<CustomEventData> dataList;
        private List<Panel> dataPanelList = new List<Panel>();

        private int x, y;
        private SubForm subForm;

        private bool isEditMode = false;
        private string editingFileName;

        private bool isSelectMode = false;
        private Button deleteButton;
        private CheckBox selectAllCheckBox;

        public MainForm(SubForm sf)
        {
            InitializeComponent();
            subForm = sf;
            dataList = new List<CustomEventData>();
            BackColor = Color.FromArgb(32, 32, 32);
            ForeColor = Color.White;
            MaximumSize = new Size(650, 1500);
            MinimumSize = new Size(650, 450);
            bottomPanel.AutoScroll = true;
            Load += MainFormLoad;
            Resize += (s, e) => AlignPanels();
            subForm.DataEvents += CreateUser;
            selectAllCheckBox = new CheckBox
            {
                Text = "Select",
                ForeColor = Color.White,
                Font = new Font("Montserrat", 10, FontStyle.Bold),
                Location = new Point(10, 45),
                AutoSize = true
            };
            selectAllCheckBox.CheckedChanged += SelectModeChanged;
            topPanel.Controls.Add(selectAllCheckBox);

            deleteButton = new Button
            {
                Text = "Delete",
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(90, 40),
                Location = new Point(10, 10),
                Visible = false
            };
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Click += DeleteSelectedNotes;
            bottomPanel.Controls.Add(deleteButton);
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            ManageDesign();
            LoadNotes();
        }

        private void ManageDesign()
        {
            stickyNotesLabel.Font = new Font("Montserrat", 15, FontStyle.Bold);
            addLabel.Font = new Font("Montserrat", 20, FontStyle.Bold);

            stickyNotesLabel.Location = new Point(10, 10);
            addLabel.Location = new Point(topPanel.Width - 35, 10);
        }

        private void LoadNotes()
        {
            bottomPanel.Controls.Clear();
            dataPanelList.Clear();

            bottomPanel.Controls.Add(deleteButton);

            dataList = DataController.GetData();

            y = 60;

            foreach (var data in dataList)
            {
                CreateNotePanel(data);
            }
        }

        private void CreateNotePanel(CustomEventData data)
        {
            int panelWidth = bottomPanel.DisplayRectangle.Width - 20;

            Panel dataPanel = new Panel
            {
                Name = data.FileName,
                BackColor = Color.FromArgb(41, 41, 41),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(panelWidth, 120),

            };

            Panel colorPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 10,
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
                Location = new Point(40, 30),
                Size = new Size(panelWidth - 80, 30)
            };

            Label timeLabel = new Label
            {
                Text = data.CreatedAt,
                ForeColor = Color.Gray,
                Location = new Point(panelWidth - 100, 95)
            };

            CheckBox cb = new CheckBox
            {
                Name = data.FileName,
                Location = new Point(10, 85),
                Visible = false
            };

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete")
            {
                ForeColor = Color.Red
            };

            editItem.Click += (s, e) =>
            {
                if (isSelectMode) return;

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
                    LoadNotes();
                }
            };

            menu.Items.Add(editItem);
            menu.Items.Add(deleteItem);

            Label optionLabel = new Label
            {
                Text = "...",
                Font = new Font("Montserrat", 15, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(panelWidth - 40, 0),
                Cursor = Cursors.Hand
            };

            optionLabel.Click += (s, e) =>
            {
                if (!isSelectMode)
                    menu.Show(optionLabel, new Point(0, optionLabel.Height));
            };

            dataPanel.DoubleClick += (s, e) =>
            {
                if (isSelectMode) return;

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
            dataPanel.Controls.Add(cb);

            dataPanel.Location = new Point(10, y);
            y += dataPanel.Height + 12;

            bottomPanel.Controls.Add(dataPanel);
            dataPanelList.Add(dataPanel);
        }

        private void AlignPanels()
        {
            int top = 60;
            if (!isEditMode)
            {
                foreach (var panel in dataPanelList)
                {
                    panel.Width = bottomPanel.DisplayRectangle.Width - 20;
                    panel.Location = new Point(10, top);
                    top += panel.Height + 12;
                }
            }
        }

        private void SelectModeChanged(object sender, EventArgs e)
        {
            isSelectMode = selectAllCheckBox.Checked;

            deleteButton.Visible = isSelectMode;

            foreach (var panel in dataPanelList)
            {
                var cb = panel.Controls.OfType<CheckBox>().First();
                cb.Visible = isSelectMode;
                cb.Checked = false;
            }
        }

        private void DeleteSelectedNotes(object sender, EventArgs e)
        {
            var selectedPanels = dataPanelList
                .Where(p => p.Controls.OfType<CheckBox>().First().Checked)
                .ToList();

            if (selectedPanels.Count == 0)
            {
                MessageBox.Show("No items selected");
                return;
            }

            if (MessageBox.Show("Delete selected notes?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            foreach (var panel in selectedPanels)
            {
                DataController.DeleteData(panel.Name);
                bottomPanel.Controls.Remove(panel);
                dataPanelList.Remove(panel);
            }

            selectAllCheckBox.Checked = false;
        }

        private void CreateUser(object sender, CustomEventData e)
        {
            if (isEditMode)
                DataController.UpdateData(editingFileName, e);
            else
                DataController.AddData(e);

            LoadNotes();
        }

        private void AddLabelClick(object sender, EventArgs e)
        {
            isEditMode = false;
            subForm.ShowDialog();
        }
    }
}
