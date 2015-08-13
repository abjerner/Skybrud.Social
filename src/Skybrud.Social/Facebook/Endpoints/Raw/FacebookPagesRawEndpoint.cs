using System;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.Pages;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the pages endpoint.
    /// </summary>
    public class FacebookPagesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference of the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookPagesRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the post with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the photo.</param>
        public SocialHttpResponse GetPage(string id) {
            return Client.DoAuthenticatedGetRequest("/" + id);
        }

        /// <summary>
        /// Gets information about the post matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPage(FacebookGetPageOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier, options);
        }

        #endregion

    }

}