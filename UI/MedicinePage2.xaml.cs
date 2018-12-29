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
    /// MedicinePage2.xaml 的交互逻辑
    /// </summary>
    public partial class MedicinePage2 : Page
    {
        public MedicinePage2()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                Init_Load();
            };
        }

        private void Init_Load()
        {
            Button5_Click(null, null);
        }

        List<Drug_insert> dd = new Drug_insert_BLL().SelectAll("");

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            lvwShow.Items.Clear();
            if (dd.Where(p => p.Dtype == cboDtype.Text).Count() == 0)
            {
                var p = new Tip("没有你要查找的数据！");
                p.ShowDialog();
                return;

            }
            foreach (var d in dd.Where(p => p.Dtype == cboDtype.Text))
            {
                #region 列表添加项
                lvwShow.Items.Add(new
                {
                    c1 = d.Dname,
                    c2 = d.Dtype,
                    c3 = d.DcostName,
                    c4 = d.Dspec,
                    c5 = d.DjiXing,
                    c6 = d.DinsertPrice,
                    c7 = d.DsellPrice,
                    c8 = d.Dstock,
                    c9 = d.DstockMax,
                    c10 = d.DstockMin,
                    c11 = d.DeffectTime,
                    c12 = d.DproductTime,
                    c13 = d.Efficay
                });
                #endregion
            }
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (txtDsellPrice.Text == "")
            {
                var p = new Tip("请输入价钱!");
                p.ShowDialog();
                return;
            }
            lvwShow.Items.Clear();
            try
            {
                if (dd.Where(p => p.DsellPrice == int.Parse(txtDsellPrice.Text)).Count() == 0)
                {
                    var p = new Tip("没有数据!");
                    p.ShowDialog();


                }
                foreach (var d in dd.Where(p => p.DsellPrice == int.Parse(txtDsellPrice.Text)))
                {
                    #region 列表添加项
                    lvwShow.Items.Add(new
                    {
                        c1 = d.Dname,
                        c2 = d.Dtype,
                        c3 = d.DcostName,
                        c4 = d.Dspec,
                        c5 = d.DjiXing,
                        c6 = d.DinsertPrice,
                        c7 = d.DsellPrice,
                        c8 = d.Dstock,
                        c9 = d.DstockMax,
                        c10 = d.DstockMin,
                        c11 = d.DeffectTime,
                        c12 = d.DproductTime,
                        c13 = d.Efficay
                    });
                    #endregion
                }
            }
            catch
            {

                var p = new Tip("请输入正确价钱!");
                p.ShowDialog();

            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            lvwShow.Items.Clear();
            if ((dd.Where(p => p.DjiXing == cboDjiXing.Text).Count() == 0))
            {
                var p = new Tip("没有你要查找的数据！");
                p.ShowDialog();
                return;
            }
            foreach (var d in dd.Where(p => p.DjiXing == cboDjiXing.Text))
            {
                #region 列表添加项
                lvwShow.Items.Add(new
                {
                    c1 = d.Dname,
                    c2 = d.Dtype,
                    c3 = d.DcostName,
                    c4 = d.Dspec,
                    c5 = d.DjiXing,
                    c6 = d.DinsertPrice,
                    c7 = d.DsellPrice,
                    c8 = d.Dstock,
                    c9 = d.DstockMax,
                    c10 = d.DstockMin,
                    c11 = d.DeffectTime,
                    c12 = d.DproductTime,
                    c13 = d.Efficay
                });
                #endregion
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            lvwShow.Items.Clear();
            foreach (var d in dd)
            {
                #region 列表添加项
                lvwShow.Items.Add(new
                {
                    c1 = d.Dname,
                    c2 = d.Dtype,
                    c3 = d.DcostName,
                    c4 = d.Dspec,
                    c5 = d.DjiXing,
                    c6 = d.DinsertPrice,
                    c7 = d.DsellPrice,
                    c8 = d.Dstock,
                    c9 = d.DstockMax,
                    c10 = d.DstockMin,
                    c11 = d.DeffectTime,
                    c12 = d.DproductTime,
                    c13 = d.Efficay
                });
                #endregion
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (txtDinsertPrice.Text == "")
            {
                var p = new Tip("请输入价钱!");
                p.ShowDialog();
                return;
            }
            lvwShow.Items.Clear();
            try
            {
                if (dd.Where(p => p.DinsertPrice == int.Parse(txtDinsertPrice.Text)).Count() == 0)
                {
                    var p = new Tip("没有数据!");
                    p.ShowDialog();
                    return;

                }
                foreach (var d in dd.Where(p => p.DinsertPrice == int.Parse(txtDinsertPrice.Text)))
                {
                    #region 列表添加项
                    lvwShow.Items.Add(new
                    {
                        c1 = d.Dname,
                        c2 = d.Dtype,
                        c3 = d.DcostName,
                        c4 = d.Dspec,
                        c5 = d.DjiXing,
                        c6 = d.DinsertPrice,
                        c7 = d.DsellPrice,
                        c8 = d.Dstock,
                        c9 = d.DstockMax,
                        c10 = d.DstockMin,
                        c11 = d.DeffectTime,
                        c12 = d.DproductTime,
                        c13 = d.Efficay
                    });
                    #endregion
                }
            }
            catch
            {
                var p = new Tip("请输入正确价钱!");
                p.ShowDialog();
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
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
                #region 列表添加项
                lvwShow.Items.Add(new
                {
                    c1 =  di[i].Dname,
                    c2 =  di[i].Dtype,
                    c3 =  di[i].DcostName,
                    c4 =  di[i].Dspec,
                    c5 =  di[i].DjiXing,
                    c6 =  di[i].DinsertPrice,
                    c7 =  di[i].DsellPrice,
                    c8 =  di[i].Dstock,
                    c9 =  di[i].DstockMax,
                    c10 = di[i].DstockMin,
                    c11 = di[i].DeffectTime,
                    c12 = di[i].DproductTime,
                    c13 = di[i].Efficay
                });
                #endregion
            }
        }

        private void LvwShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
