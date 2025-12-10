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
    public partial class MainForm : Form
    {
        private List<ContentStructure> contentList;
        private bool isSelectAllChecked = false;
        private Button deleteButton = new Button();
        private Label dataLabel;
        CheckBox dataCheckBox;
        Panel dataPanel;
        Label dataDateTimePanel;
        List<CheckBox> checkBoxList = new List<CheckBox>();
        string editId;
        public MainForm()
        {
            InitializeComponent();
            MaximumSize = new Size(500, 600);
            MinimumSize = new Size(500, 600);
            Resize += ReloadAndResize;
            Load += ReloadAndResize;
            addLabel.Click += SelectAllCheckBoxClicked;
        }

        private void AddLabelClick(object sender, EventArgs e)
        {
            SubForm sf = new SubForm();
            sf.ShowDialog();
            bottomPanel.Controls.Clear();
            ReloadAndResize(this, EventArgs.Empty);
        }

        public MainForm(string header, string content)
        {
            bool success = DataController.WriteData(header, content);
            if (!success)
            {
                MessageBox.Show("Data not added.");
                return;
            }

            MessageBox.Show("Data added successfully.");
        }



        public MainForm(string id,string header,string content)
        {
            bool success = DataController.EditData(id, header, content);
            if (!success)
            {
                MessageBox.Show("Data not edited.");
                return;
            }
            MessageBox.Show("Data edited successfully.");
        }

        public void ReloadAndResize(object s, EventArgs e)
        {
            contentList = DataController.LoadData();
            checkBoxList.Clear();

            int x = 10, y = 10;
            if (isSelectAllChecked)
            {
                y = 70;
            }
            for (int i = contentList.Count - 1; i >= 0; i--)
            {
                dataPanel = new Panel()
                {
                    Size = new Size(450, 80),
                    BorderStyle = BorderStyle.Fixed3D,
                    Location = new Point(x, y),
                    Name = contentList[i].Id,
                    Cursor = Cursors.Hand

                };
                dataPanel.DoubleClick += PanelClicked;

                if (string.IsNullOrWhiteSpace(contentList[i].Header))
                {
                    dataLabel = new Label()
                    {
                        AutoSize = true,
                        Text = contentList[i].Content,
                        Font = new Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    dataLabel.Location = new Point(10, (dataPanel.Height / 2) - (dataLabel.Height));
                }
                else
                {
                    dataLabel = new Label()
                    {
                        AutoSize = false,
                        Text = contentList[i].Header,
                        Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleLeft,
                        ForeColor = Color.FromArgb(33, 33, 33),
                        Location = new Point(10, 8),
                        Size = new Size(dataPanel.Width - 20, 40)
                    };

                }
                dataLabel.DoubleClick += PanelClicked;
                dataPanel.Controls.Add(dataLabel);

                if (isSelectAllChecked)
                {
                    dataCheckBox = new CheckBox()
                    {
                        Name = contentList[i].Id,
                        Size = new Size(20, 20),
                        Location = new Point(10, dataPanel.Height - 30),
                        TextAlign = ContentAlignment.MiddleCenter,
                        FlatStyle = FlatStyle.Flat,
                        Checked=true
                    };
                    dataCheckBox.FlatAppearance.BorderSize = 1;
                    dataPanel.Controls.Add(dataCheckBox);
                    checkBoxList.Add(dataCheckBox);
                }

                dataDateTimePanel = new Label()
                {
                    Name = contentList[i].Id,
                    Size = new Size(200, 20),
                    Location = new Point(dataPanel.Width - 200 - 10, dataPanel.Height - 30),
                    Text = contentList[i].CreatedDateTime,
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 8F),
                    ForeColor = Color.Gray
                };
                dataDateTimePanel.DoubleClick += PanelClicked;
                dataPanel.Controls.Add(dataDateTimePanel);
                bottomPanel.Controls.Add(dataPanel);
                y += 90;
            }

        }

        private void DeleteButtonClicked(object s,EventArgs e)
        {
            if (checkBoxList.Count == 0)
            {
                MessageBox.Show("No items selected");
                return;
            }
           bool check= DataController.DeleteData(checkBoxList);
            if (!check)
            {
                MessageBox.Show("Data not deleted.");
                return;
            }
             MessageBox.Show("Data deleted successfully!.");
            bottomPanel.Controls.Clear();
            ReloadAndResize(this, EventArgs.Empty);
            SelectAllCheckBoxClicked(this, EventArgs.Empty);
        }

        private void SelectAllCheckBoxClicked(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Checked)
            {
                isSelectAllChecked = true;
                deleteButton = new Button
                {
                    Text = "Delete",
                    BackColor = Color.FromArgb(244, 67, 54),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(90, 40),
                    Location = new Point(10, 10),
                    Cursor = Cursors.Hand
                };
                deleteButton.FlatAppearance.BorderSize = 0;
                deleteButton.Click += DeleteButtonClicked;

                deleteButton.Visible = true;
                bottomPanel.Controls.Clear();
                bottomPanel.Controls.Add(deleteButton);

                ReloadAndResize(this, EventArgs.Empty);
            }
            if (!selectAllCheckBox.Checked)
            {
                isSelectAllChecked = false;
                deleteButton.Visible = false;
                bottomPanel.Controls.Clear();
                ReloadAndResize(this, EventArgs.Empty);
            }
        }

        private void PanelClicked(object s, EventArgs e)
        {
            if (!isSelectAllChecked)
            {
                Control clicked = s as Control;
                Panel panel;
                if (clicked is Panel)
                {
                    panel = (Panel)clicked;
                }
                else
                {
                    panel = clicked.Parent as Panel;
                }
                if (panel == null)
                {
                    return;
                }
                string id = panel.Name;
                foreach (var ls in contentList)
                {
                    if (id == ls.Id)
                    {
                        SubForm sf = new SubForm(id, ls.Header, ls.Content);
                        sf.ShowDialog();
                        bottomPanel.Controls.Clear();
                        ReloadAndResize(this, EventArgs.Empty);
                    }
                }
            }
        }


    }
}

