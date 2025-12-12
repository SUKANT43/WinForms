using System;

namespace StickyNotes
{
    public class DataEventArgs : EventArgs
    {
        public string Id { get; }
        public string Header { get; }
        public string Content { get; }

        public DataEventArgs(string header, string content)
        {
            Header = header;
            Content = content;
            Id = null;
        }

        public DataEventArgs(string id, string header, string content)
        {
            Id = id;
            Header = header;
            Content = content;
        }
    }
}
