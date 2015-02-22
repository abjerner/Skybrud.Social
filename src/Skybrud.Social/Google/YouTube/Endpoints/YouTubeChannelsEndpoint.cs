using System;
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
        public YouTubeChannelListResponse GetChannels() {
            return YouTubeChannelListResponse.ParseResponse(Raw.GetChannels());
        }

        /// <summary>
        /// Gets a list of channels for the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username.</param>
        public YouTubeChannelListResponse GetChannels(string username) {
            return YouTubeChannelListResponse.ParseResponse(Raw.GetChannels(username));
        }

        /// <summary>
        /// Gets a list of channels based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public YouTubeChannelListResponse GetChannels(YouTubeChannelListOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return YouTubeChannelListResponse.ParseResponse(Raw.GetChannels(options));
        }

        #endregion

    }

}