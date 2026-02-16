//using System;
//using System.Drawing;
//using System.Windows.Forms;

//namespace CustomButton
//{
//    //public partial class Form1 : Form
//    //{
//        //Panel panelHome;
//        //Panel panelLogin;
//        //Panel panelRegister;
//        //Panel panelSettings;

//        //Button btnHome;
//        //Button btnLogin;
//        //Button btnRegister;
//        //Button btnSettings;

//        //public Form1()
//        //{
//        //    InitializeComponent();
//        //    CreateLayout();
//        //}

//        //private void CreateLayout()
//        //{
//        //    // ===== Window =====
//        //    this.Text = "Multi Page UI";
//        //    this.Size = new Size(800, 500);

//        //    // ===== Menu Panel =====
//        //    Panel menu = new Panel();
//        //    menu.Dock = DockStyle.Left;
//        //    menu.Width = 150;
//        //    menu.BackColor = Color.FromArgb(40, 40, 40);
//        //    this.Controls.Add(menu);

//        //    // Buttons
//        //    btnHome = CreateMenuButton("Home", 0);
//        //    btnLogin = CreateMenuButton("Login", 50);
//        //    btnRegister = CreateMenuButton("Register", 100);
//        //    btnSettings = CreateMenuButton("Settings", 150);

//        //    menu.Controls.Add(btnHome);
//        //    menu.Controls.Add(btnLogin);
//        //    menu.Controls.Add(btnRegister);
//        //    menu.Controls.Add(btnSettings);

//        //    // ===== Pages =====
//        //    panelHome = CreatePage(Color.LightSkyBlue, "HOME PAGE");
//        //    panelLogin = CreatePage(Color.LightGreen, "LOGIN PAGE");
//        //    panelRegister = CreatePage(Color.LightSalmon, "REGISTER PAGE");
//        //    panelSettings = CreatePage(Color.Khaki, "SETTINGS PAGE");

//        //    this.Controls.Add(panelHome);
//        //    this.Controls.Add(panelLogin);
//        //    this.Controls.Add(panelRegister);
//        //    this.Controls.Add(panelSettings);

//        //    // ===== Navigation =====
//        //    btnHome.Click += (s, e) => ShowPage(panelHome);
//        //    btnLogin.Click += (s, e) => ShowPage(panelLogin);
//        //    btnRegister.Click += (s, e) => ShowPage(panelRegister);
//        //    btnSettings.Click += (s, e) => ShowPage(panelSettings);

//        //    // Default page
//        //    ShowPage(panelHome);
//        //}

//        //// Create left menu button
//        //private Button CreateMenuButton(string text, int top)
//        //{
//        //    return new Button()
//        //    {
//        //        Text = text,
//        //        Top = top,
//        //        Width = 150,
//        //        Height = 50,
//        //        FlatStyle = FlatStyle.Flat,
//        //        ForeColor = Color.White,
//        //        BackColor = Color.FromArgb(40, 40, 40)
//        //    };
//        //}

//        //// Create page panel
//        //private Panel CreatePage(Color color, string title)
//        //{
//        //    Panel p = new Panel();
//        //    p.Dock = DockStyle.Fill;
//        //    p.BackColor = color;

//        //    Label lbl = new Label();
//        //    lbl.Text = title;
//        //    lbl.Font = new Font("Segoe UI", 22, FontStyle.Bold);
//        //    lbl.AutoSize = true;
//        //    lbl.Location = new Point(250, 150);

//        //    p.Controls.Add(lbl);
//        //    return p;
//        //}

//        //// Core logic
//        //private void ShowPage(Control page)
//        //{
//        //    page.BringToFront();
//        //}
//    //}
//}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomButton
{
    public partial class Form1 : Form
    {
        TabControl tab;

        public Form1()
        {
            InitializeComponent();
            CreateTabs();
        }

        private void CreateTabs()
        {
            // TabControl
            tab = new TabControl();
            tab.Dock = DockStyle.Fill;
            tab.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.Controls.Add(tab);

            // Pages
            TabPage home = CreatePage("Home", Color.LightSkyBlue);
            TabPage login = CreatePage("Login", Color.LightGreen);
            TabPage register = CreatePage("Register", Color.LightSalmon);
            TabPage settings = CreatePage("Settings", Color.Khaki);

            // Add pages
            tab.TabPages.Add(home);
            tab.TabPages.Add(login);
            tab.TabPages.Add(register);
            tab.TabPages.Add(settings);

            // Example control inside Login page
            TextBox txtUser = new TextBox();
            //txtUser.PlaceholderText = "Username";
            txtUser.Location = new Point(50, 50);
            login.Controls.Add(txtUser);

            Button btn = new Button();
            btn.Text = "Login";
            btn.Location = new Point(50, 90);
            login.Controls.Add(btn);

            // Detect page change
            tab.SelectedIndexChanged += TabChanged;
        }

        private TabPage CreatePage(string title, Color color)
        {
            TabPage page = new TabPage(title);
            page.BackColor = color;

            Label lbl = new Label();
            lbl.Text = title.ToUpper() + " PAGE";
            lbl.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lbl.AutoSize = true;
            lbl.Location = new Point(200, 150);

            page.Controls.Add(lbl);
            return page;
        }

        private void TabChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Current Tab: " + tab.SelectedTab.Text);
        }
    }
}
