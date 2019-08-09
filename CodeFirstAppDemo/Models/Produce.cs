using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstAppDemo.Models
{
    /// <summary>
    /// 产品类
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 出版日期
        /// </summary>
        public DateTime PublicDate { get; set; }
    }
}