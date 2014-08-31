using System;
using Skybrud.Social.Google.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses {
    
    public class AnalyticsResponse {

        public static JsonObject Validate(JsonObject obj) {

            // Shoduln't be NULL
            if (obj == null) throw new ArgumentNullException("obj");

            // Attempt to get the error object
            JsonObject error = obj.GetObject("error");

            // Throw an exception based on the error response
            if (error != null) {
                throw new GoogleApiException(error.GetInt("code"), error.GetString("message"));
            }

            // Just return the JSON object
            return obj;

        }

        public static JsonObject Validate(string response) {
            return Validate(JsonObject.ParseJson(response));
        }

    }

}
