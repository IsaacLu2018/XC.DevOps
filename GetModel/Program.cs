using System;

namespace GetModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // 在package manager console中执行  
            // Scaffold-DbContext "Data Source=172.16.8.7;port=3306;Database=hz_xc_devops;User ID=root;Password=p@ssw0rd;CharSet=utf8;" -Provider "Pomelo.EntityFrameworkCore.MySql" -OutputDir DataBaseModel
            // 注意 记得把Default project 切换成GETModel

            Console.WriteLine("Hello World!");
        }
    }
}
