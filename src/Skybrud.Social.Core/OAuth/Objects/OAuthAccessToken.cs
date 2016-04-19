using System;
using System.Collections.Specialized;

namespace Skybrud.Social.OAuth.Objects {

    /// <summary>
    /// Class representing the response body of a call to get an OAuth 1.0a access token.
    /// </summary>
    public class OAuthAccessToken {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public OAuthClient Client { get; private set; }

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
        public NameValueCollection Query { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>client</code> and <code>query</code>.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="query">The query string as specified by the response body.</param>
        protected OAuthAccessToken(OAuthClient client, NameValueCollection query) {

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
        public static OAuthAccessToken Parse(OAuthClient client, string str) {

            // Convert the query string to a NameValueCollection
            NameValueCollection query = SocialUtils.Misc.ParseQueryString(str);

            // Initialize a new instance
            return new OAuthAccessToken(client, query);

        }

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="query">The query string.</param>
        public static OAuthAccessToken Parse(OAuthClient client, NameValueCollection query) {
            return query == null ? null : new OAuthAccessToken(client, query);
        }

        #endregion

    }

}