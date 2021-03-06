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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChallengeCupV1.GearLib
{
    /// <summary>
    /// Gear2Grating1.xaml 的交互逻辑
    /// </summary>
    public partial class Gear2Grating1 : UserControl, IGear, IGrating
    {
        public Gear2Grating1()
        {
            InitializeComponent();
        }

        public PerspectiveCamera GetCamera()
        {
            return camera;
        }

        public GeometryModel3D GetModel()
        {
            return gearModel;
        }


        public Viewport3D GetViewPort()
        {
            return viewPort;
        }

        public AxisAngleRotation3D GetAxisAngleRotation()
        {
            return axisAngleRotation;
        }

        public void ResetView()
        {
            camera.Position = new Point3D(0, 0, 400);
            axisAngleRotation.Angle = 0;
        }
    }
}
