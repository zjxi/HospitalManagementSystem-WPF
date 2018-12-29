using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    /// <summary>
    /// 打印账单
    /// </summary>
    public class BillPrintBLL
    {
        BillPrintDAL billPrintDAL;

        public void SaveControl(List<MyControl> controls)
        {
            billPrintDAL = new BillPrintDAL();
            billPrintDAL.SaveControl(controls);
        }


        public DataTable ReadControl()
        {
            billPrintDAL = new BillPrintDAL();
            return billPrintDAL.ReadControl();
        }
    }
}
