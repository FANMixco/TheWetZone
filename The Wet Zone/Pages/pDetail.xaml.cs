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

namespace The_Wet_Zone.Pages
{
    public partial class pDescription : PhoneApplicationPage
    {
        public pDescription()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(this.NavigationContext.QueryString["id"]);

            int idType = int.Parse(this.NavigationContext.QueryString["idType"]);

            switch (idType)
            {
                case 0:
                    imgPlace.Source = App.ViewModel.hostals[id - 1].photo;
                    txtPName.Text = App.ViewModel.hostals[id - 1].title;
                    txtDescript.Text = App.ViewModel.hostals[id - 1].descripcion;
                    break;
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