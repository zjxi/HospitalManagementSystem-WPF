using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// ClinicManage_register.xaml 的交互逻辑
    /// </summary>
    public partial class ClinicManage_register : Page
    {
        public ClinicManage_register()
        {
            InitializeComponent();

            Init_Load();
        }

        List<Users> us;
        List<SectionRoom> se;

        private void Init_Load()
        {
            se = new UsersBLL().Section();
            cboSectionRoom.ItemsSource = se;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["strCon"].ToString());
            SqlCommand cmd = new SqlCommand();
            con.Open();
            string str = "select top 1 Rid from Register order by Rid desc";
            cmd.Connection = con;
            cmd.CommandText = str;
            string id = cmd.ExecuteScalar() + "";
            if (id != "")
            {
                string oldId = id.Substring(1);
                int intOldId = int.Parse(oldId);

                intOldId += 1;
                string strResult = "";
                switch ((intOldId + "").Length)
                {
                    case 1:
                        strResult = "000" + intOldId;
                        break;
                    case 2:
                        strResult = "00" + intOldId;
                        break;
                    case 3:
                        strResult = "0" + intOldId;
                        break;
                    default:
                        strResult = "编号不够了，请升级软件";
                        break;
                }
                txtRid.Text = strResult;
            }
            else
                txtRid.Text = "0001";
            con.Close();
        }
        //挂号
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            List<Control> con_list1 = new List<Control>()
            {
                txtRid,
                txtKid,
                txtOtherFei,
                cboIdType,
                cboSectionRoom,
                dtpRegisterTime,
                dtpSeeDoctorTime,
                cboDoctor,
                txtGuaHaoFei,
                txtName,
                txtAddress,
                cboCultrue,
                txtIdcardNo,
                txtPhone,
                cboWork,
                txtAge,
                cboNation,
                txtPostcode,
                rdoBoy,
                rdoGirl,
                rdoMarriageYes,
                rdoMarriageNo,
                dtpBirthday
            };

            foreach (Control item in con_list1)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Text == "")
                    {
                        var p = new Tip("请填写完整信息！");
                        p.ShowDialog();
                        return;
                    }
                }
                else if (item is ComboBox)
                {
                    if (((ComboBox)item).Text == "")
                    {
                        var p = new Tip("请填写完整信息！");
                        p.ShowDialog();
                        return;
                    }
                }
                else if(item is DatePicker)
                {
                    if (((DatePicker)item).Text == "")
                    {
                        var p = new Tip("请填写完整信息！");
                        p.ShowDialog();
                        return;
                    }
                }
                else
                {
                    //if(((RadioButton)item).IsChecked == false)
                    //{
                    //    var p = new Tip("请填写完整信息！");
                    //    p.ShowDialog();
                    //    return;
                    //}
                }
            }
            Register r = new Register
            {
                Rid = txtRid.Text,
                KId = int.Parse(txtKid.Text),
                IdType = cboIdType.Text,
                SectionRoom = cboSectionRoom.Text + "",
                Doctor = cboDoctor.Text,
                GuaDanFei = int.Parse(txtGuaHaoFei.Text),
                OtherFei = int.Parse(txtOtherFei.Text),
                ReristerTime = dtpRegisterTime.Text,
                SeeDoctorTime = dtpSeeDoctorTime.Text
            };
            string s = new UsersBLL().RegisterRew(r);

            var t = new Tip(s);
            t.ShowDialog();
            if (printList.IsChecked==true && s == "挂号成功")
            {
                PrintDialog dialog = new PrintDialog();
                if (dialog.ShowDialog() == true)
                {
                    dialog.PrintVisual(groupBox1, "打印挂号单");
                }
            }
        }
        //清空
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Init_Load();
            List<Control> con_list1 = new List<Control>()
            {
                txtRid,
                txtKid,
                txtOtherFei,
                cboIdType,
                cboSectionRoom,
                dtpRegisterTime,
                dtpSeeDoctorTime,
                cboDoctor,
                txtGuaHaoFei,
                txtName,
                txtAddress,
                cboCultrue,
                txtIdcardNo,
                txtPhone,
                cboWork,
                txtAge,
                cboNation,
                txtPostcode,
                rdoBoy,
                rdoGirl,
                rdoMarriageYes,
                rdoMarriageNo,
                dtpBirthday
            };

            foreach (Control item in con_list1)
            {
                if(item is TextBox)
                {
                    if (item.Name != "txtRid")
                    {
                        ((TextBox)item).Text = "";
                    }
                }
                else if(item is ComboBox)
                {
                    if (item.Name != "txtRid")
                    {
                        ((ComboBox)item).Text = "";
                    }
                }
                else if(item is DatePicker)
                {
                    if (item.Name != "txtRid")
                    {
                        ((DatePicker)item).Text = "";
                    }
                }
                else
                {
                    rdoBoy.IsChecked = false;
                    rdoGirl.IsChecked = false;
                    rdoMarriageNo.IsChecked = false;
                    rdoMarriageYes.IsChecked = false;
                }
            }
            txtOtherFei.Text = 0 + "";
            txtGuaHaoFei.Text = 0 + "";
        }
        //科室选中项改变
        private void CboSectionRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            us = new IdCard_BLL().p_users_select01();
            cboDoctor.Items.Clear();
            cboDoctor.Text = "";

            //foreach (Users q in us.Where(p => p.SectionRoom == cboSectionRoom.Text))
            foreach (Users q in us)
            {
                cboDoctor.Items.Add(q.name);
            }
            if(cboSectionRoom.Text != "")
            {
                txtGuaHaoFei.Text = se[cboSectionRoom.SelectedIndex].Sprice + "";
            }
        }
        //卡号输入框变化
        private void TxtKid_TextChanged(object sender, TextChangedEventArgs e)
        {
            IdCard IC = new IdCard();
            if (txtKid.Text == "")
                return;
            IC.Kid = int.Parse(txtKid.Text);
            Dictionary<int, IdCard> Cd = new IdCard_BLL().IdCard(IC);
            foreach (int item in Cd.Keys)
            {
                if (int.Parse(txtKid.Text) == item)
                {
                    if (txtKid.Text.Length == 5)
                    {
                        txtName.Text = Cd[int.Parse(txtKid.Text)].Name;
                        txtAge.Text = Cd[int.Parse(txtKid.Text)].Age.ToString();
                        txtPostcode.Text = Cd[int.Parse(txtKid.Text)].Postcode;
                        txtIdcardNo.Text = Cd[int.Parse(txtKid.Text)].IdcardNo;
                        cboCultrue.Text = Cd[int.Parse(txtKid.Text)].Cultrue;
                        cboNation.Text = Cd[int.Parse(txtKid.Text)].Nation;
                        txtPhone.Text = Cd[int.Parse(txtKid.Text)].Phone;
                        cboWork.Text = Cd[int.Parse(txtKid.Text)].Work;
                        txtAddress.Text = Cd[int.Parse(txtKid.Text)].Address;
                        if (Cd[int.Parse(txtKid.Text)].Sex == "女")
                        {
                            rdoGirl.IsChecked = true;
                        }
                        else
                            rdoBoy.IsChecked = true;
                        if (Cd[int.Parse(txtKid.Text)].Marriage == "未婚")
                        {
                            rdoMarriageNo.IsChecked = true;
                        }
                        else
                            rdoMarriageYes.IsChecked = true;
                    }
                    else
                        return;
                }
            }
        }
        //医师选中项改变
        private void CboDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Users q in us.Where(p => p.SectionRoom == cboSectionRoom.Text).Where(p => p.name == cboDoctor.Text))
            {
                txtGuaHaoFei.Text = q.money + "";
            }
        }


    }
}
