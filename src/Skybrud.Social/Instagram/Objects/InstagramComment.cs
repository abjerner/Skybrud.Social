using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramComment {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// The ID of the comment.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// The timestamp for when the comment was created.
        /// </summary>
        public DateTime Created { get; internal set; }

        /// <summary>
        /// The text/message of the comment.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// The user responsible for the comment.
        /// </summary>
        public InstagramUserSummary User { get; internal set; }

        #endregion

        #region Constructors

        internal InstagramComment() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a comment from the JSON file at the specified <var>path</var>.
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
        /// Gets a comment from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramComment Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramComment {
                JsonObject = obj,
                Id = obj.GetLong("id"),
                Created = SocialUtils.GetDateTimeFromUnixTime(obj.GetLong("created_time")),
                Text = obj.GetString("text"),
                User = InstagramUserSummary.Parse(obj.GetObject("from"))
            };
        }

        /// <summary>
        /// Gets an array of comments from the specified <var>JsonArray</var>.
        /// </summary>
        /// <param name="array">The instance of <var>JsonArray</var> to parse.</param>
        public static InstagramComment[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramComment[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}
