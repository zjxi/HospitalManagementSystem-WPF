using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class Prescribe_BLL
    {
        /// <summary>
        /// 添加病历
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        public string Bingli_Insert(Bingli bl)
        {
            int re = new Prescribe_DAL().Bingli_Insert(bl);
            if (re == 0)
                return "该病历已经存在";
            else if (re == 1)
                return "提交病历成功";
            else
                return "提交病历失败";
        }

        /// <summary>
        /// 添加药方
        /// </summary>
        /// <param name="ky"></param>
        /// <returns></returns>
        public string kaiyao_Insert(Kaiyao ky)
        {
            int re = new Prescribe_DAL().kaiyao_Insert(ky);
            if (re == 0)
                return "该药方已经存在";
            else if (re == 1)
                return "提交药方成功";
            else
                return "提交药方失败";
        }

        public List<IdCard> SelectAll(int kid)
        {
            return new Prescribe_DAL().SelectAll(kid);
        }
    }
}
