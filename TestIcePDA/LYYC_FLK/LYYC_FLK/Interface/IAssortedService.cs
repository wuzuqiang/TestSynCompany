using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusion.LYYC.PDA.Scanner.Model;

namespace Fusion.LYYC.PDA.Scanner.Interface
{
    public interface IAssortedService
    {
        List<MatchPalletPlanModel> GetMathPalletByHttp();
        void AddAssorted(string mathPallet, string barCode);
    }
}
