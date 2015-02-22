using System;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Objects.PlaylistItems;
using Skybrud.Social.Google.YouTube.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    public class YouTubePlaylistItemsRawEndpoint {

        #region Properties

        public GoogleOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public YouTubePlaylistItemsRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of playlist items for the specified <code>playlistId</code>.
        /// </summary>
        /// <param name="playlistId">The ID of the playlist.</param>
        public SocialHttpResponse GetPlaylistItems(string playlistId) {
            return GetPlaylistItems(new YouTubePlaylistItemListOptions {
                Part = YouTubePlaylistItemPart.Basic,
                PlaylistId = playlistId
            });
        }

        /// <summary>
        /// Gets a list of playlist items based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPlaylistItems(YouTubePlaylistItemListOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://www.googleapis.com/youtube/v3/playlistItems", options);

        }

        #endregion

    }

}