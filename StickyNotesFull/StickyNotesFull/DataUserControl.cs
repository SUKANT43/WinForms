using System;
using System.Drawing;
using System.Windows.Forms;

namespace StickyNotesFull
{
    public partial class DataUserControl : UserControl
    {
        public CustomEventData Data { get; private set; }

        public event EventHandler EditRequested;
        public event EventHandler DeleteRequested;

        private ContextMenuStrip menu;
        private CheckBox cb;
        private bool isSelectMode;

        public bool IsSelected => cb.Checked;

        public DataUserControl(CustomEventData data, int width)
        {
            InitializeComponent();
            Data = data;
            Width = width;
            Height = 120;

            BuildUI();
        }

        public void SetSelectMode(bool enable)
        {
            isSelectMode = enable;
            cb.Visible = enable;
            cb.Checked = false;
            Cursor = enable ? Cursors.Hand : Cursors.Default;
        }

        private void BuildUI()
        {
            BackColor = Color.FromArgb(41, 41, 41);
            BorderStyle = BorderStyle.FixedSingle;

            Panel colorPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 10,
                BackColor =
                    Data.SelectedColor == "green" ? Color.Green :
                    Data.SelectedColor == "purple" ? Color.BlueViolet :
                    Color.FromArgb(255, 128, 128)
            };

            Label headerLabel = new Label
            {
                Text = Data.Header,
                Font = new Font("Montserrat", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(40, 30),
                Size = new Size(Width - 80, 30)
            };

            Label timeLabel = new Label
            {
                Text = Data.CreatedAt,
                ForeColor = Color.Gray,
                Location = new Point(Width - 100, 95)
            };

            cb = new CheckBox
            {
                Location = new Point(10, 85),
                Visible = false
            };

            Label optionLabel = new Label
            {
                Text = "...",
                Font = new Font("Montserrat", 15, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(Width - 40, 0),
                Cursor = Cursors.Hand
            };

            BuildContextMenu(optionLabel);

            MouseClick += ToggleSelection;
            foreach (Control c in Controls)
                c.MouseClick += ToggleSelection;

            DoubleClick += (s, e) =>
            {
                if (!isSelectMode)
                    EditRequested?.Invoke(this, EventArgs.Empty);
            };

            Controls.Add(colorPanel);
            Controls.Add(optionLabel);
            Controls.Add(headerLabel);
            Controls.Add(timeLabel);
            Controls.Add(cb);
        }

        private void ToggleSelection(object sender, MouseEventArgs e)
        {
            if (isSelectMode)
                cb.Checked = !cb.Checked;
        }

        private void BuildContextMenu(Label optionLabel)
        {
            menu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete")
            {
                ForeColor = Color.Red
            };

            editItem.Click += (s, e) => EditRequested?.Invoke(this, EventArgs.Empty);
            deleteItem.Click += (s, e) => DeleteRequested?.Invoke(this, EventArgs.Empty);

            menu.Items.Add(editItem);
            menu.Items.Add(deleteItem);

            optionLabel.Click += (s, e) =>
            {
                if (!isSelectMode)
                    menu.Show(optionLabel, new Point(0, optionLabel.Height));
            };
        }
    }
}
