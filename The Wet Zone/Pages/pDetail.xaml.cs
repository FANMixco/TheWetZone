using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using The_Wet_Zone.classes;
using The_Wet_Zone.ViewModels;
using Microsoft.Phone.Maps.Controls;
using The_Wet_Zone.Resources;

namespace The_Wet_Zone.Pages
{
    public partial class pDescription : PhoneApplicationPage
    {
        createMap cm;

        public pDescription()
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
            cm = new createMap(placesMap);
            int id = int.Parse(this.NavigationContext.QueryString["id"]);

            sqliteDB cn = new sqliteDB();
            cn.open();

            //Load all places
            string query = "SELECT idplace, CASE WHEN idtype=1 THEN ('/Img/hostels/' || idplace || '.jpg') ELSE ('/Img/locations/' || idtype || '.jpg') END AS photo, title, descripcion, p.latitude, p.longitude, idtype, address , (state || ', ' || c.name) fullAddress, telephone FROM placesTable p, statesTable s, countriesTable c WHERE p.idstate = s.idstate AND c.idcountry = s.idcountry AND idplace=" + id;
            List<placeTry> placeInfo = cn.db.Query<placeTry>(query);

            var values = placeInfo[0];

            imgPlace.Source = new BitmapImage(new Uri(values.photo, UriKind.Relative));
            txtPName.Text = values.title.ToUpper();
            txtDescript.Text = values.descripcion;
            txtPhone.Text = values.telephone;
            txtAddress.Text = values.address + ", " + values.fullAddress;

            cm.setCenter(values.latitude, values.longitude, 13, true);

            load_Places();
            cn.close();
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

        private void phone_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = txtPhone.Text;
            phoneCallTask.DisplayName = txtPName.Text;

            phoneCallTask.Show();
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