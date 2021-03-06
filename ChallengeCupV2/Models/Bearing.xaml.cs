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

namespace ChallengeCupV2.Models
{
    /// <summary>
    /// Bearing.xaml 的交互逻辑
    /// </summary>
    public partial class Bearing : UserControl, IModel
    {
        public Bearing()
        {
            InitializeComponent();
        }

        public void AutoRotation()
        {
            ResetView();
        }

        public AxisAngleRotation3D GetAxisAngleRotation()
        {
            return axisAngleRotation;
        }

        public PerspectiveCamera GetCamera()
        {
            return camera;
        }

        public GeometryModel3D GetModel()
        {
            return model;
        }

        public Viewport3D GetViewPort()
        {
            return viewPort;
        }

        public void ResetView()
        {
            camera.Position = new Point3D(3.43322754474684E-05, 0.0394420623779297, 167.869010896223);
            axisAngleRotation.Angle = 0;
        }
    }
}
