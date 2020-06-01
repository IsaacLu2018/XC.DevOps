using System;

namespace GetModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // 获取数据库实例

            /*1. 在package manager console中执行  
             * 2.Scaffold-DbContext "Data Source=172.16.8.7;port=3306;Database=hz_xc_devops;User ID=root;Password=p@ssw0rd;CharSet=utf8;" -Provider "Pomelo.EntityFrameworkCore.MySql" -OutputDir DataBaseModel
             * 3.注意 记得把Default project 切换成GETModel
             */

            // 获取1DO数据库实例

            // Scaffold-DbContext "Data Source=59.202.68.48;port=3306;Database=do;User ID=reader;Password=123456;CharSet=utf8;" -Provider "Pomelo.EntityFrameworkCore.MySql" -OutputDir OneDoModels


            Console.WriteLine("Hello World!");
        }
    }
}
