﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFDemo
{
    //[Export(typeof(IBookService))]
    public class MusicBook
    {
        public string BookName { get; set; }
        public string GetBookName()
        {
            return "MusicBook";
        }
    }
}
