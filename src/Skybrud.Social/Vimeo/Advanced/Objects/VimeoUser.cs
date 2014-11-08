using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoUser : SocialJsonObject {

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string DisplayName { get; private set; }
        public string Location { get; private set; }
        public string Bio { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string ProfileUrl { get; private set; }
        public string VideosUrl { get; private set; }
        public int NumberOfContacts { get; private set; }
        public int NumberOfUploads { get; private set; }
        public int NumberOfLikes { get; private set; }
        public int NumberOfVideos { get; private set; }
        public int NumberOfVideosAppearIn { get; private set; }
        public int NumberOfAlbums { get; private set; }
        public int NumberOfChannels { get; private set; }
        public int NumberOfGroups { get; private set; }
        
        #region Constructors

        private VimeoUser(JsonObject obj) : base(obj) { }

        #endregion

        public static VimeoUser Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoUser(obj) {
                Id = obj.GetInt32("id"),
                Username = obj.GetString("username"),
                DisplayName = obj.GetString("display_name"),
                Location = obj.GetString("location"),
                Bio = obj.GetString("bio"),
                CreatedOn = obj.GetDateTime("created_on"),
                ProfileUrl = obj.GetString("profileurl"),
                VideosUrl = obj.GetString("videosurl"),
                NumberOfContacts = obj.GetInt32("number_of_contacts"),
                NumberOfUploads = obj.GetInt32("number_of_uploads"),
                NumberOfLikes = obj.GetInt32("number_of_likes"),
                NumberOfVideos = obj.GetInt32("number_of_videos"),
                NumberOfVideosAppearIn = obj.GetInt32("number_of_videos_appear_in"),
                NumberOfAlbums = obj.GetInt32("number_of_albums"),
                NumberOfChannels = obj.GetInt32("number_of_channels"),
                NumberOfGroups = obj.GetInt32("number_of_groups")
            };
        }

    }

}