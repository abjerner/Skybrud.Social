using System;
using System.Linq;
using System.Xml.Linq;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Simple.Objects {

    public class VimeoChannel : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Channel ID.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Channel name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Channel description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Channel logo (header).
        /// </summary>
        public string Logo { get; private set; }

        /// <summary>
        /// Not described in the API documentation.
        /// </summary>
        public string Badge { get; private set; }

        /// <summary>
        /// URL for the channel page.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// RSS feed for the channel’s videos.
        /// </summary>
        public string Rss { get; private set; }

        /// <summary>
        /// Date the channel was created.
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// User ID of the channel creator.
        /// </summary>
        public int CreatorId { get; private set; }

        /// <summary>
        /// Name of the User who created the channel.
        /// </summary>
        public string CreatorDisplayName { get; private set; }

        /// <summary>
        /// The URL to the channel creator’s profile.
        /// </summary>
        public string CreatorUrl { get; private set; }
        
        /// <summary>
        /// Not described in the API documentation.
        /// </summary>
        public bool IsCreator { get; private set; }
        
        /// <summary>
        /// Not described in the API documentation.
        /// </summary>
        public bool IsMod { get; private set; }

        /// <summary>
        /// Total # of videos posted in the channel.
        /// </summary>
        public int TotalVideos { get; private set; }

        /// <summary>
        /// Total # of users subscribed.
        /// </summary>
        public int TotalSubscribers { get; private set; }

        public XElement XElement { get; private set; }

        #endregion
        
        #region Constructor(s)

        private VimeoChannel(JsonObject obj) : base(obj) { }

        private VimeoChannel(XElement xChannel) : base(null) {
            XElement = xChannel;
        }

        #endregion

        public static VimeoChannel Parse(XElement xChannel) {
            if (xChannel == null || xChannel.Name != "channel") return null;
            VimeoChannel channel = new VimeoChannel(xChannel) {
                Id = SocialUtils.GetElementValue<int>(xChannel, "id"),
                Name = SocialUtils.GetElementValue<string>(xChannel, "name"),
                Description = SocialUtils.GetElementValue<string>(xChannel, "description"),
                Logo = SocialUtils.GetElementValue<string>(xChannel, "logo"),
                Badge = SocialUtils.GetElementValue<string>(xChannel, "badge"),
                Url = SocialUtils.GetElementValue<string>(xChannel, "url"),
                Rss = SocialUtils.GetElementValue<string>(xChannel, "rss"),
                CreatedOn = SocialUtils.GetElementValue<DateTime>(xChannel, "created_on"),
                CreatorId = SocialUtils.GetElementValue<int>(xChannel, "creator_id"),
                CreatorDisplayName = SocialUtils.GetElementValue<string>(xChannel, "creator_display_name"),
                CreatorUrl = SocialUtils.GetElementValue<string>(xChannel, "creator_url"),
                IsCreator = SocialUtils.GetElementValueOrDefault<string>(xChannel, "is_creator") == "yes",
                IsMod = SocialUtils.GetElementValueOrDefault<string>(xChannel, "is_mod") == "yes",
                TotalVideos = SocialUtils.GetElementValue<int>(xChannel, "total_videos"),
                TotalSubscribers = SocialUtils.GetElementValue<int>(xChannel, "total_subscribers")
            };
            if (channel.Badge == "") channel.Badge = null;
            return channel;
        }

        public static VimeoChannel Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoChannel(obj) {
                Id = obj.GetInt32("id"),
                Name = obj.GetString("name"),
                Description = obj.GetString("description"),
                Logo = obj.GetString("logo"),
                Badge = obj.GetString("badge"),
                Url = obj.GetString("url"),
                Rss = obj.GetString("rss"),
                CreatedOn = obj.GetDateTime("created_on"),
                CreatorId = obj.GetInt32("creator_id"),
                CreatorDisplayName = obj.GetString("creator_display_name"),
                CreatorUrl = obj.GetString("creator_url"),
                IsCreator = obj.GetString("is_creator") == "yes",
                IsMod = obj.GetString("is_mod") == "yes",
                TotalVideos = obj.GetInt32("total_videos"),
                TotalSubscribers = obj.GetInt32("total_subscribers"),
            };
        }

        public static VimeoChannel[] ParseMultiple(XElement xVideos) {
            if (xVideos == null || xVideos.Name != "channels") return null;
            return (from x in xVideos.Elements("channel") select Parse(x)).ToArray();
        }

    }

}
