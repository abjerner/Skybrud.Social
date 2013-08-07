using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterReverseGeocodeResponse {

        public TwitterPlace[] Places { get; private set; }
        public string Url { get; private set; }
        public double Accuracy { get; private set; }
        public string Granularity { get; private set; }
        public TwitterCoordinates Coordinates { get; private set; }

        public static TwitterReverseGeocodeResponse ParseJson(string contents) {

            // Deserialize the JSON
            JsonObject json = JsonConverter.ParseObject(contents);

            // Can there be multiple errors? Need. More. Data.
            if (json.HasValue("errors")) {
                JsonArray errors = json.GetArray("errors");
                throw new TwitterException(
                    errors.GetObject(0).GetInt("code"),
                    errors.GetObject(0).GetString("message")
                );
            }

            // Parse the JSON object
            return Parse(json);

        }

        public static TwitterReverseGeocodeResponse Parse(JsonObject obj) {
           
            // Check if null
            if (obj == null) return null;

            // Some parsing
            JsonObject result = obj.GetObject("result");
            JsonObject query = obj.GetObject("query");
            JsonObject parameters = query == null ? null : query.GetObject("params");
            JsonObject coordinates1 = parameters == null ? null : parameters.GetObject("coordinates");

            // Must not be null
            if (result == null || query == null || parameters == null || coordinates1 == null) return null;
            
            // Initalize the response object
            return new TwitterReverseGeocodeResponse {
                Places = TwitterPlace.ParseMultiple(result.GetArray("places")),
                Url = query.GetString("url"),
                Granularity = parameters.GetString("granularity"),
                Coordinates = TwitterCoordinates.Parse(parameters.GetObject("coordinates")),
                Accuracy = parameters.GetDouble("accuracy")
            };

        }

    }

}
