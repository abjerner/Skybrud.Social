using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookEvent : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the event.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the cover photo of the event.
        /// </summary>
        public FacebookCoverPhoto Cover { get; private set; }

        /// <summary>
        /// Gets the long-form description of the event.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the end time of the event. Not all events have an end time.
        /// </summary>
        public DateTime? EndTime { get; private set; }

        /// <summary>
        /// Gets whether the event only has a date specified, but no time.
        /// </summary>
        public bool IsDateOnly { get; private set; }

        /// <summary>
        /// Gets the location of the event, if any.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the profile that created the event.
        /// </summary>
        public object Owner { get; private set; }

        /// <summary>
        /// Gets who can see the event.
        /// </summary>
        public string Privacy { get; private set; }

        /// <summary>
        /// Gets the start time of the event.
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Gets the timezone of the event.
        /// </summary>
        public string TimeZone { get; private set; }

        /// <summary>
        /// Gets the last time the event was updated.
        /// </summary>
        public DateTime UpdatedTime { get; private set; }

        /// <summary>
        /// Gets the vanue hosting the event, if any.
        /// </summary>
        public object Venue { get; private set; }

        #endregion

        #region Constructors

        private FacebookEvent(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookEvent Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookEvent(obj) {
                Id = obj.GetString("id"),
                Cover = obj.GetObject("cover", FacebookCoverPhoto.Parse),
                Description = obj.GetString("description"),
                EndTime = obj.HasValue("end_time") ? (DateTime?)obj.GetDateTime("end_time") : null,
                IsDateOnly = obj.HasValue("is_date_only") && obj.GetBoolean("is_date_only"),
                Location = obj.GetString("location"),
                Name = obj.GetString("name"),
                // TODO: Implement the "owner" property
                Privacy = obj.GetString("privacy"),
                StartTime = obj.GetDateTime("start_time"),
                TimeZone = obj.GetString("timezone"),
                UpdatedTime = obj.GetDateTime("updated_time")
                // TODO: Implement the "venue" property
            };
        }

        #endregion

    }

}