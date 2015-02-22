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
            return GetChannels(new YouTubeChannelListOptions {
                Part = YouTubeChannelPart.Basic,
                Mine = true
            });
        }

        /// <summary>
        /// Gets a list of channels for the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username.</param>
        public SocialHttpResponse GetChannels(string username) {
            return GetChannels(new YouTubeChannelListOptions {
                Part = YouTubeChannelPart.Basic,
                Username = username
            });
        }

        /// <summary>
        /// Gets a list of channels based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetChannels(YouTubeChannelListOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://www.googleapis.com/youtube/v3/channels", options);

        }

        #endregion

    }

}