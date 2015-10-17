using System.Collections.Specialized;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Responses.Authentication {

    public class FacebookTokenResponse : FacebookResponse<FacebookTokenResponseBody> {

        #region Properties

        /// <summary>
        /// Gets the value of the <code>X-FB-Trace-ID</code> header.
        /// </summary>
        public string FacebookTraceId { get; private set; }
        
        /// <summary>
        /// Gets the value of the <code>X-FB-Rev</code> header.
        /// </summary>
        public string FacebookRevision { get; private set; }
        
        /// <summary>
        /// Gets the value of the <code>Facebook-API-Version</code> header.
        /// </summary>
        public string FacebookApiVersion { get; private set; }
        
        /// <summary>
        /// Gets the value of the <code>X-FB-Stats-Contexts</code> header.
        /// </summary>
        public string FacebookStatsContext { get; private set; }
        
        /// <summary>
        /// Gets the value of the <code>X-FB-Debug</code> header.
        /// </summary>
        public string FacebookDebug { get; private set; }

        #endregion

        #region Constructors

        private FacebookTokenResponse(SocialHttpResponse response) : base(response) {

            // Parse headers from the response
            FacebookTraceId = response.Headers["X-FB-Trace-ID"];
            FacebookRevision = response.Headers["X-FB-Rev"];
            FacebookApiVersion = response.Headers["Facebook-API-Version"];
            FacebookStatsContext = response.Headers["X-FB-Stats-Contexts"];
            FacebookDebug = response.Headers["X-FB-Debug"];

            // Parse the response body
            Body = FacebookTokenResponseBody.Parse(response.Body);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>FacebookTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>FacebookTokenResponse</code>.</returns>
        public static FacebookTokenResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new FacebookTokenResponse(response);
        }

        #endregion

    }

    public class FacebookTokenResponseBody {

        #region Properties

        public string AccessToken { get; private set; }

        #endregion

        #region Constructors

        private FacebookTokenResponseBody() { }

        #endregion

        public static FacebookTokenResponseBody Parse(string contents) {
            
            // Parse the contents
            NameValueCollection body = SocialUtils.ParseQueryString(contents);

            // Initialize the response body
            return new FacebookTokenResponseBody {
                AccessToken = body["access_token"]
            };

        }

    }

}