using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类继承
{
    class Program
    {
        static void Main(string[] args)
        {
            继承自抽象类 class1 = new 继承自抽象类();
            继承自接口 class2 = new 继承自接口();
            //class1.Fun1();
            //class1.Fun2();
            //Random rd = (new System.Random());
            //for (int i = 0; i < 5; i++)
            //{
            //    class2[i] = rd.Next();
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(class2[i]);
            //}
            class2.SelectId += new SelectHandler(class1.FunEvent);
            class2.Fire();

            Console.ReadLine();
        }
    }
    public delegate void MyStudyEvent(object sender, EventArgs e);
    public class TestEvent
    {
        //私有委托变量
        private MyStudyEvent eMyStudyEvent;
        //add方法合并委托到eMyStudyEvent里面
        public void add_eMyStudyEvent(MyStudyEvent value)
        {
            MyStudyEvent event3;
            MyStudyEvent eMyStudyEvent = this.eMyStudyEvent;
            do
            {
                event3 = eMyStudyEvent;
                MyStudyEvent event4 = (MyStudyEvent)System.Delegate.Combine(event3, value);
                //eMyStudyEvent = Interlocked.CompareExchange<MyStudyEvent>(ref this.eMyStudyEvent, event4, event3)
            }
            while (eMyStudyEvent != event3);
        }

        //remove方法移除eMyStudyEvent里面已存在的委托  
        public void remove_eMyStudyEvent(MyStudyEvent value)
        {
            MyStudyEvent event3;
            MyStudyEvent eMyStudyEvent = this.eMyStudyEvent;
            do
            {
                event3 = eMyStudyEvent;
                MyStudyEvent event4 = (MyStudyEvent)System.Delegate.Remove(event3, value);
                //eMyStudyEvent = Interlocked.CompareExchange<MyStudyEvent>(ref this.eMyStudyEvent, event4, event3);
            }
            while (eMyStudyEvent != event3);
        }
    }
}
