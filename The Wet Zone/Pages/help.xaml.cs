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
using Microsoft.Phone.Tasks;

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

            source.Add(new iconsHelp(0, new BitmapImage(new Uri("/Img/places/0.png", UriKind.Relative)), "Albergue", "Lugar de hospedaje para los inmigrantes."));
            source.Add(new iconsHelp(1, new BitmapImage(new Uri("/Img/places/1.png", UriKind.Relative)), "Parada de Bus", "Paradas de diversas rutas de buses."));
            source.Add(new iconsHelp(2, new BitmapImage(new Uri("/Img/places/2.png", UriKind.Relative)), "Centro de Alimentación", "Lugares de alimentación para inmigrantes."));
            source.Add(new iconsHelp(3, new BitmapImage(new Uri("/Img/places/3.png", UriKind.Relative)), "Embajada", "Representación de El Salvador en diversos lugares."));
            source.Add(new iconsHelp(4, new BitmapImage(new Uri("/Img/places/4.png", UriKind.Relative)), "Iglesia", "Albergues provistos por Iglesias para dormir."));
            source.Add(new iconsHelp(5, new BitmapImage(new Uri("/Img/places/5.png", UriKind.Relative)), "ONG", "Organizaciones para apoyo a inmigrantes."));
            source.Add(new iconsHelp(6, new BitmapImage(new Uri("/Img/places/6.png", UriKind.Relative)), "Lugar Peligroso", "Lugares con mayor número de incidencias de peligro."));
            source.Add(new iconsHelp(7, new BitmapImage(new Uri("/Img/places/7.png", UriKind.Relative)), "Tren", "Estaciones de tren."));
            source.Add(new iconsHelp(8, new BitmapImage(new Uri("/Img/places/8.png", UriKind.Relative)), "Fuente de Agua", "Fuentes de agua."));

            hList.ItemsSource = source;
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask
            {
                To = txtEmail.Text
            };

            emailComposeTask.Show();
        }

        private void TextBlock_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri(@"https://twitter.com/FANMixco");
            webBrowserTask.Show();
        }
    }
}