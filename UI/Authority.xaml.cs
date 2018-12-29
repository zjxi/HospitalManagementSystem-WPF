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
using System.Reflection;
using BLL;
using Model;

namespace UI
{
    /// <summary>
    /// Authority.xaml 的交互逻辑
    /// </summary>
    public partial class Authority : Window
    {
        List<UsersType> type;
        List<Users> us;

        public Authority()
        {
            InitializeComponent();
            Loaded += (s, e)=>
            {
                Authority_Load(s, e);
            };
        }
        //初始化加载
        private void Authority_Load(object sender, RoutedEventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            type = new IdCard_BLL().p_usesType_select();
            foreach (var item in type)
            {
                listView1.Items.Add(new
                {
                    c1 = item.Type
                });
            }
            us = new IdCard_BLL().p_users_select01();
            foreach (Users q in us)
            {
                listView2.Items.Add(new
                {
                    c1 = q.Uname,
                    c2 = q.name,
                    c3 = q.Type
                });
            }
            #region 附属复选框禁用初始化
            checkBox9.IsEnabled = false;
            checkBox10.IsEnabled = false;
            checkBox11.IsEnabled = false;
            checkBox12.IsEnabled = false;
            checkBox13.IsEnabled = false;
            checkBox14.IsEnabled = false;
            checkBox15.IsEnabled = false;
            checkBox16.IsEnabled = false;
            checkBox17.IsEnabled = false;
            checkBox18.IsEnabled = false;
            checkBox19.IsEnabled = false;
            checkBox20.IsEnabled = false;
            checkBox21.IsEnabled = false;
            checkBox22.IsEnabled = false;
            checkBox23.IsEnabled = false;
            checkBox24.IsEnabled = false;
            checkBox25.IsEnabled = false;
            checkBox26.IsEnabled = false;
            checkBox27.IsEnabled = false;
            checkBox28.IsEnabled = false;
            checkBox29.IsEnabled = false;
            checkBox30.IsEnabled = false;
            checkBox31.IsEnabled = false;
            checkBox32.IsEnabled = false;
            checkBox33.IsEnabled = false;
            checkBox34.IsEnabled = false;
            checkBox35.IsEnabled = false;
            checkBox36.IsEnabled = false;
            checkBox37.IsEnabled = false;
            checkBox38.IsEnabled = false;
            checkBox39.IsEnabled = false;
            checkBox40.IsEnabled = false;
            checkBox41.IsEnabled = false;
            checkBox42.IsEnabled = false;
            checkBox43.IsEnabled = false;
            checkBox44.IsEnabled = false;
            checkBox45.IsEnabled = false;
            #endregion
        }
        //保存按钮点击事件
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            #region 所有控件的列表容器con_list
            List<Control> con_list = new List<Control>();
            con_list.Add(groupBox1);
            con_list.Add(groupBox2);
            con_list.Add(groupBox3);
            con_list.Add(groupBox4);
            con_list.Add(groupBox5);
            con_list.Add(groupBox6);
            con_list.Add(groupBox7);
            con_list.Add(groupBox8);
            con_list.Add(checkBox1);
            con_list.Add(checkBox2);
            con_list.Add(checkBox3);
            con_list.Add(checkBox4);
            con_list.Add(checkBox5);
            con_list.Add(checkBox6);
            con_list.Add(checkBox7);
            con_list.Add(checkBox8);
            con_list.Add(checkBox9);
            con_list.Add(checkBox10);
            con_list.Add(checkBox11);
            con_list.Add(checkBox12);
            con_list.Add(checkBox13);
            con_list.Add(checkBox14);
            con_list.Add(checkBox15);
            con_list.Add(checkBox16);
            con_list.Add(checkBox17);
            con_list.Add(checkBox18);
            con_list.Add(checkBox19);
            con_list.Add(checkBox20);
            con_list.Add(checkBox21);
            con_list.Add(checkBox22);
            con_list.Add(checkBox23);
            con_list.Add(checkBox24);
            con_list.Add(checkBox25);
            con_list.Add(checkBox26);
            con_list.Add(checkBox27);
            con_list.Add(checkBox28);
            con_list.Add(checkBox29);
            con_list.Add(checkBox30);
            con_list.Add(checkBox31);
            con_list.Add(checkBox32);
            con_list.Add(checkBox33);
            con_list.Add(checkBox34);
            con_list.Add(checkBox35);
            con_list.Add(checkBox36);
            con_list.Add(checkBox37);
            con_list.Add(checkBox38);
            con_list.Add(checkBox39);
            con_list.Add(checkBox40);
            con_list.Add(checkBox41);
            con_list.Add(checkBox42);
            con_list.Add(checkBox43);
            con_list.Add(checkBox44);
            con_list.Add(checkBox45);
            #endregion
            #region checkbox容器cb_list
            List<CheckBox> cb_list = new List<CheckBox>();
            cb_list.Add(checkBox1);
            cb_list.Add(checkBox2);
            cb_list.Add(checkBox3);
            cb_list.Add(checkBox4);
            cb_list.Add(checkBox5);
            cb_list.Add(checkBox6);
            cb_list.Add(checkBox7);
            cb_list.Add(checkBox8);
            cb_list.Add(checkBox9);
            cb_list.Add(checkBox10);
            cb_list.Add(checkBox11);
            cb_list.Add(checkBox12);
            cb_list.Add(checkBox13);
            cb_list.Add(checkBox14);
            cb_list.Add(checkBox15);
            cb_list.Add(checkBox16);
            cb_list.Add(checkBox17);
            cb_list.Add(checkBox18);
            cb_list.Add(checkBox19);
            cb_list.Add(checkBox20);
            cb_list.Add(checkBox21);
            cb_list.Add(checkBox22);
            cb_list.Add(checkBox23);
            cb_list.Add(checkBox24);
            cb_list.Add(checkBox25);
            cb_list.Add(checkBox26);
            cb_list.Add(checkBox27);
            cb_list.Add(checkBox28);
            cb_list.Add(checkBox29);
            cb_list.Add(checkBox30);
            cb_list.Add(checkBox31);
            cb_list.Add(checkBox32);
            cb_list.Add(checkBox33);
            cb_list.Add(checkBox34);
            cb_list.Add(checkBox35);
            cb_list.Add(checkBox36);
            cb_list.Add(checkBox37);
            cb_list.Add(checkBox38);
            cb_list.Add(checkBox39);
            cb_list.Add(checkBox40);
            cb_list.Add(checkBox41);
            cb_list.Add(checkBox42);
            cb_list.Add(checkBox43);
            cb_list.Add(checkBox44);
            cb_list.Add(checkBox45);
            #endregion
            string str = "";
            foreach (Control item in con_list)
            {
                if (item is GroupBox)
                {
                    foreach (Control ite in cb_list)
                    {
                        if (ite is CheckBox)
                        {
                            if (((CheckBox)ite).IsChecked == true)
                                str += ((CheckBox)ite).Content.ToString() + "-";
                        }
                    }
                }
            }
            if (textBox1.Text != "")
            {
                new IdCard_BLL().p_usesType_update(textBox1.Text, str);
                type = new IdCard_BLL().p_usesType_select();
                Tip t1 = new Tip("保存成功！");
                t1.ShowDialog();
                Authority_Load(null, null);
            }
            else if (textBox3.Text != "")
            {
                new IdCard_BLL().p_usersPeodom_update(textBox3.Text, str);
                type = new IdCard_BLL().p_usesType_select();
                Tip t2 = new Tip("保存成功！");
                t2.ShowDialog();
                Authority_Load(null, null);
            }
            //设置权限...
            if (textBox1.Text == "")
            {
                var p = new Tip("请输入类型!");
                p.ShowDialog();
                return;
            }
            string str1 = "";
            foreach (Control item in con_list)
            {
                if (item is GroupBox)
                {
                    foreach (Control ite in cb_list)
                    {
                        if (ite is CheckBox)
                        {
                            if (((CheckBox)ite).IsChecked == true)
                                str1 += ((CheckBox)ite).Content.ToString() + "-";
                        }
                    }
                }
            }
            string s = new IdCard_BLL().p_usersType_insert(textBox1.Text, str);
            MessageBox.Show(str);
            var pp = new Tip(str);
            pp.ShowDialog();
        }
        //权限类型列表框
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region 所有控件的列表容器con_list
            List<Control> con_list = new List<Control>();
            con_list.Add(groupBox1);
            con_list.Add(groupBox2);
            con_list.Add(groupBox3);
            con_list.Add(groupBox4);
            con_list.Add(groupBox5);
            con_list.Add(groupBox6);
            con_list.Add(groupBox7);
            con_list.Add(groupBox8);
            con_list.Add(checkBox1);
            con_list.Add(checkBox2);
            con_list.Add(checkBox3);
            con_list.Add(checkBox4);
            con_list.Add(checkBox5);
            con_list.Add(checkBox6);
            con_list.Add(checkBox7);
            con_list.Add(checkBox8);
            con_list.Add(checkBox9);
            con_list.Add(checkBox10);
            con_list.Add(checkBox11);
            con_list.Add(checkBox12);
            con_list.Add(checkBox13);
            con_list.Add(checkBox14);
            con_list.Add(checkBox15);
            con_list.Add(checkBox16);
            con_list.Add(checkBox17);
            con_list.Add(checkBox18);
            con_list.Add(checkBox19);
            con_list.Add(checkBox20);
            con_list.Add(checkBox21);
            con_list.Add(checkBox22);
            con_list.Add(checkBox23);
            con_list.Add(checkBox24);
            con_list.Add(checkBox25);
            con_list.Add(checkBox26);
            con_list.Add(checkBox27);
            con_list.Add(checkBox28);
            con_list.Add(checkBox29);
            con_list.Add(checkBox30);
            con_list.Add(checkBox31);
            con_list.Add(checkBox32);
            con_list.Add(checkBox33);
            con_list.Add(checkBox34);
            con_list.Add(checkBox35);
            con_list.Add(checkBox36);
            con_list.Add(checkBox37);
            con_list.Add(checkBox38);
            con_list.Add(checkBox39);
            con_list.Add(checkBox40);
            con_list.Add(checkBox41);
            con_list.Add(checkBox42);
            con_list.Add(checkBox43);
            con_list.Add(checkBox44);
            con_list.Add(checkBox45);
            #endregion
            #region checkbox容器cb_list
            List<CheckBox> cb_list = new List<CheckBox>();
            cb_list.Add(checkBox1);
            cb_list.Add(checkBox2);
            cb_list.Add(checkBox3);
            cb_list.Add(checkBox4);
            cb_list.Add(checkBox5);
            cb_list.Add(checkBox6);
            cb_list.Add(checkBox7);
            cb_list.Add(checkBox8);
            cb_list.Add(checkBox9);
            cb_list.Add(checkBox10);
            cb_list.Add(checkBox11);
            cb_list.Add(checkBox12);
            cb_list.Add(checkBox13);
            cb_list.Add(checkBox14);
            cb_list.Add(checkBox15);
            cb_list.Add(checkBox16);
            cb_list.Add(checkBox17);
            cb_list.Add(checkBox18);
            cb_list.Add(checkBox19);
            cb_list.Add(checkBox20);
            cb_list.Add(checkBox21);
            cb_list.Add(checkBox22);
            cb_list.Add(checkBox23);
            cb_list.Add(checkBox24);
            cb_list.Add(checkBox25);
            cb_list.Add(checkBox26);
            cb_list.Add(checkBox27);
            cb_list.Add(checkBox28);
            cb_list.Add(checkBox29);
            cb_list.Add(checkBox30);
            cb_list.Add(checkBox31);
            cb_list.Add(checkBox32);
            cb_list.Add(checkBox33);
            cb_list.Add(checkBox34);
            cb_list.Add(checkBox35);
            cb_list.Add(checkBox36);
            cb_list.Add(checkBox37);
            cb_list.Add(checkBox38);
            cb_list.Add(checkBox39);
            cb_list.Add(checkBox40);
            cb_list.Add(checkBox41);
            cb_list.Add(checkBox42);
            cb_list.Add(checkBox43);
            cb_list.Add(checkBox44);
            cb_list.Add(checkBox45);
            #endregion
            foreach (Control item in con_list)
            {
                if (item is GroupBox)
                {
                    foreach (Control ite in cb_list)
                    {
                        if (ite is CheckBox)
                        {
                            ((CheckBox)ite).IsChecked = false;
                        }
                    }
                }
            }
            if (listView1.SelectedItems.Count > 0)
            {
                string str = listView1.Items[listView1.SelectedIndex].ToString();
                string[] ss = str.Split(',');
                textBox1.Text = ss[0].Substring(4).Replace("=", "").Replace("}", "").Trim();
                textBox2.Text = "";
                textBox3.Text = "";
                string s = type.Single(p => p.Type == textBox1.Text).Peodom;
                string[] arr = s.Split('-');
                foreach (var item in arr)
                {
                    foreach (Control cons in con_list)
                    {
                        if (cons is GroupBox)
                        {
                            foreach (Control con in cb_list)
                            {
                                if (con is CheckBox && ((CheckBox)con).Content.ToString() == item)
                                {
                                    ((CheckBox)con).IsChecked = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        //员工权限列表框
        private void listView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region 所有控件的列表容器con_list
            List<Control> con_list = new List<Control>();
            con_list.Add(groupBox1);
            con_list.Add(groupBox2);
            con_list.Add(groupBox3);
            con_list.Add(groupBox4);
            con_list.Add(groupBox5);
            con_list.Add(groupBox6);
            con_list.Add(groupBox7);
            con_list.Add(groupBox8);
            con_list.Add(checkBox1);
            con_list.Add(checkBox2);
            con_list.Add(checkBox3);
            con_list.Add(checkBox4);
            con_list.Add(checkBox5);
            con_list.Add(checkBox6);
            con_list.Add(checkBox7);
            con_list.Add(checkBox8);
            con_list.Add(checkBox9);
            con_list.Add(checkBox10);
            con_list.Add(checkBox11);
            con_list.Add(checkBox12);
            con_list.Add(checkBox13);
            con_list.Add(checkBox14);
            con_list.Add(checkBox15);
            con_list.Add(checkBox16);
            con_list.Add(checkBox17);
            con_list.Add(checkBox18);
            con_list.Add(checkBox19);
            con_list.Add(checkBox20);
            con_list.Add(checkBox21);
            con_list.Add(checkBox22);
            con_list.Add(checkBox23);
            con_list.Add(checkBox24);
            con_list.Add(checkBox25);
            con_list.Add(checkBox26);
            con_list.Add(checkBox27);
            con_list.Add(checkBox28);
            con_list.Add(checkBox29);
            con_list.Add(checkBox30);
            con_list.Add(checkBox31);
            con_list.Add(checkBox32);
            con_list.Add(checkBox33);
            con_list.Add(checkBox34);
            con_list.Add(checkBox35);
            con_list.Add(checkBox36);
            con_list.Add(checkBox37);
            con_list.Add(checkBox38);
            con_list.Add(checkBox39);
            con_list.Add(checkBox40);
            con_list.Add(checkBox41);
            con_list.Add(checkBox42);
            con_list.Add(checkBox43);
            con_list.Add(checkBox44);
            con_list.Add(checkBox45);
            #endregion
            #region checkbox容器cb_list
            List<CheckBox> cb_list = new List<CheckBox>();
            cb_list.Add(checkBox1);
            cb_list.Add(checkBox2);
            cb_list.Add(checkBox3);
            cb_list.Add(checkBox4);
            cb_list.Add(checkBox5);
            cb_list.Add(checkBox6);
            cb_list.Add(checkBox7);
            cb_list.Add(checkBox8);
            cb_list.Add(checkBox9);
            cb_list.Add(checkBox10);
            cb_list.Add(checkBox11);
            cb_list.Add(checkBox12);
            cb_list.Add(checkBox13);
            cb_list.Add(checkBox14);
            cb_list.Add(checkBox15);
            cb_list.Add(checkBox16);
            cb_list.Add(checkBox17);
            cb_list.Add(checkBox18);
            cb_list.Add(checkBox19);
            cb_list.Add(checkBox20);
            cb_list.Add(checkBox21);
            cb_list.Add(checkBox22);
            cb_list.Add(checkBox23);
            cb_list.Add(checkBox24);
            cb_list.Add(checkBox25);
            cb_list.Add(checkBox26);
            cb_list.Add(checkBox27);
            cb_list.Add(checkBox28);
            cb_list.Add(checkBox29);
            cb_list.Add(checkBox30);
            cb_list.Add(checkBox31);
            cb_list.Add(checkBox32);
            cb_list.Add(checkBox33);
            cb_list.Add(checkBox34);
            cb_list.Add(checkBox35);
            cb_list.Add(checkBox36);
            cb_list.Add(checkBox37);
            cb_list.Add(checkBox38);
            cb_list.Add(checkBox39);
            cb_list.Add(checkBox40);
            cb_list.Add(checkBox41);
            cb_list.Add(checkBox42);
            cb_list.Add(checkBox43);
            cb_list.Add(checkBox44);
            cb_list.Add(checkBox45);
            #endregion
            if (listView2.SelectedItems.Count > 0)
            {
                foreach (Control item in con_list)
                {
                    if (item is GroupBox)
                    {
                        foreach (Control ite in cb_list)
                        {
                            if (ite is CheckBox)
                            {
                                ((CheckBox)ite).IsChecked = false;
                            }
                        }
                    }
                }
                string str = listView2.Items[listView2.SelectedIndex].ToString();
                string[] ss = str.Split(',');
                textBox3.Text = ss[0].Substring(4).Replace("=", "").Trim();
                textBox2.Text = ss[2].Substring(3).Replace("=", "").Replace("}", "").Trim();
                textBox1.Text = "";
                string s = us.Single(p => p.Uname == textBox3.Text).Peodom;
                string[] arr = s.Split('-');
                foreach (var item in arr)
                {
                    foreach (Control cons in con_list)
                    {
                        if (cons is GroupBox)
                        {
                            foreach (Control con in cb_list)
                            {
                                if (con is CheckBox && ((CheckBox)con).Content.ToString() == item)
                                {
                                    ((CheckBox)con).IsChecked = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        //快捷菜单栏点击
        private void MenuDel_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string str = listView1.SelectedItems[0].ToString();
                new IdCard_BLL().p_usesType_delete(str);
                Tip t1 = new Tip("删除成功！");
                t1.ShowDialog();
            }
            else
            {
                Tip t2 = new Tip("没有选中要删除的数据");
                t2.ShowDialog();
            }
        }

        #region 门诊医生权限设置
        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox10,
                checkBox11,
                checkBox12,
                checkBox14
            };
            foreach (CheckBox item in cb_list)
            {
                item.IsEnabled = true;
            }
        }
        #endregion

        #region 系统管理权限设置
        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox9,
                checkBox13,
                checkBox19,
                checkBox20,
                checkBox15,
                checkBox16,
                checkBox17,
                checkBox18
            };
            foreach (CheckBox item in cb_list)
            {
                item.IsEnabled = true;
            }
        }
        #endregion

        #region 门诊管理权限设置
        private void CheckBox3_Checked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox21,
                checkBox22,
                checkBox23,
                checkBox24,
                checkBox25
            };
            foreach (CheckBox item in cb_list)
            {
                item.IsEnabled = true;
            }
        }
        #endregion

        #region 财务管理权限设置
        private void CheckBox4_Checked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox26,
                checkBox27,
                checkBox28,
            };
            foreach (CheckBox item in cb_list)
            {
                item.IsEnabled = true;
            }
        }
        #endregion

        #region 药房管理权限设置
        private void CheckBox5_Checked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox29,
                checkBox30,
            };
            foreach (CheckBox item in cb_list)
            {
                item.IsEnabled = true;
            }
        }
        #endregion

