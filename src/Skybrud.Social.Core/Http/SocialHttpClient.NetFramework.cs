#if NET_FRAMEWORK

using System;
using System.Collections.Specialized;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Http {

    public partial class SocialHttpClient {

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection queryString) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Get, url, queryString);
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, default(NameValueCollection));
        }
        
        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, string contentType, string body) {
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, contentType, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, JToken body) {
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
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, body);
        }
        
        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, XNode body) {
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
        public virtual SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Post, url, queryString, body, options);
        }
        
        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, default(NameValueCollection));
        }
        
        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, string contentType, string body) {
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, contentType, body);
        }
        
        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, JToken body) {
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
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, body);
        }
        
        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, XNode body) {
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
        public virtual SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Put, url, queryString, body, options);
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, default(NameValueCollection));
        }
        
        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, string contentType, string body) {
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, contentType, body);
        }
        
        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, JToken body) {
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
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, body);
        }
        
        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, XNode body) {
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
        public virtual SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, body, options);
        }
        
        /// <summary>
        /// Makes a DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpDeleteRequest(string url, NameValueCollection queryString) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(SocialHttpMethod.Delete, url, queryString);
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString) {
            return DoHttpRequest(method, url, queryString == null ? null : new SocialHttpQueryString(queryString), default(IHttpPostData));
        }
        
        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, NameValueCollection postData) {
            return DoHttpRequest(method, url, queryString == null ? null : new SocialHttpQueryString(queryString), postData == null ? null : new SocialHttpPostData(postData));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, string contentType, string body) {
            return DoHttpRequest(method, url, queryString == null ? null : new SocialHttpQueryString(queryString), contentType, body);
        }
        
        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, JToken body) {
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
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, "application/json", body.ToString(formatting));
        }
        
        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, XNode body) {
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
        public virtual SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, "text/xml", body.ToString(options));
        }

    }

}

#endif