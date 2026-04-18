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
    public partial class LoginPage : UserControl
    {
        public event Action<NavigationType> OnNavigate;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void SignInLabelClick(object sender, EventArgs e)
        {
            OnNavigate?.Invoke(NavigationType.Signup);
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            OnNavigate?.Invoke(NavigationType.Crud);
        }
    }
}
