﻿#pragma checksum "C:\Users\Federico Navarrete\Documents\Visual Studio 2012\Projects\The Wet Zone\The Wet Zone\Pages\help.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "865057550AAD27094CF3D15FF29C687C"
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
    
    
    public partial class help : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.LongListSelector hList;
        
        internal System.Windows.Controls.TextBlock txtEmail;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/The%20Wet%20Zone;component/Pages/help.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.hList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("hList")));
            this.txtEmail = ((System.Windows.Controls.TextBlock)(this.FindName("txtEmail")));
        }
    }
}

