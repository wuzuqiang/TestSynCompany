#define Debug
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Console预处理指令
{
    class Program
    {
        static void Main(string[] args)
        {
#if Debug
            Console.WriteLine("运行单元测试模块");
#else
            Console.WriteLine("运行功能模块，返回输出结果！");
#endif

            Hashtable _hs = new Hashtable();
            _hs.Add("01", "_01");
            foreach(DictionaryEntry DE in _hs)
            {

            }

            IDictionaryEnumerator myEnum = _hs.GetEnumerator();
            while(myEnum.MoveNext())
            {
                //IDictionaryEnumerator继承IDictionary和IEnumerator 2个接口
                string str = _hs[myEnum.Key].ToString();
            }

            Array ar1;
            int[] ar = new int[3];
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(new int[] { 1, 2, 3, 4, 5 });

            Console.ReadLine();
        }
    }
}
