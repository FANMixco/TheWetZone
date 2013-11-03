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

            switch (id)
            {
                case 0:
                    txtPTitle.Text = "Albergues";
                    placestList.ItemsSource = App.ViewModel.hostals;
                    break;
            }

        }

        private void placestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                place p = item.SelectedItem as place;

                string url = "/pages/pDetail.xaml?id=" + p.idplace.ToString() + "&idType=" + this.NavigationContext.QueryString["id"];
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }

        }
    }
}