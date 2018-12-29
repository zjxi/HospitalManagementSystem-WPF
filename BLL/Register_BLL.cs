using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class Register_BLL
    {
        public List<Register> SelectAll()
        {
            return new Register_DAL().SelectAll();
        }
    }
}
