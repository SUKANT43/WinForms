using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task myTask = Task.Run(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine("Task running on the background thread");
            //        Thread.Sleep(50);
            //    }
            //});


            //Task myTask2 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Another way to start a task");
            //});

            //myTask.Wait();

            //Task<int> calculationTask = Task.Run(() =>
            //{
            //    return 42 * 2;
            //});

            //int res = calculationTask.Result;
            //Console.WriteLine(res);

            //Task.Run(() =>
            //{
            //    Console.WriteLine("Work started");
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Work finished");
            //})
            //.ContinueWith(t =>
            //{
            //    Console.WriteLine("Continuation task");
            //});

            //RunAsync();

            RunTask();


            Console.ReadLine();
        }

        public static async Task RunAsync()
        {
            Console.WriteLine("Fetching data...");
            string data = await FetchDataAsync();
            Console.WriteLine(data);
        }

        public static async Task<string> FetchDataAsync()
        {
            await Task.Delay(2000);
            return "Data recived";
        }

        public static async void RunTask()
        {
            Task t1 = Task.Run(() =>
            {
                Console.WriteLine("t1 executed");
                Thread.Sleep(200);

            });
            Task t2 = Task.Run(() =>
            {
                Console.WriteLine("t2 executed");
                Thread.Sleep(200);

            });


            await Task.WhenAll(t1, t2);
            Console.WriteLine("Both task executed");

            Task finished=await Task.WhenAny(t1, t2);
            Console.WriteLine("t1 finished");

        }


    }
}
