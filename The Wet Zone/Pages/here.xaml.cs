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
using SQLite;
using System.IO;
using Windows.Storage;
using The_Wet_Zone.ViewModels;
using The_Wet_Zone.Resources;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Maps.Controls;

namespace The_Wet_Zone.Pages
{
    public partial class here : PhoneApplicationPage
    {
        createMap cm;

        public here()
        {
            InitializeComponent();
        }

        public async void GetSinglePositionAsync()
        {
            Windows.Devices.Geolocation.Geolocator geolocator = null;
            Windows.Devices.Geolocation.Geoposition geoposition = null;

            try
            {
                geolocator = new Windows.Devices.Geolocation.Geolocator();

                geoposition = await geolocator.GetGeopositionAsync();

                cm.setCenter(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude, 14, true);

                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude, "Aquí", 0));

                cm.addPushpins(locations, 0);
            }
            catch
            {
                // Something else happened while acquiring the location.
                MessageBox.Show(AppResources.locationCheck.ToString(), "Error", MessageBoxButton.OK);
            }

            load_Places();
        }

        private void load_Places()
        {
            sqliteDB cn = new sqliteDB();
            cn.open();

            //Load all places
            string query = "SELECT idplace, title, latitude, longitude, idtype FROM placesTable";
            List<placeTry> placeInfo = cn.db.Query<placeTry>(query);

            for (int i = 0; i < placeInfo.Count; i++)
            {
                var values = placeInfo[i];
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(values.latitude, values.longitude, values.title, values.idplace));

                cm.addPushpins(locations, values.idtype);
            }
            cn.close();

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            cm = new createMap(placesMap);
            GetSinglePositionAsync();
        }

        private void share_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
                SendMessage();
            else
                MessageBox.Show(AppResources.Internet, "Error", MessageBoxButton.OK);
        }


        public async void SendMessage()
        {
            try
            {
                Windows.Devices.Geolocation.Geolocator geolocator = new Windows.Devices.Geolocation.Geolocator();

                Windows.Devices.Geolocation.Geoposition geoposition = await geolocator.GetGeopositionAsync();

                EmailComposeTask task = new EmailComposeTask();
                task.Subject = "Me encuentro en...";
                task.Body = "Ver mapa:\r\n" + "http://bing.com/maps/?cp=" + geoposition.Coordinate.Latitude.ToString() + "~" + geoposition.Coordinate.Longitude.ToString() + "&lvl=16&sp=point." + geoposition.Coordinate.Latitude.ToString() + "_" + geoposition.Coordinate.Longitude.ToString() + "_";

                task.Show();
            }
            catch
            {
                // Something else happened while acquiring the location.
                MessageBox.Show(AppResources.locationCheck.ToString(), "Error", MessageBoxButton.OK);
            }
        }

        private void road_Click(object sender, EventArgs e)
        {
            placesMap.CartographicMode = MapCartographicMode.Road;
        }

        private void aerial_Click(object sender, EventArgs e)
        {
            placesMap.CartographicMode = MapCartographicMode.Aerial;
        }

    }
}