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
    /// HospitalManage_bookkeeping.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalManage_bookkeeping : Page
    {
        public HospitalManage_bookkeeping()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                Init_Load();
            };
        }

        List<zhuyuan> zhu;
        List<SectionRoom> se;

        private void Init_Load()
        {
            listView1.Items.Clear();
            se = new UsersBLL().Section();
            //comboBox1.DataSource = se;
            //comboBox1.SelectedIndex = 0;
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
            if (listView2.SelectedItems.Count > 0)
            {
                label17.Content = "" + listView2.Items.Count;
                int i = 0;
                string s = listView2.Items[listView2.SelectedIndex].ToString();
                string[] ss = s.Split(','); ;
                foreach (ListViewItem item in listView2.Items)
                {
                    i += int.Parse(ss[3].Substring(3).Replace("=", "").Trim()) * int.Parse(ss[6].Substring(3).Replace("=", "").Trim());
                }
                label20.Content = i + ":00";
            }
        }
        //病人卡号搜索
        private void Button3_Click(object sender, RoutedEventArgs e)
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
        //全部显示
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Init_Load();
        }
        //病人姓名搜索
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                var p = new Tip("请输入姓名!");
                p.ShowDialog();
                return;
            }
            listView1.Items.Clear();

            if (zhu.Where(p => p.Kname == (txtName.Text)).Count() == 0)
            {
                var p = new Tip("没有数据!");
                p.ShowDialog();
                return;
            }
            foreach (var z in zhu.Where(p => p.Kname == (txtName.Text)))
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
        int num = 0;
        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listView2.Items.Clear();
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                txtId.Text = ss[0].Substring(4).Replace("=", "").Trim();
                txtkeshi.Text = ss[2].Substring(3).Replace("=", "").Trim();
                txttime.Text = ss[8].Substring(4).Replace("=", "").Trim();
                txtmingzi.Text = ss[1].Substring(3).Replace("=", "").Trim();
                txtyujiao.Text = ss[5].Substring(3).Replace("=", "").Trim();

                listView2.Visibility = Visibility.Visible;
                txtyaopin.IsEnabled = false;
                btninsert.Content = "新单";
                num = 0;
                txtyaopin.Text = "";
            }
            List<zhuyuanxiaofei> xfs = new IdCard_BLL().p_zhuyuanxiaofei_select(int.Parse(txtId.Text));
            foreach (zhuyuanxiaofei xf in xfs)
            {
                List<Drug_insert> di = new Drug_insert_BLL().SelectAll(xf.yaoName);
                int i = 0;
                listView2.Items.Add(new
                {
                    c1 = di[i].Dname,
                    c2 = di[i].Dtype,
                    c3 = di[i].DcostName,
                    c4 = xf.yaonum,
                    c5 = di[i].Dspec,
                    c6 = di[i].DjiXing,
                    c7 = di[i].DsellPrice,
                    c8 = di[i].DeffectTime,
                    c9 = di[i].DproductTime,
                    c10 = di[i].Efficay
                });
                i++;
            }
        }
        //添加
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (textBox15.Text == "0")
            {
                var pm = new Tip("增加的数量不能为0！");
                pm.ShowDialog();
                return;
            }
            if (listView2.IsVisible == true)
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    int i = listView2.SelectedIndex;
                    string s = listView2.Items[i].ToString();
                    string[] ss = s.Split(',');
                    textBox15.Text = int.Parse(ss[3].Substring(3).Replace("=","").Trim()) + int.Parse(textBox15.Text) + "";
                    Button9_Click(null, null);

                    var p = new Tip("添加成功！");
                    p.ShowDialog();
                    textBox15.Text = "0";
                    return;
                }
            }
            foreach (ListViewItem item in listView2.Items)
            {
                string s = listView2.Items[listView2.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                if (ss[0].Substring(4).Replace("=", "").Trim() == textBox11.Text)
                {
                    textBox15.Text = int.Parse(ss[3].Substring(3).Replace("=", "").Trim()) + int.Parse(textBox15.Text) + "";
                    listView2.Visibility =Visibility.Visible;
                    txtyaopin.IsEnabled = false;
                    btninsert.Content = "新单";
                    num = 0;
                    textBox15.Text = "0";
                    Button9_Click(null, null);

                    var p = new Tip("添加成功！");
                    p.ShowDialog();
                    textBox15.Text = "0";
                    return;
                }
            }
            var pp = new Tip("没有添加信息！");
            pp.ShowDialog();
        }
        //药品智能搜索输入框改变
        private void Txtyaopin_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView2.Items.Clear();
            List<Drug_insert> di = new Drug_insert_BLL().SelectAll(txtyaopin.Text);
            for (int i = 0; i < di.Count; i++)
            {
                //listView2.Items.Add(new
                //{
                //    c1 = di[i].Dname,
                //    c2 = di[i].Dtype,
                //    c3 = di[i].DcostName,
                //   // c4 = xf.yaonum,
                //    c5 = di[i].Dspec,
                //    c6 = di[i].DjiXing,
                //    c7 = di[i].DsellPrice,
                //    c8 = di[i].DeffectTime,
                //    c9 = di[i].DproductTime,
                //    c10 = di[i].Efficay
                //});
            }
        }
        //增1
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            textBox15.Text = int.Parse(textBox15.Text) + 1 + "";
        }
        //减1
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(textBox15.Text) - 1 >= 0)
                textBox15.Text = int.Parse(textBox15.Text) - 1 + "";
        }
        //新单
        private void Btninsert_Click(object sender, RoutedEventArgs e)
        {
            if (num == 0)
            {
                listView2.Visibility = Visibility.Hidden;
                txtyaopin.IsEnabled = true;
                btninsert.Content = "返回";
                num = 1;
                Txtyaopin_TextChanged(null, null);
            }
            else
            {
                listView2.Visibility = Visibility.Visible;
                txtyaopin.IsEnabled = false;
                btninsert.Content = "新单";
                num = 0;
            }
        }
        //删除
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                var p = new Tip2("确定要删除？", this);
                p.ShowDialog();
                if (this.Tag + "" == "OK")
                {
                    string s = listView2.Items[listView2.SelectedIndex].ToString();
                    string[] ss = s.Split(',');
                    new IdCard_BLL().p_zhuyuanxiaofei_delete(int.Parse(txtId.Text), ss[0].Substring(4).Replace("=","").Trim());
                    listView2.Items.RemoveAt(listView2.SelectedIndex);
                    this.Tag = "";
                }
            }
        }
        //保存
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            List<zhuyuanxiaofei> xfs = new List<zhuyuanxiaofei>();
            string s = listView2.Items[listView2.SelectedIndex].ToString();
            string[] ss = s.Split(',');
            foreach (ListViewItem item in listView2.Items)
            {
                zhuyuanxiaofei xf = new zhuyuanxiaofei();
                xf.kId = int.Parse(txtId.Text);
                xf.yaoName = ss[0].Substring(4).Replace("=", "").Trim();
                xf.yaonum = int.Parse(ss[3].Substring(3).Replace("=", "").Trim());
                xfs.Add(xf);
                //MessageBox.Show(item.SubItems[3].Text);
            }
            new IdCard_BLL().p_zhuyuanxiaofei_insert(xfs);
        }

        private void ListView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                string s = listView2.Items[listView2.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                textBox11.Text = ss[0].Substring(4).Replace("=", "").Trim();
                textBox12.Text = ss[4].Substring(3).Replace("=", "").Trim();
                textBox13.Text = ss[5].Substring(3).Replace("=", "").Trim();
                textBox14.Text = ss[6].Substring(3).Replace("=", "").Trim();
            }
        }


    }
}
