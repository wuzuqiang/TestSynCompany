using System;
using EQ2008;
using System.Linq;
using System.Collections.Generic;

namespace Fusion.Project.SC.LZ.LED
{
    public class LEDUtil
    {
        private Dictionary<int, LEDData[]> LEDDataDic = new Dictionary<int, LEDData[]>();
        private Dictionary<int, DateTime> TimeStampDic = new Dictionary<int, DateTime>();

        private EQ2008Collection EQ2008Collection = new EQ2008Collection();
        private object syncLock = new object();

        public bool Sending(LEDData data)
        {
            lock (syncLock)
            {
                EQ2008Collection.ClearScreen();
                return EQ2008Collection.AddToProgram(data);
            }
        }
    }

    public enum LedCardType
    {
        EQ2013,
        EQ2008
    }
}
