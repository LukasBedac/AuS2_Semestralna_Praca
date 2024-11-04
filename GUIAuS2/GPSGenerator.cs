using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semestralna_Praca1;
namespace GUIAuS2
{
    public static class GPSGenerator
    {
        private static Random rand = new Random();
        private static string[] latitude = { "S", "N" };
        private static string[] longtitude = { "E", "W" };
        public static GPS GetGPS() 
        {           
            GPS gps = new GPS();
            gps.LatitudeCoord = rand.NextDouble();
            gps.LongtitudeCoord = rand.NextDouble();
            gps.Latitude = rand.NextDouble() < 0.5 ? latitude[0] : latitude[1];
            gps.Longtitude = rand.NextDouble() < 0.5 ? longtitude[0] : longtitude[1];
            return gps;
        }
    }
}
