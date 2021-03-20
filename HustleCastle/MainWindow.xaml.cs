using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using KAutoHelper;

namespace HustleCastle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listDevice = ADBHelper.GetDevices();

        Bitmap D_HOME_MAP = (Bitmap)Bitmap.FromFile("image//dungeon_Tower.jpg");
        Bitmap D_FLAG = (Bitmap)Bitmap.FromFile("image//dungeon_flag.png");
        Bitmap D_CHECK_ETHER = (Bitmap)Bitmap.FromFile("image//dungeon_Ether.png");

        DispatcherTimer timer = new DispatcherTimer();
        string id_key = "";
        string id_mem = "";
        public MainWindow()
        {
            InitializeComponent();

            if (listDevice.Count == 0)
            {
                MessageBox.Show("No Device!!!!");
                this.Close();
            }

            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;

        }

        #region LoadImage

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task t = new Task(()=> {
            //});
            //Example.CheckImage(listDevice[0], D_HOME_MAP);

            //t.Start();

            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (GetPoint(id, D_FLAG) != null)
                {
                    Dispatcher.BeginInvoke(new ThreadStart(() => rtb1.AppendText("FIND!!!\r")));

                }
                // Tìm kiếm điểm đánh

                if (GetPoint(id, D_FLAG) != null)
                {
                    Dispatcher.BeginInvoke(new ThreadStart(() => rtb1.AppendText("FIND!!!\r")));

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private System.Drawing.Point? GetPoint(string id, Bitmap img)
        {
            var screen = ADBHelper.ScreenShoot(listDevice[0], false);

            var point = ImageScanOpenCV.FindOutPoint(screen, D_FLAG);
            //var aa = ImageScanOpenCV.Find(screen, D_FLAG);
            //if (aa != null)
            //{
            //    aa.Save("aaa.png");
            //} 
            return point;
        }
    }
}
