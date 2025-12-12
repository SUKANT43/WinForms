using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNotesFull
{
    public partial class MainForm : Form
    {
        private event EventHandler<DataEventArgs> dataEvent;
        private List<Panel> dataPanelList = new List<Panel>();

        //data panel
        private Panel dataPanel;
        private Panel colorPanel;
        private Label headerLabel;
        private Label timeLabel;
        private Label optionLabel;
        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem editMenuItem;
        private ToolStripMenuItem deleteMenuItem;


        public MainForm(Form sf)
        {
            InitializeComponent();
            dataPanelList = new List<Panel>();
            this.BackColor = Color.FromArgb(32, 32, 32);
            this.ForeColor = Color.White;
            MaximumSize = new Size(650, 1500);
            MinimumSize = new Size(350, 450);
            Load += PageLoadAndResize;
            Resize += PageLoadAndResize;
        }

        public void PageLoadAndResize(object s,EventArgs e)
        {
            bottomPanel.Controls.Clear();
            ManageDesign();
            DataVisible(0,0);
        }

        private void ManageDesign()
        {
            stickyNotesLabel.Font = new Font("Montserrat", 15, FontStyle.Bold);
            addLabel.Font = new Font("Montserrat", 20, FontStyle.Bold);

            stickyNotesLabel.Location = new Point(10,10);
            addLabel.Location = new Point(topPanel.Width-35,10);
        }

        private void DataVisible(int x,int y)
        {
            x = 0;
            y = 0;
            dataPanel = new Panel()
            {
                Location=new Point(200,bottomPanel.Right),
                BorderStyle=BorderStyle.FixedSingle,
            };
            
            dataPanel.BackColor= Color.FromArgb(41, 41, 41);
            dataPanel.Size = new Size(Width-20,120);

            colorPanel = new Panel()
            {
                Location = new Point(0, 0),
                Size = new Size(),
            };
            colorPanel.BackColor = Color.BlueViolet;
            colorPanel.Size = new Size(dataPanel.Width, 10);
            dataPanel.Controls.Add(colorPanel);

            optionLabel = new Label()
            {
                Text="...",
                Location=new Point(dataPanel.Width-40,0),
            };
            optionLabel.Font=new Font("Montserrat", 15, FontStyle.Bold);
            dataPanel.Controls.Add(optionLabel);

            timeLabel = new Label()
            {
                Text="12-12-2025 13:31",
                Location=new Point(dataPanel.Width-90,dataPanel.Height-20),
                ForeColor=Color.Gray
            };
            dataPanel.Controls.Add(timeLabel);

            headerLabel = new Label()
            {
                Text="Hi Hello.........",
                Location=new Point(0,30),
                BorderStyle=BorderStyle.FixedSingle
            };
            headerLabel.Size = new Size(dataPanel.Width - 20, 30);
            headerLabel.Font = new Font("Montserrat", 10, FontStyle.Bold);
            dataPanel.Controls.Add(headerLabel);

            bottomPanel.Controls.Add(dataPanel);
            dataPanelList.Add(dataPanel);
        }

        public MainForm()
        {
        }
    }
}
