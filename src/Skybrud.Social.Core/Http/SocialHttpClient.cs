using System;
using System.Collections.Specialized;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Class representing a client for making HTTP requests.
    /// </summary>
    public class SocialHttpClient {

        #region DoHttpGetRequest

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Get, url, default(IHttpQueryString));
        }

        /// <summary>
        /// Makes a GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection queryString) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Get, url, new SocialHttpQueryString(queryString));
        }

        /// <summary>
        /// Makes a GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpRequest(SocialHttpMethod.Get, url, options.GetQueryString());
        }

        /// <summary>
        /// Makes a GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, IHttpQueryString queryString) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Get, url, queryString);
        }

        #endregion

        #region DoHttpPostRequest
        
        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Post, url, default(IHttpQueryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(SocialHttpMethod.Post, url, new SocialHttpQueryString(queryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            return DoHttpRequest(SocialHttpMethod.Post, url, new SocialHttpQueryString(queryString), new SocialHttpPostData(postData));
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpRequest(SocialHttpMethod.Post, url, options.GetQueryString(), null);
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpPostOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpRequest(SocialHttpMethod.Post, url, options.GetQueryString(), options.GetPostData());
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString) {
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, null);
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpPostData postData) {
            return DoHttpRequest(SocialHttpMethod.Post, url, null, postData);
        }
        
        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, postData);
        }

        #endregion

        #region DoHttpPutRequest

        /// <summary>
        /// Makes a PUT request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Put, url, default(IHttpQueryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PUT request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(SocialHttpMethod.Put, url, new SocialHttpQueryString(queryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PUT request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            return DoHttpRequest(SocialHttpMethod.Put, url, new SocialHttpQueryString(queryString), new SocialHttpPostData(postData));
        }

        /// <summary>
        /// Makes a PUT request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpRequest(SocialHttpMethod.Put, url, options.GetQueryString(), null);
        }

        /// <summary>
        /// Makes a PUT request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpPostOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpRequest(SocialHttpMethod.Put, url, options.GetQueryString(), options.GetPostData());
        }

        /// <summary>
        /// Makes a PUT request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString) {
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, null);
        }

        /// <summary>
        /// Makes a PUT request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpPostData postData) {
            return DoHttpRequest(SocialHttpMethod.Put, url, null, postData);
        }

        /// <summary>
        /// Makes a PUT request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, postData);
        }

        #endregion
        
        #region DoHttpPatchRequest

        /// <summary>
        /// Makes a PATCH request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Patch, url, default(IHttpQueryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PATCH request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, new SocialHttpQueryString(queryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PATCH request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, new SocialHttpQueryString(queryString), new SocialHttpPostData(postData));
        }

        /// <summary>
        /// Makes a PATCH request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpRequest(SocialHttpMethod.Patch, url, options.GetQueryString(), null);
        }

        /// <summary>
        /// Makes a PATCH request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpPostOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpRequest(SocialHttpMethod.Patch, url, options.GetQueryString(), options.GetPostData());
        }

        /// <summary>
        /// Makes a PATCH request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, null);
        }

        /// <summary>
        /// Makes a PATCH request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpPostData postData) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, null, postData);
        }

        /// <summary>
        /// Makes a PATCH request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, postData);
        }

        #endregion

        #region DoHttpDeleteRequest

        /// <summary>
        /// Makes a HTTP DELETE request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpDeleteRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Delete, url, default(IHttpQueryString));
        }

        /// <summary>
        /// Makes a DELETE request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpDeleteRequest(string url, NameValueCollection queryString) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Delete, url, new SocialHttpQueryString(queryString));
        }

        /// <summary>
        /// Makes a DELETE request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpDeleteRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpRequest(SocialHttpMethod.Delete, url, options.GetQueryString());
        }

        /// <summary>
        /// Makes a DELETE request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpDeleteRequest(string url, IHttpQueryString queryString) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpRequest(SocialHttpMethod.Delete, url, queryString);
        }

        #endregion

        #region DoHttpRequest

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url) {
            return DoHttpRequest(method, url, default(IHttpQueryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString) {
            return DoHttpRequest(method, url, new SocialHttpQueryString(queryString), null);
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, NameValueCollection postData) {
            return DoHttpRequest(method, url, new SocialHttpQueryString(queryString), new SocialHttpPostData(postData));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpGetOptions options) {
            IHttpQueryString queryString = options == null ? null : options.GetQueryString();
            return DoHttpRequest(method, url, queryString);
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString) {
            return DoHttpRequest(method, url, queryString, null);
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpPostData postData) {
            return DoHttpRequest(method, url, null, postData);
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, IHttpPostData postData) {

            // Some input validation
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (queryString == null) queryString = new SocialHttpQueryString();
            if (postData == null) postData = new SocialHttpPostData();

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = method,
                Url = url,
                QueryString = queryString,
                PostData = postData
            };

            PrepareHttpRequest(request);

            // Make the call to the URL
            return request.GetResponse();

        }

        #endregion

        #region Other

        /// <summary>
        /// Virtual method that can be used for configuring a request.
        /// </summary>
        /// <param name="request">The request.</param>
        protected virtual void PrepareHttpRequest(SocialHttpRequest request) { }

        #endregion

    }

}