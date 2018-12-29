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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Finance_staff.xaml 的交互逻辑
    /// </summary>
    public partial class Finance_staff : Page
    {
        public Finance_staff()
        {
            InitializeComponent();
            Loaded += (s, e) => 
            {
                Init_Load();
            };
        }

        List<Users> us;
        private void Init_Load()
        {
            listView1.Items.Clear();
            us = new IdCard_BLL().p_users_select01();
            foreach (Users q in us)
            {
                listView1.Items.Add(new
                {
                    c1 = q.Id,
                    c2 = q.Uname,
                    c3 = q.name,
                    c4 = q.Sex,
                    c5 = q.Address,
                    c6 = q.Phone,
                    c7 = q.Spell,
                    c8 = q.Type,
                    c9 = q.SectionRoom,
                    c10 = q.money
                });
            }
            List<UsersType> type = new IdCard_BLL().p_usesType_select();
            foreach (var item in type)
            {
                comboBox1.Items.Add(item.Type);
            }
            List<SectionRoom> se = new UsersBLL().Section();
            foreach (var item in se)
            {
                comboBox2.Items.Add(item.Sname);
            }
        }
        //保存
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var t = new Tip("保存成功！");
            Init_Load();
            t.ShowDialog();
        }
        //删除所选项
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                string uid = ss[0].Substring(4).Replace("=", "").Trim();
                new IdCard_BLL().p_users_delete(uid);
                listView1.Items.RemoveAt(listView1.SelectedIndex);
                Init_Load();
            }
        }
        //类型选项变化
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.Text == "医师")
            {
                comboBox2.IsEnabled = true;
                textBox9.IsEnabled = true;

            }
            else
            {
                comboBox2.Text = "";
                textBox9.Text = "";
                comboBox2.IsEnabled = false;
                textBox9.IsEnabled = false;

            }
        }
        //列表选中项发生改变
        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                textBox1.Text = ss[1].Substring(3).Replace("=", "").Trim();
                textBox4.Text = ss[2].Substring(3).Replace("=", "").Trim();

                if (ss[3].Substring(3).Replace("=", "").Trim() == "男")
                    radioButton1.IsChecked = true;
                else
                    radioButton2.IsChecked = true;

                textBox5.Text = ss[4].Substring(3).Replace("=", "").Trim();
                textBox6.Text = ss[5].Substring(3).Replace("=", "").Trim();
                textBox7.Text = ss[6].Substring(3).Replace("=", "").Trim();
                comboBox1.Text = ss[7].Substring(3).Replace("=", "").Trim();
                comboBox2.Text = ss[8].Substring(3).Replace("=", "").Trim();
                textBox9.Text = ss[9].Substring(3).Replace("=", "").Replace("}","").Trim();

            }
        }


    }
}
