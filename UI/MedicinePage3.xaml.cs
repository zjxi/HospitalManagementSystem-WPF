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
    /// MedicinePage3.xaml 的交互逻辑
    /// </summary>
    public partial class MedicinePage3 : Page
    {
        public MedicinePage3()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                Init_Load();
            };
        }

        private void Init_Load()
        {
            try
            {
                lvwShow.Items.Clear();
                List<Drug_insert> di = new Drug_insert_BLL().SelectAll(txtDname.Text);
                for (int i = 0; i < di.Count; i++)
                {
                    lvwShow.Items.Add(new
                    {
                        drugname = di[i].Dname,
                        type = di[i].Dtype,
                        fare = di[i].DcostName,
                        dosetype = di[i].Dspec,
                        spec = di[i].DjiXing,
                        in_price = di[i].DinsertPrice,
                        sell_price = di[i].DsellPrice,
                        stock = di[i].Dstock,
                        stockMax = di[i].DstockMax,
                        stockMin = di[i].DstockMin,
                        proDate = di[i].DeffectTime,
                        effDate = di[i].DproductTime,
                        effect = di[i].Efficay
                    });
                }
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string s = btn.Content.ToString();
            switch (s)
            {
                case "查找":
                    if (txtDname.Text == "")
                    {
                        var t1 = new Tip("请输入药品名字！");
                        t1.ShowDialog();
                        return;
                    }
                    lvwShow.Items.Clear();
                    List<Drug_insert> di = new Drug_insert_BLL().SelectAll(txtDname.Text);
                    if (di.Count == 0)
                    {
                        var t2 = new Tip("没有你要查找的数据！");
                        t2.ShowDialog();
                        return;
                    }
                    lvwShow.Items.Clear();
                    for (int i = 0; i < di.Count; i++)
                    {
                        lvwShow.Items.Add(new
                        {
                            drugname = di[i].Dname,
                            type = di[i].Dtype,
                            fare = di[i].DcostName,
                            dosetype = di[i].Dspec,
                            spec = di[i].DjiXing,
                            in_price = di[i].DinsertPrice,
                            sell_price = di[i].DsellPrice,
                            stock = di[i].Dstock,
                            stockMax = di[i].DstockMax,
                            stockMin = di[i].DstockMin,
                            proDate = di[i].DeffectTime,
                            effDate = di[i].DproductTime,
                            effect = di[i].Efficay
                        });
                    }
                    break;

                case "药品出库":
                    if (txtDname.Text == "" && lvwShow.SelectedItems.Count == 0)
                    {
                        var t1 = new Tip("请选择需要删除的数据 !");
                        t1.ShowDialog();
                        return;
                    }
                    Drug_insert Ddelete = new Drug_insert();
                    Ddelete.Dname = txtDname.Text;
                    string mes = new Drug_insert_BLL().Delete(Ddelete);
                    lvwShow.Items.RemoveAt(lvwShow.SelectedIndex);
                    txtDname.Text = "";
                    Init_Load();
                    var p = new Tip(mes);
                    p.ShowDialog();
                    break;

                case "清除":
                    txtDname.Text = "";
                    break;
            }
        }

        private void LvwShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvwShow.SelectedItems.Count > 0)
            {
                string s = lvwShow.Items[lvwShow.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                txtDname.Text = ss[0].Substring(10).Replace("=", "").Trim();
            }
        }
    }
}
