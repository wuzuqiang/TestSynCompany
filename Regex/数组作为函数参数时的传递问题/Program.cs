using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数组作为函数参数时的传递问题
{
    class Program
    {
        static int[] array = { 1, 1 };
        static void Main(string[] args)
        {
            #region //oper int[]
            ////int[] array = { 1, 1 };
            //printArray("    ", array);
            //tt1(array);
            //printArray("    ", array);
            //tt2(array);
            //printArray("    ", array);
            #endregion
            CClass[] cArr = { new CClass() };
            cArr[0].strA = "strA in Main";
            cArr[0].strB = "strB in Main";
            //cArr[0].iA = 0;
            //cArr[0].strB = 0;
            PrintClassArray(cArr);
            ChangeCArray(cArr);
            PrintClassArray(cArr);
            System.Console.ReadLine();
            /*这时，我们发现，当在函数内将数组变量指向新的数组时，原来函数外的数组并不该变。
             * 这是因为函数的参数传递的是数组的引用，所以在函数内对数组的元素做操作时
             * ，函数外的数组也会改变。但如果在函数内将数组变量指向新的数组
             * ，则函数内的数组变量不再指向函数外的数组区域。*/
        }
        #region tt1(int[] array)、tt2(int[] array)、printArray(string preDes, int[] array)
        public static void tt1(int[] array)
        {
            array[0] = array[0] + 1;
            int[] a = { array[0], array[1], 0 };
            array = a;
            printArray("In tt1 array：", array);
        }
        public static void tt2(int[] array)
        {
            array[1] = array[1] + 1;
            printArray("In tt2 array：", array);
        }
        //打印数组
        public static void printArray(string preDes, int[] array)
        {
            String s = preDes + "[";
            for (int i = 0; i < array.Length; i++)
            {
                s = s + " " + array[i];
            }
            s = s + "]";
            System.Console.WriteLine(s);
        }
        #endregion
        public static void ChangeCArray(CClass[] cArr)
        {
            CClass cATemp = new CClass();
            cATemp.strA = "strA in Fun";
            cATemp.strB = "strB in Fun";
            cATemp.iA = 3;
            cATemp.iB = 4;
            CClass[] cArrTemp = { cATemp };
            cArr = cArrTemp;
            //cArr[0] = cATemp; //此时会如自己想的那样变化
        }
        public static void PrintClassArray(CClass[] cArr)
        {
            foreach (CClass cC in cArr)
            {
                System.Console.WriteLine(string.Format("\t iA = {0}", cC.iA) + string.Format("\t iB = {0}", cC.iB));
                System.Console.WriteLine(string.Format("\tstrA = {0}", cC.strA) + string.Format("\tstrB = {0}", cC.strB));
            }
        }
    }
    public class CClass
    {
        public int iA;
        public int iB;
        public string strA;
        public string strB;
    }
}
