using Skybrud.Social.Facebook.Fields;

namespace Skybrud.Social.Facebook.Constants {

    /// <summary>
    /// Static class with constants for the fields available for a Facebook event. The class is auto-generated and based
    /// on the fields listed in the Facebook Graph API documentation. Not all fields may have been mapped for the
    /// implementation in Skybrud.Social.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.5/event</cref>
    /// </see>
    public static class FacebookEventFields {

        /// <summary>
        /// The event ID.
        /// </summary>
        public static readonly FacebookField Id = new FacebookField("id");

        /// <summary>
        /// The category of the event.
        /// </summary>
        public static readonly FacebookField Category = new FacebookField("category");

        /// <summary>
        /// Cover picture.
        /// </summary>
        public static readonly FacebookField Cover = new FacebookField("cover");

        /// <summary>
        /// Long-form description.
        /// </summary>
        public static readonly FacebookField Description = new FacebookField("description");

        /// <summary>
        /// The type of the event.
        /// </summary>
        public static readonly FacebookField Type = new FacebookField("type");

        /// <summary>
        /// End time, if one has been set.
        /// </summary>
        public static readonly FacebookField EndTime = new FacebookField("end_time");

        /// <summary>
        /// Whether the viewer is admin or not.
        /// </summary>
        public static readonly FacebookField IsViewerAdmin = new FacebookField("is_viewer_admin");

        /// <summary>
        /// Whether the event is created by page or not.
        /// </summary>
        public static readonly FacebookField IsPageOwned = new FacebookField("is_page_owned");

        /// <summary>
        /// Can guests invite friends.
        /// </summary>
        public static readonly FacebookField CanGuestsInvite = new FacebookField("can_guests_invite");

        /// <summary>
        /// Can see guest list.
        /// </summary>
        public static readonly FacebookField GuestListEnabled = new FacebookField("guest_list_enabled");

        /// <summary>
        /// Event name.
        /// </summary>
        public static readonly FacebookField Name = new FacebookField("name");

        /// <summary>
        /// The profile that created the event.
        /// </summary>
        public static readonly FacebookField Owner = new FacebookField("owner");

        /// <summary>
        /// The group the event belongs to.
        /// </summary>
        public static readonly FacebookField ParentGroup = new FacebookField("parent_group");

        /// <summary>
        /// Event Place information.
        /// </summary>
        public static readonly FacebookField Place = new FacebookField("place");

        /// <summary>
        /// Start time.
        /// </summary>
        public static readonly FacebookField StartTime = new FacebookField("start_time");

        /// <summary>
        /// The link users can visit to buy a ticket to this event.
        /// </summary>
        public static readonly FacebookField TicketUri = new FacebookField("ticket_uri");

        /// <summary>
        /// Timezone.
        /// </summary>
        public static readonly FacebookField Timezone = new FacebookField("timezone");

        /// <summary>
        /// Last update time.
        /// </summary>
        public static readonly FacebookField UpdatedTime = new FacebookField("updated_time");

        /// <summary>
        /// Number of people attending the event.
        /// </summary>
        public static readonly FacebookField AttendingCount = new FacebookField("attending_count");

        /// <summary>
        /// Number of people who declined the event.
        /// </summary>
        public static readonly FacebookField DeclinedCount = new FacebookField("declined_count");

        /// <summary>
        /// Number of people who maybe going to the event.
        /// </summary>
        public static readonly FacebookField MaybeCount = new FacebookField("maybe_count");

        /// <summary>
        /// Number of people who did not reply to the event.
        /// </summary>
        public static readonly FacebookField NoreplyCount = new FacebookField("noreply_count");

    }

}