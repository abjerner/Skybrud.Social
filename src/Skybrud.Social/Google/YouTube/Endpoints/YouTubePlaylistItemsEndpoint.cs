using Skybrud.Social.Google.YouTube.Endpoints.Raw;
using Skybrud.Social.Google.YouTube.Options;
using Skybrud.Social.Google.YouTube.Responses;

namespace Skybrud.Social.Google.YouTube.Endpoints {
    
    public class YouTubePlaylistItemsEndpoint {

        #region Properties

        /// <summary>
        /// Gets the parent endpoint of this endpoint.
        /// </summary>
        public YouTubeEndpoint YouTube { get; private set; }

        public YouTubePlaylistItemsRawEndpoint Raw {
            get { return YouTube.Service.Client.YouTube.PlaylistItems; }
        }

        #endregion

        #region Constructors

        internal YouTubePlaylistItemsEndpoint(YouTubeEndpoint youTube) {
            YouTube = youTube;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of playlist items for the specified <code>playlistId</code>.
        /// </summary>
        /// <param name="playlistId">The ID of the playlist.</param>
        public YouTubePlaylistItemListResponse GetPlaylistItems(string playlistId) {
            return YouTubePlaylistItemListResponse.ParseResponse(Raw.GetPlaylistItems(playlistId));
        }

        /// <summary>
        /// Gets a list of playlist items based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public YouTubePlaylistItemListResponse GetPlaylistItems(YouTubePlaylistItemListOptions options) {
            return YouTubePlaylistItemListResponse.ParseResponse(Raw.GetPlaylistItems(options));
        }

        #endregion

    }

}