using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassUtils
{
    public static class ListUtil
    {
        /// <summary>
        /// 将List中的内容以int值类型降序处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listT"></param>
        /// <returns></returns>
        public static List<T> SortByDesc<T>(this List<T> listT) where T : struct
        {
            listT.Sort((h1, h2) =>
            {
                if (Convert.ToInt32(h1) < Convert.ToInt32(h2)) return 1; return -1; //左值小于右值，返回-1，为升序，如果返回1，就是降序
            });
            return listT;
        }

    }
}
