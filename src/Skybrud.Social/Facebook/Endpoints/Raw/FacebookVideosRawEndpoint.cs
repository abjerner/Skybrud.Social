using System;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.Videos;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the videos endpoint.
    /// </summary>
    public class FacebookVideosRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference of the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookVideosRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the video with the specified <code>videoId</code>
        /// </summary>
        /// <param name="videoId">The ID of the video.</param>
        public SocialHttpResponse GetVideo(string videoId) {
            return Client.DoAuthenticatedGetRequest("/" + videoId);
        }

        /// <summary>
        /// Gets information about the video matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPost(FacebookGetVideoOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier, options);
        }

        #endregion

    }

}