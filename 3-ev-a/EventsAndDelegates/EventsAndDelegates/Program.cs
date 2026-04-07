using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class Publisher1
    {
        public delegate void NotifyHandler(string message);
        public event NotifyHandler OnNotify;
        //public event Action<string> OnNotify;
        public void SendMessage(string msg)
        {
            OnNotify?.Invoke(msg);
        }
    }

    public class Publisher2
    {
        public event EventHandler OnNotify;
        public void SendMessage()
        {
            OnNotify?.Invoke(this, EventArgs.Empty);
        }
    }

    public class MessageClass:EventArgs
    {
        public string Message { get; set; }
    }

    public class Publishere3
    {
        public event EventHandler<MessageClass> OnNotify;
        public void SendMessage(MessageClass data)
        {
            OnNotify?.Invoke(this, data);
        }
    }

    public class Program
    {
        static void Main()
        {
            Publisher1 publisher1 = new Publisher1();
            publisher1.OnNotify += ShowMessage1;
            publisher1.SendMessage("hello1");

            Publisher2 publisher2 = new Publisher2();
            publisher2.OnNotify +=ShowMessage2 ;
            publisher2.SendMessage();

            Publishere3 publishere3 = new Publishere3();
            publishere3.OnNotify += ShowMessage3;
            publishere3.SendMessage(new MessageClass { Message = "hello3" });
            Console.ReadLine();
        }

        private static void ShowMessage3(object sender, MessageClass e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(sender.GetType().Name);
        }

        private static void ShowMessage2(object sender, EventArgs e)
        {
            Console.WriteLine("hello2");
        }

        static void ShowMessage1(string message)
        {
            Console.WriteLine(message);
        }
    }

}
