﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            (new ClientSocket()).ClientCommunicateServer();
            Console.WriteLine("=================");
            Console.Read();
        }
    }
}
