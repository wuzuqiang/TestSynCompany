using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClientV1
{
    class Program
    {
        static void Main(string[] args)
        {
            Client.RunClientAsync().Wait();
        }
    }
}
