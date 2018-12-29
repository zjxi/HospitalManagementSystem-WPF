using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class IdCard_DAL
    {
        /// <summary>
        /// 卡号添加
        /// </summary>
        /// <param name="ic"></param>
        /// <returns></returns>
        public int Reg(IdCard ic)
        {
            SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
            SqlParameter sex = new SqlParameter("@sex", SqlDbType.Char);
            SqlParameter age = new SqlParameter("@age", SqlDbType.Int);
            SqlParameter Birthday = new SqlParameter("@Birthday", SqlDbType.SmallDateTime);
            SqlParameter address = new SqlParameter("@address", SqlDbType.VarChar);
            SqlParameter phone = new SqlParameter("@phone", SqlDbType.Char);
            SqlParameter nation = new SqlParameter("@nation", SqlDbType.VarChar);
            SqlParameter Cultrue = new SqlParameter("@Cultrue", SqlDbType.VarChar);
            SqlParameter Marriage = new SqlParameter("@Marriage", SqlDbType.Char);
            SqlParameter Work = new SqlParameter("@Work", SqlDbType.VarChar);
            SqlParameter Postcode = new SqlParameter("@Postcode", SqlDbType.Int);
            SqlParameter IdcardNo = new SqlParameter("@IdcardNo", SqlDbType.VarChar);
            SqlParameter result = new SqlParameter("@result", SqlDbType.Int);
            result.Direction = ParameterDirection.Output;
            name.Value = ic.Name;
            sex.Value = ic.Sex;
            age.Value = ic.Age;
            Birthday.Value = ic.Birthday;
            address.Value = ic.Address;
            phone.Value = ic.Phone;
            nation.Value = ic.Nation;
            Cultrue.Value = ic.Cultrue;
            Marriage.Value = ic.Marriage;
            Work.Value = ic.Work;
            Postcode.Value = ic.Postcode;
            IdcardNo.Value = ic.IdcardNo;
            SqlParameter[] sp = { name, sex, age, Birthday, address, phone, nation, Cultrue, Marriage, Work, Postcode, IdcardNo, result };
            bool f = DBHelper.ExecuteNonQueryProc("Reg_IdCard", sp);
            if (f)
                return (int)result.Value;
            else
                return -1;
        }

        /// <summary>
        /// 病房添加
        /// </summary>
        /// <param name="sics"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public string sickroom(List<Sickroom> sics, int num)  
        {
            foreach (Sickroom item in sics)
            {
                SqlParameter Idsickroom = new SqlParameter("@Idsickroom", SqlDbType.Int);
                SqlParameter Tyep = new SqlParameter("@Type", SqlDbType.Char);
                SqlParameter Sid = new SqlParameter("@Sid", SqlDbType.Int);
                SqlParameter Price = new SqlParameter("@Price", SqlDbType.Int);
                SqlParameter result = new SqlParameter("@result", SqlDbType.Char, 30);
                result.Direction = ParameterDirection.Output;
                Idsickroom.Value = item.Idsickroom;
                Tyep.Value = item.Tyep;
                Sid.Value = item.Sid;
                Price.Value = item.Price;
                SqlParameter[] sp = { Idsickroom, Tyep, Sid, Price, result };
                bool f = DBHelper.ExecuteNonQueryProc("p_sickroom_insert", sp);
                if (!f)
                {
                    return "系统出错";
                }
                string str = result.Value + "";
                if ((result.Value + "").Substring(0, 2) != "OK")
                {
                    return "出现相同的房号!";
                }
            }
            foreach (Sickroom item in sics)
            {
                for (int i = 0; i < num; i++)
                {
                    SqlParameter Idsickroom = new SqlParameter("@Idsickroom", SqlDbType.Int);
                    SqlParameter Idbed = new SqlParameter("@Idbed", SqlDbType.Int);
                    SqlParameter KId = new SqlParameter("@KId", SqlDbType.Int);
                    SqlParameter State = new SqlParameter("@State", SqlDbType.Char);
                    Idsickroom.Value = item.Idsickroom;
                    Idbed.Value = i + 1;
                    KId.Value = 0;
                    State.Value = "空";
                    SqlParameter[] sp = { Idsickroom, Idbed, KId, State };
                    bool f = DBHelper.ExecuteNonQueryProc("p_bed_insert", sp);
                }
            }
            return "添加成功";
        }
        /// <summary>
        /// 病房查询
        /// </summary>
        /// <returns></returns>
        public List<Sickroom> sickroom_select() 
        {
            List<Sickroom> ssic = new List<Sickroom>();
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_sickroom_select");
            while (reader.Read())
            {
                Sickroom sic = new Sickroom();
                sic.Idsickroom = int.Parse(reader[0] + "");
                sic.Tyep = reader[2] + "";
                sic.Sid = int.Parse(reader[1] + "");
                sic.Price = int.Parse(reader[3] + "");
                ssic.Add(sic);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return ssic;
        }
        /// <summary>
        /// 病床查询
        /// </summary>
        /// <returns></returns>
        public List<Bed> Bed_select()   
        {
            List<Bed> Bed = new List<Bed>();
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_bed_select");
            while (reader.Read())
            {
                Bed B = new Bed();
                B.Idsickroom = int.Parse(reader[0] + "");
                B.Idbed = int.Parse(reader[1] + "");
                B.KId = int.Parse(reader[2] + "");
                B.State = reader[3] + "";
                Bed.Add(B);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return Bed;
        }
        public List<string> controls_select()
        {
            List<string> s = new List<string>();
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_controls_select");
            while (reader.Read())
            {
                string str = (reader[0] + "");
                s.Add(str);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return s;
        }
        /// <summary>
        /// 病房删除
        /// </summary>
        /// <param name="sic"></param>
        /// <returns></returns>
        public string Delete(List<Sickroom> sic)
        {
            try
            {
                foreach (Sickroom item in sic)
                {
                    SqlParameter Idsickroom = new SqlParameter("@Idsickroom", SqlDbType.Int);
                    Idsickroom.Value = item.Idsickroom;
                    SqlParameter[] sp = { Idsickroom };
                    bool b = DBHelper.ExecuteNonQueryProc("p_sickroom_Delete", sp);
                    if (!b)
                        return "系统出错";
                }
                foreach (Sickroom item in sic)
                {
                    SqlParameter Idsickroom = new SqlParameter("@Idsickroom", SqlDbType.Int);
                    Idsickroom.Value = item.Idsickroom;
                    SqlParameter[] sp = { Idsickroom };
                    bool f = DBHelper.ExecuteNonQueryProc("p_bed_Delete", sp);
                    if (!f)
                        return "系统出错";
                }
                return "1";

            }
            catch { return "系统出错"; }
        }
        /// <summary>
        /// 住院病人信息添加
        /// </summary>
        /// <param name="zhu"></param>
        /// <returns></returns>
        public string p_zhuyuan_insert(zhuyuan zhu)
        {

            SqlParameter kId = new SqlParameter("@kId", SqlDbType.Int);
            SqlParameter Sid = new SqlParameter("@Sid", SqlDbType.Int);
            SqlParameter Idsickroom = new SqlParameter("@Idsickroom", SqlDbType.Int);
            SqlParameter BedNo = new SqlParameter("@BedNo", SqlDbType.Char);
            SqlParameter Imprest = new SqlParameter("@Imprest", SqlDbType.Int);
            SqlParameter Bewrite = new SqlParameter("@Bewrite", SqlDbType.Char);
            SqlParameter Tabu = new SqlParameter("@Tabu", SqlDbType.Char);
            SqlParameter Ztime = new SqlParameter("@Ztime", SqlDbType.Char);
            SqlParameter result = new SqlParameter("@result", SqlDbType.Char, 2);
            result.Direction = ParameterDirection.Output;
            kId.Value = zhu.kId;
            Sid.Value = zhu.Sid;
            Idsickroom.Value = zhu.Idsickroom;
            BedNo.Value = zhu.BedNo;
            Imprest.Value = zhu.Imprest;
            Bewrite.Value = zhu.Bewrite;
            Tabu.Value = zhu.Tabu;
            Ztime.Value = zhu.Ztime;
            SqlParameter[] sp = { kId, Sid, Idsickroom, BedNo, Imprest, Bewrite, Tabu, Ztime, result };
            bool f = DBHelper.ExecuteNonQueryProc("p_zhuyuan_insert", sp);
            if (result.Value + "" == "KO")
                return "此卡已申请过!";
            if (result.Value + "" == "NO")
                return "此卡不存在，请确认输入正确!";
            else if (f)
                return "提交成功,需预交费" + Imprest.Value + "元!";
            else
                return "系统出错";
        }
        public Dictionary<int, IdCard> IdCardSelect(IdCard i)
        {
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_IdCard_select");
            Dictionary<int, IdCard> cards = new Dictionary<int, IdCard>();
            while (reader.Read())
            {
                IdCard cd = new IdCard();
                cd.Kid = int.Parse(reader[0] + "");
                cd.Name = reader[1] + "";
                cd.Sex = reader[2] + "";
                cd.Age = int.Parse(reader[3] + "");
                cd.Birthday = reader[4] + "";
                cd.Address = reader[5] + "";
                cd.Phone = reader[6] + "";
                cd.Nation = reader[7] + "";
                cd.Cultrue = reader[8] + "";
                cd.Marriage = reader[9] + "";
                cd.Work = reader[10] + "";
                cd.Postcode = reader[11] + "";
                cd.IdcardNo = reader[12] + "";
                cards.Add(cd.Kid, cd);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return cards;
        }
        /// <summary>
        /// 查询病人信息
        /// </summary>
        /// <returns></returns>
        public List<zhuyuan> p_zhuyuan_Select()
        {
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_zhuyuan_select");
            List<zhuyuan> zhu = new List<zhuyuan>();
            while (reader.Read())
            {
                zhuyuan cd = new zhuyuan();
                cd.kId = int.Parse(reader[0] + "");
                cd.Sid = int.Parse(reader[1] + "");
                cd.Idsickroom = int.Parse(reader[2] + "");
                cd.BedNo = (reader[3] + "");
                cd.Imprest = int.Parse(reader[4] + "");
                cd.Bewrite = reader[5] + "";
                cd.Tabu = reader[6] + "";
                cd.Ztime = reader[7] + "";
                cd.Kname = reader[8] + "";
                zhu.Add(cd);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return zhu;
            //return cards;
        }
        /// <summary>
        /// 添加住院费用
        /// </summary>
        /// <param name="xfs"></param>
        public void p_zhuyuanxiaofei_insert(List<zhuyuanxiaofei> xfs)
        {
            foreach (zhuyuanxiaofei item in xfs)
            {

                SqlParameter kId = new SqlParameter("@kId", SqlDbType.Int);
                SqlParameter yaoName = new SqlParameter("@yaoName", SqlDbType.Char);
                SqlParameter yaonum = new SqlParameter("@yaonum", SqlDbType.Int);
                kId.Value = item.kId;
                yaoName.Value = item.yaoName;
                yaonum.Value = item.yaonum;
                SqlParameter[] sp = { kId, yaoName, yaonum };
                bool f = DBHelper.ExecuteNonQueryProc("p_zhuyuanxiaofei_insert", sp);

            }
        }
        /// <summary>
        /// 查询住院费用
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public List<zhuyuanxiaofei> p_zhuyuanxiaofei_select(int i)
        {
            SqlParameter kId = new SqlParameter("@kId", SqlDbType.Int);
            kId.Value = i;
            SqlParameter[] sp = { kId };
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_zhuyuanxiaofei_select", sp);
            List<zhuyuanxiaofei> zhu = new List<zhuyuanxiaofei>();
            while (reader.Read())
            {
                zhuyuanxiaofei cd = new zhuyuanxiaofei();
                cd.kId = int.Parse(reader[1] + "");
                cd.yaoName = reader[2] + "";
                cd.yaonum = int.Parse(reader[3] + "");
                zhu.Add(cd);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return zhu;

        }
        /// <summary>
        /// 删除住院消费记录
        /// </summary>
        /// <param name="i"></param>
        /// <param name="str"></param>
        public void p_zhuyuanxiaofei_delete(int i, string str)
        {
            SqlParameter kId = new SqlParameter("@kId", SqlDbType.Int);
            SqlParameter yaoName = new SqlParameter("@yaoName", SqlDbType.Char);
            kId.Value = i;
            yaoName.Value = str;
            SqlParameter[] sp = { kId, yaoName };
            bool f = DBHelper.ExecuteNonQueryProc("p_zhuyuanxiaofei_delete", sp);
        }
        public void update_zhuyuan_yujiao(int i, string s)
        {
            SqlParameter kId = new SqlParameter("@kId", SqlDbType.Int);
            SqlParameter Imprest = new SqlParameter("@Imprest", SqlDbType.Char);
            kId.Value = s;
            Imprest.Value = i;
            SqlParameter[] sp = { kId, Imprest };
            DBHelper.ExecuteNonQueryProc("update_zhuyuan_yujiao", sp);
        }
        public List<Maidan> p_kaiyao_select()
        {
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_kaiyao_select");
            List<Maidan> cards = new List<Maidan>();
            while (reader.Read())
            {
                Maidan cd = new Maidan();
                cd.Rid = (reader[0] + "");
                cd.Doctor = reader[1] + "";
                cd.SectionRoom = reader[2] + "";
                cd.Name = (reader[3] + "");
                cd.IdcardNo = reader[4] + "";
                cd.Sex = reader[5] + "";
                cd.yaopinName = reader[6] + "";
                cd.zhuangtai = reader[7] + "";
                cards.Add(cd);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return cards;

        }
        public void p_kaiyao_update(string str)
        {
            SqlParameter RId = new SqlParameter("@RId", SqlDbType.Char);
            RId.Value = str;
            SqlParameter[] sp = { RId };
            DBHelper.ExecuteNonQueryProc("p_kaiyao_update", sp);

        }
        public void p_kaiyaoregister_delete(string str)
        {
            SqlParameter RId = new SqlParameter("@RId", SqlDbType.Char);
            RId.Value = str;
            SqlParameter[] sp = { RId };
            DBHelper.ExecuteNonQueryProc("p_kaiyaoregister_delete", sp);
        }
        public void p_zhuyuanzhuyuanxiaofei_deleted(string str)
        {
            SqlParameter KId = new SqlParameter("@KId", SqlDbType.Char);
            KId.Value = str;
            SqlParameter[] sp = { KId };
            DBHelper.ExecuteNonQueryProc("p_zhuyuanzhuyuanxiaofei_deleted", sp);
        }
        public void p_zhuayuantongji_select(zhuayuantongji zhu)
        {

            SqlParameter Kid = new SqlParameter("@Kid", SqlDbType.Int);
            SqlParameter Sname = new SqlParameter("@Sname", SqlDbType.Char);
            SqlParameter zmoney = new SqlParameter("@zmoney", SqlDbType.Int);
            SqlParameter ymoney = new SqlParameter("@ymoney", SqlDbType.Int);
            SqlParameter time = new SqlParameter("@time", SqlDbType.Char);

            Kid.Value = zhu.Kid;
            Sname.Value = zhu.Sname;
            zmoney.Value = zhu.zmoney;
            ymoney.Value = zhu.ymoney;
            time.Value = zhu.time;

            SqlParameter[] sp = { Kid, Sname, zmoney, ymoney, time };
            DBHelper.ExecuteNonQueryProc("p_zhuayuantongji_select", sp);
        }
        public List<zhuayuantongji> p_zhuayuantongji()
        {
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_zhuayuantongji");
            List<zhuayuantongji> cards = new List<zhuayuantongji>();
            while (reader.Read())
            {
                zhuayuantongji cd = new zhuayuantongji();
                cd.Kid = (reader[0] + "");
                cd.Sname = reader[1] + "";
                cd.zmoney = int.Parse(reader[2] + "");
                cd.ymoney = int.Parse(reader[3] + "");
                cd.time = reader[4] + "";
                cards.Add(cd);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return cards;

        }
        public void p_bed_update(int i, int j)
        {
            SqlParameter Idsickroom = new SqlParameter("@Idsickroom", SqlDbType.Int);
            SqlParameter Idbed = new SqlParameter("@Idbed", SqlDbType.Int);
            Idsickroom.Value = i;
            Idbed.Value = j;

            SqlParameter[] sp = { Idsickroom, Idbed };
            DBHelper.ExecuteNonQueryProc("p_bed_update", sp);
        }


        public string p_usersType_insert(string name, string str)
        {
            SqlParameter Type = new SqlParameter("@Type", SqlDbType.Char);
            SqlParameter peodom = new SqlParameter("@peodom", SqlDbType.Char);
            SqlParameter mess = new SqlParameter("@mess", SqlDbType.VarChar, 20);
            mess.Direction = ParameterDirection.Output;
            Type.Value = name;
            peodom.Value = str;

            SqlParameter[] sp = { Type, peodom, mess };
            DBHelper.ExecuteNonQueryProc("p_usersType_insert", sp);
            return mess.Value + "";
        }

        public List<UsersType> p_usesType_select()
        {
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_usesType_select");
            List<UsersType> type = new List<UsersType>();
            while (reader.Read())
            {
                UsersType cd = new UsersType();
                cd.Type = (reader[1] + "");
                cd.Peodom = reader[2] + "";
                type.Add(cd);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return type;
        }

        public void p_usesType_delete(string str)
        {
            SqlParameter Type = new SqlParameter("@Type", SqlDbType.Char);
            Type.Value = str;
            DBHelper.ExecuteNonQueryProc("p_usesType_delete", Type);
        }
        public void p_usesType_update(string name, string str)
        {
            SqlParameter Type = new SqlParameter("@Type", SqlDbType.VarChar);
            SqlParameter peodom = new SqlParameter("@peodom", SqlDbType.VarChar);
            Type.Value = name;
            peodom.Value = str;
            DBHelper.ExecuteNonQueryProc("p_usesType_update", Type, peodom);

        }
        public string p_users_insert(Users u)
        {
            SqlParameter Uname = new SqlParameter("@Uname", SqlDbType.Char);
            SqlParameter Pwd = new SqlParameter("@Pwd", SqlDbType.Char);
            SqlParameter Sex = new SqlParameter("@Sex", SqlDbType.Char);
            SqlParameter Address = new SqlParameter("@Address", SqlDbType.Char);
            SqlParameter Phone = new SqlParameter("@Phone", SqlDbType.Char);
            SqlParameter Spell = new SqlParameter("@Spell", SqlDbType.Char);
            SqlParameter Type = new SqlParameter("@Type", SqlDbType.Char);
            SqlParameter money = new SqlParameter("@money", SqlDbType.Int);
            SqlParameter Peodom = new SqlParameter("@Peodom", SqlDbType.Char);
            SqlParameter Section = new SqlParameter("@SectionRoom", SqlDbType.Char);
            SqlParameter name = new SqlParameter("@name", SqlDbType.Char);
            SqlParameter result = new SqlParameter("@result", SqlDbType.Char, 30);
            result.Direction = ParameterDirection.Output;
            Uname.Value = u.Uname;
            Pwd.Value = u.Pwd;
            Sex.Value = u.Sex;
            Address.Value = u.Address;
            Phone.Value = u.Phone;
            Spell.Value = u.Spell;
            Type.Value = u.Type;
            money.Value = u.money;
            Section.Value = u.SectionRoom;
            Peodom.Value = u.Peodom;
            name.Value = u.name;
            SqlParameter[] sp = { Uname, name, Pwd, Sex, Address, Phone, Spell, Type, Section, money, Peodom, result };
            bool f = DBHelper.ExecuteNonQueryProc("p_users_insert", sp);
            if (!f)
            {
                return "系统出错";
            }
            string str = result.Value + "";
            return str;
        }
        public List<Users> p_users_select01()
        {
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_users_select01");
            List<Users> us = new List<Users>();
            while (reader.Read())
            {
                Users u = new Users();
                u.Id = (reader[0] + "");
                u.Uname = reader[1] + "";
                u.name = reader[2] + "";
                u.Pwd = (reader[3] + "");
                u.Sex = reader[4] + "";
                u.Address = reader[5] + "";
                u.Phone = reader[6] + "";
                u.Spell = reader[7] + "";
                u.Type = reader[8] + "";
                u.SectionRoom = reader[9] + "";
                u.money = Convert.ToInt32(reader[10] + "");
                u.Peodom = reader[11] + "";
                us.Add(u);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return us;
        }

        public void p_usersPeodom_update(string name, string str)
        {
            SqlParameter Uname = new SqlParameter("Uname", SqlDbType.VarChar);
            SqlParameter peodom = new SqlParameter("@peodom", SqlDbType.VarChar);
            Uname.Value = name;
            peodom.Value = str;
            DBHelper.ExecuteNonQueryProc("p_usersPeodom_update", Uname, peodom);

        }
        public string p_peodom_select(string uname)
        {
            string str = "";
            SqlParameter Uname = new SqlParameter("@Uname", SqlDbType.VarChar);
            Uname.Value = uname;
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_peodom_select", Uname);
            while (reader.Read())
            {
                str += (reader[0] + "");
                str += reader[1] + "";
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return str;
        }
        public void p_users_delete(string U)
        {
            SqlParameter Uid = new SqlParameter("@Uid", SqlDbType.Int);
            Uid.Value = int.Parse(U);
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_users_delete", Uid);
        }
        public string p_IdCard_select()
        {
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_IdCard_select1");
            string str = "";
            while (reader.Read())
            {
                str = (reader[0] + "");
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return str;
        }


    }
}
