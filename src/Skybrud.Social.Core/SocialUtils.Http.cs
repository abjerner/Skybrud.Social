using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with utility methods related to HTTP requests and responses.
        /// </summary>
        public static partial class Http {

            #region DoHttpGetRequest

            /// <summary>
            /// Makes a HTTP GET request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Get, url, default(IHttpQueryString));
            }

            /// <summary>
            /// Makes a GET request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url, IHttpGetOptions options) {
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
            public static SocialHttpResponse DoHttpGetRequest(string url, IHttpQueryString queryString) {
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
            public static SocialHttpResponse DoHttpPostRequest(string url) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Post, url, default(IHttpQueryString), default(IHttpPostData));
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpGetOptions options) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(SocialHttpMethod.Post, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpPostOptions options) {
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
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString) {
                return DoHttpRequest(SocialHttpMethod.Post, url, queryString, null);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The POST data.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpPostData postData) {
                return DoHttpRequest(SocialHttpMethod.Post, url, null, postData);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Post, url, queryString, postData);
            }

            #endregion

            #region DoHttpPutRequest

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPutRequest(string url) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Put, url, default(IHttpQueryString), default(IHttpPostData));
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPutRequest(string url, IHttpGetOptions options) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(SocialHttpMethod.Put, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPutRequest(string url, IHttpPostOptions options) {
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
            public static SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString) {
                return DoHttpRequest(SocialHttpMethod.Put, url, queryString, null);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The PUT data.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpPutRequest(string url, IHttpPostData postData) {
                return DoHttpRequest(SocialHttpMethod.Put, url, null, postData);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The PUT data of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Put, url, queryString, postData);
            }

            #endregion

            #region DoHttpPatchRequest

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPatchRequest(string url) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Patch, url, default(IHttpQueryString), default(IHttpPostData));
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPatchRequest(string url, IHttpGetOptions options) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(SocialHttpMethod.Patch, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPatchRequest(string url, IHttpPostOptions options) {
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
            public static SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString) {
                return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, null);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The PATCH data.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpPatchRequest(string url, IHttpPostData postData) {
                return DoHttpRequest(SocialHttpMethod.Patch, url, null, postData);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The PATCH data of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, postData);
            }

            #endregion

            #region DoHttpDeleteRequest

            /// <summary>
            /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpDeleteRequest(string url) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Delete, url, default(IHttpQueryString));
            }

            /// <summary>
            /// Makes a DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpDeleteRequest(string url, IHttpGetOptions options) {
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
            public static SocialHttpResponse DoHttpDeleteRequest(string url, IHttpQueryString queryString) {
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
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url) {
                return DoHttpRequest(method, url, default(IHttpQueryString), default(IHttpPostData));
            }

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="options">The options for the call to the API.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpGetOptions options) {
                IHttpQueryString queryString = options?.GetQueryString();
                return DoHttpRequest(method, url, queryString);
            }

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString) {
                return DoHttpRequest(method, url, queryString, null);
            }

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The POST data.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpPostData postData) {
                return DoHttpRequest(method, url, null, postData);
            }

            /// <summary>
            /// Makes a HTTP request using the specified <paramref name="url"/> and <paramref name="method"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            private static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, IHttpPostData postData) {

                // Initialize the request
                SocialHttpRequest request = new SocialHttpRequest {
                    Url = url,
                    Method = method,
                    QueryString = queryString,
                    PostData = postData
                };

                // Make the call to the URL
                return request.GetResponse();

            }

            #endregion

        }

    }

}