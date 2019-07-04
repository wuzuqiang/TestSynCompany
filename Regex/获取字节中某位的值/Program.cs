using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 获取字节中某位的值
{
    class Program
    {
        static void Main(string[] args)
        {
            byte input = 0x35;

            //Console.WriteLine(" 52 & 32 = {0}", 52 & 32);
            Console.WriteLine("pictureBoxTemp2".IndexOf("pictureBoxTemp"));
            Console.WriteLine("1pic1Temp2".IndexOf("1pic1Temp"));
            Console.WriteLine("pictureBoxTemp2".IndexOf("BoxTemp"));
            Console.WriteLine("piicBoxTemp2".IndexOf("piicBoxTemp"));
            Console.WriteLine("pictureBoxTemp2".LastIndexOf("pictureBoxTemp"));
            Console.WriteLine("ANBoxTemp2".LastIndexOf("Temp"));

            //Fun();
            //int[] iArray = GetBitArray(input);
            //for (int i = 0; i < iArray.Length; i++)
            //{
            //    Console.WriteLine("0x{0:X000}中的第{1}位的值为{2}", input, i, iArray[i]);
            //}

            //for (index = 0; index < 16; index++)
            //    GetbitValue(input, index);

            //for (index = 0; index < 16; index++)
            //    GetBit(input, index);

            //for (index = 0; index < 16; index++)
            //    GetbitValue__3(input, index);

            //for (index = 0; index < 16; index++)
            //    GetbitValue__2(input, index);

            //for (index = 0; index < 16; index++)
            //    GetbitValue_1(input, index);

            Console.ReadLine();
        }

        private static void Fun()
        {
            //由字符串得到字节数组
            string strTestReciveData = "/44444555556666677777>";
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(strTestReciveData);
            foreach (byte bit in byteArray)
                Console.Write(string.Format( "0x{0:X000}", bit.ToString()) + "、");
            Console.WriteLine();
        }

        private static int GetbitValue_1(byte input, int index)
        {
            int value;
            value = index > 0 ? input >> index - 1 : input;
            value &= 1;
            Console.WriteLine("使用GetbitValue_1函数，0x{0:X000}中的第{1}位的值为{2}", input, index, value);
            return value;
        }

        private static int GetbitValue__2(byte input, int index)
        {
            int value;
            value = index > 0 ? input >> (index - 1) : input;
            value &= 1;
            Console.WriteLine("使用GetbitValue__2函数，0x{0:X000}中的第{1}位的值为{2}", input, index, value);
            return value;
        }

        private static int GetbitValue(byte input, int index)
        {
            int value;
            int iTemp = input >> index;
            Console.WriteLine("使用GetbitValue函数，__0x{0:X000}中的右移{1}位的值为0x{2:X000}", input, index, iTemp);
            value = index > 0 ? (iTemp) - 1 : input;
            value &= 1;
            Console.WriteLine("使用GetbitValue函数，0x{0:X000}中的第{1}位的值为0x{2:X000}", input, index, value);
            return value;
        }

        private static int GetbitValue__3(byte input, int index)
        {
            int value;
            int iTemp = input >> index;
            Console.WriteLine("使用GetbitValue__3函数，__0x{0:X000}中的右移{1}位的值为0x{2:X000}", input, index, iTemp);
            value = index > 0 ? (iTemp) : input;
            value &= 1;
            Console.WriteLine("使用GetbitValue__3函数，0x{0:X000}中的第{1}位的值为0x{2:X000}", input, index, value);
            return value;
        }

        //index从0开始 
        //获取取第index位 
        public static int GetBit(byte input, int index)
        {
            int result = (input & (1 << index));
            int value = (result > 0) ? 1 : 0;
            Console.WriteLine("使用GetBit函数，0x{0:X000}中的第{1}位的值为0x{2:X000}", input, index, value);
            return value;
        }
       
        /// <summary>
        /// 获取input中字节码从右(0)向左(7)存储在int[]中，int[0] = inputBitArray[7];
        /// </summary>
        /// <param name="input">一个16字节的1位</param>
        /// <returns></returns>
        public static int[] GetBitArray(byte input)
        {
            int[] iArray = new int[8];
            int index = 0;
            for (; index < 8; index++)
            {
                int result = (input & (1 << index));
                int value = (result > 0) ? 1 : 0;
                iArray[index] = value;
            }
            return iArray;
        }
    }
}
