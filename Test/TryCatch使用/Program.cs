using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatch使用
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            { }
            catch(InvalidOperationException ex)
            { }
            catch(Exception ex)
            { }
            //catch (InvalidProgramException ex)  //错误 CS0160  上一个 catch 子句已经捕获了此类型或超类型(“Exception”)的所有异常
            //{ }
            catch
            { }
        }
    }
}
