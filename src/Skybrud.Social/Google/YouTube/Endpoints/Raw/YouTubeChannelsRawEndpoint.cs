using System;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Objects.Channels;
using Skybrud.Social.Google.YouTube.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    public class YouTubeChannelsRawEndpoint {

        #region Properties

        public GoogleOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public YouTubeChannelsRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of channels for the authenticated user.
        /// </summary>
        public SocialHttpResponse GetChannels() {
            return GetChannels(new YouTubeChannelsOptions {
                Part = YouTubeChannelPart.Basic,
                Mine = true
            });
        }

        /// <summary>
        /// Gets a list of channels for the specified <code>username</code>.
        /// </summary>
        public SocialHttpResponse GetChannels(string username) {
            return GetChannels(new YouTubeChannelsOptions {
                Part = YouTubeChannelPart.Basic,
                Username = username
            });
        }

        /// <summary>
        /// Gets a list of channels for the authenticated user.
        /// </summary>
        public SocialHttpResponse GetChannels(YouTubeChannelsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://www.googleapis.com/youtube/v3/channels", options);

        }

        #endregion

    }

}