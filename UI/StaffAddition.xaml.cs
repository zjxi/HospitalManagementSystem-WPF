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
    /// StaffAddition.xaml 的交互逻辑
    /// </summary>
    public partial class StaffAddition : Window
    {
        public StaffAddition()
        {
            InitializeComponent();
            Loaded += delegate
            {
                Init_Load();
            };
        }
        //初始化加载
        private void Init_Load()
        {
            List<UsersType> type = new IdCard_BLL().p_usesType_select();
            foreach (var item in type)
            {
                comboBox1.Items.Add(item.Type);
            }
            comboBox1.Items.Add("医师");
            List<SectionRoom> se = new UsersBLL().Section();
            foreach (var item in se)
            {
                comboBox2.Items.Add(item.Sname);
            }
        }
        //保存按钮事件
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

            List<TextBox> tb = new List<TextBox>
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8
            };

            foreach (TextBox item in tb) //遍历所有textbox的属性
            {
                if (comboBox1.Text != "医师" && (item.Name == "textBox8" || item.Name == "comboBox2"))
                {
                    textBox8.Text = 0 + "";
                    continue;
                }
                else if (item.Text == "")
                {
                    Tip t1= new Tip("请输入完整！");
                    t1.ShowDialog();
                    return;
                }
            }
            try
            {
                int.Parse(textBox8.Text);
            }
            catch
            {
               Tip t2 = new Tip("请正确输入挂号费！");
                t2.ShowDialog();
            }
            Users u = new Users
            {
                Uname = textBox1.Text,
                name = textBox4.Text,
                Pwd = textBox2.Text
            };
            if (radioButton1.IsChecked== true)
                u.Sex = "男";
            else
                u.Sex = "女";
            u.Address = textBox5.Text;
            u.Phone = textBox6.Text;
            u.Spell = textBox7.Text;
            u.Type = comboBox1.Text;
            u.SectionRoom = comboBox2.Text;
            u.money = int.Parse(textBox8.Text);
            u.Peodom = "";
            string s = new IdCard_BLL().p_users_insert(u);

            Tip t3 = new Tip(s);
            t3.ShowDialog();
        }
        //重置按钮事件
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> tb = new List<TextBox>
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8
            };

            foreach (TextBox txt in tb) //遍历所有text，将其清空
            {
                txt.Text = "";
            }

        }
        //选项框改变事件
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "医师")
            {
                comboBox2.IsEnabled = true;
                textBox8.IsEnabled = true;
            }
            else
            {
                comboBox2.Text = "";
                textBox8.Text = "";
                comboBox2.IsEnabled = false;
                textBox8.IsEnabled = false;
            }
        }
        //用户名输入框改变事件
        private void TextBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            ushort key = 0;
            string strResult = string.Empty;

            //创建两个不同的encoding对象
            Encoding unicode = Encoding.Unicode;
            //创建GBK码对象
            Encoding gbk = Encoding.GetEncoding(936);
            //将unicode字符串转换为字节
            byte[] unicodeBytes = unicode.GetBytes(textBox1.Text);
            //再转化为GBK码
            byte[] gbkBytes = Encoding.Convert(unicode, gbk, unicodeBytes);
            while (i < gbkBytes.Length)
            {
                //如果为数字\字母\其他ASCII符号
                if (gbkBytes[i] <= 127)
                {
                    strResult = strResult + (char)gbkBytes[i];
                    i++;
                }
                #region 否则生成汉字拼音简码,取拼音首字母
                else
                {

                    key = (ushort)(gbkBytes[i] * 256 + gbkBytes[i + 1]);
                    if (key >= '\uB0A1' && key <= '\uB0C4')
                    {
                        strResult = strResult + "A";
                    }
                    else if (key >= '\uB0C5' && key <= '\uB2C0')
                    {
                        strResult = strResult + "B";
                    }
                    else if (key >= '\uB2C1' && key <= '\uB4ED')
                    {
                        strResult = strResult + "C";
                    }
                    else if (key >= '\uB4EE' && key <= '\uB6E9')
                    {
                        strResult = strResult + "D";
                    }
                    else if (key >= '\uB6EA' && key <= '\uB7A1')
                    {
                        strResult = strResult + "E";
                    }
                    else if (key >= '\uB7A2' && key <= '\uB8C0')
                    {
                        strResult = strResult + "F";
                    }
                    else if (key >= '\uB8C1' && key <= '\uB9FD')
                    {
                        strResult = strResult + "G";
                    }
                    else if (key >= '\uB9FE' && key <= '\uBBF6')
                    {
                        strResult = strResult + "H";
                    }
                    else if (key >= '\uBBF7' && key <= '\uBFA5')
                    {
                        strResult = strResult + "J";
                    }
                    else if (key >= '\uBFA6' && key <= '\uC0AB')
                    {
                        strResult = strResult + "K";
                    }
                    else if (key >= '\uC0AC' && key <= '\uC2E7')
                    {
                        strResult = strResult + "L";
                    }
                    else if (key >= '\uC2E8' && key <= '\uC4C2')
                    {
                        strResult = strResult + "M";
                    }
                    else if (key >= '\uC4C3' && key <= '\uC5B5')
                    {
                        strResult = strResult + "N";
                    }
                    else if (key >= '\uC5B6' && key <= '\uC5BD')
                    {
                        strResult = strResult + "O";
                    }
                    else if (key >= '\uC5BE' && key <= '\uC6D9')
                    {
                        strResult = strResult + "P";
                    }
                    else if (key >= '\uC6DA' && key <= '\uC8BA')
                    {
                        strResult = strResult + "Q";
                    }
                    else if (key >= '\uC8BB' && key <= '\uC8F5')
                    {
                        strResult = strResult + "R";
                    }
                    else if (key >= '\uC8F6' && key <= '\uCBF9')
                    {
                        strResult = strResult + "S";
                    }
                    else if (key >= '\uCBFA' && key <= '\uCDD9')
                    {
                        strResult = strResult + "T";
                    }
                    else if (key >= '\uCDDA' && key <= '\uCEF3')
                    {
                        strResult = strResult + "W";
                    }
                    else if (key >= '\uCEF4' && key <= '\uD188')
                    {
                        strResult = strResult + "X";
                    }
                    else if (key >= '\uD1B9' && key <= '\uD4D0')
                    {
                        strResult = strResult + "Y";
                    }
                    else if (key >= '\uD4D1' && key <= '\uD7F9')
                    {
                        strResult = strResult + "Z";
                    }
                    else
                    {
                        strResult = strResult + "?";
                    }
                    i = i + 2;
                }
                #endregion
            }
            textBox7.Text = strResult;
        }


    }
}
