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
using System.Windows.Media.Imaging;

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

            sqliteDB cn = new sqliteDB();
            cn.open();

            string query = "SELECT idtip, tip AS name, description FROM tipsTable WHERE idtip=" + id.ToString();
            List<tipsInfoTry> tipsInfo = cn.db.Query<tipsInfoTry>(query);

            var values = tipsInfo[0];

            txtTName.Text = values.name;
            txtDesc.Text = values.description;
            imgTip.Source = new BitmapImage(new Uri("/Img/tips/"+values.idtip+ ".jpg", UriKind.Relative));
            cn.close();
        }
    }
}