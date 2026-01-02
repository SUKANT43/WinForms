using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Panels
{
    public partial class CalendarControl : UserControl
    {
        int height, width;
        int x, y;
        List<DayCell> list = new List<DayCell>();
        Font f= new Font("Segoe UI", 10, FontStyle.Bold);
        public CalendarControl()
        {
            InitializeComponent();
            LoadMonthAndYear();
            panel2.Paint += PaintPage;
            panel2.Resize += PageResize;
            panel2.MouseClick += Panel2Click;
        }

        public void Panel2Click(object s,MouseEventArgs e)
        {
            foreach (var cell in list)
            {
                if (cell.Bounds.Contains(e.Location))
                {
                    int year = (int)comboBox2.SelectedItem;
                    int month = comboBox1.SelectedIndex + 1;

                    DateTime dt = new DateTime(year, month, cell.Day);
                    label1.Text = dt.ToString("dddd, dd MMMM yyyy");
                    Invalidate();
                    break;
                }
            }
        }
        

        public void LoadMonthAndYear()
        {
            string[] month = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            comboBox1.Items.AddRange(month);

            for(int i = 2000; i <= 2999; i++)
            {
                comboBox2.Items.Add(i);
            }
            comboBox1.SelectedIndex = DateTime.Now.Month - 1;
            comboBox2.SelectedItem = DateTime.Now.Year;
            comboBox1.SelectedIndexChanged += (s, e) => panel2.Invalidate();
            comboBox2.SelectedIndexChanged += (s, e) => panel2.Invalidate();

        }

        public void PageResize(object s,EventArgs e)
        {
            width = panel2.Width / 7;
            height = panel2.Height / 8;
            propertyPanel.Location = new Point(
                (panel1.Width - propertyPanel.Width)/2,
                   (panel1.Height - propertyPanel.Height )/2
                );
            
            label1.Location = new Point(
               0,
                (panel3.Height - label1.Height) / 2
                );
            Invalidate();
        }

        private void PaintPage(object s,PaintEventArgs e)
        {
            x = 0;
            y = 0;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawHeaders(g);
            DrawCalendar(g);
        }

        private void DrawHeaders(Graphics g)
        {
            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
           
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    for (int i = 0; i < 7; i++)
                    {

                    Rectangle rect = new Rectangle(
                        i * width,
                        y,
                        width,
                        height
                    );

                    g.DrawRectangle(pen, rect);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;   
                        sf.LineAlignment = StringAlignment.Center;

                        g.DrawString(days[i], f, Brushes.Black, rect, sf);
                    }
                }
            }
            y += height;
        }

        private void DrawCalendar(Graphics g)
        {
            if (comboBox1.SelectedIndex < 0 || comboBox2.SelectedItem == null)
                return;

            int year = (int)comboBox2.SelectedItem;
            int month = comboBox1.SelectedIndex + 1;

            DateTime firstDay = new DateTime(year, month, 1);
            int startCol = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            int col = startCol;
           
            using (Pen pen = new Pen(Color.Black, 2))
            using (StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                for (int day = 1; day <= daysInMonth; day++)
                {
                    Rectangle rect = new Rectangle(
                        x + col * width,
                        y + height ,
                        width,
                        height);

                    g.DrawRectangle(pen, rect);
                    list.Add(new DayCell { Day = day, Bounds = rect });
                    Rectangle textRect = new Rectangle(
                        rect.X + 4,
                        rect.Y + 4,
                        rect.Width - 8,
                        rect.Height - 8);

                    g.DrawString(day.ToString(), f, Brushes.Black, textRect, sf);

                    col++;
                    if (col > 6)
                    {
                        col = 0;
                        y += height;
                    }
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
