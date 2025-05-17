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
    /// Kelas dasar untuk operasi manajemen obat
    /// </summary>
    public class Drug_insert_BLL
    {
        // Kelas ini akan menjadi kelas dasar untuk operasi manajemen obat
    }

    /// <summary>
    /// Kelas untuk menambahkan obat
    /// </summary>
    public class DrugInsertBLL : Drug_insert_BLL
    {
        public string Insert(Drug_insert di)
        {
            int re = new Drug_insert_DAL().Insert(di);
            if (re == 0)
                return "Obat tersebut sudah ada";
            else if (re == 1)
                return "Obat berhasil ditambahkan";
            else
                return "Gagal menambahkan obat";
        }
    }

    /// <summary>
    /// Kelas untuk memilih semua obat
    /// </summary>
    public class DrugSelectBLL : Drug_insert_BLL
    {
        public List<Drug_insert> SelectAll(string Sname)
        {
            return new Drug_insert_DAL().SelectAll(Sname);
        }
    }

    /// <summary>
    /// Kelas untuk memperbarui obat
    /// </summary>
    public class DrugUpdateBLL : Drug_insert_BLL
    {
        public string Update(Drug_insert di)
        {
            int re = new Drug_insert_DAL().Update(di);
            if (re == 0)
                return "Obat berhasil diperbarui";
            else
                return "Gagal memperbarui obat";
        }
    }

    /// <summary>
    /// Kelas untuk menghapus obat
    /// </summary>
    public class DrugDeleteBLL : Drug_insert_BLL
    {
        public string Delete(Drug_insert di)
        {
            int re = new Drug_insert_DAL().Delete(di);
            if (re == 0)
                return "Obat berhasil dihapus";
            else
                return "Gagal menghapus obat";
        }
    }
}
