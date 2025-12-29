using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class CalendarController : UserControl
    {
        
        ComboBox comboMonth;
        ComboBox comboYear;
        Label lblDay;

        List<DayCell> cells = new List<DayCell>();

        int cellSize = 45;
        int startX = 20;
        int startY = 80;

        public CalendarController()
        {
            InitializeComponent();
            DoubleBuffered = true;

            BuildUI();
            LoadMonthYear();

            Paint += FormPaint;
            MouseClick += FormMouseClick;
        }

        private void BuildUI()
        {
            Width = 380;
            Height = 420;
            Text = "Graphics Calendar";

            comboMonth = new ComboBox()
            {
                Left = 20,
                Top = 20,
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            comboYear = new ComboBox()
            {
                Left = 160,
                Top = 20,
                Width = 80,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            lblDay = new Label()
            {
                Left = 20,
                Top = 350,
                Width = 300,
                Height = 30,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Text = "Select a date"
            };

            comboMonth.SelectedIndexChanged += (s, e) => Invalidate();
            comboYear.SelectedIndexChanged += (s, e) => Invalidate();

            Controls.Add(comboMonth);
            Controls.Add(comboYear);
            Controls.Add(lblDay);
        }

        private void LoadMonthYear()
        {
            comboMonth.Items.AddRange(new string[]
            {
                "January","February","March","April","May","June",
                "July","August","September","October","November","December"
            });

            for (int y = 1990; y <= 2100; y++)
                comboYear.Items.Add(y);

            comboMonth.SelectedIndex = DateTime.Now.Month - 1;
            comboYear.SelectedItem = DateTime.Now.Year;
        }

        private void FormPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawDayHeaders(g);
            DrawCalendar(g);
        }

        private void DrawDayHeaders(Graphics g)
        {
            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            for (int i = 0; i < 7; i++)
            {
                Rectangle rect = new Rectangle(startX + i * cellSize, startY - 25, cellSize, 25);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString(days[i], Font, Brushes.Black, rect,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
        }

        private void DrawCalendar(Graphics g)
        {
            cells.Clear();

            int year = (int)comboYear.SelectedItem;
            int month = comboMonth.SelectedIndex + 1;

            DateTime firstDay = new DateTime(year, month, 1);
            int startCol = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            int col = startCol;
            int row = 0;

            for (int day = 1; day <= daysInMonth; day++)
            {
                Rectangle rect = new Rectangle(
                    startX + col * cellSize,
                    startY + row * cellSize,
                    cellSize,
                    cellSize);

                g.DrawRectangle(Pens.Black, rect);
                g.DrawString(day.ToString(), Font, Brushes.Black, rect,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                cells.Add(new DayCell { Day = day, Bounds = rect });

                col++;
                if (col > 6)
                {
                    col = 0;
                    row++;
                }
            }
        }

        private void FormMouseClick(object sender, MouseEventArgs e)
        {
            foreach (var cell in cells)
            {
                if (cell.Bounds.Contains(e.Location))
                {
                    int year = (int)comboYear.SelectedItem;
                    int month = comboMonth.SelectedIndex + 1;

                    DateTime dt = new DateTime(year, month, cell.Day);
                    lblDay.Text = dt.ToString("dddd, dd MMMM yyyy");
                    Invalidate();
                    break;
                }
            }
        }
    }

    class DayCell
    {
        public int Day;
        public Rectangle Bounds;
    }


}

 