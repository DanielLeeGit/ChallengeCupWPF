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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChallengeCupV1.View
{
    /// <summary>
    /// Wave.xaml 的交互逻辑
    /// </summary>
    public partial class Wave : UserControl
    {
        public Wave()
        {
            InitializeComponent();
            DataContext = new DataSource.Data();
        }

        /// <summary>
        /// Test OK
        /// add test data to dataSource, it can display
        /// time: 2017年1月10日17:16:41
        /// </summary>
        public void change()
        {
            var dataSource = (DataSource.Data)DataContext;
            dataSource.Add(50);
            dataSource.Add(80);
            dataSource.Add(100);
            dataSource.Update();
        }
    }
}
