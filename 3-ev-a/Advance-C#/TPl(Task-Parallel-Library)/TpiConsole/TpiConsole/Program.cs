using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TpiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //insted of this we can simply use parallel
            //Task<string> dataTask = Task.Run(() => LoadData());
            //Task<string> configTask = Task.Run(() => FetchConfig());

            //Task.WaitAll(dataTask, configTask);

            //Console.WriteLine(dataTask.Result);
            //Console.WriteLine(configTask.Result);

            Parallel.Invoke(
               LoadData,
               FetchConfig,
               InitalizeCache
                );

            var numbers = Enumerable.Range(1, 10_000_000);
            var result = numbers.Where(n => n % 2 == 0).ToList();

            //var parallelResult = numbers.AsParallel().Where(n => n % 2 == 0).ToList();

            //foreach(var n in parallelResult)
            //{
            //    Console.WriteLine(n);
            //}

            var parallelResult2 = numbers.AsParallel().WithDegreeOfParallelism(100).Where(n => n % 2 == 0).ToList();

            foreach (var n in parallelResult2)
            {
                Console.WriteLine(n);
            }


            Console.WriteLine(result.Count);

            //var downloadBlock=new TransformBlock<string,string>(url=> { return Url; });

            Console.ReadLine();
        }

        public static void LoadData()
        {
            Console.WriteLine("Loading...");
        }

        public static void FetchConfig()
        {
            Console.WriteLine("Configuration added");
        }

        public static void InitalizeCache()
        {
            Console.WriteLine("Data catched");
        }
    }
}
