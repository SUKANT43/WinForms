using System;
using System.Drawing;
using System.Windows.Forms;

namespace ButtonManager
{
    public partial class ButtonsController : UserControl
    {
        private int selectedButton = 1;
        private int totalPages;
        private int buttonPosition = 0;
        private int buttonSize = 40;
        private int gap = 6;

        public int SelectedButton{
            get => selectedButton;
        }

        public ButtonsController(int pages)
        {
            InitializeComponent();
            totalPages = pages;
            Height = 50;
            BuildUI();
        }

        private void BuildUI()
        {
            buttonPosition = 0;
            Controls.Clear();
           Button increment= CreateButton(">>");
            increment.Click+=(sender, e)=>{
                if (selectedButton + 1 <= totalPages)
                {
                    selectedButton++;
                    BuildUI();
                }
            };

            CreatePageButton();

            Button decrement=CreateButton("<<");
            decrement.Click += (s, e) =>
            {
                if (selectedButton - 1 > 0)
                {
                    selectedButton--;
                    BuildUI();
                }
            };
        }

        private void CreatePageButton()
        {
            if (totalPages <= 5)
            {
                for(int i = 1; i <= totalPages;i++)
                {
                    GeneratePageButton(i.ToString());
                }
                return;
            }

            int start = Math.Max(1, selectedButton - 3);
            int end = Math.Min(totalPages, selectedButton + 3);

            if (start > 1)
            {
                GeneratePageButton("1");
                GenerateDotLabel();
            }

            for(int i = start; i <= end; i++)
            {
                GeneratePageButton($"{i}");
            }

            if (end < totalPages)
            {
                GenerateDotLabel();
                GeneratePageButton($"{totalPages}");
            }
        }

        private void GenerateDotLabel()
        {
            Label dots = new Label
            {
                Text = "...",
                Width = buttonSize,
                Height = buttonSize,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(buttonPosition, 10)
            };

            Controls.Add(dots);
            buttonPosition += gap + buttonSize;
        }

        private void GeneratePageButton(string text)
        {
            Button btn = new Button()
            {
                Text = text,
                Width = buttonSize,
                Height = buttonSize,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Location = new Point(buttonPosition)
            };
            if (selectedButton.ToString() == text)
            {
                btn.BackColor = Color.BlueViolet;
            }
            btn.Click+=(s, e)=>{
                Selected(btn.Text);
                btn.BackColor = Color.Red;
            };
            buttonPosition += gap + buttonSize;
            Controls.Add(btn);
        }

        private void Selected(string text)
        {
            selectedButton = int.Parse(text);
            BuildUI();
        }

        private Button CreateButton(string text)
        {
            Button btn= new Button()
            {
                Text = text,
                Width = buttonSize,
                Height = buttonSize,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Location = new Point(buttonPosition)
            };
            buttonPosition += gap + buttonSize;
            Controls.Add(btn);
            return btn;
            
        }
   
    }
}
