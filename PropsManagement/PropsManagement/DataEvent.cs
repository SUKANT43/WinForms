using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropsManagement
{
   public class DataEvent:EventArgs
    {
        public string Message { get; }
        public DataEvent(string msg)
        {
            Message = msg;
        } 
    }
}
