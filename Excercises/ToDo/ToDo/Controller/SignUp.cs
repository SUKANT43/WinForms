namespace ToDo.Controller
{
    class SignUp
    {
        public string name;
        public string email;
        public string password;
       public SignUp(string name,string email,string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}
