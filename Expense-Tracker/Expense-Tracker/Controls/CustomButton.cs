using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Expense_Tracker.Controls
{
    public class CustomButton : Control
    {
        private int _height;

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        private int _width;

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        private int _padding;

        public int Padding
        {
            get => _padding;
            set => _padding = value;
        }

        private Color _background;

        public Color Background
        {
            get => _background;
            set => _background = value;
        }

        private Color _foreground;

        public Color Foreground
        {
            get => _foreground;
            set => _foreground = value;
        }

        Rectangle BaseRectangle = new Rectangle();

        public CustomButton()
        {
            this.Paint += PaintButton;
        }

        private void PaintButton(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle();
            rect.Width = Width;
            rect.Height = Height;

        }
    }
}
