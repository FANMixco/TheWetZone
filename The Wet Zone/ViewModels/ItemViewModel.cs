using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace The_Wet_Zone.ViewModels
{
    public class result
    {
        public int total { get; set; }
    }

    public class iconsHelpTry
    {
        public int idicon { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class states
    {
        public int idstate { get; set; }
        public string state { get; set; }
        public int idcountry { get; set; }
    }

    public class types
    {
        public int idtype { get; set; }
        public string type { get; set; }
        public string description { get; set; }
    }

    public class tipsInfoTry
    {
        public int idtip { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
    }

    public class countryTry
    {
        public int idcountry { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string nationality { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double zoom { get; set; }
    }

    public class placeTry
    {
        public int idplace { get; set; }
        public string photo { get; set; }
        public string title { get; set; }
        public string descripcion { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public int idstate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int idtype { get; set; }
        public string fullAddress { get; set; }
    }

    public class FirstTime {
        bool activate;

        public bool Activate
        {
            get { return activate; }
            set { activate = value; }
        }
    }
}