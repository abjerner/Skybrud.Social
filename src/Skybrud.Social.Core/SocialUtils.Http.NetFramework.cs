#if NET_FRAMEWORK

using System;
using System.Collections.Specialized;
using Skybrud.Social.Http;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        public static partial class Http {

            /// <summary>
            /// Makes a GET request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection queryString) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Get, url, queryString);
            }
            
            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString) {
                return DoHttpRequest(SocialHttpMethod.Post, url, queryString, null);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Post, url, queryString, postData);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString) {
                return DoHttpRequest(SocialHttpMethod.Put, url, queryString, null);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The PUT data of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Put, url, queryString, postData);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString) {
                return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, null);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The PATCH data of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(SocialHttpMethod.Patch, url, queryString, postData);
            }

            /// <summary>
            /// Makes a DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpDeleteRequest(string url, NameValueCollection queryString) {
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
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString) {
                return DoHttpRequest(method, url, queryString == null ? null : new SocialHttpQueryString(queryString), null);
            }
            
            /// <summary>
            /// Makes a HTTP request using the specified <paramref name="url"/> and <paramref name="method"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            private static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, NameValueCollection postData) {
                return DoHttpRequest(method, url, queryString == null ? null : new SocialHttpQueryString(queryString), postData == null ? null : new SocialHttpPostData(postData));
            }

        }

    }

}

#endif