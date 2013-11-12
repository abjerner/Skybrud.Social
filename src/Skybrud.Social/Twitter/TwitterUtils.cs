using System;
using System.Globalization;
using Skybrud.Social.Twitter.Enums;

namespace Skybrud.Social.Twitter {
    
    public class TwitterUtils {
        
        public static DateTime ParseDateTime(string date) {
            return DateTime.ParseExact(date, "ddd MMM dd HH:mm:ss K yyyy", new CultureInfo("en-US"));
        }

        public static DateTime ParseDateTimeUtc(string date) {
            return DateTime.ParseExact(date, "ddd MMM dd HH:mm:ss K yyyy", new CultureInfo("en-US"), DateTimeStyles.AdjustToUniversal);
        }

        public static TwitterGranularity ParseGranularity(string str) {
            switch (str.ToLower()) {
                case "neighborhood": return TwitterGranularity.Neighborhood;
                case "poi": return TwitterGranularity.Poi;
                case "city": return TwitterGranularity.City;
                case "admin": return TwitterGranularity.Admin;
                case "country": return TwitterGranularity.Country;
                default: throw new Exception("Unknown granularity \"" + str + "\"");
            }
        }
    
    }

}
