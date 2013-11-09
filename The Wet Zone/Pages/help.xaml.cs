using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using The_Wet_Zone.ViewModels;
using Microsoft.Phone.Tasks;
using The_Wet_Zone.classes;

namespace The_Wet_Zone.Pages
{
    public partial class help : PhoneApplicationPage
    {

        public help()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<iconsHelpTry> source = new List<iconsHelpTry>();

            sqliteDB cn = new sqliteDB();
            cn.open();

            string query = "SELECT * FROM typesTable";
            List<types> iconsHelpInfo = cn.db.Query<types>(query);

            source.Add(new iconsHelpTry { idicon = 0, icon = "/Img/large/0.png", title = "¡Estoy Aquí!", description = "Indica la ubicación actual del usuario." });

            //Load all icons
            for (int i = 0; i < iconsHelpInfo.Count; i++)
            {
                var values = iconsHelpInfo[i];
                source.Add(new iconsHelpTry { idicon = values.idtype, icon = "/Img/large/" + values.idtype + ".png", title = values.type, description = values.description });
            }
            cn.close();

            hList.ItemsSource = source;
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask
            {
                To = txtEmail.Text
            };

            emailComposeTask.Show();
        }

        private void TextBlock_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri(@"https://twitter.com/FANMixco");
            webBrowserTask.Show();
        }
    }
}