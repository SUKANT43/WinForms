using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private ComboBox yearComboBox;
        private ComboBox monthComboBox;
        private Panel calendarPanel;
        private Label dayLabel;
        public Form1()
        {
            InitializeComponent();
            //CalendarController cc = new CalendarController();
            //Controls.Add(cc);
            BuildUi();
            LoadMonthYear();
            BuildCalendar(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void BuildUi()
        {
            Width = 400;
            Height = 420;
            Text = "Custom Calendar";

            monthComboBox = new ComboBox()
            {
                Left = 20,
                Top = 20,
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDown
            };

            yearComboBox = new ComboBox()
            {
                Left = 160,
                Top = 20,
                Width = 80,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            dayLabel = new Label()
            {
                Left = 20,
                Top = 350,
                Width = 300,
                Height = 30,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Text = "Select a date"
            };


            calendarPanel = new Panel()
            {
                Left = 20,
                Top = 70,
                Width = 280,
                Height = 240,
                BorderStyle = BorderStyle.FixedSingle
            };

            monthComboBox.SelectedIndexChanged += ComboChanged;
            yearComboBox.SelectedIndexChanged += ComboChanged;
            Controls.Add(monthComboBox);
            Controls.Add(yearComboBox);
            Controls.Add(calendarPanel);
            Controls.Add(dayLabel);
        }

        private void LoadMonthYear()
        {
            monthComboBox.Items.AddRange(new string[]
            {
                "January","February","March","April","May","June",
                "July","August","September","October","November","December"
            });

            for (int y = 1990; y <= 2100; y++)
                yearComboBox.Items.Add(y);

            monthComboBox.SelectedIndex = DateTime.Now.Month - 1;
            yearComboBox.SelectedItem = DateTime.Now.Year;
            DrawDayHeaders();
        }

        public void DrawDayHeaders()
        {

            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 0; i < 7; i++)
            {
                Label lbl = new Label()
                {
                    Text = days[i],
                    Width = 40,
                    Height = 20,
                    Left = i * 40,
                    Top = 0,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };
                calendarPanel.Controls.Add(lbl);
            }
        }

        private void ComboChanged(object sender, EventArgs e)
        {
            if (monthComboBox.SelectedIndex < 0 || yearComboBox.SelectedIndex < 0)
                return;

            BuildCalendar((int)yearComboBox.SelectedItem, monthComboBox.SelectedIndex + 1);
        }

        private void BuildCalendar(int year, int month)
        {
            calendarPanel.Controls.Clear();
            DrawDayHeaders();
            DateTime firstDay = new DateTime(year, month, 1);
            int startColumn = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int cellSize = 40;
            int col = startColumn;
            int row = 1;

            for (int day = 1; day <= daysInMonth; day++)
            {
                Button btn = new Button()
                {
                    Text = day.ToString(),
                    Width = cellSize,
                    Height = cellSize,
                    Left = col * cellSize,
                    Top = row * cellSize
                };

                int selectedDay = day;
                btn.Click += (s, e) =>
                {
                    DateTime dt = new DateTime(year, month, selectedDay);
                    dayLabel.Text = $"{dt:dddd, dd MMMM yyyy}";
                };

                calendarPanel.Controls.Add(btn);

                col++;
                if (col > 6)
                {
                    col = 0;
                    row++;
                }
            }
        }
    }
}

