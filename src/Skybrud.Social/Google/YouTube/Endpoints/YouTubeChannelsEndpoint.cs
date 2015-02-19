using Skybrud.Social.Google.YouTube.Endpoints.Raw;
using Skybrud.Social.Google.YouTube.Options;
using Skybrud.Social.Google.YouTube.Responses;

namespace Skybrud.Social.Google.YouTube.Endpoints {
    
    public class YouTubeChannelsEndpoint {

        #region Properties

        /// <summary>
        /// Gets the parent endpoint of this endpoint.
        /// </summary>
        public YouTubeEndpoint YouTube { get; private set; }

        public YouTubeChannelsRawEndpoint Raw {
            get { return YouTube.Service.Client.YouTube.Channels; }
        }

        #endregion

        #region Constructors

        internal YouTubeChannelsEndpoint(YouTubeEndpoint youTube) {
            YouTube = youTube;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of channels for the authenticated user.
        /// </summary>
        public YouTubeChannelsResponse GetChannels() {
            return YouTubeChannelsResponse.ParseResponse(Raw.GetChannels());
        }

        /// <summary>
        /// Gets a list of channels for the specified <code>username</code>.
        /// </summary>
        public YouTubeChannelsResponse GetChannels(string username) {
            return YouTubeChannelsResponse.ParseResponse(Raw.GetChannels(username));
        }

        /// <summary>
        /// Gets a list of channels for the authenticated user.
        /// </summary>
        public YouTubeChannelsResponse GetChannels(YouTubeChannelsOptions options) {
            return YouTubeChannelsResponse.ParseResponse(Raw.GetChannels(options));
        }

        #endregion

    }

}