using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UI
{
    /// <summary>
    /// MainUnit.xaml 的交互逻辑
    /// </summary>
    public partial class MainUnit : Window
    {
        private DispatcherTimer ShowTimer;  //声明一个计时器

        public MainUnit()
        {
            InitializeComponent();
            FullScreenManager.RepairWpfWindowFullScreenBehavior(this); //最大化时，窗口不遮挡任务栏
            Loaded += delegate
            {
                //显示当前用户名
                lblUserName.Content = this.Tag + ""; 
                //设置计时器
                ShowTimer = new DispatcherTimer();
                ShowTimer.Tick += new EventHandler(ShowCurrentTimer);
                ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
                ShowTimer.Start();
            };
        }

        //实时显示日期时间
        private void ShowCurrentTimer(object sender, EventArgs e)
        {
            string date = DateTime.Now.DayOfWeek.ToString();  //当前日期
            if (date == "Monday")        { lblDate.Content = DateTime.Now.ToLongDateString().ToString() + " 星期一"; }
            else if (date == "Tuesday")  { lblDate.Content = DateTime.Now.ToLongDateString().ToString() + " 星期二"; }
            else if (date == "Wednesday"){ lblDate.Content = DateTime.Now.ToLongDateString().ToString() + " 星期三"; }
            else if (date == "Thursday") { lblDate.Content = DateTime.Now.ToLongDateString().ToString() + " 星期四"; }
            else if (date == "Friday")   { lblDate.Content = DateTime.Now.ToLongDateString().ToString() + " 星期五"; }
            else if (date == "Saturday") { lblDate.Content = DateTime.Now.ToLongDateString().ToString() + " 星期六"; }
            else if (date == "Sunday")   { lblDate.Content = DateTime.Now.ToLongDateString().ToString() + " 星期日"; }
            lblTime.Content = DateTime.Now.ToString("HH:mm:ss");  //当前时间
        }

        //"退出系统"按钮事件
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //窗口移动事件
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
         
        //左箭头按钮点击事件
        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            var top = choicePanel.Margin.Top;
            var bot = choicePanel.Margin.Bottom;
            var left = choicePanel.Margin.Left;
            var right = choicePanel.Margin.Right;
            choicePanel.Margin = new Thickness(left, top, right+5, bot);
            gridLeft.Margin = new Thickness(gridLeft.Margin.Left, gridLeft.Margin.Top,
                                            gridLeft.Margin.Right-5, gridLeft.Margin.Bottom);
        }
        //右箭头按钮点击事件
        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            var top = choicePanel.Margin.Top;
            var bot = choicePanel.Margin.Bottom;
            var left = choicePanel.Margin.Left;
            var right = choicePanel.Margin.Right;
            choicePanel.Margin = new Thickness(left + 5, top, right, bot);
            gridRight.Margin = new Thickness(gridRight.Margin.Left - 5, gridRight.Margin.Top,
                                             gridRight.Margin.Right, gridRight.Margin.Bottom);
        }
        //功能选项区按钮点击事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            
            string func = btn.Content.ToString();
            switch (func)
            {
                case "系统管理":
                    #region 按钮变色
                    btn.Foreground = Brushes.LightSkyBlue;
                    btnClinicDoc.Foreground = Brushes.MidnightBlue;
                    btnClinicMan.Foreground = Brushes.MidnightBlue;
                    btnClinicBill.Foreground = Brushes.MidnightBlue;
                    btnSickroom.Foreground = Brushes.MidnightBlue;
                    btnDrugstore.Foreground = Brushes.MidnightBlue;
                    btnMedicine.Foreground = Brushes.MidnightBlue;
                    btnFinance.Foreground = Brushes.MidnightBlue;
                    //BitmapImage imagetemp1 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    //BitmapImage imagetemp2 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    //BitmapImage imagetemp3 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    //BitmapImage imagetemp4 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    //BitmapImage imagetemp5 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    //BitmapImage imagetemp6 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    //BitmapImage imagetemp7 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    //BitmapImage imagetemp8 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    //img1.ImageSource = imagetemp1;
                    //img2.ImageSource = imagetemp2;
                    //img3.ImageSource = imagetemp3;
                    //img4.ImageSource = imagetemp4;
                    //img5.ImageSource = imagetemp5;
                    //img6.ImageSource = imagetemp6;
                    //img7.ImageSource = imagetemp7;
                    //img8.ImageSource = imagetemp8;
                    #endregion
                    showFrame.Source = new Uri("SystemManagement.xaml", UriKind.Relative);
                    break;

                case "门诊医生":
                    #region 按钮变色
                    btn.Foreground = Brushes.LightSkyBlue;
                    btnSys.Foreground = Brushes.MidnightBlue;
                    btnClinicMan.Foreground = Brushes.MidnightBlue;
                    btnClinicBill.Foreground = Brushes.MidnightBlue;
                    btnSickroom.Foreground = Brushes.MidnightBlue;
                    btnDrugstore.Foreground = Brushes.MidnightBlue;
                    btnMedicine.Foreground = Brushes.MidnightBlue;
                    btnFinance.Foreground = Brushes.MidnightBlue;
                    //BitmapImage imagetemp11 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp21 = new BitmapImage(new Uri("\\Images\\Btn+.png", UriKind.Relative));
                    //BitmapImage imagetemp31 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp41 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp51 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp61 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp71 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp81 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //img1.ImageSource = imagetemp11;
                    //img2.ImageSource = imagetemp21;
                    //img3.ImageSource = imagetemp31;
                    //img4.ImageSource = imagetemp41;
                    //img5.ImageSource = imagetemp51;
                    //img6.ImageSource = imagetemp61;
                    //img7.ImageSource = imagetemp71;
                    //img8.ImageSource = imagetemp81;
                    #endregion
                    var cd = new ClinicDoctor1(lblUserName.Content.ToString());
                    showFrame.Content = cd.Content;
                    break;

                case "门诊管理":
                    #region 按钮变色
                    btn.Foreground = Brushes.LightSkyBlue;
                    btnSys.Foreground = Brushes.MidnightBlue;
                    btnClinicDoc.Foreground = Brushes.MidnightBlue;
                    btnClinicBill.Foreground = Brushes.MidnightBlue;
                    btnSickroom.Foreground = Brushes.MidnightBlue;
                    btnDrugstore.Foreground = Brushes.MidnightBlue;
                    btnMedicine.Foreground = Brushes.MidnightBlue;
                    btnFinance.Foreground = Brushes.MidnightBlue;
                    //BitmapImage imagetemp12 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp22 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp32 = new BitmapImage(new Uri("\\Images\\Btn+.png", UriKind.Relative));
                    //BitmapImage imagetemp42 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp52 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp62 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp72 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp82 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //img1.ImageSource = imagetemp12;
                    //img2.ImageSource = imagetemp22;
                    //img3.ImageSource = imagetemp32;
                    //img4.ImageSource = imagetemp42;
                    //img5.ImageSource = imagetemp52;
                    //img6.ImageSource = imagetemp62;
                    //img7.ImageSource = imagetemp72;
                    //img8.ImageSource = imagetemp82;
                    #endregion
                    showFrame.Source = new Uri("ClinicManage.xaml", UriKind.Relative);
                    break;

                case "门诊收费":
                    #region 按钮变色
                    btn.Foreground = Brushes.LightSkyBlue;
                    btnSys.Foreground = Brushes.MidnightBlue;
                    btnClinicDoc.Foreground = Brushes.MidnightBlue;
                    btnClinicMan.Foreground = Brushes.MidnightBlue;
                    btnSickroom.Foreground = Brushes.MidnightBlue;
                    btnDrugstore.Foreground = Brushes.MidnightBlue;
                    btnMedicine.Foreground = Brushes.MidnightBlue;
                    btnFinance.Foreground = Brushes.MidnightBlue;
                    //BitmapImage imagetemp13 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp23 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp33 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp43 = new BitmapImage(new Uri("\\Images\\Btn+.png", UriKind.Relative));
                    //BitmapImage imagetemp53 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp63 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp73 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp83 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //img1.ImageSource = imagetemp13;
                    //img2.ImageSource = imagetemp23;
                    //img3.ImageSource = imagetemp33;
                    //img4.ImageSource = imagetemp43;
                    //img5.ImageSource = imagetemp53;
                    //img6.ImageSource = imagetemp63;
                    //img7.ImageSource = imagetemp73;
                    //img8.ImageSource = imagetemp83;
                    #endregion
                    var cc = new ClinicCharge(lblUserName.Content.ToString());
                    showFrame.Content = cc.Content;
                    break;

                case "住院管理":
                    #region 按钮变色
                    btn.Foreground = Brushes.LightSkyBlue;
                    btnClinicBill.Foreground = Brushes.MidnightBlue;
                    btnSys.Foreground = Brushes.MidnightBlue;
                    btnClinicDoc.Foreground = Brushes.MidnightBlue;
                    btnClinicMan.Foreground = Brushes.MidnightBlue;
                    btnDrugstore.Foreground = Brushes.MidnightBlue;
                    btnMedicine.Foreground = Brushes.MidnightBlue;
                    btnFinance.Foreground = Brushes.MidnightBlue;
                    //BitmapImage imagetemp14 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp24 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp34 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp44 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp54 = new BitmapImage(new Uri("\\Images\\Btn+.png", UriKind.Relative));
                    //BitmapImage imagetemp64 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp74 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp84 = new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //img1.ImageSource = imagetemp14;
                    //img2.ImageSource = imagetemp24;
                    //img3.ImageSource = imagetemp34;
                    //img4.ImageSource = imagetemp44;
                    //img5.ImageSource = imagetemp54;
                    //img6.ImageSource = imagetemp64;
                    //img7.ImageSource = imagetemp74;
                    //img8.ImageSource = imagetemp84;
                    #endregion
                    showFrame.Source = new Uri("HospitalManage.xaml", UriKind.Relative);
                    break;

                case "药房管理":
                    #region 按钮变色
                    btn.Foreground = Brushes.LightSkyBlue;
                    btnMedicine.Foreground = Brushes.MidnightBlue;
                    btnFinance.Foreground = Brushes.MidnightBlue;
                    btnClinicBill.Foreground = Brushes.MidnightBlue;
                    btnSys.Foreground = Brushes.MidnightBlue;
                    btnClinicDoc.Foreground = Brushes.MidnightBlue;
                    btnClinicMan.Foreground = Brushes.MidnightBlue;
                    btnSickroom.Foreground = Brushes.MidnightBlue;
                    //BitmapImage imagetemp15= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp25= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp35= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp45= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp55= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp65= new BitmapImage(new Uri("\\Images\\Btn+.png", UriKind.Relative));
                    //BitmapImage imagetemp75= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp85= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //img1.ImageSource = imagetemp15;
                    //img2.ImageSource = imagetemp25;
                    //img3.ImageSource = imagetemp35;
                    //img4.ImageSource = imagetemp45;
                    //img5.ImageSource = imagetemp55;
                    //img6.ImageSource = imagetemp65;
                    //img7.ImageSource = imagetemp75;
                    //img8.ImageSource = imagetemp85;
                    #endregion
                    showFrame.Source = new Uri("Drugstore.xaml", UriKind.Relative);
                    break;

                case "药库管理":
                    #region 按钮变色
                    btn.Foreground = Brushes.LightSkyBlue;
                    btnFinance.Foreground = Brushes.MidnightBlue;
                    btnClinicBill.Foreground = Brushes.MidnightBlue;
                    btnSys.Foreground = Brushes.MidnightBlue;
                    btnClinicDoc.Foreground = Brushes.MidnightBlue;
                    btnClinicMan.Foreground = Brushes.MidnightBlue;
                    btnSickroom.Foreground = Brushes.MidnightBlue;
                    btnDrugstore.Foreground = Brushes.MidnightBlue;
                    //BitmapImage imagetemp16= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp26= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp36= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp46= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp56= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp66= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp76= new BitmapImage(new Uri("\\Images\\Btn+.png", UriKind.Relative));
                    //BitmapImage imagetemp86= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //img1.ImageSource = imagetemp16;
                    //img2.ImageSource = imagetemp26;
                    //img3.ImageSource = imagetemp36;
                    //img4.ImageSource = imagetemp46;
                    //img5.ImageSource = imagetemp56;
                    //img6.ImageSource = imagetemp66;
                    //img7.ImageSource = imagetemp76;
                    //img8.ImageSource = imagetemp86;
                    #endregion
                    showFrame.Source = new Uri("Medicine.xaml", UriKind.Relative);
                    break;

                case "财务管理":
                    #region 按钮变色
                    btn.Foreground = Brushes.LightSkyBlue;
                    btnClinicBill.Foreground = Brushes.MidnightBlue;
                    btnSys.Foreground = Brushes.MidnightBlue;
                    btnClinicDoc.Foreground = Brushes.MidnightBlue;
                    btnClinicMan.Foreground = Brushes.MidnightBlue;
                    btnSickroom.Foreground = Brushes.MidnightBlue;
                    btnDrugstore.Foreground = Brushes.MidnightBlue;
                    btnMedicine.Foreground = Brushes.MidnightBlue;
                    //BitmapImage imagetemp17= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp27= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp37= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp47= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp57= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp67= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp77= new BitmapImage(new Uri("\\Images\\Btn-.png", UriKind.Relative));
                    //BitmapImage imagetemp87= new BitmapImage(new Uri("\\Images\\Btn+.png", UriKind.Relative));
                    //img1.ImageSource = imagetemp17;
                    //img2.ImageSource = imagetemp27;
                    //img3.ImageSource = imagetemp37;
                    //img4.ImageSource = imagetemp47;
                    //img5.ImageSource = imagetemp57;
                    //img6.ImageSource = imagetemp67;
                    //img7.ImageSource = imagetemp77;
                    //img8.ImageSource = imagetemp87;
                    #endregion
                    showFrame.Source = new Uri("Finance.xaml", UriKind.Relative);
                    break;
            }
        }
        //最大化
        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                BitmapImage imagetemp1 = new BitmapImage(new Uri("\\Images\\RE.png", UriKind.Relative));
                imgRE.Source = imagetemp1;
                btnMax.ToolTip = "向下还原";
            }
            else  //还原
            {
                WindowState = WindowState.Normal;
                BitmapImage imagetemp2 = new BitmapImage(new Uri("\\Images\\MAX.png", UriKind.Relative));
                imgRE.Source = imagetemp2;
                btnMax.ToolTip = "最大化";
            }
        }
        //最小化
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


    }
}
