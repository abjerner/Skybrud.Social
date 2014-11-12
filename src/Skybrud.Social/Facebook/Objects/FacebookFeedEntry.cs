using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookFeedEntry: SocialJsonObject, ISocialTimelineEntry {

        #region Properties

        public string Id { get; private set; }
        public FacebookObject From { get; private set; }
        public string Message { get; private set; }
        public string Description { get; private set; }
        public string Story { get; private set; }
        public string Picture { get; private set; }
        public string Link { get; private set; }
        public string Name { get; private set; }
        public string Caption { get; private set; }
        public string Icon { get; private set; }
        public string Type { get; private set; }
        public string StatusType { get; private set; }
        public FacebookObject Application { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public DateTime UpdatedTime { get; private set; }

        /// <summary>
        /// Gets information about how many times the feed entry has been shared. If the feed entry
        /// hasn't yet been shared, this property will return <code>NULL</code>.
        /// </summary>
        public FacebookShares Shares { get; private set; }

        public FacebookLikes Likes { get; private set; }
        public FacebookComments Comments { get; private set; }
        public long? ObjectId { get; private set; }

        public DateTime SortDate {
            get { return CreatedTime; }
        }

        #endregion
        
        #region Constructors

        private FacebookFeedEntry(JsonObject obj) : base(obj) { }

        #endregion

        public static FacebookFeedEntry Parse(JsonObject obj) {
            return new FacebookFeedEntry(obj) {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookObject.Parse),
                Message = obj.GetString("message"),
                Description = obj.GetString("description"),
                Story = obj.GetString("story"),
                Picture = obj.GetString("picture"),
                Link = obj.GetString("link"),
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
            };
        }
    
    }

}
