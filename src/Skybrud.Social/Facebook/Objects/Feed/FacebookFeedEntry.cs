using System;
using Skybrud.Social.Facebook.Objects.Comments;
using Skybrud.Social.Facebook.Objects.Likes;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Feed {

    /// <summary>
    /// Class representing an entry in the feed of a user or page.
    /// </summary>
    public class FacebookFeedEntry: SocialJsonObject, ISocialTimelineEntry {

        #region Properties

        /// <summary>
        /// Gets the ID of the entry.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets information about the user or page that posted the entry.
        /// </summary>
        public FacebookObject From { get; private set; }

        /// <summary>
        /// Gets the message of the entry.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the description of the entry.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the story of the entry.
        /// </summary>
        public string Story { get; private set; }

        /// <summary>
        /// Gets the URL of the picture of the entry. Depending on the entry, a picture may not be present.
        /// </summary>
        public string Picture { get; private set; }

        /// <summary>
        /// Gets the URL of the object behind the entry.
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// If the entry represents a video, this property will return the source URL of the video.
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// Gets the name of the entry.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Gets the caption of the entry.
        /// </summary>
        public string Caption { get; private set; }

        /// <summary>
        /// Gets the icon of the entry.
        /// </summary>
        public string Icon { get; private set; }
        
        /// <summary>
        /// Gets the type of the entry.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the status type of the entry.
        /// </summary>
        public string StatusType { get; private set; }
        
        /// <summary>
        /// Gets information about the application used for posting the entry.
        /// </summary>
        public FacebookObject Application { get; private set; }

        /// <summary>
        /// Gets the creation date of the entry.
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// Gets a timestamp for when the entry was last updated.
        /// </summary>
        public DateTime UpdatedTime { get; private set; }

        /// <summary>
        /// Gets information about how many times the feed entry has been shared. If the feed entry
        /// hasn't yet been shared, this property will return <code>NULL</code>.
        /// </summary>
        public FacebookShares Shares { get; private set; }

        /// <summary>
        /// Gets an object with information about how the entry has been liked.
        /// </summary>
        public FacebookLikes Likes { get; private set; }
        
        /// <summary>
        /// Gets an object with information about how the entry has been commented.
        /// </summary>
        public FacebookComments Comments { get; private set; }

        /// <summary>
        /// If the entry represents an object (eg. a photo or similar), this property will return the ID of that object.
        /// </summary>
        public string ObjectId { get; private set; }

        public DateTime SortDate {
            get { return CreatedTime; }
        }

        #endregion
        
        #region Constructors

        private FacebookFeedEntry(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>JsonObject</code> into an instance of <code>FacebookFeedEntry</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        public static FacebookFeedEntry Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookFeedEntry(obj) {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookObject.Parse),
                Message = obj.GetString("message"),
                Description = obj.GetString("description"),
                Story = obj.GetString("story"),
                Picture = obj.GetString("picture"),
                Link = obj.GetString("link"),
                Source = obj.GetString("source"),
                Name = obj.GetString("name"),
                Caption = obj.GetString("caption"),
                Icon = obj.GetString("icon"),
                Type = obj.GetString("type"),
                StatusType = obj.GetString("status_type"),
                Application = obj.GetObject("application", FacebookObject.Parse),
                CreatedTime = obj.GetDateTime("created_time"),
                UpdatedTime = obj.GetDateTime("updated_time"),
                Comments = obj.GetObject("comments", FacebookComments.Parse),
                Shares = obj.GetObject("shares", FacebookShares.Parse),
                Likes = obj.GetObject("likes", FacebookLikes.Parse),
                ObjectId = obj.GetString("object_id")
            };
        }

        #endregion

    }

}