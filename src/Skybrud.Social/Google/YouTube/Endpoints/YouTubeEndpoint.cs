using Skybrud.Social.Google.YouTube.Endpoints.Raw;

namespace Skybrud.Social.Google.YouTube.Endpoints {

    public class YouTubeEndpoint {

        #region Private fields

        private YouTubeChannelsEndpoint _channels;
        private YouTubePlaylistsEndpoint _playlists;
        private YouTubePlaylistItemsEndpoint _playlistItems;
        private YouTubeVideosEndpoint _videos;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the parent service of this endpoint.
        /// </summary>
        public GoogleService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw YouTube endpoint.
        /// </summary>
        public YouTubeRawEndpoint Raw {
            get { return Service.Client.YouTube; }
        }

        /// <summary>
        /// Gets a reference to the channels endpoint.
        /// </summary>
        public YouTubeChannelsEndpoint Channels {
            get { return _channels ?? (_channels = new YouTubeChannelsEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the playlists endpoint.
        /// </summary>
        public YouTubePlaylistsEndpoint Playlists {
            get { return _playlists ?? (_playlists = new YouTubePlaylistsEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the playlists items endpoint.
        /// </summary>
        public YouTubePlaylistItemsEndpoint PlaylistItems {
            get { return _playlistItems ?? (_playlistItems = new YouTubePlaylistItemsEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the videos endpoint.
        /// </summary>
        public YouTubeVideosEndpoint Videos {
            get { return _videos ?? (_videos = new YouTubeVideosEndpoint(this)); }
        }

        #endregion

        #region Constructors

        internal YouTubeEndpoint(GoogleService service) {
            Service = service;
        }

        #endregion

    }

}