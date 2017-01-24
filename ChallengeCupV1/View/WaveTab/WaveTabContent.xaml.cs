﻿using ChallengeCupV1.DataSource;
using ChallengeCupV1.FFT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
using System.Windows.Threading;

namespace ChallengeCupV1.View.WaveTab
{
    /// <summary>
    /// TabContent.xaml 的交互逻辑
    /// </summary>
    public partial class WaveTabContent : UserControl
    {
        public static bool IsDisplaying = false;
        public static DispatcherTimer Timer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(100),
        };
        FileInfo[] files;
        static int fileIndex = 0;

        CH selectedCH;
        Grating selectedGrating;
        Domain selectedDomain;


        public WaveTabContent()
        {
            InitializeComponent();
            //var dire = new DirectoryInfo(directoryPath);
            var dir = new DirectoryInfo(SettingData.WaveDataDir);
            files = dir.GetFiles();
            //-----------------------
            // Remove all files in dir
            //File.FileUtils.RemoveFileAll(files);
            //-------------------------
#if DEBUG
            Console.WriteLine("WaveTabContent:WaveTabContent() -> files name list");
            //for (int i = 0; i < files.Length; i++)
            //{
            //    Console.WriteLine(files[i].Name);
            //}
#endif
            Timer.Tick += new EventHandler(AnimatedPlot);
            //timer.IsEnabled = true;
        }

        private async void AnimatedPlot(object sender, EventArgs e)
        {
            //------------------------------------------------
            //var dir = new DirectoryInfo(SettingData.WaveDataDir);
            //files = dir.GetFiles();
            //if (IsDisplaying && files != null)
            //{
            //    AddPoints(await File.FileUtils
            //    .ReadWaveData(SettingData.WaveDataDir + files[0].Name));
            //}
            //File.FileUtils.RemoveFileAll(files);
            //-------------------------------------------------
            if (IsDisplaying && fileIndex < files.Length)
            {
                AddPoints(await File.FileUtils
                .ReadWaveData(SettingData.WaveDataDir + files[fileIndex++].Name));
            }
        }

        
        /// <summary>
        /// Add double list array to dataSource
        /// added index of array is determined by value of selectedCH
        /// </summary>
        /// <param name="yListArray"></param>
        /// <returns></returns>
        public async Task AddPoints(List<double>[] yListArray)
        {
            var selected = (int)Enum.Parse(typeof(CH), selectedCH.ToString()) + 1;
            switch (selectedDomain)
            {
                case Domain.Time:
#if DEBUG
                    Console.WriteLine("WaveTabContent:AddPoints() -> add time domain points");
#endif
                    await wavePlot.AddTimePoints(yListArray[selected]);
                    break;
                case Domain.Frequency:
#if DEBUG
                    Console.WriteLine("WaveTabContent:AddPoints() -> add frequency domain points");
#endif
                    //await wavePlot.AddFreqPoints(DataFFT.Forward(yListArray[selected].ToComplex()).Result);
                    await wavePlot.AddFreqPoints(DataFFT.Forward(
                        (from y in yListArray[selected] select new Complex(y, 0)).ToArray())
                        .Result);
                    break;
                default:
                    break;
            }
        }

        private void g1_Selected(object sender, RoutedEventArgs e)
        {
            selectedGrating = Grating.G1;
        }

        private void g2_Selected(object sender, RoutedEventArgs e)
        {
            selectedGrating = Grating.G2;
        }

        private void g3_Selected(object sender, RoutedEventArgs e)
        {
            selectedGrating = Grating.G3;
        }

        private void g4_Selected(object sender, RoutedEventArgs e)
        {
            selectedGrating = Grating.G4;
        }

        private void time_Selected(object sender, RoutedEventArgs e)
        {
            selectedDomain = Domain.Time;
        }

        private void freq_Selected(object sender, RoutedEventArgs e)
        {
            selectedDomain = Domain.Frequency;
        }

        private void ch1_Selected(object sender, RoutedEventArgs e)
        {
            selectedCH = CH.CH1;
        }

        private void ch2_Selected(object sender, RoutedEventArgs e)
        {
            selectedCH = CH.CH2;
        }

         private void ch3_Selected(object sender, RoutedEventArgs e)
        {
            selectedCH = CH.CH3;
        }

        private void ch4_Selected(object sender, RoutedEventArgs e)
        {
            selectedCH = CH.CH4;
        }
    }
}

enum CH
{
    CH1, CH2, CH3, CH4
}

enum Grating
{
    G1, G2, G3, G4
}

enum Domain
{
    Time, Frequency
}