using System;
using Skybrud.Social.Json;
using Skybrud.Social.Time;

namespace Skybrud.Social.Facebook.Objects.Events {

    /// <summary>
    /// Class representing an event in the Facebook Graph API.
    /// </summary>
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

        #region Properties mapped from Facebook

        /// <summary>
        /// Gets the ID of the event.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the cover photo of the event, or <code>null</code> if not available/specified.
        /// </summary>
        public FacebookCoverPhoto Cover { get; private set; }

        /// <summary>
        /// Gets the name of the event, or <code>null</code> if not available.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the long-form description of the event, or <code>null</code> if not available/specified.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the start time of the event.
        /// </summary>
        public SocialDateTime StartTime { get; private set; }

        /// <summary>
        /// Gets the end time of the event. Not all events have an end time.
        /// </summary>
        public SocialDateTime EndTime { get; private set; }

        /// <summary>
        /// Gets the profile that created the event, or <code>null</code> if not available.
        /// </summary>
        public FacebookEventOwner Owner { get; private set; }

        /// <summary>
        /// Gets who can see the event.
        /// </summary>
        public string Privacy { get; private set; }

        /// <summary>
        /// Gets the timezone of the event.
        /// </summary>
        public string TimeZone { get; private set; }

        /// <summary>
        /// Gets the last time the event was updated.
        /// </summary>
        public SocialDateTime UpdatedTime { get; private set; }

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        public string Type { get; private set; }

        #endregion

        #region Custom properties

        /// <summary>
        /// Gets whether a name was specified for the event.
        /// </summary>
        public bool HasName {
            get { return !String.IsNullOrWhiteSpace(Name); }
        }

        /// <summary>
        /// Gets whether a description was specified for the event.
        /// </summary>
        public bool HasDescription {
            get { return !String.IsNullOrWhiteSpace(Description); }
        }

        /// <summary>
        /// Gets whether an start time was specified for the event.
        /// </summary>
        public bool HasStartTime {
            get { return StartTime != null; }
        }

        /// <summary>
        /// Gets whether an end time was specified for the event.
        /// </summary>
        public bool HasEndTime {
            get { return EndTime != null; }
        }

        /// <summary>
        /// Gets whether a time zone was specified for the event.
        /// </summary>
        public bool HasTimeZone {
            get { return !String.IsNullOrWhiteSpace(TimeZone); }
        }

        /// <summary>
        /// Gets whether a type was specified for the event.
        /// </summary>
        public bool HasType {
            get { return !String.IsNullOrWhiteSpace(Type); }
        }

        #endregion

        #region Constructors

        protected FacebookEvent(JsonObject obj) : base(obj) {
            Id = obj.GetString("id");
            Cover = obj.GetObject("cover", FacebookCoverPhoto.Parse);
            Name = obj.GetString("name");
            Description = obj.GetString("description");
            StartTime = obj.GetString("start_time", SocialDateTime.Parse);
            EndTime = obj.GetString("end_time", SocialDateTime.Parse);
            Owner = obj.GetObject("owner", FacebookEventOwner.Parse);
            Privacy = obj.GetString("privacy");
            TimeZone = obj.GetString("timezone");
            Type = obj.GetString("type");
            UpdatedTime = obj.GetString("updated_time", SocialDateTime.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>FacebookEvent</code> from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>FacebookEvent</code>, or <code>null</code> if <code>obj</code> is
        /// <code>null</code>.</returns>
        public static FacebookEvent Parse(JsonObject obj) {
            return obj == null ? null : new FacebookEvent(obj);
        }

        #endregion

    }

}