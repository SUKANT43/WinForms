using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp.Components
{
    class CustomButton : Control
    {
        private Color _backGroundColor;
        public Color BackGroundColor
        {
            get => _backGroundColor;
            set
            {
                _backGroundColor = value;
            }
        }

        private Color _foreGroundColor;
        public Color ForeGroundColor
        {
            get => _foreGroundColor;
            set
            {
                _foreGroundColor = value;
            }
        }

        private int _cornerRadius;
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(0, value);
            }
        }

    }
}
