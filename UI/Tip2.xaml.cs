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

namespace UI
{
    /// <summary>
    /// Tip2.xaml 的交互逻辑
    /// </summary>
    public partial class Tip2 : Window
    {
        Page p;
        public Tip2(string info, Page page)
        {
            InitializeComponent();
            tipShow.Text = info;
            p = page;
        }
        //确定
        private void BtnSure_Click(object sender, RoutedEventArgs e)
        {
            p.Tag = "确定";
            this.Close();
        }
        //取消
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
