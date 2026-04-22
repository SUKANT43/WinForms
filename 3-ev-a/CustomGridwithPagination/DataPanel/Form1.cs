using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataPanel
{
    public partial class Form1 : Form
    {
        List<UserData> list = new List<UserData>();
        List<UserData> filteredList = new List<UserData>();

        SmoothFlowPanel mainPanel;
        SimplePagination pager;

        TextBox txtInput, txtFilter;
        DateTimePicker dtPicker;

        int pageSize = 6;
        int currentPage = 1;

        public Form1()
        {
            this.Text = "Pagination Demo";
            this.Size = new Size(1000, 600);
            this.BackColor = Color.LightGray;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // 🔝 Top panel
            Panel top = new Panel() { Dock = DockStyle.Top, Height = 60 };

            txtInput = new TextBox() { Location = new Point(10, 15), Width = 150 };
            dtPicker = new DateTimePicker() { Location = new Point(170, 15), Width = 150 };

            Button btnAdd = new Button()
            {
                Text = "Add",
                Location = new Point(330, 15),
                Width = 80
            };

            txtFilter = new TextBox()
            {
                Location = new Point(420, 15),
                Width = 150,
            };

            txtFilter.TextChanged += (s, e) => ApplyFilter();

            btnAdd.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtInput.Text)) return;

                list.Insert(0,new UserData
                {
                    Description = txtInput.Text,
                    Date = dtPicker.Value
                });

                txtInput.Clear();
                ApplyFilter();
            };

            top.Controls.Add(txtInput);
            top.Controls.Add(dtPicker);
            top.Controls.Add(btnAdd);
            top.Controls.Add(txtFilter);

            mainPanel = new SmoothFlowPanel();

            pager = new SimplePagination()
            {
                Dock = DockStyle.Bottom,
                PageSize = pageSize
            };

            pager.PageChanged += (p) =>
            {
                currentPage = p;
                RenderPage();
            };

            pager.PageSizeChanged += (s) =>
            {
                pageSize = s;
                currentPage = 1;
                RenderPage();
            };

            this.Controls.Add(mainPanel);
            this.Controls.Add(pager);
            this.Controls.Add(top);

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string key = txtFilter.Text.ToLower();

            filteredList = string.IsNullOrWhiteSpace(key)
                ? list.ToList()
                : list.Where(x => x.Description != null &&
                                  x.Description.ToLower().Contains(key))
                      .ToList();

            currentPage = 1;
            RenderPage();
        }

        private void RenderPage()
        {
            mainPanel.SuspendLayout();
            mainPanel.Controls.Clear();

            var pageData = filteredList
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);

            foreach (var data in pageData)
            {
                CustomPanel pn = new CustomPanel()
                {
                    Width = 300,
                    Height = 200,
                    Margin = new Padding(10),
                    Data = data
                };

                pn.DeleteClicked += Panel_Delete;
                pn.EditClicked += Panel_Edit;

                mainPanel.Controls.Add(pn);
            }

            mainPanel.ResumeLayout();
            mainPanel.Refresh();

            pager.TotalRecords = filteredList.Count;
            pager.CurrentPage = currentPage;
        }

        private void Panel_Delete(object sender, UserData data)
        {
            list.RemoveAll(x => x.Id == data.Id);
            ApplyFilter();
        }

        private void Panel_Edit(object sender, UserData data)
        {
            TransparentPanel overlay = new TransparentPanel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black
            };
            mainPanel.Enabled = false;

            Panel box = new Panel()
            {
                Size = new Size(300, 200),
                BackColor = Color.White
            };

            overlay.Resize += (s, e) =>
            {
                box.Location = new Point(
                    (overlay.Width - box.Width) / 2,
                    (overlay.Height - box.Height) / 2
                );
            };

            TextBox txt = new TextBox()
            {
                Width = 250,
                Location = new Point(25, 30),
                Text = data.Description
            };

            DateTimePicker dt = new DateTimePicker()
            {
                Width = 250,
                Location = new Point(25, 70),
                Value = data.Date
            };

            Button save = new Button()
            {
                Text = "Save",
                Location = new Point(40, 120)
            };

            Button cancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(150, 120)
            };

            save.Click += (s, e) =>
            {
                data.Description = txt.Text;
                data.Date = dt.Value;

                this.Controls.Remove(overlay);
                overlay.Dispose();
                
                ApplyFilter();
                
            };

            cancel.Click += (s, e) =>
            {
                this.Controls.Remove(overlay);
                overlay.Dispose();
            };

            box.Controls.Add(txt);
            box.Controls.Add(dt);
            box.Controls.Add(save);
            box.Controls.Add(cancel);

            overlay.Controls.Add(box);

            this.Controls.Add(overlay);
            overlay.BringToFront();
        }
    }
}