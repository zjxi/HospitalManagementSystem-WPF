using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 住院
    /// </summary>
    public class zhuyuan
    {
        public int kId { get; set; }
        public int Sid { get; set; }
        public int Idsickroom { get; set; }
        public string BedNo { get; set; }
        public int Imprest { get; set; }
        public string Bewrite { get; set; }
        public string Tabu { get; set; }
        public string Ztime { get; set; }
        public string Kname { get; set; }
    }
}
