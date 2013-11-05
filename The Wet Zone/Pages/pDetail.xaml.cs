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

namespace The_Wet_Zone.Pages
{
    public partial class pDescription : PhoneApplicationPage
    {
        createMap cm;

        public pDescription()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            cm = new createMap(placesMap);
            int id = int.Parse(this.NavigationContext.QueryString["id"]);

            int idType = int.Parse(this.NavigationContext.QueryString["idType"]);

            switch (idType)
            {
                case 0:
                    imgPlace.Source = App.ViewModel.hostals[id - 1].photo;
                    txtPName.Text = App.ViewModel.hostals[id - 1].title;
                    txtDescript.Text = App.ViewModel.hostals[id - 1].descripcion;
                    txtPhone.Text = App.ViewModel.hostals[id - 1].telephone;
                    cm.setCenter(App.ViewModel.hostals[id - 1].latitude, App.ViewModel.hostals[id - 1].longitude, 14, true);
                    break;
                case 3:
                    imgPlace.Source = App.ViewModel.embassies[id - 1].photo;
                    txtPName.Text = App.ViewModel.embassies[id - 1].title;
                    txtDescript.Text = App.ViewModel.embassies[id - 1].descripcion;
                    txtPhone.Text = App.ViewModel.embassies[id - 1].telephone;
                    cm.setCenter(App.ViewModel.embassies[id - 1].latitude, App.ViewModel.embassies[id - 1].longitude, 14, true);
                    break;
                case 6:
                    imgPlace.Source = App.ViewModel.warnings[id - 1].photo;
                    txtPName.Text = App.ViewModel.warnings[id - 1].title;
                    txtDescript.Text = App.ViewModel.warnings[id - 1].descripcion;
                    txtPhone.Text = App.ViewModel.warnings[id - 1].telephone;
                    cm.setCenter(App.ViewModel.warnings[id - 1].latitude, App.ViewModel.warnings[id - 1].longitude, 14, true);
                    break;
                case 7:
                    imgPlace.Source = App.ViewModel.trains[id - 1].photo;
                    txtPName.Text = App.ViewModel.trains[id - 1].title;
                    txtDescript.Text = App.ViewModel.trains[id - 1].descripcion;
                    txtPhone.Text = App.ViewModel.trains[id - 1].telephone;
                    cm.setCenter(App.ViewModel.trains[id - 1].latitude, App.ViewModel.trains[id - 1].longitude, 14, true);
                    break;
                case 8:
                    imgPlace.Source = App.ViewModel.water[id - 1].photo;
                    txtPName.Text = App.ViewModel.water[id - 1].title;
                    txtDescript.Text = App.ViewModel.water[id - 1].descripcion;
                    txtPhone.Text = App.ViewModel.water[id - 1].telephone;
                    cm.setCenter(App.ViewModel.water[id - 1].latitude, App.ViewModel.water[id - 1].longitude, 14, true);
                    break;
            }
            load_Places(idType);

        }

        private void load_Places(int idType)
        {
            for (int i = 0; i < App.ViewModel.embassies.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.embassies[i].latitude, App.ViewModel.embassies[i].longitude, App.ViewModel.embassies[i].title, App.ViewModel.embassies[i].idplace));

                cm.addPushpins(locations, idType);
            }

            for (int i = 0; i < App.ViewModel.warnings.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.warnings[i].latitude, App.ViewModel.warnings[i].longitude, App.ViewModel.warnings[i].title, App.ViewModel.warnings[i].idplace));

                cm.addPushpins(locations, idType);
            }

            for (int i = 0; i < App.ViewModel.hostals.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.hostals[i].latitude, App.ViewModel.hostals[i].longitude, App.ViewModel.hostals[i].title, App.ViewModel.hostals[i].idplace));

                cm.addPushpins(locations, idType);
            }

            for (int i = 0; i < App.ViewModel.trains.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.trains[i].latitude, App.ViewModel.trains[i].longitude, App.ViewModel.trains[i].title, App.ViewModel.trains[i].idplace));

                cm.addPushpins(locations, idType);
            }

            for (int i = 0; i < App.ViewModel.water.Count; i++)
            {
                List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.water[i].latitude, App.ViewModel.water[i].longitude, App.ViewModel.water[i].title, App.ViewModel.water[i].idplace));

                cm.addPushpins(locations, idType);
            }
        
        }

        private void phone_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = txtPhone.Text;
            phoneCallTask.DisplayName = txtPName.Text;

            phoneCallTask.Show();
        }
    }
}