using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced {
    
    public class VimeoUtils {

        /// <summary>
        /// Based on the structure of the JSON response received from Vimeo,
        /// it would seem that it originates from some XML, so below is some
        /// "ugly" parsing to make up for this structure.
        /// </summary>
        public static T[] ParseFromParent<T>(JsonObject obj, string plural, string singular, Func<JsonObject, T> func) {
            JsonObject cast = obj.GetObject(plural);
            if (cast != null) {
                if (cast.IsArray(singular)) return cast.GetArray(singular).ParseMultiple(func);
                if (cast.IsObject(singular)) return new[] { cast.GetObject(singular, func) };
            }
            return new T[0];
        }

        public static string TrimToNull(string str) {
            if (str == null) return null;
            str = str.Trim();
            return str == "" || str == "0" ? null : str;
        }

    }

}
