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
    /// HospitalManage_register.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalManage_register : Page
    {
        public HospitalManage_register()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                Init_Load();
            };
        }

        List<Sickroom> ssic = new IdCard_BLL().sickroom_select();
        List<SectionRoom> se = new UsersBLL().Section();
        private void Init_Load()
        {
            cboKebie.ItemsSource = se;
        }

        private void BtnSure_Click(object sender, RoutedEventArgs e)
        {
            List<Control> con_list = new List<Control>()
            {
                txtjinji,
                txtKId,
                txtmiaoshu,
                txtyujiaofei,
                cbobingchuang,
                cbobingfang,
                cboKebie
            };

            foreach (Control item in con_list)
            {
                if (item is TextBox )
                {
                    if (((TextBox)item).Text == "")
                    {
                        var t = new Tip("请把信息填完整！");
                        t.ShowDialog();
                        return;
                    }
                }else
                {
                    if (((ComboBox)item).Text == "")
                    {
                        var t = new Tip("请把信息填完整！");
                        t.ShowDialog();
                        return;
                    }
                }

            }
            zhuyuan zhu = new zhuyuan
            {
                kId = int.Parse(txtKId.Text),
                Idsickroom = int.Parse(cbobingfang.Text),
                Sid = cboKebie.SelectedIndex,
                BedNo = cbobingchuang.Text,
                Imprest = int.Parse(txtyujiaofei.Text),
                Bewrite = txtmiaoshu.Text,
                Tabu = txtjinji.Text,
                Ztime = DateTime.Now + ""
            };
            string str = new IdCard_BLL().p_zhuyuan_insert(zhu);
            var p = new Tip(str);
            p.ShowDialog();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtjinji.Text = "";
            txtKId.Text = "";
            txtmiaoshu.Text = "";
            txtyujiaofei.Text = "";
            cbobingchuang.Text = "";
            cbobingfang.Text = "";
            cboKebie.Text = "";
        }
        //下拉框选中项改变
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = e.Source as ComboBox;
            string txt = cb.Tag.ToString();
            switch (txt)
            {
                case "科别":
                    txtyujiaofei.Text = "";
                    foreach (var item in ssic.Where(p => p.Sid == cboKebie.SelectedIndex))
                    {
                        cbobingfang.Items.Add(item.Idsickroom);
                    }
                    break;

                case "病房号":
                    txtyujiaofei.Text = "";
                    List<Bed> Bed = new IdCard_BLL().Bed_select();
                    if (cbobingfang.Text != "")
                    {
                        foreach (var item in Bed.Where(p => p.Idsickroom == int.Parse(cbobingfang.Text)))
                        {
                            if (item.State == "空")
                                cbobingchuang.Items.Add(item.Idbed);
                        }
                    }
                    break;

                case "病床号":
                    foreach (var item in ssic.Where(p => p.Idsickroom == int.Parse(cbobingfang.Text)))
                    {
                        txtyujiaofei.Text = item.Price + "";
                    }
                    break;
            }


        }
    }
}
