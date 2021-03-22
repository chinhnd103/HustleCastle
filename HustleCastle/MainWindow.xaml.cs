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
        private static Bitmap D_HOME_MAP = (Bitmap)Bitmap.FromFile("image//dungeon_Tower.jpg");
        private static Bitmap D_FLAG = (Bitmap)Bitmap.FromFile("image//dungeon_flag.png");
        private static Bitmap D_FLAG_BIG = (Bitmap)Bitmap.FromFile("image//dungeon_flag_big.png");
        private static Bitmap D_FLAG_BIG2 = (Bitmap)Bitmap.FromFile("image//dungeon_flag_big2.png");
        private static Bitmap D_FLAG_BOSS = (Bitmap)Bitmap.FromFile("image//dungeon_flag_boss.png");
        private static Bitmap D_FLAG_BOSS1 = (Bitmap)Bitmap.FromFile("image//dungeon_flag_boss1.png");
        private static Bitmap D_CHECK_ETHER = (Bitmap)Bitmap.FromFile("image//dungeon_Ether.png");
        private static Bitmap D_GO_HERE = (Bitmap)Bitmap.FromFile("image//dungeon_go_here.jpg");
        private static Bitmap D_ADD_FIGHTER = (Bitmap)Bitmap.FromFile("image//dungeon_add_fighter.png");
        private static Bitmap D_READY = (Bitmap)Bitmap.FromFile("image//dungeon_ready.png");
        private static Bitmap D_CANCEL = (Bitmap)Bitmap.FromFile("image//dungeon_cancel.jpg");
        private static Bitmap D_TO_BATTLE = (Bitmap)Bitmap.FromFile("image//dungeon_start_battle.png");
        private static Bitmap D_START_BATTLE_NON_LEADER = (Bitmap)Bitmap.FromFile("image//dungeon_start_battle_non_leader.png");
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
        private static string logs = "";
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

            int step = 1;

            while (true)
            {
                switch (step)
                {
                    case 0:
                        break;
                    case 1:

                        break;
                    case 2:
                        break;
                    default:
                        break;
                }

                // find flag normal
                logs += "GO->" + ID + "\r";

                Bitmap tmp_img = (Bitmap)D_HOME_MAP.Clone();
                var p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    tmp_img = (Bitmap)D_FLAG.Clone();
                    p = GetPoint(ID, tmp_img);
                    if (p != null)
                    {
                        logs += ID + ": find FLAG" + "\r";
                        ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                        p = null;

                        // click tab Your squad
                        ADBHelper.Tap(ID, 671, 39);
                        Thread.Sleep(500);
                    }
                    else
                    {
                        tmp_img = (Bitmap)D_FLAG_BIG.Clone();
                        p = GetPoint(ID, tmp_img);
                        if (p != null)
                        {
                            logs += ID + ": find FLAG" + "\r";
                            ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                            p = null;

                            // click tab Your squad
                            ADBHelper.Tap(ID, 671, 39);
                            Thread.Sleep(500);
                        }
                        else
                        {
                            tmp_img = (Bitmap)D_FLAG_BIG2.Clone();
                            p = GetPoint(ID, tmp_img);
                            if (p != null)
                            {
                                logs += ID + ": find FLAG" + "\r";
                                ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                                p = null;

                                // click tab Your squad
                                ADBHelper.Tap(ID, 671, 39);
                                Thread.Sleep(500);
                            }

                        }
                    }
                }

                // find flag boss
                tmp_img = (Bitmap)D_FLAG_BOSS.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;

                    // click tab Your squad
                    ADBHelper.Tap(ID, 671, 39);
                    Thread.Sleep(500);
                }

                tmp_img = (Bitmap)D_GO_HERE.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                    Thread.Sleep(500);
                }

                tmp_img = (Bitmap)D_ADD_FIGHTER.Clone();
                var tmp_img1 = (Bitmap)D_READY.Clone();
                var tmp_img2 = (Bitmap)D_CANCEL.Clone();
                p = GetPoint(ID, tmp_img);
                var p1 = GetPoint(ID, tmp_img1);
                var p2 = GetPoint(ID, tmp_img2);
                if (p != null && p2 == null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    while (true)
                    {
                        ADBHelper.Swipe(ID, 236, 354, 813, 164, 2000);
                        ADBHelper.Swipe(ID, 252, 354, 813, 164, 2000);
                        ADBHelper.Swipe(ID, 298, 354, 813, 164, 2000);
                        ADBHelper.Swipe(ID, 340, 354, 813, 164, 5000);
                        ADBHelper.Swipe(ID, 393, 354, 813, 164, 5000);
                        ADBHelper.Swipe(ID, 435, 354, 813, 164, 5000);
                        p = GetPoint(ID, tmp_img);
                        Thread.Sleep(200);
                        if (p == null)
                        {
                            p = null;
                            break;
                        }
                    }
                }

                tmp_img = (Bitmap)D_ADD_FIGHTER.Clone();
                p = GetPoint(ID, tmp_img);
                if (p == null && p1 != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p1.Value.X, p1.Value.Y);
                    p1 = null;
                    Thread.Sleep(500);
                }

                tmp_img = (Bitmap)D_TO_BATTLE.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null && p2 != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                }

                tmp_img = (Bitmap)D_START_BATTLE_NON_LEADER.Clone();
                p = GetPoint(ID, tmp_img);
                var tmp_img_x = (Bitmap)D_X.Clone();
                var p_x = GetPoint(ID, tmp_img_x);
                if (p != null && p2 != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p_x.Value.X, p_x.Value.Y);
                    p = null;
                }

                tmp_img = (Bitmap)D_HOME.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                }

                tmp_img = (Bitmap)D_END_JOURNEY.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                    Thread.Sleep(1000);
                    ADBHelper.Tap(ID, 391, 345);
                }

                tmp_img = (Bitmap)D_SUMMARY.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y, 10);
                    p = null;
                    Thread.Sleep(2000);
                }

                tmp_img = (Bitmap)D_INVITE.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                }

                tmp_img = (Bitmap)D_START_JOURNEY.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                }

                tmp_img = (Bitmap)D_ACCEPT_TORCHES.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                    Thread.Sleep(500);
                }

                tmp_img = (Bitmap)D_CONFIRM_FIGHTER.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                    Thread.Sleep(500);
                }

                tmp_img = (Bitmap)D_GOTO_THE_MAP.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                    Thread.Sleep(500);
                }

                tmp_img = (Bitmap)D_REWARD_CLOSE.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                    Thread.Sleep(500);
                }

                tmp_img = (Bitmap)D_FLAG_COMBAT.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                    Thread.Sleep(500);
                }

                tmp_img = (Bitmap)D_FLAG_BOSS1.Clone();
                p = GetPoint(ID, tmp_img);
                if (p != null)
                {
                    logs += ID + ": find FLAG" + "\r";
                    ADBHelper.Tap(ID, p.Value.X, p.Value.Y);
                    p = null;
                    Thread.Sleep(500);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
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
