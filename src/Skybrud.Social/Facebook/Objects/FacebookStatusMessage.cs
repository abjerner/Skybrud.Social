using System;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookStatusMessage : SocialJsonObject {

        #region Properties


        /// <summary>
        /// The ID of the status message.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Brief information about the entity (eg. user) that posted the status message.
        /// </summary>
        public FacebookObject From { get; private set; }

        /// <summary>
        /// The text of the status message.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// An array of all tags used in the message.
        /// </summary>
        public FacebookMessageTag[] MessageTags { get; private set; }

        /// <summary>
        /// Brief information about the application used to post the status message. If
        /// the status message was posted directly from facebook.com, this property will
        /// return <var>NULL</var>.
        /// </summary>
        public FacebookObject Application { get; private set; }

        /// <summary>
        /// A timestamp for when the status message was created.
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// A timestamp for when the status message was last updated.
        /// </summary>
        public DateTime UpdatedTime { get; private set; }

        #endregion

        #region Constructors

        private FacebookStatusMessage(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookStatusMessage LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        public static FacebookStatusMessage ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        public static FacebookStatusMessage Parse(JsonObject obj) {

            // Return NULL if NULL
            if (obj == null) return null;

            // Some error checking
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);

            // Initialize the link object
            return new FacebookStatusMessage(obj) {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookObject.Parse),
                Message = obj.GetString("message"),
                MessageTags = FacebookMessageTag.ParseMultiple(obj.GetObject("message_tags")) ?? new FacebookMessageTag[0],
                Application = obj.GetObject("from", FacebookObject.Parse),
                CreatedTime = DateTime.Parse(obj.GetString("created_time")),
                UpdatedTime = DateTime.Parse(obj.GetString("updated_time"))
            };

        }

        #endregion

    }

}
