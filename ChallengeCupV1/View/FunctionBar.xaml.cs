﻿using ChallengeCupV1.DataSource;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace ChallengeCupV1.View
{
    /// <summary>
    /// FunctionColumn.xaml 的交互逻辑
    /// </summary>
    public partial class FunctionBar : UserControl
    {
        /// <summary>
        /// Timer to set gratingdata in GratingDataContainer
        /// </summary>
        private DispatcherTimer timer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(50)
        };

        private FileInfo[] files;
        private DirectoryInfo dir = new DirectoryInfo(SettingContainer.WaveDataDir);
        // For cyclic
        private int index = 0;

        public FunctionBar()
        {
            InitializeComponent();
            UserControlManager.Register(this, GetType().Name);
            timer.Tick += new EventHandler(ReadDataFromFile);
            // For cyclic
            files = dir.GetFiles();
        }

        private void ReadDataFromFile(object sender, EventArgs e)
        {
            //-----------------------
            // Remove all files in dir
            //File.FileUtils.RemoveFileAll(files, 0, files.Length - 1);
            //-------------------------
            //if (index < files.Length)
            //{
            //    //GratingDataContainer.Data = await File.FileUtils.ReadWaveData(
            //    //    SettingDataContainer.WaveDataDir + files[index++].Name);
            //    await GratingDataContainer.GetDataFrom(
            //        File.FileUtils.ReadDataFromFile(
            //            SettingContainer.WaveDataDir + files[index++].Name).Result);
            //}
            //*****************************
            files = dir.GetFiles();
            if (files.Length > 0)
            {
                try
                {
                    GratingDataContainer.GetDataFrom(
                           File.FileUtils.ReadDataFromFile(
                                SettingContainer.WaveDataDir + files.First().Name));
                    File.FileUtils.RemoveFileAll(files, 0, files.Length - 1);
                    //files.Last().Delete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            //**********************************
            //GratingDataContainer.GetDataFrom(
            //           File.FileUtils.ReadDataFromFile(
            //                SettingContainer.WaveDataDir + files.ElementAt(index++).Name));
            //index %= files.Length;
        }

        public void UpdateDir()
        {
            dir = new DirectoryInfo(SettingContainer.WaveDataDir);
        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            
            // Connect asked
            if ((string)connect.Content == "Connect")
            {
                //WaveTab.WaveTabContent.Timer.IsEnabled = true;
                //var dir = new DirectoryInfo(SettingContainer.WaveDataDir);
                //files = dir.GetFiles();
                timer.IsEnabled = true;
                connect.Content = "Disconnect";
            }
            // Connected cancled
            else
            {
                if ("Stop" == (string)start.Content)
                {
                    connect.Content = "Stop First";
                    return;
                }
                timer.IsEnabled = false;
                //WaveTab.WaveTabContent.Timer.IsEnabled = false;
                //StateTab.StateTabContent.Timer.IsEnabled = false;
                connect.Content = "Connect";
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            // Start asked
            if ("Start" == (string)start.Content)
            {
                if ((string)connect.Content == "Connect")
                {
                    start.Content = "Connect First";
                    return;
                }
                //WaveTab.WaveTabContent.Timer.IsEnabled = true;
                //StateTab.StateTabContent.Timer.IsEnabled = true;
                //GearTab.ParamDisplay.Timer.IsEnabled = true;
                //GearTab.GearTabContent.AutoRotationTimer.IsEnabled = true;
                SetTimers(true);
                //WaveTab.WaveTabContent.IsDisplaying = true;
                start.Content = "Stop";
            }
            // Start cancled
            else
            {
                //WaveTab.WaveTabContent.Timer.IsEnabled = false;
                //StateTab.StateTabContent.Timer.IsEnabled = false;
                //GearTab.ParamDisplay.Timer.IsEnabled = false;
                //GearTab.GearTabContent.AutoRotationTimer.IsEnabled = false;
                SetTimers(false);
                //WaveTab.WaveTabContent.IsDisplaying = false;
                start.Content = "Start";
            }
           
        }

        private void SetTimers(bool isEnabled)
        {
            WaveTab.WaveTabContent.Timer.IsEnabled
                = StateTab.StateTabContent.Timer.IsEnabled
                = GearTab.ParamDisplay.Timer.IsEnabled
                = GearTab.GearTabContent.AutoRotationTimer.IsEnabled
                = isEnabled;
        }

        /// <summary>
        /// Close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            timer.IsEnabled = false;
            SetTimers(false);
            Application.Current.Shutdown();
        }
    }

}
