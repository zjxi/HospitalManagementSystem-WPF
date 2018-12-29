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
using System.Drawing;
using Microsoft.Win32;
using System.IO;

namespace UI
{
    /// <summary>
    /// ListSettings.xaml 的交互逻辑
    /// </summary>
    public partial class ListSettings : Window
    {
        public ListSettings()
        {
            InitializeComponent();
        }
        //窗口重载
        public ListSettings(string title)
        {
            InitializeComponent();
            tb_title.Text = title;
        }
        //保存，预览，字体，颜色按钮点击事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string con = btn.Content.ToString();
            switch (con)
            {
                case "保存":
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Image Files (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg | All Files | *.*";
                    sfd.RestoreDirectory = true;  //保存对话框是否记忆上次打开的目录 
                    if (sfd.ShowDialog() == true)
                    {
                        var encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create((BitmapSource)this.imgList.Source));
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            encoder.Save(stream);
                        }
                    }
                    break;

                case "清空":
                    txtShow.Text = "";
                    #region 复选框批量取消选中
                    cb1.IsChecked = false;
                    cb2.IsChecked = false;
                    cb3.IsChecked = false;
                    cb4.IsChecked = false;
                    cb5.IsChecked = false;
                    cb6.IsChecked = false;
                    cb7.IsChecked = false;
                    cb8.IsChecked = false;
                    cb9.IsChecked = false;
                    cb10.IsChecked = false;
                    cb11.IsChecked = false;
                    #endregion
                    break;

                case "预览":
                    #region 病单预览
                    previewPanel.Visibility = Visibility.Visible;
                    if (tb_title.Text.ToString().Equals("住院单"))
                    {
                        BitmapImage image = new BitmapImage(new Uri("\\Images\\zyd.jpg", UriKind.Relative));
                        imgList.Source = image;
                        txtPreview.Text = txtShow.Text;
                    }
                    if (tb_title.Text.ToString().Equals("门诊单"))
                    {
                        BitmapImage image = new BitmapImage(new Uri("\\Images\\mzd.jpg", UriKind.Relative));
                        imgList.Source = image;
                        txtPreview.Text = txtShow.Text;
                    }
                    if (tb_title.Text.ToString().Equals("挂号单"))
                    {
                        BitmapImage image = new BitmapImage(new Uri("\\Images\\ghd.jpg", UriKind.Relative));
                        imgList.Source = image;
                        txtPreview.Text = txtShow.Text;
                    }
                    #endregion
                    break;

            }
        }
        //复选框选择事件
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = e.Source as CheckBox;
            txtShow.Text += cb.Content.ToString() + "\n";
        }
        //添加项目事件
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            txtShow.Text += tb_add.Text + "\n";
        }
        //复选框取消选择事件
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = e.Source as CheckBox;
            txtShow.Text = txtShow.Text.Replace(cb.Content.ToString() + '\n', "");
        }
        //退出预览按钮事件
        private void btnShut_Click(object sender, RoutedEventArgs e)
        {
            previewPanel.Visibility = Visibility.Hidden;
        }
        //打印按钮事件
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(printArea, "打印单子");
            }
        }
    }
}
