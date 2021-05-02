using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class MatchPalletPlanModel
    {
        public string MatchPalletPlanNo { get; set; }
        public string MatchPalletCode { get; set; }
        public string MatchPalletName { get; set; }
        public int PalletType { get; set; }
        public string PalletTypeName { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public DateTime PlanDate { get; set; }
    }
}
