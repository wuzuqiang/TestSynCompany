using System;
using EQ2008;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Composition;

namespace Fusion.Project.SC.LZ.LED
{
    [Export]
    public class LEDUtil
    {
        private Dictionary<int, LEDData[]> LEDDataDic = new Dictionary<int, LEDData[]>();
        private Dictionary<int, DateTime> TimeStampDic = new Dictionary<int, DateTime>();

        private EQ2008Collection EQ2008Collection = new EQ2008Collection();
        private object syncLock = new object();

        public bool Sending(LEDData[] data)
        {
            lock (syncLock)
            {
                if (data != null && data.Length > 0)
                {
                    var tmp = data.Where(d => d != null).GroupBy(d => d.CardNum)
                        .Select(k => new { Key = k.Key, Data = k.Select(d => d).ToArray() })
                        .ToDictionary(d => d.Key, d => d.Data);

                    foreach (var item in tmp)
                    {
                        if (LEDDataDic.Keys.Contains(item.Key)
                            && TimeStampDic.Keys.Contains(item.Key)
                            && ((DateTime.Now.Subtract(TimeStampDic[item.Key]) < (new TimeSpan(0, 0, 3))
                                    && !LEDDataDic[item.Key].Except(item.Value, new LEDDataEqualityComparer()).Any()
                                    && !item.Value.Except(LEDDataDic[item.Key], new LEDDataEqualityComparer()).Any())
                                || DateTime.Now.Subtract(TimeStampDic[item.Key]) < (new TimeSpan(0, 0, 0, 0, 200))))
                        {
                            continue;
                        }

                        EQ2008Collection.ClearScreen();
                        if (item.Value.All(d => EQ2008Collection.AddToProgram(d)))
                        {
                            if (EQ2008Collection.SendToScreen())
                            {
                                if (LEDDataDic.Keys.Contains(item.Key))
                                {
                                    LEDDataDic[item.Key] = item.Value;
                                }
                                else
                                {
                                    LEDDataDic.Add(item.Key, item.Value);
                                }

                                if (TimeStampDic.Keys.Contains(item.Key))
                                {
                                    TimeStampDic[item.Key] = DateTime.Now;
                                }
                                else
                                {
                                    TimeStampDic.Add(item.Key, DateTime.Now);
                                }
                            }
                            else
                            {
                                throw new Exception("发送失败！");
                            }
                        }
                        else
                        {
                            throw new Exception("添加LED节目错误！");
                        }
                    }
                    return true;
                }
                else
                {
                    throw new Exception("数据为空或者数据格式不正确！");
                }
            }
        }
    }

    public class LEDDataEqualityComparer: IEqualityComparer<LEDData>
    {
        public bool Equals(LEDData x, LEDData y)
        {
            return JsonConvert.SerializeObject(x) == JsonConvert.SerializeObject(y);
        }

        public int GetHashCode(LEDData obj)
        {
            return JsonConvert.SerializeObject(obj).GetHashCode();
        }
    }

    public enum LedCardType
    {
        EQ2013,
        EQ2008
    }
}
