using System;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Class representing a client for making HTTP requests.
    /// </summary>
    public class SocialHttpClient {

        #region DoHttpGetRequest

        /// <summary>
        /// Makes a HTTP GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Get, url, default(IHttpQueryString));
        }

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpRequest(SocialHttpMethod.Get, url, options.GetQueryString());
        }

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, IHttpQueryString queryString) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Get, url, queryString);
        }

        #endregion

        #region DoHttpPostRequest
        
        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Post, url, default(IHttpQueryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpRequest(SocialHttpMethod.Post, url, options.GetQueryString(), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpPostOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpRequest(SocialHttpMethod.Post, url, options.GetQueryString(), options.GetPostData());
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString) {
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, default(IHttpPostData));
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpPostData postData) {
            return DoHttpRequest(SocialHttpMethod.Post, url, null, postData);
        }
        
        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <code>application/json</code>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, string contentType, string body) {
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, contentType, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, body, options);
        }

        #endregion

        #region DoHttpPutRequest

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Put, url, default(IHttpQueryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpRequest(SocialHttpMethod.Put, url, options.GetQueryString(), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpPostOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpRequest(SocialHttpMethod.Put, url, options.GetQueryString(), options.GetPostData());
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString) {
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpPostData postData) {
            return DoHttpRequest(SocialHttpMethod.Put, url, null, postData);
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <code>application/json</code>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, string contentType, string body) {
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, contentType, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, body, options);
        }

        #endregion
        
        #region DoHttpPatchRequest

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Patch, url, default(IHttpQueryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpRequest(SocialHttpMethod.Patch, url, options.GetQueryString(), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpPostOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpRequest(SocialHttpMethod.Patch, url, options.GetQueryString(), options.GetPostData());
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, default(IHttpPostData));
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpPostData postData) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, null, postData);
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <code>application/json</code>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, string contentType, string body) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, contentType, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, null, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, body, options);
        }

        #endregion

        #region DoHttpDeleteRequest

        /// <summary>
        /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpDeleteRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Delete, url, default(IHttpQueryString));
        }

        /// <summary>
        /// Makes a DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpDeleteRequest(string url, IHttpGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpRequest(SocialHttpMethod.Delete, url, options.GetQueryString());
        }

        /// <summary>
        /// Makes a DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpDeleteRequest(string url, IHttpQueryString queryString) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Delete, url, queryString);
        }

        #endregion

        #region DoHttpRequest

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url) {
            return DoHttpRequest(method, url, default(IHttpQueryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
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
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString) {
            return DoHttpRequest(method, url, queryString, default(IHttpPostData));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
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
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, IHttpPostData postData) {

            // Some input validation
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
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

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="contentType">The content type of the request - eg. <code>application/json</code>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, string contentType, string body) {

            // Some input validation
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (queryString == null) queryString = new SocialHttpQueryString();

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = method,
                Url = url,
                QueryString = queryString,
                ContentType = contentType,
                Body = body
            };

            PrepareHttpRequest(request);

            // Make the call to the URL
            return request.GetResponse();

        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, null, "application/json", body.ToString(Formatting.None));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, null, "application/json", body.ToString(formatting));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, "application/json", body.ToString(Formatting.None));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, "application/json", body.ToString(formatting));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, null, "text/xml", body.ToString(SaveOptions.None));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, null, "text/xml", body.ToString(options));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, "text/xml", body.ToString(SaveOptions.None));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, "text/xml", body.ToString(options));
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