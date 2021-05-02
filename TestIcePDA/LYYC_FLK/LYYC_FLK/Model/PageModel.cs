using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public static class PageModel
    {
        public static int Page = 1;

        public static int Limit = 10;

        public static int TotalCount = 0;

        public static int PageCount = 0;

        public static void Init()
        {
            Page = 1;
        }

        public static bool ToBeforePage()
        {
            if (Page > 1)
            {
                return true;
            }
            return false;
        }
        public static bool ToNextPage()
        {
            if (PageCount > Page)
            {
                return true;
            }
            return false;
        }

        public static void PageOperator(bool isAdd)
        {
            if (isAdd)
            {
                Page++;
            }
            else
            {
                Page--;
            }
        }

        public static void Arrival(int toPage)
        {
            if (toPage > PageCount)
            {
                Page = PageCount;
            }
            else if (toPage <= 0)
            {
                Page = 1;
            }
            else
            {
                Page = toPage;
            }
        }
    }
}
