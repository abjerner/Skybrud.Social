using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing a comment of a media.
    /// </summary>
    public class InstagramComment : SocialJsonObject {

        #region Properties
        
        /// <summary>
        /// Gets the ID of the comment.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets the timestamp for when the comment was created.
        /// </summary>
        public DateTime Created { get; internal set; }

        /// <summary>
        /// Gets the text/message of the comment.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// Gets the user responsible for the comment.
        /// </summary>
        public InstagramUserSummary User { get; internal set; }

        #endregion

        #region Constructors

        private InstagramComment(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a comment from the JSON file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramComment LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a comment from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramComment ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a comment from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static InstagramComment Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramComment(obj) {
                Id = obj.GetInt64("id"),
                Created = SocialUtils.GetDateTimeFromUnixTime(obj.GetInt64("created_time")),
                Text = obj.GetString("text"),
                User = InstagramUserSummary.Parse(obj.GetObject("from"))
            };
        }

        #endregion

    }

}