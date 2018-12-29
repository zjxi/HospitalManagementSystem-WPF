using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sickroom
    {
        /// <summary>
        /// --病房号
        /// </summary>
        public int Idsickroom { get; set; }

        /// <summary>
        /// --科别
        /// </summary>
        public int Sid { get; set; }

        /// <summary>
        /// --病房类型
        /// </summary>
        public string Tyep { get; set; }

        /// <summary>
        /// --价格
        /// </summary>
        public int Price { get; set; }
    }
}
