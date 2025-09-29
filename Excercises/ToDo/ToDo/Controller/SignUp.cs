using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Controller
{
    class SignUp
    {
        public string name;
        public string email;
        public string password;
       public SignUp(string mame,string email,string password)
        {
            this.name = mame;
            this.email = email;
            this.password = password;
        }
    }
}
