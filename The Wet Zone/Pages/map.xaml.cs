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
            List<countryTry> sourceC = new List<countryTry>();

            List<iconsHelpTry> source = new List<iconsHelpTry>();
            createMap cm = new createMap(placesMap);

            cm.setCenter(21.134109, -102.575410, 4.5, true);

            sqliteDB cn = new sqliteDB();
            cn.open();

            sqliteDB tempDB = new sqliteDB();
            tempDB.open();

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
                query = "SELECT COUNT(idcountry) total FROM placesTable WHERE idcountry=" + values.idcountry;
                List<result> temp = tempDB.db.Query<result>(query);

                if (temp[0].total > 0)
                    sourceC.Add(new countryTry { idcountry = values.idcountry, name = values.name, photo = values.photo });
            }

            cn.close();
            tempDB.close();

            cList.ItemsSource = sourceC;
        }

        private void pList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                iconsHelpTry ih = item.SelectedItem as iconsHelpTry;

                string url = "/pages/places.xaml?id=" + ih.idicon.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }
        }

        private void cList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                countryTry c = item.SelectedItem as countryTry;

                string url = "/pages/countryDetail.xaml?id=" + c.idcountry.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }

        }
    }
}