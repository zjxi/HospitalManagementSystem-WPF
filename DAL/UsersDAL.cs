using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAL
{
    public class UsersDAL
    {
        /// <summary>
        /// 用户名时候的sql语句
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int Chcek(Users u)      
        {
            SqlParameter Uname = new SqlParameter("@uname", SqlDbType.VarChar);
            SqlParameter Pwd = new SqlParameter("@pwd", SqlDbType.VarChar);
            SqlParameter result = new SqlParameter("@return", SqlDbType.Int);
            result.Direction = ParameterDirection.Output;
            Uname.Value = u.Uname;
            Pwd.Value = u.Pwd;
            SqlParameter[] ps = { Uname, Pwd, result };
            bool f = new DBHelper().UsersSelect("p_users_select", ps);
            if (f)
            {
                return int.Parse(result.Value + "");
            }
            else
            {
                return 3;
            }

        }
        /// <summary>
        /// 科室查询
        /// </summary>
        /// <returns></returns>
        public List<SectionRoom> p_SectionRoom_select()                  
        {
            List<SectionRoom> section = new List<SectionRoom>();
            SqlDataReader reader = DBHelper.SectionRoomSelect("p_SectionRoom_select");
            while (reader.Read())
            {
                SectionRoom ses = new SectionRoom();
                ses.Sname = reader[1] + "";
                ses.Saddr = reader[2] + "";
                ses.Sprice = int.Parse(reader[3] + "");
                section.Add(ses);
            }
            DBHelper.con.Close();
            DBHelper.con.Dispose();
            DBHelper.cmd.Dispose();
            return section;
        }
    }
}
