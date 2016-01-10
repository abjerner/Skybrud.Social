using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social {

    public static class SocialExtensions {
        
        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        public static double GetDistance(this ILocation loc1, ILocation loc2) {
            return SocialUtils.GetDistance(loc1, loc2);
        }
        
        public static string GetAsString(this HttpWebResponse response) {
            if (response == null) return null;
            using (var stream = response.GetResponseStream()) {
                if (stream == null) return null;
                using (StreamReader reader = new StreamReader(stream)) {
                    return reader.ReadToEnd();
                }
            }
        }
        
        public static void AppendQueryString(this UriBuilder builder, NameValueCollection values) {
            if (values == null || values.Count == 0) return;
            NameValueCollection nvc = SocialUtils.ParseQueryString(builder.Query);
            nvc.Add(values);
            builder.Query = SocialUtils.NameValueCollectionToQueryString(nvc);
        }
        
        public static UriBuilder MergeQueryString(this UriBuilder builder, NameValueCollection values) {
            if (values == null || values.Count == 0) return builder;
            builder.Query = SocialUtils.NameValueCollectionToQueryString(SocialUtils.ParseQueryString(builder.Query).Set(values));
            return builder;
        }
        
        public static NameValueCollection Set(this NameValueCollection subject, NameValueCollection values) {
            if (values == null || values.Count == 0) return subject;
            foreach (string key in values.AllKeys) {
                subject.Set(key, values[key]);
            }
            return subject;
        }
    
    }

}