using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Dropbox {

    public static class JsonUtils {

        // TODO: This class should to moved to the main project prior to the next release

        public static JObject ParseJsonObject(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JObject.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });
        
        }

        public static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return func(ParseJsonObject(json));
        }

        public static JArray ParseJsonArray(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JArray.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });
        
        }

        public static T ParseJsonArray<T>(string json, Func<JArray, T> func) {
            return func(ParseJsonArray(json));
        }

    }

}