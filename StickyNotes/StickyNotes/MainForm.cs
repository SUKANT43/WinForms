using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNotes
{
    public partial class MainForm : Form
    {
        private List<ContentStructure> contentList = new List<ContentStructure>();
        public MainForm()
        {
            InitializeComponent();
            MaximumSize = new Size(500, 600);
            MinimumSize = new Size(500, 600);
            Load += ResizeAndLoad;
            Resize += ResizeAndLoad;
        }

        public void ResizeAndLoad(object s,EventArgs e)
        {
            stickyNotesLabel.Location = new Point(
                topPanel.Width/2-(stickyNotesLabel.Width)+80,
                topPanel.Height / 2 - (stickyNotesLabel.Height)
                );

            addLabel.Location = new Point(stickyNotesLabel.Width+190 ,
                stickyNotesLabel.Height
                );

            selectAllCheckBox.Location = new Point(stickyNotesLabel.Width + 230,
             stickyNotesLabel.Height+13
             );
        }

    }
    public class ContentStructure
    {
        public string Id;
        public string Header;
        public string Content;

        public ContentStructure(string id, string header, string content)
        {
            Id = id;
            Header = header;
            Content = content;
        }
    }

}
