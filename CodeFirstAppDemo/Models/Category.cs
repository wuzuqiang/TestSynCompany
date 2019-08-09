using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstAppDemo.Models
{
    /// <summary>
    /// 产品分类表
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public List<Product> ProductList { get; set; }
    }
}