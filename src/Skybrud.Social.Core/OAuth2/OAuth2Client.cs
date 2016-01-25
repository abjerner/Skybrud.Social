using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.OAuth2 {

    /// <summary>
    /// OAuth client following the OAuth 2.0 specification. The client will handle the necessary communication with the
    /// OAuth server (Service Provider).
    /// </summary>
    public abstract class OAuth2Client {

        #region Properties

        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        #endregion

        #region OAuth 2.0 member methods

        /// <summary>
        /// Generates the authorization URL using the specified <code>state</code>.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <returns>Returns an authorization URL based on <code>state</code>.</returns>
        public abstract string GetAuthorizationUrl(string state);

        #endregion

        #region HTTP member methods

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url) {
            return DoHttpGetRequest(url, (SocialQueryString) null);
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection query) {
            return DoHttpGetRequest(url, new SocialQueryString(query));
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, IGetOptions options) {
            return DoHttpGetRequest(url, options == null ? null : options.GetQueryString());
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, SocialQueryString query) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            
            // Initialize a new instance of SocialQueryString if the one specified is NULL
            if (query == null) query = new SocialQueryString();
            
            // Append the query string to the URL
            if (!query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Initialize a new HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // Get the HTTP response
            try {
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse);
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse);
            }

        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IPostOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpPostRequest(url, options.GetQueryString(), options.GetPostData(), options.IsMultipart);
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <param name="postData">The POST data.</param>
        /// <param name="isMultipart">If <code>true</code>, the content type of the request will be <code>multipart/form-data</code>, otherwise <code>application/x-www-form-urlencoded</code>.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, SocialQueryString query, SocialPostData postData, bool isMultipart) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize a new instance of SocialQueryString if the one specified is NULL
            if (query == null) query = new SocialQueryString();
            
            // Append the query string to the URL
            if (!query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Initialize a new HTTP request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Set the HTTP method
            request.Method = "POST";

            // Write the POST data to the request stream
            if (postData != null && postData.Count > 0) {
                if (isMultipart) {
                    string boundary = Guid.NewGuid().ToString().Replace("-", "");
                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    using (Stream stream = request.GetRequestStream()) {
                        postData.WriteMultipartFormData(stream, boundary);
                    }
                } else {
                    string dataString = postData.ToString();
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = dataString.Length;
                    using (Stream stream = request.GetRequestStream()) {
                        stream.Write(Encoding.UTF8.GetBytes(dataString), 0, dataString.Length);
                    }
                }
            }

            // Get the HTTP response
            try {
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse);
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse);
            }

        }

        #endregion

    }

    public interface IOAuthTokenResponse {

        SocialHttpResponse Response { get; }

        IOAuthToken Body { get; }

    }

    public interface IOAuthToken {



    } 

}