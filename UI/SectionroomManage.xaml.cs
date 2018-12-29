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
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// SectionroomManage.xaml 的交互逻辑
    /// </summary>
    public partial class SectionroomManage : Window
    {
        List<SectionRoom> se;
        List<SectionRoomSo> sw;

        public SectionroomManage()
        {
            InitializeComponent();
            Loaded += (s, e)=>
            {
                SectionroomManage_Load(s, e);
            };
        }

        //TreeView加载
        List<TreeViewItem> node_list = new List<TreeViewItem>();
        private void SectionroomManage_Load(object sender, EventArgs e)
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
            cboSectionRoom.ItemsSource = se;
        }
        //TreeView的结点选项变化
        private void TreeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            foreach (SectionRoom item in se)
            {
                foreach (TreeViewItem node in node_list)
                {
                    if (node.Header.ToString() == item.Sname && node.IsSelected == true)
                    {
                        txtSaddr.Text = item.Saddr;
                        txtSprice.Text = item.Sprice + "";
                        txtSname.Text = item.Sname;
                    }
                }
            }
            foreach (SectionRoomSo item in sw)
            {
                if (treeView1.SelectedItem != null)
                {
                    if (treeView1.SelectedItem.ToString() == item.SonSname)
                    {
                        txtSonName.Text = item.SonSname;
                        cboSectionRoom.Text = item.Sname;
                    }
                }
            }
        }
        //添加科别
        private void BtnSecAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSaddr.Text == "" && txtSname.Text == "" && txtSprice.Text == "")
                return;
            SectionRoom s = new SectionRoom();
            s.Sname = txtSname.Text;
            s.Saddr = txtSaddr.Text;
            s.Sprice = int.Parse(txtSprice.Text);
            string result = new SectionRoomBLL().Chuan(s);
            if (result == 1 + "")
                se.Add(s);
            else
                MessageBox.Show(result);
            SectionroomManage_Load(null, null);
        }
        //添加病例
        private void BtnCaseAdd_Click(object sender, RoutedEventArgs e)
        {
            SectionRoomSo w = new SectionRoomSo();
            w.Sname = cboSectionRoom.Text;
            w.SonSname = txtSonName.Text;
            string str = new SectionRoomSonBLL().Son(w);
            if (str == "")
            {
                sw.Add(w);
            }
            else
                MessageBox.Show(str);
            SectionroomManage_Load(null, null);
        }
        //清空当前科别输入框信息
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtSaddr.Text = "";
            txtSprice.Text = "";
            txtSname.Text = "";
        }
        //修改科室
        private void BtnReviseSec_Click(object sender, RoutedEventArgs e)
        {
            var w = new SectionroomRevise();
            w.ShowDialog();
        }
        //删除当前病例
        private void BtnCaseDel_Click(object sender, RoutedEventArgs e)
        {
            SectionRoomSo s = new SectionRoomSo();
            foreach (SectionRoomSo item in sw)
            {
                if (treeView1.SelectedItem.ToString() == item.SonSname)
                {
                    s.SonSname = item.SonSname;
                    foreach (TreeViewItem node in node_list)
                    {
                        foreach (SectionRoomSo it in sw)
                        {
                            if (it.Sname == item.Sname)
                            {
                                node.Items.Remove(it.SonSname);
                            }
                        }
                    }
                    sw.Remove(item);
                    txtSonName.Text = "";
                    new SectionRoomSonBLL().SonDelet(s);
                    SectionroomManage_Load(null, null);
                    return;
                }
            }
        }
        //点击取消，退出当前窗口
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
