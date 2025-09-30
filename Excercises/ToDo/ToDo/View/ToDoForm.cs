using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo.View
{
    public partial class ToDoForm : Form
    {
        private Panel mainPnl,detailsPnl;
        private Label taskLbl,descriptionLbl;
        private RichTextBox descriptionTxt;
        private TextBox taskTxt;
        private Button submitBtn;
        private DataGrid dataGrid;
        public ToDoForm()
        {
            Resize += (s, e) => FieldControls();
            Load += (s, e) => FieldControls();
        }
        private  void InitControls()
        {
            mainPnl = new Panel
            {
                Dock = DockStyle.Fill,
            };
            detailsPnl = new Panel
            {
                AutoSize = true,
                BorderStyle = BorderStyle.Fixed3D,
                BackColor=Color.AliceBlue,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
            };
            taskLbl = new Label
            {
                Text="Task:"
            };
            descriptionLbl = new Label
            {
                Text = "Description:",
                Location = new Point(taskLbl.Width,taskLbl.Height),
                BackColor=Color.AliceBlue
            };
            taskTxt = new TextBox
            {
                Font = new Font("Segoe UI", 10, FontStyle.Regular),

            };
            descriptionTxt = new RichTextBox
            {
                Font = new Font("Segoe UI", 10, FontStyle.Regular),

            };
            submitBtn = new Button
            {
                Text="Submit",
                TextAlign= ContentAlignment.MiddleCenter,
                AutoSize=true
            };
            detailsPnl.Controls.Add(taskLbl);
            detailsPnl.Controls.Add(descriptionLbl);
            detailsPnl.Controls.Add(taskTxt);
            detailsPnl.Controls.Add(descriptionTxt);
            detailsPnl.Controls.Add(submitBtn);
            mainPnl.Controls.Add(detailsPnl);
            Controls.Add(mainPnl);
        }
        private void FieldControls()
        {
            InitControls();
            int padding = 20;
            int currentY = padding;
            taskLbl.Location = new Point(padding,currentY);
            taskLbl.AutoSize = true;

            taskTxt.Location = new Point(taskLbl.Right+10,currentY);
            taskTxt.Width = detailsPnl.Width - taskTxt.Left - padding;

            currentY += taskLbl.Height+10;
            descriptionLbl.Location = new Point(padding,currentY);
            descriptionLbl.AutoSize = true;

            currentY += descriptionLbl.Height + 10;

            descriptionTxt.Location = new Point(padding, currentY);
            descriptionTxt.Width = detailsPnl.Width - 2 * padding;
            descriptionTxt.Height = detailsPnl.Height / 2;

            currentY += descriptionTxt.Height + 20;

            submitBtn.Location = new Point(padding, currentY);
            submitBtn.Width = 100;
        }
    }

}
    

