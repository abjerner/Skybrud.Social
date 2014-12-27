using System;
using Skybrud.Social.Facebook.Objects.Events;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/event#read</cref>
    /// </see>
    public class FacebookEvent : SocialJsonObject {

        // 2014-12-27: The location of an event may be specified as either a string or an already created place.
        // According to the API documentation, the returned "venue" property will be of the type "Place", but the
        // returned data doesn't match a place. If the specified location is a string, the returned object for "venue"
        // will only contain the "name" property. If the location is specified as an already created place, the
        // returned will look similar the "location" property of a page, but also with an "id" property.

        // 2014-12-27: Even though the Facebook API documenation specifies that an event can have a "cover" property, I
        // haven't been able to find an event where that is the case. I'm not sure whether the property isn't used
        // anymore, or whether it simply depends on the scope (which wouldn't make sense).

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
        public FacebookEventOwner Owner { get; private set; }

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
        public FacebookEventVenue Venue { get; private set; }

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
                Owner = obj.GetObject("owner", FacebookEventOwner.Parse),
                Privacy = obj.GetString("privacy"),
                StartTime = obj.GetDateTime("start_time"),
                TimeZone = obj.GetString("timezone"),
                UpdatedTime = obj.GetDateTime("updated_time"),
                Venue = obj.GetObject("venue", FacebookEventVenue.Parse)
            };
        }

        #endregion

    }

}