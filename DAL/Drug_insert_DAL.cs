using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class Drug_insert_DAL
    {
        public int Insert(Drug_insert di)
        {
            SqlParameter Dname        = new SqlParameter("@DName", SqlDbType.VarChar);
            SqlParameter Dtype        = new SqlParameter("@Dtype", SqlDbType.VarChar);
            SqlParameter DcostName    = new SqlParameter("@DcostName", SqlDbType.VarChar);
            SqlParameter Dspec        = new SqlParameter("@Dspec", SqlDbType.VarChar);
            SqlParameter DjiXing      = new SqlParameter("@DjiXing", SqlDbType.VarChar);
            SqlParameter DinsertPrice = new SqlParameter("@DinsertPrice", SqlDbType.Int);
            SqlParameter DsellPrice   = new SqlParameter("@DsellPrice", SqlDbType.Int);
            SqlParameter Dstock       = new SqlParameter("@Dstock", SqlDbType.Int);
            SqlParameter DstockMax    = new SqlParameter("@DstockMax", SqlDbType.Int);
            SqlParameter DstockMin    = new SqlParameter("@DstockMin", SqlDbType.Int);
            SqlParameter DeffectTime  = new SqlParameter("@DeffectTime", SqlDbType.SmallDateTime);
            SqlParameter DproductTime = new SqlParameter("@DproductTime", SqlDbType.SmallDateTime);
            SqlParameter Efficay      = new SqlParameter("@Efficay", SqlDbType.VarChar);
            SqlParameter result       = new SqlParameter("@result", SqlDbType.Int);
            result.Direction = ParameterDirection.Output;

            Dname.Value = di.Dname;
            Dtype.Value = di.Dtype;
            DcostName.Value = di.DcostName;
            Dspec.Value = di.Dspec;
            DjiXing.Value = di.DjiXing;
            DinsertPrice.Value = di.DinsertPrice;
            DsellPrice.Value = di.DsellPrice;
            Dstock.Value = di.Dstock;
            DstockMax.Value = di.DstockMax;
            DstockMin.Value = di.DstockMin;
            DeffectTime.Value = di.DeffectTime;
            DproductTime.Value = di.DproductTime;
            Efficay.Value = di.Efficay;
            SqlParameter[] sp = { Dname, Dtype, DcostName, Dspec, DjiXing, DinsertPrice, DsellPrice, Dstock, DstockMax, DstockMin, DeffectTime, DproductTime, Efficay, result };
            bool f = DBHelper.ExecuteNonQueryProc("Drug_insert_p", sp);
            if (f)
                return (int)result.Value;
            else
                return -1;
        }

        public List<Drug_insert> SelectAll(string Sname)
        {
            List<Drug_insert> di = new List<Drug_insert>();
            SqlParameter pid = new SqlParameter("@Dname", SqlDbType.VarChar);
            pid.Value = Sname;
            bool f = DBHelper.ExecuteBatchProc("Drug_SelectName_p", pid);
            if (f == true)
            {
                while (DBHelper.reader.Read())
                {
                    Drug_insert dri = new Drug_insert();
                    dri.Dname = DBHelper.reader["Dname"] + "";
                    dri.Dtype = DBHelper.reader["Dtype"] + "";
                    dri.DcostName = DBHelper.reader["DcostName"] + "";
                    dri.Dspec = DBHelper.reader["Dspec"] + "";
                    dri.DjiXing = DBHelper.reader["DjiXing"] + "";
                    dri.DinsertPrice = Convert.ToInt32(DBHelper.reader["DinsertPrice"]);
                    dri.DsellPrice = Convert.ToInt32(DBHelper.reader["DsellPrice"]);
                    dri.Dstock = Convert.ToInt32(DBHelper.reader["Dstock"]);
                    dri.DstockMax = Convert.ToInt32(DBHelper.reader["DstockMax"]);
                    dri.DstockMin = Convert.ToInt32(DBHelper.reader["DstockMin"]);
                    dri.DeffectTime = DBHelper.reader["DeffectTime"] + "";
                    dri.DproductTime = DBHelper.reader["DproductTime"] + "";
                    dri.Efficay = DBHelper.reader["Efficay"] + "";
                    di.Add(dri);
                }
            }
            DBHelper.con.Close();
            DBHelper.reader.Dispose();
            DBHelper.cmd.Dispose();
            DBHelper.con.Dispose();

            return di;
        }

        public int Update(Drug_insert di)
        {
            SqlParameter Dname = new SqlParameter("@DName", SqlDbType.VarChar);
            SqlParameter Dtype = new SqlParameter("@Dtype", SqlDbType.VarChar);
            SqlParameter DcostName = new SqlParameter("@DcostName", SqlDbType.VarChar);
            SqlParameter Dspec = new SqlParameter("@Dspec", SqlDbType.VarChar);
            SqlParameter DjiXing = new SqlParameter("@DjiXing", SqlDbType.VarChar);
            SqlParameter DinsertPrice = new SqlParameter("@DinsertPrice", SqlDbType.Int);
            SqlParameter DsellPrice = new SqlParameter("@DsellPrice", SqlDbType.Int);
            SqlParameter Dstock = new SqlParameter("@Dstock", SqlDbType.Int);
            SqlParameter DstockMax = new SqlParameter("@DstockMax", SqlDbType.Int);
            SqlParameter DstockMin = new SqlParameter("@DstockMin", SqlDbType.Int);
            SqlParameter DeffectTime = new SqlParameter("@DeffectTime", SqlDbType.SmallDateTime);
            SqlParameter DproductTime = new SqlParameter("@DproductTime", SqlDbType.SmallDateTime);
            SqlParameter Efficay = new SqlParameter("@Efficay", SqlDbType.VarChar);

            Dname.Value = di.Dname;
            Dtype.Value = di.Dtype;
            DcostName.Value = di.DcostName;
            Dspec.Value = di.Dspec;
            DjiXing.Value = di.DjiXing;
            DinsertPrice.Value = di.DinsertPrice;
            DsellPrice.Value = di.DsellPrice;
            Dstock.Value = di.Dstock;
            DstockMax.Value = di.DstockMax;
            DstockMin.Value = di.DstockMin;
            DeffectTime.Value = di.DeffectTime;
            DproductTime.Value = di.DproductTime;
            Efficay.Value = di.Efficay;
            SqlParameter[] sp = { Dname, Dtype, DcostName, Dspec, DjiXing, DinsertPrice, DsellPrice, Dstock, DstockMax, DstockMin, DeffectTime, DproductTime, Efficay };
            bool f = DBHelper.ExecuteNonQueryProc("Drug_update_p", sp);
            if (f)
                return 0; //(int)result.Value;
            else
                return -1;
        }

        public int Delete(Drug_insert di)
        {
            SqlParameter Dname = new SqlParameter("@DName", SqlDbType.VarChar);

            Dname.Value = di.Dname;
            SqlParameter[] sp = { Dname };
            bool f = DBHelper.ExecuteNonQueryProc("Drug_Delete_p", sp);
            if (f)
                return 0; //(int)result.Value;
            else
                return -1;
        }
    }
}
