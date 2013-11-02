using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using The_Wet_Zone.ViewModels;

namespace The_Wet_Zone.Pages
{
    public partial class help : PhoneApplicationPage
    {

        public help()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<iconsHelp> source = new List<iconsHelp>();

            source.Add(new iconsHelp(0, new BitmapImage(new Uri("/Img/places/albergues.png", UriKind.Relative)), "Albergue", "Lugar de hospedaje para los inmigrantes."));
            source.Add(new iconsHelp(1, new BitmapImage(new Uri("/Img/places/buses.png", UriKind.Relative)), "Parada de Bus", "Paradas de diversas rutas de buses."));
            source.Add(new iconsHelp(2, new BitmapImage(new Uri("/Img/places/comida.png", UriKind.Relative)), "Centro de Alimentación", "Lugares de alimentación para inmigrantes."));
            source.Add(new iconsHelp(3, new BitmapImage(new Uri("/Img/places/embajadas.png", UriKind.Relative)), "Embajada", "Representación de El Salvador en diversos lugares."));
            source.Add(new iconsHelp(4, new BitmapImage(new Uri("/Img/places/iglesias.png", UriKind.Relative)), "Iglesia", "Albergues provistos por Iglesias para dormir."));
            source.Add(new iconsHelp(5, new BitmapImage(new Uri("/Img/places/ong.png", UriKind.Relative)), "ONG", "Organizaciones para apoyo a inmigrantes."));
            source.Add(new iconsHelp(6, new BitmapImage(new Uri("/Img/places/peligro.png", UriKind.Relative)), "Lugar Peligroso", "Lugares con mayor número de incidencias de peligro."));
            source.Add(new iconsHelp(7, new BitmapImage(new Uri("/Img/places/trenes.png", UriKind.Relative)), "Tren", "Estaciones de tren."));
            source.Add(new iconsHelp(8, new BitmapImage(new Uri("/Img/places/water-faucet.png", UriKind.Relative)), "Fuente de Agua", "Fuentes de agua."));

            hList.ItemsSource = source;
        }
    }
}