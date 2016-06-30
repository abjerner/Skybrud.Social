using System.Collections.Specialized;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with helper methods related to HTTP requests and responses.
        /// </summary>
        public static class Http {

            /// <summary>
            /// Makes a HTTP request using the specified <code>url</code> and <code>method</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="query">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            private static SocialHttpResponse DoHttpRequest(string url, SocialHttpMethod method, IHttpQueryString query, SocialHttpPostData postData) {

                // Initialize the request
                SocialHttpRequest request = new SocialHttpRequest {
                    Url = url,
                    Method = method,
                    QueryString = query,
                    PostData = postData
                };

                // Make the call to the URL
                return request.GetResponse();

            }

            /// <summary>
            /// Makes a HTTP GET request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url) {
                return DoHttpRequest(url, SocialHttpMethod.Get, null, null);
            }

            /// <summary>
            /// Makes a HTTP GET request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="query">The query string of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection query) {
                return DoHttpRequest(url, SocialHttpMethod.Get, new SocialHttpQueryString(query), null);
            }

            /// <summary>
            /// Makes a HTTP GET request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="query">The query string of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url, IHttpQueryString query) {
                return DoHttpRequest(url, SocialHttpMethod.Get, query, null);
            }

            /// <summary>
            /// Makes a HTTP GET request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, SocialHttpPostData postData) {
                return DoHttpRequest(url, SocialHttpMethod.Post, null, postData);
            }

        }

    }

}