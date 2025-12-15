using System;

namespace StickyNotesFull
{
    public class DataEventArgs : EventArgs
    {
        public string Id { get; }
        public string Header { get; }
        public string Content { get; }
        public string CreatedAt { get; }
        public string SelectedColor { get; }
        public string FileName { get; }

        public DataEventArgs(string header, string content, string color)
        {
            Header = header;
            Content = content;
            SelectedColor = color;
        }

        public DataEventArgs(string id, string header, string content,  string createdAt, string color, string fileName)
        {
            Id = id;
            Header = header;
            Content = content;
            CreatedAt = createdAt;
            SelectedColor = color;
            FileName = fileName;
        }
    }
}
