using System;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Objects.Playlists;
using Skybrud.Social.Google.YouTube.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    public class YouTubePlaylistsRawEndpoint {

        #region Properties

        public GoogleOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public YouTubePlaylistsRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of playlists for the authenticated user.
        /// </summary>
        public SocialHttpResponse GetPlaylists() {
            return GetPlaylists(new YouTubePlaylistListOptions {
                Part = YouTubePlaylistPart.Basic,
                Mine = true
            });
        }

        /// <summary>
        /// Gets a list of playlists for the specified <code>channelId</code>.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        public SocialHttpResponse GetPlaylists(string channelId) {
            return GetPlaylists(new YouTubePlaylistListOptions {
                Part = YouTubePlaylistPart.Basic,
                ChannelId = channelId
            });
        }

        /// <summary>
        /// Gets a list of playlists based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPlaylists(YouTubePlaylistListOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://www.googleapis.com/youtube/v3/playlists", options);

        }

        #endregion

    }

}