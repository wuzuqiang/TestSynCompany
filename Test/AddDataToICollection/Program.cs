using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddDataToICollection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Model> models = new List<Model>();
            for(int i = 0; i < 3; i++)
            {
                models.Add(new Model(i.ToString()));
            }
            ModelSet modelSet = new ModelSet();
            modelSet.AddModels(models);
            List<Model> models1 = new List<Model>();
            for (int i = 0; i < 2; i++)
            {
                models1.Add(new Model("B" + i.ToString()));
            }
            modelSet.AddModels(models1);

            Console.ReadLine();
        }
    }
}
