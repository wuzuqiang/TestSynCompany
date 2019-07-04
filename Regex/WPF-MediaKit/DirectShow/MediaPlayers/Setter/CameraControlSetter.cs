using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMediaKit.DirectShow.MediaPlayers
{
    /// <summary>
    /// IAMCameraControl管理类
    /// 包括属性提取，设置
    /// 属性为<see cref="CameraControlProperty"/>枚举中的一项
    /// </summary>
    public class CameraControlSetter
    {
        private readonly IAMCameraControl _cameraControl;
        private Dictionary<CameraControlProperty, CameraControlRangeParameter> _propertyToRangeParameter =
            new Dictionary<CameraControlProperty, CameraControlRangeParameter>();

        public CameraControlSetter(IAMCameraControl cameraControl)
        {
            this._cameraControl = cameraControl;
        }
        /// <summary>
        /// 获取属性单值
        /// </summary>
        /// <param name="cameraControlProperty"></param>
        /// <returns></returns>
        public int GetParameterValue(CameraControlProperty cameraControlProperty)
        {
            int iret=0;

            try
            {
                int hr=this._cameraControl.Get(cameraControlProperty, out int getValue, out CameraControlFlags cameraControlFlags);
                string s=DsError.GetErrorText(hr);
                iret = getValue;
            }
            catch(Exception)
            {
                
            }
            return iret;
        }
        public void CheckSupportProperty()
        {
            int getValue;
            CameraControlFlags cameraControlFlags;
            string s;
            int hr= this._cameraControl.Get(CameraControlProperty.Exposure, out getValue, out cameraControlFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.Get(CameraControlProperty.Focus, out getValue, out cameraControlFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.Get(CameraControlProperty.Iris, out getValue, out cameraControlFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.Get(CameraControlProperty.Pan, out getValue, out cameraControlFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.Get(CameraControlProperty.Roll, out getValue, out cameraControlFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.Get(CameraControlProperty.Tilt, out getValue, out cameraControlFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.Get(CameraControlProperty.Zoom, out getValue, out cameraControlFlags);
            s = DsError.GetErrorText(hr);
            #region GetRange
            int pMin; int pMax; int pSteppingDelta; int pDefault; CameraControlFlags pCapsFlags;
            hr = this._cameraControl.GetRange(CameraControlProperty.Exposure, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.GetRange(CameraControlProperty.Focus, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.GetRange(CameraControlProperty.Iris, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.GetRange(CameraControlProperty.Pan, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.GetRange(CameraControlProperty.Roll, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.GetRange(CameraControlProperty.Tilt, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);
            hr = this._cameraControl.GetRange(CameraControlProperty.Zoom, out pMin, out pMax, out pSteppingDelta, out pDefault, out pCapsFlags);
            s = DsError.GetErrorText(hr);

            #endregion
        }
        /// <summary>
        /// 获取可设置范围值
        /// </summary>
        /// <param name="cameraControlProperty"></param>
        /// <returns></returns>
        public CameraControlRangeParameter GetRangeParameterValue(CameraControlProperty cameraControlProperty)
        {
            CameraControlRangeParameter cameraControlRangeParameter = null;
            try
            {
                int hr = this._cameraControl.GetRange(cameraControlProperty,
                    out int min,
                    out int max,
                    out int step,
                    out int defaultValue,
                    out CameraControlFlags cameraControlFlags);
                string sss = DsError.GetErrorText(hr);
                if ( hr== 0)
                {
                    cameraControlRangeParameter = new CameraControlRangeParameter
                    {
                        CameraControlProperty = cameraControlProperty,
                        MinValue = min,
                        MaxValue = max,
                        StepValue = step,
                        DefaultValue = defaultValue,
                        Flags = cameraControlFlags
                    };
                    //加入字典
                    if(_propertyToRangeParameter.ContainsKey(cameraControlProperty))
                    {
                        _propertyToRangeParameter[cameraControlProperty] = cameraControlRangeParameter;
                    }
                    else
                    {
                        _propertyToRangeParameter.Add(cameraControlProperty, cameraControlRangeParameter);
                    }
                }
            }
            catch(Exception)
            {

            }
            return cameraControlRangeParameter;
        }
        /// <summary>
        /// 设置CameraControlProperty的值
        /// 有做有效值判断
        /// </summary>
        /// <param name="cameraControlProperty"></param>
        /// <param name="perpertyValue"></param>
        public void SetParameterValue(CameraControlProperty cameraControlProperty,int perpertyValue)
        {
            if(_propertyToRangeParameter.ContainsKey(cameraControlProperty) || this.GetRangeParameterValue(cameraControlProperty) != null)
            {
                CameraControlRangeParameter cameraControlRangeParameter = _propertyToRangeParameter[cameraControlProperty];
                int ensureValue = Math.Min(Math.Max(cameraControlRangeParameter.MinValue, perpertyValue), cameraControlRangeParameter.MaxValue);
                this._cameraControl.Set(cameraControlProperty, ensureValue, CameraControlFlags.Manual);
            }
        }
    }
}
