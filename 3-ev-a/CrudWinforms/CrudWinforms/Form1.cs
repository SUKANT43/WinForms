using System;
using System.Drawing;
using System.Windows.Forms;

namespace CrudWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            authPanel.Dock = DockStyle.Fill;
            mainPanel.Dock = DockStyle.Fill;
            
            mainPanel.Visible = false;
            tabControl.Dock = DockStyle.Fill;
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            loginPage.Dock = DockStyle.Fill;
            signUpPage.Dock = DockStyle.Fill;

            authPanel.Controls.Add(loginPage);
            authPanel.Controls.Add(signUpPage);

            loginPage.BringToFront();

            loginPage.OnNavigate += HandleNavigation;
            signUpPage.OnNavigate += HandleNavigation;
            navBar.OnNavigate += HandleNavigation;
        }

        private void HandleNavigation(NavigationType nav)
        {
            switch (nav)
            {
                case NavigationType.Login:
                    authPanel.Visible = true;
                    mainPanel.Visible = false;
                    loginPage.BringToFront();
                    break;

                case NavigationType.Signup:
                    authPanel.Visible = true;
                    mainPanel.Visible = false;
                    signUpPage.BringToFront();
                    break;

                case NavigationType.Crud:
                    authPanel.Visible = false;
                    mainPanel.Visible = true;
                    tabControl.SelectedIndex = 0;
                    break;

                case NavigationType.Analytics:
                    authPanel.Visible = false;
                    mainPanel.Visible = true;
                    tabControl.SelectedIndex = 1;
                    break;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

    }
}