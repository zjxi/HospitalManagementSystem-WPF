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
    /// HospitalManage_sickroomAdd.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalManage_sickroomAdd : Page
    {
        public HospitalManage_sickroomAdd()
        {
            InitializeComponent();
            Loaded += (s, e) =>
              {
                  Init_Load(s, e);
              };
        }
        //初始加载
        private void Init_Load(object sender, RoutedEventArgs e)
        {
            List<SectionRoom> se = new UsersBLL().Section();
            cboKeshi.ItemsSource = se;
        } 
        //确定
        private void BtnYes_Click(object sender, RoutedEventArgs e)
        {
            List<Control> con_list = new List<Control>
            {
                txtnum,
                txtBFnum,
                txtPrice,
                txtlou1,
                txtlou2,
                txtfang1,
                txtfang2,
                cboKeshi,
                cboType
            };
            foreach (Control item in con_list)
            {
                if (checkBox1.IsChecked == true)
                {
                    if (item is TextBox)
                    {
                        if (((TextBox)item).Text == ""  && item.Name != "txtnum")
                        {
                            Tip t1 = new Tip("请输入完整！");
                            t1.ShowDialog();
                            return;
                        }
                    }
                    else
                    {
                        if (((ComboBox)item).Text == "" && item.Name != "txtnum")
                        {
                            Tip frmPrompting = new Tip("请输入完整！");
                            frmPrompting.ShowDialog();
                            return;
                        }
                    }
                }
                else
                {
                    if (item.Name == "txtlou1" || item.Name == "txtlou2" || item.Name == "txtfang1" || item.Name == "txtfang2")
                        break;
                    if(item is TextBox)
                    {
                        if (((TextBox)item).Text == "" )
                        {
                            Tip t1 = new Tip("请输入完整！");
                            t1.ShowDialog();
                            return;
                        }
                    }
                    if (item is ComboBox)
                    {
                        if (((ComboBox)item).Text == "")
                        {
                            Tip t2 = new Tip("请输入完整！");
                            t2.ShowDialog();
                            return;
                        }
                    }
                }
            }

            List<Sickroom> sics = new List<Sickroom>();//要添加的病房放到sics集合中
            if (checkBox1.IsChecked == true)
            {
                for (int i = int.Parse(txtlou1.Text); i <= int.Parse(txtlou2.Text); i++)
                {
                    for (int j = int.Parse(txtfang1.Text); j <= int.Parse(txtfang2.Text); j++)
                    {
                        Sickroom sic = new Sickroom();
                        if (j > 9)
                            sic.Idsickroom = int.Parse("" + i + j);
                        else
                            sic.Idsickroom = int.Parse("" + i + 0 + j);
                        sic.Sid = cboKeshi.SelectedIndex;
                        sic.Tyep = cboType.Text;
                        sic.Price = int.Parse(txtPrice.Text);
                        sics.Add(sic);
                    }
                }
            }
            else
            {
                Sickroom sic = new Sickroom
                {
                    Idsickroom = int.Parse(txtnum.Text),
                    Sid = cboKeshi.SelectedIndex,
                    Tyep = cboType.Text,
                    Price = int.Parse(txtPrice.Text)
                };
                sics.Add(sic);
            }
            int num = int.Parse(txtBFnum.Text); //获取病床数
            string str = new IdCard_BLL().sickroom(sics, num); //添加相应数量的病床
            Tip t = new Tip(str);
            t.ShowDialog();
        }
        //清空
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
              txtnum.Text = "";
            txtBFnum.Text = "";
            txtPrice.Text = "";
             txtlou1.Text = "";
             txtlou2.Text = "";
            txtfang1.Text = "";
            txtfang2.Text = "";
            cboKeshi.Text = "";
             cboType.Text = "";
            checkBox1.IsChecked = false;
        }
        //复选框选中
        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            txtnum.IsEnabled = false;
            txtlou1.IsEnabled = true;
            txtlou2.IsEnabled = true;
            txtfang1.IsEnabled = true;
            txtfang2.IsEnabled = true;
        }
        //复选框未选中
        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
              txtnum.IsEnabled = true;
             txtlou1.IsEnabled = false;
             txtlou2.IsEnabled = false;
            txtfang1.IsEnabled = false;
            txtfang2.IsEnabled = false;
        }
    }
}
