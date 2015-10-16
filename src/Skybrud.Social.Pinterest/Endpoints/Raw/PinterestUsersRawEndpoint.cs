using System;
using Skybrud.Social.Http;
using Skybrud.Social.Pinterest.Fields;
using Skybrud.Social.Pinterest.OAuth;
using Skybrud.Social.Pinterest.Options;

namespace Skybrud.Social.Pinterest.Endpoints.Raw {
    
    public class PinterestUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public PinterestOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal PinterestUsersRawEndpoint(PinterestOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetUser(string identifier) {
            if (String.IsNullOrWhiteSpace(identifier)) throw new ArgumentNullException("identifier");
            return GetUser(new PinterestGetUserOptions(identifier));
        }

        /// <summary>
        /// Gets information about the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <param name="fields">The fields that should be returned.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetUser(string identifier, PinterestFieldsCollection fields) {
            if (String.IsNullOrWhiteSpace(identifier)) throw new ArgumentNullException("identifier");
            return GetUser(new PinterestGetUserOptions(identifier, fields));
        }

        /// <summary>
        /// Gets information about the user matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetUser(PinterestGetUserOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://api.pinterest.com/v1/users/" + options.Identifier + "/", options);
        }

        #endregion

    }

}