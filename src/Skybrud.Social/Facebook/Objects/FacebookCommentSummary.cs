using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookCommentSummary : SocialJsonObject {

        public string Id { get; private set; }
        public FacebookObject From { get; private set; }
        public string Message { get; private set; }
        public FacebookMessageTag[] MessageTags { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public int Likes { get; private set; }
        
        #region Constructors

        private FacebookCommentSummary(JsonObject obj) : base(obj) { }

        #endregion

        public static FacebookCommentSummary Parse(JsonObject obj) {
            return new FacebookCommentSummary(obj) {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookObject.Parse),
                Message = obj.GetString("message"),
                MessageTags = obj.GetArray("message_tags", FacebookMessageTag.Parse),
                CreatedTime = obj.GetDateTime("created_time"),
                Likes = obj.HasValue("likes") ? obj.GetInt("likes") : 0
            };
        }

    }

}
