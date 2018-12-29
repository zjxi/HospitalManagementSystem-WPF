using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class SectionRoomDAL
    {
        public void SectionRoomDelte(SectionRoom s)
        {
            SqlParameter Sname = new SqlParameter("@Sname", SqlDbType.VarChar);
            Sname.Value = s.Sname;
            bool f = DBHelper.ExecuteNonQueryProc("p_SectionRoom_Delete", Sname);
        }
        public string SectionRoomChuan(SectionRoom s)
        {
            SqlParameter Sname = new SqlParameter("@Sname", SqlDbType.VarChar);
            SqlParameter Saddr = new SqlParameter("@Saddr", SqlDbType.VarChar);
            SqlParameter Sprice = new SqlParameter("@Sprice", SqlDbType.Int);
            SqlParameter result = new SqlParameter("@result", SqlDbType.VarChar, 10);
            result.Direction = ParameterDirection.Output;
            Sname.Value = s.Sname;
            Saddr.Value = s.Saddr;
            Sprice.Value = s.Sprice;
            SqlParameter[] ps = { Sname, Saddr, Sprice, result };
            bool f = DBHelper.ExecuteNonQueryProc("p_SectionRoom", ps);
            if (f)
            {
                return 1 + "";
            }
            else
                return result + "";

        }
        public void SectionRoomUpdate(SectionRoom s)
        {
            SqlParameter Sname = new SqlParameter("@Sname", SqlDbType.VarChar);
            SqlParameter Saddr = new SqlParameter("@Saddr", SqlDbType.VarChar);
            SqlParameter Sprice = new SqlParameter("@Sprice", SqlDbType.Int);
            Sname.Value = s.Sname;
            Saddr.Value = s.Saddr;
            Sprice.Value = s.Sprice;
            SqlParameter[] ps = { Sname, Saddr, Sprice };
            DBHelper.ExecuteNonQueryProc("p_SectionRoom_Update", ps);
        }

    }
}
