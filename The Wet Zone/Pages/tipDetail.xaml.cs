using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace The_Wet_Zone.Pages
{
    public partial class tipDetail : PhoneApplicationPage
    {
        public tipDetail()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(this.NavigationContext.QueryString["id"]);

            txtTName.Text = App.ViewModel.tipsData[id - 1].name;
            txtDesc.Text = App.ViewModel.tipsData[id - 1].description;
            imgTip.Source = App.ViewModel.tipsData[id - 1].photo;
        }
    }
}