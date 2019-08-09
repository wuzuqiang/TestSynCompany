using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstAppDemo.EFDbContext;
using CodeFirstAppDemo.Models;

namespace CodeFirstAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用数据库上下文Context
            using (var context = new Context())
            {
                // 如果数据库不存在，则调用EF内置的API创建数据库
                if(context.Database.CreateIfNotExists())
                {
                    Console.WriteLine("数据库创建成功！");
                }
                else
                {
                    Console.WriteLine("数据库已存在");
                }
                #region EF 2查询数据
                #region
                //查询方式1
                var products = from p in context.Categorys select p;
                foreach (var item in products)
                {
                    Console.WriteLine("分类名称：" + item.CategoryName);
                }

                //查询方式2
                //延迟加载 cates里面没有数据
                var cates = context.Categorys;
                //执行迭代的时候才有数据
                foreach (var item in cates)
                {
                    Console.Write("分类名称：" + item.CategoryName);
                }
                var product1 = context.Products.OrderBy(a => a.Id)
                    .Where(t => t.ProductName == "");
                #endregion
                #endregion

                #region //EF添加数据
                //#region
                ////添加数据
                //var cate = new List<Category>
                //{
                //    new Category
                //    {
                //        CategoryName="文学类",
                //        ProductList = new List<Product>
                //        {
                //            new Product
                //            {
                //                ProductName = "百年孤独",
                //                Price = 37.53m,
                //                PublicDate = new DateTime(2011, 6, 1)
                //            },
                //            new Product
                //            {
                //                ProductName = "老人与海",
                //                Price = 37.53m,
                //                PublicDate = new DateTime(2010, 6, 1)
                //            }
                //        }
                //    },
                //    new Category
                //    {
                //        CategoryName = "计算机类",
                //        ProductList = new List<Product>
                //        {
                //            new Product
                //            {
                //                ProductName = "C#高级编程第九版",
                //                Price=48.23m,
                //                PublicDate = new DateTime(2016, 2, 8)
                //            },
                //            new Product
                //            {
                //                ProductName = "Oracle从入门到精通",
                //                Price = 27.03m,
                //                PublicDate = new DateTime(2014, 7, 9)
                //            }
                //        }
                //    }
                //};

                ////将创建的集合添加到上下文中
                //context.Categorys.AddRange(cate);
                ////调用SaveChanges()方法，将数据插入到数据库
                //context.SaveChanges();
                //#endregion
                #endregion

                #region //EF 更新数据
                //#region 
                //var products = context.Products;
                //if(products.Any())
                //{
                //    var product = context.Products.FirstOrDefault(a => a.ProductName == "百年孤独");
                //    if (product != null)
                //    {
                //        product.ProductName = "百年孤独，Not me";
                //    }
                //    context.SaveChanges();
                //}
                //#endregion
                #endregion

                #region EF 删除记录
                #region
                var product = context.Products.SingleOrDefault(a => a.ProductName == "老人与海");
                if(product != null)
                {
                    context.Products.Remove(product);
                    context.Entry(product).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                #endregion
                #endregion
            }

            Console.ReadKey();
        }
    }
}
