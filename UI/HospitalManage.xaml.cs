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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// HospitalManage.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalManage : Page
    {
        public HospitalManage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string s = btn.Tag.ToString();
            switch (s)
            {
                case "病房查看":
                    #region 按钮换图
                    BitmapImage imagetemp1 = new BitmapImage(new Uri("\\Images\\hos2.png", UriKind.Relative));
                    BitmapImage imagetemp2 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp3 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp4 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp5 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp6 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp7 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    img1.Source = imagetemp1;
                    img2.Source = imagetemp2;
                    img3.Source = imagetemp3;
                    img4.Source = imagetemp4;
                    img5.Source = imagetemp5;
                    img6.Source = imagetemp6;
                    img7.Source = imagetemp7;
                    #endregion
                    hosManFrame.Source = new Uri("HospitalManage_sickroomCheck.xaml", UriKind.Relative);
                    break;

                case "病房添加":
                    #region 按钮换图
                    BitmapImage imagetemp11= new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp21= new BitmapImage(new Uri("\\Images\\hos2.png", UriKind.Relative));
                    BitmapImage imagetemp31= new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp41= new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp51= new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp61= new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp71= new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    img1.Source = imagetemp11;
                    img2.Source = imagetemp21;
                    img3.Source = imagetemp31;
                    img4.Source = imagetemp41;
                    img5.Source = imagetemp51;
                    img6.Source = imagetemp61;
                    img7.Source = imagetemp71;
                    #endregion
                    hosManFrame.Source = new Uri("HospitalManage_sickroomAdd.xaml", UriKind.Relative);
                    break;
                case "住院登记":
                    #region 按钮换图
                    BitmapImage imagetemp12 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp22 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp32 = new BitmapImage(new Uri("\\Images\\hos2.png", UriKind.Relative));
                    BitmapImage imagetemp42 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp52 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp62 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp72 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    img1.Source = imagetemp12;
                    img2.Source = imagetemp22;
                    img3.Source = imagetemp32;
                    img4.Source = imagetemp42;
                    img5.Source = imagetemp52;
                    img6.Source = imagetemp62;
                    img7.Source = imagetemp72;
                    #endregion
                    hosManFrame.Source = new Uri("HospitalManage_register.xaml", UriKind.Relative);
                    break;

                case "付款查看":
                    #region 按钮换图
                    BitmapImage imagetemp13 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp23 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp33 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp43 = new BitmapImage(new Uri("\\Images\\hos2.png", UriKind.Relative));
                    BitmapImage imagetemp53 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp63 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp73 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    img1.Source = imagetemp13;
                    img2.Source = imagetemp23;
                    img3.Source = imagetemp33;
                    img4.Source = imagetemp43;
                    img5.Source = imagetemp53;
                    img6.Source = imagetemp63;
                    img7.Source = imagetemp73;
                    #endregion
                    hosManFrame.Source = new Uri("HospitalManage_payment.xaml", UriKind.Relative);
                    break;

                case "病人查找":
                    #region 按钮换图
                    BitmapImage imagetemp14 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp24 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp34 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp44 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp54 = new BitmapImage(new Uri("\\Images\\hos2.png", UriKind.Relative));
                    BitmapImage imagetemp64 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp74 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    img1.Source = imagetemp14;
                    img2.Source = imagetemp24;
                    img3.Source = imagetemp34;
                    img4.Source = imagetemp44;
                    img5.Source = imagetemp54;
                    img6.Source = imagetemp64;
                    img7.Source = imagetemp74;
                    #endregion
                    hosManFrame.Source = new Uri("HospitalManage_searchPatient.xaml", UriKind.Relative);
                    break;

                case "费用记账":
                    #region 按钮换图
                    BitmapImage imagetemp15 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp25 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp35 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp45 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp55 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp65 = new BitmapImage(new Uri("\\Images\\hos2.png", UriKind.Relative));
                    BitmapImage imagetemp75 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    img1.Source = imagetemp15;
                    img2.Source = imagetemp25;
                    img3.Source = imagetemp35;
                    img4.Source = imagetemp45;
                    img5.Source = imagetemp55;
                    img6.Source = imagetemp65;
                    img7.Source = imagetemp75;
                    #endregion
                    hosManFrame.Source = new Uri("HospitalManage_bookkeeping.xaml", UriKind.Relative);
                    break;

                case "出院结算":
                    #region 按钮换图
                    BitmapImage imagetemp16 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp26 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp36 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp46 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp56 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp66 = new BitmapImage(new Uri("\\Images\\hos1.png", UriKind.Relative));
                    BitmapImage imagetemp76 = new BitmapImage(new Uri("\\Images\\hos2.png", UriKind.Relative));
                    img1.Source = imagetemp16;
                    img2.Source = imagetemp26;
                    img3.Source = imagetemp36;
                    img4.Source = imagetemp46;
                    img5.Source = imagetemp56;
                    img6.Source = imagetemp66;
                    img7.Source = imagetemp76;
                    #endregion
                    hosManFrame.Source = new Uri("HospitalManage_settlement.xaml", UriKind.Relative);
                    break;

            }

        }
    }
}
