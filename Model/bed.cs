using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    ///  病床
    /// </summary>
    public class Bed  
    {
        public int Idsickroom { get; set; }
        public int Idbed { get; set; }
        public int KId { get; set; }
        public string State { get; set; }
    }
}
