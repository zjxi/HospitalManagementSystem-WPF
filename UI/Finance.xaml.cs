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
    /// Finance.xaml 的交互逻辑
    /// </summary>
    public partial class Finance : Page
    {
        public Finance()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string s = btn.Name.ToString();
            switch (s)
            {
                case "business":
                    #region 按钮换图
                    BitmapImage imagetemp1 = new BitmapImage(new Uri("\\Images\\yingye2.png", UriKind.Relative));
                    BitmapImage imagetemp2 = new BitmapImage(new Uri("\\Images\\yuangong1.png", UriKind.Relative));
                    BitmapImage imagetemp3 = new BitmapImage(new Uri("\\Images\\gongzi1.png", UriKind.Relative));
                    img1.Source = imagetemp1;
                    img2.Source = imagetemp2;
                    img3.Source = imagetemp3;
                    #endregion
                    financeFrame.Source = new Uri("Finance_business.xaml", UriKind.Relative);
                    break;

                case "staff":
                    #region 按钮换图
                    BitmapImage imagetemp11 = new BitmapImage(new Uri("\\Images\\yingye1.png", UriKind.Relative));
                    BitmapImage imagetemp21 = new BitmapImage(new Uri("\\Images\\yuangong2.png", UriKind.Relative));
                    BitmapImage imagetemp31 = new BitmapImage(new Uri("\\Images\\gongzi1.png", UriKind.Relative));
                    img1.Source = imagetemp11;
                    img2.Source = imagetemp21;
                    img3.Source = imagetemp31;
                    #endregion
                    financeFrame.Source = new Uri("Finance_staff.xaml", UriKind.Relative);
                    break;

                case "salary":
                    #region 按钮换图
                    BitmapImage imagetemp12 = new BitmapImage(new Uri("\\Images\\yingye1.png", UriKind.Relative));
                    BitmapImage imagetemp22 = new BitmapImage(new Uri("\\Images\\yuangong1.png", UriKind.Relative));
                    BitmapImage imagetemp32 = new BitmapImage(new Uri("\\Images\\gongzi2.png", UriKind.Relative));
                    img1.Source = imagetemp12;
                    img2.Source = imagetemp22;
                    img3.Source = imagetemp32;
                    #endregion
                    break;
            }

        }

    }
}
