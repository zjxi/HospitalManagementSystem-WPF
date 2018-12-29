using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class Register_DAL
    {
        public List<Register> SelectAll()
        {
            List<Register> lRegi = new List<Register>();
            bool f = DBHelper.ExecuteBatchProc("p_retister_select");
            if (f == true)
            {
                while (DBHelper.reader.Read())
                {
                    Register Regi = new Register();
                    Regi.Rid = DBHelper.reader["Rid"] + "";
                    Regi.KId = Convert.ToInt32(DBHelper.reader["Kid"]);
                    Regi.IdType = DBHelper.reader["IdType"] + "";
                    Regi.GuaDanFei = Convert.ToInt32(DBHelper.reader["GuaDanFei"]);
                    Regi.OtherFei = Convert.ToInt32(DBHelper.reader["OtherFei"]);
                    Regi.SectionRoom = DBHelper.reader["SectionRoom"] + "";
                    Regi.Doctor = DBHelper.reader["Doctor"] + "";
                    Regi.ReristerTime = DBHelper.reader["ReristerTime"] + "";
                    Regi.SeeDoctorTime = DBHelper.reader["SeeDoctorTime"] + "";
                    lRegi.Add(Regi);
                }
            }
            DBHelper.con.Close();
            DBHelper.reader.Dispose();
            DBHelper.cmd.Dispose();
            DBHelper.con.Dispose();

            return lRegi;
        }
    }
}
