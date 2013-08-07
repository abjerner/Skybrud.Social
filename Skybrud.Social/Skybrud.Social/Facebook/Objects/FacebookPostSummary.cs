using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookPostSummary : ISocialTimelineEntry {

        public string Id { get; private set; }
        public FacebookIdName From { get; private set; }
        public FacebookIdName Application { get; private set; }
        public FacebookPostProperties[] Properties { get; private set; }
        public string Message { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public string Story { get; private set; }
        public string Picture { get; private set; }
        public string Link { get; private set; }
        public string Name { get; private set; }
        public string Icon { get; private set; }
        public string Type { get; private set; }
        public string StatusType { get; private set; }
        public long? ObjectId { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public DateTime UpdatedTime { get; private set; }
        public FacebookLikes Likes { get; private set; }
        public FacebookComments Comments { get; private set; }

        public static FacebookPostSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPostSummary {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookIdName.Parse),
                Application = obj.GetObject("application", FacebookIdName.Parse),
                Properties = obj.GetArray("properties", FacebookPostProperties.Parse) ?? new FacebookPostProperties[0],
                Caption = obj.GetString("caption"),
                Message = obj.GetString("message"),
                Description = obj.GetString("description"),
                Story = obj.GetString("story"),
                Picture = obj.GetString("picture"),
                Link = obj.GetString("link"),
                Name = obj.GetString("name"),
                Icon = obj.GetString("icon"),
                Type = obj.GetString("type"),
                StatusType = obj.GetString("status_type"),
                ObjectId = obj.HasValue("object_id") ? (long?) obj.GetLong("object_id") : null,
                CreatedTime = obj.GetDateTime("created_time"),
                UpdatedTime = obj.GetDateTime("updated_time"),
                Likes = obj.GetObject("likes", FacebookLikes.Parse),
                Comments = obj.GetObject("comments", FacebookComments.Parse)
            };
        }

        public static FacebookPostSummary[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookPostSummary[0] : array.ParseMultiple(Parse);
        }

        public DateTime SortDate {
            get { return CreatedTime; }
        }
    
    }

}
