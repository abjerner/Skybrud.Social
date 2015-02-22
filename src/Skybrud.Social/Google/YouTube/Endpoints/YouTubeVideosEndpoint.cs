using Skybrud.Social.Google.YouTube.Endpoints.Raw;
using Skybrud.Social.Google.YouTube.Options;
using Skybrud.Social.Google.YouTube.Responses;

namespace Skybrud.Social.Google.YouTube.Endpoints {
    
    public class YouTubeVideosEndpoint {

        #region Properties

        /// <summary>
        /// Gets the parent endpoint of this endpoint.
        /// </summary>
        public YouTubeEndpoint YouTube { get; private set; }

        public YouTubeVideosRawEndpoint Raw {
            get { return YouTube.Service.Client.YouTube.Videos; }
        }

        #endregion

        #region Constructors

        internal YouTubeVideosEndpoint(YouTubeEndpoint youTube) {
            YouTube = youTube;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of videos based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public YouTubeVideoListResponse GetVideos(YouTubeVideoListOptions options) {
            return YouTubeVideoListResponse.ParseResponse(Raw.GetVideos(options));
        }

        #endregion

    }

}