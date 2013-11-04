using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using The_Wet_Zone.Resources;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;
using The_Wet_Zone.ViewModels;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace The_Wet_Zone
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

        
        }

        public async Task<Windows.Devices.Geolocation.Geocoordinate> GetSinglePositionAsync()
        {
            Windows.Devices.Geolocation.Geolocator geolocator = new Windows.Devices.Geolocation.Geolocator();

            Windows.Devices.Geolocation.Geoposition geoposition = await geolocator.GetGeopositionAsync();

            SmsComposeTask smsComposeTask = new SmsComposeTask();

            smsComposeTask.To = "800-1515";
            smsComposeTask.Body = "¡Ayuda!" + "https://maps.google.com.sv/maps?q=" + geoposition.Coordinate.Latitude.ToString() + "," + geoposition.Coordinate.Longitude.ToString() + "&hl=es-419&ll=" + geoposition.Coordinate.Latitude.ToString() + "," + geoposition.Coordinate.Longitude.ToString();

            smsComposeTask.Show();

            return geoposition.Coordinate;
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("firstTime.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<FirstTime>));
                        List<FirstTime> data = (List<FirstTime>)serializer.Deserialize(stream);
                    }
                }
            }
            catch
            {
                MessageBox.Show(AppResources.Welcome1.ToString(), AppResources .welcomeHeader.ToString(), MessageBoxButton.OK);
                MessageBox.Show(AppResources.Profile1.ToString(), AppResources.Profile.ToString(), MessageBoxButton.OK);

                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("firstTime.xml", FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<FirstTime>));
                        using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                        {
                            serializer.Serialize(xmlWriter, GenerateFTData());
                        }
                    }
                }

            }

        }

        private void help_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/help.xaml", UriKind.Relative));
        }

        private void tips_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/tips.xaml", UriKind.Relative));
        }

        private void map_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/map.xaml", UriKind.Relative));
        }

        private void profile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/profile.xaml", UriKind.Relative));
        }

        private void sos_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GetSinglePositionAsync();
        }

        private void compass_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/compass.xaml", UriKind.Relative));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private List<FirstTime> GenerateFTData()
        {
            List<FirstTime> data = new List<FirstTime>();
            FirstTime ui = new FirstTime();

            ui.Activate = true;

            data.Add(ui);
            return data;
        }

        private void here_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/here.xaml", UriKind.Relative));
        }
    }
}