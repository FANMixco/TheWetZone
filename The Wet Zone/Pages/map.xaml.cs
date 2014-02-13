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
using Microsoft.Phone.Maps.Controls;
using The_Wet_Zone.Resources;

namespace The_Wet_Zone.Pages
{
    public partial class map : PhoneApplicationPage
    {
        public map()
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
            List<countryTry> sourceC = new List<countryTry>();

            List<iconsHelpTry> source = new List<iconsHelpTry>();
            createMap cm = new createMap(placesMap);

            cm.setCenter(21.134109, -102.575410, 4.5, true);

            sqliteDB cn = new sqliteDB();
            cn.open();

            sqliteDB tempDB = new sqliteDB();
            tempDB.open();

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

            //Load locations with info
            query = "SELECT * FROM typesTable";
            List<types> typeInfo = cn.db.Query<types>(query);

            for (int i = 0; i < typeInfo.Count; i++)
            {
                var values = typeInfo[i];
                query = "SELECT COUNT(idtype) total FROM placesTable WHERE idtype=" + values.idtype;
                List<result> temp = tempDB.db.Query<result>(query);

                if (temp[0].total > 0)
                    source.Add(new iconsHelpTry { idicon = values.idtype, icon = "/Img/locations/" + values.idtype + ".jpg", title = values.type, description = values.description });
            }

            pList.ItemsSource = source;

            //Load countries with info
            query = "SELECT idcountry, name, ('/Img/flags/' || idcountry || '.png') AS photo, nationality FROM countriesTable";
            List<countryTry> countryInfo = cn.db.Query<countryTry>(query);

            for (int i = 0; i < countryInfo.Count; i++)
            {
                var values = countryInfo[i];
                query = "SELECT COUNT(idcountry) total FROM placesTable p, statesTable s WHERE s.idstate = p.idstate AND idcountry=" + values.idcountry;
                List<result> temp = tempDB.db.Query<result>(query);

                if (temp[0].total > 0)
                    sourceC.Add(new countryTry { idcountry = values.idcountry, name = values.name, photo = values.photo });
            }

            cn.close();
            tempDB.close();

            cList.ItemsSource = sourceC;
        }

        private void cList_Tap(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                countryTry c = item.SelectedItem as countryTry;

                string url = "/pages/countryDetail.xaml?id=" + c.idcountry.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            } 
        }

        private void pList_Tap(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                iconsHelpTry ih = item.SelectedItem as iconsHelpTry;

                string url = "/pages/places.xaml?id=" + ih.idicon.ToString();
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

    }
}