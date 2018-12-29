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
    /// HospitalManage_searchPatient.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalManage_searchPatient : Page
    {
        public HospitalManage_searchPatient()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                Init_Load();
            };
        }

        List<SectionRoom> se;
        List<zhuyuan> zhu;

        private void Init_Load()
        {
            se = new UsersBLL().Section();
            ComboBox1.ItemsSource = se;
            zhu = new IdCard_BLL().p_zhuyuan_Select();
            foreach (zhuyuan z in zhu)
            {
                listView1.Items.Add(new
                {
                    c1 = z.kId,
                    c2 = z.Kname,
                    c3 = se[z.Sid].Sname,
                    c4 = z.Idsickroom,
                    c5 = z.BedNo,
                    c6 = z.Imprest,
                    c7 = z.Bewrite,
                    c8 = z.Tabu,
                    c9 = z.Ztime
                });
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    var p = new Tip("请输入卡号!");
                    p.ShowDialog();
                    return;
                }
                listView1.Items.Clear();
                if (zhu.Where(p => p.kId == int.Parse(textBox1.Text)).Count() == 0)
                {
                    var p = new Tip("没有数据!");
                    p.ShowDialog();
                    return;
                }
                foreach (var z in zhu.Where(p => p.kId == int.Parse(textBox1.Text)))
                {
                    listView1.Items.Add(new
                    {
                        c1 = z.kId,
                        c2 = z.Kname,
                        c3 = se[z.Sid].Sname,
                        c4 = z.Idsickroom,
                        c5 = z.BedNo,
                        c6 = z.Imprest,
                        c7 = z.Bewrite,
                        c8 = z.Tabu,
                        c9 = z.Ztime
                    });
                }

            }
            catch
            {
                var p = new Tip("病人编号只能是数字!");
                p.ShowDialog();
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            listView1.Items.Clear();
            if (zhu.Where(p => p.Sid == ComboBox1.SelectedIndex).Count() == 0)
            {
                var p = new Tip("没有数据!");
                p.ShowDialog();
                return;
            }
            foreach (var z in zhu.Where(p => p.Sid == ComboBox1.SelectedIndex))
            {
                listView1.Items.Add(new
                {
                    c1 = z.kId,
                    c2 = z.Kname,
                    c3 = se[z.Sid].Sname,
                    c4 = z.Idsickroom,
                    c5 = z.BedNo,
                    c6 = z.Imprest,
                    c7 = z.Bewrite,
                    c8 = z.Tabu,
                    c9 = z.Ztime
                });
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (textBox3.Text == "")
            {
                var p = new Tip("请输入姓名!");
                p.ShowDialog();
                return;
            }
            listView1.Items.Clear();

            if (zhu.Where(p => p.Kname == (textBox3.Text)).Count() == 0)
            {
               var p = new Tip("没有数据!");
                p.ShowDialog();
                return;
            }
            foreach (var z in zhu.Where(p => p.Kname == (textBox3.Text)))
            {
                listView1.Items.Add(new
                {
                    c1 = z.kId,
                    c2 = z.Kname,
                    c3 = se[z.Sid].Sname,
                    c4 = z.Idsickroom,
                    c5 = z.BedNo,
                    c6 = z.Imprest,
                    c7 = z.Bewrite,
                    c8 = z.Tabu,
                    c9 = z.Ztime
                });
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (textBox4.Text == "")
            {
               var p = new Tip("请输入病房号!");
                p.ShowDialog();
                return;
            }
            listView1.Items.Clear();
            if (zhu.Where(p => (p.Idsickroom + "") == textBox4.Text).Count() == 0)
            {
                var p = new Tip("没有数据");
                p.ShowDialog();
                return;
            }
            foreach (var z in zhu.Where(p => (p.Idsickroom + "") == textBox4.Text))
            {
                listView1.Items.Add(new
                {
                    c1 = z.kId,
                    c2 = z.Kname,
                    c3 = se[z.Sid].Sname,
                    c4 = z.Idsickroom,
                    c5 = z.BedNo,
                    c6 = z.Imprest,
                    c7 = z.Bewrite,
                    c8 = z.Tabu,
                    c9 = z.Ztime
                });
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (textBox5.Text == "")
            {
                var p = new Tip("请输入楼房号!");
                p.ShowDialog();
                return;
            }
            listView1.Items.Clear();
            if (zhu.Where(p => (p.Idsickroom + "").Substring(0, 1) == textBox5.Text).Count() == 0)
            {
                var p = new Tip("没有数据");
                p.ShowDialog();
                return;
            }
            foreach (var z in zhu.Where(p => (p.Idsickroom + "").Substring(0, 1) == textBox5.Text))
            {
                listView1.Items.Add(new
                {
                    c1 = z.kId,
                    c2 = z.Kname,
                    c3 = se[z.Sid].Sname,
                    c4 = z.Idsickroom,
                    c5 = z.BedNo,
                    c6 = z.Imprest,
                    c7 = z.Bewrite,
                    c8 = z.Tabu,
                    c9 = z.Ztime
                });
            }
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            listView1.Items.Clear();
            Init_Load();
        }


    }
}
