using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#status</cref>
    /// </see>    
    public class YouTubePlaylistItemStatus : GoogleApiObject {

        #region Properties

        public YouTubePrivacyStatus PrivacyStatus { get; private set; }

        #endregion

        #region Constructor

        protected YouTubePlaylistItemStatus(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubePlaylistItemStatus</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubePlaylistItemStatus Parse(JsonObject obj) {
            
            if (obj == null) return null;

            // Parse the privacy status
            YouTubePrivacyStatus status;
            string strStatus = obj.GetString("privacyStatus");
            if (!Enum.TryParse(strStatus, true, out status)) {
                throw new Exception("Unknown privacy status \"" + strStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social/issues/new");
            }

            return new YouTubePlaylistItemStatus(obj) {
                PrivacyStatus = status
            };
        
        }

        #endregion

    }

}