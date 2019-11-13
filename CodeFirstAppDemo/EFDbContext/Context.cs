using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstAppDemo.Models;

namespace CodeFirstAppDemo.EFDbContext
{
    public class Context:DbContext
    {
        /// <summary>
        /// 1.创建构造函数，构造函数继承DbContext类的构造函数，通过DbContext类的构造函数创建数据库连接
        /// 2.DbContext类的构造函数里面的参数是数据库连接字符串，通过连接字符串去创建数据库
        /// </summary>
        public Context()
            :base("name=CodeFirstApp")
        {
            this.Database.Log = (sql) =>
            {
                if (string.IsNullOrEmpty(sql) == false)
                {
                    Console.WriteLine("************sql执行*************");
                    Console.WriteLine(sql);
                    Console.WriteLine("************sql结束************");
                }
            };
        }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
