using System;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    public class YouTubeVideosRawEndpoint {

        #region Properties

        public GoogleOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public YouTubeVideosRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of videos based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetVideos(YouTubeVideoListOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://www.googleapis.com/youtube/v3/videos", options);
        }

        #endregion

    }

}