using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes
{
   public class ContentStructure
    {
        public string Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string CreatedDateTime { get; set; }

        public ContentStructure(string id, string header, string content, string createdDateTime)
        {
            Id = id;
            Header = header;
            Content = content;
            CreatedDateTime = createdDateTime;
        }
    }
}
