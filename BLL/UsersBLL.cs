using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class UsersBLL
    {
        public int Check(Users u)
        {
            return new UsersDAL().Chcek(u);
        }

        public List<SectionRoom> Section()
        {
            return new UsersDAL().p_SectionRoom_select();
        }

        public string RegisterRew(Register r)
        {
            return new RegisterDAL().RegistersDAL(r);
        }
    }
}
