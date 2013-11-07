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
    public partial class tips : PhoneApplicationPage
    {
        public tips()
        {
            InitializeComponent();
        }

        private void placestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                tipsInfoTry p = item.SelectedItem as tipsInfoTry;

                string url = "/pages/tipDetail.xaml?id=" + p.idtip.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            sqliteDB cn = new sqliteDB();
            cn.open();

            string query = "SELECT idtip, ('/Img/tips/' || idtip || '.jpg') photo, tip AS name, description FROM tipsTable";
            List<tipsInfoTry> tipsInfo = cn.db.Query<tipsInfoTry>(query);

            tipsList.ItemsSource = tipsInfo;
            cn.close();
        }
    }
}