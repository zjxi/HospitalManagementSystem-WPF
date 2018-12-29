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
    /// Medicine.xaml 的交互逻辑
    /// </summary>
    public partial class Medicine : Page
    {
        public Medicine()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string s = btn.Name.ToString();
            switch (s)
            {
                case "drug_in":
                    #region 按钮换图
                    BitmapImage imagetemp1 = new BitmapImage(new Uri("\\Images\\drug_in2.png", UriKind.Relative));
                    BitmapImage imagetemp2 = new BitmapImage(new Uri("\\Images\\drug_select.png", UriKind.Relative));
                    BitmapImage imagetemp3 = new BitmapImage(new Uri("\\Images\\drug_out.png", UriKind.Relative));
                    img1.Source = imagetemp1;
                    img2.Source = imagetemp2;
                    img3.Source = imagetemp3;
                    #endregion
                    //MedicinePage1 mp1 = new MedicinePage1();
                    medicineFrame.Source = new Uri("MedicinePage1.xaml", UriKind.Relative);
                    break;

                case "drug_select":
                    #region 按钮换图
                    BitmapImage imagetemp4 = new BitmapImage(new Uri("\\Images\\drug_in.png", UriKind.Relative));
                    BitmapImage imagetemp5 = new BitmapImage(new Uri("\\Images\\drug_select2.png", UriKind.Relative));
                    BitmapImage imagetemp6 = new BitmapImage(new Uri("\\Images\\drug_out.png", UriKind.Relative));
                    img1.Source = imagetemp4;
                    img2.Source = imagetemp5;
                    img3.Source = imagetemp6;
                    #endregion
                    medicineFrame.Source = new Uri("MedicinePage2.xaml", UriKind.Relative);
                    break;

                case "drug_out":
                    #region 按钮换图
                    BitmapImage imagetemp7 = new BitmapImage(new Uri("\\Images\\drug_in.png", UriKind.Relative));
                    BitmapImage imagetemp8 = new BitmapImage(new Uri("\\Images\\drug_select.png", UriKind.Relative));
                    BitmapImage imagetemp9 = new BitmapImage(new Uri("\\Images\\drug_out2.png", UriKind.Relative));
                    img1.Source = imagetemp7;
                    img2.Source = imagetemp8;
                    img3.Source = imagetemp9;
                    #endregion
                    medicineFrame.Source = new Uri("MedicinePage3.xaml", UriKind.Relative);
                    break;
            }
        }
    }
}
