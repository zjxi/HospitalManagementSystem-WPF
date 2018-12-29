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
    /// HospitalManage_payment.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalManage_payment : Page
    {
        public HospitalManage_payment()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            List<zhuyuan> zhu = new IdCard_BLL().p_zhuyuan_Select();
            List<SectionRoom> se = new UsersBLL().Section();
            txtId2.Text = "";
            txtname2.Text = "";
            txtyujiao2.Text = "";
            List<Control> conList2 = new List<Control>() {txtId,txtkeshi,txttime,txtname,txtshengyu,txtyujiao,txtyiyong  };
            List<Control> conList3 = new List<Control>() { txtname2,txtId2,txtyujiao2};
            foreach (Control item in conList2)
            {
                if (item is TextBox)
                   ((TextBox)item).Text = "";
            }
            foreach (Control item in conList3)
            {
                item.IsEnabled = false;
            }
            try
            {
                if (textBox1.Text == "")
                {
                    var p = new Tip("请输入卡号!");
                    p.ShowDialog();
                    return;
                }
                if (zhu.Where(p => p.kId == int.Parse(textBox1.Text)).Count() == 0)
                {
                    var p = new Tip("没有数据!");
                    p.ShowDialog();
                    return;
                }
                foreach (var z in zhu.Where(p => p.kId == int.Parse(textBox1.Text)))
                {
                    txtId.Text = z.kId + "";
                    txtname.Text = z.Kname;
                    txtkeshi.Text = (se[z.Sid].Sname);
                    txttime.Text = (z.Ztime + "");
                    txtyujiao.Text = (z.Imprest + "");

                }
                List<zhuyuanxiaofei> xfs = new IdCard_BLL().p_zhuyuanxiaofei_select(int.Parse(txtId.Text));
                int i = 0;
                foreach (zhuyuanxiaofei xf in xfs)
                {
                    List<Drug_insert> di = new Drug_insert_BLL().SelectAll(xf.yaoName);
                    i = i + int.Parse(xf.yaonum + "") * int.Parse(di[0].DsellPrice + "");
                }
                txtyiyong.Text = i + "";
                txtshengyu.Text = int.Parse(txtyujiao.Text) - int.Parse(txtyiyong.Text) + "";
            }
            catch
            {
                var p = new Tip("病人编号只能是数字!");
                p.ShowDialog();
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            List<Control> conList3 = new List<Control>() { txtname2, txtId2, txtyujiao2 };
            if (txtId.Text == "")
                return;
            foreach (Control item in conList3)
            {
                item.IsEnabled = true;
            }
            txtId2.Text = txtId.Text;
            txtname2.Text = txtname.Text;

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = int.Parse(txtyujiao.Text) + int.Parse(txtyujiao2.Text);
                new IdCard_BLL().update_zhuyuan_yujiao(i, txtId2.Text);
                var p = new Tip("交款成功!");
                p.ShowDialog();
            }
            catch
            {
                var p = new Tip("请输入正确金额！");
                p.ShowDialog();
            }
        }
    }
}
