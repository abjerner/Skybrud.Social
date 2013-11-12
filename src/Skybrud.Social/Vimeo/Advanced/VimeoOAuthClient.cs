using System.Collections.Specialized;
using Skybrud.Social.OAuth;
using Skybrud.Social.Vimeo.Advanced.Endpoints.Raw;
using Skybrud.Social.Vimeo.Advanced.Responses;

namespace Skybrud.Social.Vimeo.Advanced {
    
    public class VimeoOAuthClient : OAuthClient {

        /// <summary>
        /// Class for handling the raw communication with the channels endpoint.
        /// </summary>
        public VimeoChannelsRawEndpoint Channels { get; private set; }
        
        public VimeoOAuthClient()
            : this(null, null, null, null, null) {
            // Call overloaded constructor
        }

        public VimeoOAuthClient(string consumerKey, string consumerSecret)
            : this(consumerKey, consumerSecret, null, null, null) {
            // Call overloaded constructor
        }

        public VimeoOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret)
            : this(consumerKey, consumerSecret, token, tokenSecret, null) {
            // Call overloaded constructor
        }

        public VimeoOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) {
        
            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Specific to Vimeo
            RequestTokenUrl = "https://vimeo.com/oauth/request_token";
            AuthorizeUrl = "https://vimeo.com/oauth/authorize";
            AccessTokenUrl = "https://vimeo.com/oauth/access_token";

            // Initialize endpoints for raw data
            Channels = new VimeoChannelsRawEndpoint(this);
        
        }

        /// <summary>
        /// API description: This will just repeat back any parameters that you send.
        /// </summary>
        public string Echo() {

            NameValueCollection query = new NameValueCollection();
            query.Add("format", "json");
            query.Add("method", "vimeo.test.echo");

            return DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        /// <summary>
        /// API description: Is the user logged in?
        /// </summary>
        public VimeoTestLoginResponse Login() {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.test.login"}
            };

            // Call the Vimeo API
            string response = DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

            // TODO: Validate the server response

            // Return the response object
            return VimeoTestLoginResponse.Parse(response);

        }

    }
}
