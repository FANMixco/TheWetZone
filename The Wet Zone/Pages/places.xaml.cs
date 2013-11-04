using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using The_Wet_Zone.ViewModels;
using The_Wet_Zone.classes;

namespace The_Wet_Zone.Pages
{
    public partial class places : PhoneApplicationPage
    {
        public places()
        {
            InitializeComponent();
        }

        private void PhoneList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(this.NavigationContext.QueryString["id"]);
            createMap cm = new createMap(placesMap);

            cm.setCenter(21.134109, -102.575410, 4.5, true);

            switch (id)
            {
                case 0:
                    txtPTitle.Text = "ALBERGUES";
                    placestList.ItemsSource = App.ViewModel.hostals;

                    for (int i = 0; i < App.ViewModel.hostals.Count; i++)
                    {
                        List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                        locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.hostals[i].latitude, App.ViewModel.hostals[i].longitude, App.ViewModel.hostals[i].title, App.ViewModel.hostals[i].idplace));

                        cm.addPushpins(locations, 0);
                    }

                    break;
                case 3:
                    txtPTitle.Text = "EMBAJADAS";
                    placestList.ItemsSource = App.ViewModel.warnings;
                    break;
                case 6:
                    txtPTitle.Text = "PELIGRO";
                    placestList.ItemsSource = App.ViewModel.warnings;

                    for (int i = 0; i < App.ViewModel.warnings.Count; i++)
                    {
                        List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                        locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.warnings[i].latitude, App.ViewModel.warnings[i].longitude, App.ViewModel.warnings[i].title, App.ViewModel.warnings[i].idplace));

                        cm.addPushpins(locations, 6);
                    }
                    break;
                case 7:
                    txtPTitle.Text = "TRENES";
                    placestList.ItemsSource = App.ViewModel.trains;
                    break;
                case 8:
                    txtPTitle.Text = "AGUA";
                    placestList.ItemsSource = App.ViewModel.water;
                    break;
            }

        }

        private void placestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                place p = item.SelectedItem as place;

                string url = "/pages/pDetail.xaml?id=" + p.idplace.ToString() + "&idType=" + this.NavigationContext.QueryString["id"];
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }

        }
    }
}