using System;
using System.Globalization;

namespace Skybrud.Social.Twitter {
    
    public class TwitterUtils {
        
        public static DateTime ParseDateTime(string date) {
            return DateTime.ParseExact(date, "ddd MMM dd HH:mm:ss K yyyy", new CultureInfo("en-US"));
        }

        public static DateTime ParseDateTimeUtc(string date) {
            return DateTime.ParseExact(date, "ddd MMM dd HH:mm:ss K yyyy", new CultureInfo("en-US"), DateTimeStyles.AdjustToUniversal);
        }
    
    }

}
