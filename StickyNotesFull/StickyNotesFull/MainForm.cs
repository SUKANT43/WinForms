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

        private int y;
        private SubForm subForm;

        private bool isEditMode = false;
        private bool isSelectMode = false;
        private string editingFileName;

        private Button deleteButton;
        private CheckBox selectAllCheckBox;

        static List<NotificationForm> notes = new List<NotificationForm>();

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
            Resize += (s, e) => AlignNotes();

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
                Location = new Point(110, 35),
                Visible = false
            };
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Click += DeleteSelectedNotes;
            topPanel.Controls.Add(deleteButton);
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

            dataList = DataController.GetData();
            y = 10;

            foreach (var data in dataList)
                CreateNotePanel(data);
        }

        private void CreateNotePanel(CustomEventData data)
        {
            int panelWidth = bottomPanel.DisplayRectangle.Width - 20;

            DataUserControl note = new DataUserControl(data, panelWidth);

            note.EditRequested += (s, e) =>
            {
                if (isSelectMode) return;

                isEditMode = true;
                editingFileName = data.FileName;
                subForm.EditData(data);
                subForm.ShowDialog();
                isEditMode = false;
            };

            note.DeleteRequested += (s, e) =>
            {
                if (MessageBox.Show("Delete this note?", "Confirm",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataController.DeleteData(data.FileName);
                    ShowNote(data.FileName + " is deleted.");
                    LoadNotes();
                }
            };

            note.Location = new Point(10, y);
            y += note.Height + 12;

            bottomPanel.Controls.Add(note);
        }

        private void AlignNotes()
        {
            int top = 10;
            int width = bottomPanel.DisplayRectangle.Width - 20;

            foreach (DataUserControl note in bottomPanel.Controls.OfType<DataUserControl>())
            {
                note.Width = width;
                note.Location = new Point(10, top);
                top += note.Height + 12;
            }
        }


        private void SelectModeChanged(object sender, EventArgs e)
        {
            isSelectMode = selectAllCheckBox.Checked;
            deleteButton.Visible = isSelectMode;

            foreach (DataUserControl note in bottomPanel.Controls.OfType<DataUserControl>())
                note.SetSelectMode(isSelectMode);
        }

        private void DeleteSelectedNotes(object sender, EventArgs e)
        {
            var selectedNotes = bottomPanel.Controls
                .OfType<DataUserControl>()
                .Where(n => n.IsSelected)
                .ToList();

            if (selectedNotes.Count == 0)
            {
                MessageBox.Show("No items selected");
                return;
            }

            if (MessageBox.Show("Delete selected notes?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            foreach (var note in selectedNotes)
            {
                DataController.DeleteData(note.Data.FileName);
                bottomPanel.Controls.Remove(note);
                ShowNote(note.Data.FileName + " is deleted.");
            }

            selectAllCheckBox.Checked = false;
        }


        private void CreateUser(object sender, CustomEventData e)
        {
            if (isEditMode)
            {
                DataController.UpdateData(editingFileName, e);
                ShowNote("Data Updated.");
            }
            else
            {
                DataController.AddData(e);
                ShowNote("New Data Added.");
            }

            LoadNotes();
        }

        private void AddLabelClick(object sender, EventArgs e)
        {
            isEditMode = false;
            subForm.ShowDialog();
        }


        void ShowNote(string msg)
        {
            NotificationForm n = new NotificationForm(msg);

            int x = Screen.PrimaryScreen.WorkingArea.Width - n.Width - 10;
            int y = Screen.PrimaryScreen.WorkingArea.Height - n.Height - 10;

            foreach (var f in notes)
                y -= (f.Height + 10);

            n.Location = new Point(x, y);
            n.FormClosed += (s, e) => notes.Remove(n);
            notes.Add(n);
            n.Show();
        }
    }
}
