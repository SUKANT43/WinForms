using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPanel
{
    public class UserData
    {
        public string Id { get; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
         
        public UserData()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
