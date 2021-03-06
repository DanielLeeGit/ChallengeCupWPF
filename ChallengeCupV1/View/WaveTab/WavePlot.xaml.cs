﻿using ChallengeCupV1.DataSource;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.Charts;
using Microsoft.Research.DynamicDataDisplay.Charts.Axes;
using Microsoft.Research.DynamicDataDisplay.ViewportRestrictions;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChallengeCupV1.View.WaveTab
{
    /// <summary>
    /// WavePlot.xaml 的交互逻辑
    /// </summary>
    public partial class WavePlot : UserControl
    {
        /// <summary>
        /// Data source to show in chart
        /// </summary>
        WavePoints dataSource = new WavePoints();

        public WavePlot()
        {
            InitializeComponent();
            UserControlManager.Register(this, this.GetType().Name);
            // Set axes range
            //ViewportAxesRangeRestriction restr = new ViewportAxesRangeRestriction();
            // Set mouse cannot change view of plotter
            plotter.Children.Remove(plotter.MouseNavigation);
            plotter.Children.Remove(plotter.KeyboardNavigation);

            //DataContext = dataSource;
            line.DataSource = dataSource.Points;
            
        }

        /// <summary>
        /// Add double list to dataSource in time domain
        /// </summary>
        /// <param name="yList"></param>
        /// <returns></returns>
        public void AddTimePoints(List<double> yList)
        {
            UpdateYRange();
            xAxis.Visibility = Visibility.Hidden;
            dataSource.Add(yList);
        }
        
        /// <summary>
        /// Add complex array to dataSource in freq domain
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public Task AddFreqPoints(Complex[] com)
        {
            plotter.Viewport.Restrictions.Clear();
            xAxis.Visibility = Visibility.Visible;
            dataSource.FromComplexArray(com);
            return null;
        }

        /// <summary>
        /// Set vertical title
        /// </summary>
        /// <param name="title"></param>
        public void SetYTitle(string title)
        {
            if (title == null)
            {
#if DEBUG
                Console.WriteLine("WavePlot: SetYTitle() -> Illegal input, argument can not be null.");
#endif
                throw new ArgumentNullException("WavePlot: SetYTitle()");
            }
            verticalTitle.Content = title;
        }

        public void UpdateYRange()
        {
            ViewportAxesRangeRestriction restr = new ViewportAxesRangeRestriction();
            restr.YRange = new DisplayRange(
                SettingContainer.MinYWavePlotTimeDomain,
                SettingContainer.MaxYWavePlotTimeDomain);
            plotter.Viewport.Restrictions.Add(restr);
        }
    }

    /// <summary>
    /// Set Axes Range
    /// </summary>
    class ViewportAxesRangeRestriction : IViewportRestriction
    {
        public DisplayRange XRange = null;
        public DisplayRange YRange = null;

        public event EventHandler Changed;

        public Rect Apply(Rect oldVisible, Rect newVisible, Viewport2D viewport)
        {
            if (XRange != null)
            {
                newVisible.X = XRange.Start;
                newVisible.Width = XRange.End - XRange.Start;
            }

            if (YRange != null)
            {
                newVisible.Y = YRange.Start;
                newVisible.Height = YRange.End - YRange.Start;
            }
            return newVisible;
        }
    }

    /// <summary>
    /// Display range
    /// </summary>
    class DisplayRange
    {
        public double Start { get; set; }
        public double End { get; set; }
        public DisplayRange(double start, double end)
        {
            Start = start;
            End = end;
        }
    }

}
