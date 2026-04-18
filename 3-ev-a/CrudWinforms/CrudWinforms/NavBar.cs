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
    public partial class NavBar : UserControl
    {
        public event Action<NavigationType> OnNavigate;

        public NavBar()
        {
            InitializeComponent();
            analyticButton.BackColor = Color.Yellow;
            curdButton.BackColor = Color.Red;

        }

        private void CrudButtonClick(object sender, EventArgs e)
        {
            analyticButton.BackColor = Color.Yellow;
            curdButton.BackColor = Color.Red;
            OnNavigate?.Invoke(NavigationType.Crud);
        }

        private void AnalyticButtonClick(object sender, EventArgs e)
        {
            analyticButton.BackColor = Color.Red;
            curdButton.BackColor = Color.Yellow;
            OnNavigate?.Invoke(NavigationType.Analytics);
        }
    }
}
