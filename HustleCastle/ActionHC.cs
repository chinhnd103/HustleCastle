using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Timers;
using System.Drawing;
using System.Threading;
using KAutoHelper;

namespace HustleCastle
{
    //public static class Action
    //{
    //    static DispatcherTimer dispatcherTimer = new DispatcherTimer();

    //}


    public class Example
    {



        private static System.Timers.Timer aTimer;
        //private static DispatcherTimer dtm;
        public static void Action(string id, Bitmap img)
        {
            //SetTimer(id, img);

            //Console.WriteLine("\nPress the Enter key to exit the application...\n");
            //Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            //Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer(string id, Bitmap img)
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(20);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            string rt = CheckImage(id, img);

            Console.WriteLine(rt);
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
        }


        private static string CheckImage(string id, Bitmap img)
        {
            //Task l = new Task(() =>
            //{
            //while (true)
            //{
            var screen = ADBHelper.ScreenShoot(id);
            var point = ImageScanOpenCV.FindOutPoint(screen, img);
            var aa = ImageScanOpenCV.Find(screen, img);
            aa.Save("aaa.png");
            if (point != null)
            {
                //Dispatcher.BeginInvoke(new ThreadStart(() => rtb1.AppendText("Home!!!")));
                //break;

                return "find!";
            }

            return "";
            //}
            //});
            //l.Start();

        }
    }



}
