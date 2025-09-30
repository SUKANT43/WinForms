using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Controller
{
    class TodoController
    {
        private string title;
        private string description;

        public TodoController(string title,string description)
        {
            this.title = title;
            this.description = description;
        }
    }
}
