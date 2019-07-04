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

namespace WpfApp1
{
    /// <summary>
    /// MyDependencyProperty.xaml 的交互逻辑
    /// </summary>
    public partial class MyDependencyProperty : UserControl
    {
        public MyDependencyProperty()
        {
            InitializeComponent();
            MyColor = "2332";
        }
        //1、声明依赖属性变量
        public static readonly DependencyProperty MyColorProperty;
        //2、在属性系统中注册
        static MyDependencyProperty()
        {
            MyColorProperty = DependencyProperty.Register("MyColor", typeof(string),    //去掉.Register这行之后
            //，会出现错误：System.Windows.Markup.XamlParseException:““对类型“WpfApp1.MyDependencyProperty”的构造函数执行符合指定的绑定约束的调用时引发了异常。
                typeof(MyDependencyProperty)
                //,new PropertyMetadata("Red", (s, e) =>
                //{
                //    var mdp = s as MyDependencyProperty;
                //    if (mdp != null)
                //    {
                //        try
                //        {
                //            var color = (Color)ColorConverter.ConvertFromString(e.NewValue.ToString());
                //            mdp.Foreground = new SolidColorBrush(color);
                //        }
                //        catch
                //        {
                //            mdp.Foreground = new SolidColorBrush(Colors.Black);
                //        }
                //    }
                //})
                );
        }
        //3、使用.NET属性包装依赖属性：属性名称与注册时候的名称必须一致，
        //即属性名MyColor对应注册时的MyColor
        public string MyColor
        {
            get
            {
                return (string)GetValue(MyColorProperty);
            }
            set
            {
                SetValue(MyColorProperty, value);
            }
        }
        
    }
}
