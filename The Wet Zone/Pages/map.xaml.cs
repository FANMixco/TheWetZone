using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using The_Wet_Zone.classes;
using The_Wet_Zone.ViewModels;
using System.Windows.Media.Imaging;

namespace The_Wet_Zone.Pages
{
    public partial class map : PhoneApplicationPage
    {
        public map()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<country> sourceC = new List<country>();

            List<iconsHelp> source = new List<iconsHelp>();
            createMap cm = new createMap(placesMap);

            cm.setCenter(21.134109, -102.575410, 4.5, true);

            for (int i = 0; i < App.ViewModel.hostals.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.hostals[i].latitude, App.ViewModel.hostals[i].longitude, App.ViewModel.hostals[i].title, App.ViewModel.hostals[i].idplace));

                cm.addPushpins(locations, 0);
            }

            source.Add(new iconsHelp(0, new BitmapImage(new Uri("/Img/locations/0.jpg", UriKind.Relative)), "Albergues", "Lugar de hospedaje para los inmigrantes."));
            //source.Add(new iconsHelp(1, new BitmapImage(new Uri("/Img/locations/1.jpg", UriKind.Relative)), "Paradas de Buses", "Paradas de diversas rutas de buses."));
            //source.Add(new iconsHelp(2, new BitmapImage(new Uri("/Img/locations/2.jpg", UriKind.Relative)), "Cafeterias", "Lugares de alimentación para inmigrantes."));
            //source.Add(new iconsHelp(3, new BitmapImage(new Uri("/Img/locations/3.jpg", UriKind.Relative)), "Embajadas", "Representación de El Salvador en diversos lugares."));
            //source.Add(new iconsHelp(4, new BitmapImage(new Uri("/Img/locations/4.jpg", UriKind.Relative)), "Iglesias", "Albergues provistos por Iglesias para dormir."));
            //source.Add(new iconsHelp(5, new BitmapImage(new Uri("/Img/locations/5.jpg", UriKind.Relative)), "ONGs", "Organizaciones para apoyo a inmigrantes."));
            //source.Add(new iconsHelp(6, new BitmapImage(new Uri("/Img/locations/6.jpg", UriKind.Relative)), "Lugares Peligrosos", "Lugares con mayor número de incidencias de peligro."));
            //source.Add(new iconsHelp(7, new BitmapImage(new Uri("/Img/locations/7.jpg", UriKind.Relative)), "Trenes", "Estaciones de tren."));
            //source.Add(new iconsHelp(8, new BitmapImage(new Uri("/Img/locations/8.jpg", UriKind.Relative)), "Fuentes de Agua", "Fuentes de agua."));

            pList.ItemsSource = source;

//            sourceC.Add(new country { idcountry = App.ViewModel.countries[0].idcountry, name = App.ViewModel.countries[0].name, photo = App.ViewModel.countries[0].photo });
            sourceC.Add(new country { idcountry = App.ViewModel.countries[1].idcountry, name = App.ViewModel.countries[1].name, photo = App.ViewModel.countries[1].photo });
            sourceC.Add(new country { idcountry = App.ViewModel.countries[2].idcountry, name = App.ViewModel.countries[2].name, photo = App.ViewModel.countries[2].photo });

            cList.ItemsSource = sourceC;
        }

        private void pList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                iconsHelp ih = item.SelectedItem as iconsHelp;

                string url = "/pages/places.xaml?id=" + ih.idicon.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }
        }

        private void cList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                country c = item.SelectedItem as country;

                string url = "/pages/countryDetail.xaml?id=" + c.idcountry.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }

        }
    }
}