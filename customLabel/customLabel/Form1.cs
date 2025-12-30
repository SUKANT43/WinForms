using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customLabel
{
    public partial class Form1 : Form
    {
        int x = 10;
        int y = 10;

        private List<TextData> ls = new List<TextData>();
        public Form1()
        {
            InitializeComponent();
            //Paint += PagePaint;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox.Text))
            {
                MessageBox.Show("Fill all fields");
                return;
            }
            ls.Add(new TextData(text:richTextBox.Text));
            ShowLabel();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ShowLabel();
        }

        private void ShowLabel()
        {
            topPanel.Controls.Clear();
            y = 10;
            foreach (var list in ls)
            {
                Label lbl = new Label()
                {
                    Name = list.Id.ToString(),
                    Text = list.Text,
                    Font = new Font("Segoe UI", 10f),
                    BackColor = Color.LightBlue,
                    AutoSize = false,
                    Padding = new Padding(),
                    Location = new Point(x, y)
                };

                

                int maxWidth = topPanel.Width - 30;

                using (Graphics g = topPanel.CreateGraphics())
                {
                    SizeF size = g.MeasureString(lbl.Text, lbl.Font);

                    int width = (int)Math.Ceiling(size.Width) ;
                    int height;

                    if (width > maxWidth)
                    {
                        width = maxWidth;
                        SizeF wrapped = g.MeasureString(lbl.Text, lbl.Font, width);
                        height = (int)Math.Ceiling(wrapped.Height) ;
                        if (height > 100)
                        {
                            height += 100;
                        }
                    }
                    else
                    {
                        height = (int)Math.Ceiling(size.Height) ;
                    }

                    lbl.Size = new Size(width+10, height);
                }

                topPanel.Controls.Add(lbl);
                Button delBtn = new Button
                {
                    Text = "Delete",
                    Height = 20,
                    Location = new Point(lbl.Right -30, lbl.Bottom),
                };
                delBtn.Click += (s, e) =>
                {
                    ls.Remove(list);
                    ShowLabel();
                };
                topPanel.Controls.Add(delBtn);


                y += lbl.Height + 40;
            }
        }



    }
}

public class TextData
{
    public int Id { get; private set; }
    public string Text { get; set; }
    private int idGenerator = 1;
    public TextData(string text)
    {
        Id = idGenerator++;
        Text = text;
    }
}
