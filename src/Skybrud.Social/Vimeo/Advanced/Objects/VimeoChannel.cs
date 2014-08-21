using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoChannel : SocialJsonObject {
        
        public int Id { get; private set; }
        public bool IsFeatured { get; private set; }
        public bool IsSponsored { get; private set; }
        public bool IsSubscribed { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }
        public int TotalVideos { get; private set; }
        public int TotalSubscribers { get; private set; }
        public string LogoUrl { get; private set; }
        public string BadgeUrl { get; private set; }
        public string ThumbnailUrl { get; private set; }
        public string Url { get; private set; }
        public string Layout { get; private set; }
        public string Theme { get; private set; }
        public string Privacy { get; private set; }

        #region Constructor

        internal VimeoChannel() {
            // Hide default constructor
        }

        #endregion

        public static VimeoChannel[] Parse(JsonArray array) {
            return array == null ? new VimeoChannel[0] : array.ParseMultiple(Parse);
        }

        public static VimeoChannel Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoChannel {
                JsonObject = obj,
                Id = obj.GetInt("id"),
                IsFeatured = obj.GetString("is_featured") == "1",
                IsSponsored = obj.GetString("is_sponsored") == "1",
                IsSubscribed = obj.GetString("is_subscribed") == "1",
                Name = obj.GetString("name"),
                Description = obj.GetString("description"),
                CreatedOn = obj.GetDateTime("created_on"),
                ModifiedOn = obj.GetDateTime("modified_on"),
                TotalVideos = obj.GetInt("total_videos"),
                TotalSubscribers = obj.GetInt("total_subscribers"),
                LogoUrl = obj.GetString("logo_url"),
                BadgeUrl = obj.GetString("badge_url"),
                ThumbnailUrl = obj.GetString("thumbnail_url"),
                Url = obj.GetArray("url").GetString(0),
                Layout = obj.GetString("layout"),
                Theme = obj.GetString("theme"),
                Privacy = obj.GetString("privacy")
            };
        }

    }

}
