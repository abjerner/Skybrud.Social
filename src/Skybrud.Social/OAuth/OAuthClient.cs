using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Skybrud.Social.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.OAuth.Objects;
using Skybrud.Social.OAuth.Responses;

namespace Skybrud.Social.OAuth {

    /// <summary>
    /// OAuth client following the OAuth 1.0a protocol. The client will handle the necessary communication with the
    /// OAuth server (Service Provider). This includes the technical part with signatures, authorization headers and
    /// similar. The client can also be used for 3-legged logins.
    /// </summary>
    public class OAuthClient {

        #region Properties

        /// <summary>
        /// Gets or sets the consumer key of your application.
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the consumer secret of your application. The consumer secret is sensitive information used to
        /// identify your application. Users should never be shown this value.
        /// </summary>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// Gets or sets a unique/random value specifying the <code>oauth_nonce</code> parameter in the OAuth protocol.
        /// Along with <code>oauth_timestamp</code>, it will make sure each request is only sent once to the OAuth
        /// server (provider).
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Gets or sets the current UNIX timestamp specifying the <code>oauth_timestamp</code> in the OAuth protocol.
        /// Along with <code>oauth_nonce</code>, it will make sure each request is only sent once to the OAuth server
        /// (provider).
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the request token or access token used to access the OAuth server on behalf of a user.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the request token secret or access token secret used to access the OAuth server on behalf of a
        /// user.
        /// </summary>
        public string TokenSecret { get; set; }

        /// <summary>
        /// Gets or sets the version of the OAuth protocol.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the callback URL. This property specified the <code>oauth_callback</code> parameter and is
        /// used for 3-legged logins. You only need to specify this property for authentication - it is not necessary
        /// toset this property when just making calls to the API. 
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// Gets or sets the request token URL. As the first step of the 3-legged login process, the client must obtain
        /// a request token through this URL. If possible this URL should always use HTTPS.
        /// </summary>
        public string RequestTokenUrl { get; set; }

        /// <summary>
        /// Gets or sets the authorization URL. As the second step of the 3-legged login process, the user is
        /// redirected to this URL for authorizing the login. If possible this URL should always use HTTPS.
        /// </summary>
        public string AuthorizeUrl { get; set; }

        /// <summary>
        /// Gets or sets the access token URL. In the final step of the 3-legged login process, the OAuth client will
        /// exchange the request token for an access token. It will do so using this URL. If possible this URL should
        /// always use HTTPS.
        /// </summary>
        public string AccessTokenUrl { get; set; }

