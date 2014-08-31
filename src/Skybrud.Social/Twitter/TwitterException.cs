using System;
using System.Collections;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter {

    public class TwitterException : Exception {

        public int Code { get; private set; }

        public TwitterException(int code, string message) : base(message) {
            Code = code;
        }

        public static TwitterException Parse(string str) {
            IJsonObject obj = JsonConverter.Parse(str);
            return obj is JsonArray ? Parse(obj as JsonArray) : Parse(obj as JsonObject);
        }

        public static TwitterException Parse(JsonArray array) {
            return array == null ? null : Parse(array.GetObject(0));
        }
        
        public static TwitterException Parse(JsonObject obj) {

            // TODO: Does this mess up the stack trace?

            if (obj.HasValue("errors") && obj.Dictionary["errors"] is ArrayList) {
                obj = obj.GetArray("errors").GetObject(0);
            }

            throw new TwitterException(obj.GetInt("code"), obj.GetString("message"));
        
        }
    
    }

}
