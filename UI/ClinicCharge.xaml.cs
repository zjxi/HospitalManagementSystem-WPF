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
using System.Windows.Threading;

namespace UI
{
    /// <summary>
    /// ClinicCharge.xaml 的交互逻辑
    /// </summary>
    public partial class ClinicCharge : Page
    {
        string s = "";
        string tmp = "";
        public ClinicCharge(string str)
        {
            InitializeComponent();
            tmp = str;
            Init_Load();
        }

        List<Maidan> maidan;
        List<SectionRoom> se;

        private void Init_Load()
        {
            se = new UsersBLL().Section();
            foreach (var item in se)
            {
                cboroom.Items.Add(item.Sname);
            }

            Load();

            List<Control> con_list = new List<Control>
            {
                txtRid,
                txtdoct,
                txtname,
                txtidno,
                textBox4,
                textBox5,
                textBox6,
                cboroom,
                cbosex
            };
            s = new IdCard_BLL().p_peodom_select(tmp + "");
            string[] ss = s.Split('-');
            foreach (Control item in con_list)
            {
                foreach (string ite in ss)
                {
                    if (item is TextBox)
                    {
                        if (((TextBox)item).Text == ite)
                        {
                            item.IsEnabled = true;
                        }
                    }
                    if (item is ComboBox)
                    {
                        if (((ComboBox)item).Text == ite)
                        {
                            item.IsEnabled = true;
                        }
                    }
                }
            }
        }
        private void Load()
        {
            maidan = new IdCard_BLL().p_kaiyao_select();
            foreach (Maidan item in maidan)
            {
                if (item.zhuangtai == "no")
                {
                    listView1.Items.Add(new
                    {
                        c1 = item.Rid,
                        c2 = item.Name,
                        c3 = item.Sex,
                        c4 = item.SectionRoom,
                        c5 = item.IdcardNo
                    });
                }
            }
        }
        //门诊结账按钮
        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            if (txtRid.Text == "")
            {
                Tip pf = new Tip("没有要结账病人信息！");
                pf.ShowDialog();
                return;
            }
            if (textBox6.Text == "")
            {
                Tip pm = new Tip("付款金额不足！");
                pm.ShowDialog();
                return;
            }
            if (int.Parse(textBox6.Text) < 0)
            {
                Tip pm = new Tip("付款金额不足！");
                pm.ShowDialog();
                return;
            }
            Tip2 p = new Tip2("确定结账？", this);
            p.ShowDialog();
            if (this.Tag.ToString() == "OK")
            {
                new IdCard_BLL().p_kaiyao_update(txtRid.Text);
                Tip pp = new Tip("结账成功!请到药房取药!");
                pp.ShowDialog();

                zhuayuantongji zhu = new zhuayuantongji();
                zhu.Kid = (txtRid.Text);
                zhu.Sname = cboroom.Text;
                zhu.time = DateTime.Now + "";
                zhu.ymoney = int.Parse(textBox4.Text);
                zhu.zmoney = 0;
                new IdCard_BLL().p_zhuayuantongji_select(zhu);
                Init_Load();

                List<Control> con_list = new List<Control>
            {
                txtRid,
                txtdoct,
                txtname,
                txtidno,
                textBox4,
                textBox5,
                textBox6,
                cboroom,
                cbosex
            };

                foreach (Control item in con_list )
                {
                    if (item is TextBox )
                    {
                        ((TextBox)item).Text = "";
                    }
                    if (item is ComboBox)
                    {
                        ((ComboBox)item).Text = "";
                    }
                }
                listView2.Items.Clear();
            }
        }
        //支付金额输入框改变
        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textBox5.Text == "")
                {
                    textBox6.Text = "";
                    return;
                }
                textBox6.Text = int.Parse(textBox5.Text) - int.Parse(textBox4.Text) + "";
            }
            catch
            {
                Tip t = new Tip("请正确输入金钱！");
                t.ShowDialog();
            }
        }
        
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string str = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = str.Split(',');
                string tmp = ss[0].Substring(4).Replace("=", "").Trim();
                string s = "";
                foreach (var item in maidan.Where(p => p.Rid == tmp))
                {
                    txtdoct.Text = item.Doctor;
                    txtidno.Text = item.IdcardNo;
                    txtname.Text = item.Name;
                    txtRid.Text = item.Rid;
                    cboroom.Text = item.SectionRoom;
                    cbosex.Text = item.Sex;
                    s = item.yaopinName;
                    break;
                }
                string[] arr = s.Split('-');
                listView2.Items.Clear();
                int num = 0;
                foreach (string ite in arr)
                {
                    if (ite != "")
                    {
                        List<Drug_insert> di = new Drug_insert_BLL().SelectAll(ite);
                        for (int i = 0; i < di.Count; i++)
                        {
                            listView2.Items.Add(new
                            {
                                c1 = di[i].Dname,
                                c2= di[i].DsellPrice,
                                c3 = 1
                            });
                            num += int.Parse(di[i].DsellPrice + "") * 1;
                        }
                    }
                }
                textBox4.Text = num + "";
            }
        }
        //查找按钮
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
        //取消按钮
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
