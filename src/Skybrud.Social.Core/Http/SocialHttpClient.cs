using System;
using System.Collections.Specialized;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Class representing a client for making HTTP requests.
    /// </summary>
    public class SocialHttpClient {

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpGetRequest(url, default(SocialQueryString));
        }

        /// <summary>
        /// Makes a GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection query) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
             return DoHttpGetRequest(url, (SocialQueryString) query);
        }

        /// <summary>
        /// Makes a GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, IGetOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return SocialUtils.DoHttpGetRequest(url, options.GetQueryString());
        }

        /// <summary>
        /// Makes a GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, SocialQueryString query) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return SocialUtils.DoHttpGetRequest(url, query);
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public SocialHttpResponse DoHttpPostRequest(string url, IPostOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpPostRequest(url, options.GetQueryString(), options.GetPostData());
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public SocialHttpResponse DoHttpPostRequest(string url, SocialQueryString query, SocialPostData postData) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return SocialUtils.DoHttpPostRequest(url, query, postData);
        }

    }

}