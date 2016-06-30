using System;
using System.Collections.Specialized;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Class representing a client for making HTTP requests.
    /// </summary>
    public class SocialHttpClient {

        #region GET

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            return DoHttpGetRequest(url, default(SocialHttpQueryString));
        }

        /// <summary>
        /// Makes a GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection query) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
             return DoHttpGetRequest(url, (SocialHttpQueryString) query);
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
            return DoHttpGetRequest(url, options.GetQueryString());
        }

        /// <summary>
        /// Makes a GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpGetRequest(string url, SocialHttpQueryString query) {

            // Some input validation
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Url = url,
                QueryString = query
            };

            // Do something extra for the request
            PrepareHttpRequest(request);

            // Make the request to the specified URL
            return request.GetResponse();

        }

        #endregion

        #region POST

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, IPostOptions options) {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpPostRequest(url, options.GetQueryString(), options.GetPostData(), options.IsMultipart);
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, SocialHttpQueryString query, SocialPostData postData) {
            
            // Some input validation
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = SocialHttpMethod.Post,
                Url = url,
                QueryString = query,
                PostData = postData
            };

            // Do something extra for the request
            PrepareHttpRequest(request);

            // Make the request to the specified URL
            return request.GetResponse();
        
        }

        /// <summary>
        /// Makes a POST request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <param name="isMultipart">Indicates the request should be encoded as <code>multipart/form-data</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public virtual SocialHttpResponse DoHttpPostRequest(string url, SocialHttpQueryString query, SocialPostData postData, bool isMultipart) {

            // Some input validation
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = SocialHttpMethod.Post,
                Url = url,
                QueryString = query,
                PostData = postData,
                IsMultipart = isMultipart
            };

            // Do something extra for the request
            PrepareHttpRequest(request);

            // Make the request to the specified URL
            return request.GetResponse();

        }

        #endregion

        /// <summary>
        /// Virtual method that can be used for configuring a request.
        /// </summary>
        /// <param name="request">The request.</param>
        protected virtual void PrepareHttpRequest(SocialHttpRequest request) { }

    }

}