        /// <summary>
        /// If <code>true</code>, new requests will automatically reset the <code>oauth_timestamp</code> and
        /// <code>oauth_nonce</code> with new values. It should only be disabled for testing purposes.
        /// </summary>
        public bool AutoReset { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new OAuth client with default options.
        /// </summary>
        public OAuthClient() {
            AutoReset = true;
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
            Version = "1.0";
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <code>consumerKey</code> and <code>consumerSecret</code>.
        /// </summary>
        /// <param name="consumerKey">The consumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        public OAuthClient(string consumerKey, string consumerSecret) {
            AutoReset = true;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
            Version = "1.0";
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <code>consumerKey</code>, <code>consumerSecret</code> and
        /// <code>callback</code>.
        /// </summary>
        /// <param name="consumerKey">The consumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="callback">The callback URI of your application.</param>
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

        #region Member methods

        /// <summary>
        /// Updates the <code>oauth_timestamp</code> and <code>oauth_nonce</code> parameters with new values for
        /// another request. If the property <code>AutoReset</code> is <code>true</code>, this method will be called
        /// automatically before each request to the underlying API.
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
        /// Gets a request token from the provider. After acquiring a request token, the user should be redirected
        /// to the website of the provider for approving the application. If successful, the user will be redirected
        /// back to the specified callback URL where you then can exchange the request token for an access token.
        /// </summary>
        public virtual OAuthRequestTokenResponse GetRequestToken() {

            // Make the call to the API/provider
            SocialHttpResponse response = GetRequestTokenResponse();

            // Parse the response body
            OAuthRequestToken body = OAuthRequestToken.Parse(this, response.Body);

            // Parse the response
            return OAuthRequestTokenResponse.ParseResponse(response, body);

        }

        protected virtual SocialHttpResponse GetRequestTokenResponse() {

            // Some error checking
            if (String.IsNullOrWhiteSpace(RequestTokenUrl)) throw new PropertyNotSetException("RequestTokenUrl");
            if (String.IsNullOrWhiteSpace(AuthorizeUrl)) throw new PropertyNotSetException("AuthorizeUrl");

            // Make the call to the API/provider
            return DoHttpPostRequest(RequestTokenUrl, null, null);

        }

        /// <summary>
        /// Following the 3-legged authorization, you can exchange a request token for an access token
        /// using this method. This is the third and final step of the authorization process.
        /// </summary>
        /// <param name="verifier">The verification key received after the user has accepted the app.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/auth/3-legged-authorization</cref>
        /// </see>
        public virtual OAuthAccessTokenResponse GetAccessToken(string verifier) {

            // Make the call to the API/provider
            SocialHttpResponse response = GetAccessTokenResponse(verifier);

            // Parse the response body
            OAuthAccessToken body = OAuthAccessToken.Parse(this, response.Body);

            // Parse the response
            return OAuthAccessTokenResponse.ParseResponse(response, body);

        }

        protected virtual SocialHttpResponse GetAccessTokenResponse(string verifier) {

            // Some error checking
            if (String.IsNullOrWhiteSpace(AccessTokenUrl)) throw new PropertyNotSetException("AccessTokenUrl");

            // Initialize the POST data
            NameValueCollection postData = new NameValueCollection {
                {"oauth_verifier", verifier}
            };

            // Make the call to the API/provider
            return DoHttpPostRequest(AccessTokenUrl, null, postData);

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
            return DoHttpRequest("GET", url, queryString, null);
        }

        /// <summary>
        /// Makes a signed GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="queryString">The query string.</param>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, SocialQueryString queryString) {
            return DoHttpRequest("GET", url, queryString == null ? null : queryString.NameValueCollection, null);
        }

        /// <summary>
        /// Makes a signed GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options for the call to the API.</param>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, IGetOptions options) {
            NameValueCollection nvc = (options == null ? null : options.GetQueryString().NameValueCollection);
            return DoHttpRequest("GET", url, nvc, null);
        }

        /// <summary>
        /// Makes a signed POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options for the call to the API.</param>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IPostOptions options) {

            SocialQueryString query = (options == null ? null : options.GetQueryString());
            SocialPostData postData = (options == null ? null : options.GetPostData());

            NameValueCollection nvcQuery = (query == null ? null : query.NameValueCollection);
            NameValueCollection nvcPostData = (postData == null ? null : postData.ToNameValueCollection());

            // TODO: Converting the POST data to a NameValueCollection will not support multipart data

            return DoHttpRequest("POST", url, nvcQuery, nvcPostData);

        }

        /// <summary>
        /// Makes a signed POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, NameValueCollection postData) {

            // Check if NULL
            if (queryString == null) queryString = new NameValueCollection();
            if (postData == null) postData = new NameValueCollection();

            // TODO: Converting the POST data to a NameValueCollection will not support multipart data

            return DoHttpRequest("POST", url, queryString, postData);

        }

        /// <summary>
        /// Makes a signed request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        public virtual SocialHttpResponse DoHttpRequest(string method, string url, NameValueCollection queryString, NameValueCollection postData) {

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
                return SocialHttpResponse.GetFromWebResponse((HttpWebResponse) request.GetResponse());
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse((HttpWebResponse) ex.Response);
            }

        }

        /// <summary>
        /// Makes a signed request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        public virtual SocialHttpResponse DoHttpRequest(string method, string url, SocialQueryString queryString) {

            // TODO: Should this method have is own implementation instead of calling another DoHttpRequest method?

            NameValueCollection query = queryString == null ? null : queryString.NameValueCollection;
            return DoHttpRequest(method, url, query, null);

        }

        /// <summary>
        /// Makes a signed request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="options">The options for the call to the API.</param>
        public virtual SocialHttpResponse DoHttpRequest(string method, string url, IGetOptions options) {
            SocialQueryString queryString = options == null ? null : options.GetQueryString();
            return DoHttpRequest(method, url, queryString);
        }

        #endregion

    }

}