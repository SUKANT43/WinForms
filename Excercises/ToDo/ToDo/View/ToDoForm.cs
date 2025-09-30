using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ToDo.View
{
    public partial class ToDoForm : Form
    {
        private Panel mainPnl, detailsPnl;
        private Label taskLbl, descriptionLbl;
        private TextBox taskTxt;
        private RichTextBox descriptionTxt;
        private Button submitBtn;
        private DataGridView dataGrid;
        private List<Controller.TodoController> list;

        public ToDoForm()
        {
            MinimumSize = new Size(700, 600);
            InitControls();

            list = new List<Controller.TodoController>();

            Resize += (s, e) => LayoutControls();
            Load += (s, e) => LayoutControls();

            submitBtn.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(taskTxt.Text) || string.IsNullOrWhiteSpace(descriptionTxt.Text))
                {
                    MessageBox.Show("All fields must be filled.");
                    return;
                }

                taskTxt.Text.Trim();
                descriptionTxt.Text.Trim();
                string Title = taskTxt.Text.Trim();
                string Description = descriptionTxt.Text.Trim();
                var todo = new Controller.TodoController
                {
                    title = Title,
                    description = Description
                };
                list.Add(todo);

                dataGrid.Rows.Add(todo.title, todo.description);

                taskTxt.Text = "";
                descriptionTxt.Text = "";

                MessageBox.Show("Todo added successfully!");
            };
        }

        private void InitControls()
        {
            mainPnl = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };

            detailsPnl = new Panel
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                BackColor = Color.AliceBlue,
                BorderStyle = BorderStyle.FixedSingle
            };

            taskLbl = new Label { Text = "Title:", AutoSize = true };
            taskTxt = new TextBox { Font = new Font("Segoe UI", 10) };

            descriptionLbl = new Label { Text = "Description:", AutoSize = true };
            descriptionTxt = new RichTextBox { Font = new Font("Segoe UI", 10), Height = 100 };

            submitBtn = new Button
            {
                Text = "Submit",
                Width = 100,
                Height = 35,
                BackColor = Color.LightSkyBlue,
                FlatStyle = FlatStyle.Flat
            };

            dataGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            dataGrid.Columns.Add("Title", "Title");
            dataGrid.Columns.Add("Description", "Description");

            detailsPnl.Controls.Add(taskLbl);
            detailsPnl.Controls.Add(taskTxt);
            detailsPnl.Controls.Add(descriptionLbl);
            detailsPnl.Controls.Add(descriptionTxt);
            detailsPnl.Controls.Add(submitBtn);

            mainPnl.Controls.Add(dataGrid);       
            mainPnl.Controls.Add(detailsPnl);     
            Controls.Add(mainPnl);
        }

        private void LayoutControls()
        {
            int padding = 10;
            int currentY = padding;

            taskLbl.Location = new Point(padding, currentY);
            taskTxt.Location = new Point(taskLbl.Right + 10, currentY);
            taskTxt.Width = detailsPnl.Width - taskTxt.Left - padding;

            currentY += taskLbl.Height + padding;

            descriptionLbl.Location = new Point(padding, currentY);
            currentY += descriptionLbl.Height + 5;

            descriptionTxt.Location = new Point(padding, currentY);
            descriptionTxt.Width = detailsPnl.Width - 2 * padding;
            descriptionTxt.Height = 100; 

            currentY += descriptionTxt.Height + padding;

            submitBtn.Location = new Point(padding, currentY);
        }
    }
}
