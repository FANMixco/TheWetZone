﻿#pragma checksum "C:\Users\Federico Navarrete\documents\visual studio 2012\Projects\The Wet Zone\The Wet Zone\Pages\countryDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6DF4073502C51E4FFA98951ABE2E588A"
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
    
    
    public partial class countryDetail : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock txtCName;
        
        internal Microsoft.Phone.Maps.Controls.Map placesMap;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/The%20Wet%20Zone;component/Pages/countryDetail.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtCName = ((System.Windows.Controls.TextBlock)(this.FindName("txtCName")));
            this.placesMap = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("placesMap")));
            this.placestList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("placestList")));
        }
    }
}

