using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Model;

namespace DAL
{
    public class RegisterDAL
    {
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
        public string RegistersDAL(Register r)
        {
            SqlParameter Rid = new SqlParameter("@Rid", SqlDbType.VarChar);
            SqlParameter Kid = new SqlParameter("@Kid", SqlDbType.VarChar);
            SqlParameter IdType = new SqlParameter("@IdType", SqlDbType.VarChar);
            SqlParameter GuaDanFei = new SqlParameter("@GuaDanFei", SqlDbType.Int);
            SqlParameter OtherFei = new SqlParameter("@OtherFei", SqlDbType.Int);
            SqlParameter SectionRoom = new SqlParameter("@SectionRoom", SqlDbType.VarChar);
            SqlParameter Doctor = new SqlParameter("@Doctor", SqlDbType.VarChar);
            SqlParameter ReristerTime = new SqlParameter("@ReristerTime", SqlDbType.DateTime);
            SqlParameter SeeDoctorTime = new SqlParameter("@SeeDoctorTime", SqlDbType.DateTime);
            SqlParameter mess = new SqlParameter("@mess", SqlDbType.VarChar, 10);
            mess.Direction = ParameterDirection.Output;
            Rid.Value = r.Rid;
            Kid.Value = r.KId;
            IdType.Value = r.IdType;
            GuaDanFei.Value = r.GuaDanFei;
            OtherFei.Value = r.OtherFei;
            SectionRoom.Value = r.SectionRoom;
            Doctor.Value = r.Doctor;
            ReristerTime.Value = r.ReristerTime;
            SeeDoctorTime.Value = r.SeeDoctorTime;
            SqlParameter[] pd = { Rid, Kid, IdType, GuaDanFei, OtherFei, SectionRoom, Doctor, ReristerTime, SeeDoctorTime, mess };
            bool f = DBHelper.ExecuteNonQueryProc("p_retister_insert", pd);
            if (f)
            {
                return mess.Value + "";
            }
            else
            {
                return "系统错误";
            }
        }
    }
}
