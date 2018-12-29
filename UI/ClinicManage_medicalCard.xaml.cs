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
    /// ClinicManage_medicalCard.xaml 的交互逻辑
    /// </summary>
    public partial class ClinicManage_medicalCard : Page
    {
        public ClinicManage_medicalCard()
        {
            InitializeComponent();
        }

        //注册
        private void BtnSure_Click(object sender, RoutedEventArgs e)
        {
            List<Control> con_list = new List<Control>()
            {
                txtName,
                txtAddress,
                cboCulture,
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

            foreach (Control item in con_list)
            {
                if (item is TextBox)
                    if (((TextBox)item).Text == "" )
                    {
                        var p = new Tip("请把信息填写完整！");
                        p.ShowDialog();
                        return;
                    }
                if(item is ComboBox)
                {
                    if (((ComboBox)item).Text == "")
                    {
                        var p = new Tip("请把信息填写完整！");
                        p.ShowDialog();
                        return;
                    }
                }
                if (item is DatePicker)
                {
                    if (((DatePicker)item).Text == "")
                    {
                        var p = new Tip("请把信息填写完整！");
                        p.ShowDialog();
                        return;
                    }
                }
            }
            IdCard IC = new IdCard
            {
                Name = txtName.Text
            };
            if (rdoBoy.IsChecked == true)
                IC.Sex = rdoBoy.Content.ToString();
            else
                IC.Sex = rdoGirl.Content.ToString();
            IC.Age = int.Parse(txtAge.Text);
            IC.Birthday = dtpBirthday.Text;
            IC.Address = txtAddress.Text;
            IC.Phone = (txtPhone.Text);
            IC.Nation = cboNation.Text;
            IC.Cultrue = cboCulture.Text;
            if (rdoMarriageYes.IsChecked == true)
                IC.Marriage = rdoMarriageYes.Content.ToString();
            else
                IC.Marriage = rdoMarriageNo.Content.ToString();
            IC.Work = cboWork.Text;
            IC.Postcode = (txtPostcode.Text);
            IC.IdcardNo = txtIdcardNo.Text;

            string mes = new IdCard_BLL().Reg(IC);
            string s = new IdCard_BLL().p_IdCard_select();

            var t = new Tip("注册成功!卡号为：" + s);
            t.ShowDialog();
        }
        //初始化
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            cboCulture.Text = "";
            txtIdcardNo.Text = "";
            txtPhone.Text = "";
            cboWork.Text = "";
            txtAge.Text = "";
            cboNation.Text = "";
            txtPostcode.Text = "";
            rdoBoy.Content = "";
            rdoGirl.Content = "";
            rdoMarriageYes.Content = "";
            rdoMarriageNo.Content = "";
            dtpBirthday.Text = "";
        }


    } 
}





