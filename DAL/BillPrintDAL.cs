using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Model;
using System.Data;


namespace DAL
{
    public class BillPrintDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
        //SqlCommand cmd;

        public void SaveControl(List<MyControl> controls)
        {
            DBHelper.ExecuteIUD("delete controlInfo");
            string sql = "insert controlInfo ";
            foreach (MyControl item in controls)
            {
                sql += " select '" + item.Name + "' , '" + item.CLocation + "' , '" + item.CFont + "' , '" + item.CColor + "' union ";
            }
            sql = sql.Substring(0, sql.LastIndexOf("union") - 1);
            DBHelper.ExecuteIUD(sql);
        }

        public DataTable ReadControl()
        {
            return DBHelper.ExecuteBatch("select * from controlinfo");
        }
    }
}
