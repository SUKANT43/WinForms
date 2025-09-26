using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace wf
{
    public partial class Form1 : Form
    {
        private Label lblCPU;
        private Label lblRAM;
        private Timer timer;
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        public Form1()
        {
            InitializeComponent();
            //SplitContainer split = new SplitContainer();
            //split.Dock = DockStyle.Fill;
            //split.Orientation = Orientation.Vertical; // left & right panels
            //split.SplitterDistance = 200; // initial width of left panel

            //// Add controls to Panel1 and Panel2
            //split.Panel1.BackColor = Color.LightBlue;
            //split.Panel2.BackColor = Color.LightGreen;

            //split.Panel1.Controls.Add(new Button() { Text = "Left Button" });
            //split.Panel2.Controls.Add(new Button() { Text = "Right Button" });

            //this.Controls.Add(split);
            //ListView ls = new ListView();
            //ls.Dock = DockStyle.Fill;
            //ls.View = View.Details;          // 🔑 must set this to see columns
            //ls.FullRowSelect = true;         // (optional) selects entire row

            //// Add columns
            //ls.Columns.Add("Subject", 100);
            //ls.Columns.Add("Mark", 50);

            //// Add row (first item text is for first column)
            //ListViewItem l1 = new ListViewItem("Maths");  // goes to "Subject"
            //l1.SubItems.Add("100");                       // goes to "Mark"
            //ls.Items.Add(l1);

            //// Add another row
            //ListViewItem l2 = new ListViewItem("Science");
            //l2.SubItems.Add("95");
            //ls.Items.Add(l2);

            //// Add ListView to form
            //Controls.Add(ls);
            //MaskedTextBox mtxt = new MaskedTextBox();
            //mtxt.Location = new Point(20, 20);
            //mtxt.Mask = "(999) 000-0000";  // Phone number format
            //mtxt.PromptChar = '_';         // Placeholder character
            //mtxt.Width = 120;

            //Button btn = new Button();
            //btn.Text = "Check";
            //btn.Location = new Point(20, 60);

            //btn.Click += (s, e) =>
            //{
            //    if (mtxt.MaskCompleted)
            //        MessageBox.Show("Phone: " + mtxt.Text);
            //    else
            //        MessageBox.Show("Please enter full number!");
            //};

            //this.Controls.Add(mtxt);
            //this.Controls.Add(btn);
            //this.Text = "NotifyIcon Demo";
            //this.Size = new Size(300, 200);

            //NotifyIcon notifyIcon = new NotifyIcon();
            //notifyIcon.Icon = SystemIcons.Information;  // Use default system icon
            //notifyIcon.Text = "My Tray App";
            //notifyIcon.Visible = true;

            //// Add context menu
            //ContextMenuStrip menu = new ContextMenuStrip();
            //menu.Items.Add("Show App", null, (s, e) => this.Show());
            //menu.Items.Add("Exit", null, (s, e) => Application.Exit());

            //notifyIcon.ContextMenuStrip = menu;

            //// Show balloon notification
            //notifyIcon.ShowBalloonTip(3000, "Hello!", "App is running in system tray.", ToolTipIcon.Info);

            //this.Resize += (s, e) =>
            //{
            //    if (this.WindowState == FormWindowState.Minimized)
            //        this.Hide()The remote name could not be resolved: 'via.placeholder.com';  // Hide window when minimized
            //};
            //this.Text = "PictureBox from URL";
            //this.Size = new System.Drawing.Size(400, 400);

            //PictureBox pictureBox = new PictureBox();
            //pictureBox.Dock = DockStyle.Fill;
            //pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            //// Load image from the internet
            //pictureBox.Load("https://imgs.search.brave.com/tu80peDDYz46QJ-k5hQt-xJBiKLPdXDaWtkdTw-6rH8/rs:fit:500:0:1:0/g:ce/aHR0cHM6Ly9jZG4t/ZnJvbnQuZnJlZXBp/ay5jb20vaG9tZS9h/bm9uLXJ2bXAvY3Jl/YXRpdmUtc3VpdGUv/YXVkaW8tY3JlYXRp/b24vdmlzdWFscy1z/b25ncy53ZWJw");

            //this.Controls.Add(pictureBox);
            //this.Text = "ToolTip Example";
            //this.Size = new System.Drawing.Size(300, 200);

            //Button btn = new Button();
            //btn.Text = "Save";
            //btn.Location = new System.Drawing.Point(50, 50);

            //TextBox txt = new TextBox();
            //txt.Location = new System.Drawing.Point(50, 100);

            //// Create ToolTip
            //ToolTip toolTip = new ToolTip();
            //toolTip.SetToolTip(btn, "Click here to save your work.");
            //toolTip.SetToolTip(txt, "Enter your name here.");

            //this.Controls.Add(btn);
            //this.Controls.Add(txt);
            //TreeView treeView = new TreeView();
            //treeView.Dock = DockStyle.Fill;

            //// Add root nodes
            //TreeNode root1 = new TreeNode("Fruits");
            //TreeNode root2 = new TreeNode("Vegetables");

            //// Add child nodes
            //root1.Nodes.Add("Apple");
            //root1.Nodes.Add("Banana");
            //root1.Nodes.Add("Mango");

            //root2.Nodes.Add("Carrot");
            //root2.Nodes.Add("Tomato");
            //root2.Nodes.Add("Potato");

            //// Add root nodes to TreeView
            //treeView.Nodes.Add(root1);
            //treeView.Nodes.Add(root2);

            //// Handle node selection
            //treeView.AfterSelect += (s, e) =>
            //{
            //    MessageBox.Show("You selected: " + e.Node.Text);
            //};

            //this.Controls.Add(treeView);

            //WebBrowser webBrowser = new WebBrowser();
            //webBrowser.Dock = DockStyle.Fill;

            //// Navigate to a website

            //webBrowser.Navigate("youtube.com");

            //// Handle page load completed
            //webBrowser.DocumentCompleted += (s, e) =>
            //{
            //    MessageBox.Show("Page Loaded: " + webBrowser.Url);
            //};

            //this.Controls.Add(webBrowser);
            //NotifyIcon nf = new NotifyIcon();
            //nf.Icon = SystemIcons.Warning;
            //nf.Visible = true;
            //nf.BalloonTipTitle = "hi";
            //nf.BalloonTipText = "This is a simple notification.";
            //nf.ShowBalloonTip(3000);
            //    this.Text = "PC Performance Monitor";
            //    this.Size = new System.Drawing.Size(300, 150);

            //    lblCPU = new Label() { Text = "CPU: 0%", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            //    lblRAM = new Label() { Text = "RAM: 0%", Location = new System.Drawing.Point(20, 50), AutoSize = true };

            //    this.Controls.Add(lblCPU);
            //    this.Controls.Add(lblRAM);

            //    // Setup Performance Counters
            //    cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            //    ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            //    // Timer for updating performance
            //    timer = new Timer();
            //    timer.Interval = 1000; // update every second
            //    timer.Tick += Timer_Tick;
            //    timer.Start();

            //}
            //private void Timer_Tick(object sender, EventArgs e)
            //{
            //    float cpuUsage = cpuCounter.NextValue();
            //    float ramUsage = ramCounter.NextValue();

            //    lblCPU.Text = $"CPU Usage: {cpuUsage:F1}%";
            //    lblRAM.Text = $"RAM Usage: {ramUsage:F1}%";
            //}


            //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            //{
            //    linkLabel1.Text = "hi";
            //}

        }
    }
}
