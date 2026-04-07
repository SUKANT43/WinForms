using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Diagnostics;

namespace Timers
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        System.Threading.Timer timer2;
        Stopwatch stopwatch;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
            timer.Start();

            timer2 = new System.Threading.Timer(CallbackTask, null, 10000, 2000);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            string time = stopwatch.Elapsed.ToString();
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Restart();
            MessageBox.Show(time);

        }

        private void CallbackTask(object state)
        {
            MessageBox.Show("");
            Thread.Sleep(2000);
        }  

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    label1.Text = DateTime.Now.ToString("HH:mm:ss");
                });
            }
        }

        private void TimeGetter()
        {
            
        }

    }
}


//UI animation / clock / control updates → System.Windows.Forms.Timer

//Use this when the task is directly related to the WinForms UI and needs to update controls on the screen.

//Typical tasks:

//Digital clock on a form that updates every second
//Loading spinner / rotating icon
//Progress bar animation
//Move a panel or button smoothly across the form
//Blinking label / notification badge
//Slideshow of images in a PictureBox
//Countdown timer displayed in a label
//Auto-hide popup / toast message after 3 seconds
//Game loop for a simple WinForms game UI

//Example idea:
//A login screen shows “Connecting…” with dots changing every 500 ms:

//Connecting.
//Connecting..
//Connecting...

//This is perfect for Forms.Timer because it updates UI elements.

//background repeated tasks → System.Timers.Timer

//Use this for tasks that repeat in the background and are not mainly visual.

//Typical tasks:

//Auto-save file every 30 seconds
//Check database for new records
//Poll an API every minute
//Write logs periodically
//Session timeout checker
//Refresh cached data in memory
//Monitor system resource usage
//Retry failed background operations

//Example idea:
//Your inventory application checks the server every 10 seconds for stock changes and then updates the UI only when needed.

//This fits Timers.Timer.

//high-performance repeated callbacks → System.Threading.Timer

//Use this for lightweight, frequent, performance-sensitive background tasks.

//Typical tasks:

//Memory cleanup / cache eviction
//Heartbeat ping to a server
//Very frequent sensor/device polling
//Fast repeated calculations
//Network keep-alive messages
//Background task scheduler
//High-frequency status monitoring
//Token/session refresh checker

//Example idea:
//A desktop monitoring app checks CPU usage every 100 ms and stores the values in memory for analytics.

//This is ideal for Threading.Timer because it is lightweight and efficient.

//Quick practical rule for you as a WinForms developer:

//Think like this:

//screen changes → Forms.Timer
//business logic repeating → Timers.Timer
//fast backend repeated work → Threading.Timer

//For example in your custom control library:

//smooth slider animation → Forms.Timer
//auto-save control settings → Timers.Timer
//performance metrics sampler → Threading.Timer

//That mental model will help you choose quickly.