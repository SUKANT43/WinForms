using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesFull
{
    class DataEventArgs:EventArgs
    {
        string Id { get; }
        string Header { get; }
        string Content { get; }
        string CreatedAt { get; }
        string SelectedColor { get; }
        public DataEventArgs(string Header,string Content)
        {
            this.Header = Header;
            this.Content = Content;
            this.SelectedColor = SelectedColor;
        }
        public DataEventArgs(string Id,string Header,string Content,string CreatedAt,string SelectedColor)
        {
            this.Id = Id;
            this.Header = Header;
            this.Content = Content;
            this.CreatedAt = CreatedAt;
            this.SelectedColor = SelectedColor;
        }
    }
}
