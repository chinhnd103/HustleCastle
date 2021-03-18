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
        private static readonly DispatcherTimer dt = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            if (listDevice.Count == 0)
            {
                MessageBox.Show("No Device!!!!");
            }

            Example.Action();

        }

        #region LoadImage

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task t = new Task(()=> {
            //});
            CheckImage(listDevice[0], D_HOME_MAP);

            //t.Start();
        }

        void CheckImage(string id, Bitmap img)
        {
            Task l = new Task(() =>
            {
                while (true)
                {
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(id);
                    var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, img);
                    if (point != null)
                    {
                        Dispatcher.BeginInvoke(new ThreadStart(() => rtb1.AppendText("Home!!!")));
                        break;
                    }
                }
            });
            l.Start();

        }


    }
}
