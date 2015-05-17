using System;
using Skybrud.Social.Facebook.Objects.Comments;
using Skybrud.Social.Facebook.Objects.Likes;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Posts {

    public class FacebookPost : SocialJsonObject, ISocialTimelineEntry {

        #region Properties

        public string Id { get; private set; }
        public FacebookObject From { get; private set; }
        public FacebookObject Application { get; private set; }
        public FacebookPostProperties[] Properties { get; private set; }
        public string Message { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public string Story { get; private set; }
        public string Picture { get; private set; }
        public string Link { get; private set; }
        public string Source { get; private set; }
        public string Name { get; private set; }
        public string Icon { get; private set; }
        public string Type { get; private set; }
        public string StatusType { get; private set; }
        public string ObjectId { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public DateTime UpdatedTime { get; private set; }
        
        /// <summary>
        /// Gets information about how many times the post has been shared. If the post hasn't yet
        /// been shared, this property will return <code>NULL</code>.
        /// </summary>
        public FacebookShares Shares { get; private set; }
        
        public FacebookLikes Likes { get; private set; }
        public FacebookComments Comments { get; private set; }

        public DateTime SortDate {
            get { return CreatedTime; }
        }

        #endregion

        #region Constructors

        private FacebookPost(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a post from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookPost Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPost(obj) {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookObject.Parse),
                Application = obj.GetObject("application", FacebookObject.Parse),
                Properties = obj.GetArray("properties", FacebookPostProperties.Parse) ?? new FacebookPostProperties[0],
                Caption = obj.GetString("caption"),
                Message = obj.GetString("message"),
                Description = obj.GetString("description"),
                Story = obj.GetString("story"),
                Picture = obj.GetString("picture"),
                Link = obj.GetString("link"),
                Source = obj.GetString("source"),
                Name = obj.GetString("name"),
                Icon = obj.GetString("icon"),
                Type = obj.GetString("type"),
                StatusType = obj.GetString("status_type"),
                ObjectId = obj.GetString("object_id"),
                CreatedTime = obj.GetDateTime("created_time"),
                UpdatedTime = obj.GetDateTime("updated_time"),
                Shares = obj.GetObject("shares", FacebookShares.Parse),
                Likes = obj.GetObject("likes", FacebookLikes.Parse),
                Comments = obj.GetObject("comments", FacebookComments.Parse)
            };
        }

        #endregion

    }

}