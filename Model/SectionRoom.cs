using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SectionRoom
    {
        public int Sid { get; set; }
        public string Sname { get; set; }
        public string Saddr { get; set; }
        public int Sprice { get; set; }
        public override string ToString()
        {
            return Sname;
        }
    }
}
