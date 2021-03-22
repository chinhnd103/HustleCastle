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

        #region LoadImage
        //private static Bitmap D_ = (Bitmap)Bitmap.FromFile("image//");
        private static Bitmap GOTO_HOME = (Bitmap)Bitmap.FromFile("image//GOTO_HOME.png");
        private static Bitmap GOTO_MAP = (Bitmap)Bitmap.FromFile("image//GOTO_MAP.png");
        private static Bitmap GOTO_DUNGEON = (Bitmap)Bitmap.FromFile("image//MAP_DUNGEON.png");
        private static Bitmap D_HOME_MAP = (Bitmap)Bitmap.FromFile("image//dungeon_Tower.jpg");
        private static Bitmap D_FLAG = (Bitmap)Bitmap.FromFile("image//dungeon_flag.png");
        private static Bitmap D_FLAG_BIG = (Bitmap)Bitmap.FromFile("image//dungeon_flag_big.png");
        private static Bitmap D_FLAG_BIG2 = (Bitmap)Bitmap.FromFile("image//dungeon_flag_big2.png");
        private static Bitmap D_FLAG_BIG3 = (Bitmap)Bitmap.FromFile("image//dungeon_flag_big3.png");
        private static Bitmap D_FLAG_BOSS = (Bitmap)Bitmap.FromFile("image//dungeon_flag_boss.png");
        private static Bitmap D_FLAG_BOSS1 = (Bitmap)Bitmap.FromFile("image//dungeon_flag_boss1.png");
        private static Bitmap D_CHECK_ETHER = (Bitmap)Bitmap.FromFile("image//dungeon_Ether.png");
        private static Bitmap D_GO_HERE = (Bitmap)Bitmap.FromFile("image//dungeon_go_here.jpg");
        private static Bitmap D_ADD_FIGHTER = (Bitmap)Bitmap.FromFile("image//dungeon_add_fighter.png");
        private static Bitmap D_READY = (Bitmap)Bitmap.FromFile("image//dungeon_ready.png");
        private static Bitmap D_CANCEL = (Bitmap)Bitmap.FromFile("image//dungeon_cancel.jpg");
        private static Bitmap D_TO_BATTLE = (Bitmap)Bitmap.FromFile("image//dungeon_start_battle.png");
        private static Bitmap D_STARTED_BATTLE = (Bitmap)Bitmap.FromFile("image//dungeon_started_battle.png");
        private static Bitmap D_X = (Bitmap)Bitmap.FromFile("image//dungeon_x.png");
        private static Bitmap D_HOME = (Bitmap)Bitmap.FromFile("image//dungeon_home_finish_battle.jpg");
        private static Bitmap D_END_JOURNEY = (Bitmap)Bitmap.FromFile("image//dungeon_end_journey.jpg");
        private static Bitmap D_END_JOURNEY_QUESTION = (Bitmap)Bitmap.FromFile("image//dungeon_end_question.png");
        private static Bitmap D_SUMMARY = (Bitmap)Bitmap.FromFile("image//dungeon_summary.png");
        private static Bitmap D_INVITE = (Bitmap)Bitmap.FromFile("image//dungeon_invite_next.jpg");
        private static Bitmap D_START_JOURNEY = (Bitmap)Bitmap.FromFile("image//dungeon_start_journey.png");
        private static Bitmap D_ACCEPT_TORCHES = (Bitmap)Bitmap.FromFile("image//dungeon_accept_torches.png");
        private static Bitmap D_CONFIRM_FIGHTER = (Bitmap)Bitmap.FromFile("image//dungeon_confirm_fighter.png");
        private static Bitmap D_GOTO_THE_MAP = (Bitmap)Bitmap.FromFile("image//dungeon_goto_map.jpg");
        private static Bitmap D_FLAG_COMBAT = (Bitmap)Bitmap.FromFile("image//dungeon_flag_combat.jpg");
        private static Bitmap D_REWARD_CLOSE = (Bitmap)Bitmap.FromFile("image//dungeon_reward_close.png");

        #endregion

        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        string ID1 = "";
        string ID2 = "";
        static string IDKey = "";
        private static string logs = "";

        static int step = 2;
        public MainWindow()
        {
            InitializeComponent();

            if (listDevice.Count == 0)
            {
                txtLog.Text += "No Device!!!!";
                //MessageBox.Show("No Device!!!!");
                this.Close();
            }
            if (listDevice.Count == 1)
            {
                ID1 = listDevice[0];
                txtLog.Text += "Devices 1: " + listDevice[0] + "\r";
            }
            else
            {
                ID1 = listDevice[0];
                ID2 = listDevice[1];
                txtLog.Text += "Devices 1: " + listDevice[0] + "\r";
                txtLog.Text += "Devices 2: " + listDevice[1] + "\r";
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task t = new Task(()=> {
            //});
            //t.Start();

            if (ID1 != "")
            {
                //timer1.Interval = TimeSpan.FromMilliseconds(1);
                //timer1.Tick += timer1_Tick;
                //timer1.Start();

                Thread myNewThread1 = new Thread(() => RunDungeon(ID1));
                myNewThread1.Start();
            }

            if (ID2 != "")
            {
                //timer2.Interval = TimeSpan.FromMilliseconds(1);
                //timer2.Tick += timer2_Tick;
                //timer2.Start();

                Thread myNewThread2 = new Thread(() => RunDungeon(ID2));
                myNewThread2.Start();
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
        }
        void timer2_Tick(object sender, EventArgs e)
        {
        }

        static void RunDungeon(string ID)
        {
            if (ID == "")
            {
                return;
            }

            while (true)
            {
                if (step == -1)
                {
                    var img = (Bitmap)GOTO_MAP.Clone();
                    var _p = GetPoint(ID, img);
                    if (_p != null)
                    {
                        ADBHelper.Tap(ID, _p.Value.X, _p.Value.Y);
                        _p = null;
                        Thread.Sleep(500);
                    }
                    else
                    {
                        img = (Bitmap)GOTO_HOME.Clone();
                        _p = GetPoint(ID, img);
                        if (_p != null)
                        {
                            img = (Bitmap)GOTO_DUNGEON.Clone();
                            _p = GetPoint(ID, img);
                            if (_p != null)
                            {
                                step = 0;
                                ADBHelper.Tap(ID, _p.Value.X, _p.Value.Y);
                                _p = null;
                                Thread.Sleep(500);
                            }
                        }
                    }
                }

                System.Drawing.Point? p;

                switch (step)
                {
                    case 0:
                        break;
                    case 1: // Start Dungeon
                        #region Start Dungeon
                        p = GetPoint(ID, (Bitmap)D_GOTO_THE_MAP.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            step = 2;
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;
                        }
                        break;
                    #endregion
                    case 2: // Choose FLAG
                        #region Chọn ải
                        // Check xem co phan thuong tu ai truoc hay khong?
                        p = GetPoint(ID, (Bitmap)D_REWARD_CLOSE.Clone());
                        if (p != null)
                        {
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;
                        }

                        //Flag Normal
                        p = GetPoint(ID, (Bitmap)D_HOME_MAP.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            p = GetPoint(ID, (Bitmap)D_FLAG.Clone());
                            if (p != null)
                            {
                                step = 3;
                                ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                                p = null;

                                // click tab Your squad
                                ADBHelper.Tap(ID, 671, 39);
                                break;
                            }
                            else
                            {
                                p = GetPoint(ID, (Bitmap)D_FLAG_BIG.Clone());
                                if (p != null)
                                {
                                    step = 3;
                                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                                    p = null;

                                    // click tab Your squad
                                    ADBHelper.Tap(ID, 671, 39);
                                    break;
                                }
                                else
                                {
                                    p = GetPoint(ID, (Bitmap)D_FLAG_BIG2.Clone());
                                    if (p != null)
                                    {
                                        step = 3;
                                        ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                                        p = null;

                                        // click tab Your squad
                                        ADBHelper.Tap(ID, 671, 39);
                                        break;
                                    }
                                    else
                                    {
                                        p = GetPoint(ID, (Bitmap)D_FLAG_BIG3.Clone());
                                        if (p != null)
                                        {
                                            step = 3;
                                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                                            p = null;

                                            // click tab Your squad
                                            ADBHelper.Tap(ID, 671, 39);
                                            break;
                                        }

                                    }

                                }
                            }

                            // Flag Boss
                            p = GetPoint(ID, (Bitmap)D_FLAG_BOSS.Clone());
                            if (p != null)
                            {
                                step = 3;
                                ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                                p = null;

                                // click tab Your squad
                                ADBHelper.Tap(ID, 671, 39);
                                break;
                            }
                            else
                            {
                                p = GetPoint(ID, (Bitmap)D_FLAG_BOSS1.Clone());
                                if (p != null)
                                {
                                    step = 3;
                                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                                    p = null;

                                    // click tab Your squad
                                    ADBHelper.Tap(ID, 671, 39);
                                    break;
                                }
                            }
                            //tmp_img = (Bitmap)D_FLAG_COMBAT.Clone();
                            //p = GetPoint(ID, tmp_img);
                            //if (p != null)
                            //{

                            //    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            //    p = null;
                            //    Thread.Sleep(500);
                            //}
                        }
                        #endregion
                        break;
                    case 3: // Click "GO HERE" -> Set Leader
                        #region Click "GO HERE" -> Set Leader
                        if (IDKey != "")
                        {
                            step = 4;
                            break;
                        }

                        p = GetPoint(ID, (Bitmap)D_GO_HERE.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            Console.WriteLine("[" + ID + "] STEP " + step + "---->KEY");
                            IDKey = ID;
                            ADBHelper.Tap(ID, 766, 456);
                            p = null;
                            Thread.Sleep(500);
                        }
                        else
                        {
                            IDKey = "";
                        }
                        step = 4;
                        #endregion
                        break;
                    case 4: // Deploy fighter
                        #region Deploy fighter
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        p = GetPoint(ID, (Bitmap)D_ADD_FIGHTER.Clone());
                        var p2 = GetPoint(ID, (Bitmap)D_CANCEL.Clone());

                        if (p != null && p2 == null)
                        {
                            while (true)
                            {
                                ADBHelper.Swipe(ID, 236, 354, 813, 164, 2000);
                                ADBHelper.Swipe(ID, 252, 354, 813, 164, 2000);
                                ADBHelper.Swipe(ID, 298, 354, 813, 164, 2000);
                                ADBHelper.Swipe(ID, 340, 354, 813, 164, 5000);
                                ADBHelper.Swipe(ID, 393, 354, 813, 164, 5000);
                                ADBHelper.Swipe(ID, 435, 354, 813, 164, 5000);

                                p = GetPoint(ID, (Bitmap)D_ADD_FIGHTER.Clone());
                                Thread.Sleep(200);
                                if (p == null)
                                {
                                    p = null;
                                    break;
                                }
                            }
                        }

                        p = GetPoint(ID, (Bitmap)D_ADD_FIGHTER.Clone());
                        var p1 = GetPoint(ID, (Bitmap)D_READY.Clone());
                        if (p == null && p1 != null)
                        {

                            ADBHelper.Tap(ID, p1.Value.X, p1.Value.Y);
                            p1 = null;
                            Thread.Sleep(1000);
                        }

                        // Sau khi deploy xong
                        // Key -> start battal
                        // NoKey -> quay ra map
                        p = GetPoint(ID, (Bitmap)D_TO_BATTLE.Clone());
                        if (p != null && p2 != null)
                        {
                            step = 5;
                            ADBHelper.Tap(ID, 766, 456);
                            p = null;
                        }
                        else
                        {
                            p = GetPoint(ID, (Bitmap)D_X.Clone());
                            if (p != null)
                            {
                                step = 2;
                                ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                                p = null;
                            }
                        }
                        #endregion
                        break;
                    case 5: // Sau khi xong combat thi quay lai map dungeon
                        #region Sau khi xong combat thi quay lai map dungeon
                        p = GetPoint(ID, (Bitmap)D_HOME.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            step = 2;
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;
                        }
                        #endregion
                        break;
                    case 6: // Khi het Flag thi end dungeon
                        #region Khi het Flag thi end dungeon
                        p = GetPoint(ID, (Bitmap)D_END_JOURNEY.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            step = 7;
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;
                            Thread.Sleep(1000);
                            ADBHelper.Tap(ID, 391, 345); // Click popup question
                        }
                        #endregion
                        break;
                    case 7: // Tổng kết
                        #region Tổng kết phần thưởng dungeon
                        p = GetPoint(ID, (Bitmap)D_SUMMARY.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            step = 8;
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y, 10);
                            p = null;
                            Thread.Sleep(1000);
                        }
                        #endregion
                        break;
                    case 8: // Re-invite friend
                        #region Re-invite friend
                        p = GetPoint(ID, (Bitmap)D_INVITE.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            step = 9;
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;
                            Thread.Sleep(1000);
                        }
                        #endregion
                        break;
                    case 9: // Hai ben cung chon thi bat dau dungeon moi
                        #region Hai ben cung chon thi bat dau dungeon moi
                        p = GetPoint(ID, (Bitmap)D_START_JOURNEY.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            step = 10;
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;
                        }
                        #endregion
                        break;
                    case 10: // Chon ve' vao dungeon
                        #region Chon ve' vao dungeon
                        p = GetPoint(ID, (Bitmap)D_ACCEPT_TORCHES.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            step = 11;
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;
                            Thread.Sleep(500);
                        }
                        #endregion
                        break;
                    case 11: // xac nhan doi hinh vao dungeon
                        #region xac nhan doi hinh vao dungeon
                        p = GetPoint(ID, (Bitmap)D_CONFIRM_FIGHTER.Clone());
                        Console.WriteLine("[" + ID + "] STEP " + step);
                        if (p != null)
                        {
                            step = 2;
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;
                            Thread.Sleep(17000);
                        }
                        #endregion
                        break;
                    default:
                        break;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            step = 2;
            IDKey = "";
        }

        private static System.Drawing.Point? GetPoint(string id, Bitmap img)
        {
            var screen = ADBHelper.ScreenShoot(id, false);
            Bitmap tmp_img = (Bitmap)img.Clone();
            Bitmap tmp_scr = (Bitmap)screen.Clone();
            var point = ImageScanOpenCV.FindOutPoint(tmp_scr, tmp_img);
            return point;
            //var aa = ImageScanOpenCV.Find(screen, D_FLAG);
            //if (aa != null)
            //{
            //    aa.Save("aaa.png");
            //} 
        }
    }
}
