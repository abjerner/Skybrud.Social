using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the debug endpoint.
    /// </summary>
    public class FacebookDebugRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookDebugRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public SocialHttpResponse DebugToken(string accessToken) {

            // Declare the query string
            SocialQueryString query = new SocialQueryString();
            query.Add("input_token", accessToken);
            
            // Make the call to the API
            return Client.DoAuthenticatedGetRequest("/debug_token", query);
        
        }

        #endregion

    }

}