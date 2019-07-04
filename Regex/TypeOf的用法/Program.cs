using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TypeOf的用法
{

    public class MyFieldClassA
    {
        public string Field = "A Field";
    }

    public class MyFieldClassB
    {
        private string field = "B Field";
        public string Field
        {
            get
            {
                return field;
            }
            set
            {
                if (field != value)
                {
                    field = value;
                }
            }
        }
    }

    public class MyFieldInfoClass
    {
        public static void Main()
        {
            Test();
            MyFieldClassB myFieldObjectB = new MyFieldClassB();
            MyFieldClassA myFieldObjectA = new MyFieldClassA();

            Type myTypeA = typeof(MyFieldClassA);
            FieldInfo myFieldInfo = myTypeA.GetField("Field");

            Type myTypeB = typeof(MyFieldClassB);
            FieldInfo myFieldInfo1 = myTypeB.GetField("field",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("The value of the public field is: '{0}'",
                myFieldInfo.GetValue(myFieldObjectA));
            Console.WriteLine("The value of the private field is: '{0}'",
                myFieldInfo1.GetValue(myFieldObjectB));

            Console.ReadLine();
        }
        public static void Test()
        {
            MyFieldClassB myFieldObjectB = new MyFieldClassB();
            MyFieldClassA myFieldObjectA = new MyFieldClassA();

            Type myTypeB = typeof(MyFieldClassB);
            FieldInfo myFieldInfo1 = myTypeB.GetField("Field",
                BindingFlags.NonPublic | BindingFlags.Instance);
            
            Console.WriteLine("The value of the private field is: '{0}'",
                myFieldInfo1.GetValue(myFieldObjectB));

            Console.ReadLine();
        }
    }
}
