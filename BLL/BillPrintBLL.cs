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
    /// Kelas dasar untuk operasi Cetak Tagihan
    /// </summary>
    public class BillPrintBLL
    {
        protected BillPrintDAL billPrintDAL;

        public BillPrintBLL()
        {
            billPrintDAL = new BillPrintDAL();
        }
    }

    /// <summary>
    /// Kelas yang bertanggung jawab untuk menyimpan kontrol
    /// </summary>
    public class SaveControlBLL : BillPrintBLL
    {
        public void SaveControl(List<MyControl> controls)
        {
            billPrintDAL.SaveControl(controls);
        }
    }

    /// <summary>
    /// Kelas yang bertanggung jawab untuk membaca kontrol
    /// </summary>
    public class ReadControlBLL : BillPrintBLL
    {
        public DataTable ReadControl()
        {
            return billPrintDAL.ReadControl();
        }
    }
}

