using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterUsersSearchResponse {

        public TwitterUser[] Data { get; private set; }

        public static TwitterUsersSearchResponse ParseJson(string json) {

            // Parse the JSON string to either an object (if any errors) or an
            // array of matched users if successful.
            IJsonObject converted = JsonConverter.Parse(json);

            // Check for any errors
            JsonObject obj = converted as JsonObject;
            if (obj != null) {
                JsonArray errors = obj.GetArray("errors");
                throw new TwitterException(
                    errors.GetObject(0).GetInt32("code"),
                    errors.GetObject(0).GetString("message")
                );
            }

            // Parse the array
            return new TwitterUsersSearchResponse {
                Data = ((JsonArray) converted).ParseMultiple(TwitterUser.Parse)
            };

        }

    }

}
