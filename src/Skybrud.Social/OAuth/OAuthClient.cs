using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.OAuth {

    /// <summary>
    /// OAuth client following the OAuth 1.0a protocol. The client will handle
    /// the necessary communication with the OAuth server (Service Provider).
    /// This includes the technical part with signatures, authorization headers
    /// and similar. The client can also be used for 3-legged logins.
    /// </summary>
    public class OAuthClient {

        /// <summary>
        /// The consumer key of your application.
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// The consumer secret of your application. The consumer secret is
        /// sensitiveinformation used to identify your application. Users s
        /// hould never beshown this value.
        /// </summary>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// A unique/random value specifying the <var>oauth_nonce</var>
        /// parameter in the OAuth protocol. Along with <var>oauth_timestamp</var>,
        /// it will make sure each request is only sent once to the OAUth server.
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// The current UNIX timestamp specifying the <var>oauth_timestamp</var>
        /// in the OAuth protocol. Along with <var>oauth_nonce</var>,
        /// it will make sure each request is only sent once to the OAUth server.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// The request token or access token used to access the OAuth server on behalf of a user.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The request token secret or access token secret used to access the OAuth server on behalf of a user.
        /// </summary>
        public string TokenSecret { get; set; }

        /// <summary>
        /// The version of the OAuth protocol.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// A callback URL. This property specified the <var>oauth_callback</var> parameter
        /// and is used for 3-legged logins. In most cases this proparty should be empty.
        /// </summary>
        public string Callback { get; set; }
        
        /// <summary>
        /// As the first step of the 3-legged login process, the client
        /// must obtain a request token through this URL. If possible
        /// this URL should always use HTTPS.
        /// </summary>
        public string RequestTokenUrl { get; set; }

        /// <summary>
        /// As the second step of the 3-legged login process, the user
        /// is redirected to this URL for authorizing the login. If
        /// possible this URL should always use HTTPS.
        /// </summary>
        public string AuthorizeUrl { get; set; }

        /// <summary>
        /// In the final step of the 3-legged login process, the OAuth
        /// client will exchange the request token for an access token.
        /// It will do so using this URL. If possible this URL should
        /// always use HTTPS.
        /// </summary>
        public string AccessTokenUrl { get; set; }

        /// <summary>
        /// If <var>TRUE</var>, new requests will automatically reset
        /// the <var>oauth_timestamp</var> and <var>oauth_nonce</var>
        /// with new values. I should only be disabled for testing
        /// purposes.
        /// </summary>
        public bool AutoReset { get; set; }

        #region Constructors

        public OAuthClient() {
            AutoReset = true;
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
            Version = "1.0";
        }

        public OAuthClient(string consumerKey, string consumerSecret) {
            AutoReset = true;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
            Version = "1.0";
        }

        public OAuthClient(string consumerKey, string consumerSecret, string callback) {
            AutoReset = true;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Callback = callback;
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
            Version = "1.0";
        }

        #endregion

        /// <summary>
        /// Updates the <var>oauth_timestamp</var> and <var>oauth_nonce</var>
        /// parameters with new values for another request.
        /// </summary>
        public virtual void Reset() {
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
        }

        /// <summary>
        /// Generates the string for the authorization header based on the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        public virtual string GenerateHeaderString(string signature) {
            string oauthHeaders = "OAuth realm=\"\",";
            if (!String.IsNullOrEmpty(Callback)) oauthHeaders += "oauth_callback=\"" + Uri.EscapeDataString(Callback) + "\",";
            oauthHeaders += "oauth_consumer_key=\"" + Uri.EscapeDataString(ConsumerKey) + "\",";
            oauthHeaders += "oauth_nonce=\"" + Uri.EscapeDataString(Nonce) + "\",";
            oauthHeaders += "oauth_signature=\"" + Uri.EscapeDataString(signature) + "\",";
            oauthHeaders += "oauth_signature_method=\"HMAC-SHA1\",";
            oauthHeaders += "oauth_timestamp=\"" + Timestamp + "\",";
            if (!String.IsNullOrEmpty(Token)) oauthHeaders += "oauth_token=\"" + Uri.EscapeDataString(Token) + "\",";
            oauthHeaders += "oauth_version=\"" + Version + "\"";
            return oauthHeaders;
        }

        /// <summary>
        /// Generates the the string of parameters used for making the signature.
        /// </summary>
        /// <param name="queryString">Values representing the query string.</param>
        /// <param name="body">Values representing the POST body.</param>
        public virtual string GenerateParameterString(NameValueCollection queryString, NameValueCollection body) {

            // The parameters must be alphabetically sorted
            SortedDictionary<string, string> sorted = new SortedDictionary<string, string>();

            // Add parameters from the query string
            if (queryString != null) {
                foreach (string key in queryString) {
                    //if (key.StartsWith("oauth_")) continue;
                    sorted.Add(Uri.EscapeDataString(key), Uri.EscapeDataString(queryString[key]));
                }
            }
            
            // Add parameters from the POST data
            if (body != null) {
                foreach (string key in body) {
                    //if (key.StartsWith("oauth_")) continue;
                    sorted.Add(Uri.EscapeDataString(key), Uri.EscapeDataString(body[key]));
                }
            }

            // Add OAuth values
            if (!String.IsNullOrEmpty(Callback)) sorted.Add("oauth_callback", Uri.EscapeDataString(Callback));
            sorted.Add("oauth_consumer_key", Uri.EscapeDataString(ConsumerKey));
            sorted.Add("oauth_nonce", Uri.EscapeDataString(Nonce));
            sorted.Add("oauth_signature_method", "HMAC-SHA1");
            sorted.Add("oauth_timestamp", Uri.EscapeDataString(Timestamp));
            if (!String.IsNullOrEmpty(Token)) sorted.Add("oauth_token", Uri.EscapeDataString(Token));
            sorted.Add("oauth_version", Uri.EscapeDataString(Version));

            // Merge all parameters
            return sorted.Aggregate("", (current, pair) => current + ("&" + pair.Key + "=" + pair.Value)).Substring(1);

        }

        /// <summary>
        /// Generates the key used for making the signature.
        /// </summary>
        /// <returns></returns>
        public virtual string GenerateSignatureKey() {
            return Uri.EscapeDataString(ConsumerSecret ?? "") + "&" + Uri.EscapeDataString(TokenSecret ?? "");
        }

        /// <summary>
        /// Generates the string value used for making the signature.
        /// </summary>
        /// <param name="method">The method for the HTTP request.</param>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The POST data.</param>
        /// <returns></returns>
        public virtual string GenerateSignatureValue(string method, string url, NameValueCollection queryString, NameValueCollection body) {
            return String.Format(
                "{0}&{1}&{2}",
                method,
                Uri.EscapeDataString(url.Split('#')[0].Split('?')[0]),
                Uri.EscapeDataString(GenerateParameterString(queryString, body))
            );
        }

        /// <summary>
        /// Generate the signature.
        /// </summary>
        /// <param name="method">The method for the HTTP request.</param>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The POST data.</param>
        public virtual string GenerateSignature(string method, string url, NameValueCollection queryString, NameValueCollection body) {
            HMACSHA1 hasher = new HMACSHA1(new ASCIIEncoding().GetBytes(GenerateSignatureKey()));
            return Convert.ToBase64String(hasher.ComputeHash(new ASCIIEncoding().GetBytes(GenerateSignatureValue(method, url, queryString, body))));
        }

        /// <summary>
        /// Gets a request token from the Twitter API. After acquiring a request token, the user
        /// should be redirected to the Twitter website for approving the application. If successful,
        /// the user will be redirected back to the specified callback URL where you then can exchange
        /// the request token for an access token.
        /// </summary>
        public virtual OAuthRequestToken GetRequestToken() {

            // Some error checking
            if (RequestTokenUrl == null) throw new ArgumentNullException("RequestTokenUrl");
            if (AuthorizeUrl == null) throw new ArgumentNullException("AuthorizeUrl");
            
            // Get the request token
            HttpStatusCode status;
            string response = DoHttpRequestAsString("POST", RequestTokenUrl, null, null, out status);

            // Check for errors
            if (status != HttpStatusCode.OK) {
                throw new OAuthException(status, response);
            }

            // Convert the query string to a NameValueCollection
            NameValueCollection query = HttpUtility.ParseQueryString(response);

            // Return the request token
            return new OAuthRequestToken {
                Token = query["oauth_token"],
                TokenSecret = query["oauth_token_secret"],
                CallbackConfirmed = query["oauth_callback_confirmed"] == "true",
                AuthorizeUrl = AuthorizeUrl + "?oauth_token=" + query["oauth_token"]
            };

        }

        /// <summary>
        /// Following the 3-legged authorization, you can exchange a request token for an access token
        /// using this method. This is the third and final step of the authorization process.
        /// </summary>
        /// <param name="verifier">The verification key received after the user has accepted the app.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/auth/3-legged-authorization</cref>
        /// </see>
        public virtual OAuthAccessToken GetAccessToken(string verifier) {
            return OAuthAccessToken.Parse(GetAccessTokenQuery(verifier));
        }

        /// <summary>
        /// Makes a signed GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        public virtual SocialHttpResponse DoHttpGetRequest(string url) {
            return DoHttpGetRequest(url, default(NameValueCollection));
        }

        /// <summary>
        /// Makes a signed GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="queryString">The query string.</param>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection queryString) {
            return SocialHttpResponse.GetFromWebResponse(DoHttpRequest("GET", url, queryString, null));
        }

        /// <summary>
        /// Makes a signed GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options for the call to the API.</param>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, IGetOptions options) {
            NameValueCollection nvc = (options == null ? null : options.GetQueryString().NameValueCollection);
            return SocialHttpResponse.GetFromWebResponse(DoHttpRequest("GET", url, nvc, null));
        }

        /// <summary>
        /// Makes a signed request to the Twitter API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        public virtual HttpWebResponse DoHttpRequest(string method, string url, NameValueCollection queryString, NameValueCollection postData) {

            // Check if NULL
            if (queryString == null) queryString = new NameValueCollection();
            if (postData == null) postData = new NameValueCollection();
            
            // Merge the query string
            if (queryString.Count > 0) {
                UriBuilder builder = new UriBuilder(url);
                url += (url.Contains("?") ? "&" : "") + builder.MergeQueryString(queryString).Query;
            }

            // Initialize the request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Generate the signature
            string signature = GenerateSignature(method, url, queryString, postData);

            // Generate the header
            string header = GenerateHeaderString(signature);

            // Add the authorization header
            request.Headers.Add("Authorization", header);

            // Set the method
            request.Method = method;

            // Add the request body (if a POST request)
            if (method == "POST" && postData.Count > 0) {
                string dataString = SocialUtils.NameValueCollectionToQueryString(postData);
                //throw new Exception(dataString);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = dataString.Length;
                using (Stream stream = request.GetRequestStream()) {
                    stream.Write(Encoding.UTF8.GetBytes(dataString), 0, dataString.Length);
                }
            }

            // Make sure we reset the client (timestamp and nonce)
            if (AutoReset) Reset();

            // Get the response
            try {
                return (HttpWebResponse) request.GetResponse();
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return (HttpWebResponse) ex.Response;
            }

        }

        /// <summary>
        /// Makes a signed request to the Twitter API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        public virtual HttpWebResponse DoHttpRequest(string method, string url, SocialQueryString queryString) {

            // TODO: Should this method have is own implementation instead of calling another DoHttpRequest method?
        
            NameValueCollection query = queryString == null ? null : queryString.NameValueCollection;
            return DoHttpRequest(method, url, query, null);
        
        }

        /// <summary>
        /// Makes a signed request to the Twitter API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="options">The options for the call to the API.</param>
        public virtual HttpWebResponse DoHttpRequest(string method, string url, IGetOptions options) {
            SocialQueryString queryString = options == null ? null : options.GetQueryString();
            return DoHttpRequest(method, url, queryString);
        }

        /// <summary>
        /// Makes a signed request to the Twitter API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        public virtual string DoHttpRequestAsString(string method, string url, NameValueCollection queryString = null, NameValueCollection postData = null) {
            using (HttpWebResponse response = DoHttpRequest(method, url, queryString, postData)) {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Makes a signed request to the Twitter API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        /// <param name="statusCode">The status code of the response.</param>
        public virtual string DoHttpRequestAsString(string method, string url, NameValueCollection queryString, NameValueCollection postData, out HttpStatusCode statusCode) {
            using (HttpWebResponse response = DoHttpRequest(method, url, queryString, postData)) {
                statusCode = response.StatusCode;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
        }

        private NameValueCollection GetAccessTokenQuery(string verifier) {

            // Some error checking
            if (AccessTokenUrl == null) throw new ArgumentNullException("AccessTokenUrl");

            // Get the access token
            HttpStatusCode status;
            string response = DoHttpRequestAsString("POST", AccessTokenUrl, null, new NameValueCollection {{"oauth_verifier", verifier}}, out status);

            // Check for errors
            if (status != HttpStatusCode.OK) {
                throw new OAuthException(status, response);
            }

            // Convert the query string to a NameValueCollection
            return HttpUtility.ParseQueryString(response);

        }
    
    }

}
