using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {
    
    public class YouTubeRawEndpoint {

        #region Properties

        public GoogleOAuthClient Client { get; private set; }

        public YouTubeChannelsRawEndpoint Channels { get; private set; }

        public YouTubePlaylistsRawEndpoint Playlists { get; private set; }

        public YouTubePlaylistItemsRawEndpoint PlaylistItems { get; private set; }

        public YouTubeVideosRawEndpoint Videos { get; private set; }

        #endregion

        #region Constructors

        public YouTubeRawEndpoint(GoogleOAuthClient client) {
            Client = client;
            Channels = new YouTubeChannelsRawEndpoint(client);
            Playlists = new YouTubePlaylistsRawEndpoint(client);
            PlaylistItems = new YouTubePlaylistItemsRawEndpoint(client);
            Videos = new YouTubeVideosRawEndpoint(client);
        }

        #endregion

    }

}