using System;

namespace Fusion.LYYC.PDA.Scanner.Model
{
     [Serializable]
    public class SearchModel
    {
        public string property { get; set; }
        public string @operator { get; set; }
        public string value { get; set; }
    }
}
