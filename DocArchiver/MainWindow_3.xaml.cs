﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DocArchiver
{
    /// <summary>
    /// Interaction logic for MainWindow_3.xaml
    /// </summary>
    public partial class MainWindow_3 : Window
    {
        public MainWindow_3()
        {
            InitializeComponent();

            _mainFrame.Navigate(new Page_Main());        
        }
    }
}
