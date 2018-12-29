using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class IdCard
    {
        public int Kid { get; set; }
        public string Name { get; set; }                       //姓名
        public string Sex { get; set; }                           //性别
        public int Age { get; set; }                               //年龄
        public string Birthday { get; set; }                       //出生日期
        public string Address { get; set; }                  //地址
        public string Phone { get; set; }                       	   //电话
        public string Nation { get; set; }                   	 //民族
        public string Cultrue { get; set; }                  	 //文化
        public string Marriage { get; set; }                	 //婚姻状况
        public string Work { get; set; }                     //职业
        public string Postcode { get; set; }                    //邮编  
        public string IdcardNo { get; set; }               	//身份证号码
    }
}
