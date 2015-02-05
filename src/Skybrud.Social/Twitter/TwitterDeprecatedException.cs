using System;
using System.Collections;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter {

    [Obsolete("Use class TwitterException instead")]
    public class TwitterDeprecatedException : Exception {

        public int Code { get; private set; }

        public TwitterDeprecatedException(int code, string message) : base(message) {
            Code = code;
        }

        public static TwitterDeprecatedException Parse(string str) {
            IJsonObject obj = JsonConverter.Parse(str);
            return obj is JsonArray ? Parse(obj as JsonArray) : Parse(obj as JsonObject);
        }

        public static TwitterDeprecatedException Parse(JsonArray array) {
            return array == null ? null : Parse(array.GetObject(0));
        }
        
        public static TwitterDeprecatedException Parse(JsonObject obj) {

            // TODO: Does this mess up the stack trace?

            if (obj.HasValue("errors") && obj.Dictionary["errors"] is ArrayList) {
                obj = obj.GetArray("errors").GetObject(0);
            }

            throw new TwitterDeprecatedException(obj.GetInt32("code"), obj.GetString("message"));
        
        }
    
    }

}
