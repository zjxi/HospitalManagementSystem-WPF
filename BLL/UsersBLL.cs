using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    /// <summary>
    /// Kelas dasar untuk operasi manajemen pengguna
    /// </summary>
    public class UsersBLL
    {
        // Kelas ini akan menjadi kelas dasar untuk operasi manajemen pengguna
    }

    /// <summary>
    /// Kelas untuk memeriksa pengguna
    /// </summary>
    public class UserCheckBLL : UsersBLL
    {
        public int CheckUser(Users u)
        {
            return new UsersDAL().Chcek(u);
        }
    }

    /// <summary>
    /// Kelas untuk memilih ruang bagian
    /// </summary>
    public class SectionRoomSelectBLL : UsersBLL
    {
        public List<SectionRoom> GetSectionRooms()
        {
            return new UsersDAL().p_SectionRoom_select();
        }
    }

    /// <summary>
    /// Kelas untuk mendaftarkan ulang
    /// </summary>
    public class RegisterRewBLL : UsersBLL
    {
        public string Register(Register r)
        {
            return new RegisterDAL().RegistersDAL(r);
        }
    }
}
