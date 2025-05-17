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
    /// Kelas dasar untuk operasi manajemen resep
    /// </summary>
    public class Prescribe_BLL
    {
        // Kelas ini akan menjadi kelas dasar untuk operasi manajemen resep
    }

    /// <summary>
    /// Kelas untuk menambahkan catatan medis
    /// </summary>
    public class BingliInsertBLL : Prescribe_BLL
    {
        public string InsertBingli(Bingli bl)
        {
            int re = new Prescribe_DAL().Bingli_Insert(bl);
            if (re == 0)
                return "Catatan medis tersebut sudah ada";
            else if (re == 1)
                return "Berhasil menambahkan catatan medis";
            else
                return "Gagal menambahkan catatan medis";
        }
    }

    /// <summary>
    /// Kelas untuk menambahkan resep obat
    /// </summary>
    public class KaiyaoInsertBLL : Prescribe_BLL
    {
        public string InsertKaiyao(Kaiyao ky)
        {
            int re = new Prescribe_DAL().kaiyao_Insert(ky);
            if (re == 0)
                return "Resep obat tersebut sudah ada";
            else if (re == 1)
                return "Berhasil menambahkan resep obat";
            else
                return "Gagal menambahkan resep obat";
        }
    }

    /// <summary>
    /// Kelas untuk memilih semua kartu identitas
    /// </summary>
    public class IdCardSelectBLL : Prescribe_BLL
    {
        public List<IdCard> SelectAll(int kid)
        {
            return new Prescribe_DAL().SelectAll(kid);
        }
    }
}
