using System.Collections.Specialized;

namespace Skybrud.Social.OAuth.Objects {

    /// <summary>
    /// Class representing the response body of a call to get an OAuth 1.0a refresh token.
    /// </summary>
    public class OAuthRequestToken {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public OAuthClient Client { get; private set; }

        /// <summary>
        /// Gets the request token.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Gets the request token secret.
        /// </summary>
        public string TokenSecret { get; private set; }

        /// <summary>
        /// Is the callback confirmed?
        /// </summary>
        public bool IsCallbackConfirmed { get; private set; }

        /// <summary>
        /// Gets the authentication URL for this request token.
        /// </summary>
        public string AuthorizeUrl { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>client</code> and <code>query</code>.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="query">The query string as specified by the response body.</param>
        protected OAuthRequestToken(OAuthClient client, NameValueCollection query) {
            Client = client;
            Token = query["oauth_token"];
            TokenSecret = query["oauth_token_secret"];
            IsCallbackConfirmed = query["oauth_callback_confirmed"] == "true";
            AuthorizeUrl = client.AuthorizeUrl + "?oauth_token=" + query["oauth_token"];
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="str">The query string.</param>
        public static OAuthRequestToken Parse(OAuthClient client, string str) {

            // Convert the query string to a NameValueCollection
            NameValueCollection query = SocialUtils.Misc.ParseQueryString(str);

            // Initialize a new instance
            return new OAuthRequestToken(client, query);

        }

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="query">The query string.</param>
        public static OAuthRequestToken Parse(OAuthClient client, NameValueCollection query) {
            return query == null ? null : new OAuthRequestToken(client, query);
        }

        #endregion

    }

}