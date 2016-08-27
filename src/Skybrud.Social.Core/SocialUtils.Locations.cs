using System;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with helper methods related to locations.
        /// </summary>
        public static class Locations {

            #region Constants

            /// <summary>
            /// Gets the equatorial radius of Earth (in meters).
            /// 
            /// Notice: When comparing with various online services, they seem to use 6378137 meters for the equatorial
            /// radius of Earth, while 6378136.6 meters for the equatorial radius is more precise.
            /// </summary>
            /// <see>
            ///     <cref>https://web.archive.org/web/20130826043456/http://asa.usno.navy.mil/SecK/2011/Astronomical_Constants_2011.txt</cref>
            /// </see>
            public const double EarthEquatorialRadiusMeters = 6378136.6;

            #endregion

            #region Static methods

            /// <summary>
            /// Calculates the distance in meters between two GPS locations.
            /// </summary>
            /// <param name="loc1">The first location.</param>
            /// <param name="loc2">The second location.</param>
            /// <returns>Returns the distance in meters between the two locations.</returns>
            public static double GetDistance(ILocation loc1, ILocation loc2) {
                return GetDistance(loc1.Latitude, loc1.Longitude, loc2.Latitude, loc2.Longitude);
            }

            /// <summary>
            /// Calculates the distance in meters between two GPS locations.
            /// </summary>
            /// <param name="lat1">The latitude of the first location.</param>
            /// <param name="lng1">The longitude of the first location.</param>
            /// <param name="lat2">The latitude of the second location.</param>
            /// <param name="lng2">The longitude of the second location.</param>
            /// <returns>Returns the distance in meters between the two locations.</returns>
            public static double GetDistance(double lat1, double lng1, double lat2, double lng2) {

                double ee = (Math.PI * lat1 / 180);
                double f = (Math.PI * lng1 / 180);
                double g = (Math.PI * lat2 / 180);
                double h = (Math.PI * lng2 / 180);
                double i = (Math.Cos(ee) * Math.Cos(g) * Math.Cos(f) * Math.Cos(h) + Math.Cos(ee) * Math.Sin(f) * Math.Cos(g) * Math.Sin(h) + Math.Sin(ee) * Math.Sin(g));
                double j = (Math.Acos(i));

                // Multiply with the equatorial radius of Earth
                return (6378136.6 * j);

            }

            #endregion

        }

    }

}