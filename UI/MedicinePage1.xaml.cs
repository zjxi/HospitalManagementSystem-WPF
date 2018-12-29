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
    /// MedicinePage1.xaml 的交互逻辑
    /// </summary>
    public partial class MedicinePage1 : Page
    {
        public MedicinePage1()
        {
            InitializeComponent();
            Loaded += (s, e) =>
             {
                 Init_Load();
             };
        }

        private void Init_Load()
        {
            Method();
            cboDtype.Items.Add("中药");
            cboDtype.Items.Add("西药");
            cboDspec.Items.Add("片");
            cboDspec.Items.Add("g");
            cboDspec.Items.Add("盒");
            cboDspec.Items.Add("袋");
            cboDcostName.Items.Add("西药费");
            cboDcostName.Items.Add("中药费");
            cboDjiXing.Items.Add("片剂");
            cboDjiXing.Items.Add("药丸");
            cboDjiXing.Items.Add("冲剂");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string s = btn.Content.ToString();


            switch (s)
            {
                case "清空全部":
                    txtDinsertPrice.Text = "";
                    txtDname.Text = "";
                    txtDsellPrice.Text = "";
                    txtDstock.Text = "";
                    txtDstockMax.Text = "";
                    txtDstockMin.Text = "";
                    txtEfficay.Text = "";
                    cboDcostName.Text = "";
                    cboDjiXing.Text = "";
                    cboDspec.Text = "";
                    cboDtype.Text = "";
                    dtpDeffectTime.Text = "";
                    dtpDproductTime.Text = "";
                    break;

                case "显示全部":
                    #region 列表添加显示所有药品
                    List<Drug_insert> di = new Drug_insert_BLL().SelectAll("");
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
                    #endregion
                    break;

                case "药品修改":
                    if (txtDname.Text == "")
                    {
                        Tip p = new Tip("请选择需要修改的数据 !");
                        p.ShowDialog();
                        return;
                    }
                    Drug_insert Dupdate = new Drug_insert();
                    Dupdate.Dname = txtDname.Text;
                    Dupdate.Dtype = cboDtype.Text;
                    Dupdate.DcostName = cboDcostName.Text;
                    Dupdate.Dspec = cboDspec.Text;
                    Dupdate.DjiXing = cboDjiXing.Text;
                    Dupdate.DinsertPrice = int.Parse(txtDinsertPrice.Text);
                    Dupdate.DsellPrice = int.Parse(txtDsellPrice.Text);
                    Dupdate.Dstock = int.Parse(txtDstock.Text);
                    Dupdate.DstockMax = int.Parse(txtDstockMax.Text);
                    Dupdate.DstockMin = int.Parse(txtDstockMin.Text);
                    Dupdate.DeffectTime = dtpDproductTime.Text;
                    Dupdate.DproductTime = dtpDeffectTime.Text;
                    Dupdate.Efficay = txtEfficay.Text;
                    string mes = new Drug_insert_BLL().Update(Dupdate);
                    break;

                case "药品入库":
                    Drug_Insert();
                    break;
            }
        }
        //药品入库
        private void Drug_Insert()
        {
            #region 控件列表集合
            List<Control> con_list = new List<Control>()
            {
            txtDinsertPrice,
            txtDname,
            txtDsellPrice,
            txtDstock,
            txtDstockMax,
            txtDstockMin,
            txtEfficay,
            cboDcostName,
            cboDjiXing,
            cboDspec,
            cboDtype,
            dtpDeffectTime,
            dtpDproductTime
            };
            #endregion
            foreach (Control item in con_list)
            {
                if (item is TextBox)
                    if (((TextBox)item).Text == "")
                    {
                        Tip p = new Tip("请把信息填写完整 !");
                        p.ShowDialog();
                        return;
                    }
                if (item is ComboBox)
                    if (((ComboBox)item).Text == "")
                    {
                        Tip p = new Tip("请把信息填写完整 !");
                        p.ShowDialog();

                        return;
                    }
            }
            Drug_insert Dinsert = new Drug_insert();
            Dinsert.Dname = txtDname.Text;
            Dinsert.Dtype = cboDtype.Text;
            Dinsert.DcostName = cboDcostName.Text;
            Dinsert.Dspec = cboDspec.Text;
            Dinsert.DjiXing = cboDjiXing.Text;
            Dinsert.DinsertPrice = int.Parse(txtDinsertPrice.Text);
            Dinsert.DsellPrice = int.Parse(txtDsellPrice.Text);
            Dinsert.Dstock = int.Parse(txtDstock.Text);
            Dinsert.DstockMax = int.Parse(txtDstockMax.Text);
            Dinsert.DstockMin = int.Parse(txtDstockMin.Text);
            Dinsert.DeffectTime = dtpDproductTime.Text;
            Dinsert.DproductTime = dtpDeffectTime.Text;
            Dinsert.Efficay = txtEfficay.Text;

            string mes = new Drug_insert_BLL().Insert(Dinsert);
            txtDname.Text = "";
            Method();
            Tip pp = new Tip(mes);
            pp.ShowDialog();
        }
        //药品查找
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtDname.Text == "")
            {
                var p = new Tip("请输入药品名字！");
                p.ShowDialog();
                return;
            }
            lvwShow.Items.Clear();
            List<Drug_insert> di = new Drug_insert_BLL().SelectAll(txtDname.Text);
            if (di.Count == 0)
            {

                var p = new Tip("没有你要查找的数据！");
                p.ShowDialog();
                return;
            }
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

        private void Method()
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
                    stock       = di[i].Dstock,
                    stockMax = di[i].DstockMax,
                    stockMin = di[i].DstockMin,
                    proDate = di[i].DeffectTime,
                    effDate = di[i].DproductTime,
                    effect = di[i].Efficay
                });
            }
        }

        private void LvwShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvwShow.SelectedItems.Count > 0)
            {
                string s = lvwShow.Items[lvwShow.SelectedIndex].ToString();
                string[] ss = s.Split(',');
                txtDname.Text = ss[0].Substring(10).Replace("=", "").Trim();
                cboDtype.Text = ss[1].Substring(6).Replace("=", "").Trim();
                cboDcostName.Text = ss[2].Substring(6).Replace("=", "").Trim();
                cboDspec.Text = ss[3].Substring(10).Replace("=", "").Trim();
                cboDjiXing.Text = ss[4].Substring(6).Replace("=", "").Trim();
                txtDinsertPrice.Text = ss[5].Substring(10).Replace("=", "").Trim();
                txtDsellPrice.Text = ss[6].Substring(12).Replace("=", "").Trim();
                txtDstock.Text = ss[7].Substring(7).Replace("=", "").Trim();
                txtDstockMax.Text = ss[8].Substring(10).Replace("=", "").Trim();
                txtDstockMin.Text = ss[9].Substring(10).Replace("=", "").Trim();
                dtpDeffectTime.Text = ss[10].Substring(9).Replace("=", "").Trim();
                dtpDproductTime.Text = ss[11].Substring(9).Replace("=", "").Trim();
                txtEfficay.Text = ss[12].Substring(8).Replace("=", "").Replace("}", "").Trim();
            }
        }                        
    }
}