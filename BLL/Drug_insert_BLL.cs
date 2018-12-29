using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    /// <summary>
    /// 添加药品
    /// </summary>
    public class Drug_insert_BLL
    {
        public string Insert(Drug_insert di)
        {
            int re = new Drug_insert_DAL().Insert(di);
            if (re == 0)
                return "该药品已经存在";
            else if (re == 1)
                return "药品添加成功";
            else
                return "药品添加失败";
        }

        public List<Drug_insert> SelectAll(string Sname)
        {
            return new Drug_insert_DAL().SelectAll(Sname);
        }

        public string Update(Drug_insert di)
        {
            int re = new Drug_insert_DAL().Update(di);
            if (re == 0)
                return "药品修改成功";
            else
                return "药品修改失败";
        }

        public string Delete(Drug_insert di)
        {
            int re = new Drug_insert_DAL().Delete(di);
            if (re == 0)
                return "药品删除成功";
            else
                return "药品删除失败";
        }
    }
}
