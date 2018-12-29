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
    /// Drugstore.xaml 的交互逻辑
    /// </summary>
    public partial class Drugstore : Page
    {
        public Drugstore()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string s = btn.Name.ToString();
            switch (s)
            {
                case "btn1":
                    #region 按钮换图
                    BitmapImage imagetemp1 = new BitmapImage(new Uri("\\Images\\jianyaodan2.png", UriKind.Relative));
                    BitmapImage imagetemp2 = new BitmapImage(new Uri("\\Images\\yifayao.png", UriKind.Relative));
                    img1.Source = imagetemp1;
                    img2.Source = imagetemp2;
                    #endregion
                    drugFrame.Source = new Uri("DrugstorePage1.xaml", UriKind.Relative);
                    break;

                case "btn2":
                    #region 按钮换图
                    BitmapImage imagetemp3 = new BitmapImage(new Uri("\\Images\\jianyaodan.png", UriKind.Relative));
                    BitmapImage imagetemp4 = new BitmapImage(new Uri("\\Images\\yifayao2.png", UriKind.Relative));
                    img2.Source = imagetemp4;
                    img1.Source = imagetemp3;
                    #endregion
                    drugFrame.Source = new Uri("DrugstorePage2.xaml", UriKind.Relative);
                    break;

            }
        }
    }
}
