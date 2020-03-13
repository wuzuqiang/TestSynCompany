using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExportAttribute
{
    public interface IBookService
    {
        string BookName { get; set; }
        string GetBookName();
    }
}
