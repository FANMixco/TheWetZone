using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;
using The_Wet_Zone.classes;

namespace The_Wet_Zone.Pages
{
    public partial class here : PhoneApplicationPage
    {
        createMap cm;

        public here()
        {
            InitializeComponent();
        }

        public async Task<Windows.Devices.Geolocation.Geocoordinate> GetSinglePositionAsync()
        {
            Windows.Devices.Geolocation.Geolocator geolocator = new Windows.Devices.Geolocation.Geolocator();

            Windows.Devices.Geolocation.Geoposition geoposition = await geolocator.GetGeopositionAsync();

            cm.setCenter(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude, 14, true);

            for (int i = 0; i < 1; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude, "Aquí", 0));

                cm.addPushpins(locations, 9);
            }

            load_Places();

            return geoposition.Coordinate;
        }

        private void load_Places()
        {
            for (int i = 0; i < App.ViewModel.embassies.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.embassies[i].latitude, App.ViewModel.embassies[i].longitude, App.ViewModel.embassies[i].title, App.ViewModel.embassies[i].idplace));

                cm.addPushpins(locations, 3);
            }

            for (int i = 0; i < App.ViewModel.warnings.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.warnings[i].latitude, App.ViewModel.warnings[i].longitude, App.ViewModel.warnings[i].title, App.ViewModel.warnings[i].idplace));

                cm.addPushpins(locations, 6);
            }

            for (int i = 0; i < App.ViewModel.hostals.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.hostals[i].latitude, App.ViewModel.hostals[i].longitude, App.ViewModel.hostals[i].title, App.ViewModel.hostals[i].idplace));

                cm.addPushpins(locations, 0);
            }

            for (int i = 0; i < App.ViewModel.trains.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.trains[i].latitude, App.ViewModel.trains[i].longitude, App.ViewModel.trains[i].title, App.ViewModel.trains[i].idplace));

                cm.addPushpins(locations, 7);
            }

            for (int i = 0; i < App.ViewModel.water.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.water[i].latitude, App.ViewModel.water[i].longitude, App.ViewModel.water[i].title, App.ViewModel.water[i].idplace));

                cm.addPushpins(locations, 8);
            }

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            cm = new createMap(placesMap);
            GetSinglePositionAsync();
        }
    }
}