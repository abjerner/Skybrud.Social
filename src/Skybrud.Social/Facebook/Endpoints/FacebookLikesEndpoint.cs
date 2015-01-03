using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Likes;
using Skybrud.Social.Facebook.Responses.Likes;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookLikesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookLikesRawEndpoint Raw {
            get { return Service.Client.Likes; }
        }

        #endregion

        #region Constructors

        internal FacebookLikesEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of likes of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        public FacebookLikesResponse GetLikes(string id) {
            return GetLikes(id, new FacebookLikesOptions());
        }

        /// <summary>
        /// Gets a list of likes of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="limit">The maximum amount of likes to return.</param>
        public FacebookLikesResponse GetLikes(string id, int limit) {
            return GetLikes(id, new FacebookLikesOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of likes of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/object/likes#read</cref>
        /// </see>
        public FacebookLikesResponse GetLikes(string id, FacebookLikesOptions options) {
            return FacebookLikesResponse.ParseResponse(Raw.GetLikes(id, options));
        }

        #endregion

    }

}