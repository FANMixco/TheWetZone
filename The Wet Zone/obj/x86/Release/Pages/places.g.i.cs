﻿#pragma checksum "C:\Users\Federico\Documents\GitHub\TheWetZone\The Wet Zone\Pages\places.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "65BB7338996B39BA97276F2E03830C4E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
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
    
    
    public partial class places : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock txtPTitle;
        
        internal Microsoft.Phone.Maps.Controls.Map placesMap;
        
        internal System.Windows.Controls.Image btnZoomIn;
        
        internal System.Windows.Controls.Image btnZoomOut;
        
        internal Microsoft.Phone.Controls.LongListSelector placestList;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/The%20Wet%20Zone;component/Pages/places.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtPTitle = ((System.Windows.Controls.TextBlock)(this.FindName("txtPTitle")));
            this.placesMap = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("placesMap")));
            this.btnZoomIn = ((System.Windows.Controls.Image)(this.FindName("btnZoomIn")));
            this.btnZoomOut = ((System.Windows.Controls.Image)(this.FindName("btnZoomOut")));
            this.placestList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("placestList")));
        }
    }
}

