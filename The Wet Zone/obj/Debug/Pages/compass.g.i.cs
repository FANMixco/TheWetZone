﻿#pragma checksum "C:\Users\Federico Navarrete\documents\visual studio 2012\Projects\The Wet Zone\The Wet Zone\Pages\compass.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "061F2CF3BD2006B9EEF4914954C35598"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using QiblaCompass.View;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace The_Wet_Zone.Pages {
    
    
    public partial class compass : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image CompassFace;
        
        internal QiblaCompass.View.QiblaControl QiblaControl;
        
        internal System.Windows.Controls.StackPanel calibrationStackPanel;
        
        internal System.Windows.Controls.TextBlock calibrationTextBlock;
        
        internal System.Windows.Controls.Button calibrationButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/The%20Wet%20Zone;component/Pages/compass.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.CompassFace = ((System.Windows.Controls.Image)(this.FindName("CompassFace")));
            this.QiblaControl = ((QiblaCompass.View.QiblaControl)(this.FindName("QiblaControl")));
            this.calibrationStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("calibrationStackPanel")));
            this.calibrationTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("calibrationTextBlock")));
            this.calibrationButton = ((System.Windows.Controls.Button)(this.FindName("calibrationButton")));
        }
    }
}

