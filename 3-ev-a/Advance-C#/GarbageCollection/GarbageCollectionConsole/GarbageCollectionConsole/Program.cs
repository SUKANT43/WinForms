using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollectionConsole
{
    class Program:IDisposable
    {
        private static FileStream _stream;
        static void Main(string[] args)
        {
            _stream = new FileStream(@"C:\Users\sez-a4\Desktop\xUnitPackage.txt", FileMode.Open);
            Console.ReadLine();
        }

        public void Dispose()
        {
            _stream.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
