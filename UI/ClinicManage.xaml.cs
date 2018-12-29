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
    /// ClinicManage.xaml 的交互逻辑
    /// </summary>
    public partial class ClinicManage : Page
    {
        public ClinicManage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string s = btn.Name.ToString();
            switch (s)
            {
                case "register":
                    #region 按钮换图
                    BitmapImage imagetemp1 = new BitmapImage(new Uri("\\Images\\bingren2.png", UriKind.Relative));
                    BitmapImage imagetemp2 = new BitmapImage(new Uri("\\Images\\card1.png", UriKind.Relative));
                    img1.Source = imagetemp1;
                    img2.Source = imagetemp2;
                    #endregion
                    clinicManFrame.Source = new Uri("ClinicManage_register.xaml", UriKind.Relative);
                    break;

                case "medicalCard":
                    #region 按钮换图
                    BitmapImage imagetemp11 = new BitmapImage(new Uri("\\Images\\bingren1.png", UriKind.Relative));
                    BitmapImage imagetemp21 = new BitmapImage(new Uri("\\Images\\card2.png", UriKind.Relative));
                    img1.Source = imagetemp11;
                    img2.Source = imagetemp21;
                    #endregion
                    clinicManFrame.Source = new Uri("ClinicManage_medicalCard.xaml", UriKind.Relative);
                    break;
            }
        }
    }
}
