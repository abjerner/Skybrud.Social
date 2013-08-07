using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookCommentSummary {

        public string Id { get; private set; }
        public FacebookIdName From { get; private set; }
        public string Message { get; private set; }
        public FacebookMessageTag[] MessageTags { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public int Likes { get; private set; }

        public static FacebookCommentSummary Parse(JsonObject obj) {
            return new FacebookCommentSummary {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookIdName.Parse),
                Message = obj.GetString("message"),
                MessageTags = obj.GetArray("message_tags", FacebookMessageTag.Parse),
                CreatedTime = obj.GetDateTime("created_time"),
                Likes = obj.HasValue("likes") ? obj.GetInt("likes") : 0
            };
        }

        public static FacebookCommentSummary[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookCommentSummary[0] : array.ParseMultiple(Parse);
        }

    }

}
