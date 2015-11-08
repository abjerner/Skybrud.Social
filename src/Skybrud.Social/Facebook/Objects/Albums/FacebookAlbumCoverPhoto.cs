using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Albums {

    /// <summary>
    /// Class representing the cover photo of an album.
    /// </summary>
    public class FacebookAlbumCoverPhoto : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the cover photo.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets a timestamp representing the creation time of the cover photo.
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// Gets the name of the cover photo, or <code>null</code> if not specified.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets whether the album has a name.
        /// </summary>
        public bool HasName {
            get { return !String.IsNullOrWhiteSpace(Name); }
        }

        #endregion

        #region Constructors

        private FacebookAlbumCoverPhoto(JsonObject obj) : base(obj) {
            Id = obj.GetString("id");
            CreatedTime = obj.GetDateTime("created_time");
            Name = obj.GetString("name");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>FacebookAlbumCoverPhoto</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        /// <returns>Returns an instance of <code>FacebookAlbumCoverPhoto</code>, or <code>null</code> if the specified
        /// <code>obj</code> is <code>null</code>.</returns>
        public static FacebookAlbumCoverPhoto Parse(JsonObject obj) {
            return obj == null ? null : new FacebookAlbumCoverPhoto(obj);
        }

        #endregion

    }

}