        #region 住院管理权限设置
        private void CheckBox6_Checked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox31,
                checkBox32,
                checkBox33,
                checkBox34,
                checkBox35,
                checkBox36,
                checkBox37,
                checkBox38,
                checkBox39,

            };

            foreach (CheckBox item in cb_list)
            {
                item.IsEnabled = true;
            }
        }
        #endregion

        #region 门诊收费权限设置
        private void CheckBox7_Checked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox40,
                checkBox41,

            };
            foreach (CheckBox item in cb_list)
            {
                item.IsEnabled = true;
            }
        }
        #endregion

        #region 药库管理权限设置
        private void CheckBox8_Checked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox42,
                checkBox43,
                checkBox44,
                checkBox45,

            };
            foreach (CheckBox item in cb_list)
            {
                item.IsEnabled = true;
            }
        }
        #endregion

        //未勾选时
        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox10,
                checkBox11,
                checkBox12,
                checkBox14
            };
            foreach (CheckBox item in cb_list)
            {
                if (item.Name != "checkBox1")
                {
                    item.IsChecked = false;
                    item.IsEnabled = false;
                }
            }
        }

        private void CheckBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox9,
                checkBox13,
                checkBox19,
                checkBox20,
                checkBox15,
                checkBox16,
                checkBox17,
                checkBox18
            };
            foreach (CheckBox item in cb_list)
            {
                if (item.Name != "checkBox2")
                {
                    item.IsChecked = false;
                    item.IsEnabled = false;
                }
            }
        }

        private void CheckBox3_Unchecked(object sender, RoutedEventArgs e)
        {

            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox21,
                checkBox22,
                checkBox23,
                checkBox24,
                checkBox25
            };
            foreach (CheckBox item in cb_list)
            {
                if (item.Name != "checkBox3")
                {
                    item.IsChecked = false;
                    item.IsEnabled = false;
                }
            }
        }

        private void CheckBox4_Unchecked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox26,
                checkBox27,
                checkBox28,
            };
            foreach (CheckBox item in cb_list)
            {
                if (item.Name != "checkBox4")
                {
                    item.IsChecked = false;
                    item.IsEnabled = false;
                }
            }
        }

        private void CheckBox5_Unchecked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox29,
                checkBox30,
            };
            foreach (CheckBox item in cb_list)
            {
                if (item.Name != "checkBox5")
                {
                    item.IsChecked = false;
                    item.IsEnabled = false;
                }
            }
        }

        private void CheckBox6_Unchecked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox31,
                checkBox32,
                checkBox33,
                checkBox34,
                checkBox35,
                checkBox36,
                checkBox37,
                checkBox38,
                checkBox39,

            };
            foreach (CheckBox item in cb_list)
            {
                if (item.Name != "checkBox6")
                {
                    item.IsChecked = false;
                    item.IsEnabled = false;
                }
            }
        }

        private void CheckBox7_Unchecked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox40,
                checkBox41,

            };
            foreach (CheckBox item in cb_list)
            {
                if (item.Name != "checkBox7")
                {
                    item.IsChecked = false;
                    item.IsEnabled = false;
                }
            }
        }

        private void CheckBox8_Unchecked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> cb_list = new List<CheckBox>
            {
                checkBox42,
                checkBox43,
                checkBox44,
                checkBox45,

            };
            foreach (CheckBox item in cb_list)
            {
                if (item.Name != "checkBox8")
                {
                    item.IsChecked = false;
                    item.IsEnabled = false;
                }
            }
        }
        //全选
        private void CheckBox46_Checked(object sender, RoutedEventArgs e)
        {
            #region checkbox容器cb_list
            List<CheckBox> cb_list = new List<CheckBox>();
            cb_list.Add(checkBox1);
            cb_list.Add(checkBox2);
            cb_list.Add(checkBox3);
            cb_list.Add(checkBox4);
            cb_list.Add(checkBox5);
            cb_list.Add(checkBox6);
            cb_list.Add(checkBox7);
            cb_list.Add(checkBox8);
            cb_list.Add(checkBox9);
            cb_list.Add(checkBox10);
            cb_list.Add(checkBox11);
            cb_list.Add(checkBox12);
            cb_list.Add(checkBox13);
            cb_list.Add(checkBox14);
            cb_list.Add(checkBox15);
            cb_list.Add(checkBox16);
            cb_list.Add(checkBox17);
            cb_list.Add(checkBox18);
            cb_list.Add(checkBox19);
            cb_list.Add(checkBox20);
            cb_list.Add(checkBox21);
            cb_list.Add(checkBox22);
            cb_list.Add(checkBox23);
            cb_list.Add(checkBox24);
            cb_list.Add(checkBox25);
            cb_list.Add(checkBox26);
            cb_list.Add(checkBox27);
            cb_list.Add(checkBox28);
            cb_list.Add(checkBox29);
            cb_list.Add(checkBox30);
            cb_list.Add(checkBox31);
            cb_list.Add(checkBox32);
            cb_list.Add(checkBox33);
            cb_list.Add(checkBox34);
            cb_list.Add(checkBox35);
            cb_list.Add(checkBox36);
            cb_list.Add(checkBox37);
            cb_list.Add(checkBox38);
            cb_list.Add(checkBox39);
            cb_list.Add(checkBox40);
            cb_list.Add(checkBox41);
            cb_list.Add(checkBox42);
            cb_list.Add(checkBox43);
            cb_list.Add(checkBox44);
            cb_list.Add(checkBox45);
            #endregion
            foreach (CheckBox c in cb_list)
            {
                c.IsChecked = true;
            }
        }
        //不全选
        private void CheckBox46_Unchecked(object sender, RoutedEventArgs e)
        {
            #region checkbox容器cb_list
            List<CheckBox> cb_list = new List<CheckBox>();
            cb_list.Add(checkBox1);
            cb_list.Add(checkBox2);
            cb_list.Add(checkBox3);
            cb_list.Add(checkBox4);
            cb_list.Add(checkBox5);
            cb_list.Add(checkBox6);
            cb_list.Add(checkBox7);
            cb_list.Add(checkBox8);
            cb_list.Add(checkBox9);
            cb_list.Add(checkBox10);
            cb_list.Add(checkBox11);
            cb_list.Add(checkBox12);
            cb_list.Add(checkBox13);
            cb_list.Add(checkBox14);
            cb_list.Add(checkBox15);
            cb_list.Add(checkBox16);
            cb_list.Add(checkBox17);
            cb_list.Add(checkBox18);
            cb_list.Add(checkBox19);
            cb_list.Add(checkBox20);
            cb_list.Add(checkBox21);
            cb_list.Add(checkBox22);
            cb_list.Add(checkBox23);
            cb_list.Add(checkBox24);
            cb_list.Add(checkBox25);
            cb_list.Add(checkBox26);
            cb_list.Add(checkBox27);
            cb_list.Add(checkBox28);
            cb_list.Add(checkBox29);
            cb_list.Add(checkBox30);
            cb_list.Add(checkBox31);
            cb_list.Add(checkBox32);
            cb_list.Add(checkBox33);
            cb_list.Add(checkBox34);
            cb_list.Add(checkBox35);
            cb_list.Add(checkBox36);
            cb_list.Add(checkBox37);
            cb_list.Add(checkBox38);
            cb_list.Add(checkBox39);
            cb_list.Add(checkBox40);
            cb_list.Add(checkBox41);
            cb_list.Add(checkBox42);
            cb_list.Add(checkBox43);
            cb_list.Add(checkBox44);
            cb_list.Add(checkBox45);
            #endregion
            foreach (CheckBox c in cb_list)
            {
                c.IsChecked = false;
            }
        }


    }
}
