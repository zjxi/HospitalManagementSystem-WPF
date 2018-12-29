using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Data;

namespace DAL
{
    public class Prescribe_DAL
    {
        public int Bingli_Insert(Bingli bl)
        {
            SqlParameter kId = new SqlParameter("@kId", SqlDbType.Int);
            SqlParameter Rid = new SqlParameter("@Rid", SqlDbType.VarChar);
            SqlParameter bing = new SqlParameter("@bing", SqlDbType.VarChar);
            SqlParameter zhusu = new SqlParameter("@zhusu", SqlDbType.VarChar);
            SqlParameter xianbingshi = new SqlParameter("@xianbingshi", SqlDbType.VarChar);
            SqlParameter jiwangbingshi = new SqlParameter("@jiwangbingshi", SqlDbType.VarChar);
            SqlParameter guominshi = new SqlParameter("@guominshi", SqlDbType.VarChar);
            SqlParameter geirenshi = new SqlParameter("@geirenshi", SqlDbType.VarChar);
            SqlParameter jiatingshi = new SqlParameter("@jiatingshi", SqlDbType.VarChar);
            SqlParameter tijian = new SqlParameter("@tijian", SqlDbType.VarChar);
            SqlParameter fuzhu = new SqlParameter("@fuzhu", SqlDbType.VarChar);
            SqlParameter zhiliaojianyi = new SqlParameter("@zhiliaojianyi", SqlDbType.VarChar);
            SqlParameter result = new SqlParameter("@result", SqlDbType.Int);
            result.Direction = ParameterDirection.Output;

            kId.Value = bl.kId;
            Rid.Value = bl.Rid;
            bing.Value = bl.bing;
            zhusu.Value = bl.zhusu;
            xianbingshi.Value = bl.xianbingshi;
            jiwangbingshi.Value = bl.jiwangbingshi;
            guominshi.Value = bl.guominshi;
            geirenshi.Value = bl.geirenshi;
            jiatingshi.Value = bl.jiatingshi;
            tijian.Value = bl.tijian;
            fuzhu.Value = bl.fuzhu;
            zhiliaojianyi.Value = bl.zhiliaojianyi;
            SqlParameter[] sp = { kId, Rid, bing, zhusu, xianbingshi, jiwangbingshi, guominshi, geirenshi, jiatingshi, tijian, fuzhu, zhiliaojianyi, result };
            bool f = DBHelper.ExecuteNonQueryProc("Bingli_insert", sp);
            if (f)
                return (int)result.Value;
            else
                return -1;
        }

        public int kaiyao_Insert(Kaiyao ky)
        {
            SqlParameter Rid = new SqlParameter("@Rid", SqlDbType.VarChar);
            SqlParameter kId = new SqlParameter("@kId", SqlDbType.Int);
            SqlParameter yaopinName = new SqlParameter("@yaopinName", SqlDbType.VarChar);
            SqlParameter zhuangtai = new SqlParameter("@zhuangtai", SqlDbType.VarChar);
            SqlParameter yizhu = new SqlParameter("@yizhu", SqlDbType.VarChar);
            SqlParameter yongfa = new SqlParameter("@yongfa", SqlDbType.VarChar);
            SqlParameter result = new SqlParameter("@result", SqlDbType.Int);
            result.Direction = ParameterDirection.Output;

            Rid.Value = ky.Rid;
            kId.Value = ky.Kid;
            yaopinName.Value = ky.yaopinName;
            zhuangtai.Value = ky.zhuangtai;
            yizhu.Value = ky.yizhu;
            yongfa.Value = ky.yongfa;
            SqlParameter[] sp = { kId, Rid, yaopinName, zhuangtai, yizhu, yongfa, result };
            bool f = DBHelper.ExecuteNonQueryProc("kaiyao_insert", sp);
            if (f)
                return (int)result.Value;
            else
                return -1;
        }

        public List<IdCard> SelectAll(int kid)
        {
            List<IdCard> di = new List<IdCard>();
            SqlParameter pid = new SqlParameter("@kid", SqlDbType.Int);
            pid.Value = kid;
            bool f = DBHelper.ExecuteBatchProc("IdCard_S_select", pid);
            if (f == true)
            {
                while (DBHelper.reader.Read())
                {
                    IdCard idc = new IdCard();
                    idc.Name = DBHelper.reader["name"] + "";
                    idc.Sex = DBHelper.reader["sex"] + "";
                    idc.Age = Convert.ToInt32(DBHelper.reader["age"]);
                    idc.Address = DBHelper.reader["address"] + "";
                    di.Add(idc);
                }
            }
            DBHelper.con.Close();
            DBHelper.reader.Dispose();
            DBHelper.cmd.Dispose();
            DBHelper.con.Dispose();

            return di;
        }
    }
}
