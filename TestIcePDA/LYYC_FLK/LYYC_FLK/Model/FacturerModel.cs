using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class FacturerModel
    {
        public string FacturerCode { get; set; }
        public string FacturerName { get; set; }
        public string ProvinceName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
