using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ThreadsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //Thread thread = new Thread(() =>
            //  {
            //      Console.WriteLine("Hello from background thread");
            //      Thread.Sleep(1000);
            //      Console.WriteLine("Thread done");
            //  });

            //thread.IsBackground = true;
            //thread.Start();
            //thread.Join();
            //Console.WriteLine("Main completed");

            //
            //not works good
            //int counter = 0;
            //Parallel.For(0, 10, i => Console.WriteLine(counter++));


            //
            //thread-safe using lock
            //int safeCounter = 0;
            //object lockObj = new object();
            //Parallel.For(0, 100, i =>
            //{
            //    lock (lockObj) { Console.WriteLine(safeCounter++); }
            //});

            //
            //int atomicCounter = 0;
            //Parallel.For(0, 100, i =>
            //{
            //    int value = Interlocked.Increment(ref atomicCounter);
            //    Console.WriteLine(value);
            //});

            //
            //object lockObj = new object();
            //Monitor.TryEnter(lockObj);
            //try
            //{
            //    Console.WriteLine("hello");
            //}
            //finally
            //{
            //    Monitor.Exit(lockObj);
            //}

            //
            //object lockObj = new object();

            //bool lockTaken = false;
            //try
            //{
            //    Monitor.TryEnter(lockObj,1000,ref lockTaken);
            //    if (lockTaken)
            //    {
            //        Console.WriteLine("Lock acquired");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Timeout");
            //    }
            //}
            //finally
            //{
            //    if (lockTaken)
            //    {
            //        Monitor.Exit(lockObj);
            //    }
            //}


            //
            //Mutex mutex = new Mutex();
            //mutex.WaitOne();
            //try
            //{
            //    Console.WriteLine("Inside critical section");
            //}
            //finally
            //{
            //    mutex.ReleaseMutex();
            //}

            //
            //ThreadPool.QueueUserWorkItem(s =>
            //{
            //    Console.WriteLine("Running on a thread pool thread");
            //});


            //
            //Thread t1 = new Thread(IncrementUnSafe);
            //Console.WriteLine(counter);

            //Thread t2 = new Thread(IncrementUnSafe);
            //Console.WriteLine(counter);

            //Thread t3 = new Thread(IncrementUnSafe);

            //t1.Start();

            //t1.Join();
            //Console.WriteLine(counter);
            //t2.Start();
            //Console.WriteLine(counter);

            //t3.Start();
            //Console.WriteLine(counter);


            //
            //Thread t1 = new Thread(InCrementSafe);
            //Thread t2 = new Thread(InCrementSafe);
            //Thread t3 = new Thread(InCrementSafe);

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            //Console.WriteLine($"Final Counter: {counter}");

            object obj1 = new object();
            object obj2 = new object();

            Parallel.For(0, 100, i =>
            {
                if (i % 2 == 0)
                {
                    lock (obj1)
                    {
                        Thread.Sleep(10); // increase chance
                        lock (obj2)
                        {
                            Console.WriteLine($"Even {i}");
                        }
                    }
                }
                else
                {
                    lock (obj2)
                    {
                        Thread.Sleep(10); // increase chance
                        lock (obj1)
                        {
                            Console.WriteLine($"Odd {i}");
                        }
                    }
                }
            });

            Console.ReadLine();
        }
        static int counter = 0;
        //public static void IncrementUnSafe()
        //{
        //    for (int i = 0; i < 3000; i++)
        //    {
        //        counter++;
        //    }
        //}

        static object lockObj = new object();

        public static void InCrementSafe()
        {
            for (int i = 0; i < 10000; i++)
            {
                lock (lockObj)
                {
                    counter++; // Thread safe
                }
            }

        }
    }
}
