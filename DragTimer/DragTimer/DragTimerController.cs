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
        private int step = 5;
        private int speed = 10;

        public int Min
        {
            get => min;
            set
            {
                if (value < 0 || value >= 100)
                    min = 0;
                else
                    min = value;
            }
        }

        public int Max
        {
            get => max;
            set
            {
                if (value > 100 || value < 0)
                    max = 100;
                else
                    max = value;
            }
        }

        public int Step
        {
            get => step;
            set
            {
                if (value > 100 || value < 0)
                    step = 1;
                else
                    step = value;
            }
        }

        public int Speed
        {
            get => speed;
            set
            {
                if (value > 100 || value < 0)
                    speed = 100;
                else
                    speed = value;
            }
        }

        private int currentValue = 1;
        private int lastMouseX;
        private bool mouseMove;
        private int mid;
        private bool isCustomValue;

        public DragTimerController()
        {
            InitializeComponent();

            showLabel.DisplayText = currentValue.ToString();
            showLabel.Visible = true;

            showValueTextBox.Visible = false;
            showValueTextBox.ReadOnly = false;

            showLabel.MouseDown += TextBoxMouseClick;
            showLabel.MouseMove += TextBoxMouseMove;
            showLabel.MouseUp += TextBoxMouseUp;
            showLabel.DoubleClick += TextBoxDoubleClick;

            mid = showLabel.Location.X + showLabel.Width / 2;
        }

        private void TextBoxDoubleClick(object s, EventArgs e)
        {
            mouseMove = false;
            isCustomValue = true;

            decreaseLabel.Visible = false;
            increaseLabel.Visible = false;
            okButton.Visible = true;

            showValueTextBox.Text = currentValue.ToString();
            showValueTextBox.Visible = true;
            showLabel.Visible = false;

            showValueTextBox.Focus();
            showValueTextBox.SelectAll();
        }

        private void OkbuttonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(showValueTextBox.Text))
            {
                currentValue = 1;
            }
            else if (!int.TryParse(showValueTextBox.Text, out int value))
            {
                currentValue = 1;
            }
            else
            {
                int n = int.Parse(showValueTextBox.Text);
                if (n > 100)
                    currentValue = 100;
                else if (n < 0)
                    currentValue = 1;
                else
                    currentValue = n;
            }

            min = 0;
            max = 100;
            step = 1;
            speed = 10;

            showLabel.DisplayText = currentValue.ToString();

            showValueTextBox.Visible = false;
            showLabel.Visible = true;

            decreaseLabel.Visible = true;
            increaseLabel.Visible = true;
            okButton.Visible = false;

            isCustomValue = false;
        }

        private void TextBoxMouseClick(object s, MouseEventArgs e)
        {
            mouseMove = true;
            lastMouseX = e.X;
        }

        private void TextBoxMouseMove(object s, MouseEventArgs e)
        {
            if (!mouseMove)
                return;

            int centerX = showLabel.Width / 2;

            int deltaX = e.X - lastMouseX;
            if (Math.Abs(deltaX) < speed)
                return;

            if (e.X < centerX && lastMouseX < e.X)
            {
                currentValue += GetStep();
            }
            else if (e.X < centerX && lastMouseX > e.X)
            {
                currentValue -= GetStep();
            }

            else if (e.X > centerX && lastMouseX > e.X)
            {
                currentValue -= GetStep();
            }
            else if (e.X > centerX && lastMouseX < e.X)
            {
                currentValue += GetStep();
            }

            currentValue = CheckStep();
            showLabel.DisplayText = currentValue.ToString();
            lastMouseX = e.X;
        }

        private void TextBoxMouseUp(object s, MouseEventArgs e)
        {
            mouseMove = false;
            lastMouseX = 0;
        }

        private void IncreaseLabelClick(object sender, EventArgs e)
        {
            currentValue += GetStep();
            currentValue = CheckStep();
            showLabel.DisplayText = currentValue.ToString();
        }

        private void DecreaseLabelClick(object sender, EventArgs e)
        {
            currentValue -= GetStep();
            currentValue = CheckStep();
            showLabel.DisplayText = currentValue.ToString();
        }

        private int GetStep()
        {
            return step > 0 ? step : 1;
        }

        private int CheckStep()
        {
            if (currentValue > max)
                return currentValue = max;
            else if (currentValue < min)
                return currentValue = min;

            return currentValue;
        }
    }
        
}
