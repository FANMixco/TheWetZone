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
using SQLite;
using Windows.Storage;
using The_Wet_Zone.classes;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Microsoft.Phone.Reactive;

namespace The_Wet_Zone
{
    public partial class MainPage : PhoneApplicationPage
    {
        List<UserInfo> data;

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

        private void autoLogin()
        {

            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("user.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                        data = (List<UserInfo>)serializer.Deserialize(stream);
                    }
                }
            }
            catch
            {
            }

        }

        private void checkInternetConnection(double lat, double lng)
        {
            string user = "";

            if (data != null)
                user = data[0].Userid;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                cleanString cs = new cleanString();

                string url = "http://thewetzone.pixub.com/web_services/insertsosAlerts.php?uid=" + user + "&longitude=" + lng.ToString() + "&latitude=" + lat.ToString();

                WebClient w = new WebClient();
                Observable
                .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                .Subscribe(r =>
                {
                    var deserialized = JsonConvert.DeserializeObject<List<result>>(cs.clear(r.EventArgs.Result));

                    sendSMS(lat, lng);
                });
                w.DownloadStringAsync(
                new Uri(url));

            }
            else
                sendSMS(lat, lng);
        }

        private void sendSMS(double lat, double lng)
        {
            SmsComposeTask smsComposeTask = new SmsComposeTask();

            smsComposeTask.To = "800-1515";
            smsComposeTask.Body = AppResources.HelpMsg + " " + "http://bing.com/maps/?cp=" +lat.ToString() + "~" + lng.ToString() + "&lvl=16&sp=point." +lat.ToString() + "_" + lng.ToString() + "_";

            smsComposeTask.Show();
        }

        public async void GetSinglePositionAsync()
        {
            Windows.Devices.Geolocation.Geolocator geolocator = null;
            Windows.Devices.Geolocation.Geoposition geoposition = null;

            try
            {
                geolocator = new Windows.Devices.Geolocation.Geolocator();

                geoposition = await geolocator.GetGeopositionAsync();

                checkInternetConnection(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
            }
            catch
            {
                // Something else happened while acquiring the location.
                MessageBox.Show(AppResources.locationCheck.ToString(), "Error", MessageBoxButton.OK);
            }
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            autoLogin();

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
                sqliteDB cn = new sqliteDB();
                cn.createDB();
                cn.close();

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

        private void lamp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void PhoneApplicationPage_GotFocus(object sender, RoutedEventArgs e)
        {

        }

    }
}