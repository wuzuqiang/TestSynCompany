using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectShowLib;

namespace WPFMediaKit.DirectShow
{
    public class VideoProcAmpRangeParameter
    {
        public VideoProcAmpProperty VideoProcAmpProperty
        {
            get;
            internal set;
        }

        public int MaxValue
        {
            get;
            internal set;
        }

        public int MinValue
        {
            get;
            internal set;
        }

        public int DefaultValue
        {
            get;
            internal set;
        }

        public int StepValue
        {
            get;
            internal set;
        }

        public VideoProcAmpFlags Flags
        {
            get;
            internal set;
        }

    }
}
