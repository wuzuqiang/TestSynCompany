﻿using System;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// StyleTest.xaml 的交互逻辑
    /// </summary>
    public partial class StyleTest : Window
    {
        public StyleTest()
        {
            InitializeComponent();
            //cmd.Style = (Style)cmd.FindResource("BigFontButtonStyle");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
