using QiblaCompass.Model;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiblaCompass.ViewModel
{
    public class QiblaViewModel
    {
        public QiblaModel qiblaDirection { get; set; }

        public QiblaViewModel()
        {
            qiblaDirection = new QiblaModel();
        }

        public double GetQiblaAngleInDegrees()
        {
            GeoCoordinate kaabaLoc = qiblaDirection.KaabahLocation;
            double latitudeRadians = qiblaDirection.MyLocation.Latitude * (Math.PI / 180);
            double longitudeRadians = qiblaDirection.MyLocation.Longitude * (Math.PI / 180);
            double kaabaLatRadians = kaabaLoc.Latitude * (Math.PI / 180);
            double kaabaLonRadians = kaabaLoc.Longitude * (Math.PI / 180);

            var qiblaAngel = Math.Round((Math.Atan2((Math.Sin((kaabaLonRadians - longitudeRadians))), (Math.Cos(latitudeRadians) * Math.Tan(kaabaLatRadians) - Math.Sin(latitudeRadians) * Math.Cos(kaabaLonRadians - longitudeRadians))) * (180 / Math.PI)));
            return qiblaAngel;
        }
    }
}
