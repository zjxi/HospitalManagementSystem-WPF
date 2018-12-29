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
    /// Tip.xaml 的交互逻辑
    /// </summary>
    public partial class Tip : Window
    {
        public Tip()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="str">提示文字</param>
        public Tip(string str)
        {
            InitializeComponent();
            tipShow.Text = str;
        }
        /// <summary>
        /// 提示信息、标题
        /// </summary>
        /// <param name="str">提示文字</param>
        /// <param name="str">标题</param>
        public Tip(string str, string title)
        {
            InitializeComponent();
            tipShow.Text = str;
            lblCaption.Content = title;
        }

        //确定退出提示窗口
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //鼠标拖拽
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
    }
}
