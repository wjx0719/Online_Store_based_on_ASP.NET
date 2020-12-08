using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services
{
    static public class SQLtool
    {
        //windows身份验证连接本地SQL Server数据库
        public static string strcon = "Server=.;Database=Online Shopping;Trusted_Connection=SSPI";
        //SQL Server验证连接本地SQLServer数据库
        //public static string strcon = @"server=.;database=Online Shopping;Uid=;Pwd=";
    }
}