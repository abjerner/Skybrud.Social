using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookLikesEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookLikesRawEndpoint Raw {
            get { return Service.Client.Likes; }
        }

        internal FacebookLikesEndpoint(FacebookService service) {
            Service = service;
        }

        #region Methods

        /// <summary>
        /// Gets a list of all likes for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="limit">The maximum amount of likes to return.</param>
        public FacebookResponse<FacebookLikesCollection> GetLikes(string id, int? limit = null) {
            return GetLikes(id, new FacebookLikesOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of all likes for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/object/likes#read</cref>
        /// </see>
        public FacebookResponse<FacebookLikesCollection> GetLikes(string id, FacebookLikesOptions options) {
            return FacebookHelpers.ParseResponse(Raw.GetLikes(id, options), FacebookLikesCollection.Parse);
        }

        #endregion

    }

}
