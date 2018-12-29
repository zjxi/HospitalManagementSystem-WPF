using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class SectionRoomSonDAL
    {
        List<SectionRoomSo> sw = new List<SectionRoomSo>();
        public string SonInsert(SectionRoomSo s)
        {
            SqlParameter Sname = new SqlParameter("@Sname", SqlDbType.VarChar);
            SqlParameter SonName = new SqlParameter("@Sonname", SqlDbType.VarChar);
            SqlParameter result = new SqlParameter("@result", SqlDbType.VarChar, 20);
            result.Direction = ParameterDirection.Output;
            Sname.Value = s.Sname;
            SonName.Value = s.SonSname;
            SqlParameter[] ps = { Sname, SonName, result };
            bool f = DBHelper.ExecuteNonQueryProc("p_SectionRooomSonInsert", ps);
            if (f)
            {
                return result.Value + "";
            }
            else
                return "出现异常";

        }
        public List<SectionRoomSo> SectionRoomSonCheck()
        {


            SqlDataReader reader = DBHelper.SectionRoomSelect("p_SectionRooomSon_select");
            while (reader.Read())
            {
                SectionRoomSo sr = new SectionRoomSo();
                sr.Sname = reader[1] + "";
                sr.SonSname = reader[2] + "";
                sw.Add(sr);
            }

            DBHelper.cmd.Dispose();
            DBHelper.reader.Dispose();
            DBHelper.con.Close();
            return sw;
        }
        public string SonDelteDal(SectionRoomSo s)
        {
            SqlParameter SonName = new SqlParameter("@SonName", SqlDbType.VarChar);
            SqlParameter result = new SqlParameter("@result", SqlDbType.VarChar, 20);
            result.Direction = ParameterDirection.Output;
            SonName.Value = s.SonSname;
            SqlParameter[] ps = { SonName, result };
            bool f = DBHelper.ExecuteNonQueryProc("p_SectionRooomSonDelete", ps);
            if (f)
            {
                return result.Value + "";
            }
            else
            {
                return "出现异常";
            }
        }
    }
}
