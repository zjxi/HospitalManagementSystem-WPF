using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class Users
    {
        public string Id             { get; set; }              //用户编号          
        public string Uname          { get; set; }           //用户名    
        public string name           { get; set; }            //用户姓名
        public string Pwd           { get; set; }             //密码        	
        public string Sex                   { get; set; }             //性别        	
        public string Address       { get; set; }         //地址        	
        public string Phone          { get; set; }           //联系电话    	
        public string Spell             { get; set; }           //拼音码
        public string Type          { get; set; }            //类型  
        public string SectionRoom    { get; set; }     //
        public int    money            { get; set; }              //挂号费
        public string Peodom        { get; set; }          //权限     
    }
}
