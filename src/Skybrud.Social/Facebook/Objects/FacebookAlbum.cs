using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookAlbum : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the album.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets whether the authenticated user or page can upload photos to this album.
        /// </summary>
        public bool CanUpload { get; private set; }

        /// <summary>
        /// Gets the number of photos in this album.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the ID of the album's cover photo.
        /// </summary>
        public string CoverPhoto { get; private set; }

        /// <summary>
        /// Gets the time the album was initially created.
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// Gets the description of the album.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the profile that created the album.
        /// </summary>
        public FacebookFrom From { get; private set; }

        /// <summary>
        /// Gets the link to this album on Facebook.
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// Gets the textual location of the album.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// Gets the title of the album.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the place of the album.
        /// </summary>
        public FacebookPlace Place { get; private set; }

        /// <summary>
        /// Gets the privacy settings for the album.
        /// </summary>
        public string Privacy { get; private set; }

        /// <summary>
        /// Gets the type of the album.
        /// </summary>
        public FacebookAlbumType Type { get; private set; }

        /// <summary>
        /// Gets the last time the album was updated.
        /// </summary>
        public string UpdatedTime { get; private set; }

        #endregion

        #region Constructors

        private FacebookAlbum(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an album from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static FacebookAlbum Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookAlbum(obj) {
                Id = obj.GetString("id"),
                CanUpload = obj.GetBoolean("can_upload"),
                Count = obj.GetInt32("count"),
                CoverPhoto = obj.GetString("cover_photo"),
                CreatedTime = obj.GetDateTime("created_time"),
                Description = obj.GetString("description"),
                From = obj.GetObject("from", FacebookFrom.Parse),
                Link = obj.GetString("link"),
                Location = obj.GetString("location"),
                Name = obj.GetString("name"),
                Place = obj.GetObject("place", FacebookPlace.Parse),
                Privacy = obj.GetString("privacy"),
                Type = obj.GetEnum<FacebookAlbumType>("type"),
                UpdatedTime = obj.GetString("updated_time")
            };
        }

        #endregion

    }

}