using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 各项医疗纪录
    /// </summary>
    public class Register
    {
        public string Rid { get; set; }        //挂单号
        public int KId { get; set; }        //卡号
        public string IdType { get; set; }        //号类
        public int GuaDanFei { get; set; }        //挂单费
        public int OtherFei { get; set; }        //其他费 
        public string SectionRoom { get; set; }        //科室
        public string Doctor { get; set; }        //医师
        public string ReristerTime { get; set; }        //挂号日期
        public string SeeDoctorTime { get; set; }        //就诊日期
    }
}
