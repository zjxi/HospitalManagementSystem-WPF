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
    /// Kelas dasar untuk operasi manajemen kartu identitas
    /// </summary>
    public class IdCard_BLL
    {
        // Kelas ini akan menjadi kelas dasar untuk operasi manajemen kartu identitas
    }

    /// <summary>
    /// Kelas untuk registrasi kartu identitas
    /// </summary>
    public class IdCardRegistrationBLL : IdCard_BLL
    {
        public string Reg(IdCard ic)
        {
            int re = new IdCard_DAL().Reg(ic);
            if (re == 0)
                return "Kartu identitas ini sudah terdaftar untuk kartu hijau";
            else if (re == 1)
                return "Registrasi berhasil";
            else
                return "Registrasi gagal";
        }
    }

    /// <summary>
    /// Kelas untuk manajemen ruang sakit
    /// </summary>
    public class SickroomManagementBLL : IdCard_BLL
    {
        public string AssignSickroom(List<Sickroom> sect, int num)
        {
            return new IdCard_DAL().sickroom(sect, num);
        }

        public List<Sickroom> GetSickrooms()
        {
            return new IdCard_DAL().sickroom_select();
        }

        public string DeleteSickroom(List<Sickroom> sic)
        {
            return new IdCard_DAL().Delete(sic);
        }
    }

    /// <summary>
    /// Kelas untuk manajemen tempat tidur
    /// </summary>
    public class BedManagementBLL : IdCard_BLL
    {
        public List<Bed> GetBeds()
        {
            return new IdCard_DAL().Bed_select();
        }

        public void UpdateBed(int i, int j)
        {
            new IdCard_DAL().p_bed_update(i, j);
        }
    }

    /// <summary>
    /// Kelas untuk manajemen kontrol
    /// </summary>
    public class ControlManagementBLL : IdCard_BLL
    {
        public List<string> GetControls()
        {
            return new IdCard_DAL().controls_select();
        }
    }

    /// <summary>
    /// Kelas untuk manajemen rawat inap
    /// </summary>
    public class ZhuyuanManagementBLL : IdCard_BLL
    {
        public string InsertZhuyuan(zhuyuan zhu)
        {
            return new IdCard_DAL().p_zhuyuan_insert(zhu);
        }

        public List<zhuyuan> GetZhuyuans()
        {
            return new IdCard_DAL().p_zhuyuan_Select();
        }

        public void UpdateZhuyuanYujiao(int i, string s)
        {
            new IdCard_DAL().update_zhuyuan_yujiao(i, s);
        }
    }

    /// <summary>
    /// Kelas untuk manajemen biaya rawat inap
    /// </summary>
    public class ZhuyuanXiaofeiManagementBLL : IdCard_BLL
    {
        public void InsertZhuyuanXiaofei(List<zhuyuanxiaofei> xfs)
        {
            new IdCard_DAL().p_zhuyuanxiaofei_insert(xfs);
        }

        public List<zhuyuanxiaofei> GetZhuyuanXiaofei(int i)
        {
            return new IdCard_DAL().p_zhuyuanxiaofei_select(i);
        }

        public void DeleteZhuyuanXiaofei(int i, string str)
        {
            new IdCard_DAL().p_zhuyuanxiaofei_delete(i, str);
        }
    }

    /// <summary>
    /// Kelas untuk manajemen resep obat
    /// </summary>
    public class KaiyaoManagementBLL : IdCard_BLL
    {
        public List<Maidan> GetKaiyao()
        {
            return new IdCard_DAL().p_kaiyao_select();
        }

        public void UpdateKaiyao(string str)
        {
            new IdCard_DAL().p_kaiyao_update(str);
        }

        public void DeleteKaiyaoRegister(string str)
        {
            new IdCard_DAL().p_kaiyaoregister_delete(str);
        }
    }

    /// <summary>
    /// Kelas untuk manajemen statistik rawat inap
    /// </summary>
    public class ZhuayuanTongjiManagementBLL : IdCard_BLL
    {
        public void SelectZhuayuanTongji(zhuayuantongji zhu)
        {
            new IdCard_DAL().p_zhuayuantongji_select(zhu);
        }

        public List<zhuayuantongji> GetZhuayuanTongji()
        {
            return new IdCard_DAL().p_zhuayuantongji();
        }

        public void DeleteZhuayuanZhuyuanXiaofei(string str)
        {
            new IdCard_DAL().p_zhuyuanzhuyuanxiaofei_deleted(str);
        }
    }

    /// <summary>
    /// Kelas untuk manajemen tipe pengguna
    /// </summary>
    public class UsersTypeManagementBLL : IdCard_BLL
    {
        public string InsertUsersType(string name, string str)
        {
            return new IdCard_DAL().p_usersType_insert(name, str);
        }

        public List<UsersType> GetUsersTypes()
        {
            return new IdCard_DAL().p_usesType_select();
        }

        public void DeleteUsersType(string str)
        {
            new IdCard_DAL().p_usesType_delete(str);
        }

        public void UpdateUsersType(string name, string str)
        {
            new IdCard_DAL().p_usesType_update(name, str);
        }
    }

    /// <summary>
    /// Kelas untuk manajemen pengguna
    /// </summary>
    public class UsersManagementBLL : IdCard_BLL
    {
        public string InsertUser(Users u)
        {
            return new IdCard_DAL().p_users_insert(u);
        }

        public List<Users> GetUsers()
        {
            return new IdCard_DAL().p_users_select01();
        }

        public void UpdateUsersPeodom(string name, string str)
        {
            new IdCard_DAL().p_usersPeodom_update(name, str);
        }

        public string GetPeodom(string uname)
        {
            return new IdCard_DAL().p_peodom_select(uname);
        }

        public void DeleteUser(string Uid)
        {
            new IdCard_DAL().p_users_delete(Uid);
        }
    }

    /// <summary>
    /// Kelas untuk manajemen seleksi kartu identitas
    /// </summary>
    public class IdCardSelectManagementBLL : IdCard_BLL
    {
        public Dictionary<int, IdCard> GetIdCards(IdCard i)
        {
            return new IdCard_DAL().IdCardSelect(i);
        }

        public string GetIdCardSelect()
        {
            return new IdCard_DAL().p_IdCard_select();
        }
    }
}
