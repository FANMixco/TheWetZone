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

            sqliteDB cn = new sqliteDB();
            cn.open();

            cm.setCenter(21.134109, -102.575410, 4.5, true);

            string query = "SELECT * FROM typesTable";
            List<types> iconsHelpInfo = cn.db.Query<types>(query);

            var valuesI = iconsHelpInfo[0];
            txtPTitle.Text = valuesI.type.ToUpper();

            //Load all places
            query = "SELECT idplace, CASE WHEN idtype=1 THEN ('/Img/hostels/' || idplace || '.jpg') ELSE ('/Img/locations/' || idtype || '.jpg') END AS photo, title, descripcion, telephone, idcountry, latitude, longitude, idtype FROM placesTable WHERE idtype=" + id;
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

                string url = "/pages/pDetail.xaml?id=" + p.idplace.ToString() + "&idType=" + this.NavigationContext.QueryString["id"];
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }

        }
    }
}