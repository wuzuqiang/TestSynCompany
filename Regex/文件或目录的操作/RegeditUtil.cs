using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//倒入必须的命名空间
using Microsoft.Win32;

namespace Utility
{
    /// <summary>
    /// 注册表操作，如果不想创建项ItemName，则赋值空字符串。
    /// </summary>
    public class RegeditUtil
    {
        /// <summary>
        /// 要操作的在baseRK下的软件节点
        /// </summary>
        private string strRKOpering;
        private RegistryKey baseRK;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseRK">根注册表项</param>
        /// <param name="isCreate">是否创建新注册表项</param>
        /// <param name="itemName">要创建的注册表项，项使用'\'链接</param>
        public RegeditUtil(RegistryKey baseRK, Boolean isCreate = false, string strRKOpering = "")
        {
            this.baseRK = baseRK;
            this.strRKOpering = strRKOpering;
            if (isCreate)
            {
                RegistryKey rgSoftware = baseRK.OpenSubKey(strRKOpering);
                //首先判断是否存在ItemName项，没有就建立
                if (null == rgSoftware)//
                {   //建立该节点，如果该节点已经存在，则不影响
                    if (baseRK.CreateSubKey(strRKOpering) == null)
                    {   //本身就是错误的，还是抛出异常进行提示吧！
                        throw new Exception(string.Format("抱歉！创建注册表项{0}出现错误！", strRKOpering));
                    }
                    baseRK.Close();
                }
            }
        }

        /// <summary>
        /// 增加键，值对；已存在就不用增加了
        /// </summary>
        /// <param name="keyName">键的名称</param>
        /// <param name="keyValue">键的数值</param>
        public void RegeditAdd(string keyName, string keyValue)
        {
            RegistryKey rkOpering = baseRK.OpenSubKey(strRKOpering);
            if(RegeditKeyExist(keyName))
                rkOpering.SetValue(keyName, keyValue);
            rkOpering.Close();
        }

        /// <summary>
        /// 根据键的名称，验证该键是否存在
        /// </summary>
        /// <param name="keyName">键的名称</param>
        /// <returns></returns>
        public bool RegeditKeyExist(string keyName)
        {
            string[] subkeyNames;
            RegistryKey rkOper = baseRK.OpenSubKey(strRKOpering);
            subkeyNames = rkOper.GetValueNames();
            //取得该项下所有键值的名称的序列，并传递给预定的数组中   
            foreach (string itemKeyName in subkeyNames)
            {
                if (itemKeyName == keyName)    //判断键值的名称   
                {
                    //baseRK.Close();   //没改动项，不用close吧！！！！！
                    return true;
                }
            }
            //baseRK.Close();
            return false;
        }

        /// <summary>
        /// 根据节点的名称，验证baseRK节点下是否存在该节点
        /// </summary>
        /// <param name="linkedItemName">根节点一下的节点组合使用'\'拼接而成的查找项</param>
        /// <returns></returns>
        public bool RegeditItemExist(string linkedItemName)
        {
            string[] subkeyNames;

            string[] strArrayNeedSearch = linkedItemName.Split('\\');
            subkeyNames = baseRK.GetSubKeyNames();
            string strNeedSeaachSubKeyLink = "";
            //取得该项下所有子项的名称的序列，并传递给预定的数组中
            foreach (string strNeedSerarchItem in strArrayNeedSearch)
            {
                bool flagPrevLayer = false;
                foreach (string keyName in subkeyNames)   //遍历整个数组  
                {
                    //判断子项的名称
                    if (keyName.ToUpper() == strNeedSerarchItem.ToUpper())
                    {
                        flagPrevLayer = true;
                        strNeedSeaachSubKeyLink += "\\" + strNeedSerarchItem;    //第一次和后面几次会有区别
                        strNeedSeaachSubKeyLink = strNeedSeaachSubKeyLink[0] == '\\' ? strNeedSeaachSubKeyLink = strNeedSeaachSubKeyLink.Substring(1) : strNeedSeaachSubKeyLink;
                        subkeyNames = baseRK.OpenSubKey(strNeedSeaachSubKeyLink).GetSubKeyNames();
                        break;
                    }
                }
                if (!flagPrevLayer)
                {   //上面的项都不匹配
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 根据节点的名称，验证baseRK节点下是否存在该节点
        /// </summary>
        /// <param name="listLinkedItemName">根节点一下的节点组合使用'\'拼接而成的查找项列表</param>
        /// <returns></returns>
        public bool RegeditItemExist(List<string> listLinkedItemName)
        {
            foreach (string linkedItemName in listLinkedItemName)
            {
                #region linkedItemName查找项是否存在
                string[] subkeyNames;

                string[] strArrayNeedSearch = linkedItemName.Split('\\');
                subkeyNames = baseRK.GetSubKeyNames();
                string strNeedSeaachSubKeyLink = "";
                //取得该项下所有子项的名称的序列，并传递给预定的数组中
                foreach (string strNeedSerarchItem in strArrayNeedSearch)
                {
                    bool flagPrevLayer = false;
                    foreach (string keyName in subkeyNames)   //遍历整个数组  
                    {
                        //判断子项的名称
                        if (keyName.ToUpper() == strNeedSerarchItem.ToUpper())
                        {
                            flagPrevLayer = true;
                            strNeedSeaachSubKeyLink += "\\" + strNeedSerarchItem;    //第一次和后面几次会有区别
                            strNeedSeaachSubKeyLink = strNeedSeaachSubKeyLink[0] == '\\' ? strNeedSeaachSubKeyLink = strNeedSeaachSubKeyLink.Substring(1) : strNeedSeaachSubKeyLink;
                            subkeyNames = baseRK.OpenSubKey(strNeedSeaachSubKeyLink).GetSubKeyNames();
                            break;
                        }
                    }
                    if (!flagPrevLayer)
                    {   //上面的项都不匹配
                        //只要有一项不匹配，那么就是不存在。。。
                        return false;
                    }
                }
                #endregion
            }
            return true;
        }

        /// <summary>
        /// 根据键的名称，获得该键的值
        /// </summary>
        /// <param name="keyName">键的名称</param>
        /// <returns></returns>
        public string GetValeByName(string keyName)
        {
            RegistryKey Zane = baseRK.OpenSubKey(strRKOpering, true);
            string regName = Zane.GetValue(keyName).ToString();

            Zane.Close();
            return regName;
        }

        /// <summary>
        /// 根据键的名称，删除该键
        /// </summary>
        /// <param name="keyName">键的名称</param>
        /// <returns></returns>
        public bool DeleteRegist(string keyName)
        {
            string[] keys;
            RegistryKey item = baseRK.OpenSubKey(strRKOpering, true);

            keys = item.GetValueNames();
            foreach (string key in keys)
            {
                if (key == keyName)
                {
                    item.DeleteValue(key);
                    return true;
                }
            }
            return true;
        }
    }
}
