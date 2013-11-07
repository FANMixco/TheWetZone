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

            List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
            locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude, "Aquí", 0));

            cm.addPushpins(locations, 10);

            load_Places();

            return geoposition.Coordinate;
        }

        private void load_Places()
        {
            sqliteDB cn = new sqliteDB();
            cn.open();

            //Load all places
            string query = "SELECT idplace, CASE WHEN idtype=0 THEN ('/Img/hostels/' || idplace || '.jpg') ELSE ('/Img/locations/' || idtype || '.jpg') END AS photo, title, descripcion, telephone, idcountry, latitude, longitude, idtype FROM placesTable";
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
    }
}