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
    /// HospitalManage_settlement.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalManage_settlement : Page
    {
        public HospitalManage_settlement()
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

            zhu = new IdCard_BLL().p_zhuyuan_Select();
            foreach (zhuyuan z in zhu)
            {
                listView1.Items.Add(new
                {
                    c1= z.kId,
                    c2 = z.Kname,
                    c3 = se[z.Sid].Sname,
                    c4 = z.Idsickroom,
                    c5 = z.BedNo,
                    c6= z.Imprest,
                    c7 = z.Bewrite,
                    c8 = z.Tabu,
                    c9 = z.Ztime
                });
            }
        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int date = 0;

            listView2.Items.Clear();
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                txtId.Text = ss[0].Substring(4).Replace("=", "").Trim();
                textBox4.Text = ss[3].Substring(3).Replace("=", "").Trim();
                textBox4.Tag = ss[4].Substring(4).Replace("=", "").Replace("}","").Trim();
                txtkeshi.Text = ss[2].Substring(3).Replace("=", "").Trim();
                dpTime1.Text = ss[8].Substring(3).Replace("=", "").Replace("}", "").Trim();
                txtmingzi.Text = ss[1].Substring(3).Replace("=", "").Trim();
                txtyujiao.Text = ss[5].Substring(3).Replace("=", "").Trim();
                //计算两个日期间隔的天数
                //DateTime st = Convert.ToDateTime(dpTime1.Text);
                //DateTime et = Convert.ToDateTime(dpTime2.Text);
                //TimeSpan span = et - st;
                //date = span.Days;
            }
            List<Sickroom> ssic = new IdCard_BLL().sickroom_select();
            foreach (Sickroom item in ssic.Where(p => p.Idsickroom == int.Parse(textBox4.Text)))
            {
                txtyiyong.Text = item.Price * (date + 1) + "";
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
            int num = 0;
            foreach (ListViewItem item in listView2.Items)
            {
                string s = listView2.Items[listView2.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                num += int.Parse(ss[6].Substring(3).Replace("=","").Trim());
            }
            textBox3.Text = num + "";
            textBox2.Text = int.Parse(txtyiyong.Text) + int.Parse(textBox3.Text) - int.Parse(txtyujiao.Text) + "";
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox5.Text == "")
            {
                return;
            }
            if (int.Parse(textBox5.Text) - int.Parse(textBox2.Text) >= 0)
            {
                new IdCard_BLL().p_zhuyuanzhuyuanxiaofei_deleted(txtId.Text);
                zhuayuantongji zhu = new zhuayuantongji
                {
                    Kid = (txtId.Text),
                    Sname = txtkeshi.Text,
                    time = DateTime.Now + "",
                    ymoney = int.Parse(textBox3.Text),
                    zmoney = int.Parse(txtyiyong.Text)
                };
                new IdCard_BLL().p_zhuayuantongji_select(zhu);
                //new IdCard_BLL().p_bed_update(int.Parse(textBox4.Text), int.Parse(textBox4.Tag+""));
                var p = new Tip("出院成功！祝您身体健康！");
                p.ShowDialog();
                Init_Load();

                List<Control> conList = new List<Control>()
                {
                    txtId,
                    txtkeshi,
                    txtmingzi,
                    txtyiyong,
                    txtyujiao,
                    textBox2,
                    textBox3,
                    textBox4,
                    textBox5,
                    dpTime1,
                    dpTime2,
                    textBox1,
                    txtName
                }; 
                foreach (Control item in conList)
                {
                    if (item is TextBox)
                    {
                        ((TextBox)item).Text = "";
                    }
                    if (item is DatePicker)
                    {
                        ((DatePicker)item).Text = "";
                    }

                }
                listView2.Items.Clear();
            }
        }


    }
}
