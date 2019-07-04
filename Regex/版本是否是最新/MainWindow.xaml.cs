using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Software.UI.PrepareMode;

namespace 版本是否是最新
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region UBC更新版本以及文件名
        private string serverXmlFile = "http://update.geit.com.cn/UBoardMate/UBoardCamera/update.xml";//服务器XML文档地址(默认中文)
        //获取服务器上的版本号
        public String GetFileNameInfo()
        {
            XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
            XmlNodeList newNodeList = serverXmlFiles.GetNodeList("UpdateInfo/AppVersion");
            return newNodeList.Item(0).Value.Trim();
        }
        #endregion
    }
}
