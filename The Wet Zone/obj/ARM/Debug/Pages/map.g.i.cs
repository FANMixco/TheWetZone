﻿#pragma checksum "C:\Users\Federico\Documents\GitHub\TheWetZone\The Wet Zone\Pages\map.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "757A809CBDE2FD5016CD1451576CCBC2"
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
    
    
    public partial class map : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Maps.Controls.Map placesMap;
        
        internal Microsoft.Phone.Controls.LongListSelector pList;
        
        internal Microsoft.Phone.Controls.LongListSelector cList;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/The%20Wet%20Zone;component/Pages/map.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.placesMap = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("placesMap")));
            this.pList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("pList")));
            this.cList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("cList")));
        }
    }
}

