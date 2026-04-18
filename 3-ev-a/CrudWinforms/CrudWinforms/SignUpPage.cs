using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWinforms
{
    public partial class SignUpPage : UserControl
    {
        public Action<NavigationType> OnNavigate;
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void LoginLabelClick(object sender, EventArgs e)
        {
            OnNavigate?.Invoke( NavigationType.Login);
        }
    }
}
