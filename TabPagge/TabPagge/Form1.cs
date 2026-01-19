using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabPagge
{
    public partial class Form1 : Form
    {
        TabControl tabControl1;
        TabPage tabPage1;
        TabPage tabPage2;

        Button btnGoPage1;
        Button btnGoPage2;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create TabControl
            tabControl1 = new TabControl();
            tabControl1.Dock = DockStyle.Fill;

            // Create 2 TabPages
            tabPage1 = new TabPage("Page 1");
            tabPage2 = new TabPage("Page 2");

            // Add TabPages to TabControl
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.TabPages.Add(tabPage2);

            // Add TabControl to Form
            this.Controls.Add(tabControl1);

            // ---- Page 1 Controls ----
            Label lb1 = new Label();
            lb1.Text = "This is Page 1";
            lb1.AutoSize = true;
            lb1.Location = new Point(30, 30);

            btnGoPage2 = new Button();
            btnGoPage2.Text = "Go to Page 2";
            btnGoPage2.Location = new Point(30, 80);
            btnGoPage2.Click += BtnGoPage2_Click;

            tabPage1.Controls.Add(lb1);
            tabPage1.Controls.Add(btnGoPage2);

            // ---- Page 2 Controls ----
            Label lb2 = new Label();
            lb2.Text = "This is Page 2";
            lb2.AutoSize = true;
            lb2.Location = new Point(30, 30);

            btnGoPage1 = new Button();
            btnGoPage1.Text = "Go to Page 1";
            btnGoPage1.Location = new Point(30, 80);
            btnGoPage1.Click += BtnGoPage1_Click;

            tabPage2.Controls.Add(lb2);
            tabPage2.Controls.Add(btnGoPage1);

            // Default open Page 1
            tabControl1.SelectedTab = tabPage1;
        }

        private void BtnGoPage2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void BtnGoPage1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
    }
}
