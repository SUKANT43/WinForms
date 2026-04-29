using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace BackGroundWorkerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (s, e) =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(1);
                    worker.ReportProgress(i);
                }
            };

            worker.ProgressChanged += (s, e) =>
            {
                Console.WriteLine(e.ProgressPercentage);
            };
            worker.RunWorkerAsync();
            worker.RunWorkerCompleted += (s, e) =>
            {
                Console.WriteLine("Work completed");
            };

            Console.WriteLine(workerThreads);
            // worker.WorkerSupportsCancellation = true;
            // worker.DoWork += (s, e) =>
            // {
            //     for(int i = 0; i <= 10; i++)
            //     {
            //         if (worker.CancellationPending)
            //         {
            //             e.Cancel = true;
            //             return;
            //         }
            //         Thread.Sleep(50);
            //         worker.ReportProgress(i);
            //     }
            // };
            // worker.ProgressChanged += (s, e) =>
            // {
            //     Console.WriteLine(e.ProgressPercentage);
            // };

            // worker.RunWorkerAsync();
            //worker.CancelAsync();
            Console.ReadLine();

        }
    }
}
