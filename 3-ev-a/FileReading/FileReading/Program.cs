//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FileReading
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Stopwatch st = new Stopwatch();
//            st.Start();

//            string[] file = new string[]
//            {
//                "txt0.txt",
//                "txt1.txt",
//                "txt2.txt",
//                "txt3.txt",
//                "txt4.txt",
//                "txt5.txt",
//                "txt6.txt",
//                "txt7.txt",
//                "txt8.txt",
//                "txt9.txt"
//            };

//            int count = 0;
//            string targetWord = "last";
//            string folderPath = @"C:\Users\SEZ-A4\Desktop\fileReading\";
//            for (int i = 0; i < file.Count(); i++)
//            {
//                string content = File.ReadAllText(folderPath + file[i]);
//                content = content.Trim();
//                string[] words = content.Split(' ');
//                Console.WriteLine(i);
//                for (int j = 0; j < words.Count(); j++)
//                {
//                    if (words[j].Equals(targetWord))
//                        count++;
//                }
//            }

//            st.Stop();
//            Console.WriteLine(count);
//            Console.WriteLine(st.Elapsed.ToString());


//            Console.ReadLine();
//        }
//    }
//}


using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileReading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch st = new Stopwatch();
            //st.Start();

            //string[] files = new string[]
            //{
            //    "txt0.txt","txt1.txt","txt2.txt","txt3.txt","txt4.txt",
            //    "txt5.txt","txt6.txt","txt7.txt","txt8.txt",""
            //};

            //string folderPath = @"C:\Users\SEZ-A4\Desktop\fileReading\";
            //string targetWord = "last";

            //int totalCount = 0;
            //object lockObj = new object();
            //try
            //{
            //    Parallel.For(0, files.Length, i =>
            //    {
            //        string content = File.ReadAllText(folderPath + files[i]);

            //        string[] words = content.Split(
            //            new char[] { ' ', '\t', '\n', '\r' },
            //            StringSplitOptions.RemoveEmptyEntries
            //        );

            //        int localCount = words.AsParallel().Count(w => w.Equals(targetWord));

            //        // Thread-safe update
            //        lock (lockObj)
            //        {
            //            totalCount += localCount;
            //        }

            //        Console.WriteLine($"File {i} processed");
            //    });
            //}
            //catch(Exception e) { }
            //finally
            //{
            //    Console.WriteLine("process finished");
            //}

            //st.Stop();

            //Console.WriteLine($"Total Count: {totalCount}");
            //Console.WriteLine($"Time: {st.Elapsed}");

            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(Guid.NewGuid());
            }

            Console.ReadLine();
        }
    }
}

//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Threading;

//namespace FileReading
//{
//    class Program
//    {
//        static int totalCount = 0;
//        static object lockObj = new object();

//        static void Main(string[] args)
//        {
//            Stopwatch st = new Stopwatch();
//            st.Start();

//            string[] files = new string[]
//            {
//                "txt0.txt","txt1.txt","txt2.txt","txt3.txt","txt4.txt",
//                "txt5.txt","txt6.txt","txt7.txt","txt8.txt","txt9.txt"
//            };

//            string folderPath = @"C:\Users\SEZ-A4\Desktop\fileReading\";
//            string targetWord = "last";

//            Thread[] threads = new Thread[files.Length];

//            for (int i = 0; i < files.Length; i++)
//            {
//                int index = i; // IMPORTANT (avoid closure issue)

//                threads[i] = new Thread(() =>
//                {
//                    string content = File.ReadAllText(folderPath + files[index]);

//                    string[] words = content.Split(
//                        new char[] { ' ', '\t', '\n', '\r' },
//                        StringSplitOptions.RemoveEmptyEntries
//                    );

//                    int localCount = words.Count(w => w.Equals(targetWord));

//                    // Thread-safe update
//                    lock (lockObj)
//                    {
//                        totalCount += localCount;
//                    }

//                    Console.WriteLine($"Thread {index} done");
//                });

//                threads[i].Start();
//            }

//            // Wait for all threads to finish
//            foreach (Thread t in threads)
//            {
//                t.Join();
//            }

//            st.Stop();

//            Console.WriteLine($"Total Count: {totalCount}");
//            Console.WriteLine($"Time: {st.Elapsed}");

//            Console.ReadLine();
//        }
//    }
//}

