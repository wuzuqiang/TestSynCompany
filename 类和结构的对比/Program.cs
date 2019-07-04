using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类和结构的对比
{
    class Program
    {
        static void Main(string[] args)
        {
            Book a = new Book();
            a.title = "title";
            Class1 class1 = new Class1();
            class1.title = "ti";
            
        }
    }
    struct Book
    {
        decimal price;
        public string title;
        string author;
    }
    public class Class1
    {
        public string title;
        private string author;
        string content;
    }
}
