using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Fusion.LYYC.PDA.Scanner.Tools
{
    public class SerizlizableTool
    {
        public static void ToSerizalbe<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                FileStream fileStream = null;
                fileStream = new FileStream(obj + ".txt", FileMode.Create);
                CompactFormatter.CompactFormatter ser = new CompactFormatter.CompactFormatter();
                ser.Serialize(ms, obj);
            }
        }

        public static void ToSerizalbeDess<T>(T obj)
        {
            //using (MemoryStream ms = new MemoryStream(binBuffer))
            //{
            //    CompactFormatter.CompactFormatter ser = new CompactFormatter.CompactFormatter();
            //    obj = ser.Deserialize(ms) as T[];
            //}
        }
    }
}
