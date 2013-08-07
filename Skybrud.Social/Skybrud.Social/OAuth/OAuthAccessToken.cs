using System;
using System.Collections.Specialized;
using System.Web;

namespace Skybrud.Social.OAuth {
    
    public class OAuthAccessToken {

        #region Properties

        /// <summary>
        /// The access token.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// The access token secret.
        /// </summary>
        public string TokenSecret { get; private set; }

        public NameValueCollection Query { get; private set; }

        #endregion

        #region Constructor(s)

        private OAuthAccessToken() {
            // make constructor private
        }

        #endregion

        #region Static methods(s)

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="str">The query string.</param>
        public static OAuthAccessToken Parse(string str) {

            // Convert the query string to a NameValueCollection
            NameValueCollection query = HttpUtility.ParseQueryString(str);

            // Get the user ID
            long userId;
            Int64.TryParse(query["user_id"], out userId);

            // Return the access token
            return new OAuthAccessToken {
                Token = query["oauth_token"],
                TokenSecret = query["oauth_token_secret"],
                Query = query
            };

        }

        public static OAuthAccessToken Parse(NameValueCollection query) {
            return new OAuthAccessToken {
                Token = query["oauth_token"],
                TokenSecret = query["oauth_token_secret"],
                Query = query
            };
        }

        #endregion

    }

}