using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Text.RegularExpressions;

namespace UI
{
    /// <summary>
    /// SectionroomRevise.xaml 的交互逻辑
    /// </summary>
    public partial class SectionroomRevise : Window
    {
        public SectionroomRevise()
        {
            InitializeComponent();
            Loaded += (s, e) =>
              {
                  Init_Load(s, e);
              };
        }

        List<SectionRoom> se;
        //初始化加载
        private void Init_Load(object sender, RoutedEventArgs e)
        {
            se = new UsersBLL().Section();
            foreach (SectionRoom item in se)
            {
                listView1.Items.Add(new {sec=item.Sname , addr=item.Saddr , price=item.Sprice });
            }
        }
        //修改
        private void BtnRevise_Click(object sender, RoutedEventArgs e)
        {
            SectionRoom s = new SectionRoom();
            s.Sname = txtSname.Text;
            s.Saddr = txtSaddr.Text;
            s.Sprice = int.Parse(txtSprice.Text);
            new SectionRoomBLL().Update(s);
            listView1.Items.Clear();
            Init_Load(null, null);
        }
        //删除
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            SectionRoom s = new SectionRoom();
            if (listView1.SelectedItems.Count > 0)
            {
                s.Sname = txtSname.Text;
                new SectionRoomBLL().Delete(s);
                listView1.Items.RemoveAt(listView1.SelectedIndex);
            }
            listView1.Items.Clear();
            Init_Load(null, null);
            txtSname.Text = "";
            txtSaddr.Text = "";
            txtSprice.Text = "";
            Tip p = new Tip("删除成功");
            p.ShowDialog();
        }
        //ListView选项发生改变
        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                txtSname.Text = ss[0].Substring(6).Replace("=", "").Trim();
                txtSaddr.Text = ss[1].Substring(6).Replace("=", "").Trim();
                txtSprice.Text = ss[2].Substring(7).Replace("}", "").Replace("=", "").Trim();
            }
        }

    }
}
