using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterSearchTweetsResponse : SocialJsonObject {

        public TwitterStatusMessage[] Statuses { get; private set; }
        public TwitterSearchTweetMetaData MetaData { get; private set; }

        public TwitterSearchTweetsResponse(JsonObject obj) : base(obj) { }

        public static TwitterSearchTweetsResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        public static TwitterSearchTweetsResponse Parse(JsonObject obj) {

            if (obj == null) return null;

            if (obj.HasValue("errors")) {
                JsonArray errors = obj.GetArray("errors");
                throw new TwitterDeprecatedException(
                    errors.GetObject(0).GetInt32("code"),
                    errors.GetObject(0).GetString("message")
                );
            }

            // Parse the array
            return new TwitterSearchTweetsResponse(obj) {
                Statuses = obj.GetArray("statuses", TwitterStatusMessage.Parse),
                MetaData = obj.GetObject("search_metadata", TwitterSearchTweetMetaData.Parse)
            };

        }

    }

}
