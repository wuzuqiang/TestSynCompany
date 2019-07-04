using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMediaKit.DirectShow.MediaPlayers
{
    /// <summary>
    /// IAMVideoProcAmp管理类
    /// 包括属性提取，设置
    /// 属性为<see cref="VideoProcAmpProperty"/>枚举中的一项
    /// </summary>
    public class VideoProcAmpSetter
    {
        private readonly IAMVideoProcAmp _videoProcAmp;
        private Dictionary<VideoProcAmpProperty, VideoProcAmpRangeParameter> _propertyToRangeParameter =
            new Dictionary<VideoProcAmpProperty, VideoProcAmpRangeParameter>();

        public VideoProcAmpSetter(IAMVideoProcAmp videoProcAmp)
        {
            this._videoProcAmp = videoProcAmp;
        }
        /// <summary>
        /// 获取属性单值
        /// </summary>
        /// <param name="videoProcAmpProperty"></param>
        /// <returns></returns>
        public int GetParameterValue(VideoProcAmpProperty videoProcAmpProperty)
        {
            int iret = 0;

            try
            {
                int hr = this._videoProcAmp.Get(videoProcAmpProperty, out int getValue, out VideoProcAmpFlags videoProcAmpFlags);
                string s = DsError.GetErrorText(hr);
                iret = getValue;
            }
            catch (Exception)
            {

            }
            return iret;
        }
        public void CheckSupportProperty()
        {
            int getValue;
            VideoProcAmpFlags videoProcAmpFlags;
            string s = string.Empty;
            int hr = this._videoProcAmp.Get(VideoProcAmpProperty.Brightness, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.Contrast, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.Hue, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.Saturation, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.Sharpness, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.Gamma, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.ColorEnable, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.WhiteBalance, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.BacklightCompensation, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.Get(VideoProcAmpProperty.Gain, out getValue, out videoProcAmpFlags);
            s = DsError.GetErrorText(hr);
            #region GetRange
            int pMin; int pMax; int pSteppingDelta; int pDefault; VideoProcAmpFlags pCapsFlags;
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.Brightness, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.Contrast, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.Hue, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.Saturation, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.Sharpness, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.Gamma, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.ColorEnable, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.WhiteBalance, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.BacklightCompensation, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._videoProcAmp.GetRange(VideoProcAmpProperty.Gain, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);

            #endregion
        }
        /// <summary>
        /// 获取可设置范围值
        /// </summary>
        /// <param name="videoProcAmpProperty"></param>
        /// <returns></returns>
        public VideoProcAmpRangeParameter GetRangeParameterValue(VideoProcAmpProperty videoProcAmpProperty)
        {
            VideoProcAmpRangeParameter videoProcAmpRangeParameter = null;
            try
            {
                int hr = this._videoProcAmp.GetRange(videoProcAmpProperty,
                    out int min,
                    out int max,
                    out int step,
                    out int defaultValue,
                    out VideoProcAmpFlags videoProcAmpFlags);
                string sss = DsError.GetErrorText(hr);
                if (hr == 0)
                {
                    videoProcAmpRangeParameter = new VideoProcAmpRangeParameter
                    {
                        VideoProcAmpProperty = videoProcAmpProperty,
                        MinValue = min,
                        MaxValue = max,
                        StepValue = step,
                        DefaultValue = defaultValue,
                        Flags = videoProcAmpFlags
                    };
                    //加入字典
                    if (_propertyToRangeParameter.ContainsKey(videoProcAmpProperty))
                    {
                        _propertyToRangeParameter[videoProcAmpProperty] = videoProcAmpRangeParameter;
                    }
                    else
                    {
                        _propertyToRangeParameter.Add(videoProcAmpProperty, videoProcAmpRangeParameter);
                    }
                }
            }
            catch (Exception)
            {

            }
            return videoProcAmpRangeParameter;
        }
        /// <summary>
        /// 设置VideoProcAmpProperty的值
        /// 有做有效值判断
        /// </summary>
        /// <param name="videoProcAmpProperty"></param>
        /// <param name="perpertyValue"></param>
        public void SetParameterValue(VideoProcAmpProperty videoProcAmpProperty, int perpertyValue)
        {
            if (_propertyToRangeParameter.ContainsKey(videoProcAmpProperty) || this.GetRangeParameterValue(videoProcAmpProperty) != null)
            {
                VideoProcAmpRangeParameter videoProcAmpRangeParameter = _propertyToRangeParameter[videoProcAmpProperty];
                int ensureValue = Math.Min(Math.Max(videoProcAmpRangeParameter.MinValue, perpertyValue), videoProcAmpRangeParameter.MaxValue);
                this._videoProcAmp.Set(videoProcAmpProperty, ensureValue, VideoProcAmpFlags.Manual);
            }
        }
        /// <summary>
        /// 设置VideoProcAmpProperty的Auto值
        /// 有做有效值判断
        /// </summary>
        /// <param name="videoProcAmpProperty"></param>
        /// <param name="perpertyValue"></param>
        public void SetAutoParameterValue(VideoProcAmpProperty videoProcAmpProperty, int perpertyValue)
        {
            if (_propertyToRangeParameter.ContainsKey(videoProcAmpProperty) || this.GetRangeParameterValue(videoProcAmpProperty) != null)
            {
                VideoProcAmpRangeParameter videoProcAmpRangeParameter = _propertyToRangeParameter[videoProcAmpProperty];
                int ensureValue = perpertyValue;
                int hr = this._videoProcAmp.Set(videoProcAmpProperty, ensureValue, VideoProcAmpFlags.Auto);
            }
        }
        /// <summary>
        /// 设置VideoProcAmpProperty的Mannual值
        /// 有做有效值判断
        /// </summary>
        /// <param name="videoProcAmpProperty"></param>
        /// <param name="perpertyValue"></param>
        public void SetManualParameterValue(VideoProcAmpProperty videoProcAmpProperty, int perpertyValue)
        {
            if (_propertyToRangeParameter.ContainsKey(videoProcAmpProperty) || this.GetRangeParameterValue(videoProcAmpProperty) != null)
            {
                VideoProcAmpRangeParameter videoProcAmpRangeParameter = _propertyToRangeParameter[videoProcAmpProperty];
                int ensureValue = perpertyValue;
                int hr = this._videoProcAmp.Set(videoProcAmpProperty, ensureValue, VideoProcAmpFlags.Manual);
            }
        }
    }
}

