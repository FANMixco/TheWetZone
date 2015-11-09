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
using Microsoft.Phone.Maps.Controls;
using The_Wet_Zone.Resources;

namespace The_Wet_Zone.Pages
{
    public partial class places : PhoneApplicationPage
    {
        public places()
        {
            InitializeComponent();
        }
        private void createAppBar(bool p)
        {
            ApplicationBar = new ApplicationBar();

            if (p == false)
            {
                ApplicationBar.Opacity = 0.9;

                ApplicationBarIconButton button1 = new ApplicationBarIconButton();
                button1.IconUri = new Uri("/Assets/AppBar/road.png", UriKind.Relative);
                button1.Text = AppResources.RoadView;
                ApplicationBar.Buttons.Add(button1);
                button1.Click += new EventHandler(road_Click);

                ApplicationBarIconButton button2 = new ApplicationBarIconButton();
                button2.IconUri = new Uri("/Assets/AppBar/eye.png", UriKind.Relative);
                button2.Text = AppResources.AerialView;
                ApplicationBar.Buttons.Add(button2);
                button2.Click += new EventHandler(aerial_Click);
            }
            else
                ApplicationBar.IsVisible = false;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(this.NavigationContext.QueryString["id"]);
            createMap cm = new createMap(placesMap);

            sqliteDB cn = new sqliteDB();
            cn.open();

            cm.setCenter(21.134109, -102.575410, 4.5, true);

            string query = "SELECT * FROM typesTable WHERE idtype=" + id;
            List<types> iconsHelpInfo = cn.db.Query<types>(query);

            var valuesI = iconsHelpInfo[0];
            txtPTitle.Text = valuesI.type.ToUpper();

            //Load all places
            query = "SELECT idplace, CASE WHEN idtype=1 THEN ('/Img/hostels/' || idplace || '.jpg') ELSE ('/Img/locations/' || idtype || '.jpg') END AS photo, title, p.latitude, p.longitude, idtype, CASE WHEN address IS NULL THEN (state || ', ' || c.name) ELSE (address || ', ' || state || ', ' || c.name) END AS fullAddress FROM placesTable p, statesTable s, countriesTable c WHERE p.idstate = s.idstate AND c.idcountry = s.idcountry AND idtype=" + id.ToString();
            List<placeTry> placeInfo = cn.db.Query<placeTry>(query);
            placestList.ItemsSource = placeInfo;

            for (int i = 0; i < placeInfo.Count; i++)
            {
                var values = placeInfo[i];
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(values.latitude, values.longitude, values.title, values.idplace));

                cm.addPushpins(locations, values.idtype);
            }
            cn.close();

        }
        

        private void placestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                placeTry p = item.SelectedItem as placeTry;

                string url = "/pages/pDetail.xaml?id=" + p.idplace.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
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

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Pivot)sender).SelectedIndex == 0)
                createAppBar(false);
            else
                createAppBar(true);
        }

        private void btnZoomIn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            double currentZoom = placesMap.ZoomLevel;
            if (currentZoom < 20)
                placesMap.ZoomLevel = placesMap.ZoomLevel + 0.5;
        }

        private void btnZoomOut_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            double currentZoom = placesMap.ZoomLevel;
            if (currentZoom > 0)
                placesMap.ZoomLevel = placesMap.ZoomLevel - 0.5;
        }

        private void placesMap_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "TheWetZone";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "AvwvdhyXjnKmueSeRrjmMDr4QhPLw1o3n_h-xtmQZ6PKozlrw7a8WNCMyjq25RrC";
        }
    }
}