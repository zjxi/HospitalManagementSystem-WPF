using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using Model;
using BLL;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// “登陆”点击事件
        /// </summary>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Users u = new Users
            {
                Uname = txtBoxUserName.Text,
                Pwd = txtBoxPwd.Password
            };

            int i = new UsersBLL().Check(u);
            if (txtBoxUserName.Text == "")
            {
                userNameTip.Visibility = Visibility.Visible;
                userNameTip.Content = "用户名不能为空!";
                return;
            }
            else if (txtBoxPwd.Password == "")
            {
                pwdTip.Visibility = Visibility.Visible;
                pwdTip.Content = "密码不能为空!";
                return;
            }
            else if (i == 1) {

                pwdTip.Visibility = Visibility.Visible;
                pwdTip.Content = "密码不正确!";
            }
            else if (i == 0)
            {
                userNameTip.Visibility = Visibility.Visible;
                userNameTip.Content = "没有此用户!";
            }
            else if (i == 3)
            {
                MessageBox.Show("系统错误!", "系统提示");
            }
            else
            {
                MainUnit m = new MainUnit
                {
                    Tag = txtBoxUserName.Text
                };
                m.Show();
                this.Close();
            }
        }
        /// <summary>
        /// “取消”点击事件
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 用户名输入框改变
        /// </summary>
        private void txtBoxUserName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            userNameTip.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// 密码输入框改变
        /// </summary>
        private void txtBoxPwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pwdTip.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// 鼠标主键拖拽窗口
        /// </summary>
        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch{ }
        }
        /// <summary>
        /// 鼠标进入“登陆”按钮
        /// </summary>
        private void btnLogin_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("\\Images\\LoginD.png", UriKind.Relative));
            imgLogin.Source = imagetemp;
            
        }
        /// <summary>
        /// 鼠标离开“登陆”按钮
        /// </summary>
        private void btnLogin_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("\\Images\\Login.png", UriKind.Relative));
            imgLogin.Source = imagetemp;
        }
        /// <summary>
        /// 鼠标进入“取消”按钮
        /// </summary>
        private void btnCancel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("\\Images\\CancelD.png", UriKind.Relative));
            imgCancel.Source = imagetemp;
        }
        /// <summary>
        /// 鼠标离开“取消”按钮
        /// </summary>
        private void btnCancel_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("\\Images\\Cancel.png", UriKind.Relative));
            imgCancel.Source = imagetemp;
        }

        private void txtBoxPwd_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.MouseMove -= Window_MouseMove;
        }

        private void txtBoxPwd_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.MouseMove += Window_MouseMove;
        }
    }
}
