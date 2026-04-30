using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                ()=>LoadData(),
                ()=>FetchConfig(),
                ()=>InitializeCache()
                );


            Console.ReadLine();
        }
        public static void LoadData()
        {
            Console.WriteLine("Load data");
        }

        public static void FetchConfig()
        {
            Console.WriteLine("Fetch config");
        }

        public static void InitializeCache()
        {
            Console.WriteLine("Initalize cache");
        }
    }
}
