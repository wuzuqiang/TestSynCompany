using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class ScanBarModel
    {
        public ScanBarModel() { }
        public ScanBarModel(string barCode)
        {
            this.BarCode = barCode;
        }

        public string BarCode { get; set; }
        public int Count { get; set; }

        public void Add(ref List<ScanBarModel> model)
        {
            if (model.Count > 0)
            {
                var scModel = model.FirstOrDefault(it => it.BarCode == BarCode);
                if (scModel == null)
                {
                    model.Add(new ScanBarModel() { BarCode = BarCode, Count = 1 });
                }
                else
                {
                    scModel.Count++;
                }
            }
            else
            {
                model.Add(new ScanBarModel() { BarCode = BarCode, Count = 1 });
            }
        }
    }
}
