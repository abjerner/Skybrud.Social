using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookStatusMessage : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the status message.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets brief information about the entity (eg. user) that posted the status message.
        /// </summary>
        public FacebookObject From { get; private set; }

        /// <summary>
        /// Gets the text of the status message.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets an array of all tags used in the message.
        /// </summary>
        public FacebookMessageTag[] MessageTags { get; private set; }

        /// <summary>
        /// Gets brief information about the application used to post the status message. If the status message was
        /// posted directly from facebook.com, this property will return <code>NULL</code>.
        /// </summary>
        public FacebookObject Application { get; private set; }

        /// <summary>
        /// Gets the timestamp for when the status message was created.
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// ets the timestamp for when the status message was last updated.
        /// </summary>
        public DateTime UpdatedTime { get; private set; }

        #endregion

        #region Constructors

        private FacebookStatusMessage(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookStatusMessage Parse(JsonObject obj) {
            if (obj == null) return null;
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