﻿using ChallengeCupV1.DataSource;
using ChallengeCupV1.DataSource.GearStatus;
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

namespace ChallengeCupV1.View.SettingTab
{
    /// <summary>
    /// SettingTabContent.xaml 的交互逻辑
    /// </summary>
    public partial class SettingTabContent : UserControl
    {
        public SettingTabContent()
        {
            InitializeComponent();
            UserControlManager.Register(this, this.GetType().Name);
            // Init text box
            statusReportDir.Text = SettingContainer.StatusReportDir;
            maxYTimeDomain.Text = SettingContainer.MaxYWavePlotTimeDomain.ToString();
            minYTimeDomain.Text = SettingContainer.MinYWavePlotTimeDomain.ToString();
            referYTimeDomain.Text = SettingContainer.ReferYWavePlotTimeDomain.ToString();
            E_PARM.Text = StatusConstantParam.E.ToString();
            u_PARM.Text = StatusConstantParam.u.ToString();
            delta_PARM.Text = StatusConstantParam.DELTA.ToString();
            alpha_PARM.Text = StatusConstantParam.ALPHA.ToString();
            gearWidth.Text = StatusConstantParam.GEAR_WIDTH.ToString();
        }

        /// <summary>
        /// Brower and set generate report dir path of setting data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseDir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string dir = dialog.SelectedPath.Trim();
            statusReportDir.Text = dir;
        }

        /// <summary>
        /// Apply all settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apply_Click(object sender, RoutedEventArgs e)
        {
            SettingContainer.StatusReportDir = statusReportDir.Text;
            SettingContainer.MaxYWavePlotTimeDomain = double.Parse(maxYTimeDomain.Text);
            SettingContainer.MinYWavePlotTimeDomain = double.Parse(minYTimeDomain.Text);
            SettingContainer.ReferYWavePlotTimeDomain = double.Parse(referYTimeDomain.Text);
            StatusConstantParam.E = double.Parse(E_PARM.Text);
            StatusConstantParam.u = double.Parse(u_PARM.Text);
            StatusConstantParam.DELTA = double.Parse(delta_PARM.Text);
            StatusConstantParam.ALPHA = double.Parse(alpha_PARM.Text);
            StatusConstantParam.GEAR_WIDTH = double.Parse(gearWidth.Text);
            (UserControlManager.Get("WavePlot") as WaveTab.WavePlot).UpdateYRange();
            (UserControlManager.Get("FunctionBar") as FunctionBar).UpdateDir();
        }
    }
}