using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class SectionRoomBLL
    {
        public string Chuan(SectionRoom s)
        {
            return new SectionRoomDAL().SectionRoomChuan(s);
        }

        public void Delete(SectionRoom s)
        {
            new SectionRoomDAL().SectionRoomDelte(s);
        }

        public void Update(SectionRoom s)
        {
            new SectionRoomDAL().SectionRoomUpdate(s);

        }
    }
}
