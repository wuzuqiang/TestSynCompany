using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MEFDemo
{
    class Program
    {
        //[Import]
        public IBookService Service { get; set; }
        static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            if(pro.Service != null)
            {
                Console.WriteLine(pro.Service.GetBookName());
            }
            Console.WriteLine("go end");
            Console.Read();
        }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
