using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DragTimer
{
    public partial class DragTimerController : UserControl
    {
        private int min = 0;
        private int max = 100;
        private int step = 1;
        private int speed = 10;



        public int Min{
            get => min;
            set
            {
                if (value < 0 || value>=100)
                {
                    min = 0;
                }
                else
                {
                    min = value;
                }
            }
        }

        public int Max
        {
            get => max;
            set
            {
                if (value >100 || value<0)
                {
                    max = 100;
                }
                else
                {
                    max = value;
                }
            }
        }

        public int Step
        {
            get => step;
            set
            {
                if (value > 100 || value < 0)
                {
                    step = 1;
                }
                else
                {
                    step = value;
                }
            }
        }

        public int Speed
        {
            get => speed;
            set
            {
                if (value > 100 || value < 0)
                {
                    speed = 100;
                }
                else
                {
                    speed = value;
                }
            }
        }


        private int currentValue = 0;
        private int lastMouseX;
        private bool mouseMove;
        private int mid;
        private bool isCustomValue;
        public DragTimerController()
        {
            InitializeComponent();
            mouseMove = false;
            mid = showValueTextBox.Location.X + showValueTextBox.Width / 2;

            showValueTextBox.MouseDown += TextBoxMouseClick;
            showValueTextBox.MouseMove += TextBoxMouseMove;
            showValueTextBox.MouseUp += TextBoxMouseUp;
            showValueTextBox.DoubleClick += TextBoxDoubleClick;
        }

        

        private void TextBoxDoubleClick(object s,EventArgs e)
        {
            mouseMove = false;
            isCustomValue = true;
            decreaseLabel.Visible = false;
            increaseLabel.Visible = false;
            okLabel.Visible = true;
            showValueTextBox.ReadOnly = false;
        }

        private void OkLabelClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(showValueTextBox.Text))
            {
                currentValue = 1;
            }

            else if(!int.TryParse(showValueTextBox.Text,out int value))
            {
                currentValue = 1;
            }

            else
            {
                int n = int.Parse(showValueTextBox.Text);
                if (n > 100)
                {
                    currentValue = 100;
                }
                else if (n < 0)
                {
                    currentValue = 1;
                }
                else
                {
                    currentValue = n;
                }
            }
            min = 0;
            max = 100;
            step = 1;
            speed = 10;

            showValueTextBox.Text = currentValue.ToString();
            mouseMove = false;
            decreaseLabel.Visible = true;
            increaseLabel.Visible = true;
            okLabel.Visible = false;
            showValueTextBox.ReadOnly = true;
            isCustomValue = false;
            return;

        }

        private void TextBoxMouseClick(object s,MouseEventArgs e)
        {
            mouseMove = true;
            lastMouseX = e.X;
        }

        private void TextBoxMouseMove(object s, MouseEventArgs e)
        {
            if (!mouseMove )
            {
                return;
            }

            int deltaX = e.X - lastMouseX;

            if (Math.Abs(deltaX) < speed)
                return;


            int changeOccurs = lastMouseX - e.X;
            if(e.X< showValueTextBox.Location.X + showValueTextBox.Width / 2 && lastMouseX<e.X )
            {
                currentValue += GetStep();
                currentValue = CheckStep();
                showValueTextBox.Text = currentValue.ToString();
                lastMouseX = e.X;
            }

            if (e.X < showValueTextBox.Location.X + showValueTextBox.Width / 2 && lastMouseX > e.X)
            {
                currentValue -= GetStep();
                currentValue = CheckStep();
                showValueTextBox.Text = currentValue.ToString();
                lastMouseX = e.X;
            }

            if (e.X > showValueTextBox.Location.X + showValueTextBox.Width / 2 && lastMouseX > e.X)
            {
                currentValue -= GetStep();
                currentValue = CheckStep();
                showValueTextBox.Text = currentValue.ToString();
                lastMouseX = e.X;
            }

            if (e.X > showValueTextBox.Location.X + showValueTextBox.Width / 2 && lastMouseX < e.X)
            {
                currentValue += GetStep();
                currentValue = CheckStep();
                showValueTextBox.Text = currentValue.ToString();
                lastMouseX = e.X;
            }

        }

        private void TextBoxMouseUp(object s,MouseEventArgs e)
        {
            mouseMove = false;
            lastMouseX = 0;
        }


        private void IncreaseLabelClick(object sender, EventArgs e)
        {
            currentValue += GetStep();
            currentValue = CheckStep();
            showValueTextBox.Text = currentValue.ToString();
            return;
        }


        private void DecreaseLabelClick(object sender, EventArgs e)
        {
            currentValue -= GetStep();
            currentValue = CheckStep();
            showValueTextBox.Text = currentValue.ToString();
            return;
        }

        private int GetStep()
        {
            return step > 0 ? step : 1;
        }

        private int CheckStep()
        {
            if (currentValue > max)
            {
               return currentValue = max;
            }
            else if (currentValue < min)
            {
               return currentValue = min;
            }
            return currentValue;
        }

       
    }
}
