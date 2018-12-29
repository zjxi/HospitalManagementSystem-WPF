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
    /// ClinicDoctor1.xaml 的交互逻辑
    /// </summary>
    public partial class ClinicDoctor1 : Page
    {
        string s;
        public ClinicDoctor1(string str)
        {
            InitializeComponent();
            s = new IdCard_BLL().p_peodom_select(str + "");
            List<Users> us = new IdCard_BLL().p_users_select01();
            //初始药物禁忌与服法列表框隐藏
            listBoxTaboo.Visibility = Visibility.Hidden;
            listBoxUsage.Visibility = Visibility.Hidden;
            listBox3.Visibility = Visibility.Hidden;
            listBox4.Visibility = Visibility.Hidden;
            //调用加载项
            Load();
        }

        List<Drug_insert> di;
        List<SectionRoom> se;
        List<SectionRoomSo> sw;

        List<TreeViewItem> node_list = new List<TreeViewItem>();
        private void Load()  //加载项
        {
            se = new UsersBLL().Section();
            sw = new SectionRoomSonBLL().Section();
            foreach (SectionRoom item in se)
            {
                TreeViewItem node = new TreeViewItem();
                node.Header = item.Sname;
                node_list.Add(node);
                foreach (SectionRoomSo it in sw)
                {
                    if (it.Sname == item.Sname)
                    {
                        node.Items.Add(it.SonSname);
                    }
                }
            }
            treeView1.ItemsSource = node_list;

            List<Register> lRegi = new Register_BLL().SelectAll();
            foreach (Register lR in lRegi)
            {
                lvwGuaHaoShow.Items.Add(new
                {
                    c1 = lR.Rid,
                    c2 = lR.KId,
                    c3 = lR.IdType,
                    c4 = lR.GuaDanFei,
                    c5 = lR.OtherFei,
                    c6 = lR.SectionRoom,
                    c7 = lR.Doctor,
                    c8 = lR.ReristerTime,
                    c9 = lR.SeeDoctorTime
                });
            }
        }
        //病例选项改变
        private void TreeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            foreach (SectionRoomSo item in sw)
            {
                if (treeView1.SelectedItem != null)
                {
                    if (treeView1.SelectedItem.ToString() == item.SonSname)
                    {
                        txtZhenduan.Text = item.SonSname;
                    }
                }
            }
        }
        //中药显示全部
        private void BtnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            lvwSelect.Items.Clear();
            di = new Drug_insert_BLL().SelectAll(txtSelect.Text);
            di.Where(p => p.Dtype == "中药");
            for (int i = 0; i < di.Count; i++)
            {
                lvwSelect.Items.Add(new
                {
                    c1 = i + 1 + "",
                    c2 = di[i].Dname,
                    c3 = di[i].Dspec,
                    c4 = di[i].DjiXing,
                    c5 = di[i].DsellPrice,
                    c6 = di[i].Efficay
                });
            }
        }
        void yy()
        {
            int count = 1;
            foreach (ListViewItem i in lvwYaofang.Items)
            {
                i.Content = count + "";
                count++;
            }
        }
        void ww()
        {
            int count = 1;
            foreach (ListViewItem i in lvwYaofang2.Items)
            {
                i.Content = count + "";
                count++;
            }
        }
        //中药显示搜索药品
        private void LvwSelect_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            yy();
            string str = lvwSelect.Items[lvwSelect.SelectedIndex].ToString();
            string[] ss = str.Split(',');
            string s = ss[1].Substring(3).Replace("=", "").Trim();
            foreach (ListViewItem ite in lvwYaofang.Items)
            {
                if (s == ite.Content.ToString())
                {
                    var p = new Tip("已经添加了该药品 !");
                    p.ShowDialog();
                    return;
                }
            }
            lvwYaofang.Items.Add(new
            {
                c1 = lvwYaofang2.Items.Count + 1 + "",
                c2 = ss[1].Substring(3).Replace("=", "").Trim(),
                c3 = ss[2].Substring(3).Replace("=", "").Trim(),
                c4 = ss[3].Substring(3).Replace("=", "").Trim(),
                c5 = ss[4].Substring(3).Replace("=", "").Trim(),
                c6 = ss[5].Substring(3).Replace("=", "").Replace("}", "").Trim()
            });
        }
        //西药显示全部
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            lvwSelect2.Items.Clear();
            di = new Drug_insert_BLL().SelectAll(txtSelect2.Text);
            int i = 0;
            foreach (var d in di.Where(p => p.Dtype == "西药"))
            {
                lvwSelect2.Items.Add(new
                {
                    c1 = i + 1 + "",
                    c2 = di[i].Dname,
                    c3 = di[i].Dspec,
                    c4 = di[i].DjiXing,
                    c5 = di[i].DsellPrice,
                    c6 = di[i].Efficay
                });
                i++;
            }
        }
        //西药显示搜索药品
        private void LvwSelect2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ww();
            string str = lvwSelect2.Items[lvwSelect2.SelectedIndex].ToString();
            string[] ss = str.Split(',');
            string s = ss[1].Substring(3).Replace("=", "").Trim();
            foreach (ListViewItem ite in lvwYaofang2.Items)
            {
                if (s == ite.Content.ToString())
                {
                    var p = new Tip("已经添加了该药品 !");
                    p.ShowDialog();
                    return;
                }
            }
            lvwYaofang2.Items.Add(new
            {
                c1 = lvwYaofang2.Items.Count + 1 + "",
                c2 = ss[1].Substring(3).Replace("=", "").Trim(),
                c3 = ss[2].Substring(3).Replace("=", "").Trim(),
                c4 = ss[3].Substring(3).Replace("=", "").Trim(),
                c5 = ss[4].Substring(3).Replace("=", "").Trim(),
                c6 = ss[5].Substring(3).Replace("=", "").Replace("}", "").Trim()
            });
        }
        //西药删除
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (lvwYaofang2.SelectedItems.Count == 0)
            {
                var p = new Tip("请选中要删除的药品 !");
                p.ShowDialog();
                return;
            }
            string str = lvwYaofang2.Items[lvwYaofang2.SelectedIndex].ToString();
            string[] ss = str.Split(',');
            string s = ss[1].Substring(3).Replace("=", "").Trim();
            int deleteNo = int.Parse(s);
            lvwYaofang2.Items.RemoveAt(deleteNo - 1);
            ww();
        }
        //中药禁忌按钮
        private void BtnTaboo_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxTaboo.IsVisible == true)
                listBoxTaboo.Visibility = Visibility.Hidden;
            else
                listBoxTaboo.Visibility = Visibility.Visible;
        }
        //中药服药用法按钮
        private void BtnUsage_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxUsage.IsVisible == true)
                listBoxUsage.Visibility = Visibility.Hidden;
            else
                listBoxUsage.Visibility = Visibility.Visible;
        }
        //中药禁忌选项改变
        private void ListBoxTaboo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = listBoxTaboo.SelectedItem.ToString();
            string[] ss = s.Split(':');
            txtJinji.Text += ss[1].Trim() + "，";
            listBoxTaboo.Visibility = Visibility.Hidden;
        }
        //中药服法选项改变
        private void ListBoxUsage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = listBoxUsage.SelectedItem.ToString();
            string[] ss = s.Split(':');
            txtJinji.Text += ss[1].Trim() + "，";
            listBoxUsage.Visibility = Visibility.Hidden;
        }
        //西药药物禁忌
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (listBox3.IsVisible == true)
               listBox3.Visibility = Visibility.Hidden;
            else
                listBox3.Visibility = Visibility.Visible;
        }
        //西药服药用法
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (listBox4.IsVisible == true)
                listBox4.Visibility = Visibility.Hidden;
            else
                listBox4.Visibility = Visibility.Visible;
        }
        //西药药物禁忌选项改变
        private void ListBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = listBox3.SelectedItem.ToString();
            string[] ss = s.Split(':');
            txtJinji2.Text += ss[1].Trim() + "，";
            listBox3.Visibility = Visibility.Hidden;
        }
        //西药服法选项改变
        private void ListBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = listBox4.SelectedItem.ToString();
            string[] ss = s.Split(':');
            txtJinji2.Text += ss[1].Trim() + "，";
            listBox4.Visibility = Visibility.Hidden;
        }
        //当前挂号病人选项变化
        private void LvwGuaHaoShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvwGuaHaoShow.SelectedItems.Count > 0)
            {
                string str = lvwGuaHaoShow.Items[lvwGuaHaoShow.SelectedIndex].ToString();
                string[] ss = str.Split(',');
                txtRid.Text = ss[0].Substring(4).Replace("=", "").Trim();
                txtKId.Text = ss[1].Substring(3).Replace("=", "").Trim();
                txtIdType.Text = ss[2].Substring(3).Replace("=", "").Trim();
                txtGuaDanFei.Text = ss[3].Substring(3).Replace("=", "").Trim();
                txtOtherFei.Text = ss[4].Substring(3).Replace("=", "").Trim();
                txtSectionRoom.Text = ss[5].Substring(3).Replace("=", "").Trim();
                txtDoctor.Text = ss[6].Substring(3).Replace("=", "").Trim();
                dtpRegisterTime.Text = ss[7].Substring(3).Replace("=", "").Trim();
                dtpSeeDoctorTime.Text = ss[8].Substring(3).Replace("=", "").Replace("}", "").Trim();

                List<IdCard> Lic = new Prescribe_BLL().SelectAll(int.Parse(txtKId.Text));
                txtName.Text = Lic[0].Name;
                txtSex.Text = Lic[0].Sex;
                txtAge.Text = Lic[0].Age + "";
                txtAddress.Text = Lic[0].Address;
            }
        }
        //病历提交
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            List<Control> tb_list = new List<Control>()
            {
                txtZhushu,
                txtJiwangshi,
                txtGerenshi,
                txtTijian,
                txtJianyi,
                txtJiatingshi,
                txtGuominshi,
                txtXianbingshi,
                txtFuzhu
            };
            if (txtKId.Text == "" || txtRid.Text == "")
            {
                MessageBox.Show("请先选择挂号单 !");
                return;
            }
            foreach (Control item in tb_list)
            {
                if (item is TextBox)
                    if (((TextBox)item).Text == "")
                    {
                        MessageBox.Show("请把病历填写完整 !");
                        return;
                    }
            }
            Bingli Bl = new Bingli
            {
                kId = int.Parse(txtKId.Text),
                Rid = txtRid.Text,
                bing = txtZhenduan.Text,
                zhusu = txtZhushu.Text,
                xianbingshi = txtXianbingshi.Text,
                jiwangbingshi = txtJiwangshi.Text,
                guominshi = txtGuominshi.Text,
                geirenshi = txtGerenshi.Text,
                jiatingshi = txtJiatingshi.Text,
                tijian = txtTijian.Text,
                fuzhu = txtFuzhu.Text,
                zhiliaojianyi = txtJianyi.Text
            };
            string mes = new Prescribe_BLL().Bingli_Insert(Bl);
            MessageBox.Show(mes);
        }
        //中药提交
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtKId.Text == "" || txtRid.Text == "")
            {
                var t1 = new Tip("请先选择挂号单 !");
                t1.ShowDialog();
                return;
            }
            if (txtYizhu.Text == "" || txtJinji.Text == "")
            {
                var t2 = new Tip("请把药方填写完整 !");
                t2.ShowDialog();
                return;
            }
            string ypName = "";
            if (lvwYaofang.SelectedItems.Count > 0)
            {
                string str = lvwYaofang.Items[lvwYaofang.SelectedIndex].ToString();
                string[] ss = str.Split(',');
                //foreach (ListViewItem item in lvwYaofang.Items)
                //{
                //    ypName += ss[1].Substring(3).Replace("=", "").Trim() + "-";
                //}

                Kaiyao ky = new Kaiyao
                {
                    Rid = txtRid.Text,
                    Kid = int.Parse(txtKId.Text),
                    yaopinName = ypName,
                    zhuangtai = "no",
                    yizhu = txtYizhu.Text,
                    yongfa = txtJinji.Text
                };
                if (lvwGuaHaoShow.SelectedItems.Count > 0)
                {
                    lvwGuaHaoShow.Items.RemoveAt(lvwGuaHaoShow.SelectedIndex);
                }
                string mes = new Prescribe_BLL().kaiyao_Insert(ky);
                //MessageBox.Show(mes);
                var t = new Tip("提交成功！");
                t.ShowDialog();
                
            }
        }
        //中药删除
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvwYaofang.SelectedItems.Count == 0)
            {
                var p = new Tip("请选中要删除的药品 !");
                p.ShowDialog();
                return;
            }
            if (lvwYaofang.SelectedItems.Count > 0)
            {
                string str = lvwYaofang.Items[lvwYaofang.SelectedIndex].ToString();
                string[] ss = str.Split(',');
                string s = ss[1].Substring(3).Replace("=", "").Trim();
                int deleteNo = int.Parse(s);
                lvwYaofang.Items.RemoveAt(deleteNo - 1);
                yy();
            }
        }
       //导入病例点击事件
        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            var t = new Tip("导入病例成功！");
            t.ShowDialog();
        }

        //清空病例点击事件
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtZhushu.Text = "";
            txtJiwangshi.Text = "";
            txtGerenshi.Text = "";
            txtTijian.Text = "";
            txtJianyi.Text = "";
            txtXianbingshi.Text = "";
            txtJiatingshi.Text = "";
            txtGuominshi.Text = "";
            txtFuzhu.Text = "";
        }


    }
}
