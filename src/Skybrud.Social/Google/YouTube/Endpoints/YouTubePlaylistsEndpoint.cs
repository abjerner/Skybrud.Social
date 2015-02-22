using System;
using Skybrud.Social.Google.YouTube.Endpoints.Raw;
using Skybrud.Social.Google.YouTube.Options;
using Skybrud.Social.Google.YouTube.Responses;

namespace Skybrud.Social.Google.YouTube.Endpoints {
    
    public class YouTubePlaylistsEndpoint {

        #region Properties

        /// <summary>
        /// Gets the parent endpoint of this endpoint.
        /// </summary>
        public YouTubeEndpoint YouTube { get; private set; }

        public YouTubePlaylistsRawEndpoint Raw {
            get { return YouTube.Service.Client.YouTube.Playlists; }
        }

        #endregion

        #region Constructors

        internal YouTubePlaylistsEndpoint(YouTubeEndpoint youTube) {
            YouTube = youTube;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of playlists for the authenticated user.
        /// </summary>
        public YouTubePlaylistListResponse GetPlaylists() {
            return YouTubePlaylistListResponse.ParseResponse(Raw.GetPlaylists());
        }

        /// <summary>
        /// Gets a list of playlists for the specified <code>channelId</code>.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        public YouTubePlaylistListResponse GetPlaylists(string channelId) {
            return YouTubePlaylistListResponse.ParseResponse(Raw.GetPlaylists(channelId));
        }

        /// <summary>
        /// Gets a list of playlists based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public YouTubePlaylistListResponse GetPlaylists(YouTubePlaylistListOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return YouTubePlaylistListResponse.ParseResponse(Raw.GetPlaylists(options));
        }

        #endregion

    }

}