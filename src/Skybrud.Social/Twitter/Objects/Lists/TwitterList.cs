using System;
using Skybrud.Social.Facebook.Objects.Users;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Enums;

namespace Skybrud.Social.Twitter.Objects.Lists {

    /// <summary>
    /// Class representing a Twitter list.
    /// </summary>
    public class TwitterList : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the list.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Gets the slug of the list.
        /// </summary>
        public string Slug { get; private set; }

        /// <summary>
        /// Gets the slug of the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the timestam for when the list was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets the URI of the list.
        /// </summary>
        public string Uri { get; private set; }

        /// <summary>
        /// Gets the amount of subscribers to the list.
        /// </summary>
        public int SubscriberCount { get; private set; }

        /// <summary>
        /// Gets the amount of members of the list.
        /// </summary>
        public int MemberCount { get; private set; }

        /// <summary>
        /// Gets the mode (visibility) of the list.
        /// </summary>
        public TwitterListMode Mode { get; private set; }

        /// <summary>
        /// Gets the full name of the list.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets the description of the list.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets a referecne to the user owning the list.
        /// </summary>
        public FacebookUser User { get; private set; }

        /// <summary>
        /// Gets whether the authenticated user is following the list.
        /// </summary>
        public bool IsFollowing { get; private set; }

        #endregion

        #region Constructors

        private TwitterList(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterList</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static TwitterList Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterList(obj) {
                Id = obj.GetInt64("id"),
                Slug = obj.GetString("slug"),
                Name = obj.GetString("name"),
                CreatedAt = obj.GetString("created_at", TwitterUtils.ParseDateTime),
                Uri = obj.GetString("uri"),
                SubscriberCount = obj.GetInt32("subscriber_count"),
                MemberCount = obj.GetInt32("member_count"),
                Mode = obj.GetEnum<TwitterListMode>("mode"),
                FullName = obj.GetString("full_name"),
                Description = obj.GetString("description"),
                User = obj.GetObject("user", FacebookUser.Parse),
                IsFollowing = obj.GetBoolean("following")
            };
        }

        #endregion

    }

}