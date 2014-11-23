using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    /// <summary>
    /// Class representing a summary for the comments of a given object.
    /// </summary>
    public class FacebookCommentsSummary : SocialJsonObject {

        public string Order { get; private set; }

        public int TotalCount { get; private set; }
        
        #region Constructors

        private FacebookCommentsSummary(JsonObject obj) : base(obj) { }

        #endregion

        public static FacebookCommentsSummary Parse(JsonObject obj) {
            return new FacebookCommentsSummary(obj) {
                Order = obj.GetString("order"),
                TotalCount = obj.GetInt32("total_count")
            };
        }

    }

}
