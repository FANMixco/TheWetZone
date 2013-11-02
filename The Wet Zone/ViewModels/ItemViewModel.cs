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
    public class iconsHelp
    {
        public int idicon { get; set; }
        public ImageSource icon { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public iconsHelp(int ID, ImageSource Icon, string Title, string Descrition)
        {
            this.idicon = ID;
            this.icon = Icon;
            this.title = Title;
            this.description = Descrition;
        }
    }

    public class country
    {
        public int idcountry { get; set; }
        public string name { get; set; }
    }

    public class place
    {
        public int idplace { get; set; }
        public ImageSource photo { get; set; }
        public string title { get; set; }
        public string descripcion { get; set; }
        public string telephone { get; set; }
        public int idcountry { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}