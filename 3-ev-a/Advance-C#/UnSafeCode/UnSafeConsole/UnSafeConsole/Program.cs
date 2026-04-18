using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnSafeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int value = 42;
                int* pointer = &value;
                Console.WriteLine(*pointer);
                *pointer = 100;
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
