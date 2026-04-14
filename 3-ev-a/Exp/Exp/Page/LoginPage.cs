using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp.Page
{
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
            Load += LoginPageLoad;
        }

        private void LoginPageLoad(object sender, EventArgs e)
        {
            ManageSizeAndLoacion();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ManageSizeAndLoacion();
        }

        private void ManageSizeAndLoacion()
        {
            topPanel.Location= new Point((Width / 2)-(topPanel.Width/2),20);
        }
    }
}
