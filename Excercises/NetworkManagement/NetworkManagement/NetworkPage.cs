using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkManagement
{
    public partial class NetworkPage : Form
    {
        public NetworkPage()
        {
            InitializeComponent();
            pd.VisibleChanged += Pd_VisibleChanged;
        }

        private void Pd_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        private void NetworkPage_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {

            }
            else
            {

            }
        }

        private void NetworkPage_Load(object sender, EventArgs e)
        {

        }

        private void NetworkPage_Resize(object sender, EventArgs e)
        {

        }
    }
}
