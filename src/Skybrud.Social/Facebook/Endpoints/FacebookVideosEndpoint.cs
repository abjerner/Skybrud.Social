using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Videos;
using Skybrud.Social.Facebook.Responses.Videos;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class representing the implementation of the videos endpoint.
    /// </summary>
    public class FacebookVideosEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookVideosRawEndpoint Raw {
            get { return Service.Client.Videos; }
        }

        #endregion

        #region Constructors

        internal FacebookVideosEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the video with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the video.</param>
        public FacebookVideoResponse GetVideo(string id) {
            return FacebookVideoResponse.ParseResponse(Raw.GetVideo(id));
        }

        /// <summary>
        /// Gets information about the video matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookVideoResponse GetVideo(FacebookGetVideoOptions options) {
            return FacebookVideoResponse.ParseResponse(Raw.GetVideo(options));
        }

        #endregion

    }

}