using System;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookFeedResponse {

        public FacebookFeedEntry[] Data { get; private set; }

        public FacebookPaging Paging {
            get; private set;
        }

        public static FacebookFeedResponse ParseJson(string contents) {
            return Parse(JsonConverter.ParseObject(contents));
        }

        public static FacebookFeedResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookFeedResponse {
                Data = obj.GetArray("data", FacebookFeedEntry.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }

    }

}
