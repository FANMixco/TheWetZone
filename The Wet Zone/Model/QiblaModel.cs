using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiblaCompass.Model
{
    public class QiblaModel 
    {
        public GeoCoordinate _kaabahLocation = new GeoCoordinate(21.4225,39.8261);

        public GeoCoordinate KaabahLocation
        {
            get { return this._kaabahLocation; }
        }

        public GeoCoordinate _myLocation = new GeoCoordinate(25.171077, 55.242455);

        public GeoCoordinate MyLocation
        {
            get { return this._myLocation; }
        }
    }
}
