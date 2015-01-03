using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Comments {
    
    public class FacebookComment : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the comment.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets information about the person that made the comment.
        /// </summary>
        public FacebookFrom From { get; private set; }

        /// <summary>
        /// Gets the text of the comment.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets whether the authenticated user can remove the comment.
        /// </summary>
        public bool CanRemove { get; private set; }

        /// <summary>
        /// Gets the time the comment was made.
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// Gets the number of times the comment was liked.
        /// </summary>
        public int LikeCount { get; private set; }

        /// <summary>
        /// Gets whether the authenticated has like the comment.
        /// </summary>
        public bool UserLikes { get; private set; }

        // TODO: Add more properties: https://developers.facebook.com/docs/graph-api/reference/v2.2/comment#fields

        #endregion

        #region Constructors

        private FacebookComment(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookComment Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookComment(obj) {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookFrom.Parse),
                Message = obj.GetString("message"),
                CanRemove = obj.GetBoolean("can_remove"),
                CreatedTime = obj.GetDateTime("created_time"),
                LikeCount = obj.GetInt32("like_count"),
                UserLikes = obj.GetBoolean("user_likes")
            };

        }

        #endregion

    }

}