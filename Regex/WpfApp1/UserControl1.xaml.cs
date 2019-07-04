using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        DataSource dataSource = new DataSource();
        public UserControl1()
        {
            InitializeComponent();
            //ClassA classA = new ClassA()
            //{
            //    IsSelected = "IsSelected",
            //    DeviceName = "DeviceName",
            //};
            //this.DataContext = classA;
            //dataSource.Source = "Source1";
            //this.DataContext = dataSource;
            cbx1.IsChecked = true;
        }

        private void CameraList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataSource.Source = "ChangedSource";
        }
    }
    public class ClassA
    {
        public string IsSelected { get; set; }
        public string DeviceName { get; set; }
    }
    public class DataSource : INotifyPropertyChanged
    {
        private string mSource = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string Source
        {
            get { return mSource; }
            set
            {
                if (mSource == value)
                {
                    return;
                }
                mSource = value;
                //NotifyPropertyChanged("Source");
            }
        }
    }
}
