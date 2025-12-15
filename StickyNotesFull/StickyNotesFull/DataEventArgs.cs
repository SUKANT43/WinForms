using System;

namespace StickyNotesFull
{
    public class CustomEventData
    {
        public string Id { get; }
        public string Header { get; }
        public string Content { get; }
        public string CreatedAt { get; }
        public string SelectedColor { get; }
        public string FileName { get; }

        public CustomEventData(string header, string content, string color)
        {
            Header = header;
            Content = content;
            SelectedColor = color;
        }

        public CustomEventData(string id, string header, string content,  string createdAt, string color, string fileName)
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
