using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Description;

namespace CommMethod
{
    /// <summary>
    /// OuterPortReflector类 
    /// </summary>
    public class OuterPortReflector : SoapExtensionReflector
    {
        #region //1
        //#region
        ///// <summary>
        ///// 重写ReflectMethod
        ///// </summary>
        //public override void ReflectMethod()
        //{
        //}
        ///// <summary>
        ///// 重写ReflectDescription
        ///// </summary>
        //public override void ReflectDescription()
        //{
        //    //  为了说明问题，这里直接把端口号写死了，建议写在配置文件中
        //    string portNum = "8888";
        //    portNum = ":" + portNum;
        //    ServiceDescription description = ReflectionContext.ServiceDescription;
        //    foreach (Service service in description.Services)
        //    {
        //        foreach (Port port in service.Ports)
        //        {
        //            foreach (ServiceDescriptionFormatExtension extension in port.Extensions)
        //            {
        //                SoapAddressBinding binding = extension as SoapAddressBinding;
        //                if (null != binding)
        //                {
        //                    binding.Location = binding.Location.Replace(portNum, string.Empty);
        //                }
        //                else
        //                {
        //                    HttpAddressBinding httpBinding = extension as HttpAddressBinding;
        //                    if (httpBinding != null)
        //                    {
        //                        httpBinding.Location = httpBinding.Location.Replace(portNum, string.Empty);
        //                    }
        //                    else
        //                    {
        //                        Soap12AddressBinding soap12Binding = extension as Soap12AddressBinding;
        //                        if (soap12Binding != null)
        //                        {
        //                            soap12Binding.Location = soap12Binding.Location.Replace(portNum, string.Empty);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //#endregion
        #endregion
        #region 2        
        /// <summary>
        /// ws方法不做修改
        /// </summary>
        public override void ReflectMethod()
        {

        }

        /// <summary>
        /// 继承修改描述方法
        /// </summary>
        public override void ReflectDescription()
        {

            ServiceDescription description = ReflectionContext.ServiceDescription;

            foreach (Service service in description.Services)
            {

                foreach (Port port in service.Ports)
                {

                    port.Name = port.Name.Replace("uaService", "uaWebService");
                }

            }
        }
        #endregion
    }
}