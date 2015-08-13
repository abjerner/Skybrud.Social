using System;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.User;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw implementation of the users endpoint.
    /// </summary>
    public class FacebookUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference of the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookUsersRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        public SocialHttpResponse GetUser(string identifier) {
            return Client.DoAuthenticatedGetRequest("/" + identifier);
        }

        /// <summary>
        /// Gets information about the user matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetUser(FacebookGetUserOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier, options);
        }

        #endregion

    }

}