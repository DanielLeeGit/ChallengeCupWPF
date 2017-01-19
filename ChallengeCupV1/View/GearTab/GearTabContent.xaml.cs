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

namespace ChallengeCupV1.View.GearTab
{
    /// <summary>
    /// GearTabContent.xaml 的交互逻辑
    /// </summary>
    public partial class GearTabContent : UserControl
    {
        public static Gear SelectedGear = Gear.G1;

        public GearTabContent()
        {
            InitializeComponent();
        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {
            initPage.Visibility = Visibility.Visible;
        }
    }

    public enum Gear
    {
        G1, G2, G3, G4
    }
}
