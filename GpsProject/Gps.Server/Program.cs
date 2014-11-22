using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gps.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new TcpServer(5001);

            //var xx = Nmea2DecDeg("07133.7947", "W");
        }

        public static double Nmea2DecDeg(string NmeaLonLat, string Hemisphere)
        {
            int inx = NmeaLonLat.IndexOf(".");
            if (inx == -1)
            {
                return 0;    // Invalid syntax
            }
            string minutes_str = NmeaLonLat.Substring(inx - 2);
            double minutes = Double.Parse(minutes_str, new
                      System.Globalization.CultureInfo("en-US"));
            string degrees_str = NmeaLonLat.Substring(0, inx - 2);
            double degrees = Convert.ToDouble(degrees_str) + minutes / 60.0;
            if (Hemisphere.Equals("W") || Hemisphere.Equals("S"))
            {
                degrees = -degrees;

            }
            return degrees;
        }
    }
}
