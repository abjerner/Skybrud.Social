using System;
using System.Linq;
using System.Xml.Linq;

namespace Skybrud.Social.Vimeo.Simple.Objects {

    public class VimeoChannel {

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

        public static VimeoChannel Parse(XElement xChannel) {
            if (xChannel == null || xChannel.Name != "channel") return null;
            VimeoChannel channel = new VimeoChannel {
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
                TotalSubscribers = SocialUtils.GetElementValue<int>(xChannel, "total_subscribers"),
                XElement = xChannel
            };
            if (channel.Badge == "") channel.Badge = null;
            return channel;
        }

        public static VimeoChannel[] ParseMultiple(XElement xVideos) {
            if (xVideos == null || xVideos.Name != "channels") return null;
            return (from x in xVideos.Elements("channel") select Parse(x)).ToArray();
        }

    }

}
