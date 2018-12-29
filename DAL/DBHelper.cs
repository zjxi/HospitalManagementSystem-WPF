using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DBHelper
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd = null;
        public static SqlDataReader reader;
        public static bool ExecuteNonQueryProc(string pName, params SqlParameter[] sp)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
                con.Open();
                cmd = new SqlCommand(pName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sp);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
        }
        //用户查询的方法
        public bool UsersSelect(string pName, params SqlParameter[] ps)   
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
                con.Open();
                cmd = new SqlCommand(pName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(ps);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }

        }
        //从数据库读取信息
        public static SqlDataReader SectionRoomSelect(string pName, params SqlParameter[] ps)               //多条查询
        {
            con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
            con.Open();
            cmd = new SqlCommand(pName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(ps);
            return reader = cmd.ExecuteReader();

        }
        //用户登录验证
        public int LoginCheck(string Account, string pwd)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
                con.Open();
                SqlCommand cmd = new SqlCommand("p_LoginCheck", con);
                cmd.Parameters.Add(new SqlParameter("@Account", 1) { Value = Account });
                cmd.Parameters.Add(new SqlParameter("@pwd", 1) { Value = pwd });
                cmd.CommandType = CommandType.StoredProcedure;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        // ************
        public static void ExecuteIUD(string sql)
        {
            SqlConnection con = null;
            try
            {
                //读取App.config中key为str的value值
                con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            //catch
            //{ }
            finally
            {
                con.Close();
            }

        }

        public static object ExecuteScalar(string sql)
        {
            con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object obj = cmd.ExecuteScalar();
            con.Close();
            return obj;

        }

        public static DataTable ExecuteBatch(string sql)
        {
            con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //批量查询
        public static bool ExecuteBatchProc(string pName, params SqlParameter[] sp)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
                con.Open();
                cmd = new SqlCommand(pName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sp);
                reader = cmd.ExecuteReader();
                return true;
            }
            finally { }
        }


    }
}
