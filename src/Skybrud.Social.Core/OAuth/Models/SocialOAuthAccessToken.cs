using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.OAuth.Models {

    /// <summary>
    /// Class representing the response body of a call to get an OAuth 1.0a access token.
    /// </summary>
    public class SocialOAuthAccessToken {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SocialOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Gets the access token secret.
        /// </summary>
        public string TokenSecret { get; private set; }

        /// <summary>
        /// Gets a reference to the query string representing the response body.
        /// </summary>
        public IHttpQueryString Query { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="client"/> and <paramref name="query"/>.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="query">The query string as specified by the response body.</param>
        protected SocialOAuthAccessToken(SocialOAuthClient client, IHttpQueryString query) {

            Client = client;

            // Get the user ID
            long userId;
            Int64.TryParse(query["user_id"], out userId);

            // Populate the properties
            Token = query["oauth_token"];
            TokenSecret = query["oauth_token_secret"];
            Query = query;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="str">The query string.</param>
        public static SocialOAuthAccessToken Parse(SocialOAuthClient client, string str) {

            // Convert the query string to an IHttpQueryString
            IHttpQueryString query = SocialHttpQueryString.ParseQueryString(str);

            // Initialize a new instance
            return new SocialOAuthAccessToken(client, query);

        }

        #endregion

    }

}