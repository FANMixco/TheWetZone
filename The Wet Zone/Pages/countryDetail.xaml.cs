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
using Microsoft.Phone.Maps.Controls;
using The_Wet_Zone.Resources;

namespace The_Wet_Zone.Pages
{
    public partial class countryDetail : PhoneApplicationPage
    {
        public countryDetail()
        {
            InitializeComponent();
            createAppBar();
        }

        private void createAppBar()
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Opacity = 0.9;

            ApplicationBar.Mode = ApplicationBarMode.Minimized;

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

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            int id = int.Parse(this.NavigationContext.QueryString["id"]);
            List<placeTry> source = new List<placeTry>();
            createMap cm = new createMap(placesMap);

            sqliteDB cn = new sqliteDB();
            cn.open();

            string query = "SELECT * FROM countriesTable WHERE idcountry=" + id.ToString();
            List<countryTry> countryInfo = cn.db.Query<countryTry>(query);

            txtCName.Text = countryInfo[0].name.ToUpper();

            cm.setCenter(countryInfo[0].latitude, countryInfo[0].longitude, countryInfo[0].zoom, true);


            //Load all places
            try
            {
                query = "SELECT idplace, CASE WHEN idtype=1 THEN ('/Img/hostels/' || idplace || '.jpg') ELSE ('/Img/locations/' || idtype || '.jpg') END AS photo, title, p.latitude, p.longitude, idtype, CASE WHEN address IS NULL THEN (state || ', ' || c.name) ELSE (address || ', ' || state || ', ' || c.name) END AS fullAddress FROM placesTable p, statesTable s, countriesTable c WHERE p.idstate = s.idstate AND c.idcountry = s.idcountry AND c.idcountry=" + id.ToString();
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
            catch (Exception ex)
            {
                Console.Write(ex);
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