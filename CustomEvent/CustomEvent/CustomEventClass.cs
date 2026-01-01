using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEvent
{
    public class CustomEventClass : EventArgs
    {
        public string Message { get; set; }

        public CustomEventClass(string message)
        {
            Message = message;
        }

        
    }

}
