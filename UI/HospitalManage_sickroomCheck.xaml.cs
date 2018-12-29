using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.ComponentModel;
using UI.Properties;

namespace UI
{
    /// <summary>
    /// HospitalManage_sickroomCheck.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalManage_sickroomCheck : Page
    {
        public HospitalManage_sickroomCheck()
        {
            InitializeComponent();
            Loaded += (s, e)=>
            {
                Init_Load(s, e);
            };  
        }
      
        List<SectionRoom> se = new UsersBLL().Section();

        private void Init_Load(object sender, RoutedEventArgs e)
        {
            listView1.Items.Clear();
            List<Sickroom> ssic = new IdCard_BLL().sickroom_select();
            foreach (Sickroom sic in ssic)
            {
                listView1.Items.Add(new
                {
                   c2= sic.Idsickroom,
                   c3= sic.Tyep,
                   c4= se[sic.Sid],
                   c5= sic.Price
                });
            }
        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Bed> Bed = new IdCard_BLL().Bed_select();
            string str = listView1.Items[listView1.SelectedIndex].ToString();
            string[] ss = str.Split(',');
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                //判断此行是否被选中
                if (listView1.SelectedItems.Count>0)
                {
                    var result = Bed.Where(p => p.Idsickroom == int.Parse(ss[0].Substring(4).Replace("=","").Trim()));
                    listView2.Items.Clear();
                    foreach (var s in result)
                    {
                        listView2.Items.Add(new
                        {
                            c1 = s.Idsickroom,
                            c2 = s.Idbed,
                            c3 = s.KId,
                            c4 = s.State
                        });
                    }
                }
            }
        }

       

    }
}
