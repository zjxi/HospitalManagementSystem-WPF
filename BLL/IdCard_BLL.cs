using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class IdCard_BLL
    {
        public string Reg(IdCard ic)
        {
            int re = new IdCard_DAL().Reg(ic);
            if (re == 0)
                return "该身份证已注册过绿卡";
            else if (re == 1)
                return "注册成功";
            else
                return "注册失败";
        }
        public string sickroom(List<Sickroom> sect, int num)
        {
            return new IdCard_DAL().sickroom(sect, num);
        }

        /// <summary>
        /// 病房查询
        /// </summary>
        /// <returns></returns>
        public List<Sickroom> sickroom_select()
        {
            return new IdCard_DAL().sickroom_select();
        }

        /// <summary>
        /// 病床查询
        /// </summary>
        /// <returns></returns>
        public List<Bed> Bed_select() 
        {
            return new IdCard_DAL().Bed_select();
        }

        public List<string> controls_select()
        {
            return new IdCard_DAL().controls_select();
        }

        public string Delete(List<Sickroom> sic)
        {
            return new IdCard_DAL().Delete(sic);
        }

        public string p_zhuyuan_insert(zhuyuan zhu)
        {
            return new IdCard_DAL().p_zhuyuan_insert(zhu);
        }

        public Dictionary<int, IdCard> IdCard(IdCard i)
        {
            return new IdCard_DAL().IdCardSelect(i);
        }

        public List<zhuyuan> p_zhuyuan_Select()
        {
            return new IdCard_DAL().p_zhuyuan_Select();
        }

        public void p_zhuyuanxiaofei_insert(List<zhuyuanxiaofei> xfs)
        {
            new IdCard_DAL().p_zhuyuanxiaofei_insert(xfs);
        }

        public List<zhuyuanxiaofei> p_zhuyuanxiaofei_select(int i)
        {
            return new IdCard_DAL().p_zhuyuanxiaofei_select(i);
        }

        public void p_zhuyuanxiaofei_delete(int i, string str)
        {
            new IdCard_DAL().p_zhuyuanxiaofei_delete(i, str);
        }

        public void update_zhuyuan_yujiao(int i, string s)
        {
            new IdCard_DAL().update_zhuyuan_yujiao(i, s);
        }

        public List<Maidan> p_kaiyao_select()
        {
            return new IdCard_DAL().p_kaiyao_select();
        }

        public void p_kaiyao_update(string str)
        {
            new IdCard_DAL().p_kaiyao_update(str);
        }

        public void p_kaiyaoregister_delete(string str)
        {
            new IdCard_DAL().p_kaiyaoregister_delete(str);
        }

        public void p_zhuyuanzhuyuanxiaofei_deleted(string str)
        {
            new IdCard_DAL().p_zhuyuanzhuyuanxiaofei_deleted(str);
        }

        public void p_zhuayuantongji_select(zhuayuantongji zhu)
        {
            new IdCard_DAL().p_zhuayuantongji_select(zhu);
        }

        public List<zhuayuantongji> p_zhuayuantongji()
        {

            return new IdCard_DAL().p_zhuayuantongji();
        }

        public void p_bed_update(int i, int j)
        {
            new IdCard_DAL().p_bed_update(i, j);
        }

        public string p_usersType_insert(string name, string str)
        {
            return new IdCard_DAL().p_usersType_insert(name, str);
        }

        public List<UsersType> p_usesType_select()
        {
            return new IdCard_DAL().p_usesType_select();
        }

        public void p_usesType_delete(string str)
        {
            new IdCard_DAL().p_usesType_delete(str);
        }

        public void p_usesType_update(string name, string str)
        {
            new IdCard_DAL().p_usesType_update(name, str);
        }

        public string p_users_insert(Users u)
        {
            return new IdCard_DAL().p_users_insert(u);
        }

        public List<Users> p_users_select01()
        {
            return new IdCard_DAL().p_users_select01();
        }

        public void p_usersPeodom_update(string name, string str)
        {
            new IdCard_DAL().p_usersPeodom_update(name, str);
        }

        public string p_peodom_select(string uname)
        {
            return new IdCard_DAL().p_peodom_select(uname);
        }

        public void p_users_delete(string Uid)
        {
            new IdCard_DAL().p_users_delete(Uid);
        }

        public string p_IdCard_select()
        {
            return new IdCard_DAL().p_IdCard_select();
        }
    }
}
