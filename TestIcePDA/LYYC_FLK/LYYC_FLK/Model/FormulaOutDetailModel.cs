using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class FormulaOutDetailModel
    {
        public FormulaOutDetailModel() { }

        public FormulaOutDetailModel(string formulaCode, string insequence, string uniqueId)
        {
            this.FormulaCode = formulaCode;
            this.InSequence = insequence;
            this.UniqueId = uniqueId;
        }

        public string FormulaCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string InSequence { get; set; }
        public string Weight { get; set; }
        public string UniqueId { get; set; }

    }
}