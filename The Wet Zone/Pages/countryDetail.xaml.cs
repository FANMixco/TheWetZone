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

namespace The_Wet_Zone.Pages
{
    public partial class countryDetail : PhoneApplicationPage
    {
        public countryDetail()
        {
            InitializeComponent();
        }

        private void placestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                place p = item.SelectedItem as place;

                string url = "/pages/pDetail.xaml?id=" + p.idplace.ToString() + "&idType=" + p.idtype.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(this.NavigationContext.QueryString["id"]);
            List<place> source = new List<place>();
            createMap cm = new createMap(placesMap);

            switch (id)
            {
                case 2:

                    txtCName.Text = "Guatemala";

                    cm.setCenter(15.783471, -90.230759, 7, true);

                    for (int i = 0; i < 3; i++)
                    {
                        List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                        locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.hostals[i].latitude, App.ViewModel.hostals[i].longitude, App.ViewModel.hostals[i].title, App.ViewModel.hostals[i].idplace));

                        cm.addPushpins(locations, 0);
                        source.Add(new place {idplace =  App.ViewModel.hostals[i].idplace, photo = App.ViewModel.hostals[i].photo, title= App.ViewModel.hostals[i].title, descripcion = App.ViewModel.hostals[i].descripcion, telephone =  App.ViewModel.hostals[i].telephone, idcountry = App.ViewModel.hostals[i].idcountry, latitude =  App.ViewModel.hostals[i].latitude, longitude =  App.ViewModel.hostals[i].longitude, idtype = App.ViewModel.hostals[i].idtype });

                    }

                    placestList.ItemsSource = source;

                    break;
                case 3:

                    txtCName.Text = "México";

                    cm.setCenter(23.634502, -102.552784, 4.5, true);

                    for (int i = 3; i < 42; i++)
                    {
                        List<The_Wet_Zone.classes.Tuple<double, double, string, int>> locations = new List<The_Wet_Zone.classes.Tuple<double, double, string, int>>();
                        locations.Add(new The_Wet_Zone.classes.Tuple<double, double, string, int>(App.ViewModel.hostals[i].latitude, App.ViewModel.hostals[i].longitude, App.ViewModel.hostals[i].title, App.ViewModel.hostals[i].idplace));

                        cm.addPushpins(locations, 0);
                        source.Add(new place {idplace =  App.ViewModel.hostals[i].idplace, photo = App.ViewModel.hostals[i].photo, title= App.ViewModel.hostals[i].title, descripcion = App.ViewModel.hostals[i].descripcion, telephone =  App.ViewModel.hostals[i].telephone, idcountry = App.ViewModel.hostals[i].idcountry, latitude =  App.ViewModel.hostals[i].latitude, longitude =  App.ViewModel.hostals[i].longitude, idtype = App.ViewModel.hostals[i].idtype });

                    }

                    placestList.ItemsSource = source;

                    break;

            }

        }
    }
}