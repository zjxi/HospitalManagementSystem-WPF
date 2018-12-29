using BLL;
using Model;
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
    /// Finance_business.xaml 的交互逻辑
    /// </summary>
    public partial class Finance_business : Page
    {
        public Finance_business()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                Init_Load();
            };
        }

        List<SectionRoom> se;
        List<zhuayuantongji> zhuyuantongji;

        private void Init_Load()
        {
            listView1.Items.Clear();
            se = new UsersBLL().Section();
            comboBox1.ItemsSource = se;
            zhuyuantongji = new IdCard_BLL().p_zhuayuantongji();
            int i = 0;
            int i1 = 0;
            foreach (zhuayuantongji ite in zhuyuantongji)
            {
                string str = ite.Kid + "";
                if (str.Length < 2)
                {
                    str = "0000" + str;
                }
                listView1.Items.Add(new
                {
                    c1 = str,
                    c2 = ite.Sname,
                    c3 = ite.ymoney,
                    c4 = ite.zmoney,
                    c5 = ite.time
                });
                i += ite.ymoney;
                i1 += ite.zmoney;
            }
            label5.Content = i + "";
            label3.Content = i1 + "";
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            listView1.Items.Clear();
            if (checkBox1.IsChecked == true && checkBox2.IsChecked == true)
            {
                Init_Load();
            }
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            listView1.Items.Clear();
            int i1 = 0;
            int i = 0;
            foreach (var ite in zhuyuantongji.Where(p => p.zmoney != 0))
            {
                string str = ite.Kid + "";
                if (str.Length < 2)
                {
                    str = "0000" + str;
                }
                listView1.Items.Add(new
                {
                    c1 = str,
                    c2 = ite.Sname,
                    c3 = ite.ymoney,
                    c4 = ite.zmoney,
                    c5 = ite.time
                });
                i += ite.ymoney;
                i1 += ite.zmoney;
            }
            label5.Content = i + "";
            label3.Content = i1 + "";
        }


    }
}
