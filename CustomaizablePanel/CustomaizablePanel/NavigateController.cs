using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomaizablePanel
{
    class NavigateController:Control
    {
        public int NumberOfPage { get; set; } = 6;
        public int SelectedPage { get; set; }

        public NavigateController()
        {
            InitalizeNavigator();
        }

        private void InitalizeNavigator()
        {
            if (NumberOfPage <= 6)
            {
                Invalidate();
            }
            else
            {

            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

    }
}
