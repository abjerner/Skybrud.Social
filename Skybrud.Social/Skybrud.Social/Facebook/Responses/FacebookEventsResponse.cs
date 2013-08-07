using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookEventsResponse {

        public FacebookEventSummary[] Data {
            get; private set;
        }

        public FacebookPaging Paging {
            get; private set;
        }

        public static FacebookEventsResponse ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        public static FacebookEventsResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookEventsResponse {
                Data = obj.GetArray("data", FacebookEventSummary.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }

    }

}
