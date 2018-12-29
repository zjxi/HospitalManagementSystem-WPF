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
    /// SystemManagement.xaml 的交互逻辑
    /// </summary>
    public partial class SystemManagement : Page
    {
        public SystemManagement()
        {
            InitializeComponent();
        }

        //按钮点击事件
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string name = btn.Name.ToString();
            switch (name)
            {
                case "btn1": //挂号单设置
                    Window g = new ListSettings("挂号单");
                    g.Title = "挂号单设计";
                    g.ShowDialog();
                    break;

                case "btn2": //门诊单设置
                    Window m = new ListSettings("门诊单");
                    m.Title = "门诊单设计";
                    m.ShowDialog();
                    break;
                case "btn3": //住院单设置
                    Window z = new ListSettings("住院单");
                    z.Title = "住院单设计";
                    z.ShowDialog();
                    break;

                case "btn4": //数据库备份
                    var db1 = new Tip("数据库备份成功！");
                    db1.ShowDialog();
                    break;

                case "btn5": //科室管理
                    var sec = new SectionroomManage();
                    sec.ShowDialog();
                    break;

                case "btn6": //权限管理
                    Window a = new Authority();
                    a.ShowDialog();
                    break;

                case "btn7": //员工添加
                    StaffAddition sa = new StaffAddition();
                    sa.ShowDialog();
                    break;

                case "btn8": //数据恢复
                    var db2 = new Tip("数据恢复正常！");
                    db2.ShowDialog();
                    break;

            }
        }



    }
}
