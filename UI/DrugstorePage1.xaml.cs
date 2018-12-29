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
    /// DrugstorePage1.xaml 的交互逻辑
    /// </summary>
    public partial class DrugstorePage1 : Page
    {
        public DrugstorePage1()
        {
            InitializeComponent();
        }
        List<Maidan> maidan;
        private void Init_Load()
        {
            listView1.Items.Clear();
            maidan = new IdCard_BLL().p_kaiyao_select();
            foreach (Maidan item in maidan)
            {
                if (item.zhuangtai == "yes")
                {
                    listView1.Items.Add(new
                    {
                        c1 = item.Rid,
                        c2 = item.Name,
                        c3 = item.Sex,
                        c4 = item.SectionRoom,
                        c5 = item.IdcardNo,

                    });
                }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                txtRid.Text = ss[0].Substring(3).Replace("=", "").Trim();
                txtName.Text = ss[1].Substring(2).Replace("=", "").Trim();
                listView2.Items.Add(new
                {
                    a1 = ss[0].Substring(3).Replace("=", "").Trim(),
                    a2 = ss[0].Substring(2).Replace("=", "").Trim(),
                    a3 = ss[0].Substring(2).Replace("=", "").Trim(),
                    a4 = ss[0].Substring(2).Replace("=", "").Trim(),
                    a5 = ss[0].Substring(2).Replace("=", "").Replace("}","").Trim(),
                });
                listView1.Items.RemoveAt(listView1.SelectedIndex);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                string str = listView2.Items[listView2.SelectedIndex].ToString();
                new IdCard_BLL().p_kaiyaoregister_delete(str);
                listView2.Items.RemoveAt(listView2.SelectedIndex);
                var p = new Tip("药品发药成功");
                p.ShowDialog();

            }
        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                txtRid.Text = ss[0].Substring(3).Replace("=", "").Trim();
                txtName.Text = ss[1].Substring(2).Replace("=", "").Trim();
            }
        }
        private void ListView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}

