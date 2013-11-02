﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Device.Location;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Input;
using System.Windows.Controls;
using The_Wet_Zone.Resources;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;

namespace The_Wet_Zone.classes
{
    public class Tuple<T1, T2, T3, T4>
    {
        public T1 Latitude { get; set; }
        public T2 Longitude { get; set; }
        public T3 Name { get; set; }
        public T4 idCountry { get; set; }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            Latitude = item1;
            Longitude = item2;
            Name = item3;
            idCountry = item4;
        }
    }

    class createMap
    {
        private Map mapLocation;
        private double Latitude;
        private double Longitude;
        private GeoCoordinateWatcher myCoordinateWatcher;

        public createMap(Map temp)
        {
            this.mapLocation = temp;
        }

        public void setCenter(double lat, double lon, double zoom, bool bar)
        {
            this.Latitude = lat;
            this.Longitude = lon;

            this.mapLocation.Center = new GeoCoordinate(this.Latitude, this.Longitude);
            this.mapLocation.ZoomLevel = zoom;

            myCoordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            myCoordinateWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(this.myCoordinateWatcher_PositionChanged);

        }

        private void myCoordinateWatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (!e.Position.Location.IsUnknown)
            {
                Latitude = e.Position.Location.Latitude;
                Longitude = e.Position.Location.Longitude;
                mapLocation.Center = new GeoCoordinate(Latitude, Longitude);
            }
        }

        public void addPushpins(List<Tuple<double, double, string, int>> Values)
        {
            foreach (Tuple<double, double, string, int> location in Values)
            {

                MapOverlay overlay = new MapOverlay();

                ImageBrush ib = new ImageBrush();
                ib.ImageSource =
                new BitmapImage(new Uri("/Img/places/albergues.png", UriKind.Relative));

                // Create a map marker
                Rectangle rectangle = new Rectangle();

                rectangle.Fill = ib;

                rectangle.Height = 40;
                rectangle.Width = 40;


                rectangle.MouseLeftButtonUp += getHandler(location);

                overlay.Content = rectangle;

                overlay.GeoCoordinate = new GeoCoordinate(location.Latitude, location.Longitude);
                
                MapLayer layer = new MapLayer();
                layer.Add(overlay);

                mapLocation.Layers.Add(layer);

            }
        }

        public MouseButtonEventHandler getHandler(Tuple<double, double, string, int> cls)
        {
            return delegate(object sender, MouseButtonEventArgs e)
            {

                string url = "/pages/pDetail.xaml?id=" + "&id=" + cls.idCountry.ToString();

                CustomMessageBox messageBox = new CustomMessageBox()
                {
                    Caption = AppResources.Learn.ToString(),
                    Message = cls.Name,
                    LeftButtonContent = AppResources.Ok.ToString(),
                    RightButtonContent = AppResources.View.ToString()
                };

                messageBox.Dismissed += (s1, e1) =>
                {
                    switch (e1.Result)
                    {
                        case CustomMessageBoxResult.LeftButton:
                            break;
                        case CustomMessageBoxResult.RightButton:
                            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri(url, UriKind.Relative));
                            break;
                        case CustomMessageBoxResult.None:
                            break;
                        default:
                            break;
                    }
                };
                messageBox.Show();
            };
        }
    }
}
