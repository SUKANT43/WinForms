using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutexExample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            bool isNewInstance;
            mutex = new Mutex(true, "MyUniqueAppName123", out isNewInstance);

            if (!isNewInstance)
            {
                MessageBox.Show("Application is already running!");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
